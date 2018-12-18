namespace QuanLyBanHang.GUI
{
    partial class ProductsFormGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsFormGUI));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txbProductID = new System.Windows.Forms.TextBox();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbUnitPrice = new System.Windows.Forms.TextBox();
            this.cbxQuantityPerUnit = new System.Windows.Forms.ComboBox();
            this.txbUnitsInStock = new System.Windows.Forms.TextBox();
            this.txbUnitsOnInvoice = new System.Windows.Forms.TextBox();
            this.dtpAddedDate = new System.Windows.Forms.DateTimePicker();
            this.rdbIsContinued = new System.Windows.Forms.RadioButton();
            this.rdbIsDiscontinued = new System.Windows.Forms.RadioButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgButton = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txbProductID);
            this.dataLayoutControl1.Controls.Add(this.txbName);
            this.dataLayoutControl1.Controls.Add(this.txbUnitPrice);
            this.dataLayoutControl1.Controls.Add(this.cbxQuantityPerUnit);
            this.dataLayoutControl1.Controls.Add(this.txbUnitsInStock);
            this.dataLayoutControl1.Controls.Add(this.txbUnitsOnInvoice);
            this.dataLayoutControl1.Controls.Add(this.dtpAddedDate);
            this.dataLayoutControl1.Controls.Add(this.rdbIsContinued);
            this.dataLayoutControl1.Controls.Add(this.rdbIsDiscontinued);
            this.dataLayoutControl1.Controls.Add(this.btnAdd);
            this.dataLayoutControl1.Controls.Add(this.btnEdit);
            this.dataLayoutControl1.Controls.Add(this.btnDelete);
            this.dataLayoutControl1.Controls.Add(this.btnOK);
            this.dataLayoutControl1.Controls.Add(this.btnCancel);
            this.dataLayoutControl1.Controls.Add(this.btnExit);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(714, 215);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txbProductID
            // 
            this.txbProductID.Location = new System.Drawing.Point(79, 44);
            this.txbProductID.Name = "txbProductID";
            this.txbProductID.ReadOnly = true;
            this.txbProductID.Size = new System.Drawing.Size(165, 20);
            this.txbProductID.TabIndex = 1;
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(303, 44);
            this.txbName.Name = "txbName";
            this.txbName.ReadOnly = true;
            this.txbName.Size = new System.Drawing.Size(387, 20);
            this.txbName.TabIndex = 1;
            // 
            // txbUnitPrice
            // 
            this.txbUnitPrice.Location = new System.Drawing.Point(79, 68);
            this.txbUnitPrice.Name = "txbUnitPrice";
            this.txbUnitPrice.ReadOnly = true;
            this.txbUnitPrice.Size = new System.Drawing.Size(165, 20);
            this.txbUnitPrice.TabIndex = 1;
            // 
            // cbxQuantityPerUnit
            // 
            this.cbxQuantityPerUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxQuantityPerUnit.Enabled = false;
            this.cbxQuantityPerUnit.FormattingEnabled = true;
            this.cbxQuantityPerUnit.Items.AddRange(new object[] {
            "Không xác định",
            "1 chai",
            "1 gói",
            "1 bịch",
            "1 lọ",
            "1 hộp",
            "1 túi",
            "1 lon",
            "1 vỉ",
            "1 kg"});
            this.cbxQuantityPerUnit.Location = new System.Drawing.Point(79, 92);
            this.cbxQuantityPerUnit.Name = "cbxQuantityPerUnit";
            this.cbxQuantityPerUnit.Size = new System.Drawing.Size(165, 21);
            this.cbxQuantityPerUnit.TabIndex = 1;
            // 
            // txbUnitsInStock
            // 
            this.txbUnitsInStock.Location = new System.Drawing.Point(303, 68);
            this.txbUnitsInStock.Name = "txbUnitsInStock";
            this.txbUnitsInStock.ReadOnly = true;
            this.txbUnitsInStock.Size = new System.Drawing.Size(163, 20);
            this.txbUnitsInStock.TabIndex = 1;
            // 
            // txbUnitsOnInvoice
            // 
            this.txbUnitsOnInvoice.Location = new System.Drawing.Point(525, 68);
            this.txbUnitsOnInvoice.Name = "txbUnitsOnInvoice";
            this.txbUnitsOnInvoice.ReadOnly = true;
            this.txbUnitsOnInvoice.Size = new System.Drawing.Size(165, 20);
            this.txbUnitsOnInvoice.TabIndex = 1;
            // 
            // dtpAddedDate
            // 
            this.dtpAddedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpAddedDate.Enabled = false;
            this.dtpAddedDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpAddedDate.Location = new System.Drawing.Point(303, 92);
            this.dtpAddedDate.Name = "dtpAddedDate";
            this.dtpAddedDate.Size = new System.Drawing.Size(163, 21);
            this.dtpAddedDate.TabIndex = 1;
            // 
            // rdbIsContinued
            // 
            this.rdbIsContinued.Enabled = false;
            this.rdbIsContinued.Location = new System.Drawing.Point(470, 92);
            this.rdbIsContinued.Name = "rdbIsContinued";
            this.rdbIsContinued.Size = new System.Drawing.Size(108, 25);
            this.rdbIsContinued.TabIndex = 1;
            this.rdbIsContinued.TabStop = true;
            this.rdbIsContinued.Text = "Bán";
            this.rdbIsContinued.UseVisualStyleBackColor = true;
            // 
            // rdbIsDiscontinued
            // 
            this.rdbIsDiscontinued.Enabled = false;
            this.rdbIsDiscontinued.Location = new System.Drawing.Point(582, 92);
            this.rdbIsDiscontinued.Name = "rdbIsDiscontinued";
            this.rdbIsDiscontinued.Size = new System.Drawing.Size(108, 25);
            this.rdbIsDiscontinued.TabIndex = 1;
            this.rdbIsDiscontinued.TabStop = true;
            this.rdbIsDiscontinued.Text = "Dừng Bán";
            this.rdbIsDiscontinued.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.insert_16x16;
            this.btnAdd.Location = new System.Drawing.Point(24, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 22);
            this.btnAdd.StyleController = this.dataLayoutControl1;
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.editname_16x16;
            this.btnEdit.Location = new System.Drawing.Point(136, 165);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(108, 22);
            this.btnEdit.StyleController = this.dataLayoutControl1;
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.deletelist2_16x16;
            this.btnDelete.Location = new System.Drawing.Point(248, 165);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 22);
            this.btnDelete.StyleController = this.dataLayoutControl1;
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.apply_16x16;
            this.btnOK.Location = new System.Drawing.Point(360, 165);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 22);
            this.btnOK.StyleController = this.dataLayoutControl1;
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Lưu";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.cancel_16x16;
            this.btnCancel.Location = new System.Drawing.Point(472, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 22);
            this.btnCancel.StyleController = this.dataLayoutControl1;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.close_16x16;
            this.btnExit.Location = new System.Drawing.Point(582, 165);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 22);
            this.btnExit.StyleController = this.dataLayoutControl1;
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.lcgButton});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(714, 215);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem15,
            this.layoutControlItem14,
            this.layoutControlItem17,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(694, 121);
            this.layoutControlGroup1.Text = "Thông Tin Sản Phẩm";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txbProductID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(224, 24);
            this.layoutControlItem1.Text = "Mã SP";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txbName;
            this.layoutControlItem4.Location = new System.Drawing.Point(224, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(446, 24);
            this.layoutControlItem4.Text = "Tên";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txbUnitPrice;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(224, 24);
            this.layoutControlItem15.Text = "Giá bán";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.cbxQuantityPerUnit;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(224, 29);
            this.layoutControlItem14.Text = "Đơn vị đo";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.dtpAddedDate;
            this.layoutControlItem17.Location = new System.Drawing.Point(224, 48);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(222, 29);
            this.layoutControlItem17.Text = "Ngày nhập";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txbUnitsInStock;
            this.layoutControlItem3.Location = new System.Drawing.Point(224, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(222, 24);
            this.layoutControlItem3.Text = "Trong kho";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txbUnitsOnInvoice;
            this.layoutControlItem2.Location = new System.Drawing.Point(446, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(224, 24);
            this.layoutControlItem2.Text = "Trong đơn";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.rdbIsContinued;
            this.layoutControlItem7.Location = new System.Drawing.Point(446, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(112, 29);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.rdbIsDiscontinued;
            this.layoutControlItem5.Location = new System.Drawing.Point(558, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(112, 29);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // lcgButton
            // 
            this.lcgButton.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13});
            this.lcgButton.Location = new System.Drawing.Point(0, 121);
            this.lcgButton.Name = "lcgButton";
            this.lcgButton.Size = new System.Drawing.Size(694, 74);
            this.lcgButton.Text = "Chức Năng";
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnAdd;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(112, 30);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnCancel;
            this.layoutControlItem9.Location = new System.Drawing.Point(448, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(110, 30);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnExit;
            this.layoutControlItem10.Location = new System.Drawing.Point(558, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(112, 30);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnDelete;
            this.layoutControlItem11.Location = new System.Drawing.Point(224, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(112, 30);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.btnEdit;
            this.layoutControlItem12.Location = new System.Drawing.Point(112, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(112, 30);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.btnOK;
            this.layoutControlItem13.Location = new System.Drawing.Point(336, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(112, 30);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.dgvProduct);
            this.groupControl1.Location = new System.Drawing.Point(12, 208);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(690, 228);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Danh Sách Sản Phẩm";
            // 
            // dgvProduct
            // 
            this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduct.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduct.Location = new System.Drawing.Point(2, 22);
            this.dgvProduct.MultiSelect = false;
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.Size = new System.Drawing.Size(686, 204);
            this.dgvProduct.TabIndex = 0;
            this.dgvProduct.SelectionChanged += new System.EventHandler(this.dgvProduct_SelectionChanged);
            // 
            // ProductsFormGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 448);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dataLayoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductsFormGUI";
            this.Text = "Quản Lý Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.TextBox txbProductID;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.TextBox txbUnitsInStock;
        private System.Windows.Forms.TextBox txbUnitsOnInvoice;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.TextBox txbName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraLayout.LayoutControlGroup lcgButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private System.Windows.Forms.RadioButton rdbIsContinued;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.RadioButton rdbIsDiscontinued;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.TextBox txbUnitPrice;
        private System.Windows.Forms.ComboBox cbxQuantityPerUnit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private System.Windows.Forms.DateTimePicker dtpAddedDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
    }
}