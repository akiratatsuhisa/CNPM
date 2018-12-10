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

namespace QuanLyBanHang.GUI.OrderMDI
{
    public partial class AddOrderDialog : Form
    {
        public bool ReturnValue = false;

        public decimal? Freight { get; private set; }
        public AddOrderDialog()
        {
            InitializeComponent();
        }
        private void txtFreight_TextChanged(object sender, EventArgs e)
        {
            decimal freight;
            if (decimal.TryParse(txtFreight.Text, out freight))
                if (freight > 0)
                    txtIntoMoney.Text = (freight + int.Parse(txtTotal.Text)).ToString();
                else
                    txtIntoMoney.Text = txtTotal.Text;
            else
                txtIntoMoney.Text = txtTotal.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool Check(out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                message += "Nhập mã khách hàng.\n";
            }
            else if (!Regex.IsMatch(txtCustomerID.Text.Trim(), @"^\d+$"))
            {
                message += "Mã  khách hàng: " + txtCustomerID.Text + " không hợp lệ.\n";
            }
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                message += "Nhập mã nhân viên.\n";
            }
            else if (!Regex.IsMatch(txtEmployeeID.Text.Trim(), @"^\d+$"))
            {
                message += "Mã nhân viên: " + txtEmployeeID.Text + " không hợp lệ.\n";
            }
            if (!string.IsNullOrWhiteSpace(txtFreight.Text))
            {
                try
                {
                    Freight = int.Parse(txtFreight.Text);
                }
                catch (Exception)
                {
                    message += "Phí: " + txtFreight.Text + " không hợp lệ.\n";
                }
            }
            else
            {
                Freight = null;
            }
            return message == "" ? true : false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string message;
            if (Check(out message))
            {
                ReturnValue = true;
                Close();
            }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}
