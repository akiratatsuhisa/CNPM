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

namespace QuanLyBanHang.GUI.OrderMDI
{
    public partial class AddOrderDialogGUI : DevExpress.XtraEditors.XtraForm
    {
        public bool ReturnValue { get; set; } = false;
        private bool _customerIsValid;
        private EmployeesBUS _employeesContext = new EmployeesBUS();
        private CustomersBUS _customersContext = new CustomersBUS();
        private List<CustomerDTO> listCustomer;
        public decimal? Freight { get; private set; }
        public AddOrderDialogGUI()
        {
            InitializeComponent();
            cbxEmployeeID.DataSource = _employeesContext.GetSalesEmployees();
            listCustomer = _customersContext.GetList();
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
            else if (!_customerIsValid)
            {
                message += "Khách hàng không tồn tại, Xin hãy nhập thông tin khách hàng trước khi đặt hàng.\n";
            }
            if (cbxEmployeeID.SelectedItem == null)
            {
                message += "Nhập mã nhân viên.\n";
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
        private void AddOrderDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Return)
            {
                btnOK_Click(sender, e);
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                txtCustomerName.Text = "";
                _customerIsValid = false;
            }
            else
            {
                int id;
                if (int.TryParse(txtCustomerID.Text, out id))
                {
                    var customer = listCustomer.SingleOrDefault(obj => obj.CustomerID == id);
                    if (customer != null)
                    {
                        txtCustomerName.Text = customer.Name;
                        _customerIsValid = true;
                    }
                    else
                    {
                        txtCustomerName.Text = "";
                        _customerIsValid = false;
                    }
                }
            }
        }
    }
}