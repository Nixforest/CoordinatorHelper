using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class InputPassword : Form
    {
        public InputPassword()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbxPassword.UseSystemPasswordChar = !cbxShowPassword.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pass = CommonProcess.ReadPasswordFromSetting();
            if (pass.Equals(tbxPassword.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                CommonProcess.ShowInformMessage("Mật khẩu không đúng", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
