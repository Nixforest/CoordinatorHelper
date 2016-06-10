using MainPrj.Model;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class HistoryView : Form
    {
        /// <summary>
        /// List of data.
        /// </summary>
        private List<CallModel> listData = new List<CallModel>();
        /// <summary>
        /// List of data which search result.
        /// </summary>
        private List<CallModel> listDataSearch = new List<CallModel>();

        public List<CallModel> ListData
        {
            get { return listData; }
            set { listData = value; }
        }
        private Point rightClick;
        /// <summary>
        /// Selected id.
        /// </summary>
        private string selectedId = String.Empty;

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
            for (int i = listData.Count - 1; i >= 0; i--)
            {
                this.listViewHistory.Items.Add(CreateListViewItem(listData[i], listData.Count - i));
            }
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
                                    this.listData.Insert(0, callModel);
                                }
                            }
                            // Show to list view
                            for (int i = listCalls.Count - 1; i >= 0; i--)
                            {
                                this.listViewHistory.Items.Add(CreateListViewItem(listCalls[i], ++index));
                            }
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
            arr[(int)HistoryColumns.HISTORY_COLUMN_HANDLE] = CommonProcess.GetCallTypeString(callModel.Type);
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
            return item;
        }
        /// <summary>
        /// Handle when click button finish.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            HandleFinishItem();
        }
        /// <summary>
        /// Mark item is finish.
        /// </summary>
        private void HandleFinishItem()
        {
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
                    for (int i = 0; i < this.listData.Count; i++)
                    {
                        if (this.listData[i].Id.Equals(id))
                        {
                            this.listData[i].IsFinish = true;
                        }
                    }
                }
            }
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
                for (int i = 0; i < this.listData.Count; i++)
                {
                    if (this.listData[i].Id.Equals(value))
                    {
                        callModel = this.listData[i];
                        customerView.GetChannel().SetIncommingPhone(callModel.Phone);
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
            this.listDataSearch.Clear();
            keyword = CommonProcess.NormalizationString(keyword).ToLower();
            if (!String.IsNullOrEmpty(keyword))
            {
                foreach (CallModel item in this.listData)
                {
                    if (item.IsContainString(keyword))
                    {
                        this.listDataSearch.Add(item);
                    }
                }
            }
            this.listViewHistory.Items.Clear();
            for (int i = this.listDataSearch.Count - 1; i >= 0; i--)
            {
                this.listViewHistory.Items.Add(CreateListViewItem(this.listDataSearch[i], this.listDataSearch.Count - i));
            }
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
            //SearchByKeyword(String.Empty);
            this.listDataSearch.Clear();
            this.listViewHistory.Items.Clear();
            for (int i = listData.Count - 1; i >= 0; i--)
            {
                this.listViewHistory.Items.Add(CreateListViewItem(listData[i], listData.Count - i));
            }
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
    }
}
