namespace MainPrj.View.Component
{
    partial class CoordinatorOrderView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnYellow = new System.Windows.Forms.RadioButton();
            this.rbtnRed = new System.Windows.Forms.RadioButton();
            this.rbtnGrey = new System.Windows.Forms.RadioButton();
            this.rbtnOrange = new System.Windows.Forms.RadioButton();
            this.rbtnBlue = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnSmall = new System.Windows.Forms.RadioButton();
            this.rbtnLarge = new System.Windows.Forms.RadioButton();
            this.tbxNote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDQuantity = new System.Windows.Forms.NumericUpDown();
            this.rbtnNoColor = new System.Windows.Forms.RadioButton();
            this.rbtnLarge50 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbxNote);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nUDQuantity);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 268);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đặt hàng";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnYellow);
            this.groupBox3.Controls.Add(this.rbtnRed);
            this.groupBox3.Controls.Add(this.rbtnNoColor);
            this.groupBox3.Controls.Add(this.rbtnGrey);
            this.groupBox3.Controls.Add(this.rbtnOrange);
            this.groupBox3.Controls.Add(this.rbtnBlue);
            this.groupBox3.Location = new System.Drawing.Point(10, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 85);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Màu";
            // 
            // rbtnYellow
            // 
            this.rbtnYellow.AutoSize = true;
            this.rbtnYellow.Location = new System.Drawing.Point(7, 50);
            this.rbtnYellow.Name = "rbtnYellow";
            this.rbtnYellow.Size = new System.Drawing.Size(77, 29);
            this.rbtnYellow.TabIndex = 7;
            this.rbtnYellow.Text = "Vàng";
            this.rbtnYellow.UseVisualStyleBackColor = true;
            // 
            // rbtnRed
            // 
            this.rbtnRed.AutoSize = true;
            this.rbtnRed.Location = new System.Drawing.Point(136, 23);
            this.rbtnRed.Name = "rbtnRed";
            this.rbtnRed.Size = new System.Drawing.Size(55, 29);
            this.rbtnRed.TabIndex = 5;
            this.rbtnRed.Text = "Đỏ";
            this.rbtnRed.UseVisualStyleBackColor = true;
            // 
            // rbtnGrey
            // 
            this.rbtnGrey.AutoSize = true;
            this.rbtnGrey.Location = new System.Drawing.Point(136, 50);
            this.rbtnGrey.Name = "rbtnGrey";
            this.rbtnGrey.Size = new System.Drawing.Size(71, 29);
            this.rbtnGrey.TabIndex = 8;
            this.rbtnGrey.Text = "Xám";
            this.rbtnGrey.UseVisualStyleBackColor = true;
            // 
            // rbtnOrange
            // 
            this.rbtnOrange.AutoSize = true;
            this.rbtnOrange.Location = new System.Drawing.Point(208, 50);
            this.rbtnOrange.Name = "rbtnOrange";
            this.rbtnOrange.Size = new System.Drawing.Size(72, 29);
            this.rbtnOrange.TabIndex = 9;
            this.rbtnOrange.Text = "Cam";
            this.rbtnOrange.UseVisualStyleBackColor = true;
            // 
            // rbtnBlue
            // 
            this.rbtnBlue.AutoSize = true;
            this.rbtnBlue.Location = new System.Drawing.Point(208, 23);
            this.rbtnBlue.Name = "rbtnBlue";
            this.rbtnBlue.Size = new System.Drawing.Size(77, 29);
            this.rbtnBlue.TabIndex = 6;
            this.rbtnBlue.Text = "Xanh";
            this.rbtnBlue.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnSmall);
            this.groupBox2.Controls.Add(this.rbtnLarge50);
            this.groupBox2.Controls.Add(this.rbtnLarge);
            this.groupBox2.Location = new System.Drawing.Point(11, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 68);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loại gas";
            // 
            // rbtnSmall
            // 
            this.rbtnSmall.AutoSize = true;
            this.rbtnSmall.Checked = true;
            this.rbtnSmall.Location = new System.Drawing.Point(6, 29);
            this.rbtnSmall.Name = "rbtnSmall";
            this.rbtnSmall.Size = new System.Drawing.Size(66, 29);
            this.rbtnSmall.TabIndex = 1;
            this.rbtnSmall.TabStop = true;
            this.rbtnSmall.Text = "Nhỏ";
            this.rbtnSmall.UseVisualStyleBackColor = true;
            // 
            // rbtnLarge
            // 
            this.rbtnLarge.AutoSize = true;
            this.rbtnLarge.Location = new System.Drawing.Point(84, 29);
            this.rbtnLarge.Name = "rbtnLarge";
            this.rbtnLarge.Size = new System.Drawing.Size(63, 29);
            this.rbtnLarge.TabIndex = 2;
            this.rbtnLarge.TabStop = true;
            this.rbtnLarge.Text = "Lớn";
            this.rbtnLarge.UseVisualStyleBackColor = true;
            // 
            // tbxNote
            // 
            this.tbxNote.Location = new System.Drawing.Point(104, 226);
            this.tbxNote.Multiline = true;
            this.tbxNote.Name = "tbxNote";
            this.tbxNote.Size = new System.Drawing.Size(192, 36);
            this.tbxNote.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ghi chú:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lượng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bình";
            // 
            // nUDQuantity
            // 
            this.nUDQuantity.Location = new System.Drawing.Point(104, 29);
            this.nUDQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDQuantity.Name = "nUDQuantity";
            this.nUDQuantity.Size = new System.Drawing.Size(135, 30);
            this.nUDQuantity.TabIndex = 0;
            this.nUDQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbtnNoColor
            // 
            this.rbtnNoColor.AutoSize = true;
            this.rbtnNoColor.Checked = true;
            this.rbtnNoColor.Location = new System.Drawing.Point(6, 23);
            this.rbtnNoColor.Name = "rbtnNoColor";
            this.rbtnNoColor.Size = new System.Drawing.Size(131, 29);
            this.rbtnNoColor.TabIndex = 4;
            this.rbtnNoColor.Text = "Không màu";
            this.rbtnNoColor.UseVisualStyleBackColor = true;
            // 
            // rbtnLarge50
            // 
            this.rbtnLarge50.AutoSize = true;
            this.rbtnLarge50.Location = new System.Drawing.Point(153, 29);
            this.rbtnLarge50.Name = "rbtnLarge50";
            this.rbtnLarge50.Size = new System.Drawing.Size(125, 29);
            this.rbtnLarge50.TabIndex = 3;
            this.rbtnLarge50.TabStop = true;
            this.rbtnLarge50.Text = "Lớn (50kg)";
            this.rbtnLarge50.UseVisualStyleBackColor = true;
            // 
            // CoordinatorOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CoordinatorOrderView";
            this.Size = new System.Drawing.Size(315, 274);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDQuantity;
        private System.Windows.Forms.RadioButton rbtnYellow;
        private System.Windows.Forms.RadioButton rbtnBlue;
        private System.Windows.Forms.RadioButton rbtnOrange;
        private System.Windows.Forms.RadioButton rbtnGrey;
        private System.Windows.Forms.RadioButton rbtnRed;
        private System.Windows.Forms.RadioButton rbtnLarge;
        private System.Windows.Forms.RadioButton rbtnSmall;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnNoColor;
        private System.Windows.Forms.RadioButton rbtnLarge50;

    }
}
