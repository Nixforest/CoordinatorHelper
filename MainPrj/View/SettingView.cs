using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
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
        /// Handle when click on Save button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UdpMainPort                     = (int)nUDMainPort.Value;
            Properties.Settings.Default.ServerURL                       = tbxServerURL.Text;
            Properties.Settings.Default.URLGetCustomerByPhone           = tbxURLGetCustomerByPhone.Text;
            Properties.Settings.Default.PhoneListToken                  = tbxPhoneSeparator.Text;
            Properties.Settings.Default.PhoneKey                        = tbxKeyIncommingPhone.Text;
            Properties.Settings.Default.TestingMode                     = chbTestingMode.Checked;
            Properties.Settings.Default.URLGetCustomerByKeyword         = tbxURLGetCustomerByKeyword.Text;
            Properties.Settings.Default.KeywordKey                      = tbxKeyKeyword.Text;
            Properties.Settings.Default.URLUpdateCustomerPhone          = tbxURLUpdateCustomerPhone.Text;
            Properties.Settings.Default.CustomerIdKey                   = tbxKeyCustomerId.Text;
            Properties.Settings.Default.SettingFilePath                 = tbxHistoryFilepath.Text;
            Properties.Settings.Default.HistoryFileName                 = tbxHistoryFilename.Text;
            Properties.Settings.Default.CallIdFormat                    = tbxCallIdFormat.Text;
            Properties.Settings.Default.ColorMissCallText               = this.btnMissCallTextColor.BackColor;
            Properties.Settings.Default.ColorFinishCallText             = this.btnFinishCallColor.ForeColor;
            Properties.Settings.Default.ColorFinishCallBackground       = this.btnFinishCallColor.BackColor;
            Properties.Settings.Default.TimeAutoCloseMsgBox             = (double)(this.nUDTimeAutoCloseMsgBox.Value * 1000);
            Properties.Settings.Default.ColorTabActiveBackground        = this.btnTabActiveBackgroundColor.BackColor;
            Properties.Settings.Default.ColorIncommingCallText          = this.btnTabIncommingTextColor.BackColor;
            Properties.Settings.Default.ColorHandleCallText             = this.btnTabHandleCallTextColor.BackColor;
            Properties.Settings.Default.ColorFinishCallTabText          = this.btnTabFinishCallTextColor.BackColor;
            Properties.Settings.Default.PhoneCutLength                  = (int)this.nUDPhoneCutLen.Value;
            Properties.Settings.Default.ColorFoundKeywordText           = this.btnSearchResultText.BackColor;
            Properties.Settings.Default.ColorFoundKeywordBackground     = this.btnSearchResultBackground.BackColor;
            Properties.Settings.Default.BillBrand                       = this.tbxBrand.Text;
            Properties.Settings.Default.IsTabColorChange                = this.cbxTabColorChanged.Checked;
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
            nUDMainPort.Value                          = Properties.Settings.Default.UdpMainPort;
            tbxServerURL.Text                          = Properties.Settings.Default.ServerURL;
            tbxURLGetCustomerByPhone.Text              = Properties.Settings.Default.URLGetCustomerByPhone;
            tbxPhoneSeparator.Text                     = Properties.Settings.Default.PhoneListToken;
            tbxKeyIncommingPhone.Text                  = Properties.Settings.Default.PhoneKey;
            chbTestingMode.Checked                     = Properties.Settings.Default.TestingMode;
            tbxURLGetCustomerByKeyword.Text            = Properties.Settings.Default.URLGetCustomerByKeyword;
            tbxKeyKeyword.Text                         = Properties.Settings.Default.KeywordKey;
            tbxURLUpdateCustomerPhone.Text             = Properties.Settings.Default.URLUpdateCustomerPhone;
            tbxKeyCustomerId.Text                      = Properties.Settings.Default.CustomerIdKey;
            tbxIP.Text                                 = CommonProcess.GetLocalIPAddress();
            tbxHistoryFilepath.Text                    = Properties.Settings.Default.SettingFilePath;
            tbxHistoryFilename.Text                    = Properties.Settings.Default.HistoryFileName;
            tbxCallIdFormat.Text                       = Properties.Settings.Default.CallIdFormat;
            this.btnMissCallTextColor.BackColor        = Properties.Settings.Default.ColorMissCallText;
            this.btnFinishCallColor.ForeColor          = Properties.Settings.Default.ColorFinishCallText;
            this.btnFinishCallTextColor.BackColor      = Properties.Settings.Default.ColorFinishCallText;
            this.btnFinishCallColor.BackColor          = Properties.Settings.Default.ColorFinishCallBackground;
            this.btnFinishCallBackColor.BackColor      = Properties.Settings.Default.ColorFinishCallBackground;
            this.nUDTimeAutoCloseMsgBox.Value          = (decimal)Properties.Settings.Default.TimeAutoCloseMsgBox / 1000m;
            this.btnTabActiveBackgroundColor.BackColor = Properties.Settings.Default.ColorTabActiveBackground;
            this.btnTabIncommingTextColor.BackColor    = Properties.Settings.Default.ColorIncommingCallText;
            this.btnTabHandleCallTextColor.BackColor   = Properties.Settings.Default.ColorHandleCallText;
            this.btnTabFinishCallTextColor.BackColor   = Properties.Settings.Default.ColorFinishCallTabText;
            this.btnSearchResult.ForeColor             = Properties.Settings.Default.ColorFoundKeywordText;
            this.btnSearchResult.BackColor             = Properties.Settings.Default.ColorFoundKeywordBackground;
            this.btnSearchResultText.BackColor         = Properties.Settings.Default.ColorFoundKeywordText;
            this.btnSearchResultBackground.BackColor   = Properties.Settings.Default.ColorFoundKeywordBackground;
            this.nUDPhoneCutLen.Value                  = Properties.Settings.Default.PhoneCutLength;
            this.tbxBrand.Text                         = Properties.Settings.Default.BillBrand;
            this.cbxTabColorChanged.Checked            = Properties.Settings.Default.IsTabColorChange;
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
        private void btnMissCallTextColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.colorDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                this.btnMissCallTextColor.BackColor = this.colorDialog.Color;
            }
        }

        private void btnFinishCallTextColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.colorDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                this.btnFinishCallTextColor.BackColor = this.colorDialog.Color;
                this.btnFinishCallColor.ForeColor = this.colorDialog.Color;
            }
        }

        private void btnFinishCallBackColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.colorDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                this.btnFinishCallBackColor.BackColor = this.colorDialog.Color;
                this.btnFinishCallColor.BackColor = this.colorDialog.Color;
            }
        }

        private void btnTabActiveBackground_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.colorDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                this.btnTabActiveBackgroundColor.BackColor = this.colorDialog.Color;
            }
        }

        private void btnIncommingTextColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.colorDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                this.btnTabIncommingTextColor.BackColor = this.colorDialog.Color;
            }
        }

        private void btnTabHandleCallTextColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.colorDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                this.btnTabHandleCallTextColor.BackColor = this.colorDialog.Color;
            }
        }

        private void btnTabFinishCallTextColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.colorDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                this.btnTabFinishCallTextColor.BackColor = this.colorDialog.Color;
            }
        }

        private void btnSearchResultText_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.colorDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                this.btnSearchResultText.BackColor = this.colorDialog.Color;
                this.btnSearchResult.ForeColor = this.colorDialog.Color;
            }
        }

        private void btnSearchResultBackground_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.colorDialog.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK))
            {
                this.btnSearchResultBackground.BackColor = this.colorDialog.Color;
                this.btnSearchResult.BackColor = this.colorDialog.Color;
            }
        }

        private void btnPrinterSetting_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            //foreach (string item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            //{
            //    msg += item + "\n";
            //}
            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var printer in printerQuery.Get())
            {
                var name = printer.GetPropertyValue("Name");
                var status = printer.GetPropertyValue("Status");
                var isDefault = printer.GetPropertyValue("Default");
                var isNetworkPrinter = printer.GetPropertyValue("Network");

                msg += String.Format("{0} (Status: {1}, Default: {2}, Network: {3}",
                            name, status, isDefault, isNetworkPrinter) + "\n";
            }
            CommonProcess.ShowInformMessage(msg, MessageBoxButtons.OK);
        }

        /// <summary>
        /// Handle when click Advance button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnAccess_Click(object sender, EventArgs e)
        {
            // Turn on control
            nUDMainPort.ReadOnly   = false;
            nUDMainPort.Enabled    = true;
            chbTestingMode.Visible = true;
        }
    }
}
