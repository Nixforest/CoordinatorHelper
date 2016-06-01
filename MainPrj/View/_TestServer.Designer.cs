namespace MainPrj.View
{
    partial class _TestServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxServer = new System.Windows.Forms.ComboBox();
            this.btnSendReq = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // cbxServer
            // 
            this.cbxServer.FormattingEnabled = true;
            this.cbxServer.Items.AddRange(new object[] {
            "/api/default/getCustomerByPhone",
            "/api/default/updateCustomerPhone",
            "/api/default/getCustomerByKeyword",
            "/api/site/login",
            "/api/site/logout"});
            this.cbxServer.Location = new System.Drawing.Point(60, 10);
            this.cbxServer.Name = "cbxServer";
            this.cbxServer.Size = new System.Drawing.Size(417, 21);
            this.cbxServer.TabIndex = 1;
            // 
            // btnSendReq
            // 
            this.btnSendReq.Location = new System.Drawing.Point(496, 8);
            this.btnSendReq.Name = "btnSendReq";
            this.btnSendReq.Size = new System.Drawing.Size(93, 23);
            this.btnSendReq.TabIndex = 2;
            this.btnSendReq.Text = "Request";
            this.btnSendReq.UseVisualStyleBackColor = true;
            this.btnSendReq.Click += new System.EventHandler(this.btnSendReq_Click);
            // 
            // _TestServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 261);
            this.Controls.Add(this.btnSendReq);
            this.Controls.Add(this.cbxServer);
            this.Controls.Add(this.label1);
            this.Name = "_TestServer";
            this.Text = "_TestServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxServer;
        private System.Windows.Forms.Button btnSendReq;
    }
}