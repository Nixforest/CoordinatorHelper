using MainPrj.Model;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
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
            toolStripStatusLabel.Text = Properties.Resources.RequestingLogin;
            UpdateUI(false);
            CommonProcess.RequestLogin(
                tbxUsername.Text.Trim(),
                tbxPassword.Text.Trim(), loginProgressChanged, loginCompleted);
            //++ BUG0046-SPJ (NguyenPT 20160824) Login automatically
            if (chbSaveLogin.Checked)
            {
                CommonProcess.WriteLoginInfoToSetting(
                    tbxUsername.Text.Trim(),
                    tbxPassword.Text.Trim());
            }
            //-- BUG0046-SPJ (NguyenPT 20160824) Login automatically
        }
        /// <summary>
        /// Handle when login request is completed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void loginCompleted(object sender, System.Net.UploadValuesCompletedEventArgs e)
        {
            UpdateUI(true);
            if (e.Cancelled)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + Properties.Resources.Cancel;
            }
            else if (e.Error != null)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + e.Error.Message;
            }
            else
            {
                toolStripStatusLabel.Text  = Properties.Resources.LoginSuccess;
                Properties.Settings.Default.LastUsername = tbxUsername.Text;
                Properties.Settings.Default.Save();
                toolStripProgressBar.Value = 0;
                byte[] response            = e.Result;
                string respStr             = String.Empty;
                respStr                    = System.Text.Encoding.UTF8.GetString(response);
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(UserLoginResponseModel));
                    byte[] encodingBytes = null;
                    try
                    {
                        // Encoding response data
                        encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);
                    }
                    catch (System.Text.EncoderFallbackException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.EncodingError);
                    }
                    if (encodingBytes != null)
                    {
                        MemoryStream msU = new MemoryStream(encodingBytes);
                        UserLoginResponseModel baseResp = (UserLoginResponseModel)js.ReadObject(msU);
                        if (baseResp != null)
                        {
                            if (!String.IsNullOrEmpty(baseResp.Token))
                            {
                                Properties.Settings.Default.UserToken = baseResp.Token;
                                Properties.Settings.Default.Save();
                            }
                            UserLoginResponseModel userResp = baseResp;
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
                                if (userResp.User_id != null)
                                {
                                    user.User_id = userResp.User_id;
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
                    }
                }
            }
        }
        /// <summary>
        /// Handle when login request is processing.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void loginProgressChanged(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            //if ((e.ProgressPercentage <= 50)
            //    && (e.ProgressPercentage >= 0))
            //{
            //    toolStripProgressBar.Value = e.ProgressPercentage * 2;
            //}
            //toolStripStatusLabel.Text = Properties.Resources.RequestingLogin;
            CommonProcess.UpdateProgress(e, Properties.Resources.RequestingLogin,
                toolStripProgressBar, toolStripStatusLabel);
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
        /// <summary>
        /// Update UI.
        /// </summary>
        /// <param name="isEnabled">True is enable, False is disable</param>
        private void UpdateUI(bool isEnabled)
        {
            tbxUsername.Enabled = isEnabled;
            tbxPassword.Enabled = isEnabled;
            chbShowPass.Enabled = isEnabled;
            btnLogin.Enabled    = isEnabled;
            btnCancel.Enabled   = isEnabled;
        }
        /// <summary>
        /// Handle load form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void LoginView_Load(object sender, EventArgs e)
        {
            tbxUsername.Text = Properties.Settings.Default.LastUsername;
        }
    }
}
