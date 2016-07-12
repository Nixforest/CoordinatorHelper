namespace MainPrj.View
{
    partial class OrderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderView));
            this.label1 = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxItem = new System.Windows.Forms.TextBox();
            this.tbxPromote = new System.Windows.Forms.TextBox();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPromote = new System.Windows.Forms.Label();
            this.lblTotalPay = new System.Windows.Forms.Label();
            this.cbxDeliver = new System.Windows.Forms.ComboBox();
            this.cbxCCS = new System.Windows.Forms.ComboBox();
            this.lblDeliver = new System.Windows.Forms.Label();
            this.lblCCS = new System.Windows.Forms.Label();
            this.tbxCustomer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCreatePrint = new System.Windows.Forms.Button();
            this.listViewRecentProduct = new System.Windows.Forms.ListView();
            this.listViewRecentPromote = new System.Windows.Forms.ListView();
            this.listViewPromote = new MainPrj.View.EditableListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewProduct = new MainPrj.View.EditableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kế toán:";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.ForeColor = System.Drawing.Color.Blue;
            this.lblCreator.Location = new System.Drawing.Point(145, 20);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(48, 24);
            this.lblCreator.TabIndex = 0;
            this.lblCreator.Text = "ABC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "NV giao nhận:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "NV CCS:";
            // 
            // tbxItem
            // 
            this.tbxItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbxItem.Location = new System.Drawing.Point(149, 122);
            this.tbxItem.Name = "tbxItem";
            this.tbxItem.Size = new System.Drawing.Size(289, 29);
            this.tbxItem.TabIndex = 2;
            this.tbxItem.Text = "Tìm kiếm";
            this.tbxItem.Enter += new System.EventHandler(this.tbxItem_Enter);
            this.tbxItem.Leave += new System.EventHandler(this.tbxItem_Leave);
            // 
            // tbxPromote
            // 
            this.tbxPromote.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbxPromote.Location = new System.Drawing.Point(149, 398);
            this.tbxPromote.Name = "tbxPromote";
            this.tbxPromote.Size = new System.Drawing.Size(289, 29);
            this.tbxPromote.TabIndex = 3;
            this.tbxPromote.Text = "Tìm kiếm";
            this.tbxPromote.Enter += new System.EventHandler(this.tbxPromote_Enter);
            this.tbxPromote.Leave += new System.EventHandler(this.tbxPromote_Leave);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(751, 662);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(102, 46);
            this.btnCreateOrder.TabIndex = 6;
            this.btnCreateOrder.Text = "Tạo";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(859, 662);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 46);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "- Sản phẩm:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "- Khuyến mãi:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 673);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "=> Tổng thanh toán:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotal.Location = new System.Drawing.Point(601, 120);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(29, 31);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "0";
            // 
            // lblPromote
            // 
            this.lblPromote.AutoSize = true;
            this.lblPromote.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromote.ForeColor = System.Drawing.Color.Red;
            this.lblPromote.Location = new System.Drawing.Point(601, 396);
            this.lblPromote.Name = "lblPromote";
            this.lblPromote.Size = new System.Drawing.Size(29, 31);
            this.lblPromote.TabIndex = 0;
            this.lblPromote.Text = "0";
            // 
            // lblTotalPay
            // 
            this.lblTotalPay.AutoSize = true;
            this.lblTotalPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPay.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalPay.Location = new System.Drawing.Point(194, 666);
            this.lblTotalPay.Name = "lblTotalPay";
            this.lblTotalPay.Size = new System.Drawing.Size(29, 31);
            this.lblTotalPay.TabIndex = 0;
            this.lblTotalPay.Text = "0";
            // 
            // cbxDeliver
            // 
            this.cbxDeliver.DisplayMember = "Text";
            this.cbxDeliver.FormattingEnabled = true;
            this.cbxDeliver.Location = new System.Drawing.Point(149, 47);
            this.cbxDeliver.Name = "cbxDeliver";
            this.cbxDeliver.Size = new System.Drawing.Size(289, 32);
            this.cbxDeliver.TabIndex = 0;
            this.cbxDeliver.ValueMember = "Value";
            this.cbxDeliver.SelectedIndexChanged += new System.EventHandler(this.cbxDeliver_SelectedIndexChanged);
            // 
            // cbxCCS
            // 
            this.cbxCCS.DisplayMember = "Text";
            this.cbxCCS.FormattingEnabled = true;
            this.cbxCCS.Location = new System.Drawing.Point(149, 84);
            this.cbxCCS.Name = "cbxCCS";
            this.cbxCCS.Size = new System.Drawing.Size(289, 32);
            this.cbxCCS.TabIndex = 1;
            this.cbxCCS.ValueMember = "Value";
            this.cbxCCS.SelectedIndexChanged += new System.EventHandler(this.cbxCCS_SelectedIndexChanged);
            // 
            // lblDeliver
            // 
            this.lblDeliver.AutoSize = true;
            this.lblDeliver.ForeColor = System.Drawing.Color.Blue;
            this.lblDeliver.Location = new System.Drawing.Point(444, 50);
            this.lblDeliver.Name = "lblDeliver";
            this.lblDeliver.Size = new System.Drawing.Size(35, 24);
            this.lblDeliver.TabIndex = 0;
            this.lblDeliver.Text = "Id :";
            this.lblDeliver.Visible = false;
            // 
            // lblCCS
            // 
            this.lblCCS.AutoSize = true;
            this.lblCCS.ForeColor = System.Drawing.Color.Blue;
            this.lblCCS.Location = new System.Drawing.Point(443, 92);
            this.lblCCS.Name = "lblCCS";
            this.lblCCS.Size = new System.Drawing.Size(35, 24);
            this.lblCCS.TabIndex = 0;
            this.lblCCS.Text = "Id :";
            this.lblCCS.Visible = false;
            // 
            // tbxCustomer
            // 
            this.tbxCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxCustomer.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbxCustomer.Location = new System.Drawing.Point(568, 15);
            this.tbxCustomer.Multiline = true;
            this.tbxCustomer.Name = "tbxCustomer";
            this.tbxCustomer.ReadOnly = true;
            this.tbxCustomer.Size = new System.Drawing.Size(393, 101);
            this.tbxCustomer.TabIndex = 9;
            this.tbxCustomer.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng tiền:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tổng chiết khấu:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox1.Location = new System.Drawing.Point(448, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(114, 101);
            this.textBox1.TabIndex = 9;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Khách hàng:\r\nĐịa chỉ:";
            // 
            // btnCreatePrint
            // 
            this.btnCreatePrint.Location = new System.Drawing.Point(589, 662);
            this.btnCreatePrint.Name = "btnCreatePrint";
            this.btnCreatePrint.Size = new System.Drawing.Size(156, 46);
            this.btnCreatePrint.TabIndex = 6;
            this.btnCreatePrint.Text = "Tạo và in phiếu";
            this.btnCreatePrint.UseVisualStyleBackColor = true;
            this.btnCreatePrint.Click += new System.EventHandler(this.btnCreatePrint_Click);
            // 
            // listViewRecentProduct
            // 
            this.listViewRecentProduct.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewRecentProduct.BackColor = System.Drawing.SystemColors.Control;
            this.listViewRecentProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewRecentProduct.Location = new System.Drawing.Point(12, 157);
            this.listViewRecentProduct.Name = "listViewRecentProduct";
            this.listViewRecentProduct.Size = new System.Drawing.Size(949, 88);
            this.listViewRecentProduct.TabIndex = 10;
            this.listViewRecentProduct.UseCompatibleStateImageBehavior = false;
            this.listViewRecentProduct.DoubleClick += new System.EventHandler(this.listViewRecentProduct_DoubleClick);
            // 
            // listViewRecentPromote
            // 
            this.listViewRecentPromote.BackColor = System.Drawing.SystemColors.Control;
            this.listViewRecentPromote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewRecentPromote.Location = new System.Drawing.Point(12, 433);
            this.listViewRecentPromote.Name = "listViewRecentPromote";
            this.listViewRecentPromote.Scrollable = false;
            this.listViewRecentPromote.Size = new System.Drawing.Size(949, 88);
            this.listViewRecentPromote.TabIndex = 11;
            this.listViewRecentPromote.UseCompatibleStateImageBehavior = false;
            this.listViewRecentPromote.DoubleClick += new System.EventHandler(this.listViewRecentPromote_DoubleClick);
            // 
            // listViewPromote
            // 
            this.listViewPromote.AllowColumnReorder = true;
            this.listViewPromote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPromote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewPromote.ColumnTypes = ((System.Collections.Generic.List<System.Type>)(resources.GetObject("listViewPromote.ColumnTypes")));
            this.listViewPromote.DoubleClickActivation = false;
            this.listViewPromote.FullRowSelect = true;
            this.listViewPromote.GridLines = true;
            this.listViewPromote.Location = new System.Drawing.Point(12, 529);
            this.listViewPromote.Name = "listViewPromote";
            this.listViewPromote.Size = new System.Drawing.Size(949, 127);
            this.listViewPromote.TabIndex = 5;
            this.listViewPromote.UseCompatibleStateImageBehavior = false;
            this.listViewPromote.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "STT";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Mã sản phẩm";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tên sản phẩm";
            this.columnHeader9.Width = 300;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Số lượng";
            this.columnHeader10.Width = 90;
            // 
            // listViewProduct
            // 
            this.listViewProduct.AllowColumnReorder = true;
            this.listViewProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewProduct.ColumnTypes = ((System.Collections.Generic.List<System.Type>)(resources.GetObject("listViewProduct.ColumnTypes")));
            this.listViewProduct.DoubleClickActivation = false;
            this.listViewProduct.FullRowSelect = true;
            this.listViewProduct.GridLines = true;
            this.listViewProduct.HideSelection = false;
            this.listViewProduct.Location = new System.Drawing.Point(12, 251);
            this.listViewProduct.Name = "listViewProduct";
            this.listViewProduct.ShowItemToolTips = true;
            this.listViewProduct.Size = new System.Drawing.Size(949, 141);
            this.listViewProduct.TabIndex = 4;
            this.listViewProduct.UseCompatibleStateImageBehavior = false;
            this.listViewProduct.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã sản phẩm";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên sản phẩm";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số lượng";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Giá";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tiền";
            this.columnHeader6.Width = 150;
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 716);
            this.Controls.Add(this.listViewRecentPromote);
            this.Controls.Add(this.listViewRecentProduct);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbxCustomer);
            this.Controls.Add(this.listViewPromote);
            this.Controls.Add(this.listViewProduct);
            this.Controls.Add(this.cbxCCS);
            this.Controls.Add(this.cbxDeliver);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreatePrint);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxPromote);
            this.Controls.Add(this.tbxItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCCS);
            this.Controls.Add(this.lblDeliver);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTotalPay);
            this.Controls.Add(this.lblPromote);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo đơn đặt hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderView_FormClosing);
            this.Load += new System.EventHandler(this.OrderView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderView_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxItem;
        private System.Windows.Forms.TextBox tbxPromote;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPromote;
        private System.Windows.Forms.Label lblTotalPay;
        private System.Windows.Forms.ComboBox cbxDeliver;
        private System.Windows.Forms.ComboBox cbxCCS;
        private System.Windows.Forms.Label lblDeliver;
        private System.Windows.Forms.Label lblCCS;
        private EditableListView listViewProduct;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private EditableListView listViewPromote;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TextBox tbxCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCreatePrint;
        private System.Windows.Forms.ListView listViewRecentProduct;
        private System.Windows.Forms.ListView listViewRecentPromote;
    }
}