using MainPrj.Model;
using MainPrj.Model.Response;
using MainPrj.Util;
using MainPrj.View;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
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
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
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
        #region Properties
        /// <summary>
        /// Main Udp client.
        /// </summary>
        private UdpClient mainUdp = null;
        /// <summary>
        /// Udp thread.
        /// </summary>
        private Thread udpThread = default(Thread);
        /// <summary>
        /// SIP thread.
        /// </summary>
        private Thread sipThread = default(Thread);
        /// <summary>
        /// Thread listenning data from web.
        /// </summary>
        private Thread listenThread = default(Thread);
        /// <summary>
        /// List of tab control.
        /// </summary>
        private List<ChannelControl> listChannelControl = new List<ChannelControl>();
        /// <summary>
        /// List flag need update title of tab controls.
        /// </summary>
        private bool[] listChannelNeedUpdateTitle = new bool[Properties.Settings.Default.ChannelNumber]; 
        #endregion

        #region Methods
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
            //++ BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
            string packetSIP = CommonProcess.ReadPacketSIPFromSetting();
            bool isStartSIP = false;
            //-- BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
            StartUdpThread();
            //StartListeningThread();
            //++ BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
            if (!string.IsNullOrEmpty(packetSIP))
            {
                if (bool.TryParse(packetSIP, out isStartSIP))
                {
                    if (isStartSIP)
                    {
                        StartSIPThread();
                    }
                }
            }
            //-- BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
            //++ BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
            DataPure.Instance.MainForm = this;
            //-- BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
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
                        selectorModel.Id = customerInfo.Id;
                        selectorModel.Name = customerInfo.Name;
                        selectorModel.Detail = customerInfo.Address;
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

            //++ BUG0070-SPJ (NguyenPT 20160908) Reset data
            this.coordinatorOrderView_v2.Reset();
            //-- BUG0070-SPJ (NguyenPT 20160908) Reset data
            customer.ActivePhone = phone;
            CallModel call = new CallModel(System.DateTime.Now, channelIdx, customer, phone, status);
            //++ BUG0006-SPJ (NguyenPT 20161111) Call history
            ////++ BUG0043-SPJ (NguyenPT 20160822) Fix bug lost all history when program down
            //CommonProcess.WriteHistory(call);
            ////-- BUG0043-SPJ (NguyenPT 20160822) Fix bug lost all history when program down
            //DataPure.Instance.ListCalls.Add(call);
            //++ BUG0085-SPJ (NguyenPT 20161117) Fix bug
            //if (status.Equals((int)CardDataStatus.CARDDATA_HANDLING) || status.Equals((int)CardDataStatus.CARDDATA_MISS))
            if (status.Equals((int)CardDataStatus.CARDDATA_RINGING)
                || status.Equals((int)CardDataStatus.CARDDATA_MISS)
                || status.Equals((int)CardDataStatus.CARDDATA_HANDLING))
            //-- BUG0085-SPJ (NguyenPT 20161117) Fix bug
            {
                CommonProcess.WriteHistory(call);
                DataPure.Instance.ListCalls.Add(call);
                CommonProcess.RequestCreateCallHistory(call);
            }
            CommonProcess.SetChannelInformation(channel, call.Customer);
            channel.CallId = call.Id;
            channel.SetCallTypeOption(call);
            //-- BUG0006-SPJ (NguyenPT 20161111) Call history
            //++ BUG0008-SPJ (NguyenPT 20160830) Order history
            // Request orders history
            if (!string.IsNullOrEmpty(customer.Id))
            {
                CommonProcess.RequestOrderHistory(customer.Id, orderHistoryProgressChanged, orderHistoryCompleted);
            }
            //-- BUG0008-SPJ (NguyenPT 20160830) Order history
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
            chbUpdatePhone.Visible = onoff;
            btnTestNotification.Visible = onoff;

            if (onoff)
            {
                this.channelControlLine2.SetIncommingPhone("01869194542");
                this.channelControlLine3.SetIncommingPhone("01674816039");
                this.channelControlLine4.SetIncommingPhone("0988180386");
                this.chbListenFromCard.Checked = Properties.Settings.Default.ListeningCardMode;
                this.chbUpdatePhone.Checked = Properties.Settings.Default.UpdatePhone;
            }
        }
        /// <summary>
        /// Handle when click Create order button.
        /// </summary>
        //++ BUG0069-SPJ (NguyenPT 20160908) Fix bug select wrong customer information
        //private void HandleClickCreateOrderButton()
        private void HandleClickCreateOrderButton(CustomerModel customerInfo = null)
        {
        //-- BUG0069-SPJ (NguyenPT 20160908) Fix bug select wrong customer information
            DataPure.Instance.CustomerInfo = this.listChannelControl[DataPure.Instance.CurrentChannel].Data;
            //++ BUG0069-SPJ (NguyenPT 20160908) Fix bug select wrong customer information
            if (customerInfo == null)
            {
                customerInfo = new CustomerModel(this.listChannelControl[DataPure.Instance.CurrentChannel].Data);
            }
            //-- BUG0069-SPJ (NguyenPT 20160908) Fix bug select wrong customer information
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
                    case RoleType.ROLE_ACCOUNTING_ZONE:
                        OrderView order = new OrderView(DataPure.Instance.CustomerInfo);
                        order.ShowDialog();
                        //++ BUG0006-SPJ (NguyenPT 20161111) Call history
                        if (!String.IsNullOrEmpty(order.OrderId))
                        {
                            // Update id of order to current call
                            DataPure.Instance.UpdateOrderIdToCallModel(
                                this.listChannelControl[DataPure.Instance.CurrentChannel].CallId,
                                order.OrderId);
                        }
                        //-- BUG0006-SPJ (NguyenPT 20161111) Call history
                        break;
                    case RoleType.ROLE_DIEU_PHOI:
                        //++ BUG0070-SPJ (NguyenPT 20160908) Reset data
                        // Get data from order view
                        string note = string.Empty;
                        //note = coordinatorOrderView_v2.GetData() + " - ĐT: " + customerInfo.ActivePhone;
                        note = coordinatorOrderView_v2.GetData();
                        //-- BUG0070-SPJ (NguyenPT 20160908) Reset data

                        List<SelectorModel> listSelector = new List<SelectorModel>();
                        foreach (SelectorModel item in DataPure.Instance.GetListAgents())
                        {
                            listSelector.Add((SelectorModel)item.Clone());
                        }
                        listSelector.Sort();

                        SelectorView selectorView = new SelectorView();
                        // Set data
                        selectorView.ListData = listSelector;
                        // Set title
                        selectorView.Text = Properties.Resources.SelectorTitleAgent;
                        // Set header text
                        selectorView.SetHeaderText(SelectorColumns.SELECTOR_COLUMN_ADDRESS, string.Empty);
                        // Set default selection
                        //++ BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
                        //selectorView.SetSelection(DataPure.Instance.CustomerInfo.Agent_id);
                        if (!string.IsNullOrEmpty(customerInfo.Customer_delivery_agent_id))
                        {
                            selectorView.SetSelection(customerInfo.Customer_delivery_agent_id);
                        }
                        else
                        {
                            selectorView.SetSelection(customerInfo.Agent_id);
                        }
                        //-- BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
                        // Show dialog
                        selectorView.ShowDialog();
                        string selectorId = selectorView.SelectedId;
                        if (!String.IsNullOrEmpty(selectorId))
                        {
                            //++ BUG0070-SPJ (NguyenPT 20160908) Reset data
                            //string note = string.Empty;
                            //note = coordinatorOrderView.GetData();
                            //++ BUG0063-SPJ (NguyenPT 20160831) Add phone number
                            //note = coordinatorOrderView_v2.GetData()
                            //note = coordinatorOrderView_v2.GetData() + " - ĐT: " + customerInfo.ActivePhone;
                            //++ BUG0070-SPJ (NguyenPT 20160908) Reset data
                            //-- BUG0063-SPJ (NguyenPT 20160831) Add phone number
                            if (!String.IsNullOrEmpty(note))
                            {
                                note += " - ĐT: " + customerInfo.ActivePhone;
                                DialogResult result = CommonProcess.ShowInformMessage(
                                    String.Format(Properties.Resources.CreatingOrder,
                                    //++ BUG0063-SPJ (NguyenPT 20160831) Add phone number
                                        //DataPure.Instance.CustomerInfo.Name, note, DataPure.Instance.GetAgentNameById(selectorId),
                                        //DataPure.Instance.CustomerInfo.ActivePhone),
                                        customerInfo.Name, note, DataPure.Instance.GetAgentNameById(selectorId),
                                        customerInfo.ActivePhone),
                                    //-- BUG0063-SPJ (NguyenPT 20160831) Add phone number
                                    MessageBoxButtons.OKCancel);
                                if (result.Equals(DialogResult.OK))
                                {
                                    CommonProcess.RequestCreateOrderCoordinator(selectorId,
                                        //++ BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
                                        //DataPure.Instance.CustomerInfo.Id, note,
                                        customerInfo.Id, note,
                                        //-- BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
                                        createOrderProgressChanged, createOrderCompleted);
                                }
                            }
                            else
                            {
                                CommonProcess.ShowErrorMessage(Properties.Resources.NotSelectMaterial);
                            }
                        }
                        else
                        {
                            // User not choose any agent
                            DialogResult result = CommonProcess.ShowInformMessage(
                                Properties.Resources.YouMustSelectAnAgent, MessageBoxButtons.RetryCancel);
                            if (result.Equals(DialogResult.Retry))
                            {
                                //++ BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
                                //HandleClickCreateOrderButton();
                                HandleClickCreateOrderButton(customerInfo);
                                //-- BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
                            }
                        }
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
        //++ BUG0081-SPJ (NguyenPT 20160928) Handle double line jump
        private void HandleDoubleLineJump()
        {
            //// Get channel control
            //ChannelControl channel = this.listChannelControl[DataPure.Instance.CurrentChannel];
            //// Customer does not created
            //if (String.IsNullOrEmpty(channel.Data.Name))
            //{
            //    CustomerModel newInfo = new CustomerModel();
            //    List<String> customerInfo = channel.GetNewCustomerInfo();
            //    newInfo.ActivePhone = channel.GetIncommingPhone();
                
            //    if (String.IsNullOrEmpty(customerInfo[0]))
            //    {
            //        newInfo.Name = Properties.Resources.CustomerNameUnknown;
            //    }
            //    else
            //    {
            //        newInfo.Name = customerInfo[0];
            //    }
            //    newInfo.Address = channel.GetAddress();
            //    channel.SetChannelInformation(newInfo);
            //    //this.listChannelControl[DataPure.Instance.CurrentChannel].SaveNote(this.listChannelControl[DataPure.Instance.CurrentChannel].GetFullInformation());

            //}
            this.listChannelControl[DataPure.Instance.CurrentChannel].SaveNote(this.listChannelControl[DataPure.Instance.CurrentChannel].GetFullInformation());
        }
        //-- BUG0081-SPJ (NguyenPT 20160928) Handle double line jump
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
                    //++ BUG0040-SPJ (NguyenPT 20160822) Disable Create Customer button
                    btnCreateCustomer.Enabled = false;
                    //-- BUG0040-SPJ (NguyenPT 20160822) Disable Create Customer button
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
        /// Handle when click List order button.
        /// </summary>
        private void HandleClickListOrderButton()
        {
            ListOrderView view = new ListOrderView();
            //++ BUG0011-SPJ (NguyenPT 20160822) Add list data to List Order screen
            view.ListTodayData.AddRange(DataPure.Instance.ListOrders);
            //-- BUG0011-SPJ (NguyenPT 20160822) Add list data to List Order screen
            //++ BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
            //view.Show();
            view.ShowDialog();
            //-- BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
        }
        /// <summary>
        /// Handle when click History button.
        /// </summary>
        private void HandleClickHistoryButton()
        {
            //++ BUG0006-SPJ (NguyenPT 20161118) Call history
            CommonProcess.RequestCreateCallHistory();
            //-- BUG0006-SPJ (NguyenPT 20161118) Call history
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
        //-- BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
        /// <summary>
        /// Handle click on Uphold button.
        /// </summary>
        private void HandleClickUpholdButton()
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
                    case RoleType.ROLE_ACCOUNTING_ZONE:
                        UpholdCreateView view = new UpholdCreateView(DataPure.Instance.CustomerInfo);
                        view.ShowDialog();
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
        //-- BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
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
        /// Update status content.
        /// </summary>
        /// <param name="status">Update status</param>
        private void UpdateStatus(string status)
        {
            toolStripStatusLabel.Text = status;
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
            btnCreateOrder.Enabled = DataPure.Instance.IsAccountingAgentRole() || DataPure.Instance.IsCoordinatorRole();
            //++ BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
            btnUphold.Enabled   = DataPure.Instance.IsAccountingAgentRole();
            btnUphold.Visible   = DataPure.Instance.IsAccountingAgentRole();
            btnSaveData.Enabled = DataPure.Instance.IsCoordinatorRole();
            btnSaveData.Visible = DataPure.Instance.IsCoordinatorRole();
            //-- BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
            btnOrderList.Enabled = DataPure.Instance.IsAccountingAgentRole();
            btnCreateCustomer.Enabled = DataPure.Instance.IsAccountingAgentRole();
            //coordinatorOrderView.Enabled = DataPure.Instance.IsCoordinatorRole();
            coordinatorOrderView_v2.Visible = DataPure.Instance.IsCoordinatorRole();
            CommonProcess.RequestTempData(reqTempDataProgressChanged, reqTempDataCompleted);
            pbxAvatar.Image = CommonProcess.CreateAvatar(avatarString, pbxAvatar.Size.Height);

            Properties.Settings.Default.IsTabColorChange = DataPure.Instance.IsCoordinatorRole();
            // Save setting
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.IsTabColorChange)
            {
                this.mainTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
                this.mainTabControl.DrawItem += mainTabControl_DrawItem;
            }
            //++ BUG0008-SPJ (NguyenPT 20160830) Order history
            // Reload channel control after login
            foreach (ChannelControl item in this.listChannelControl)
            {
                item.ChannelControl_Load(null, null);
            }
            //-- BUG0008-SPJ (NguyenPT 20160830) Order history
            //WebSocketUtility.StartWebSocket(openSocket, errorSocket, receiveDataSocket, closeSocket);
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

        //++ BUG0045-SPJ (NguyenPT 20160823) Update agent info
        /// <summary>
        /// Update new agent information from server.
        /// </summary>
        /// <param name="agentId">Agent id</param>
        private void UpdateAgentInfo(string agentId)
        {
            // Request agent information from server
            CommonProcess.RequestAgentInformation(agentId);
            // Updaate agent id
            DataPure.Instance.TempData.Agent_id = agentId;
            // Search in agent list and save into [DataPure.Instance.Agent]
            foreach (SelectorModel item in DataPure.Instance.GetListAgents())
            {
                if (agentId.Equals(item.Id))
                {
                    DataPure.Instance.Agent = new AgentModel(item);
                    DataPure.Instance.Agent.Phone = DataPure.Instance.TempData.Agent_phone;
                    DataPure.Instance.Agent.Address = DataPure.Instance.TempData.Agent_address;
                    DataPure.Instance.Agent.Agent_province = DataPure.Instance.TempData.Agent_province;
                    DataPure.Instance.Agent.Agent_district = DataPure.Instance.TempData.Agent_district;
                    DataPure.Instance.Agent.Agent_cell_phone = DataPure.Instance.TempData.Agent_cell_phone;
                    break;
                }
            }
        }
        //-- BUG0045-SPJ (NguyenPT 20160823) Update agent info
        //++ BUG0053-SPJ (NguyenPT 20160823) Check record device
        /// <summary>
        /// Check if agent use zibo record card, change port and restart thread.
        /// </summary>
        private void CheckRecordDevice()
        {
            // Check if agent use zibo record card
            if (CommonProcess.AGENT_LIST_ZIBO.Contains(DataPure.Instance.Agent.Id)
                //if (CommonProcess.AGENT_LIST_ZIBO.Any(str => str.Contains(DataPure.Instance.Agent.Id))
                && (Properties.Settings.Default.UdpMainPort != Properties.Settings.Default.ZiboUdpPort))
            {
                Properties.Settings.Default.UdpMainPort = Properties.Settings.Default.ZiboUdpPort;
                Properties.Settings.Default.Save();
                //CommonProcess.ShowInformMessage(Properties.Resources.RestartProgram, MessageBoxButtons.OK);
                StopUdpThread();
                StartUdpThread();
            }
        }
        //-- BUG0053-SPJ (NguyenPT 20160823) Check record device
        /// <summary>
        /// Select agent.
        /// </summary>
        private void SelectAgent()
        {
            //++ BUG0045-SPJ (NguyenPT 20160823) Update agent info
            string agentId = CommonProcess.ReadAgentIdFromSetting();
            if (!string.IsNullOrEmpty(agentId) && CommonProcess.IsValidAgentId(agentId))
            {
                // If user select another choice
                if (!agentId.Equals(DataPure.Instance.TempData.Agent_id))
                {
                    UpdateAgentInfo(agentId);
                }
                CheckRecordDevice();
                return;
            }
            //-- BUG0045-SPJ (NguyenPT 20160823) Update agent info
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
                            Id = item.Id,                   // Id
                            Name = item.Name,                 // Name
                            Detail = string.Empty,              // Empty
                        });
                    }
                    // Sort list agents
                    listSelector.Sort();
                    SelectorView selectorView = new SelectorView();
                    // Set data
                    selectorView.ListData = listSelector;
                    // Set title
                    selectorView.Text = Properties.Resources.SelectorTitleAgent;
                    // Set header text
                    selectorView.SetHeaderText(SelectorColumns.SELECTOR_COLUMN_ADDRESS, string.Empty);
                    // Set default selection
                    selectorView.SetSelection(DataPure.Instance.TempData.Agent_id);
                    // Show dialog
                    selectorView.ShowDialog();
                    // Get selection id
                    string selectorId = selectorView.SelectedId;
                    if (!String.IsNullOrEmpty(selectorId))
                    {
                        // If user select another choice
                        if (!selectorId.Equals(DataPure.Instance.TempData.Agent_id))
                        {
                            //++ BUG0045-SPJ (NguyenPT 20160823) Update agent info
                            //// Request agent information from server
                            //CommonProcess.RequestAgentInformation(selectorId);
                            //// Updaate agent id
                            //DataPure.Instance.TempData.Agent_id = selectorId;
                            //// Search in agent list and save into [DataPure.Instance.Agent]
                            //foreach (SelectorModel item in DataPure.Instance.TempData.Agent_list)
                            //{
                            //    if (selectorId.Equals(item.Id))
                            //    {
                            //        DataPure.Instance.Agent                  = new AgentModel(item);
                            //        DataPure.Instance.Agent.Phone            = DataPure.Instance.TempData.Agent_phone;
                            //        DataPure.Instance.Agent.Address          = DataPure.Instance.TempData.Agent_address;
                            //        DataPure.Instance.Agent.Agent_province   = DataPure.Instance.TempData.Agent_province;
                            //        DataPure.Instance.Agent.Agent_district   = DataPure.Instance.TempData.Agent_district;
                            //        DataPure.Instance.Agent.Agent_cell_phone = DataPure.Instance.TempData.Agent_cell_phone;
                            //        break;
                            //    }
                            //}
                            UpdateAgentInfo(selectorId);
                            //-- BUG0045-SPJ (NguyenPT 20160823) Update agent info
                        }
                        CommonProcess.WriteAgentIdToSetting(selectorId);
                        //++ BUG0053-SPJ (NguyenPT 20160823) Check record device
                        // Check if agent use zibo record card
                        //if (CommonProcess.AGENT_LIST_ZIBO.Contains(DataPure.Instance.Agent.Id)
                        ////if (CommonProcess.AGENT_LIST_ZIBO.Any(str => str.Contains(DataPure.Instance.Agent.Id))
                        //    && (Properties.Settings.Default.UdpMainPort != Properties.Settings.Default.ZiboUdpPort))
                        //{
                        //    Properties.Settings.Default.UdpMainPort = Properties.Settings.Default.ZiboUdpPort;
                        //    Properties.Settings.Default.Save();
                        //    CommonProcess.ShowInformMessage(Properties.Resources.RestartProgram, MessageBoxButtons.OK);
                        //}
                        CheckRecordDevice();
                        //-- BUG0053-SPJ (NguyenPT 20160823) Check record device
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
            this.toolStripMenuItemLogin.Enabled = true;
            this.toolStripMenuItemLogout.Enabled = false;
            // Reset token
            Properties.Settings.Default.UserToken = String.Empty;
            Properties.Settings.Default.Save();
            // Reset label content and position
            lblUsername.Text = Properties.Resources.Name;
            lblUsername.Left = Properties.Settings.Default.NameLabelPosX;
            lblRole.Text = Properties.Resources.Role;
            lblRole.Left = Properties.Settings.Default.RoleLabelPosX;
            lblAgent.Text = Properties.Resources.Agent;
            lblAgent.Left = Properties.Settings.Default.AgentLabelPosX;
            // Update button enable
            btnCreateOrder.Enabled = false;
            btnOrderList.Enabled = false;
            btnCreateCustomer.Enabled = false;
            DataPure.Instance.Agent = null;
            //coordinatorOrderView.Enabled = false;
            coordinatorOrderView_v2.Visible = false;
        }
        #endregion

        #region Event hanlers
        /// <summary>
        /// Handle when click Setting menu.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemSetting_Click(object sender, EventArgs e)
        {
            //++ BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
            string packetSIP = CommonProcess.ReadPacketSIPFromSetting();
            //-- BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
            SettingView setting = new SettingView();
            DialogResult result = setting.ShowDialog();
            //if (result.Equals(DialogResult.OK))
            {
                // For test
                TurnOnOffTestingMode(Properties.Settings.Default.TestingMode);
            }
            //++ BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
            string packetSIPAfter = CommonProcess.ReadPacketSIPFromSetting();
            if (!packetSIP.Equals(packetSIPAfter))
            {
                bool isStartSIP = false;
                if (bool.TryParse(packetSIPAfter, out isStartSIP))
                {
                    if (isStartSIP)
                    {
                        StartSIPThread();
                    }
                    else
                    {
                        StopSIPThread();
                    }
                }
            }
            //-- BUG0074-SPJ (NguyenPT 20160913) Handle turn on/off SIP thread
        }
        /// <summary>
        /// Handle when loading form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //++ BUG0054-SPJ (NguyenPT 20160822) Show version on screen's title
            // Title
            this.Text += String.Format(" - Version {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            //-- BUG0054-SPJ (NguyenPT 20160822) Show version on screen's title
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
            CommonProcess.ReadListOrders();
            CommonProcess.ReadHistory();
            CommonProcess.ReadSetting();
            CommonProcess.ReadSettingPromote();
            
            //++ BUG0086-SPJ (NguyenPT 20161024d Promote money setting
            // Get promote money value from setting.ini
            string promoteMoney = CommonProcess.ReadPromoteMoneyFromSetting();
            // Check if promote money value is not empty
            if (!String.IsNullOrEmpty(promoteMoney))
            {
                // Set default value for output value
                double outValue = Properties.Settings.Default.PromoteMoney;
                // Try parse promote money to double value
                if (double.TryParse(promoteMoney, out outValue))
                {
                    // Parse is success -> Save to Properties.Settings
                    Properties.Settings.Default.PromoteMoney = outValue;
                    Properties.Settings.Default.Save();
                }
            }
            //-- BUG0086-SPJ (NguyenPT 20161024d Promote money setting

            //++ BUG0046-SPJ (NguyenPT 20160824) Login automatically
            // Check if login automatically
            string username = CommonProcess.ReadUsernameFromSetting();
            string pass     = CommonProcess.ReadPasswordFromSetting();
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pass))
            {
                CommonProcess.RequestLogin(
                username, pass, loginProgressChanged, loginCompleted);
            }
            //-- BUG0046-SPJ (NguyenPT 20160824) Login automatically
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
        /// Handle when change tab index.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataPure.Instance.CurrentChannel = this.mainTabControl.SelectedIndex;
            DataPure.Instance.CustomerInfo = this.listChannelControl[this.mainTabControl.SelectedIndex].Data;
            //++ BUG0070-SPJ (NguyenPT 20160908) Reset data
            //this.coordinatorOrderView_v2.Reset();
            //-- BUG0070-SPJ (NguyenPT 20160908) Reset data
        }
        /// <summary>
        /// Handle when click button search.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region Test get customer information
            string phone = this.listChannelControl.ElementAt(DataPure.Instance.CurrentChannel).GetIncommingPhone();
            double n = 0;
            // Get incomming number information
            //if (!String.IsNullOrEmpty(phone) && double.TryParse(phone, out n))
            {
                // Insert value into current channel
                try
                {
                    ChannelControl tab = this.listChannelControl.ElementAt(DataPure.Instance.CurrentChannel);
                    //HandleDoubleLineJump();
                    tab.SetIncommingPhone(phone);
                    // Request server and update data from server
                    UpdateData(phone, (int)CardDataStatus.CARDDATA_HANDLING, DataPure.Instance.CurrentChannel);
                }
                catch (ArgumentOutOfRangeException)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                }
            }
            //PrintData("<CRMV1               0002     2016-08-02 16:15:00                               01689908271                    >                                          172.16.1.64                                       {RAWCID:[0939331371]}{DETAILDES:[]}");
            #endregion
            //_TestServer test = new _TestServer();
            //test.ShowDialog();
            //CommonProcess.GetAgentExt();
            //WebSocketUtility.StartWebSocket(openSocket, errorSocket, receiveDataSocket, closeSocket);

            //SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.notifySound2);
            //simpleSound.PlayLooping();
            //CommonProcess.ShowInformMessage(DataPure.Instance.WebSocket.ReadyState.ToString());
            //CommonProcess.ShowInformMessage(
            //    CommonProcess.GetPhoneFromRecordFilePath(@"C:\REC\REC201610\20161025\01--A-0838964703---20161025090533.wav") + " - "
            //    + CommonProcess.GetFileNameFromRecordFilePath(@"C:\REC\REC201610\20161025\01--A-0838964703---20161025090533.wav"));
            //RecordPlayerView view = new RecordPlayerView();
            ////view.Path = "";
            //view.Location = this.Location;
            //view.Deactivate += delegate
            //{
            //    view.Close();
            //};
            //view.Show();
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
                    //++ BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
                    //HandleClickSaveDataButton();
                    if (DataPure.Instance.IsAccountingAgentRole())
                    {
                        HandleClickUpholdButton();
                    }
                    else if (DataPure.Instance.IsCoordinatorRole())
                    {
                        HandleClickSaveDataButton();
                    }
                    //-- BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
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

                        //++ BUG0062-SPJ (NguyenPT 20160831) Request order history
                        if ((channelControl.Data != null) && (!string.IsNullOrEmpty(channelControl.Data.Id)))
                        {
                            CommonProcess.RequestOrderHistory(channelControl.Data.Id, orderHistoryProgressChanged, orderHistoryCompleted);
                        }
                        //-- BUG0062-SPJ (NguyenPT 20160831) Request order history
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
        private void MainForm_FormClosing(object sender, CancelEventArgs e)
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
            e.Cancel = true;
            base.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Save data.
        /// </summary>
        /// <returns></returns>
        private bool SaveSettingData()
        {
            if (!CommonProcess.WriteHistory(DataPure.Instance.ListCalls))
            {
                return false;
            }
            if (!CommonProcess.WriteListOrders())
            {
                return false;
            }
            Properties.Settings.Default.UserToken = String.Empty;
            Properties.Settings.Default.Save();
            //++ BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
            //CloseWebSocketConnection();
            //-- BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
            return true;
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
                //CommonProcess.RequestLogout();
                CommonProcess.RequestLogout(logoutProgressChanged, logoutCompleted);
            }
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
            //CommonProcess.ShowInformMessageProcessing();

            OrderCarView order = new OrderCarView();
            order.Text = "Hướng dẫn sử dụng";
            order.Show();
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
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + Properties.Resources.Cancel;
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
        /// <summary>
        /// Handle when click on ware house item.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemWareHouse_Click(object sender, EventArgs e)
        {
            WareHouseView view = new WareHouseView();
            view.ShowDialog();
        }
        /// <summary>
        /// Handle when click on Agent phone item.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemAgentPhone_Click(object sender, EventArgs e)
        {
            AgentCellPhoneView view = new AgentCellPhoneView();
            view.ShowDialog();
        }
        /// <summary>
        /// Handle exit application.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            if (SaveSettingData())
            {
                Application.Exit();
                //this.Close();
            }
        }
        /// <summary>
        /// Handle exit application.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (SaveSettingData())
            {
                Application.Exit();
            }
        }
        //++ BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
        /// <summary>
        /// Handle click Uphold button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnUphold_Click(object sender, EventArgs e)
        {
            HandleClickUpholdButton();
        }
        //-- BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold

        //++ BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
        /// <summary>
        /// Handle close connection with web socket event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">CloseEventArgs</param>
        private void closeSocket(object sender, WebSocketSharp.CloseEventArgs e)
        {
            //UpdateStatus(Properties.Resources.ConnectedWithNotifyCenterClosed);
            //CommonProcess.ShowErrorMessage(Properties.Resources.ConnectedWithNotifyCenterClosed);

            // Disable notification button
            SetControlEnable(this.btnNotification, false);
            if (!DataPure.Instance.IsCloseWebSocketConnection)
            {
                StartReconnectWebSocket();
            }
        }

        /// <summary>
        /// Handle data received from web socket.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">MessageEventArgs</param>
        private void receiveDataSocket(object sender, WebSocketSharp.MessageEventArgs e)
        {
            UpdateStatus(Properties.Resources.ConnectedWithNotifyCenterReceivedData + ": " + e.Data);
            // Play sound if user is accounting
            if (DataPure.Instance.IsAccountingAgentRole())
            {
                CommonProcess.NotificationSound.PlayLooping();
            }
            if (!String.IsNullOrEmpty(e.Data))
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NotificationResponseModel));
                byte[] encodingBytes = null;
                try
                {
                    // Encoding response data
                    encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(e.Data);
                }
                catch (System.Text.EncoderFallbackException)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.EncodingError);
                }
                if (encodingBytes != null)
                {
                    MemoryStream msU = new MemoryStream(encodingBytes);
                    NotificationResponseModel baseResp = null;
                    try
                    {
                        baseResp = (NotificationResponseModel)js.ReadObject(msU);
                    }
                    catch (SerializationException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.ConvertJsonError);
                    }
                    if (baseResp != null)
                    {
                        if (baseResp.Status.Equals("1"))
                        {
                            baseResp.Record.IsNew = true;
                            // Check if id is not existed in list notification
                            if (!DataPure.Instance.ListNotification.ContainsKey(baseResp.Record.Id))
                            {
                                DataPure.Instance.ListNotification.Add(baseResp.Record.Id, baseResp.Record);
                            }
                        }
                    }
                }
            }
            SetNotificationLabel(DataPure.Instance.GetNewNotificationCount().ToString());
        }

        /// <summary>
        /// Set control status.
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="isEnable">Enable/Disable</param>
        private void SetControlEnable(Control control, bool isEnable)
        {
            if (control.InvokeRequired)
            {
                CrossThreadUtility.EnableCallBack callback = new CrossThreadUtility.EnableCallBack(
                    SetControlEnable);
                this.Invoke(callback, new object[] { control, isEnable });
            }
            else
            {
                control.Enabled = isEnable;
            }
        }

        /// <summary>
        /// Set text for control (cross-thread).
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="text">Sext</param>
        private void SetControlText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                CrossThreadUtility.SetTextCallBack callback = new CrossThreadUtility.SetTextCallBack(
                    SetControlText);
                this.Invoke(callback, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        /// <summary>
        /// Set label notification.
        /// </summary>
        /// <param name="text">Label content</param>
        public void SetNotificationLabel(string text)
        {
            if (text.Equals("0"))
            {
                SetControlText(this.lblNotification, string.Empty);
            }
            else
            {
                SetControlText(this.lblNotification, text);
            }
        }

        /// <summary>
        /// Handle error connection event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void errorSocket(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            UpdateStatus(Properties.Resources.ConnectedWithNotifyCenterError);
            CommonProcess.ShowErrorMessage(Properties.Resources.ConnectedWithNotifyCenterError);
            // Disable notification button
            SetControlEnable(this.btnNotification, false);
            if (!DataPure.Instance.IsCloseWebSocketConnection)
            {
                StartReconnectWebSocket();
            }
        }

        /// <summary>
        /// Handle open connection event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void openSocket(object sender, EventArgs e)
        {
            UpdateStatus(Properties.Resources.ConnectedWithNotifyCenter);
            //CommonProcess.ShowInformMessage(Properties.Resources.ConnectedWithNotifyCenter, MessageBoxButtons.OK);
            // Enable notification button
            SetControlEnable(this.btnNotification, true);
        }
        //-- BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
        #endregion

        #region Request server handler
        /// <summary>
        /// Handle when finish logout.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void logoutCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
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
                // Logout is success
                toolStripStatusLabel.Text = Properties.Resources.RequestLogoutSuccess;
                DataPure.Instance.User = new UserLoginModel();
                pbxAvatar.Image = CommonProcess.CreateAvatar(string.Empty, pbxAvatar.Size.Height);
                Logout();
                //++ BUG0046-SPJ (NguyenPT 20160824) Login automatically
                CommonProcess.WriteLoginInfoToSetting(string.Empty, string.Empty);
                //-- BUG0046-SPJ (NguyenPT 20160824) Login automatically
            }
        }
        /// <summary>
        /// Handle when logout progress changed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void logoutProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            UpdateProgress(e, Properties.Resources.RequestingLogout);
        }
        /// <summary>
        /// Handle when creating customer.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void createCustomerProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            //if ((e.ProgressPercentage <= 50)
            //    && (e.ProgressPercentage >= 0))
            //{
            //    toolStripProgressBarReqServer.Value = e.ProgressPercentage * 2;
            //}
            //toolStripStatusLabel.Text = Properties.Resources.RequestingCreateCustomer;
            UpdateProgress(e, Properties.Resources.RequestingCreateCustomer);
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
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + Properties.Resources.Cancel;
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
                        //++ BUG0012-SPJ (NguyenPT 20160822) Show message from server
                        //if ((baseResp != null)
                        //    && (baseResp.Status.Equals("1")))
                        //{
                        //    // Create customer is success.
                        //    toolStripStatusLabel.Text = Properties.Resources.CreateCustomerSuccess;
                        //    CommonProcess.ShowInformMessage(Properties.Resources.CreateCustomerSuccess,
                        //        MessageBoxButtons.OK);
                        //    ChannelControl channelControl = null;
                        //    try
                        //    {
                        //        channelControl = this.listChannelControl.ElementAt(DataPure.Instance.CurrentChannel);
                        //    }
                        //    catch (ArgumentOutOfRangeException)
                        //    {
                        //        CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                        //        return;
                        //    }
                        //    if (channelControl != null)
                        //    {
                        //        if (baseResp.Record != null)
                        //        {
                        //            baseResp.Record[0].ActivePhone = channelControl.GetIncommingPhone();
                        //            //CommonProcess.SetChannelInformation(channelControl, baseResp.Record[0]);
                        //            channelControl.SetChannelInformation(baseResp.Record[0]);
                        //        }
                        //    }
                        //}
                        if (baseResp != null)
                        {
                            if (baseResp.Status.Equals("1"))
                            {
                                // Create customer is success.
                                toolStripStatusLabel.Text = Properties.Resources.CreateCustomerSuccess;
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
                                        //CommonProcess.SetChannelInformation(channelControl, baseResp.Record[0]);
                                        channelControl.SetChannelInformation(baseResp.Record[0]);
                                    }
                                }
                            }
                            else
                            {
                                toolStripStatusLabel.Text = baseResp.Message;
                                CommonProcess.ShowErrorMessage(baseResp.Message);
                            }
                        }
                        //-- BUG0012-SPJ (NguyenPT 20160822) Show message from server
                        else
                        {
                            // Create customer is failed.
                            CommonProcess.ShowInformMessage(Properties.Resources.CreateCustomerFailed,
                                MessageBoxButtons.OK);
                        }
                    }
                }
            }
            //++ BUG0040-SPJ (NguyenPT 20160822) Enable Create Customer button
            btnCreateCustomer.Enabled = true;
            //-- BUG0040-SPJ (NguyenPT 20160822) Enable Create Customer button
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
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause
                    + Properties.Resources.Cancel;
            }
            else if (e.Error != null)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + e.Error.Message;
            }
            else
            {
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
                        //++ BUG0052-SPJ (NguyenPT 20160823) Update CCS when change Agent
                        List<SelectorModel> listCCS = null;
                        //-- BUG0052-SPJ (NguyenPT 20160823) Update CCS when change Agent
                        // Update data
                        if (isNotFirstTime)
                        {
                            listEmployee = new List<SelectorModel>(DataPure.Instance.GetListDelivers());
                            //++ BUG0052-SPJ (NguyenPT 20160823) Update CCS when change Agent
                            listCCS = new List<SelectorModel>(DataPure.Instance.GetListCCSs());
                            //-- BUG0052-SPJ (NguyenPT 20160823) Update CCS when change Agent
                        }
                        DataPure.Instance.TempData = baseResp.Record;
                        timer.Stop();
                        Console.WriteLine("Time elapsed [DataPure.Instance.TempData = baseResp.Record;]:\t{0}", timer.ElapsedMilliseconds);
                        timer.Restart();
                        if ((DataPure.Instance.TempData != null) && (DataPure.Instance.TempData.Material_gas != null))
                        {
                            DataPure.Instance.TempData.Material_gas.AddRange(DataPure.Instance.TempData.Material_vo);
                        }
                        DataPure.Instance.TempData.Sort();
                        // Update data
                        if (isNotFirstTime)
                        {
                            if (listEmployee != null)
                            {
                                DataPure.Instance.TempData.Employee_maintain = listEmployee;
                                //++ BUG0052-SPJ (NguyenPT 20160823) Update CCS when change Agent
                                DataPure.Instance.TempData.Monitor_market_development = listCCS;
                                //-- BUG0052-SPJ (NguyenPT 20160823) Update CCS when change Agent
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
                                DataPure.Instance.TempData.Agent_district,
                                DataPure.Instance.TempData.Agent_cell_phone);
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
                if (DataPure.Instance.IsAccountingAgentRole())
                {
                    SelectAgent();
                }
                ReLocateLabel();
                //++ BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
                //StartReconnectWebSocket();
                //-- BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
            }
            // Update address data
            if (DataPure.Instance.IsAccountingAgentRole())
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
            ////if ((e.ProgressPercentage <= 50)
            //if ((e.ProgressPercentage <= 100)
            //    && (e.ProgressPercentage >= 0))
            //{
            //    //toolStripProgressBarReqServer.Value = e.ProgressPercentage * 2;
            //    toolStripProgressBarReqServer.Value = e.ProgressPercentage;
            //}
            //toolStripStatusLabel.Text = Properties.Resources.RequestingTempData;
            UpdateProgress(e, Properties.Resources.RequestingTempData);
        }
        /// <summary>
        /// Created order completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createOrderCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
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
                byte[] response = e.Result;
                string respStr = String.Empty;
                respStr = System.Text.Encoding.UTF8.GetString(response);
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OrderResponseModel));
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
                        OrderResponseModel baseResp = (OrderResponseModel)js.ReadObject(msU);
                        if (baseResp != null)
                        {
                            //++ BUG0006-SPJ (NguyenPT 20161111) Call history
                            // Update id of order to current call (Coordinator)
                            DataPure.Instance.UpdateOrderIdToCallModel(this.listChannelControl[DataPure.Instance.CurrentChannel].CallId, baseResp.Id);
                            //-- BUG0006-SPJ (NguyenPT 20161111) Call history
                            toolStripStatusLabel.Text = baseResp.Message;
                            CommonProcess.ShowInformMessage(baseResp.Message, MessageBoxButtons.OK);
                        }
                        else
                        {
                            CommonProcess.ShowInformMessage(Properties.Resources.CreateOrderServerError, MessageBoxButtons.OK);
                        }
                        //if (baseResp != null && baseResp.Status.Equals("1"))
                        //{
                        //    string id = baseResp.Id;
                        //    if (!String.IsNullOrEmpty(id))
                        //    {
                        //        toolStripStatusLabel.Text = Properties.Resources.CreateOrderSuccess;
                        //        CommonProcess.ShowInformMessage(Properties.Resources.CreateOrderSuccess, MessageBoxButtons.OK);
                        //    }
                        //}
                        //else
                        //{
                        //    CommonProcess.ShowInformMessage(Properties.Resources.CreateOrderServerError, MessageBoxButtons.OK);
                        //}
                    }
                }
            }
        }
        /// <summary>
        /// Create order progress changed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void createOrderProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            //if ((e.ProgressPercentage <= 50) && (e.ProgressPercentage >= 0))
            //{
            //    toolStripProgressBarReqServer.Value = e.ProgressPercentage * 2;
            //}
            //toolStripStatusLabel.Text = Properties.Resources.RequestingCreateOrder;
            UpdateProgress(e, Properties.Resources.RequestingCreateOrder);
        }
        /// <summary>
        /// Update progress bar.
        /// </summary>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        /// <param name="status">Status string</param>
        private void UpdateProgress(UploadProgressChangedEventArgs e, string status)
        {
            CommonProcess.UpdateProgress(e, status, toolStripProgressBarReqServer, toolStripStatusLabel);
        }
        //++ BUG0046-SPJ (NguyenPT 20160824) Login automatically
        /// <summary>
        /// Login completed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void loginCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
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
                toolStripStatusLabel.Text = Properties.Resources.LoginSuccess;
                Properties.Settings.Default.LastUsername = CommonProcess.ReadUsernameFromSetting();
                Properties.Settings.Default.Save();
                toolStripProgressBarReqServer.Value = 0;
                byte[] response = e.Result;
                string respStr = String.Empty;
                respStr = System.Text.Encoding.UTF8.GetString(response);
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
                            UserLoginModel user = new UserLoginModel();
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
                                DataPure.Instance.User = user;
                                if (!String.IsNullOrEmpty(DataPure.Instance.User.First_name))
                                {
                                    Login();
                                }
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
        /// Handle login progress changed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void loginProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            CommonProcess.UpdateProgress(e, Properties.Resources.RequestingLogin,
                toolStripProgressBarReqServer, toolStripStatusLabel);
        }
        //-- BUG0046-SPJ (NguyenPT 20160824) Login automatically
        //++ BUG0008-SPJ (NguyenPT 20160830) Order history
        /// <summary>
        /// Handle after request order history completed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void orderHistoryCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
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
                toolStripStatusLabel.Text = Properties.Resources.RequestOrderHistorySuccess;
                toolStripProgressBarReqServer.Value = 0;
                byte[] response = e.Result;
                string respStr = String.Empty;
                respStr = System.Text.Encoding.UTF8.GetString(response);
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OrderHistoryResponseModel));
                    byte[] encodingBytes = null;
                    try
                    {
                        // Encoding response data
                        encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);
                        if (encodingBytes != null)
                        {
                            MemoryStream msU = new MemoryStream(encodingBytes);
                            OrderHistoryResponseModel baseResp = (OrderHistoryResponseModel)js.ReadObject(msU);
                            if (baseResp != null)
                            {
                                if (baseResp.Status.Equals(GlobalConst.RESPONSE_STATUS_SUCCESS))
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
                                        channelControl.SetHistory(baseResp);
                                    }
                                }
                            }
                        }
                    }
                    catch (System.Text.EncoderFallbackException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.EncodingError);
                    }
                    catch (Exception ex)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                        CommonProcess.HasError = true;
                    }
                }
            }
        }
        /// <summary>
        /// Handle when requesting order history.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void orderHistoryProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            CommonProcess.UpdateProgress(e, Properties.Resources.RequestingOrderHistory,
                toolStripProgressBarReqServer, toolStripStatusLabel);
        }
        //-- BUG0008-SPJ (NguyenPT 20160830) Order history
        #endregion

        #region Tansonic UDP handling
        /// <summary>
        /// Start udp in separate thread.
        /// </summary>
        private void StartUdpThread()
        {
            // Create new Udp client
            try
            {
                mainUdp = new UdpClient(Properties.Settings.Default.UdpMainPort);
                //mainUdp = new UdpClient(new IPEndPoint(IPAddress.Any, Properties.Settings.Default.UdpMainPort));
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
        //++ BUG0053-SPJ (NguyenPT 20160823) Stop Udp thread
        /// <summary>
        /// Stop Udp thread.
        /// </summary>
        private void StopUdpThread()
        {
            if ((udpThread != null) && (udpThread.IsAlive))
            {
                udpThread.Abort();
            }
        }
        //-- BUG0053-SPJ (NguyenPT 20160823) Stop Udp thread
        /// <summary>
        /// Get data from Tansonic card.
        /// </summary>
        private void ConnectWithTansonicCard()
        {
            string recvBuf = String.Empty;
            IPEndPoint remoteHost = new IPEndPoint(IPAddress.Any, 0);
            //IPEndPoint remoteHost = new IPEndPoint(IPAddress.Any, Properties.Settings.Default.UdpMainPort);
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
            double n;
            CardDataModel model = new CardDataModel(data);          // Data model
            bool needUpdate = false;                                // Flag need update UI
            ChannelControl channel = null;                          // Channel incomming
            //++ BUG0006-SPJ (NguyenPT 20161111) Call history
            // Receive record packet
            if (model.Status.Equals((int)CardDataStatus.CARDDATA_RECORD))
            {
                // Get phone number from record file name
                string phone = CommonProcess.GetPhoneFromRecordFilePath(model.Phone);
                // Success
                if (!String.IsNullOrEmpty(phone))
                {
                    // Add record file name to call model
                    foreach (CallModel item in DataPure.Instance.ListCalls)
                    {
                        if (item.Phone.Equals(phone) && item.Channel.Equals(model.Channel))
                        {
                            //item.File_record_name = CommonProcess.GetFileNameFromRecordFilePath(model.Phone);
                            item.File_record_name = model.Phone;
                            CommonProcess.RequestCreateCallHistory(item);
                        }
                    }
                }
                this.tbxLog.Text = data + "\r\n" + this.tbxLog.Text;
                return;
            }
            //-- BUG0006-SPJ (NguyenPT 20161111) Call history
            // Get incomming number information
            if (!String.IsNullOrEmpty(model.Phone))
            {
                // Check phone is valid
                if (double.TryParse(model.Phone, out n))
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
                                //++ BUG0073-SPJ (NguyenPT 20160909) Update tab if user is accounting
                                if (DataPure.Instance.IsAccountingAgentRole())
                                {
                                    needUpdate = true;
                                }
                                //-- BUG0073-SPJ (NguyenPT 20160909) Update tab if user is accounting
                                break;
                            case (int)CardDataStatus.CARDDATA_CALLING:
                                //statusStr = Properties.Resources.CardDataStatus2;
                                break;
                            case (int)CardDataStatus.CARDDATA_HANDLING:
                                FlashWindowHelper.Flash(this.Handle);
                                statusStr = Properties.Resources.CardDataStatus3;
                                color = Color.Blue;
                                //++ BUG0085-SPJ (NguyenPT 20161117) Fix bug
                                //needUpdate = true;
                                if (DataPure.Instance.IsCoordinatorRole())
                                {
                                  needUpdate = true;  
                                }
                                //-- BUG0085-SPJ (NguyenPT 20161117) Fix bug
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
                    // Difference line
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
                    //++ BUG0081-SPJ (NguyenPT 20160928) Handle double line jump
                    else    // Same line
                    {
                        HandleDoubleLineJump();
                    }
                    //-- BUG0081-SPJ (NguyenPT 20160928) Handle double line jump
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
        #endregion

        #region SIP handling
        /// <summary>
        /// Last phone.
        /// </summary>
        private string lastPhone = string.Empty;
        /// <summary>
        /// Start 
        /// </summary>
        private void StartSIPThread()
        {
            // Start thread for read SIP packet
            try
            {
                // Check network device
                CheckAvailableDevice();
                if (DataPure.Instance.NetDevice != null)
                {
                    sipThread = new Thread(CollectingPacket);
                    sipThread.Start();
                    sipThread.IsBackground = true;
                }
                else
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.NotDeviceAvailable);
                    return;
                }
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
        /// Stop SIP thread
        /// </summary>
        private void StopSIPThread()
        {
            if ((sipThread != null) && (sipThread.IsAlive))
            {
                sipThread.Abort();
            }
        }
        /// <summary>
        /// Collect packet data handler.
        /// </summary>
        private void CollectingPacket()
        {
            const string filterStr = "ip and udp";
            if (DataPure.Instance.NetDevice != null)
            {
                try
                {
                    PacketCommunicator communicator = DataPure.Instance.NetDevice.Open(
                        Properties.Settings.Default.BufferLength,
                        PacketDeviceOpenAttributes.Promiscuous,
                        Properties.Settings.Default.NetworkTimeOut);
                    using (BerkeleyPacketFilter filter = communicator.CreateFilter(filterStr))
                    {
                        communicator.SetFilter(filter);
                    }
                    communicator.ReceivePackets(0, PacketHandler);
                }
                catch (Exception ex)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                    return;
                }
            }
        }
        /// <summary>
        /// Check which device use receive SIP packet.
        /// </summary>
        private void CheckAvailableDevice()
        {
            try
            {
                // Get all local device
                IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
                if (allDevices.Count > 0)
                {
                    // Loop through all devices
                    foreach (PacketDevice device in allDevices)
                    {
                        // Open communicator
                        PacketCommunicator communicator = device.Open(
                            Properties.Settings.Default.BufferLength,
                            PacketDeviceOpenAttributes.Promiscuous,
                            Properties.Settings.Default.NetworkTimeOut);
                        Packet packet;
                        // Try to get a packet
                        PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out packet);
                        switch (result)
                        {
                            case PacketCommunicatorReceiveResult.BreakLoop:
                                break;
                            case PacketCommunicatorReceiveResult.Eof:
                                break;
                            case PacketCommunicatorReceiveResult.None:
                                break;
                            case PacketCommunicatorReceiveResult.Ok:        // Get packet is success
                                DataPure.Instance.NetDevice = device;       // Save to DataPure
                                return;
                            case PacketCommunicatorReceiveResult.Timeout:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                return;
            }
        }
        /// <summary>
        /// Handle after receive SIP packet.
        /// </summary>
        /// <param name="packet">SIP packet</param>
        private void PacketHandler(Packet packet)
        {
            IpV4Datagram ip = packet.Ethernet.IpV4;
            UdpDatagram udp = ip.Udp;
            ushort srcPort = udp.SourcePort;
            ushort destPort = udp.DestinationPort;
            string format = "txIP,{0},1,1,{1},End";
            if (srcPort == 5060 || destPort == 5060)
            {
                MemoryStream ms = packet.Ethernet.IpV4.Udp.Payload.ToMemoryStream();
                var sr = new StreamReader(ms);
                string sipTxt = sr.ReadToEnd();
                sr.Close();
                string from = CommonProcess.GetFrom(sipTxt);
                if (CommonProcess.IsRingingPacket(sipTxt))          // Is ringing call?
                {
                    if (!String.IsNullOrEmpty(from))
                    {
                        lastPhone = from;
                        PrintData(String.Format(format, from, (int)CardDataStatus.CARDDATA_RINGING + 1));
                    }
                }
                else if (CommonProcess.IsMissPacket(sipTxt))        // Is miss call?
                {
                    if (!String.IsNullOrEmpty(from))
                    {
                        PrintData(String.Format(format, from, (int)CardDataStatus.CARDDATA_MISS + 1));
                    }
                }
                else if (CommonProcess.IsHandlingPacket(sipTxt))    // Is handling call?
                {
                    if (!String.IsNullOrEmpty(from))
                    {
                        PrintData(String.Format(format, from, (int)CardDataStatus.CARDDATA_HANDLING + 1));
                    }
                }
                else if (CommonProcess.IsHangUpPacket(sipTxt))      // Is hang up call?
                {
                    if (!String.IsNullOrEmpty(from))
                    {
                        PrintData(String.Format(format, from, (int)CardDataStatus.CARDDATA_HANGUP + 1));
                    }
                    else
                    {
                        PrintData(String.Format(format, lastPhone, (int)CardDataStatus.CARDDATA_HANGUP + 1));
                    }
                }
                else if (CommonProcess.IsBusyPacket(sipTxt))        // Is busy call?
                {
                    if (!String.IsNullOrEmpty(from))
                    {
                        PrintData(String.Format(format, from, (int)CardDataStatus.CARDDATA_HANGUP + 1));
                    }
                }
            }
        }
        #endregion

        #region Listening new order
        private void StartListeningThread()
        {
            //// Start thread for listen web
            //try
            //{
            //    listenThread = new Thread(ListenThreadHandler);
            //    listenThread.Start();
            //    listenThread.IsBackground = true;
            //}
            //catch (System.ArgumentNullException)
            //{
            //    this.Close();
            //}
            //catch (System.Threading.ThreadStateException)
            //{
            //    CommonProcess.ShowErrorMessage(Properties.Resources.ThreadStateError);
            //    this.Close();
            //}
            //catch (System.OutOfMemoryException)
            //{
            //    CommonProcess.ShowErrorMessage(Properties.Resources.OutOfMemory);
            //    this.Close();
            //}
        }

        //private void ListenThreadHandler()
        //{
        //    Stopwatch timer = new Stopwatch();
        //    timer.Start();
        //    int count = 0;
        //    while (true)
        //    {
        //        if (timer.ElapsedMilliseconds == 1000)
        //        {
        //            count++;
        //            Console.WriteLine("Đã qua {0}s", count);
        //            timer.Restart();
        //        }
        //    }
        //    timer.Stop();
        //}

        //++ BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
        /// <summary>
        /// Notification view.
        /// </summary>
        private NotificationView view = null;
        /// <summary>
        /// Handle click Notification button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnNotification_Click(object sender, EventArgs e)
        {
            // Get location of notification button
            Point location = this.PointToScreen(btnNotification.Location);
            //
            view = new NotificationView(location.X + btnNotification.Size.Width,
                location.Y);
            view.ListData = DataPure.Instance.ListNotification;
            view.Deactivate += delegate
            {
                view.Close();
            };
            view.Show();
        }

        /// <summary>
        /// Handle click test notification button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnTestNotification_Click(object sender, EventArgs e)
        {
            //int count = DataPure.Instance.GetNewNotificationCount();
            //if (count != 0)
            //{
            //    lblNotification.Text = count.ToString();
            //}
            //else
            //{
            //    lblNotification.Text = string.Empty;
            //}
            //string retVal = string.Empty;
            //using (WebClient client = new WebClient())
            //{
            //    string respStr = String.Empty;
            //    try
            //    {
            //        // Post keyword to server
            //        string value = string.Empty;
            //        value = String.Format("{{\"token\":\"{0}\",\"agent_id\":\"{1}\"}}",
            //            Properties.Settings.Default.UserToken, DataPure.Instance.Agent.Id);
            //            //"3e9d4bbc6eb88773b737a65f6a2d901c", DataPure.Instance.Agent.Id);
            //        byte[] response = client.UploadValues(
            //            @"http://spj.daukhimiennam.com/api/socket/notifyDevTest",
            //            new System.Collections.Specialized.NameValueCollection()
            //        {
            //            { "q", value}
            //        });
            //        // Get response
            //        respStr = System.Text.Encoding.UTF8.GetString(response);
            //    }
            //    catch (System.Net.WebException)
            //    {
            //        CommonProcess.ShowErrorMessage(Properties.Resources.InternetConnectionError);
            //        CommonProcess.HasError = true;
            //    }
            //    if (!String.IsNullOrEmpty(respStr))
            //    {
            //        //CommonProcess.ShowErrorMessage(respStr);
            //    }
            //}
            DataPure.Instance.WebSocket.CloseAsync();
        }
        /// <summary>
        /// Connect with socket server.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemConnect_Click(object sender, EventArgs e)
        {
            //// Object is not null
            //if (DataPure.Instance.WebSocket != null)
            //{
            //    // Status is closed
            //    if (DataPure.Instance.WebSocket.ReadyState.Equals(WebSocketSharp.WebSocketState.Closed))
            //    {
            //        // Reconnect
            //        WebSocketUtility.StartWebSocket(openSocket, errorSocket, receiveDataSocket, closeSocket);
            //    }
            //    else
            //    {
            //        // Show error.
            //        CommonProcess.ShowErrorMessage(Properties.Resources.ConnectionWithNotifyCenterOpened);
            //    }
            //}
            //else    // Object is null
            //{
            //    // Start connect
            //    WebSocketUtility.StartWebSocket(openSocket, errorSocket, receiveDataSocket, closeSocket);
            //}

            CommonProcess.ShowInformMessageFunctionBlocking();
        }
        /// <summary>
        /// Disconnect with socket server.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemDisConnect_Click(object sender, EventArgs e)
        {
            //CloseWebSocketConnection();
            //DataPure.Instance.IsCloseWebSocketConnection = true;

            CommonProcess.ShowInformMessageFunctionBlocking();
        }
        /// <summary>
        /// Close connect.
        /// </summary>
        private void CloseWebSocketConnection()
        {
            if (DataPure.Instance.WebSocket != null)
            {
                DataPure.Instance.WebSocket.CloseAsync(WebSocketSharp.CloseStatusCode.Normal);
            }
        }
        /// <summary>
        /// Start reconnect with web socket.
        /// </summary>
        private void StartReconnectWebSocket()
        {
            try
            {
                listenThread = new Thread(ReconnectWebSocket);
                listenThread.Start();
                listenThread.IsBackground = true;
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
        /// Reconnect with web socket.
        /// </summary>
        /// <param name="obj"></param>
        private void ReconnectWebSocket(object obj)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int count = 0;
            // Get elapsed time
            int elapsedTime = CommonProcess.RECONNECT_WEBSOCKET_MIN_TIME;
            Random rnd = new Random();
            // Random elapsed time between MIN-MAX
            elapsedTime = rnd.Next(CommonProcess.RECONNECT_WEBSOCKET_MIN_TIME, CommonProcess.RECONNECT_WEBSOCKET_MAX_TIME);
            while (true)
            {
                if (timer.ElapsedMilliseconds == elapsedTime * 1000)
                {
                    count++;
                    Console.WriteLine("Đã qua {0}s", count);
                    //timer.Restart();
                    // Start connect
                    WebSocketUtility.StartWebSocket(openSocket, errorSocket, receiveDataSocket, closeSocket);
                    // Stop thread
                    StopReconnectWebSocketThread();
                    return;
                }
            }
        }
        /// <summary>
        /// Stop ReconnectWebSocket thread.
        /// </summary>
        private void StopReconnectWebSocketThread()
        {
            if ((listenThread != null) && (listenThread.IsAlive))
            {
                listenThread.Abort();
            }
        }
        //-- BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
        #endregion
    }
}
