using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace QuanLyBanHang.GUI
{
    public partial class MainFormGUI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainFormGUI()
        {
            InitializeComponent();
            var form = new SaleFormGUI();
            form.MdiParent = this;
            form.Show();
        }
        private void barBtnSale_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var child in MdiChildren)
            {
                if (child is SaleFormGUI)
                {
                    child.BringToFront();
                    return;
                }
            }
            var form = new SaleFormGUI();
            form.MdiParent = this;
            form.Show();
        }
        private void barBtnListCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var child in MdiChildren)
            {
                if (child is CustomersFormGUI)
                {
                    child.BringToFront();
                    return;
                }
            }
            var form = new CustomersFormGUI();
            form.MdiParent = this;
            form.Show();
        }

        private void barBtnEmployees_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var child in MdiChildren)
            {
                if (child is EmployeesFormGUI)
                {
                    child.BringToFront();
                    return;
                }
            }
            var form = new EmployeesFormGUI();
            form.MdiParent = this;
            form.Show();
        }

        private void barBtnCustomers_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var child in MdiChildren)
            {
                if (child is CustomersFormGUI)
                {
                    child.BringToFront();
                    return;
                }
            }
            var form = new CustomersFormGUI();
            form.MdiParent = this;
            form.Show();
        }

        private void barBtnProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var child in MdiChildren)
            {
                if (child is ProductsFormGUI)
                {
                    child.BringToFront();
                    return;
                }
            }
            var form = new ProductsFormGUI();
            form.MdiParent = this;
            form.Show();
        }
    }
}