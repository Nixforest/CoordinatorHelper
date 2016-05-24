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

        public List<CallModel> ListData
        {
            get { return listData; }
            set { listData = value; }
        }
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
                        Stream fileStream = fileDialog.OpenFile();
                        if (fileStream != null)
                        {
                            int index = this.listViewHistory.Items.Count;
                            List<CallModel> listCalls = new List<CallModel>();
                            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CallModel));
                            byte[] encodingBytes = null;
                            StreamReader sr = new StreamReader(fileStream);
                            while (true)
                            {
                                string line = sr.ReadLine();
                                if (line == null)
                                {
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
                                    listCalls.Add(callModel);
                                    this.listData.Add(callModel);
                                }
                            }
                            for (int i = listCalls.Count - 1; i >= 0; i--)
                            {
                                this.listViewHistory.Items.Add(CreateListViewItem(listCalls[i], ++index));
                            }
                        }
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
                arr[(int)HistoryColumns.HISTORY_COLUMN_TIME] = String.Format("{0}/{1}/{2} {3:00}:{4:00}:{5:00}",
                    time.Year,
                    time.Month,
                    time.Day,
                    time.Hour,
                    time.Minute,
                    time.Second);
            }
            //arr[(int)HistoryColumns.HISTORY_COLUMN_TIME] = callModel.Id;
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
            if (callModel.Status.Equals((int)CardDataStatus.CARDDATA_MISS))
            {
                item.ForeColor = Properties.Settings.Default.ColorMissCallText;
            }
            if (callModel.IsFinish)
            {
                item.ForeColor = Properties.Settings.Default.ColorFinishCallText;
                item.BackColor = Properties.Settings.Default.ColorFinishCallBackground;
            }
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
            // Has a row is selected
            if (this.listViewHistory.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in this.listViewHistory.SelectedItems)
                {
                    string id = item.Tag.ToString();
                    item.ForeColor = Properties.Settings.Default.ColorFinishCallText;
                    item.BackColor = Properties.Settings.Default.ColorFinishCallBackground;
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

        private void listViewHistory_DoubleClick(object sender, EventArgs e)
        {
            CustomerView customerView = new CustomerView();
            CallModel callModel = null;
            if (this.listViewHistory.SelectedItems.Count == 1)
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
                callModel.Customer.Id = data.Id;
                callModel.Customer.Name = data.Name;
                callModel.Customer.Address = data.Address;
                callModel.Customer.PhoneList = data.PhoneList;
                callModel.Customer.AgencyName = data.AgencyName;
                callModel.Customer.CustomerType = data.CustomerType;
                callModel.Customer.Contact = data.Contact;
                callModel.Customer.Contact_note = data.Contact_note;
                callModel.Customer.Sale_name = data.Sale_name;
                callModel.Customer.Sale_phone = data.Sale_phone;
                callModel.Customer.Sale_type = data.Sale_type;
                callModel.Customer.AgencyNearest = data.AgencyNearest;
                if (this.listViewHistory.SelectedItems.Count == 1)
                {
                    ListViewItem listViewItem = this.listViewHistory.SelectedItems[0];
                    listViewItem.SubItems[6].Text = data.Contact_note;
                    listViewItem.SubItems[7].Text = string.Format("{0} - {1}", data.Name, data.Address);
                }
            }
        }
    }
}
