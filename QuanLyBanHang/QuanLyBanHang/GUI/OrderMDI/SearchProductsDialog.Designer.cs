namespace QuanLyBanHang.GUI.OrderMDI
{
    partial class SearchProductsDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.nudMaxPrice = new System.Windows.Forms.NumericUpDown();
            this.nudMinPrice = new System.Windows.Forms.NumericUpDown();
            this.ckbUnitPriceFrom = new System.Windows.Forms.CheckBox();
            this.ckbUnitPriceTo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPrice)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtProductName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 98);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductName.Location = new System.Drawing.Point(132, 11);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(8);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(278, 26);
            this.txtProductName.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.nudMaxPrice, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.nudMinPrice, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ckbUnitPriceFrom, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ckbUnitPriceTo, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 49);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(418, 49);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // nudMaxPrice
            // 
            this.nudMaxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMaxPrice.Enabled = false;
            this.nudMaxPrice.Location = new System.Drawing.Point(309, 11);
            this.nudMaxPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMaxPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudMaxPrice.Name = "nudMaxPrice";
            this.nudMaxPrice.Size = new System.Drawing.Size(105, 26);
            this.nudMaxPrice.TabIndex = 1;
            this.nudMaxPrice.Value = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.nudMaxPrice.ValueChanged += new System.EventHandler(this.nudMaxPrice_ValueChanged);
            // 
            // nudMinPrice
            // 
            this.nudMinPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMinPrice.Enabled = false;
            this.nudMinPrice.Location = new System.Drawing.Point(94, 11);
            this.nudMinPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudMinPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMinPrice.Name = "nudMinPrice";
            this.nudMinPrice.Size = new System.Drawing.Size(104, 26);
            this.nudMinPrice.TabIndex = 1;
            this.nudMinPrice.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nudMinPrice.ValueChanged += new System.EventHandler(this.nudMinPrice_ValueChanged);
            // 
            // ckbUnitPriceFrom
            // 
            this.ckbUnitPriceFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbUnitPriceFrom.AutoSize = true;
            this.ckbUnitPriceFrom.Location = new System.Drawing.Point(4, 12);
            this.ckbUnitPriceFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbUnitPriceFrom.Name = "ckbUnitPriceFrom";
            this.ckbUnitPriceFrom.Size = new System.Drawing.Size(82, 24);
            this.ckbUnitPriceFrom.TabIndex = 3;
            this.ckbUnitPriceFrom.Text = "Giá từ:";
            this.ckbUnitPriceFrom.UseVisualStyleBackColor = true;
            this.ckbUnitPriceFrom.CheckedChanged += new System.EventHandler(this.ckbUnitPriceFrom_CheckedChanged);
            // 
            // ckbUnitPriceTo
            // 
            this.ckbUnitPriceTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbUnitPriceTo.AutoSize = true;
            this.ckbUnitPriceTo.Location = new System.Drawing.Point(206, 12);
            this.ckbUnitPriceTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbUnitPriceTo.Name = "ckbUnitPriceTo";
            this.ckbUnitPriceTo.Size = new System.Drawing.Size(95, 24);
            this.ckbUnitPriceTo.TabIndex = 3;
            this.ckbUnitPriceTo.Text = "Giá đến:";
            this.ckbUnitPriceTo.UseVisualStyleBackColor = true;
            this.ckbUnitPriceTo.CheckedChanged += new System.EventHandler(this.ckbUnitPriceTo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên Sản Phẩm:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnOK, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(20, 128);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(418, 48);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe Script", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(217, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(193, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe Script", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(8, 8);
            this.btnOK.Margin = new System.Windows.Forms.Padding(8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(193, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SearchProductsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 168);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(739, 224);
            this.MinimumSize = new System.Drawing.Size(469, 224);
            this.Name = "SearchProductsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchProductsDialog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchProductDialog_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPrice)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudMinPrice;
        private System.Windows.Forms.NumericUpDown nudMaxPrice;
        private System.Windows.Forms.CheckBox ckbUnitPriceFrom;
        private System.Windows.Forms.CheckBox ckbUnitPriceTo;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
    }
}