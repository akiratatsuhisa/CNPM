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
    public partial class LoginFormGUI : Form
    {
        public LoginFormGUI()
        {
            InitializeComponent();
        }
        internal bool Result { get; private set; }
        private void btnClose_Click(object sender, EventArgs e) => Close();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txbUsername.Text == "admin" && txbPassword.Text == "admin")
            {
                Result = true;
                Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại.\nTài khoản hoặc mật khẩu bị sai.");
            }
        }
        private void LoginGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
