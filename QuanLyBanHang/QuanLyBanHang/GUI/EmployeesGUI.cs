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
    public partial class EmployeesGUI : Form
    {
        public EmployeesGUI()
        {
            InitializeComponent();
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
            btnSave.Enabled = value;
            btnCancel.Enabled = value;
            btnExit.Enabled = !value;
            // Mở khóa nhập liệu
            txtName.ReadOnly = !value;
            txtPhone.ReadOnly = !value;
            txtAddress.ReadOnly = !value;
            txtBirthDay.ReadOnly = !value;
            txtCMND.ReadOnly = !value;
            txtID.ReadOnly = !value;
            chbFemale.Enabled = value;
            chbMale.Enabled = value;
        }
    }
}
