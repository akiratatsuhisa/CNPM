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
    public partial class LoginGUI : Form
    {
        public bool CanLogin { get; private set;}
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txbUsername.Text == "admin" && txbPassword.Text == "admin")
            {
                CanLogin = true;
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
