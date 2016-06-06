using System;
using System.ComponentModel;
using System.Net.Cache;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;

namespace AutoUpdaterDotNET
{
    internal partial class DownloadUpdateDialog : Form
    {
        private readonly string _downloadURL;

        private string _tempPath;

        private WebClient _webClient;
        private string _newVersion = String.Empty;

        public DownloadUpdateDialog(string downloadURL, string newVersion)
        {
            InitializeComponent();

            _downloadURL = downloadURL;
            _newVersion = newVersion;
        }

        private void DownloadUpdateDialogLoad(object sender, EventArgs e)
        {
            _webClient = new WebClient();

            var uri = new Uri(_downloadURL);

            string fileName = GetFileName(_downloadURL);

            _tempPath = Path.Combine(Path.GetTempPath(), fileName);

            _webClient.DownloadProgressChanged += OnDownloadProgressChanged;

            _webClient.DownloadFileCompleted += OnDownloadComplete;

            while (_webClient.IsBusy) { }
            _webClient.DownloadFileAsync(uri, _tempPath);
            //_webClient.DownloadFile(uri, _tempPath);
            labelInformation.Text = "Đang tải file: " + fileName;
            //while (_webClient.IsBusy) { }
        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        private void OnDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            string currentFolder = Directory.GetCurrentDirectory();
            string currentPath = Path.Combine(currentFolder, Path.GetFileName(_tempPath));
            try
            {
                File.Copy(_tempPath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (!e.Cancelled && !String.IsNullOrEmpty(_newVersion))
            {
                IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, Assembly.GetEntryAssembly().GetName().Name);
                if (hWnd.ToInt32() != 0)
                {
                    Clipboard.SetText(_newVersion);
                    PostMessage(hWnd, WM_USER + 1, 0, 0);
                }
                //if (AutoUpdater.IsWinFormsApplication)
                //{
                //    Application.Exit();
                //}
                //else
                //{
                //    Environment.Exit(0);
                //}
                //// Copy to current location
                //string currentFolder = Directory.GetCurrentDirectory();
                //string currentPath = Path.Combine(currentFolder, Path.GetFileName(_tempPath));
                //try
                //{  
                //    File.Copy(_tempPath, currentPath, true);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    return;
                //}
                //var processStartInfo = new ProcessStartInfo { FileName = currentPath, UseShellExecute = true };
                //Process.Start(processStartInfo);
            }
            _webClient.Dispose();
            this.Close();
        }

        private static string GetFileName(string url)
        {
            var fileName = string.Empty;
            var uri = new Uri(url);
            if (uri.Scheme.Equals(Uri.UriSchemeHttp) || uri.Scheme.Equals(Uri.UriSchemeHttps))
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
                httpWebRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                httpWebRequest.Method = "HEAD";
                httpWebRequest.AllowAutoRedirect = false;
                var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                if (httpWebResponse.StatusCode.Equals(HttpStatusCode.Redirect) ||
                    httpWebResponse.StatusCode.Equals(HttpStatusCode.Moved) ||
                    httpWebResponse.StatusCode.Equals(HttpStatusCode.MovedPermanently))
                {
                    if (httpWebResponse.Headers["Location"] != null)
                    {
                        var location = httpWebResponse.Headers["Location"];
                        fileName = GetFileName(location);
                        return fileName;
                    }
                }
                var contentDisposition = httpWebResponse.Headers["content-disposition"];
                if (!string.IsNullOrEmpty(contentDisposition))
                {
                    const string lookForFileName = "filename=";
                    var index = contentDisposition.IndexOf(lookForFileName, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                        fileName = contentDisposition.Substring(index + lookForFileName.Length);
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Substring(1, fileName.Length - 2);
                    }
                }
            }
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Path.GetFileName(uri.LocalPath);
            }
            return fileName;
        }

        private void DownloadUpdateDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _webClient.CancelAsync();
        }

        public uint WM_USER = 0x0400;
    }
}
