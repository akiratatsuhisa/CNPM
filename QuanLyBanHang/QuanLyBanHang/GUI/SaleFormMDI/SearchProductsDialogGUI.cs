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

namespace QuanLyBanHang.GUI.SaleFormMDI
{
    public partial class SearchProductsDialogGUI : DevExpress.XtraEditors.XtraForm
    {
        public SearchProductsDialogGUI()
        {
            InitializeComponent();
        }
        internal bool Result { get; private set; }
        internal string SearchName { get; private set; }
        internal decimal? MinUnitPrice { get; private set; }
        internal decimal? MaxUnitPrice { get; private set; }
        private void ckbUnitPriceFrom_CheckedChanged(object sender, EventArgs e)
        {
            nudMinPrice.Enabled = ckbUnitPriceFrom.CheckState == CheckState.Checked ? true : false;
        }
        private void ckbUnitPriceTo_CheckedChanged(object sender, EventArgs e)
        {
            nudMaxPrice.Enabled = ckbUnitPriceTo.CheckState == CheckState.Checked ? true : false;
        }
        private void nudMinPrice_ValueChanged(object sender, EventArgs e)
        {
            if (ckbUnitPriceTo.Checked && nudMaxPrice.Value < nudMinPrice.Value)
            {
                nudMinPrice.Value = nudMaxPrice.Value;
            }
        }
        private void nudMaxPrice_ValueChanged(object sender, EventArgs e)
        {
            if (ckbUnitPriceFrom.Checked && nudMaxPrice.Value < nudMinPrice.Value)
            {
                nudMaxPrice.Value = nudMinPrice.Value;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (!string.IsNullOrWhiteSpace(txbProductName.Text))
            {
                SearchName = txbProductName.Text.Trim();
                flag = true;
            }
            else
            {
                SearchName = null;
            }
            if (ckbUnitPriceFrom.Checked)
            {
                MinUnitPrice = nudMinPrice.Value;
                flag = true;
            }
            if (ckbUnitPriceTo.Checked)
            {
                MaxUnitPrice = nudMaxPrice.Value;
                flag = true;
            }
            Result = flag;
            Close();
        }
        private void SearchProductDialog_KeyDown(object sender, KeyEventArgs e)
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