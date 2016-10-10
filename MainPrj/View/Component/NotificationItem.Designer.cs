namespace MainPrj.View.Component
{
    partial class NotificationItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbxAvatar = new System.Windows.Forms.PictureBox();
            this.lblSender = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMarkRead = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnMarkedRead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxAvatar
            // 
            this.pbxAvatar.BackColor = System.Drawing.Color.Black;
            this.pbxAvatar.Location = new System.Drawing.Point(12, 5);
            this.pbxAvatar.Name = "pbxAvatar";
            this.pbxAvatar.Size = new System.Drawing.Size(57, 57);
            this.pbxAvatar.TabIndex = 16;
            this.pbxAvatar.TabStop = false;
            this.pbxAvatar.MouseHover += new System.EventHandler(this.pbxAvatar_MouseHover);
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSender.Location = new System.Drawing.Point(81, 5);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(193, 15);
            this.lblSender.TabIndex = 17;
            this.lblSender.Text = "Điều phối Phạm Ngọc Thùy Trang";
            this.lblSender.MouseHover += new System.EventHandler(this.lblSender_MouseHover);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(81, 22);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(305, 15);
            this.lblMessage.TabIndex = 17;
            this.lblMessage.Text = "đã tạo một đơn hàng mới cho Khách hàng Quán ốc...";
            this.lblMessage.MouseHover += new System.EventHandler(this.lblMessage_MouseHover);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblTime.Location = new System.Drawing.Point(107, 39);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(131, 15);
            this.lblTime.TabIndex = 17;
            this.lblTime.Text = "khoảng một phút trước";
            this.lblTime.MouseHover += new System.EventHandler(this.lblTime_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MainPrj.Properties.Resources.timer;
            this.pictureBox1.Location = new System.Drawing.Point(84, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // btnMarkRead
            // 
            this.btnMarkRead.FlatAppearance.BorderSize = 0;
            this.btnMarkRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkRead.Image = global::MainPrj.Properties.Resources.markread;
            this.btnMarkRead.Location = new System.Drawing.Point(390, 9);
            this.btnMarkRead.Name = "btnMarkRead";
            this.btnMarkRead.Size = new System.Drawing.Size(16, 43);
            this.btnMarkRead.TabIndex = 19;
            this.btnMarkRead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnMarkRead, "Đánh dấu là đã đọc");
            this.btnMarkRead.UseVisualStyleBackColor = false;
            this.btnMarkRead.Visible = false;
            this.btnMarkRead.Click += new System.EventHandler(this.btnMarkRead_Click);
            this.btnMarkRead.MouseHover += new System.EventHandler(this.btnMarkRead_MouseHover);
            // 
            // btnMarkedRead
            // 
            this.btnMarkedRead.FlatAppearance.BorderSize = 0;
            this.btnMarkedRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkedRead.Image = global::MainPrj.Properties.Resources.markedread;
            this.btnMarkedRead.Location = new System.Drawing.Point(390, 9);
            this.btnMarkedRead.Name = "btnMarkedRead";
            this.btnMarkedRead.Size = new System.Drawing.Size(16, 43);
            this.btnMarkedRead.TabIndex = 19;
            this.btnMarkedRead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip.SetToolTip(this.btnMarkedRead, "Đã đọc");
            this.btnMarkedRead.UseVisualStyleBackColor = false;
            this.btnMarkedRead.Visible = false;
            this.btnMarkedRead.MouseHover += new System.EventHandler(this.btnMarkRead_MouseHover);
            // 
            // NotificationItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnMarkedRead);
            this.Controls.Add(this.btnMarkRead);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblSender);
            this.Controls.Add(this.pbxAvatar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "NotificationItem";
            this.Size = new System.Drawing.Size(430, 67);
            this.Load += new System.EventHandler(this.NotificationItem_Load);
            this.Click += new System.EventHandler(this.NotificationItem_Click);
            this.MouseLeave += new System.EventHandler(this.NotificationItem_MouseLeave);
            this.MouseHover += new System.EventHandler(this.NotificationItem_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAvatar;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMarkRead;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnMarkedRead;
    }
}
