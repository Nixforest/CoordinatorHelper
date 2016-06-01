using MainPrj.Model;
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
    public partial class LoginView : Form
    {
        private UserLoginModel user = new UserLoginModel();

        public UserLoginModel User
        {
            get { return user; }
            set { user = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handle click Login button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLoginResponseModel userResp = CommonProcess.RequestLogin(
                tbxUsername.Text.Trim(),
                tbxPassword.Text.Trim());
            if (userResp.Status.Equals("1"))
            {
                // Login success
                if (!String.IsNullOrEmpty(userResp.Token))
                {
                    // Save token
                    Properties.Settings.Default.UserToken = userResp.Token;
                    Properties.Settings.Default.Save();
                }
                if (userResp.Record != null)
	            {
                    user = userResp.Record;
                }
                if (CommonProcess.IsValidNumber(userResp.Role_id))
                {
                    user.Role = (RoleType)int.Parse(userResp.Role_id);
                }
                if (!String.IsNullOrEmpty(userResp.Role_name))
                {
                    user.RoleStr = userResp.Role_name;
                }
                this.Close();
            }
            else
            {
                CommonProcess.ShowErrorMessage(userResp.Message);
            }
        }
        /// <summary>
        /// Handle click Show password.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void chbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            this.tbxPassword.UseSystemPasswordChar = !this.chbShowPass.Checked;
        }
        /// <summary>
        /// Handle click Logout button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
