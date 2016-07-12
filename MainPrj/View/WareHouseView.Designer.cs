namespace MainPrj.View
{
    partial class WareHouseView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WareHouseView));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewSelectedProduct = new System.Windows.Forms.ListView();
            this.btnAll = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.listViewSourceProduct = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listViewSelectedPromote = new System.Windows.Forms.ListView();
            this.btnAllPromote = new System.Windows.Forms.Button();
            this.tbxSearchPromote = new System.Windows.Forms.TextBox();
            this.listViewSourcePromote = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemovePromote = new System.Windows.Forms.Button();
            this.btnAddPromote = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(667, 647);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.listViewSelectedProduct);
            this.tabPage1.Controls.Add(this.btnAll);
            this.tabPage1.Controls.Add(this.tbxSearch);
            this.tabPage1.Controls.Add(this.listViewSourceProduct);
            this.tabPage1.Controls.Add(this.btnRemove);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(659, 609);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vật tư";
            // 
            // listViewSelectedProduct
            // 
            this.listViewSelectedProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewSelectedProduct.LabelEdit = true;
            this.listViewSelectedProduct.LabelWrap = false;
            this.listViewSelectedProduct.Location = new System.Drawing.Point(429, 67);
            this.listViewSelectedProduct.Name = "listViewSelectedProduct";
            this.listViewSelectedProduct.Size = new System.Drawing.Size(224, 535);
            this.listViewSelectedProduct.TabIndex = 6;
            this.listViewSelectedProduct.UseCompatibleStateImageBehavior = false;
            this.listViewSelectedProduct.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewSelected_AfterLabelEdit);
            this.listViewSelectedProduct.DoubleClick += new System.EventHandler(this.listViewSelected_DoubleClick);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(266, 30);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(99, 32);
            this.btnAll.TabIndex = 5;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.ForeColor = System.Drawing.Color.Gray;
            this.tbxSearch.Location = new System.Drawing.Point(11, 31);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(249, 30);
            this.tbxSearch.TabIndex = 4;
            this.tbxSearch.Text = "Tìm kiếm";
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            this.tbxSearch.Enter += new System.EventHandler(this.tbxSearch_Enter);
            this.tbxSearch.Leave += new System.EventHandler(this.tbxSearch_Leave);
            // 
            // listViewSourceProduct
            // 
            this.listViewSourceProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.listViewSourceProduct.FullRowSelect = true;
            this.listViewSourceProduct.GridLines = true;
            this.listViewSourceProduct.HideSelection = false;
            this.listViewSourceProduct.Location = new System.Drawing.Point(11, 67);
            this.listViewSourceProduct.MultiSelect = false;
            this.listViewSourceProduct.Name = "listViewSourceProduct";
            this.listViewSourceProduct.ShowItemToolTips = true;
            this.listViewSourceProduct.Size = new System.Drawing.Size(354, 535);
            this.listViewSourceProduct.TabIndex = 3;
            this.listViewSourceProduct.UseCompatibleStateImageBehavior = false;
            this.listViewSourceProduct.View = System.Windows.Forms.View.Details;
            this.listViewSourceProduct.DoubleClick += new System.EventHandler(this.listViewSource_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên vật tư";
            this.columnHeader2.Width = 340;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tồn";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(371, 105);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(52, 32);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "X";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(371, 67);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 32);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "→";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn các vật tư đang có trong kho:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.listViewSelectedPromote);
            this.tabPage2.Controls.Add(this.btnAllPromote);
            this.tabPage2.Controls.Add(this.tbxSearchPromote);
            this.tabPage2.Controls.Add(this.listViewSourcePromote);
            this.tabPage2.Controls.Add(this.btnRemovePromote);
            this.tabPage2.Controls.Add(this.btnAddPromote);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(659, 609);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hàng khuyến mãi";
            // 
            // listViewSelectedPromote
            // 
            this.listViewSelectedPromote.LabelEdit = true;
            this.listViewSelectedPromote.LabelWrap = false;
            this.listViewSelectedPromote.Location = new System.Drawing.Point(429, 67);
            this.listViewSelectedPromote.Name = "listViewSelectedPromote";
            this.listViewSelectedPromote.Size = new System.Drawing.Size(224, 535);
            this.listViewSelectedPromote.TabIndex = 13;
            this.listViewSelectedPromote.UseCompatibleStateImageBehavior = false;
            this.listViewSelectedPromote.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewSelectedPromote_AfterLabelEdit);
            this.listViewSelectedPromote.DoubleClick += new System.EventHandler(this.listViewSelectedPromote_DoubleClick);
            // 
            // btnAllPromote
            // 
            this.btnAllPromote.Location = new System.Drawing.Point(266, 30);
            this.btnAllPromote.Name = "btnAllPromote";
            this.btnAllPromote.Size = new System.Drawing.Size(99, 32);
            this.btnAllPromote.TabIndex = 12;
            this.btnAllPromote.Text = "Tất cả";
            this.btnAllPromote.UseVisualStyleBackColor = true;
            this.btnAllPromote.Click += new System.EventHandler(this.btnAllPromote_Click);
            // 
            // tbxSearchPromote
            // 
            this.tbxSearchPromote.ForeColor = System.Drawing.Color.Gray;
            this.tbxSearchPromote.Location = new System.Drawing.Point(11, 31);
            this.tbxSearchPromote.Name = "tbxSearchPromote";
            this.tbxSearchPromote.Size = new System.Drawing.Size(249, 30);
            this.tbxSearchPromote.TabIndex = 11;
            this.tbxSearchPromote.Text = "Tìm kiếm";
            this.tbxSearchPromote.TextChanged += new System.EventHandler(this.tbxSearchPromote_TextChanged);
            this.tbxSearchPromote.Enter += new System.EventHandler(this.tbxSearchPromote_Enter);
            this.tbxSearchPromote.Leave += new System.EventHandler(this.tbxSearchPromote_Leave);
            // 
            // listViewSourcePromote
            // 
            this.listViewSourcePromote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.listViewSourcePromote.FullRowSelect = true;
            this.listViewSourcePromote.GridLines = true;
            this.listViewSourcePromote.HideSelection = false;
            this.listViewSourcePromote.Location = new System.Drawing.Point(11, 67);
            this.listViewSourcePromote.MultiSelect = false;
            this.listViewSourcePromote.Name = "listViewSourcePromote";
            this.listViewSourcePromote.ShowItemToolTips = true;
            this.listViewSourcePromote.Size = new System.Drawing.Size(354, 535);
            this.listViewSourcePromote.TabIndex = 10;
            this.listViewSourcePromote.UseCompatibleStateImageBehavior = false;
            this.listViewSourcePromote.View = System.Windows.Forms.View.Details;
            this.listViewSourcePromote.DoubleClick += new System.EventHandler(this.listViewSourcePromote_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên vật tư";
            this.columnHeader1.Width = 340;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tồn";
            // 
            // btnRemovePromote
            // 
            this.btnRemovePromote.Location = new System.Drawing.Point(371, 105);
            this.btnRemovePromote.Name = "btnRemovePromote";
            this.btnRemovePromote.Size = new System.Drawing.Size(52, 32);
            this.btnRemovePromote.TabIndex = 8;
            this.btnRemovePromote.Text = "X";
            this.btnRemovePromote.UseVisualStyleBackColor = true;
            this.btnRemovePromote.Click += new System.EventHandler(this.btnRemovePromote_Click);
            // 
            // btnAddPromote
            // 
            this.btnAddPromote.Location = new System.Drawing.Point(371, 67);
            this.btnAddPromote.Name = "btnAddPromote";
            this.btnAddPromote.Size = new System.Drawing.Size(52, 32);
            this.btnAddPromote.TabIndex = 9;
            this.btnAddPromote.Text = "→";
            this.btnAddPromote.UseVisualStyleBackColor = true;
            this.btnAddPromote.Click += new System.EventHandler(this.btnAddPromote_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(417, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chọn các hàng khuyến mãi đang có trong kho:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(563, 665);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 48);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(445, 665);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 48);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // WareHouseView
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(691, 725);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WareHouseView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý kho hàng";
            this.Load += new System.EventHandler(this.WareHouseView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WareHouseView_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewSourceProduct;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.ListView listViewSelectedProduct;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ListView listViewSelectedPromote;
        private System.Windows.Forms.Button btnAllPromote;
        private System.Windows.Forms.TextBox tbxSearchPromote;
        private System.Windows.Forms.ListView listViewSourcePromote;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnRemovePromote;
        private System.Windows.Forms.Button btnAddPromote;
        private System.Windows.Forms.Label label2;
    }
}