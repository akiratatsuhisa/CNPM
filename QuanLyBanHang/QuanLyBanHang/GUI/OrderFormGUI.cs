using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyBanHang.BUS;
using QuanLyBanHang.GUI.OrderMDI;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class OrderFormGUI : DevExpress.XtraEditors.XtraForm
    {
        private ProductsBUS _productsContext = new ProductsBUS();
        private OrdersBUS _ordersContext = new OrdersBUS();
        public OrderFormGUI()
        {
            InitializeComponent();
            LoadProducts();
        }
        private void LoadProducts()
        {
            flpProduct.Controls.Clear();
            _productsContext.GetProductCanBuy().ForEach(o => flpProduct.Controls.
              Add(new ProductUserControlGUI(o.ProductID, o.ProductName, o.QuantityPerUnit, o.UnitPrice, o.UnitsInStock, this)));
        }
        private void CheckProducts()
        {
            var list = dgvDetail.Rows.Cast<DataGridViewRow>().ToList();
            foreach (var item in flpProduct.Controls)
            {
                if (item is ProductUserControlGUI objUS)
                {
                    var obj = list.SingleOrDefault(o => o.Cells[0].Value.ToString() == objUS.ProductID);
                    if (obj != null)
                    {
                        objUS.UnitInStock -= int.Parse(obj.Cells[3].Value.ToString());
                    }
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProductsDialogGUI dialog = new SearchProductsDialogGUI();
            dialog.ShowDialog();
            if (dialog.Result)
            {
                flpProduct.Controls.Clear();
                bool? result;

                var resultList = _productsContext.GetSearchListProduct(dialog.SearchName, dialog.MinUnitPrice, dialog.MaxUnitPrice, out result);
                if (result == true)
                {
                    resultList.ForEach(o => flpProduct.Controls.
                    Add(new ProductUserControlGUI(o.ProductID, o.ProductName, o.QuantityPerUnit, o.UnitPrice, o.UnitsInStock, this)));
                    CheckProducts();
                }
                else if (result == null)
                {
                    MessageBox.Show("Không tìm thấy.");
                }
                else
                {
                    MessageBox.Show("Lỗi kết nối tới máy chủ.");
                }
            }
        }
        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadProducts();
            CheckProducts();
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count > 0)
            {
                AddOrderDialogGUI dialog = new AddOrderDialogGUI(txbTotal.Text);
                dialog.ShowDialog();
                if (dialog.Result)
                {
                    string message;
                    if (_ordersContext.AddOrder(new OrderDTO
                    {
                        EmployeeID = dialog.EmployeeID,
                        CustomerID = dialog.CustomerID,
                        Freight = dialog.Freight,
                        OrderDate = DateTime.Now
                    },
                    dgvDetail.Rows.Cast<DataGridViewRow>().Select(o => new OrderDetailDTO
                    {
                        ProductID = int.Parse(o.Cells[0].Value.ToString()),
                        UnitPrice = decimal.Parse(o.Cells[2].Value.ToString()),
                        Quantity = int.Parse(o.Cells[3].Value.ToString()),
                    }).ToList(), out message))
                    {
                        MessageBox.Show("Đã mua.");
                        btnClear_Click(sender, e);
                        LoadProducts();
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
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedCells.Count > 0)
            {
                dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                LoadProducts();
                CheckProducts();
                txbTotal.Text = dgvDetail.Rows.Cast<DataGridViewRow>().
                    Sum(o => decimal.Parse(o.Cells[2].Value.ToString()) * decimal.Parse(o.Cells[3].Value.ToString())).ToString();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvDetail.Rows.Clear();
            LoadProducts();
            txbTotal.Text = "";
        }
    }
}