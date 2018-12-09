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
            dgvCustomers.Columns[0].HeaderText = "Mã KH";
            dgvCustomers.Columns[1].HeaderText = "Tên";
            dgvCustomers.Columns[2].HeaderText = "Giới tính";
            dgvCustomers.Columns[3].HeaderText = "Điện thoại";
            dgvCustomers.Columns[4].HeaderText = "Địa chỉ";
            dgvCustomers.Columns[5].HeaderText = "Email";
        }

        private void SetOkButtonEnable(bool value)
        {
            // Tắt button trong lúc thay đổi dữ liệu
            btnAdd.Enabled = !value;
            btnEdit.Enabled = !value;
            btnDelete.Enabled = !value;
            btnSave.Enabled = value;
            btnCancel.Enabled = value;
            btnExit.Enabled = !value;
            // Mở khóa nhập liệu
            txtName.ReadOnly = !value;
            txtPhone.ReadOnly = !value;
            txtAddress.ReadOnly = !value;
            txtEmail.ReadOnly = !value;
            cbxFemale.Enabled = value;
            cbxMale.Enabled = value;
        }       
    }
}
