namespace MainPrj.View
{
    partial class OrderCoordinatorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderCoordinatorView));
            this.coordinatorOrderView = new MainPrj.View.Component.CoordinatorOrderView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.coordinatorOrderView_v2 = new MainPrj.View.Component.CoordinatorOrderView_v2();
            this.SuspendLayout();
            // 
            // coordinatorOrderView
            // 
            this.coordinatorOrderView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.coordinatorOrderView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinatorOrderView.Location = new System.Drawing.Point(61, 6);
            this.coordinatorOrderView.Margin = new System.Windows.Forms.Padding(6);
            this.coordinatorOrderView.Name = "coordinatorOrderView";
            this.coordinatorOrderView.Size = new System.Drawing.Size(289, 263);
            this.coordinatorOrderView.TabIndex = 0;
            this.coordinatorOrderView.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(77, 173);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 40);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(182, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // coordinatorOrderView_v2
            // 
            this.coordinatorOrderView_v2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.coordinatorOrderView_v2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coordinatorOrderView_v2.Location = new System.Drawing.Point(1, 1);
            this.coordinatorOrderView_v2.Margin = new System.Windows.Forms.Padding(6);
            this.coordinatorOrderView_v2.Name = "coordinatorOrderView_v2";
            this.coordinatorOrderView_v2.Size = new System.Drawing.Size(289, 163);
            this.coordinatorOrderView_v2.TabIndex = 0;
            // 
            // OrderCoordinatorView
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(291, 220);
            this.Controls.Add(this.coordinatorOrderView_v2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.coordinatorOrderView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderCoordinatorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo đơn hàng";
            this.ResumeLayout(false);

        }

        #endregion

        private Component.CoordinatorOrderView coordinatorOrderView;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private Component.CoordinatorOrderView_v2 coordinatorOrderView_v2;
    }
}