﻿using QuanLyBanHang.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.GUI.OrderMDI;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class OrderGUI : Form
    {
        private ProductsBUS _productsContext = new ProductsBUS();

        private OrdersBUS _ordersContext = new OrdersBUS();
        public OrderGUI()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            flpProduct.Controls.Clear();
            _productsContext.GetProductCanBuy().ForEach(o => flpProduct.Controls.
              Add(new ProductUserControl(o.ProductID, o.ProductName, o.QuantityPerUnit, o.UnitPrice, o.UnitsInStock, this)));
            }
        private void CheckProducts()
        {
            var list = dgvDetail.Rows.Cast<DataGridViewRow>().ToList();
            foreach (var item in flpProduct.Controls)
            {
                if (item is ProductUserControl objUS)
                {
                    var obj = list.SingleOrDefault(o => o.Cells[0].Value.ToString() == objUS.ProductID);
                    if (obj != null)
                    {
                        objUS.UnitInStock -= int.Parse(obj.Cells[3].Value.ToString());
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Clear();
            LoadProducts();
            txtTotal.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedCells.Count > 0)
            {
                dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                LoadProducts();
                CheckProducts();
                txtTotal.Text = dgvDetail.Rows.Cast<DataGridViewRow>().
                    Sum(o => decimal.Parse(o.Cells[2].Value.ToString()) * decimal.Parse(o.Cells[3].Value.ToString())).ToString();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count>0)
            {
                AddOrderDialog dialog = new AddOrderDialog();
                dialog.txtTotal.Text = txtTotal.Text;
                dialog.txtIntoMoney.Text = txtTotal.Text;
                dialog.ShowDialog();
                if (dialog.ReturnValue)
                {
                    string message;
                    if (_ordersContext.AddOrder(new OrderDTO
                    {
                        EmployeeID = int.Parse(dialog.cbxEmployeeID.SelectedItem.ToString()),
                        CustomerID = int.Parse(dialog.txtCustomerID.Text),
                        Freight = dialog.Freight,
                        OrderDate = DateTime.Now
                    },
                    dgvDetail.Rows.Cast<DataGridViewRow>().Select(o => new OrderDetailDTO
                    {
                        ProductID = int.Parse(o.Cells[0].Value.ToString()),
                        UnitPrice = decimal.Parse(o.Cells[2].Value.ToString()),
                        Quantity = int.Parse(o.Cells[3].Value.ToString()),
                    }).ToList()
                    , out message))
                    {
                        MessageBox.Show("Đã mua.");
                        btnClear_Click(sender, e);
                    }
                    else
                    {
                        if (MessageBox.Show("Có lỗi trong quá trình đặt hàng.", "Lỗi.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            MessageBox.Show(message, "Lỗi thông báo từ server.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng đặt hàng.");
            }
            LoadProducts();
        }

        private void btnReloadList_Click(object sender, EventArgs e)
        {
            LoadProducts();
            CheckProducts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProductsDialog dialog = new SearchProductsDialog();
            dialog.ShowDialog();
            if (dialog.Result)
            {
                flpProduct.Controls.Clear();
                bool? result;
                _productsContext.GetSearchListProduct(dialog.SearchName, dialog.MinUnitPrice, dialog.MaxUnitPrice, out result)
                    .ForEach(o => flpProduct.Controls.
                  Add(new ProductUserControl(o.ProductID, o.ProductName, o.QuantityPerUnit, o.UnitPrice, o.UnitsInStock, this)));
                CheckProducts();
                if (result == null)
                {
                    MessageBox.Show("Không tìm thấy.");
                }
                else if (result == false)
                {
                    MessageBox.Show("Lỗi kết nối tới máy chủ.");
                }
            }
        }
    }
}
