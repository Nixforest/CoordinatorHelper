using MainPrj.Model;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class HistoryView : Form
    {
        private List<CallModel> listTodayData = new List<CallModel>();
        private string selectedId = String.Empty;
        //++ BUG0006-SPJ (NguyenPT 20161111) Call history
        /// <summary>
        /// Record player view.
        /// </summary>
        private RecordPlayerView view = null;
        //-- BUG0006-SPJ (NguyenPT 20161111) Call history
        /// <summary>
        /// List of data which search result.
        /// </summary>
        private List<CallModel> listCurrentData = new List<CallModel>();
        /// <summary>
        /// Point of right click.
        /// </summary>
        private Point rightClick;

        /// <summary>
        /// List of data.
        /// </summary>
        public List<CallModel> ListTodayData
        {
            get { return listTodayData; }
            set { listTodayData = value; }
        }

        /// <summary>
        /// Selected id.
        /// </summary>
        public string SelectedId
        {
            get { return selectedId; }
            set { selectedId = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public HistoryView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handle when loading form.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void HistoryView_Load(object sender, EventArgs e)
        {
            btnCreateOrder.Enabled = DataPure.Instance.IsAccountingAgentRole() || DataPure.Instance.IsCoordinatorRole();
            //++ BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
            btnUphold.Enabled = DataPure.Instance.IsAccountingAgentRole();
            //-- BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
            //listData.Sort();
            //for (int i = listData.Count - 1; i >= 0; i--)
            //{
            //    this.listViewHistory.Items.Add(CreateListViewItem(listData[i], listData.Count - i));
            //}
            this.listCurrentData.AddRange(this.listTodayData);
            ReloadListView(this.listCurrentData);
            //++ BUG0089-SPJ (NguyenPT 20161111) Order history
            btnFinish.Visible = DataPure.Instance.IsCoordinatorRole();
            //-- BUG0089-SPJ (NguyenPT 20161111) Order history
        }

        /// <summary>
        /// Handle when item selection change on listview.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewHistory_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.listViewHistory.SelectedItems.Count > 0)
            {
                this.selectedId = this.listViewHistory.Items[0].SubItems[(int)HistoryColumns.HISTORY_COLUMN_TIME].Text;
            }
        }
        /// <summary>
        /// Handle when click button Close
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Handle when click button Open file
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                if (fileDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    try
                    {
                        // Open filestream
                        Stream fileStream = fileDialog.OpenFile();
                        if (fileStream != null)
                        {
                            // Get last index
                            int index = this.listViewHistory.Items.Count;
                            // Local list
                            List<CallModel> listCalls = new List<CallModel>();
                            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CallModel));
                            byte[] encodingBytes = null;
                            // Stream reader
                            StreamReader sr = new StreamReader(fileStream);
                            while (true)
                            {
                                // Read line by line
                                string line = sr.ReadLine();
                                if (line == null)
                                {
                                    // EOF
                                    break;
                                }
                                try
                                {
                                    // Encoding response data
                                    encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(line);
                                }
                                catch (System.Text.EncoderFallbackException)
                                {
                                    CommonProcess.ShowErrorMessage(Properties.Resources.EncodingError);
                                }
                                if (encodingBytes != null)
                                {
                                    MemoryStream msU = new MemoryStream(encodingBytes);
                                    CallModel callModel = (CallModel)js.ReadObject(msU);
                                    // Add to local list
                                    listCalls.Add(callModel);
                                    // Add to member list
                                    //this.listData.Add(callModel);
                                    this.listTodayData.Insert(0, callModel);
                                }
                            }
                            // Show to list view
                            ReloadListView(this.listTodayData);
                            //for (int i = listCalls.Count - 1; i >= 0; i--)
                            //{
                            //    this.listViewHistory.Items.Add(CreateListViewItem(listCalls[i], ++index));
                            //}
                        }
                        // Close stream
                        fileStream.Close();
                    }
                    catch (Exception ex)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// Reload listview.
        /// </summary>
        /// <param name="list">List data</param>
        private void ReloadListView(List<CallModel> list)
        {
            list.Sort();
            this.listViewHistory.Items.Clear();
            int index = 0;
            foreach (CallModel item in list)
            {
                this.listViewHistory.Items.Add(CreateListViewItem(item, ++index));
            }
        }
        /// <summary>
        /// Create list view item from CallModel.
        /// </summary>
        /// <param name="callModel">Call data</param>
        /// <param name="index">Index</param>
        /// <returns>ListViewItem</returns>
        private ListViewItem CreateListViewItem(CallModel callModel, int index)
        {
            ListViewItem item;
            string[] arr = new string[(int)HistoryColumns.HISTORY_COLUMN_NUM];
            arr[(int)HistoryColumns.HISTORY_COLUMN_NO] = String.Format("{0}", index);
            DateTime time;
            // Specify exactly how to interpret the string.
            IFormatProvider culture = System.Globalization.CultureInfo.CurrentCulture;
            if (DateTime.TryParseExact(callModel.Id, Properties.Settings.Default.CallIdFormat,
                culture, System.Globalization.DateTimeStyles.AssumeLocal, out time))
            {
                arr[(int)HistoryColumns.HISTORY_COLUMN_TIME] = String.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}",
                    time.Year,
                    time.Month,
                    time.Day,
                    time.Hour,
                    time.Minute,
                    time.Second);
            }
            arr[(int)HistoryColumns.HISTORY_COLUMN_PHONE] = callModel.Phone;
            arr[(int)HistoryColumns.HISTORY_COLUMN_CHANNEL] = String.Format("{0}", callModel.Channel + 1);
            arr[(int)HistoryColumns.HISTORY_COLUMN_STATUS] = CommonProcess.GetStatusString(callModel.Status);
            //++ BUG0006-SPJ (NguyenPT 20161111) Call history
            //arr[(int)HistoryColumns.HISTORY_COLUMN_HANDLE] = CommonProcess.GetCallTypeString(callModel.Type);
            // Get list of tyle call id
            string[] listTypeCall   = callModel.Type_call.Split(GlobalConst.SPLITER_CHR);
            string typeCall         = string.Empty;
            // Get list of type call string
            foreach (string type in listTypeCall)
            {
                typeCall += DataPure.Instance.GetTypeCallString(type) + GlobalConst.SPLITER_STR;
            }
            // Remove last spliter if need
            if (!string.IsNullOrEmpty(typeCall))
            {
                typeCall = typeCall.Remove(typeCall.Length - 1);
            }
            // Replace spliter by space + spliter
            typeCall = typeCall.Replace(GlobalConst.SPLITER_STR, GlobalConst.SPLITER_SPACE_STR);
            arr[(int)HistoryColumns.HISTORY_COLUMN_HANDLE] = typeCall;
            //-- BUG0006-SPJ (NguyenPT 20161111) Call history

            if (callModel.Customer != null)
            {
                arr[(int)HistoryColumns.HISTORY_COLUMN_NOTE] = callModel.Customer.Contact_note;
                arr[(int)HistoryColumns.HISTORY_COLUMN_CUSTOMER] = String.Format("{0} - {1}",
                    callModel.Customer.Name,
                    callModel.Customer.Address);
            }
            item = new ListViewItem(arr);
            // Miss call
            if (callModel.Status.Equals((int)CardDataStatus.CARDDATA_MISS))
            {
                item.ForeColor = Properties.Settings.Default.ColorMissCallText;
            }
            // Finish item
            if (callModel.IsFinish)
            {
                item.ForeColor = Properties.Settings.Default.ColorFinishCallText;
                item.BackColor = Properties.Settings.Default.ColorFinishCallBackground;
            }
            // Set tag value
            item.Tag = callModel.Id;
            //++ BUG0006-SPJ (NguyenPT 20161111) Call history
            if (!String.IsNullOrEmpty(callModel.Order_id))
            {
                // Mark finish
                item.ForeColor = Properties.Settings.Default.ColorFinishCallText;
                item.BackColor = Properties.Settings.Default.ColorFinishCallBackground;
                // Update data
                for (int i = 0; i < this.listTodayData.Count; i++)
                {
                    if (this.listTodayData[i].Id.Equals(callModel.Id))
                    {
                        this.listTodayData[i].IsFinish = true;
                    }
                }
            }
            //-- BUG0006-SPJ (NguyenPT 20161111) Call history
            return item;
        }
        /// <summary>
        /// Handle when click button finish.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            //++ BUG0089-SPJ (NguyenPT 20161111) Order history
            //HandleFinishItem();
            if (!DataPure.Instance.IsAccountingAgentRole())
            {
                HandleShowOrderHistory();
            }
            //-- BUG0089-SPJ (NguyenPT 20161111) Order history
        }

        //++ BUG0089-SPJ (NguyenPT 20161111) Order history
        /// <summary>
        /// Handle show order history for Coordinator.
        /// </summary>
        private void HandleShowOrderHistory()
        {
            if (this.listViewHistory.SelectedItems.Count > 0)
            {
                string value = this.listViewHistory.SelectedItems[0].Tag.ToString();
                for (int i = 0; i < this.listCurrentData.Count; i++)
                {
                    if (this.listCurrentData[i].Id.Equals(value))
                    {
                        CommonProcess.RequestOrderHistory(this.listCurrentData[i].Customer.Id,
                            orderHistoryProgressChanged, orderHistoryCompleted);
                    }
                }
            }
        }
        /// <summary>
        /// Request order history completed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void orderHistoryCompleted(object sender, System.Net.UploadValuesCompletedEventArgs e)
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
                toolStripProgressBar.Value = 0;
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
                                    OrderHistoryCoordinatorView view = new OrderHistoryCoordinatorView();
                                    view.UpdateData(baseResp);
                                    view.ShowDialog();
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

        private void orderHistoryProgressChanged(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }
        //-- BUG0089-SPJ (NguyenPT 20161111) Order history

        /// <summary>
        /// Mark item is finish.
        /// </summary>
        private void HandleFinishItem()
        {
            //Stopwatch timer = new Stopwatch();
            //timer.Start();
            // Has a row is selected
            if (this.listViewHistory.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.listViewHistory.SelectedItems)
                {
                    string id = item.Tag.ToString();
                    // Mark finish
                    item.ForeColor = Properties.Settings.Default.ColorFinishCallText;
                    item.BackColor = Properties.Settings.Default.ColorFinishCallBackground;
                    // Update data
                    for (int i = 0; i < this.listTodayData.Count; i++)
                    {
                        if (this.listTodayData[i].Id.Equals(id))
                        {
                            this.listTodayData[i].IsFinish = true;
                        }
                    }
                }
            }
            //timer.Stop();
            //CommonProcess.ShowInformMessage(String.Format("Time elapsed: {0}", timer.Elapsed), MessageBoxButtons.OK);
        }
        /// <summary>
        /// Handle when double click on item list view
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewHistory_DoubleClick(object sender, EventArgs e)
        {
            CustomerView customerView = new CustomerView();
            CallModel callModel = null;
            if (this.listViewHistory.SelectedItems.Count > 0)
            {
                string value = this.listViewHistory.SelectedItems[0].Tag.ToString();
                for (int i = 0; i < this.listCurrentData.Count; i++)
                {
                    if (this.listCurrentData[i].Id.Equals(value))
                    {
                        callModel = this.listCurrentData[i];
                        customerView.GetChannel().SetIncommingPhone(callModel.Phone);
                        customerView.GetChannel().SetCity(DataPure.Instance.TempData.List_province);
                        customerView.GetChannel().SetStreet(DataPure.Instance.TempData.List_street);
                        CommonProcess.SetChannelInformation(customerView.GetChannel(), callModel.Customer);
                        break;
                    }
                }
            }
            customerView.ShowDialog();
            if (callModel != null)
            {
                CustomerModel data = customerView.GetChannel().Data;
                callModel.Customer.Id               = data.Id;
                callModel.Customer.Name             = data.Name;
                callModel.Customer.Address          = data.Address;
                callModel.Customer.PhoneList        = data.PhoneList;
                callModel.Customer.AgencyName       = data.AgencyName;
                callModel.Customer.CustomerType     = data.CustomerType;
                callModel.Customer.Contact          = data.Contact;
                callModel.Customer.Contact_note     = data.Contact_note;
                callModel.Customer.Sale_name        = data.Sale_name;
                callModel.Customer.Sale_phone       = data.Sale_phone;
                callModel.Customer.Sale_type        = data.Sale_type;
                callModel.Customer.AgencyNearest    = data.AgencyNearest;
                if (this.listViewHistory.SelectedItems.Count == 1)
                {
                    ListViewItem listViewItem = this.listViewHistory.SelectedItems[0];
                    listViewItem.SubItems[(int)HistoryColumns.HISTORY_COLUMN_NOTE].Text = data.Contact_note;
                    listViewItem.SubItems[(int)HistoryColumns.HISTORY_COLUMN_CUSTOMER].Text = string.Format("{0} - {1}", data.Name, data.Address);
                }
            }
        }
        /// <summary>
        /// Handle press key on window
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void HistoryView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    this.Close();
                    break;
                case Keys.Enter:
                    if (tbxSearch.Focused)
                    {
                        this.SearchByKeyword(this.tbxSearch.Text.Trim());
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Search keyword in listview.
        /// </summary>
        /// <param name="keyword">Keyword</param>
        private void SearchByKeyword(string keyword)
        {
            this.listCurrentData.Clear();
            keyword = CommonProcess.NormalizationString(keyword).ToLower();
            // Result when search with keyword
            List<CallModel> listResult = new List<CallModel>();
            // Get number of days
            int dayNum = (dtpFilterTo.Value - dtpFilterFrom.Value).Days;
            // Get From value
            DateTime from = dtpFilterFrom.Value;
            // Loop for all dates
            for (int i = 0; i <= dayNum; i++)
            {
                from = dtpFilterFrom.Value.AddDays(i);
                DateTime today = System.DateTime.Now;
                if ((from.Year == today.Year) && (from.Month == today.Month) && (from.Day == today.Day))
                {
                    if (!String.IsNullOrEmpty(keyword))
                    {
                        foreach (CallModel item in this.listTodayData)
                        {
                            if (item.IsContainString(keyword))
                            {
                                listResult.Add(item);
                            }
                        }
                    }
                    else
                    {
                        listResult.AddRange(this.listTodayData);
                    }
                }
                else
                {
                    listResult.AddRange(CommonProcess.ReadHistoryByDate(from));
                }
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                foreach (CallModel item in listResult)
                {
                    if (item.IsContainString(keyword))
                    {
                        this.listCurrentData.Add(item);
                    }
                }
            }
            else
            {
                this.listCurrentData.AddRange(listResult);
            }
            //listDataSearch.Sort();
            //this.listViewHistory.Items.Clear();
            //for (int i = this.listDataSearch.Count - 1; i >= 0; i--)
            //{
            //    this.listViewHistory.Items.Add(CreateListViewItem(this.listDataSearch[i], this.listDataSearch.Count - i));
            //}
            ReloadListView(listCurrentData);
        }
        /// <summary>
        /// Handle when enter focus on Search textbox.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (this.tbxSearch.Text.Equals(Properties.Resources.SearchString))
            {
                this.tbxSearch.Text = string.Empty;
                this.tbxSearch.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Handle when lost focus on Search textbox.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbxSearch.Text.Trim()))
            {
                this.tbxSearch.Text = Properties.Resources.SearchString;
                this.tbxSearch.ForeColor = SystemColors.GrayText;
            }
        }
        /// <summary>
        /// Clear search process.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxSearch.Text = Properties.Resources.SearchString;
            tbxSearch.ForeColor = SystemColors.GrayText;
            //dtpFilterFrom.Value = System.DateTime.Now;
            //SearchByKeyword(String.Empty);
            this.listCurrentData.Clear();
            //this.listViewHistory.Items.Clear();
            //for (int i = listData.Count - 1; i >= 0; i--)
            //{
            //    this.listViewHistory.Items.Add(CreateListViewItem(listData[i], listData.Count - i));
            //}
            int dayNum = (dtpFilterTo.Value - dtpFilterFrom.Value).Days;
            DateTime from = dtpFilterFrom.Value;
            for (int i = 0; i <= dayNum; i++)
            {
                from = dtpFilterFrom.Value;
                this.listCurrentData.AddRange(CommonProcess.ReadHistoryByDate(from.AddDays(i)));
            }
            ReloadListView(this.listCurrentData);
        }
        /// <summary>
        /// Handle when click on Listview
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void listViewHistory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                rightClick = e.Location;
                foreach (ListViewItem item in this.listViewHistory.Items)
                {
                    if (item.Bounds.Contains(e.Location))
                    {
                        this.contextMenuStrip.Show(Cursor.Position);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Handle copy phone
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemCopyPhone_Click(object sender, EventArgs e)
        {
            string phone = string.Empty;
            foreach (ListViewItem item in this.listViewHistory.Items)
            {
                if (item.Bounds.Contains(rightClick))
                {
                    phone = item.SubItems[(int)HistoryColumns.HISTORY_COLUMN_PHONE].Text;
                    break;
                }
            }
            Clipboard.SetText(phone);
        }
        /// <summary>
        /// Handle finish item.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void toolStripMenuItemMarkFinish_Click(object sender, EventArgs e)
        {
            HandleFinishItem();
        }
        /// <summary>
        /// Handle click button CreateOrder.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (this.listViewHistory.SelectedItems.Count > 0)
            {
                string id = this.listViewHistory.SelectedItems[0].Tag.ToString();
                foreach (CallModel callModel in this.listCurrentData)
                {
                    if (callModel.Id.Equals(id))
                    {
                        //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                        //DataPure.Instance.CustomerInfo = callModel.Customer;
                        // Check if customer name is empty
                        //if ((DataPure.Instance.CustomerInfo != null)
                        //    && (!String.IsNullOrEmpty(DataPure.Instance.CustomerInfo.Name)))
                        if ((callModel.Customer != null)
                            && (!String.IsNullOrEmpty(callModel.Customer.Name)))
                        //-- BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                        {
                            CustomerModel customerInfo = new CustomerModel(callModel.Customer);
                            RoleType role = DataPure.Instance.GetUserRole();

                            switch (role)
                            {
                                case RoleType.ROLE_ACCOUNTING_AGENT:
                                case RoleType.ROLE_ACCOUNTING_ZONE:
                                    //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                                    //OrderView order = new OrderView(DataPure.Instance.CustomerInfo);
                                    OrderView order = new OrderView(callModel.Customer);
                                    //-- BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                                    order.ShowDialog();
                                    //++ BUG0006-SPJ (NguyenPT 20161111) Call history
                                    if (!String.IsNullOrEmpty(order.OrderId))
                                    {
                                        DataPure.Instance.UpdateOrderIdToCallModel(id, order.OrderId);
                                    }
                                    //-- BUG0006-SPJ (NguyenPT 20161111) Call history
                                    break;
                                case RoleType.ROLE_DIEU_PHOI:
                                    OrderCoordinatorView view = new OrderCoordinatorView();
                                    DialogResult result = view.ShowDialog();
                                    if (result.Equals(DialogResult.OK))
                                    {
                                        string note = view.Note;
                                        //string note = view.Note +" - ĐT: " + customerInfo.ActivePhone;
                                        if (!String.IsNullOrEmpty(note))
                                        {
                                            //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                                            //SelectAgent(note);
                                            //SelectAgent(note, callModel.Customer);
                                            SelectAgent(note + " - ĐT: " + customerInfo.ActivePhone, customerInfo);
                                            //-- BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                                        }
                                        else
                                        {
                                            CommonProcess.ShowErrorMessage(Properties.Resources.NotSelectMaterial);
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
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Select agent for create order.
        /// </summary>
        /// <param name="note">Note</param>
        //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
        //private void SelectAgent(string note)
        private void SelectAgent(string note, CustomerModel customerInfo)
        //-- BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
        {
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
            //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
            //selectorView.SetSelection(DataPure.Instance.CustomerInfo.Agent_id);
            selectorView.SetSelection(customerInfo.Agent_id);
            //-- BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
            // Show dialog
            selectorView.ShowDialog();
            string selectorId = selectorView.SelectedId;
            if (!String.IsNullOrEmpty(selectorId))
            {
                DialogResult result = CommonProcess.ShowInformMessage(
                    String.Format(Properties.Resources.CreatingOrder,
                    //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                        //DataPure.Instance.CustomerInfo.Name, note, DataPure.Instance.GetAgentNameById(selectorId),),
                        customerInfo.Name, note, DataPure.Instance.GetAgentNameById(selectorId), customerInfo.ActivePhone),
                    //-- BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                    MessageBoxButtons.OKCancel);
                if (result.Equals(DialogResult.OK))
                {
                    //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                    //CommonProcess.RequestCreateOrderCoordinator(selectorId, DataPure.Instance.CustomerInfo.Id, note,
                    CommonProcess.RequestCreateOrderCoordinator(selectorId, customerInfo.Id, note,
                    //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                        createOrderProgressChanged, createOrderCompleted);
                }
            }
            else
            {
                // User not choose any agent
                DialogResult result = CommonProcess.ShowInformMessage(
                    Properties.Resources.YouMustSelectAnAgent, MessageBoxButtons.RetryCancel);
                if (result.Equals(DialogResult.Retry))
                {
                    //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                    //SelectAgent(note);
                    SelectAgent(note, customerInfo);
                    //++ BUG0065-SPJ (NguyenPT 20160901) Use callMode.Customer instead of DataPure.Instance.CustomerInfo
                }
            }
        }
        /// <summary>
        /// Create order completed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void createOrderCompleted(object sender, System.Net.UploadValuesCompletedEventArgs e)
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
                            // Success
                            if (baseResp.Status.Equals("1"))
                            {
                                string id = baseResp.Id;
                                if (!String.IsNullOrEmpty(id))
                                {
                                    if (this.listViewHistory.SelectedItems.Count > 0)
                                    {
                                        string callId = this.listViewHistory.SelectedItems[0].Tag.ToString();
                                        foreach (CallModel callModel in this.listCurrentData)
                                        {
                                            if (callModel.Id.Equals(callId))
                                            {
                                                DataPure.Instance.UpdateOrderIdToCallModel(callId, baseResp.Id);
                                            }
                                        }
                                    }
                                    toolStripStatusLabel.Text = Properties.Resources.CreateOrderSuccess;
                                    CommonProcess.ShowInformMessage(Properties.Resources.CreateOrderSuccess, MessageBoxButtons.OK);
                                }
                            }
                            else                            // Failed
                            {
                                if (baseResp.Code.Equals("1987"))
                                {
                                    CommonProcess.ShowInformMessage(Properties.Resources.CreateOrderServerError1987, MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            CommonProcess.ShowInformMessage(Properties.Resources.CreateOrderServerError, MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Create order progress changed.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void createOrderProgressChanged(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            //if ((e.ProgressPercentage <= 50) && (e.ProgressPercentage >= 0))
            //{
            //    toolStripProgressBar.Value = e.ProgressPercentage * 2;
            //}
            //toolStripStatusLabel.Text = Properties.Resources.RequestUpdateAgentCellPhone;
            CommonProcess.UpdateProgress(e, Properties.Resources.RequestingCreateOrder,
                toolStripProgressBar, toolStripStatusLabel);
        }
        /// <summary>
        /// Handle when change From value.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void dtpFilterFrom_ValueChanged(object sender, EventArgs e)
        {
            // Check if From value is greater than To value
            if (dtpFilterFrom.Value > dtpFilterTo.Value)
            {
                dtpFilterTo.Value = dtpFilterFrom.Value;
            }
            string keyword = this.tbxSearch.Text.Trim();
            if (this.tbxSearch.Text.Equals(Properties.Resources.SearchString))
            {
                keyword = string.Empty;
            }
            this.SearchByKeyword(keyword);
        }
        /// <summary>
        /// Handle when change To value.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void dtpFilterTo_ValueChanged(object sender, EventArgs e)
        {
            // Check if From value is greater than To value
            if (dtpFilterFrom.Value > dtpFilterTo.Value)
            {
                dtpFilterFrom.Value = dtpFilterTo.Value;
            }
            string keyword = this.tbxSearch.Text.Trim();
            if (this.tbxSearch.Text.Equals(Properties.Resources.SearchString))
            {
                keyword = string.Empty;
            }
            this.SearchByKeyword(keyword);
        }
        //++ BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
        /// <summary>
        /// Handle click Uphold button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnUphold_Click(object sender, EventArgs e)
        {
            if (this.listViewHistory.SelectedItems.Count > 0)
            {
                string id = this.listViewHistory.SelectedItems[0].Tag.ToString();
                foreach (CallModel callModel in this.listCurrentData)
                {
                    if (callModel.Id.Equals(id))
                    {
                        DataPure.Instance.CustomerInfo = callModel.Customer;
                        // Check if customer name is empty
                        if ((DataPure.Instance.CustomerInfo != null)
                            && (!String.IsNullOrEmpty(DataPure.Instance.CustomerInfo.Name)))
                        {
                            RoleType role = DataPure.Instance.GetUserRole();

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
                        break;
                    }
                }
            }
        }

        private void toolStripMenuItemListenRecord_Click(object sender, EventArgs e)
        {
            string id = string.Empty;
            foreach (ListViewItem item in this.listViewHistory.Items)
            {
                if (item.Bounds.Contains(rightClick))
                {
                    id = item.Tag.ToString();
                    break;
                }
            }
            foreach (CallModel item in DataPure.Instance.ListCalls)
            {
                if (item.Id.Equals(id))
                {
                    if (!string.IsNullOrEmpty(item.File_record_name))
                    {
                        view = new RecordPlayerView();
                        view.Path = item.File_record_name;
                        view.Location = rightClick;
                        view.Deactivate += delegate
                        {
                            view.Close();
                        };
                        view.Show();
                    }
                    else
                    {
                        CommonProcess.ShowErrorMessage(GlobalConst.CONTENT00001);
                    }
                    break;
                }
            }
        }

        //++ BUG0006-SPJ (NguyenPT 20161111) Call history
        private void toolStripMenuItemSelectCallType_Click(object sender, EventArgs e)
        {
            string id = string.Empty;
            foreach (ListViewItem item in this.listViewHistory.Items)
            {
                if (item.Bounds.Contains(rightClick))
                {
                    id = item.Tag.ToString();
                    CallModel model = DataPure.Instance.GetCallModelByCallId(id);
                    if (model != null)
                    {
                        SelectCallTypeView view = new SelectCallTypeView(model, model.Type_call);
                        view.ShowDialog();
                        this.ReloadListView(this.listCurrentData);
                    }
                    break;
                }
            }
        }
        //-- BUG0006-SPJ (NguyenPT 20161111) Call history
        //-- BUG0047-SPJ (NguyenPT 20160826) Handle print Uphold
    }
}
