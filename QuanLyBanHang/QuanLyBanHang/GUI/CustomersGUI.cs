using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            dgvCustomers.DataSource = _customersContext.GetList();
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
            txtCustomerName.ReadOnly = !value;
            txtPhone.ReadOnly = !value;
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
            txtCustomerName.Text = "";
            txtPhone.Text = "";
            rdbMale.Checked = true;
            txtAddress.Text = "";
            txtEmail.Text = "";
            _isAddButtonClicked = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(true);
            _isAddButtonClicked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                string message = "Bạn có thực sự muốn xóa khách hàng tên: " + txtCustomerName.Text + ", ID: " + txtCustomerID.Text + " không?";
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
        }
        private bool _isAddButtonClicked = false;
        private void btnOK_Click(object sender, EventArgs e)
        {
            CustomerDTO customerFormat = new CustomerDTO
            {
                Name = txtCustomerName.Text,
                Gender = rdbMale.Checked ? "Nam" : "Nữ",
                PhoneNumber = txtPhone.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text
            };
            if (_isAddButtonClicked)
            {
                string serverMessage;
                if (_customersContext.AddCustomer(customerFormat, out serverMessage))
                {
                    MessageBox.Show("Thêm thành công khách hàng tên: " + txtCustomerName.Text + ", ID: " + txtCustomerID.Text + ".");
                    SetOkButtonEnable(false);
                    dgvCustomers.DataSource = _customersContext.GetList();

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
                string serverMessage;
                if (_customersContext.EditCustomer(customerFormat, out serverMessage))
                {
                    MessageBox.Show("Sửa thành công khách hàng tên: " + txtCustomerName.Text + ", ID: " + txtCustomerID.Text + ".");
                    SetOkButtonEnable(false);
                    dgvCustomers.DataSource = _customersContext.GetList();
                }
                else
                {
                    string message = "Có lỗi xảy ra trong quá trình sửa khách hàng.\nXem chi tiết?";
                    if (MessageBox.Show(message, "Không thể sửa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        MessageBox.Show(serverMessage);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetOkButtonEnable(false);
            try
            {
                CustomerDTO selectedItem = _customersContext.GetList().Single(o => o.CustomerID == _selectedID);
                txtCustomerID.Text = selectedItem.CustomerID.ToString();
                txtCustomerName.Text = selectedItem.Name;
                if (selectedItem.Gender == "Nam")
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;
                txtPhone.Text = selectedItem.PhoneNumber;
                txtAddress.Text = selectedItem.Address;
                txtEmail.Text = selectedItem.Email;
            }
            catch
            {
                MessageBox.Show("Có vấn đề trong việc truy xuất tới máy chủ.","Lỗi.");
            }
        }
        private int _selectedID;
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedCells.Count > 0)
            {
                int rowIndex = dgvCustomers.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvCustomers.Rows[rowIndex];

                txtCustomerID.Text = selectedRow.Cells[0].Value.ToString();
                txtCustomerName.Text = selectedRow.Cells[1].Value.ToString();
                if (selectedRow.Cells[2].Value.ToString() == "Nam")
                    rdbMale.Checked = true;
                else   
                    rdbFemale.Checked = true;          
                txtPhone.Text = selectedRow.Cells[3].Value.ToString();
                txtAddress.Text = selectedRow.Cells[4].Value.ToString();
                txtEmail.Text = selectedRow.Cells[5].Value.ToString();

                _selectedID = int.Parse(txtCustomerID.Text);
            }
        }
    }
}
