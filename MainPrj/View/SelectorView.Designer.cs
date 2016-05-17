namespace MainPrj.View
{
    partial class SelectorView
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
            this.listViewSelector = new System.Windows.Forms.ListView();
            this.columnHeaderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewSelector
            // 
            this.listViewSelector.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNo,
            this.columnHeaderName,
            this.columnHeaderAddress,
            this.columnHeaderId});
            this.listViewSelector.FullRowSelect = true;
            this.listViewSelector.GridLines = true;
            this.listViewSelector.HideSelection = false;
            this.listViewSelector.Location = new System.Drawing.Point(15, 15);
            this.listViewSelector.Margin = new System.Windows.Forms.Padding(6);
            this.listViewSelector.MultiSelect = false;
            this.listViewSelector.Name = "listViewSelector";
            this.listViewSelector.ShowItemToolTips = true;
            this.listViewSelector.Size = new System.Drawing.Size(885, 328);
            this.listViewSelector.TabIndex = 0;
            this.listViewSelector.UseCompatibleStateImageBehavior = false;
            this.listViewSelector.View = System.Windows.Forms.View.Details;
            this.listViewSelector.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewSelector_ItemSelectionChanged);
            this.listViewSelector.Enter += new System.EventHandler(this.listViewSelector_Enter);
            this.listViewSelector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewSelector_KeyDown);
            this.listViewSelector.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewSelector_MouseDoubleClick);
            // 
            // columnHeaderNo
            // 
            this.columnHeaderNo.Text = "No.";
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Tên";
            this.columnHeaderName.Width = 400;
            // 
            // columnHeaderAddress
            // 
            this.columnHeaderAddress.Text = "Địa chỉ";
            this.columnHeaderAddress.Width = 420;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "";
            this.columnHeaderId.Width = 0;
            // 
            // SelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 358);
            this.Controls.Add(this.listViewSelector);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SelectorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectorView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectorView_FormClosing);
            this.Load += new System.EventHandler(this.SelectorView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewSelector;
        private System.Windows.Forms.ColumnHeader columnHeaderNo;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderAddress;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
    }
}