namespace QuanLyBanHang.GUI.OrderMDI
{
    partial class ProductUserControlGUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txbProductID = new System.Windows.Forms.TextBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbQuantityPerUnit = new System.Windows.Forms.TextBox();
            this.txbUnitPrice = new System.Windows.Forms.TextBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dataLayoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(210, 200);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Sản phẩm";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txbProductID);
            this.dataLayoutControl1.Controls.Add(this.txbName);
            this.dataLayoutControl1.Controls.Add(this.txbQuantityPerUnit);
            this.dataLayoutControl1.Controls.Add(this.txbUnitPrice);
            this.dataLayoutControl1.Controls.Add(this.nudQuantity);
            this.dataLayoutControl1.Controls.Add(this.btnAdd);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(2, 22);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(544, 0, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(206, 176);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txbProductID
            // 
            this.txbProductID.Location = new System.Drawing.Point(65, 12);
            this.txbProductID.Name = "txbProductID";
            this.txbProductID.ReadOnly = true;
            this.txbProductID.Size = new System.Drawing.Size(129, 20);
            this.txbProductID.TabIndex = 1;
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(65, 36);
            this.txbName.Name = "txbName";
            this.txbName.ReadOnly = true;
            this.txbName.Size = new System.Drawing.Size(129, 20);
            this.txbName.TabIndex = 1;
            // 
            // txbQuantityPerUnit
            // 
            this.txbQuantityPerUnit.Location = new System.Drawing.Point(65, 60);
            this.txbQuantityPerUnit.Name = "txbQuantityPerUnit";
            this.txbQuantityPerUnit.ReadOnly = true;
            this.txbQuantityPerUnit.Size = new System.Drawing.Size(129, 20);
            this.txbQuantityPerUnit.TabIndex = 1;
            // 
            // txbUnitPrice
            // 
            this.txbUnitPrice.Location = new System.Drawing.Point(65, 84);
            this.txbUnitPrice.Name = "txbUnitPrice";
            this.txbUnitPrice.ReadOnly = true;
            this.txbUnitPrice.Size = new System.Drawing.Size(129, 20);
            this.txbUnitPrice.TabIndex = 1;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(65, 108);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(129, 21);
            this.nudQuantity.TabIndex = 1;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.boorder_16x16;
            this.btnAdd.Location = new System.Drawing.Point(12, 132);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(182, 22);
            this.btnAdd.StyleController = this.dataLayoutControl1;
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm vào giỏ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(206, 176);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 146);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(186, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txbProductID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem1.Text = "Mã SP:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txbName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem2.Text = "Tên SP:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txbQuantityPerUnit;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem3.Text = "Đơn vị đo:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txbUnitPrice;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem4.Text = "Giá:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.nudQuantity;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem5.Text = "Số lượng:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnAdd;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(186, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // ProductUserControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ProductUserControlGUI";
            this.Size = new System.Drawing.Size(210, 200);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.TextBox txbUnitPrice;
        private System.Windows.Forms.TextBox txbQuantityPerUnit;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.TextBox txbProductID;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}
