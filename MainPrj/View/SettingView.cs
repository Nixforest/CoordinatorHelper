using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class SettingView : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handle when click Advance button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnAdvance_Click(object sender, EventArgs e)
        {
            // Turn on control
            nUDMainPort.ReadOnly = false;
            nUDMainPort.Enabled = true;
            chbTestingMode.Visible = true;
        }

        /// <summary>
        /// Handle when click on Save button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UdpMainPort = (int)nUDMainPort.Value;
            Properties.Settings.Default.ServerURL = tbxServerURL.Text;
            Properties.Settings.Default.URLGetCustomerByPhone = tbxURLGetCustomerByPhone.Text;
            Properties.Settings.Default.PhoneListToken = tbxPhoneSeparator.Text;
            Properties.Settings.Default.PhoneKey = tbxKeyIncommingPhone.Text;
            Properties.Settings.Default.TestingMode = chbTestingMode.Checked;
            Properties.Settings.Default.URLGetCustomerByKeyword = tbxURLGetCustomerByKeyword.Text;
            Properties.Settings.Default.KeywordKey = tbxKeyKeyword.Text;
            Properties.Settings.Default.URLUpdateCustomerPhone = tbxURLUpdateCustomerPhone.Text;
            Properties.Settings.Default.CustomerIdKey = tbxKeyCustomerId.Text;
            //FileInfo.
            Properties.Settings.Default.HistoryFilePath = tbxHistoryFilepath.Text;
            Properties.Settings.Default.HistoryFileName = tbxHistoryFilename.Text;
            Properties.Settings.Default.CallIdFormat = tbxCallIdFormat.Text;

            // Save setting
            Properties.Settings.Default.Save();
            // Close form
            this.Close();
        }

        /// <summary>
        /// Handle when click close button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close form
            this.Close();
        }
        /// <summary>
        /// Handle when load form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void SettingView_Load(object sender, EventArgs e)
        {
            nUDMainPort.Value = Properties.Settings.Default.UdpMainPort;
            tbxServerURL.Text = Properties.Settings.Default.ServerURL;
            tbxURLGetCustomerByPhone.Text = Properties.Settings.Default.URLGetCustomerByPhone;
            tbxPhoneSeparator.Text = Properties.Settings.Default.PhoneListToken;
            tbxKeyIncommingPhone.Text = Properties.Settings.Default.PhoneKey;
            chbTestingMode.Checked = Properties.Settings.Default.TestingMode;
            tbxURLGetCustomerByKeyword.Text = Properties.Settings.Default.URLGetCustomerByKeyword;
            tbxKeyKeyword.Text = Properties.Settings.Default.KeywordKey;
            tbxURLUpdateCustomerPhone.Text = Properties.Settings.Default.URLUpdateCustomerPhone;
            tbxKeyCustomerId.Text = Properties.Settings.Default.CustomerIdKey;
            tbxIP.Text = CommonProcess.GetLocalIPAddress();
            tbxHistoryFilepath.Text = Properties.Settings.Default.HistoryFilePath;
            tbxHistoryFilename.Text = Properties.Settings.Default.HistoryFileName;
            tbxCallIdFormat.Text = Properties.Settings.Default.CallIdFormat;
        }
        /// <summary>
        /// Handle when click on button Open file.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fileDialog = new FolderBrowserDialog())
            {
                if (DialogResult.OK == fileDialog.ShowDialog())
                {
                    tbxHistoryFilepath.Text = fileDialog.SelectedPath;
                }
            }
        }
    }
}
