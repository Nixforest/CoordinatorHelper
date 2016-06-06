using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Launcher
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handle start CoordinatorHelper.exe
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnRunCoordinatorHelper_Click(object sender, EventArgs e)
        {
            Process mainProcess = new Process();
            try
            {
                mainProcess.StartInfo.UseShellExecute = false;
                mainProcess.StartInfo.FileName = Path.Combine(Directory.GetCurrentDirectory(),
                    Properties.Resources.MainAppName);
                mainProcess.StartInfo.CreateNoWindow = true;
                mainProcess.Start();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Handle form loading.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set title of main form
            this.Text = Assembly.GetEntryAssembly().GetName().Name;
            toolStripStatusLabel.Text = Properties.Settings.Default.CurrrentVersion;
            btnRunCoordinatorHelper.Enabled = File.Exists(Path.Combine(Directory.GetCurrentDirectory(),
                    Properties.Resources.MainAppName));
            // Check update software
            AutoUpdaterDotNET.AutoUpdater.Start(
                Properties.Resources.CheckAutoUpdate,
                Properties.Settings.Default.CurrrentVersion);
        }
        /// <summary>
        /// Handle receive message.
        /// </summary>
        /// <param name="m">Message</param>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
        protected override void WndProc(ref Message m) 
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                case WM_USER_DOWNLOAD_FINISHED:                 // Finish download
                    Properties.Settings.Default.CurrrentVersion = Clipboard.GetText();
                    Properties.Settings.Default.Save();
                    toolStripStatusLabel.Text = Properties.Resources.DownloadFinishedMsg;
                    btnRunCoordinatorHelper.Enabled = true;
                    break;                
            }
            base.WndProc(ref m);
        }
        /// <summary>
        /// Handle keydown event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F11:              // Reset version
                    Properties.Settings.Default.CurrrentVersion = Properties.Resources.FirstVersion;
                    Properties.Settings.Default.Save();
                    toolStripStatusLabel.Text = Properties.Settings.Default.CurrrentVersion;
                    break;
                default: break;
            }
        }
        /// <summary>
        /// User message.
        /// </summary>
        public const int WM_USER = 0x0400;
        /// <summary>
        /// Download finished message.
        /// </summary>
        public const int WM_USER_DOWNLOAD_FINISHED = WM_USER + 1;
    }
}
