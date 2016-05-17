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
                    if (!Properties.Settings.Default.TestingMode)
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
            int incommingChannel = this.currentChannel;             // Channel incomming index
            // Get channel information
            if (!String.IsNullOrEmpty(model.Channel))
            {
                if (int.TryParse(model.Channel, out n))
                {
                    incommingChannel = n - 1;
                }
            }
            // Get incomming number information
            if (!String.IsNullOrEmpty(model.Phone))
            {
                // Check phone is valid
                if (int.TryParse(model.Phone, out n))
                {
                    // Insert value into current channel
                    try
                    {
                        channel = this.listChannelControl.ElementAt(incommingChannel);
                        // If incomming phone number is changed
                        if (!channel.GetPhone().Equals(model.Phone))
                        {
                            needUpdate = true;
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                    }
                }
            }
            if (needUpdate)
            {
                if (!incommingChannel.Equals(this.currentChannel))
                {
                    this.currentChannel = incommingChannel;
                    // Show up incomming channel
                    if ((this.currentChannel >= 0)
                        && (this.currentChannel < Properties.Settings.Default.ChannelNumber))
                    {
                        this.mainTabControl.SelectedIndex = this.currentChannel;
                    }
                }
                if (channel != null)
                {
                    channel.SetPhone(model.Phone);
                    UpdateData(model.Phone);
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
            this.listChannelControl.Add(this.channelControlLine1);
            this.listChannelControl.Add(this.channelControlLine2);
            this.listChannelControl.Add(this.channelControlLine3);
            this.listChannelControl.Add(this.channelControlLine4);
            this.listChannelControl.Add(this.channelControlLine5);
            this.listChannelControl.Add(this.channelControlLine6);
            this.listChannelControl.Add(this.channelControlLine7);
            this.listChannelControl.Add(this.channelControlLine8);
            // For test
            TurnOnOffTestingMode(Properties.Settings.Default.TestingMode);

            if (Properties.Settings.Default.TestingMode)
            {
                this.channelControlLine2.SetPhone("01869194542");
                this.channelControlLine3.SetPhone("01674816039");
            }
        }
        /// <summary>
        /// Update data to channel tab.
        /// </summary>
        /// <param name="phone">Incomming number</param>
        private void UpdateData(string phone)
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
                    //CommonProcess.ShowInformMessage(Properties.Resources.NewIncommingPhone, MessageBoxButtons.OK);
                    CustomerModel customer = new CustomerModel();
                    customer.Name = "Khách Hàng Mới";
                    SetChannelInformation(channel, customer);
                    break;
                case 1:         // A customer has phone number is match with incomming phone
                    SetChannelInformation(channel, listCustomer.ElementAt(0));
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
                                // Update data to channel
                                SetChannelInformation(channel, customerInfo);
                                break;
                            }
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// Set data to channel tab.
        /// </summary>
        /// <param name="channel">Channel control</param>
        /// <param name="customer">Customer information</param>
        private void SetChannelInformation(ChannelControl channel, CustomerModel customer)
        {
            if ((channel != null) && (customer != null))
            {
                channel.ClearData();
                channel.SetCustomerName(customer.Name);
                channel.SetAddress(customer.Address);
                channel.SetPhoneList(customer.PhoneList);
                channel.SetAgency(customer.AgencyName);
                channel.SetContact(customer.Contact);
                channel.SetCustomerType(customer.CustomerType);
                channel.SetNote(customer.Contact_note);
                channel.SetSaleInfor(customer.Sale_name, customer.Sale_phone);
            }
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
            string phone = this.listChannelControl.ElementAt(this.currentChannel).GetPhone();
            int n = 0;
            // Get incomming number information
            if (!String.IsNullOrEmpty(phone))
            {
                // Check phone is valid
                if (int.TryParse(phone, out n))
                {
                    // Insert value into current channel
                    try
                    {
                        ChannelControl tab = this.listChannelControl.ElementAt(this.currentChannel);
                        tab.SetPhone(phone);
                        // Request server and update data from server
                        UpdateData(phone);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.ArgumentOutOfRange);
                    }
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
    }
}
