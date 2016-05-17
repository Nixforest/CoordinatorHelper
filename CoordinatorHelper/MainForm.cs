using CoordinatorHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoordinatorHelper
{
    /// <summary>
    /// Main form of application.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Main Udp client.
        /// </summary>
        private UdpClient mainUdp = null;
        /// <summary>
        /// Udp thread.
        /// </summary>
        private Thread udpThread = default(Thread);

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            // Start thread
            StartUdpThread();
        }
        /// <summary>
        /// Start udp in separate thread.
        /// </summary>
        private void StartUdpThread()
        {
            // Create new Udp client
            try
            {
                mainUdp = new UdpClient(Properties.Settings.Default.UdpMainPort);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show(String.Format("{0} {1}", Properties.Resources.UdpClientArgumentOutOfRangeException,
                    Properties.Settings.Default.UdpMainPort),
                    Properties.Resources.Error);
                this.Close();
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show(String.Format("{0} {1}", Properties.Resources.UdpClientArgumentOutOfRangeException,
                    Properties.Settings.Default.UdpMainPort),
                    Properties.Resources.Error);
                this.Close();
            }
            // Start thread for reading Tansonic card
            try
            {
                udpThread = new Thread(ConnectWithTansonicCard);
                udpThread.Start();
                udpThread.IsBackground = true;
            }
            catch (System.ArgumentNullException)
            {
                this.Close();
            }
            catch (System.Threading.ThreadStateException)
            {
                MessageBox.Show(Properties.Resources.ThreadStateError,
                    Properties.Resources.Error);
                this.Close();
            }
            catch (System.OutOfMemoryException)
            {
                MessageBox.Show(Properties.Resources.OutOfMemory,
                    Properties.Resources.Error);
                this.Close();
            }
        }
        /// <summary>
        /// Get data from Tansonic card.
        /// </summary>
        private void ConnectWithTansonicCard()
        {
            string recvBuf = "";
            IPEndPoint remoteHost = new IPEndPoint(IPAddress.Any, 0);
            while (mainUdp != null)
            {
                try
                {
                    byte[] dataBuf = mainUdp.Receive(ref remoteHost);
                    // Get data success
                    if (dataBuf != null)
                    {
                        recvBuf = Encoding.ASCII.GetString(dataBuf, 0, dataBuf.Length);
                    }
                    PrintData(recvBuf);
                }
                catch (System.ObjectDisposedException)
                {
                    MessageBox.Show(Properties.Resources.ObjectDisposedException,
                        Properties.Resources.Error);
                    this.Close();
                }
                catch (System.Net.Sockets.SocketException)
                {
                    MessageBox.Show(Properties.Resources.SocketException,
                        Properties.Resources.Error);
                    this.Close();
                }
                catch (System.Text.DecoderFallbackException)
                {
                    MessageBox.Show(Properties.Resources.DecoderError,
                        Properties.Resources.Error);
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Method invoker delegate.
        /// </summary>
        /// <param name="text">Text data</param>
        delegate void MethodInvoker(string text);
        /// <summary>
        /// Print data get from Tansonic card.
        /// </summary>
        /// <param name="data">Data to print</param>
        private void PrintData(string data)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(this.PrintData);
                this.Invoke(invoker, data);
                return;
            }
            int n;
            CardDataModel model = new CardDataModel(data);
            if (!String.IsNullOrEmpty(model.Phone))
            {
                if (int.TryParse(model.Phone, out n))
                {
                    this.tbxIncomingNumber.Text = model.Phone;
                }
            }
            this.tbxLog.Text = data + "\r\n" + this.tbxLog.Text;
        }
        /// <summary>
        /// Handle when click Setting menu.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemSetting_Click(object sender, EventArgs e)
        {
            CoordinatorHelper.View.Setting settingForm = new CoordinatorHelper.View.Setting();
            settingForm.ShowDialog();
        }
    }
}
