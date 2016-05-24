using MainPrj.Model;
using MainPrj.Util;
using MainPrj.View;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPrj
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
        /// Current channel.
        /// </summary>
        private int currentChannel = 0;
        /// <summary>
        /// List of tab control.
        /// </summary>
        private List<ChannelControl> listChannelControl = new List<ChannelControl>();
        /// <summary>
        /// List of calls.
        /// </summary>
        private List<CallModel> listCalls = new List<CallModel>();
        /// <summary>
        /// List flag need update title of tab controls.
        /// </summary>
        private bool[] listChannelNeedUpdateTitle = new bool[Properties.Settings.Default.ChannelNumber];

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.mainTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.mainTabControl.DrawItem += mainTabControl_DrawItem;
            // Start thread
            StartUdpThread();
        }
        /// <summary>
        /// Handle draw tab title.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">DrawItemEventArgs</param>
        void mainTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index.Equals(this.mainTabControl.SelectedIndex))
            {
                e.Graphics.FillRectangle(new SolidBrush(Properties.Settings.Default.ColorTabActiveBackground), e.Bounds);
            }
            string title = mainTabControl.TabPages[e.Index].Text;
			Font font = this.mainTabControl.Font;
			PointF point = new PointF((float)(e.Bounds.X + 3), (float)(e.Bounds.Y + 3));
            if (title.Contains(Properties.Resources.CardDataStatus1))
            {
                e.Graphics.DrawString(title, font,
                    new SolidBrush(Properties.Settings.Default.ColorIncommingCallText),
                    point);
            }
            else if (title.Contains(Properties.Resources.CardDataStatus3))
            {
                e.Graphics.DrawString(title, font,
                    new SolidBrush(Properties.Settings.Default.ColorHandleCallText),
                    point);
            }
            else if (title.Contains(Properties.Resources.CardDataStatus4))
            {
                e.Graphics.DrawString(title, font,
                    new SolidBrush(Properties.Settings.Default.ColorFinishCallTabText),
                    point);
            }
            else if (title.Contains(Properties.Resources.CardDataStatus5))
            {
                e.Graphics.DrawString(title, font,
                    new SolidBrush(Properties.Settings.Default.ColorMissCallText),
                    point);
            }
            else
            {
                e.Graphics.DrawString(title, font, Brushes.Black, point);
            }
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
                CommonProcess.ShowErrorMessage(String.Format("{0} {1}", Properties.Resources.UdpClientArgumentOutOfRangeException,
                    Properties.Settings.Default.UdpMainPort));
                this.Close();
            }
            catch (System.Net.Sockets.SocketException)
            {
                CommonProcess.ShowErrorMessage(String.Format("{0} {1}", Properties.Resources.UdpClientArgumentOutOfRangeException,
                    Properties.Settings.Default.UdpMainPort));
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
                CommonProcess.ShowErrorMessage(Properties.Resources.ThreadStateError);
                this.Close();
            }
            catch (System.OutOfMemoryException)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.OutOfMemory);
                this.Close();
            }
        }
        /// <summary>
        /// Get data from Tansonic card.
        /// </summary>
        private void ConnectWithTansonicCard()
        {
            string recvBuf = String.Empty;
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
                    if ((Properties.Settings.Default.TestingMode                    // Testing mode is ON
                            && Properties.Settings.Default.ListeningCardMode)       // but ListeningCard mode is ON
                        || !Properties.Settings.Default.TestingMode)                // Testing mode is OFF
                    {
                        PrintData(recvBuf);
                    }
                }
                catch (System.ObjectDisposedException)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.ObjectDisposedException);
                    this.Close();
                }
                catch (System.Net.Sockets.SocketException)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.SocketException);
                    this.Close();
                }
                catch (System.Text.DecoderFallbackException)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.DecoderError);
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
            CardDataModel model = new CardDataModel(data);          // Data model
            bool needUpdate = false;                                // Flag need update UI
            ChannelControl channel = null;                          // Channel incomming
            // Get incomming number information
            if (!String.IsNullOrEmpty(model.Phone))
            {
                // Check phone is valid
                if (int.TryParse(model.Phone, out n))
                {
                    // Insert value into current channel
                    try
                    {
                        // Get incomming channel
                        if ((model.Channel >= 0)
                            && (model.Channel < Properties.Settings.Default.ChannelNumber))
                        {
                            channel = this.listChannelControl.ElementAt(model.Channel);
                        }
                        string statusStr = String.Empty;
                        Color color = Color.White;
                        // Handle update channel title
                        switch (model.Status)
                        {
                            case (int)CardDataStatus.CARDDATA_RINGING:
                                statusStr = Properties.Resources.CardDataStatus1;
                                color = Color.DarkGreen;
                                break;
                            case (int)CardDataStatus.CARDDATA_CALLING:
                                //statusStr = Properties.Resources.CardDataStatus2;
                                break;
                            case (int)CardDataStatus.CARDDATA_HANDLING:
                                statusStr = Properties.Resources.CardDataStatus3;
                                color = Color.Blue;
                                needUpdate = true;
                                break;
                            case (int)CardDataStatus.CARDDATA_HANGUP:
                                statusStr = Properties.Resources.CardDataStatus4;
                                color = Color.Pink;
                                break;
                            case (int)CardDataStatus.CARDDATA_MISS:
                                needUpdate = true;
                                statusStr = Properties.Resources.CardDataStatus5;
                                color = Color.Red;
                                break;
                            case (int)CardDataStatus.CARDDATA_RECORD:
                                statusStr = Properties.Resources.CardDataStatus6;
                                break;
                            default:
                                break;
                        }
                        // Update tab title
                        UpdateTabTitle(model.Channel, model.Phone, model.Status, statusStr);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                    }
                }
            }
            if (needUpdate)
            {
                ChannelControl currentChannelCtrl = this.listChannelControl[this.currentChannel];
                
                if (!model.Channel.Equals(this.currentChannel)
                    && currentChannelCtrl.CanChangeTab())
                {
                    this.currentChannel = model.Channel;
                    // Show up incomming channel
                    if ((this.currentChannel >= 0)
                        && (this.currentChannel < Properties.Settings.Default.ChannelNumber))
                    {
                        this.mainTabControl.SelectedIndex = this.currentChannel;
                    }
                }
                if (channel != null)
                {
                    channel.SetIncommingPhone(model.Phone);
                    UpdateData(model.Phone, model.Status);
                }
                //this.listCalls.Add
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
            SettingView setting = new SettingView();
            setting.ShowDialog();
        }
        /// <summary>
        /// Handle when loading form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.listChannelControl.Add(this.channelControlLine1);
            this.listChannelControl.Add(this.channelControlLine2);
            this.listChannelControl.Add(this.channelControlLine3);
            this.listChannelControl.Add(this.channelControlLine4);
            this.listChannelControl.Add(this.channelControlLine5);
            this.listChannelControl.Add(this.channelControlLine6);
            this.listChannelControl.Add(this.channelControlLine7);
            this.listChannelControl.Add(this.channelControlLine8);
            // Turn on flag update tab title
            for (int i = 0; i < this.listChannelNeedUpdateTitle.Length; i++)
            {
                this.listChannelNeedUpdateTitle[i] = true;
            }
            // For test
            TurnOnOffTestingMode(Properties.Settings.Default.TestingMode);

            if (Properties.Settings.Default.TestingMode)
            {
                this.channelControlLine2.SetIncommingPhone("01869194542");
                this.channelControlLine3.SetIncommingPhone("01674816039");
                this.chbListenFromCard.Checked = Properties.Settings.Default.ListeningCardMode;
            }
        }
        /// <summary>
        /// Update data to channel tab.
        /// </summary>
        /// <param name="phone">Incomming number</param>
        private void UpdateData(string phone, int status)
        {
            // Get list of customers
            List<CustomerModel> listCustomer = CommonProcess.RequestCustomerByPhone(phone);
            // Check if has error when handle common process
            if (CommonProcess.HasError)
            {
                // Reset flag
                CommonProcess.HasError = false;
                // Stop
                return;
            }
            // Get current channel
            ChannelControl channel = null;
            CustomerModel customer = new CustomerModel();
            try
            {
                channel = this.listChannelControl.ElementAt(this.currentChannel);
            }
            catch (ArgumentOutOfRangeException)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                return;
            }
            switch (listCustomer.Count)
            {
                case 0:         // Incomming phone is current not existing in system
                    customer.Name = String.Empty;
                    break;
                case 1:         // A customer has phone number is match with incomming phone
                    customer = listCustomer.ElementAt(0);
                    break;
                default:        // 2 or more customer has phone number is match with incomming phone
                    List<SelectorModel> listSelector = new List<SelectorModel>();
                    // Create list selector data
                    foreach (CustomerModel customerInfo in listCustomer)
                    {
                        SelectorModel selectorModel = new SelectorModel();
                        selectorModel.Id = customerInfo.Id;
                        selectorModel.Name = customerInfo.Name;
                        selectorModel.Address = customerInfo.Address;
                        listSelector.Add(selectorModel);
                    }
                    // Create SelectorView
                    SelectorView selectorForm = new SelectorView();
                    selectorForm.ListData = listSelector;
                    selectorForm.Text = Properties.Resources.SelectorTitleCustomer;
                    selectorForm.ShowDialog();
                    // Get customer id that user selected
                    string customerId = selectorForm.SelectedId;
                    if (!String.IsNullOrEmpty(customerId))
                    {
                        // Find customer id in list customer
                        foreach (CustomerModel customerInfo in listCustomer)
                        {
                            // Found
                            if (customerId.Equals(customerInfo.Id))
                            {
                               customer = customerInfo;
                                break;
                            }
                        }
                    }
                    break;
            }

            CallModel call = new CallModel(System.DateTime.Now, this.currentChannel, customer, phone, status);
            this.listCalls.Add(call);
            CommonProcess.SetChannelInformation(channel, call.Customer);
        }
        /// <summary>
        /// Handle when change tab index.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentChannel = this.mainTabControl.SelectedIndex;
        }
        /// <summary>
        /// Handle when click button search.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string phone = this.listChannelControl.ElementAt(this.currentChannel).GetIncommingPhone();
            int n = 0;
            // Get incomming number information
            if (!String.IsNullOrEmpty(phone) && int.TryParse(phone, out n))
            {
                // Insert value into current channel
                try
                {
                    ChannelControl tab = this.listChannelControl.ElementAt(this.currentChannel);
                    tab.SetIncommingPhone(phone);
                    // Request server and update data from server
                    UpdateData(phone, (int)CardDataStatus.CARDDATA_RINGING);
                }
                catch (ArgumentOutOfRangeException)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                }
            }
        }
        /// <summary>
        /// Setting ON/OFF testing control.
        /// </summary>
        /// <param name="onoff">Flag value</param>
        private void TurnOnOffTestingMode(bool onoff)
        {
            btnSearch.Visible = onoff;
            tbxLog.Visible = onoff;
            chbListenFromCard.Visible = onoff;
        }
        /// <summary>
        /// Handle when click Create order button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            HandleClickCreateOrderButton();
        }

        /// <summary>
        /// Handle when click Save data button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            HandleClickSaveDataButton();
        }

        /// <summary>
        /// Handle when click Update customer button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            HandleClickUpdateCustomerButton();
        }

        /// <summary>
        /// Handle when click Transfer to Sale button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnTransferToSale_Click(object sender, EventArgs e)
        {
            HandleClickTransferToSaleButton();
        }
        /// <summary>
        /// Handle when press key on main form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Return)
			{
				ChannelControl channelControl = null;
				try
				{
					channelControl = this.listChannelControl.ElementAt(this.currentChannel);
				}
				catch (ArgumentOutOfRangeException)
				{
					CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
					return;
				}
				if (channelControl != null)
				{
					channelControl.SearchCustomer();
					foreach (CallModel current in this.listCalls)
					{
						if (channelControl.Data.Id.Equals(current.Customer.Id))
						{
							current.Customer.Contact_note = channelControl.Data.Contact_note;
						}
					}
				}
				return;
			}
            switch (e.KeyCode)
            {
                case Keys.F1:
                    HandleClickCreateOrderButton();
                    break;
                case Keys.F2:
                    HandleClickSaveDataButton();
                    break;
                case Keys.F3:
                    HandleClickUpdateCustomerButton();
                    break;
                case Keys.F4:
                    HandleClickTransferToSaleButton();
                    break;
                case Keys.F5:
                    HandleClickHistoryButton();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Handle when click Create order button.
        /// </summary>
        private void HandleClickCreateOrderButton()
        {
            CommonProcess.ShowInformMessageProcessing();
        }
        /// <summary>
        /// Handle when click Save data button.
        /// </summary>
        private void HandleClickSaveDataButton()
        {
            CommonProcess.ShowInformMessageProcessing();
        }
        /// <summary>
        /// Handle when click Update Customer button.
        /// </summary>
        private void HandleClickUpdateCustomerButton()
        {
            CommonProcess.ShowInformMessageProcessing();
        }
        /// <summary>
        /// Handle when click Transfer To Sale button.
        /// </summary>
        private void HandleClickTransferToSaleButton()
        {
            CommonProcess.ShowInformMessageProcessing();
        }
        /// <summary>
        /// Handle when click History button.
        /// </summary>
        private void HandleClickHistoryButton()
        {
            HistoryView historyView = new HistoryView();
            historyView.ListData.AddRange(this.listCalls);
            historyView.ShowDialog();
            foreach (CallModel current in historyView.ListData)
            {
                foreach (CallModel current2 in this.listCalls)
                {
                    if (current.Id.Equals(current2.Id))
                    {
                        current2.IsFinish = current.IsFinish;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Handle when click on checkbox Listen from card.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void chbListenFromCard_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ListeningCardMode = chbListenFromCard.Checked;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// Update tab page title.
        /// </summary>
        /// <param name="channel">Chanel</param>
        /// <param name="phone">Phone</param>
        /// <param name="status">Status</param>
        /// <param name="statusStr">Status string</param>
        private void UpdateTabTitle(int channel, string phone, int status, string statusStr)
        {
            if ((channel >= 0) && (channel < Properties.Settings.Default.ChannelNumber))
            {
                if (this.listChannelNeedUpdateTitle[channel])                           // Flag is ON
                {
                    if (status.Equals((int)CardDataStatus.CARDDATA_CALLING))            // Status is calling
                    {
                        this.listChannelNeedUpdateTitle[channel] = false;               // Turn off flag
                        return;
                    }
                }
                else                                                                    // Flag is OFF
                {
                    if (status.Equals((int)CardDataStatus.CARDDATA_RINGING))            // Status is ringing
                    {
                        this.listChannelNeedUpdateTitle[channel] = true;
                    }
                }
                // Flag is ON
                if (this.listChannelNeedUpdateTitle[channel])
                {
                    // Update tab title
                    this.mainTabControl.TabPages[channel].Text = String.Format("{0} :{1}-{2}",
                                channel + 1,
                                phone.Substring(Math.Max(0, phone.Length - Properties.Settings.Default.PhoneCutLength)),
                                statusStr);
                }
            }
        }
        /// <summary>
        /// Handle when click History button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxHistory_Click(object sender, EventArgs e)
        {
            HandleClickHistoryButton();
        }
        /// <summary>
        /// Handle when close form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Write history file
            CommonProcess.WriteHistory(this.listCalls);
        }
    }
}
