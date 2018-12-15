using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI
{
    public partial class ProductsGUI : DevExpress.XtraEditors.XtraForm
    {
        private ProductsBUS _productsContext = new ProductsBUS();
    
        public ProductsGUI()
        {
            InitializeComponent();
            // Lấy danh sách
            dgvProducts.DataSource = _productsContext.GetList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SetOkButtonEnable(bool value)
        {
            // Tắt button trong lúc thay đổi dữ liệu
            btnAdd.Enabled = !value;
            btnEdit.Enabled = !value;
            btnDelete.Enabled = !value;
            btnOK.Enabled = value;
            btnCancel.Enabled = value;
            btnExit.Enabled = !value;
            // Mở khóa nhập liệu
            txtName.ReadOnly = !value;
            txtUnitPrice.ReadOnly = !value;
            txtUnitsInStock.ReadOnly = !value;
            txtUnitsOnOrder.ReadOnly = !value;
            cbxQuantityPerUnit.Enabled = value;
            dtpAddedDate.Enabled = value;
            rdbIsDiscontinued.Enabled = value;
            rdbIsContinued.Enabled = value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(true);
            //Xóa sạch textBox để nhập
            txtProductID.Text = "";
            txtName.Text = "";
            dtpAddedDate.Value = DateTime.Now;
            cbxQuantityPerUnit.SelectedItem = null;
            txtUnitPrice.Text = "";
            txtUnitsInStock.Text = "";
            txtUnitsOnOrder.Text = "";
            rdbIsContinued.Checked = true;
            _isAddButtonClicked = true;
            grbButton.Text = "Chức Năng - Thêm";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(true);
            _isAddButtonClicked = false;
            grbButton.Text = "Chức Năng - Sửa";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            grbButton.Text = "Chức Năng - Xóa";
            if (!string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                string message = "Bạn có thực sự muốn xóa sản phẩm tên: " + txtName.Text + ", ID: " + txtProductID.Text + " không?";
                if (MessageBox.Show(message, "Xóa sản phẩm.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string serverMessage;
                    if (_productsContext.DeleteProduct(_selectedID, out serverMessage))
                    {
                        MessageBox.Show("Xóa thành công.");
                        dgvProducts.DataSource = _productsContext.GetList();
                    }
                    else
                    {
                        message = "Có lỗi xảy ra trong quá trình xóa sản phẩm.\nXem chi tiết?";
                        if (MessageBox.Show(message, "Không thể xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            MessageBox.Show(serverMessage);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm cần xóa");
            }
            grbButton.Text = "Chức Năng";
        }
        private bool Check(out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtName.Text))
                message += "Nhập tên sản phẩm.\n";
            int number;
            if (int.TryParse(txtUnitsInStock.Text, out number))
            {
                if (number < 0)
                {
                    message += "Đơn vị trong kho không được là số âm.\n";
                }
            }
            else if(!string.IsNullOrWhiteSpace(txtUnitsInStock.Text))
            {
                message += "Đơn vị trong kho: " + txtUnitsInStock.Text + " không hợp lệ.\n";
            }
            if (int.TryParse(txtUnitsOnOrder.Text, out number))
            {
                if (number < 0)
                {
                    message += "Đơn vị trong đơn không được là số âm.\n";
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtUnitsOnOrder.Text))
            {
                message += "Đơn vị trong đơn: " + txtUnitsOnOrder.Text + " không hợp lệ.\n";
            }
            decimal price;
            if (decimal.TryParse(txtUnitPrice.Text, out price))
            {
                if (price < 0)
                {
                    message += "Giá sản phẩm không được là số âm.\n";
                }
            }
            else if (!string.IsNullOrWhiteSpace(txtUnitPrice.Text))
            {
                message += "Giá sản phẩm: " + txtUnitPrice.Text + " không hợp lệ.\n";
            }
            return message == "" ? true : false;
        }
        private bool _isAddButtonClicked = false;
        private void btnOK_Click(object sender, EventArgs e)
        {
            string serverMessage;
            if (!Check(out serverMessage))
            {
                MessageBox.Show(serverMessage, "Thiếu dữ kiện.");
                return;
            }
            ProductDTO productFormat = new ProductDTO
            {
                ProductName = txtName.Text.Trim(),
                AddedDate = dtpAddedDate.Value,
                QuantityPerUnit = cbxQuantityPerUnit.SelectedItem?.ToString() ?? "Không xác định",
                UnitPrice = string.IsNullOrWhiteSpace(txtUnitPrice.Text)? 0 : decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = string.IsNullOrWhiteSpace(txtUnitsInStock.Text) ? 0 : int.Parse(txtUnitsInStock.Text),
                UnitsOnOrder = string.IsNullOrWhiteSpace(txtUnitsOnOrder.Text) ? 0 : int.Parse(txtUnitsOnOrder.Text),
                Discontinued = rdbIsContinued.Checked ? "Bán" : "Dừng bán"
            };
            bool completed = false;
            if (_isAddButtonClicked)
            {
                productFormat.AddedDate = DateTime.Now;
                if (_productsContext.AddProduct(productFormat, out serverMessage))
                {
                    MessageBox.Show("Thêm thành công sản phẩm tên: " + txtName.Text + ", ID: " + txtProductID.Text + ".");
                    completed = true;
                }
                else
                {
                    string message = "Có lỗi xảy ra trong quá trình thêm sản phẩm.\nXem chi tiết?";
                    if (MessageBox.Show(message, "Không thể thêm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        MessageBox.Show(serverMessage);
                }
            }
            else
            {
                productFormat.ProductID = int.Parse(txtProductID.Text);
                if (_productsContext.EditProduct(productFormat, out serverMessage))
                {
                    MessageBox.Show("Sửa thành công sản phẩm tên: " + txtName.Text + ", ID: " + txtProductID.Text + ".");
                    completed = true;
                }
                else
                {
                    string message = "Có lỗi xảy ra trong quá trình sửa sản phẩm.\nXem chi tiết?";
                    if (MessageBox.Show(message, "Không thể sửa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        MessageBox.Show(serverMessage);
                }
            }
            if (completed)
            {
                SetOkButtonEnable(false);
                grbButton.Text = "Chức Năng";
                dgvProducts.DataSource = _productsContext.GetList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(false);
            try
            {
                var selectedItem = dgvProducts.Rows.Cast< ProductDTO>().Single(o => o.ProductID == _selectedID);
                txtProductID.Text = selectedItem.ProductID.ToString();
                txtName.Text = selectedItem.ProductName;
                dtpAddedDate.Value = selectedItem.AddedDate;
                cbxQuantityPerUnit.SelectedItem = selectedItem.QuantityPerUnit;
                txtUnitPrice.Text = selectedItem.UnitPrice.ToString();
                txtUnitsInStock.Text = selectedItem.UnitsInStock.ToString();
                txtUnitsOnOrder.Text = selectedItem.UnitsOnOrder.ToString();
                if (selectedItem.Discontinued == "Bán")
                    rdbIsContinued.Checked = true;
                else
                    rdbIsDiscontinued.Checked = true;
            }
            catch
            {
                MessageBox.Show("Có vấn đề trong việc truy xuất tới máy chủ.", "Lỗi.");
            }
            grbButton.Text = "Chức Năng";
        }
        private int _selectedID;
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedCells.Count > 0)
            {
                int rowIndex = dgvProducts.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvProducts.Rows[rowIndex];
                //Thứ tự gán theo bên file DTO
                txtProductID.Text = selectedRow.Cells[0].Value?.ToString();
                txtName.Text = selectedRow.Cells[1].Value?.ToString();
                dtpAddedDate.Value = DateTime.Parse(selectedRow.Cells[2].Value?.ToString());
                cbxQuantityPerUnit.SelectedItem = selectedRow.Cells[3].Value?.ToString();
                txtUnitPrice.Text = selectedRow.Cells[4].Value?.ToString();
                txtUnitsInStock.Text = selectedRow.Cells[5].Value?.ToString();
                txtUnitsOnOrder.Text = selectedRow.Cells[6].Value?.ToString();
                if (selectedRow.Cells[7].Value?.ToString() == "Bán")
                    rdbIsContinued.Checked = true;
                else
                    rdbIsDiscontinued.Checked = true;
                //gán ID ngầm để truy xuất ngược khi hủy
                _selectedID = int.Parse(txtProductID.Text);
            }
        }
    }
}
