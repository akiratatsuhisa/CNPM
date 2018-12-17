namespace QuanLyBanHang.GUI.OrderMDI
{
    partial class SearchProductsDialogGUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchProductsDialogGUI));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txbProductName = new System.Windows.Forms.TextBox();
            this.ckbUnitPriceFrom = new System.Windows.Forms.CheckBox();
            this.nudMinPrice = new System.Windows.Forms.NumericUpDown();
            this.ckbUnitPriceTo = new System.Windows.Forms.CheckBox();
            this.nudMaxPrice = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txbProductName);
            this.dataLayoutControl1.Controls.Add(this.ckbUnitPriceFrom);
            this.dataLayoutControl1.Controls.Add(this.nudMinPrice);
            this.dataLayoutControl1.Controls.Add(this.ckbUnitPriceTo);
            this.dataLayoutControl1.Controls.Add(this.nudMaxPrice);
            this.dataLayoutControl1.Controls.Add(this.btnOK);
            this.dataLayoutControl1.Controls.Add(this.btnCancel);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(334, 123);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txbProductName
            // 
            this.txbProductName.Location = new System.Drawing.Point(87, 12);
            this.txbProductName.Name = "txbProductName";
            this.txbProductName.Size = new System.Drawing.Size(235, 20);
            this.txbProductName.TabIndex = 1;
            // 
            // ckbUnitPriceFrom
            // 
            this.ckbUnitPriceFrom.Location = new System.Drawing.Point(12, 36);
            this.ckbUnitPriceFrom.Name = "ckbUnitPriceFrom";
            this.ckbUnitPriceFrom.Size = new System.Drawing.Size(76, 20);
            this.ckbUnitPriceFrom.TabIndex = 1;
            this.ckbUnitPriceFrom.Text = "Giá từ:";
            this.ckbUnitPriceFrom.UseVisualStyleBackColor = true;
            this.ckbUnitPriceFrom.CheckedChanged += new System.EventHandler(this.ckbUnitPriceFrom_CheckedChanged);
            // 
            // nudMinPrice
            // 
            this.nudMinPrice.Enabled = false;
            this.nudMinPrice.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinPrice.Location = new System.Drawing.Point(92, 36);
            this.nudMinPrice.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudMinPrice.Name = "nudMinPrice";
            this.nudMinPrice.Size = new System.Drawing.Size(73, 21);
            this.nudMinPrice.TabIndex = 1;
            this.nudMinPrice.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nudMinPrice.ValueChanged += new System.EventHandler(this.nudMinPrice_ValueChanged);
            // 
            // ckbUnitPriceTo
            // 
            this.ckbUnitPriceTo.Location = new System.Drawing.Point(169, 36);
            this.ckbUnitPriceTo.Name = "ckbUnitPriceTo";
            this.ckbUnitPriceTo.Size = new System.Drawing.Size(76, 20);
            this.ckbUnitPriceTo.TabIndex = 1;
            this.ckbUnitPriceTo.Text = "Giá đến:";
            this.ckbUnitPriceTo.UseVisualStyleBackColor = true;
            this.ckbUnitPriceTo.CheckedChanged += new System.EventHandler(this.ckbUnitPriceTo_CheckedChanged);
            // 
            // nudMaxPrice
            // 
            this.nudMaxPrice.Enabled = false;
            this.nudMaxPrice.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxPrice.Location = new System.Drawing.Point(249, 36);
            this.nudMaxPrice.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudMaxPrice.Name = "nudMaxPrice";
            this.nudMaxPrice.Size = new System.Drawing.Size(73, 21);
            this.nudMaxPrice.TabIndex = 1;
            this.nudMaxPrice.Value = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.nudMaxPrice.ValueChanged += new System.EventHandler(this.nudMaxPrice_ValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.apply_32x32;
            this.btnOK.Location = new System.Drawing.Point(12, 60);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(153, 38);
            this.btnOK.StyleController = this.dataLayoutControl1;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.cancel_32x32;
            this.btnCancel.Location = new System.Drawing.Point(169, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(153, 38);
            this.btnCancel.StyleController = this.dataLayoutControl1;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(334, 123);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txbProductName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(314, 24);
            this.layoutControlItem1.Text = "Tên Sản Phẩm:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(157, 90);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(157, 13);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ckbUnitPriceFrom;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(80, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(80, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(80, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.nudMinPrice;
            this.layoutControlItem3.Location = new System.Drawing.Point(80, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(77, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ckbUnitPriceTo;
            this.layoutControlItem4.Location = new System.Drawing.Point(157, 24);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(80, 0);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(80, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(80, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.nudMaxPrice;
            this.layoutControlItem5.Location = new System.Drawing.Point(237, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(77, 24);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnOK;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(157, 55);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnCancel;
            this.layoutControlItem7.Location = new System.Drawing.Point(157, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(157, 42);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // SearchProductsDialogGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 123);
            this.Controls.Add(this.dataLayoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(430, 155);
            this.MinimumSize = new System.Drawing.Size(340, 155);
            this.Name = "SearchProductsDialogGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm sản phẩm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchProductDialog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.NumericUpDown nudMaxPrice;
        private System.Windows.Forms.TextBox txbProductName;
        private System.Windows.Forms.CheckBox ckbUnitPriceFrom;
        private System.Windows.Forms.NumericUpDown nudMinPrice;
        private System.Windows.Forms.CheckBox ckbUnitPriceTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}