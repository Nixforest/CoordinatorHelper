namespace MainPrj.View
{
    partial class OrderReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderReport));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxMaterialType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewMaterial = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại vật tư:";
            // 
            // cbxMaterialType
            // 
            this.cbxMaterialType.DisplayMember = "Text";
            this.cbxMaterialType.FormattingEnabled = true;
            this.cbxMaterialType.Location = new System.Drawing.Point(117, 10);
            this.cbxMaterialType.Name = "cbxMaterialType";
            this.cbxMaterialType.Size = new System.Drawing.Size(310, 32);
            this.cbxMaterialType.TabIndex = 1;
            this.cbxMaterialType.ValueMember = "Value";
            this.cbxMaterialType.SelectedValueChanged += new System.EventHandler(this.cbxMaterialType_SelectedValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(433, 589);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(433, 10);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(122, 32);
            this.btnAll.TabIndex = 4;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã vật tư";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên vật tư";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SL";
            // 
            // listViewMaterial
            // 
            this.listViewMaterial.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewMaterial.FullRowSelect = true;
            this.listViewMaterial.GridLines = true;
            this.listViewMaterial.Location = new System.Drawing.Point(12, 48);
            this.listViewMaterial.Name = "listViewMaterial";
            this.listViewMaterial.Size = new System.Drawing.Size(543, 535);
            this.listViewMaterial.TabIndex = 2;
            this.listViewMaterial.UseCompatibleStateImageBehavior = false;
            this.listViewMaterial.View = System.Windows.Forms.View.Details;
            // 
            // OrderReport
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(567, 644);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.listViewMaterial);
            this.Controls.Add(this.cbxMaterialType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OrderReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tổng hợp";
            this.Load += new System.EventHandler(this.OrderReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMaterialType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listViewMaterial;
    }
}