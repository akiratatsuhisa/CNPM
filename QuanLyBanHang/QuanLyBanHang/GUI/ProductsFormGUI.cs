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
using System.Text.RegularExpressions;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang.GUI
{
    public partial class ProductsFormGUI : DevExpress.XtraEditors.XtraForm
    {
        private ProductsBUS _productsContext = new ProductsBUS();
        private bool _isAddButtonClicked = false;
        private bool _isOkButtonEnabled = false;
        private int? _selectedID;
        public ProductsFormGUI()
        {
            InitializeComponent();
            // Lấy danh sách
            dgvProduct.DataSource = _productsContext.GetList();
        }
        private void SetOkButtonEnable(bool value)
        {
            // Tắt button trong lúc thay đổi dữ liệu
            btnAdd.Enabled = !value;
            btnEdit.Enabled = !value;
            btnDelete.Enabled = !value;
            btnOK.Enabled = value;
            btnCancel.Enabled = value;
            _isOkButtonEnabled = value;
            // Mở khóa nhập liệu
            txbName.ReadOnly = !value;
            txbUnitPrice.ReadOnly = !value;
            txbUnitsOnOrder.ReadOnly = !value;
            txbUnitsInStock.ReadOnly = !value;
            cbxQuantityPerUnit.Enabled = value;
            dtpAddedDate.Enabled = value;
            rdbIsDiscontinued.Enabled = value;
            rdbIsContinued.Enabled = value;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(true);
            //Xóa sạch textBox để nhập
            txbProductID.Text = "";
            txbName.Text = "";
            txbUnitPrice.Text = "";
            txbUnitsInStock.Text = "";
            txbUnitsOnOrder.Text = "";
            cbxQuantityPerUnit.SelectedItem = null;
            dtpAddedDate.Value = DateTime.Now.AddYears(-18);
            rdbIsContinued.Checked = true;  
            _isAddButtonClicked = true;
            lcgButton.Text = "Chức Năng - Thêm";
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedID != null)
            {
                SetOkButtonEnable(true);
                _isAddButtonClicked = false;
                lcgButton.Text = "Chức Năng - Sửa";
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm cần sửa.");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            lcgButton.Text = "Chức Năng - Xóa";
            if (_selectedID != null)
            {
                string message = "Bạn có thực sự muốn xóa sản phẩm tên: " + txbName.Text + ", ID: " + txbProductID.Text + " không?";
                if (MessageBox.Show(message, "Xóa sản phẩm.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string serverMessage;
                    if (_productsContext.DeleteProduct(_selectedID.Value, out serverMessage))
                    {
                        MessageBox.Show("Xóa thành công.");
                        dgvProduct.DataSource = _productsContext.GetList();
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
                MessageBox.Show("Chọn sản phẩm cần xóa.");
            }
            lcgButton.Text = "Chức Năng";
        }
        private bool Check(out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txbName.Text))
                message += "Nhập tên sản phẩm.\n";
            int number;
            if (int.TryParse(txbUnitsInStock.Text, out number))
            {
                if (number < 0)
                {
                    message += "Đơn vị trong kho không được là số âm.\n";
                }
            }
            else if (!string.IsNullOrWhiteSpace(txbUnitsInStock.Text))
            {
                message += "Đơn vị trong kho: " + txbUnitsInStock.Text + " không hợp lệ.\n";
            }
            if (int.TryParse(txbUnitsOnOrder.Text, out number))
            {
                if (number < 0)
                {
                    message += "Đơn vị trong đơn không được là số âm.\n";
                }
            }
            else if (!string.IsNullOrWhiteSpace(txbUnitsOnOrder.Text))
            {
                message += "Đơn vị trong đơn: " + txbUnitsOnOrder.Text + " không hợp lệ.\n";
            }
            decimal price;
            if (decimal.TryParse(txbUnitPrice.Text, out price))
            {
                if (price < 0)
                {
                    message += "Giá sản phẩm không được là số âm.\n";
                }
            }
            else if (!string.IsNullOrWhiteSpace(txbUnitPrice.Text))
            {
                message += "Giá sản phẩm: " + txbUnitPrice.Text + " không hợp lệ.\n";
            }
            return message == "" ? true : false;
        }
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
                ProductName = txbName.Text.Trim(),
                AddedDate = dtpAddedDate.Value,
                QuantityPerUnit = cbxQuantityPerUnit.SelectedItem?.ToString() ?? "Không xác định",
                UnitPrice = string.IsNullOrWhiteSpace(txbUnitPrice.Text) ? 0 : decimal.Parse(txbUnitPrice.Text),
                UnitsInStock = string.IsNullOrWhiteSpace(txbUnitsInStock.Text) ? 0 : int.Parse(txbUnitsInStock.Text),
                UnitsOnOrder = string.IsNullOrWhiteSpace(txbUnitsOnOrder.Text) ? 0 : int.Parse(txbUnitsOnOrder.Text),
                Discontinued = rdbIsContinued.Checked ? "Bán" : "Dừng bán"
            };
            bool completed = false;
            if (_isAddButtonClicked)
            {
                productFormat.AddedDate = DateTime.Now;
                if (_productsContext.AddProduct(productFormat, out serverMessage))
                {
                    MessageBox.Show("Thêm thành công sản phẩm tên: " + txbName.Text + ", ID: " + serverMessage + ".");
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
                productFormat.ProductID = int.Parse(txbProductID.Text);
                if (_productsContext.EditProduct(productFormat, out serverMessage))
                {
                    MessageBox.Show("Sửa thành công sản phẩm tên: " + txbName.Text + ", ID: " + txbProductID.Text + ".");
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
                lcgButton.Text = "Chức Năng";
                dgvProduct.DataSource = _productsContext.GetList();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(false);
            lcgButton.Text = "Chức Năng";
            if (_selectedID != null)
            {
                try
                {
                    var selectedItem = dgvProduct.Rows.Cast<DataGridViewRow>().Single(o => o.Cells[0].Value.ToString() == _selectedID.ToString());
                    txbProductID.Text = _selectedID.ToString();
                    txbName.Text = selectedItem.Cells[1].Value?.ToString();
                    dtpAddedDate.Value = DateTime.Parse(selectedItem.Cells[2].Value?.ToString());
                    cbxQuantityPerUnit.SelectedItem = selectedItem.Cells[3].Value?.ToString();
                    txbUnitPrice.Text = selectedItem.Cells[4].Value?.ToString();
                    txbUnitsInStock.Text = selectedItem.Cells[5].Value?.ToString();
                    txbUnitsOnOrder.Text = selectedItem.Cells[6].Value?.ToString();
                    if (selectedItem.Cells[7].Value?.ToString() == "Bán")
                        rdbIsContinued.Checked = true;
                    else
                        rdbIsDiscontinued.Checked = true;
                }
                catch
                {
                    MessageBox.Show("Có vấn đề trong việc truy xuất dữ liệu.", "Lỗi.");
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedCells.Count > 0 && !_isOkButtonEnabled)
            {
                int rowIndex = dgvProduct.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvProduct.Rows[rowIndex];

                txbProductID.Text = selectedRow.Cells[0].Value?.ToString();
                txbName.Text = selectedRow.Cells[1].Value?.ToString();
                dtpAddedDate.Value = DateTime.Parse(selectedRow.Cells[2].Value?.ToString());
                cbxQuantityPerUnit.SelectedItem = selectedRow.Cells[3].Value?.ToString();
                txbUnitPrice.Text = selectedRow.Cells[4].Value?.ToString();
                txbUnitsInStock.Text = selectedRow.Cells[5].Value?.ToString();
                txbUnitsOnOrder.Text = selectedRow.Cells[6].Value?.ToString();
                if (selectedRow.Cells[7].Value?.ToString() == "Bán")
                    rdbIsContinued.Checked = true;
                else
                    rdbIsDiscontinued.Checked = true;

                _selectedID = int.Parse(txbProductID.Text);
            }
            else if (dgvProduct.SelectedCells.Count == 0 && !_isOkButtonEnabled)
            {
                _selectedID = null;
            }
        }
    }
}