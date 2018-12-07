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
        public CustomersGUI()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
      
        private void SetEnable(bool value)
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
            rdbFemale.Enabled = value;
            rdbMale.Enabled = value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetEnable(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEnable(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetEnable(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetEnable(false);
        }
    }
}
