using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyBanHang.GUI.OrderMDI
{
    public partial class ProductUserControlGUI : DevExpress.XtraEditors.XtraUserControl
    {
        private OrderFormGUI _owner;
        private int _unitInStock;
        public ProductUserControlGUI()
        {
            InitializeComponent();
        }
        public ProductUserControlGUI(int id, string name, string quantityPerUnit, decimal unitPrice, int unitInStock, OrderFormGUI owner)
        {
            InitializeComponent();
            txbProductID.Text = id.ToString();
            txbName.Text = name;
            txbQuantityPerUnit.Text = quantityPerUnit;
            txbUnitPrice.Text = unitPrice.ToString();
            UnitInStock = unitInStock;
            _owner = owner;
        }
        internal string ProductID => txbProductID.Text;
        internal int UnitInStock
        {
            get => _unitInStock; set
            {
                _unitInStock = value;
                nudQuantity.Maximum = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (nudQuantity.Value > 0)
            {
                var quantity = (int)nudQuantity.Value;
                var item = _owner.dgvDetail.Rows.Cast<DataGridViewRow>().
                    SingleOrDefault(o => o.Cells[0].Value.ToString() == txbProductID.Text);
                if (item == null)
                {
                    int index = _owner.dgvDetail.Rows.Add();
                    DataGridViewRow row = _owner.dgvDetail.Rows[index];
                    row.Cells[0].Value = txbProductID.Text;
                    row.Cells[1].Value = txbName.Text;
                    row.Cells[2].Value = txbUnitPrice.Text;
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
                _owner.txbTotal.Text = _owner.dgvDetail.Rows.Cast<DataGridViewRow>().
                    Sum(o => decimal.Parse(o.Cells[2].Value.ToString()) * decimal.Parse(o.Cells[3].Value.ToString())).ToString();
            }
        }
    }
}
