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
using QuanLyBanHang.DTO;
using System.Text.RegularExpressions;

namespace QuanLyBanHang.GUI
{
    public partial class CustomersFormGUI : DevExpress.XtraEditors.XtraForm
    {
        private CustomersBUS _customersContext = new CustomersBUS();
        private bool _isAddButtonClicked = false;
        private bool _isOkButtonEnabled = false;
        private int? _selectedID;
        public CustomersFormGUI()
        {
            InitializeComponent();
            // Lấy danh sách
            dgvCustomer.DataSource = _customersContext.GetList();
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
            txbPhoneNumber.ReadOnly = !value;
            txbAddress.ReadOnly = !value;
            txbEmail.ReadOnly = !value;
            rdbFemale.Enabled = value;
            rdbMale.Enabled = value;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(true);
            //Xóa sạch textBox để nhập
            txbCustomerID.Text = "";
            txbName.Text = "";
            txbPhoneNumber.Text = "";
            rdbMale.Checked = true;
            txbAddress.Text = "";
            txbEmail.Text = "";
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
                MessageBox.Show("Chọn khách hàng cần sửa.");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            lcgButton.Text = "Chức Năng - Xóa";
            if (_selectedID != null)
            {
                string message = "Bạn có thực sự muốn xóa khách hàng tên: " + txbName.Text + ", ID: " + txbCustomerID.Text + " không?";
                if (MessageBox.Show(message, "Xóa khách hàng.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string serverMessage;
                    if (_customersContext.DeleteCustomer(_selectedID.Value, out serverMessage))
                    {
                        MessageBox.Show("Xóa thành công.");
                        dgvCustomer.DataSource = _customersContext.GetList();
                    }
                    else
                    {
                        message = "Có lỗi xảy ra trong quá trình xóa khách hàng.\nXem chi tiết?";
                        if (MessageBox.Show(message, "Không thể xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            MessageBox.Show(serverMessage);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn khách hàng cần xóa.");
            }
            lcgButton.Text = "Chức Năng";
        }
        private bool Check(out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txbName.Text))
                message += "Nhập tên khách hàng.\n";
            if (string.IsNullOrWhiteSpace(txbPhoneNumber.Text))
                message += "Nhập số điện thoại.\n";
            else if (!Regex.IsMatch(txbPhoneNumber.Text, @"^0(3[2-9]|5[2689]|7[06789]|8[1-689]|9[0-9])\d{7}$"))
                message += "Số điện thoại: " + txbPhoneNumber.Text + " không hợp lệ.\n";
            if (string.IsNullOrWhiteSpace(txbAddress.Text))
                message += "Nhập địa chỉ.\n";
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
            CustomerDTO customerFormat = new CustomerDTO
            {
                Name = string.IsNullOrWhiteSpace(txbName.Text) ? null : txbName.Text.Trim(),
                Gender = rdbMale.Checked ? "Nam" : "Nữ",
                PhoneNumber = string.IsNullOrWhiteSpace(txbPhoneNumber.Text) ? null : txbPhoneNumber.Text,
                Address = string.IsNullOrWhiteSpace(txbAddress.Text) ? null : txbAddress.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txbEmail.Text) ? null : txbEmail.Text.Trim()
            };
            bool completed = false;
            if (_isAddButtonClicked)
            {
                if (_customersContext.AddCustomer(customerFormat, out serverMessage))
                {
                    MessageBox.Show("Thêm thành công khách hàng tên: " + txbName.Text + ", ID: " + serverMessage + ".");
                    completed = true;
                }
                else
                {
                    string message = "Có lỗi xảy ra trong quá trình thêm khách hàng.\nXem chi tiết?";
                    if (MessageBox.Show(message, "Không thể thêm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        MessageBox.Show(serverMessage);
                }
            }
            else
            {
                customerFormat.CustomerID = int.Parse(txbCustomerID.Text);
                if (_customersContext.EditCustomer(customerFormat, out serverMessage))
                {
                    MessageBox.Show("Sửa thành công khách hàng tên: " + txbName.Text + ", ID: " + txbCustomerID.Text + ".");
                    completed = true;
                }
                else
                {
                    string message = "Có lỗi xảy ra trong quá trình sửa khách hàng.\nXem chi tiết?";
                    if (MessageBox.Show(message, "Không thể sửa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        MessageBox.Show(serverMessage);
                }
            }
            if (completed)
            {
                SetOkButtonEnable(false);
                lcgButton.Text = "Chức Năng";
                dgvCustomer.DataSource = _customersContext.GetList();
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
                    var selectedItem = dgvCustomer.Rows.Cast<DataGridViewRow>().Single(o => o.Cells[0].Value.ToString() == _selectedID.ToString());
                    txbCustomerID.Text = _selectedID.ToString();
                    txbName.Text = selectedItem.Cells[1].Value?.ToString();
                    if (selectedItem.Cells[2].Value?.ToString() == "Nam")
                        rdbMale.Checked = true;
                    else
                        rdbFemale.Checked = true;
                    txbPhoneNumber.Text = selectedItem.Cells[3].Value?.ToString();
                    txbAddress.Text = selectedItem.Cells[4].Value?.ToString();
                    txbEmail.Text = selectedItem.Cells[5].Value?.ToString();
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
        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedCells.Count > 0 && !_isOkButtonEnabled)
            {
                int rowIndex = dgvCustomer.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvCustomer.Rows[rowIndex];

                txbCustomerID.Text = selectedRow.Cells[0].Value?.ToString();
                txbName.Text = selectedRow.Cells[1].Value?.ToString();
                if (selectedRow.Cells[2].Value?.ToString() == "Nam")
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;
                txbPhoneNumber.Text = selectedRow.Cells[3].Value?.ToString();
                txbAddress.Text = selectedRow.Cells[4].Value?.ToString();
                txbEmail.Text = selectedRow.Cells[5].Value?.ToString();

                _selectedID = int.Parse(txbCustomerID.Text);
            }
            else if (dgvCustomer.SelectedCells.Count == 0 && !_isOkButtonEnabled)
            {
                _selectedID = null;
            }
        }
    }
}