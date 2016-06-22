using MainPrj.Model.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class OrderReport : Form
    {
        private Dictionary<string, OrderDetailModel> listData = new Dictionary<string, OrderDetailModel>();

        /// <summary>
        /// List of data.
        /// </summary>
        public Dictionary<string, OrderDetailModel> ListData
        {
            get { return listData; }
            set { listData = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public OrderReport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handle when change selection index of Material type combobox.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void cbxMaterialType_SelectedValueChanged(object sender, EventArgs e)
        {
            Dictionary<string, OrderDetailModel> listDataSearch = new Dictionary<string, OrderDetailModel>();
            switch ((MaterialTypes)cbxMaterialType.SelectedValue)
            {
                case MaterialTypes.MATERIALTYPE_GAS:
                    foreach (OrderDetailModel item in this.listData.Values)
                    {
                        if (item.IsGas())
                        {
                            listDataSearch.Add(item.Materials_id, item);
                        }
                    }
                    break;
                case MaterialTypes.MATERIALTYPE_GAS_STOVE:
                    foreach (OrderDetailModel item in this.listData.Values)
                    {
                        if (item.IsGasStove())
                        {
                            listDataSearch.Add(item.Materials_id, item);
                        }
                    }
                    break;
                case MaterialTypes.MATERIALTYPE_VAN:
                    foreach (OrderDetailModel item in this.listData.Values)
                    {
                        if (item.IsVan())
                        {
                            listDataSearch.Add(item.Materials_id, item);
                        }
                    }
                    break;
                case MaterialTypes.MATERIALTYPE_CYLINDER:
                    foreach (OrderDetailModel item in this.listData.Values)
                    {
                        if (item.IsCylinder())
                        {
                            listDataSearch.Add(item.Materials_id, item);
                        }
                    }
                    break;
                case MaterialTypes.MATERIALTYPE_PROMOTE:
                    foreach (OrderDetailModel item in this.listData.Values)
                    {
                        if (item.IsPromote())
                        {
                            listDataSearch.Add(item.Materials_id, item);
                        }
                    }
                    break;
                default:
                    foreach (OrderDetailModel item in this.listData.Values)
                    {
                        listDataSearch.Add(item.Materials_id, item);
                    }
                    break;
            }
            ReloadListView(listDataSearch);

        }
        /// <summary>
        /// Handle when form load.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void OrderReport_Load(object sender, EventArgs e)
        {
            List<object> items = new List<object>();
            items.Add(new { Text = string.Empty, Value = (int)MaterialTypes.MATERIALTYPE_ALL });
            items.Add(new { Text = "Gas", Value = (int)MaterialTypes.MATERIALTYPE_GAS });
            items.Add(new { Text = "Bếp", Value = (int)MaterialTypes.MATERIALTYPE_GAS_STOVE });
            items.Add(new { Text = "Van", Value = (int)MaterialTypes.MATERIALTYPE_VAN });
            items.Add(new { Text = "Vỏ", Value = (int)MaterialTypes.MATERIALTYPE_CYLINDER });
            items.Add(new { Text = "Khuyến mãi", Value = (int)MaterialTypes.MATERIALTYPE_PROMOTE });
            //cbxMaterialType.Items.AddRange(items.ToArray());
            cbxMaterialType.DataSource = items;
            ReloadListView(this.listData);
        }
        private void ReloadListView(Dictionary<string, OrderDetailModel> list)
        {
            this.listViewMaterial.Items.Clear();
            int index = 0;
            List<string> listKeys = list.Keys.ToList();
            listKeys.Sort();
            foreach (string key in listKeys)
            {
                this.listViewMaterial.Items.Add(CreateListViewItem(list[key], ++index));
            }
        }
        /// <summary>
        /// Handle close button click.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private ListViewItem CreateListViewItem(OrderDetailModel model, int index)
        {
            // Create array data
            string[] arr = new string[(int)OrderReportColumns.ORDERREPORT_COLUMN_NUM];
            // No column
            arr[(int)OrderReportColumns.ORDERREPORT_COLUMN_NO] = String.Format("{0}", index);
            // Id column
            arr[(int)OrderReportColumns.ORDERREPORT_COLUMN_ID] = model.Materials_id;
            // Name column
            arr[(int)OrderReportColumns.ORDERREPORT_COLUMN_NAME] = model.Seri;
            // Quantity column
            if (model.Quantity != 0)
            {
                arr[(int)OrderReportColumns.ORDERREPORT_COLUMN_QUANTITY] = String.Format("{0}", model.Quantity);
            }
            else
            {
                arr[(int)OrderReportColumns.ORDERREPORT_COLUMN_QUANTITY] = String.Empty;
            }
            // Create listview item object
            ListViewItem item = new ListViewItem(arr);
            // Set tag value
            item.Tag = model.Materials_id;

            return item;
        }
        /// <summary>
        /// Handle select all.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnAll_Click(object sender, EventArgs e)
        {
            ReloadListView(this.listData);
        }
    }
    /// <summary>
    /// Material types.
    /// </summary>
    public enum MaterialTypes
    {
        MATERIALTYPE_ALL = 0,
        MATERIALTYPE_GAS,
        MATERIALTYPE_GAS_STOVE,
        MATERIALTYPE_VAN,
        MATERIALTYPE_CYLINDER,
        MATERIALTYPE_PROMOTE,
        MATERIALTYPE_NUM
    }
    /// <summary>
    /// Order report listview columns.
    /// </summary>
    public enum OrderReportColumns
    {
        ORDERREPORT_COLUMN_NO,
        ORDERREPORT_COLUMN_ID,
        ORDERREPORT_COLUMN_NAME,
        ORDERREPORT_COLUMN_QUANTITY,
        ORDERREPORT_COLUMN_NUM
    }
}
