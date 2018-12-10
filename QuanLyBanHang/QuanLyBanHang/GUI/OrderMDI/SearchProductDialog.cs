using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.OrderMDI
{
    public partial class SearchProductDialog : Form
    {
        public SearchProductDialog()
        {
            InitializeComponent();
        }
        private void ckbProductName_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbProductName.CheckState == CheckState.Checked)
            {
                txtProductName.ReadOnly = false;
            }
            else
            {
                txtProductName.ReadOnly = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        internal string SearchName { get; private set; }
        internal decimal? MinUnitPrice { get; private set; }
        internal decimal? MaxUnitPrice { get; private set; }
        internal bool Result { get; private set; } = false;
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (ckbProductName.Checked && !string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                SearchName = txtProductName.Text.Trim();
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
