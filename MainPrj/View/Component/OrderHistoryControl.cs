using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainPrj.Model;
using MainPrj.Model.Update;
using MainPrj.Util;

namespace MainPrj.View.Component
{
    public partial class OrderHistoryControl : UserControl
    {
        private OrderHistoryResponseModel _data = null;

        /// <summary>
        /// Data.
        /// </summary>
        public OrderHistoryResponseModel Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public OrderHistoryControl()
        {
            InitializeComponent();
        }
        public void UpdateData()
        {
            if (_data != null)
            {
                this.listView.Items.Clear();
                int idx = 0;
                foreach (CreateOrderModel item in _data.Record)
                {
                    this.listView.Items.Add(CreateListViewItem(item, ++idx));
                    if (item.Order_detail.Count > 1)
                    {
                        for (int i = 1; i < item.Order_detail.Count; i++)
                        {
                            this.listView.Items.Add(CreateListViewSubItem(item.Order_detail[i]));
                        }
                    }
                }
            }
        }
        //++ BUG0080-SPJ (NguyenPT 20160928) Clear order history
        /// <summary>
        /// Clear all data on listview.
        /// </summary>
        public void ClearData()
        {
            this.listView.Items.Clear();
        }
        //-- BUG0080-SPJ (NguyenPT 20160928) Clear order history

        private ListViewItem CreateListViewItem(CreateOrderModel model, int index)
        {
            ListViewItem item;
            string[] arr                                                    = new string[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_NUM];
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_NO]           = String.Format("{0}", index);
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_TIME]         = model.Created_date;
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_PRODUCT_ID] = DataPure.Instance.GetMaterialNoFromId(model.Order_detail[0].Materials_id);
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_PRODUCT_NAME] = DataPure.Instance.GetMaterialNameFromId(model.Order_detail[0].Materials_id);
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_QUANTITY]     = model.Order_detail[0].Quantity.ToString();
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_NOTE]         = model.Note;
            item                                                            = new ListViewItem(arr);
            // Set tag value
            item.Tag = model;
            return item;
        }
        private ListViewItem CreateListViewSubItem(OrderDetailModel model)
        {
            ListViewItem item;
            string[] arr                                                    = new string[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_NUM];
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_NO]           = string.Empty;
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_TIME]         = string.Empty;
            string materialNo = DataPure.Instance.GetMaterialNoFromId(model.Materials_id);
            if (string.IsNullOrEmpty(materialNo))
            {
                materialNo = DataPure.Instance.GetPromoteNoFromId(model.Materials_id);
            }
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_PRODUCT_ID] = materialNo;
            string materialName = DataPure.Instance.GetMaterialNameFromId(model.Materials_id);
            if (string.IsNullOrEmpty(materialName))
            {
                materialName = DataPure.Instance.GetPromoteNameFromId(model.Materials_id);
            }
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_PRODUCT_NAME] = materialName;
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_QUANTITY]     = model.Quantity.ToString();
            arr[(int)OrderHistoryColumns.ORDER_HISTORY_COLUMN_NOTE]         = string.Empty ;
            item                                                            = new ListViewItem(arr);
            // Set tag value
            item.Tag = null;
            return item;
        }
    }

}
