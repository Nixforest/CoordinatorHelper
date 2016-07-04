using MainPrj.Model;
using MainPrj.Util;
using MainPrj.View;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
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
        /// List of tab control.
        /// </summary>
        private List<ChannelControl> listChannelControl = new List<ChannelControl>();
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
            if (Properties.Settings.Default.IsTabColorChange)
            {
                this.mainTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
                this.mainTabControl.DrawItem += mainTabControl_DrawItem;
            }
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
                                FlashWindowHelper.Flash(this.Handle);
                                UpdateStatus(String.Format(Properties.Resources.IncommingCall, model.Phone));
                                statusStr = Properties.Resources.CardDataStatus1;
                                color = Color.DarkGreen;
                                break;
                            case (int)CardDataStatus.CARDDATA_CALLING:
                                //statusStr = Properties.Resources.CardDataStatus2;
                                break;
                            case (int)CardDataStatus.CARDDATA_HANDLING:
                                FlashWindowHelper.Flash(this.Handle);
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
                if (this.listChannelControl[DataPure.Instance.CurrentChannel].CanChangeTab())
                {
                    if (!model.Channel.Equals(DataPure.Instance.CurrentChannel))
                    {
                        DataPure.Instance.CurrentChannel = model.Channel;
                        // Show up incomming channel
                        if ((DataPure.Instance.CurrentChannel >= 0)
                            && (DataPure.Instance.CurrentChannel < Properties.Settings.Default.ChannelNumber))
                        {
                            this.mainTabControl.SelectedIndex = DataPure.Instance.CurrentChannel;
                        }
                    }
                    if (channel != null)
                    {
                        channel.SetIncommingPhone(model.Phone);
                        UpdateData(model.Phone, model.Status, DataPure.Instance.CurrentChannel);
                    }
                }
                else
                {
                    if (channel != null)
                    {
                        channel.SetIncommingPhone(model.Phone);
                        UpdateData(model.Phone, model.Status, model.Channel);
                    }
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
            // Initialize
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

            // Check user login
            if (!String.IsNullOrEmpty(Properties.Settings.Default.UserToken))
            {
                // Last user login already -> Request user infor from server
            }

            // For test
            TurnOnOffTestingMode(Properties.Settings.Default.TestingMode);
            if (Properties.Settings.Default.TestingMode)
            {
                this.channelControlLine2.SetIncommingPhone("01869194542");
                this.channelControlLine3.SetIncommingPhone("01674816039");
                this.channelControlLine4.SetIncommingPhone("0988180386");
                this.chbListenFromCard.Checked = Properties.Settings.Default.ListeningCardMode;
                this.chbUpdatePhone.Checked    = Properties.Settings.Default.UpdatePhone;
            }
            CommonProcess.ReadListOrders();
            CommonProcess.ReadHistory();
        }
        /// <summary>
        /// Update data to channel tab.
        /// </summary>
        /// <param name="phone">Incomming number</param>
        private void UpdateData(string phone, int status, int channelIdx)
        {
            // Disable button create customer
            //btnCreateCustomer.Enabled = false;
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
            ChannelControl channel = null;
            CustomerModel customer = new CustomerModel();
            try
            {
                // Get channel need update
                channel = this.listChannelControl.ElementAt(channelIdx);
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
                    // Disable button create customer
                    //btnCreateCustomer.Enabled = true;
                    break;
                case 1:         // A customer has phone number is match with incomming phone
                    customer = listCustomer.ElementAt(0);
                    break;
                default:        // 2 or more customer has phone number is match with incomming phone
                    // Channel need update is not current channel
                    if (!channelIdx.Equals(DataPure.Instance.CurrentChannel))
                    {
                        // Not show selector list
                        break;
                    }
                    List<SelectorModel> listSelector = new List<SelectorModel>();
                    // Create list selector data
                    foreach (CustomerModel customerInfo in listCustomer)
                    {
                        SelectorModel selectorModel = new SelectorModel();
                        selectorModel.Id            = customerInfo.Id;
                        selectorModel.Name          = customerInfo.Name;
                        selectorModel.Detail        = customerInfo.Address;
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

            customer.ActivePhone = phone;
            CallModel call = new CallModel(System.DateTime.Now, channelIdx, customer, phone, status);
            DataPure.Instance.ListCalls.Add(call);
            CommonProcess.SetChannelInformation(channel, call.Customer);
        }
        /// <summary>
        /// Handle when change tab index.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataPure.Instance.CurrentChannel = this.mainTabControl.SelectedIndex;
            DataPure.Instance.CustomerInfo = this.listChannelControl[this.mainTabControl.SelectedIndex].Data;
        }
        /// <summary>
        /// Handle when click button search.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string phone = this.listChannelControl.ElementAt(DataPure.Instance.CurrentChannel).GetIncommingPhone();
            int n = 0;
            // Get incomming number information
            if (!String.IsNullOrEmpty(phone) && int.TryParse(phone, out n))
            {
                // Insert value into current channel
                try
                {
                    ChannelControl tab = this.listChannelControl.ElementAt(DataPure.Instance.CurrentChannel);
                    tab.SetIncommingPhone(phone);
                    // Request server and update data from server
                    UpdateData(phone, (int)CardDataStatus.CARDDATA_RINGING, DataPure.Instance.CurrentChannel);
                }
                catch (ArgumentOutOfRangeException)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                }
            }
            //_TestServer test = new _TestServer();
            //test.ShowDialog();
        }
        /// <summary>
        /// Setting ON/OFF testing control.
        /// </summary>
        /// <param name="onoff">Flag value</param>
        private void TurnOnOffTestingMode(bool onoff)
        {
            btnSearch.Visible         = onoff;
            tbxLog.Visible            = onoff;
            chbListenFromCard.Visible = onoff;
            chbUpdatePhone.Visible    = onoff;
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
        /// Handle when click Create customer button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            HandleClickCreateCustomerButton();
        }
        /// <summary>
        /// Handle when press key on main form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
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
                    HandleClickCreateCustomerButton();
                    break;
                case Keys.F5:
                    HandleClickHistoryButton();
                    break;
                case Keys.F6:
                    HandleClickListOrderButton();
                    break;
                case Keys.Return:
                    ChannelControl channelControl = null;
				    try
				    {
                        channelControl = this.listChannelControl.ElementAt(DataPure.Instance.CurrentChannel);
				    }
				    catch (ArgumentOutOfRangeException)
				    {
					    CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
					    return;
				    }
				    if (channelControl != null)
				    {
					    channelControl.SearchCustomer();
                        foreach (CallModel current in DataPure.Instance.ListCalls)
					    {
						    if (channelControl.Data.Id.Equals(current.Customer.Id))
						    {
							    current.Customer.Contact_note = channelControl.Data.Contact_note;
						    }
					    }
				    }
                    break;
                case Keys.F7:
                    //HistoryView1 historyView = new HistoryView1();
                    //foreach (CallModel item in DataPure.Instance.ListCalls)
                    //{
                    //    historyView.ListData.Add(item.Id, item);
                    //}
                    //historyView.ShowDialog();
                    //foreach (CallModel current in historyView.ListData.Values)
                    //{
                    //    foreach (CallModel current2 in DataPure.Instance.ListCalls)
                    //    {
                    //        if (current.Id.Equals(current2.Id))
                    //        {
                    //            current2.IsFinish = current.IsFinish;
                    //            break;
                    //        }
                    //    }
                    //}
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
            DataPure.Instance.CustomerInfo = this.listChannelControl[DataPure.Instance.CurrentChannel].Data;
            // Check if customer name is empty
            if ((DataPure.Instance.CustomerInfo != null)
                && (!String.IsNullOrEmpty(DataPure.Instance.CustomerInfo.Name)))
            {
                RoleType role = RoleType.ROLE_ACCOUNTING_AGENT;
                if (DataPure.Instance.User != null)
                {
                    role = DataPure.Instance.User.Role;
                }
                switch (role)
                {
                    case RoleType.ROLE_ACCOUNTING_AGENT:
                        OrderView order = new OrderView();
                        order.Show();
                        break;
                    case RoleType.ROLE_DIEU_PHOI:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.MissCustomerInfor);
            }
        }
        /// <summary>
        /// Handle when click Save data button.
        /// </summary>
        private void HandleClickSaveDataButton()
        {
            //OrderCarView order = new OrderCarView();
            //order.Show();
            CommonProcess.ShowInformMessageProcessing();
        }
        /// <summary>
        /// Handle when click Update Customer button.
        /// </summary>
        private void HandleClickUpdateCustomerButton()
        {
            //CommonProcess.ShowInformMessageProcessing();
            this.listChannelControl[DataPure.Instance.CurrentChannel].SaveNote();
            UpdateStatus(Properties.Resources.NoteSaved);
        }
        /// <summary>
        /// Handle when click Transfer To Sale button.
        /// </summary>
        private void HandleClickCreateCustomerButton()
        {
            ChannelControl channelControl = null;
            try
            {
                channelControl = this.listChannelControl.ElementAt(DataPure.Instance.CurrentChannel);
            }
            catch (ArgumentOutOfRangeException)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                return;
            }
            if (channelControl != null)
            {
                if (String.IsNullOrEmpty(channelControl.Data.Name))
                {
                    List<String> customerInfo = channelControl.GetNewCustomerInfo();
                    CommonProcess.RequestCreateNewCustomer(customerInfo[0],
                        channelControl.GetIncommingPhone(),
                        customerInfo[1],
                        customerInfo[2],
                        customerInfo[3],
                        customerInfo[4],
                        customerInfo[5],
                        createCustomerProgressChanged,
                        createCustomerCompleted);
                }
            }
        }
        /// <summary>
        /// Handle when creating customer.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void createCustomerProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            if ((e.ProgressPercentage <= 50)
                && (e.ProgressPercentage >= 0))
            {
                toolStripProgressBarReqServer.Value = e.ProgressPercentage * 2;
            }
            toolStripStatusLabel.Text = Properties.Resources.RequestingCreateCustomer;
        }
        /// <summary>
        /// Handle when created customer.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void createCustomerCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + "Hủy";
            }
            else if (e.Error != null)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + e.Error.Message;
            }
            else
            {
                byte[] response = e.Result;
                string respStr = String.Empty;
                respStr = System.Text.Encoding.UTF8.GetString(response);
                // Response string is not null
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CustomerResponseModel));
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
                        CustomerResponseModel baseResp = (CustomerResponseModel)js.ReadObject(msU);
                        // Check status
                        if ((baseResp != null)
                            && (baseResp.Status.Equals("1")))
                        {
                            // Create customer is success.
                            CommonProcess.ShowInformMessage(Properties.Resources.CreateCustomerSuccess,
                                MessageBoxButtons.OK);
                            ChannelControl channelControl = null;
                            try
                            {
                                channelControl = this.listChannelControl.ElementAt(DataPure.Instance.CurrentChannel);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                                return;
                            }
                            if (channelControl != null)
                            {
                                if (baseResp.Record != null)
                                {
                                    baseResp.Record[0].ActivePhone = channelControl.GetIncommingPhone();
                                    CommonProcess.SetChannelInformation(channelControl, baseResp.Record[0]);
                                }
                            }
                        }
                        else
                        {
                            // Create customer is failed.
                            CommonProcess.ShowInformMessage(Properties.Resources.CreateCustomerFailed,
                                MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handle when click List order button.
        /// </summary>
        private void HandleClickListOrderButton()
        {
            ListOrderView view = new ListOrderView();
            view.Show();
        }
        /// <summary>
        /// Handle when click History button.
        /// </summary>
        private void HandleClickHistoryButton()
        {
            HistoryView historyView = new HistoryView();
            historyView.ListTodayData.AddRange(DataPure.Instance.ListCalls);
            historyView.ShowDialog();
            foreach (CallModel current in historyView.ListTodayData)
            {
                foreach (CallModel current2 in DataPure.Instance.ListCalls)
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
        private void btnHistory_Click(object sender, EventArgs e)
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
            //DialogResult result = CommonProcess.ShowInformMessage(Properties.Resources.AreYouSureToClose,
            //    MessageBoxButtons.YesNo);
            //if (result.Equals(DialogResult.Yes))
            //{
            //    // Write history file
            //    CommonProcess.WriteHistory(this.listCalls);
            //    Properties.Settings.Default.UserToken = String.Empty;
            //    Properties.Settings.Default.Save();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
            // Write history file
            if (!CommonProcess.WriteHistory(DataPure.Instance.ListCalls))
            {
                e.Cancel = true;
                return;
            }
            if (!CommonProcess.WriteListOrders())
            {
                e.Cancel = true;
                return;
            }
            Properties.Settings.Default.UserToken = String.Empty;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// Update status content.
        /// </summary>
        /// <param name="status">Update status</param>
        private void UpdateStatus(string status)
        {
            toolStripStatusLabel.Text = status;
        }
        /// <summary>
        /// Handle when check in Update phone checkbox
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void chbUpdatePhone_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UpdatePhone = chbUpdatePhone.Checked;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// Handle when select item Login menu
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemLogin_Click(object sender, EventArgs e)
        {
            LoginView login = new LoginView();
            login.ShowDialog();
            DataPure.Instance.User = new UserLoginModel(login.User);
            if (!String.IsNullOrEmpty(DataPure.Instance.User.First_name))
            {
                Login();
            }
        }

        /// <summary>
        /// Handle when select item Logout menu
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemLogout_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.UserToken))
            {
                CommonProcess.RequestLogout();
            }
            DataPure.Instance.User = new UserLoginModel();
            pbxAvatar.Image = CommonProcess.CreateAvatar(string.Empty, pbxAvatar.Size.Height);
            Logout();
        }
        /// <summary>
        /// Login handle.
        /// </summary>
        private void Login()
        {
            // Draw avatar
            string avatarString = string.Empty;
            if (!String.IsNullOrEmpty(DataPure.Instance.User.First_name))
            {
                string[] token = DataPure.Instance.User.First_name.Split(' ');
                if (token != null)
                {
                    foreach (string item in token)
                    {
                        avatarString += String.Format("{0}", item[0]).ToUpper();
                    }
                }
            }
            // Turn off login menu
            this.toolStripMenuItemLogin.Enabled = false;
            this.toolStripMenuItemLogout.Enabled = true;
            // Update button enable
            btnCreateOrder.Enabled    = DataPure.Instance.IsAccountingAgentRole();
            btnOrderList.Enabled      = DataPure.Instance.IsAccountingAgentRole();
            btnCreateCustomer.Enabled = DataPure.Instance.IsAccountingAgentRole();
            CommonProcess.RequestTempData(reqTempDataProgressChanged, reqTempDataCompleted);
            pbxAvatar.Image = CommonProcess.CreateAvatar(avatarString, pbxAvatar.Size.Height);
        }
        /// <summary>
        /// Request temp data completed event handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void reqTempDataCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + "Hủy";
            }
            else if (e.Error != null)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + e.Error.Message;
            }
            else
            {
                //toolStripStatusLabel.Text = Properties.Resources.RequestTempDataSuccess;
                toolStripStatusLabel.Text = Properties.Resources.AnalyzingTempData;
                toolStripProgressBarReqServer.Value = 0;
                reqTempDataCompleted(e);
            }
        }
        /// <summary>
        /// Request temp data completed event handler.
        /// </summary>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        /// <param name="isNotFirstTime">True if request temp data in the first time, False otherwise</param>
        private void reqTempDataCompleted(UploadValuesCompletedEventArgs e, bool isNotFirstTime = false)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            byte[] response = e.Result;
            string respStr = String.Empty;
            respStr = System.Text.Encoding.UTF8.GetString(response);

            if (!String.IsNullOrEmpty(respStr))
            {
                timer.Stop();
                Console.WriteLine("Time elapsed [respStr = System.Text.Encoding.UTF8.GetString(response);]:\t{0}", timer.ElapsedMilliseconds);
                timer.Restart();
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(TempDataResponseModel));
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
                timer.Stop();
                Console.WriteLine("Time elapsed [encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);]:\t{0}", timer.ElapsedMilliseconds);
                timer.Restart();
                if (encodingBytes != null)
                {
                    MemoryStream msU = new MemoryStream(encodingBytes);
                    TempDataResponseModel baseResp = (TempDataResponseModel)js.ReadObject(msU);
                    toolStripStatusLabel.Text = Properties.Resources.AnalyzeTempDataDone;
                    timer.Stop();
                    Console.WriteLine("Time elapsed [js.ReadObject(msU);]:\t{0}", timer.ElapsedMilliseconds);
                    timer.Restart();
                    if ((baseResp != null)
                        && (baseResp.Record != null))
                    {
                        List<SelectorModel> listEmployee = null;
                        // Update data
                        if (isNotFirstTime)
                        {
                            listEmployee = new List<SelectorModel>(DataPure.Instance.TempData.Employee_maintain);
                        }
                        DataPure.Instance.TempData = baseResp.Record;
                        timer.Stop();
                        Console.WriteLine("Time elapsed [DataPure.Instance.TempData = baseResp.Record;]:\t{0}", timer.ElapsedMilliseconds);
                        timer.Restart();
                        DataPure.Instance.TempData.Sort();
                        // Update data
                        if (isNotFirstTime)
                        {
                            if (listEmployee != null)
                            {
                                DataPure.Instance.TempData.Employee_maintain = listEmployee.ToArray();
                            }
                        }
                        else
                        {
                            // Get temp data
                            DataPure.Instance.Agent = new AgentModel(DataPure.Instance.TempData.Agent_id,
                                DataPure.Instance.TempData.Agent_name, string.Empty,
                                DataPure.Instance.TempData.Agent_phone,
                                DataPure.Instance.TempData.Agent_address,
                                DataPure.Instance.TempData.Agent_province,
                                DataPure.Instance.TempData.Agent_district);
                        }
                        timer.Stop();
                        Console.WriteLine("Time elapsed [DataPure.Instance.TempData.Sort();]:\t{0}", timer.ElapsedMilliseconds);
                    }
                }
            }
            // Get temp data
            if (!isNotFirstTime)
            {
                // Select agent if user role is Accounting agent
                if (DataPure.Instance.User.Role.Equals(RoleType.ROLE_ACCOUNTING_AGENT))
                {
                    SelectAgent();
                }
                ReLocateLabel();
            }
            // Update address data
            if (DataPure.Instance.User.Role.Equals(RoleType.ROLE_ACCOUNTING_AGENT))
            {
                if (DataPure.Instance.TempData != null)
                {
                    foreach (ChannelControl item in this.listChannelControl)
                    {
                        item.SetCity(DataPure.Instance.GetListCities());
                        item.SetStreet(DataPure.Instance.GetListStreets());
                    }
                }
            }
        }
        /// <summary>
        /// Request temp data progress changed event handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void reqTempDataProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            //if ((e.ProgressPercentage <= 50)
            if ((e.ProgressPercentage <= 100)
                && (e.ProgressPercentage >= 0))
            {
                //toolStripProgressBarReqServer.Value = e.ProgressPercentage * 2;
                toolStripProgressBarReqServer.Value = e.ProgressPercentage;
            }
            toolStripStatusLabel.Text = Properties.Resources.RequestingTempData;
        }
        /// <summary>
        /// Re-locate label.
        /// </summary>
        private void ReLocateLabel()
        {
            int leftBound = pbxAvatar.Left - 5;
            lblUsername.Text = DataPure.Instance.User.First_name;
            if (lblUsername.Right > leftBound)
            {
                lblUsername.Left = leftBound - lblUsername.Width;
            }
            lblRole.Text = DataPure.Instance.User.RoleStr;
            if (lblRole.Right > leftBound)
            {
                lblRole.Left = leftBound - lblRole.Width;
            }
            if (DataPure.Instance.Agent != null)
            {
                lblAgent.Text = DataPure.Instance.Agent.Name;
                if (lblAgent.Right > leftBound)
                {
                    lblAgent.Left = leftBound - lblAgent.Width;
                }
            }
        }
        /// <summary>
        /// Select agent.
        /// </summary>
        private void SelectAgent()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            // Check null object
            if (DataPure.Instance.TempData != null)
            {
                // Check null object
                if (DataPure.Instance.TempData.Agent_list != null)
                {
                    // Create list selector from Agents list
                    List<SelectorModel> listSelector = new List<SelectorModel>();
                    foreach (SelectorModel item in DataPure.Instance.TempData.Agent_list)
                    {
                        listSelector.Add(new SelectorModel
                        {
                            Id     = item.Id,                   // Id
                            Name   = item.Name,                 // Name
                            Detail = string.Empty,              // Empty
                        });
                    }
                    // Sort list agents
                    listSelector.Sort();
                    SelectorView selectorView = new SelectorView();
                    // Set data
                    selectorView.ListData     = listSelector;
                    // Set title
                    selectorView.Text         = Properties.Resources.SelectorTitleAgent;
                    // Set header text
                    selectorView.SetHeaderText(SelectorColumns.SELECTOR_COLUMN_ADDRESS, string.Empty);
                    // Set default selection
                    selectorView.SetSelection(DataPure.Instance.TempData.Agent_id);
                    timer.Stop();
                    Console.WriteLine("Time elapsed [selectorView.ShowDialog();]:\t{0}", timer.ElapsedMilliseconds);
                    // Show dialog
                    selectorView.ShowDialog();
                    // Get selection id
                    string selectorId = selectorView.SelectedId;
                    if (!String.IsNullOrEmpty(selectorId))
                    {
                        // If user select another choice
                        if (!selectorId.Equals(DataPure.Instance.TempData.Agent_id))
                        {
                            // Request agent information from server
                            CommonProcess.RequestAgentInformation(selectorId);
                            // Updaate agent id
                            DataPure.Instance.TempData.Agent_id = selectorId;
                            // Search in agent list and save into [DataPure.Instance.Agent]
                            foreach (SelectorModel item in DataPure.Instance.TempData.Agent_list)
                            {
                                if (selectorId.Equals(item.Id))
                                {
                                    DataPure.Instance.Agent                = new AgentModel(item);
                                    DataPure.Instance.Agent.Phone          = DataPure.Instance.TempData.Agent_phone;
                                    DataPure.Instance.Agent.Address        = DataPure.Instance.TempData.Agent_address;
                                    DataPure.Instance.Agent.Agent_province = DataPure.Instance.TempData.Agent_province;
                                    DataPure.Instance.Agent.Agent_district = DataPure.Instance.TempData.Agent_district;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        // User not choose any agent
                        DialogResult result = CommonProcess.ShowInformMessage(
                            Properties.Resources.YouMustSelectAnAgent, MessageBoxButtons.RetryCancel);
                        if (result.Equals(DialogResult.Retry))
                        {
                            SelectAgent();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Logout handle.
        /// </summary>
        private void Logout()
        {
            // Turn on login menus
            this.toolStripMenuItemLogin.Enabled  = true;
            this.toolStripMenuItemLogout.Enabled = false;
            // Reset token
            Properties.Settings.Default.UserToken = String.Empty;
            Properties.Settings.Default.Save();
            // Reset label content and position
            lblUsername.Text = Properties.Resources.Name;
            lblUsername.Left = Properties.Settings.Default.NameLabelPosX;
            lblRole.Text     = Properties.Resources.Role;
            lblRole.Left     = Properties.Settings.Default.RoleLabelPosX;
            lblAgent.Text    = Properties.Resources.Agent;
            lblAgent.Left    = Properties.Settings.Default.AgentLabelPosX;
            // Update button enable
            btnCreateOrder.Enabled    = false;
            btnOrderList.Enabled      = false;
            btnCreateCustomer.Enabled = false;
            DataPure.Instance.Agent = null;
        }
        /// <summary>
        /// Handle list order
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnOrderList_Click(object sender, EventArgs e)
        {
            HandleClickListOrderButton();
        }

        /// <summary>
        /// Handle when click Support menu.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemSupport_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }
        /// <summary>
        /// Handle when click Guideline menu.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemGuideline_Click(object sender, EventArgs e)
        {
            CommonProcess.ShowInformMessageProcessing();
        }
        /// <summary>
        /// Handle when click Update data menu.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemUpdateData_Click(object sender, EventArgs e)
        {
            CommonProcess.RequestTempData(reqTempDataProgressChanged, reqTempDataCompletedMenu);
        }
        /// <summary>
        /// Request temp data completed from menu event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void reqTempDataCompletedMenu(object sender, UploadValuesCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + "Hủy";
            }
            else if (e.Error != null)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + e.Error.Message;
            }
            else
            {
                toolStripStatusLabel.Text = Properties.Resources.RequestTempDataSuccess;
                toolStripProgressBarReqServer.Value = 0;
                reqTempDataCompleted(e, true);
            }
        }
    }
}
