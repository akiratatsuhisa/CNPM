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
        private bool _customerIsValid;
        private EmployeesBUS _employeesContext = new EmployeesBUS();
        private CustomersBUS _customersContext = new CustomersBUS();
        private List<CustomerDTO> listCustomer;
        public AddOrderDialogGUI()
        {
            InitializeComponent();
        }
        public AddOrderDialogGUI(string total)
        {
            InitializeComponent();
            cbxEmployeeID.DataSource = _employeesContext.GetSalesEmployees();
            listCustomer = _customersContext.GetList();
            txbTotal.Text = total;
            txbIntoMoney.Text = total;
        }
        internal bool Result { get; private set; }
        internal int CustomerID { get; private set; }
        internal int EmployeeID { get; private set; }
        internal decimal Freight { get; private set; }
        private void txtFreight_TextChanged(object sender, EventArgs e)
        {
            decimal freight;
            if (decimal.TryParse(txbFreight.Text, out freight))
                if (freight > 0)
                    txbIntoMoney.Text = (freight + int.Parse(txbTotal.Text)).ToString();
                else
                    txbIntoMoney.Text = txbTotal.Text;
            else
                txbIntoMoney.Text = txbTotal.Text;
        }
        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbCustomerID.Text))
            {
                txbCustomerName.Text = "";
                _customerIsValid = false;
            }
            else
            {
                int id;
                if (int.TryParse(txbCustomerID.Text, out id))
                {
                    var customer = listCustomer.SingleOrDefault(obj => obj.CustomerID == id);
                    if (customer != null)
                    {
                        txbCustomerName.Text = customer.Name;
                        _customerIsValid = true;
                    }
                    else
                    {
                        txbCustomerName.Text = "";
                        _customerIsValid = false;
                    }
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool Check(out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txbCustomerID.Text))
            {
                message += "Nhập mã khách hàng.\n";
            }
            else if (!Regex.IsMatch(txbCustomerID.Text.Trim(), @"^\d+$"))
            {
                message += "Mã  khách hàng: " + txbCustomerID.Text + " không hợp lệ.\n";
            }
            else if (!_customerIsValid)
            {
                message += "Khách hàng không tồn tại, Xin hãy nhập thông tin khách hàng trước khi đặt hàng.\n";
            }
            else
            {
                CustomerID = int.Parse(txbCustomerID.Text);
            }
            if (cbxEmployeeID.SelectedItem == null)
            {
                message += "Nhập mã nhân viên.\n";
            }
            else
            {
                EmployeeID = int.Parse(cbxEmployeeID.SelectedItem.ToString());
            }
            if (!string.IsNullOrWhiteSpace(txbFreight.Text))
            {
                try
                {
                    Freight = int.Parse(txbFreight.Text);
                }
                catch (Exception)
                {
                    message += "Phí: " + txbFreight.Text + " không hợp lệ.\n";
                }
            }
            else
            {
                Freight = 0;
            }
            return message == "" ? true : false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string message;
            if (Check(out message))
            {
                Result = true;
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
    }
}