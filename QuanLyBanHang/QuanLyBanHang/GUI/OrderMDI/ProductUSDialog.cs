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
    public partial class ProductUSDialog : Form
    {
        public ProductUSDialog()
        {
            InitializeComponent();
        }
        public ProductUSDialog(int unitInStock)
        {
            InitializeComponent();
            txtUnitInStock.Text = unitInStock.ToString();
            nudQuantity.Maximum = unitInStock;
        }
        public bool Bought = false;
        private void ProductUSDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
            else if(e.KeyCode == Keys.Return)
            {
                btnOK_Click(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Bought = false;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Bought = true;
            Close();
        }
    }
}
