using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            AutoUpdaterDotNET.AutoUpdater.Start(Properties.Resources.CheckAutoUpdate);
            Process mainProcess = new Process();
            try
            {
                mainProcess.StartInfo.UseShellExecute = false;
                mainProcess.StartInfo.FileName = Path.Combine(Directory.GetCurrentDirectory(), "CoordinatorHelper.exe");
                mainProcess.StartInfo.CreateNoWindow = true;
                mainProcess.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
