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
    public partial class MoneyInputView : Form
    {
        private string _title = string.Empty;
        private double _money = 0.0;
        /// <summary>
        /// Money value.
        /// </summary>
        public double Money
        {
            get { return _money; }
            set { _money = value; }
        }

        /// <summary>
        /// Title.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public MoneyInputView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handle click OK button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handle validate input in textbox money.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyPressEventArgs</param>
        private void tbxMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Text changed event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxMoney_TextChanged(object sender, EventArgs e)
        {
            double n = 0.0;
            if (double.TryParse(tbxMoney.Text, out n))
            {
                _money = n;
                lblMoney.Text = CommonProcess.FormatMoney(_money);
            }
        }
        /// <summary>
        /// Loading event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void MoneyInputView_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Title;
            tbxMoney.Text = Money.ToString();
        }
    }
}
