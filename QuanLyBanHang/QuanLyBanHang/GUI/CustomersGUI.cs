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
    public partial class CustomersGUI : Form
    {
        private CustomersBUS _customersContext = new CustomersBUS();
        public CustomersGUI()
        {
            InitializeComponent();
            // Lấy danh sách đặt tên cho Columns theo thứ tự bên DTO
            dgvCustomers.DataSource = _customersContext.GetList();
            dgvCustomers.Columns[0].HeaderText = "Mã KH";
            dgvCustomers.Columns[1].HeaderText = "Tên";
            dgvCustomers.Columns[2].HeaderText = "Giới tính";
            dgvCustomers.Columns[3].HeaderText = "Điện thoại";
            dgvCustomers.Columns[4].HeaderText = "Địa chỉ";
            dgvCustomers.Columns[5].HeaderText = "Email";
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
            txtPhoneNumber.ReadOnly = !value;
            txtAddress.ReadOnly = !value;
            txtEmail.ReadOnly = !value;
            rdbFemale.Enabled = value;
            rdbMale.Enabled = value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(true);
            //Xóa sạch textBox để nhập
            txtCustomerID.Text = "";
            txtName.Text = "";
            txtPhoneNumber.Text = "";
            rdbMale.Checked = true;
            txtAddress.Text = "";
            txtEmail.Text = "";
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
            if (!string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                string message = "Bạn có thực sự muốn xóa khách hàng tên: " + txtName.Text + ", ID: " + txtCustomerID.Text + " không?";
                if (MessageBox.Show(message, "Xóa khách hàng.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string serverMessage;
                    if (_customersContext.DeleteCustomer(_selectedID, out serverMessage))
                    {
                        MessageBox.Show("Xóa thành công.");
                        dgvCustomers.DataSource = _customersContext.GetList();
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
                MessageBox.Show("Chọn khách hàng cần xóa");
            }
            grbButton.Text = "Chức Năng";
        }
        private bool Check(out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtName.Text))
                message += "Nhập tên khách hàng.\n";
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                message += "Nhập số điện thoại.\n";
            else if(!Regex.IsMatch(txtPhoneNumber.Text, @"^0(3[3-9]|7[06789]|8[1-5]|5[689])\d{7}$"))
                message += "Số điện thoại: " + txtPhoneNumber.Text + " không hợp lệ.\n";
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
                message += "Nhập địa chỉ.\n";
            return message == "" ? true : false;
        }
        private bool _isAddButtonClicked = false;
        private void btnOK_Click(object sender, EventArgs e)
        {
            string serverMessage;
            if(!Check(out serverMessage))
            {
                MessageBox.Show(serverMessage, "Thiếu dữ kiện.");
                return;
            }
            CustomerDTO customerFormat = new CustomerDTO
            {
                Name = string.IsNullOrWhiteSpace(txtName.Text) ? null : txtName.Text.Trim(),
                Gender = rdbMale.Checked ? "Nam" : "Nữ",
                PhoneNumber = string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ? null : txtPhoneNumber.Text,
                Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim()
            };
            bool completed = false;
            if (_isAddButtonClicked)
            {
                if (_customersContext.AddCustomer(customerFormat, out serverMessage))
                {
                    MessageBox.Show("Thêm thành công khách hàng tên: " + txtName.Text + ", ID: " + txtCustomerID.Text + ".");
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
                customerFormat.CustomerID = int.Parse(txtCustomerID.Text);
                if (_customersContext.EditCustomer(customerFormat, out serverMessage))
                {
                    MessageBox.Show("Sửa thành công khách hàng tên: " + txtName.Text + ", ID: " + txtCustomerID.Text + ".");
                    completed = true;
                }
                else
                {
                    string message = "Có lỗi xảy ra trong quá trình sửa khách hàng.\nXem chi tiết?";
                    if (MessageBox.Show(message, "Không thể sửa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        MessageBox.Show(serverMessage);
                }
            }
            if(completed)
            {
                SetOkButtonEnable(false);
                grbButton.Text = "Chức Năng";
                dgvCustomers.DataSource = _customersContext.GetList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(false);
            try
            {
                CustomerDTO selectedItem = _customersContext.GetList().Single(o => o.CustomerID == _selectedID);
                txtCustomerID.Text = selectedItem.CustomerID.ToString();
                txtName.Text = selectedItem.Name;
                if (selectedItem.Gender == "Nam")
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;
                txtPhoneNumber.Text = selectedItem.PhoneNumber;
                txtAddress.Text = selectedItem.Address;
                txtEmail.Text = selectedItem.Email;
            }
            catch
            {
                MessageBox.Show("Có vấn đề trong việc truy xuất tới máy chủ.","Lỗi.");
            }
            grbButton.Text = "Chức Năng";
        }
        private int _selectedID;
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedCells.Count > 0)
            {
                int rowIndex = dgvCustomers.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvCustomers.Rows[rowIndex];

                txtCustomerID.Text = selectedRow.Cells[0].Value?.ToString();
                txtName.Text = selectedRow.Cells[1].Value?.ToString();
                if (selectedRow.Cells[2].Value?.ToString() == "Nam")
                    rdbMale.Checked = true;
                else   
                    rdbFemale.Checked = true;          
                txtPhoneNumber.Text = selectedRow.Cells[3].Value?.ToString();
                txtAddress.Text = selectedRow.Cells[4].Value?.ToString();
                txtEmail.Text = selectedRow.Cells[5].Value?.ToString();

                _selectedID = int.Parse(txtCustomerID.Text);
            }
        }
    }
}
