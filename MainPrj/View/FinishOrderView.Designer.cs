namespace MainPrj.View
{
    partial class FinishOrderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishOrderView));
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalPay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDeliver = new System.Windows.Forms.ComboBox();
            this.chbPromote = new System.Windows.Forms.CheckBox();
            this.listViewCylinder = new MainPrj.View.EditableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // tbxSearch
            // 
            this.tbxSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbxSearch.Location = new System.Drawing.Point(90, 6);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(137, 29);
            this.tbxSearch.TabIndex = 0;
            this.tbxSearch.Text = "Tìm kiếm";
            this.tbxSearch.Enter += new System.EventHandler(this.tbxSearch_Enter);
            this.tbxSearch.Leave += new System.EventHandler(this.tbxSearch_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tìm vỏ:";
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Image = global::MainPrj.Properties.Resources.finish;
            this.btnFinish.Location = new System.Drawing.Point(483, 236);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(141, 151);
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "Đã thu tiền";
            this.btnFinish.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Thanh toán:";
            // 
            // lblTotalPay
            // 
            this.lblTotalPay.AutoSize = true;
            this.lblTotalPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPay.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalPay.Location = new System.Drawing.Point(129, 236);
            this.lblTotalPay.Name = "lblTotalPay";
            this.lblTotalPay.Size = new System.Drawing.Size(29, 31);
            this.lblTotalPay.TabIndex = 10;
            this.lblTotalPay.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "NV giao nhận:";
            // 
            // cbxDeliver
            // 
            this.cbxDeliver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDeliver.DisplayMember = "Text";
            this.cbxDeliver.FormattingEnabled = true;
            this.cbxDeliver.Location = new System.Drawing.Point(370, 6);
            this.cbxDeliver.Name = "cbxDeliver";
            this.cbxDeliver.Size = new System.Drawing.Size(254, 32);
            this.cbxDeliver.TabIndex = 1;
            this.cbxDeliver.ValueMember = "Value";
            // 
            // chbPromote
            // 
            this.chbPromote.AutoSize = true;
            this.chbPromote.Location = new System.Drawing.Point(16, 279);
            this.chbPromote.Name = "chbPromote";
            this.chbPromote.Size = new System.Drawing.Size(255, 28);
            this.chbPromote.TabIndex = 3;
            this.chbPromote.Text = "Không lấy quà Khuyến mãi";
            this.chbPromote.UseVisualStyleBackColor = true;
            this.chbPromote.Visible = false;
            // 
            // listViewCylinder
            // 
            this.listViewCylinder.AllowColumnReorder = true;
            this.listViewCylinder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCylinder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewCylinder.ColumnTypes = ((System.Collections.Generic.List<System.Type>)(resources.GetObject("listViewCylinder.ColumnTypes")));
            this.listViewCylinder.DoubleClickActivation = false;
            this.listViewCylinder.FullRowSelect = true;
            this.listViewCylinder.Location = new System.Drawing.Point(16, 41);
            this.listViewCylinder.Name = "listViewCylinder";
            this.listViewCylinder.Size = new System.Drawing.Size(608, 189);
            this.listViewCylinder.TabIndex = 2;
            this.listViewCylinder.UseCompatibleStateImageBehavior = false;
            this.listViewCylinder.View = System.Windows.Forms.View.Details;
            this.listViewCylinder.SubItemEndEditing += new MainPrj.View.SubItemEndEditingEventHandler(this.listViewCylinder_SubItemEndEditing);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã vỏ";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên vỏ";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SL";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Serial";
            this.columnHeader5.Width = 90;
            // 
            // FinishOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 394);
            this.Controls.Add(this.chbPromote);
            this.Controls.Add(this.cbxDeliver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lblTotalPay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewCylinder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FinishOrderView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hoàn tất đơn hàng";
            this.Load += new System.EventHandler(this.FinishOrderView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FinishOrderView_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EditableListView listViewCylinder;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalPay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDeliver;
        private System.Windows.Forms.CheckBox chbPromote;
    }
}