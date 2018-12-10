using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.OrderMDI
{
    public partial class ProductUserControl : UserControl
    {
        public ProductUserControl()
        {
            InitializeComponent();
        }
        private OrderGUI _owner;
        public ProductUserControl(int id, string name, string quantityPerUnit, decimal unitPrice,int unitInStock, OrderGUI owner) 
        {
            InitializeComponent();
            txtProductID.Text = id.ToString();
            txtName.Text = name;
            txtQuantityPerUnit.Text = quantityPerUnit;
            txtUnitPrice.Text = unitPrice.ToString();
            UnitInStock = unitInStock;
            _owner = owner;
        }
        internal string ProductID => txtProductID.Text;
        internal int UnitInStock { get; set; }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            ProductUSDialog dialog = new ProductUSDialog(UnitInStock);
            dialog.ShowDialog();
            if (dialog.Bought)
            {
                var quantity = (int)dialog.nudQuantity.Value;
                var item = _owner.dgvDetail.Rows.Cast<DataGridViewRow>().
                    SingleOrDefault(o => o.Cells[0].Value.ToString() == txtProductID.Text);
                if (item == null)
                {
                    int index = _owner.dgvDetail.Rows.Add();
                    DataGridViewRow row = _owner.dgvDetail.Rows[index];
                    row.Cells[0].Value = txtProductID.Text;
                    row.Cells[1].Value = txtName.Text;
                    row.Cells[2].Value = txtUnitPrice.Text;
                    row.Cells[3].Value = quantity.ToString();
                    UnitInStock -= quantity;
                }
                else
                {
                    var oldQuantity = int.Parse(item.Cells[3].Value.ToString());
                    UnitInStock -= quantity;
                    quantity += oldQuantity;
                    item.Cells[3].Value = quantity.ToString();
                }
                _owner.txtTotal.Text = _owner.dgvDetail.Rows.Cast<DataGridViewRow>().
                    Sum(o => decimal.Parse(o.Cells[2].Value.ToString())*decimal.Parse(o.Cells[3].Value.ToString())).ToString();
            }
        }
    }
}
