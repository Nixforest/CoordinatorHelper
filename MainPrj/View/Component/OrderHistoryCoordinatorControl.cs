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
    public partial class OrderHistoryCoordinatorControl : UserControl
    {
        /// <summary>
        /// Data.
        /// </summary>
        private OrderHistoryResponseModel _data = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public OrderHistoryCoordinatorControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Clear all data on listview.
        /// </summary>
        public void ClearData()
        {
            this.listView.Items.Clear();
        }

        /// <summary>
        /// Create list view item.
        /// </summary>
        /// <param name="model">CreateOrderModel</param>
        /// <param name="index">Index</param>
        /// <returns>ListViewItem</returns>
        private ListViewItem CreateListViewItem(CreateOrderModel model, int index)
        {
            ListViewItem item;
            string[] arr = new string[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_NUM];
            arr[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_TIME] = model.Created_date.Remove(5);
            string name = string.Empty;
            if (model.Order_detail.Count > 0)
            {
                name = DataPure.Instance.GetMaterialNameFromId(model.Order_detail[0].Materials_id);
            }
            else
            {
                name = GlobalConst.CONTENT00002;
            }
            arr[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_PRODUCT_NAME] = name;
            string qty = string.Empty;
            if (model.Order_detail.Count > 0)
            {
                qty = model.Order_detail[0].Quantity.ToString();
            }
            arr[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_QUANTITY] = qty;
            arr[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_NOTE] = model.Note;
            item                                                            = new ListViewItem(arr);
            // Set tag value
            item.Tag = model;
            return item;
        }

        /// <summary>
        /// Create listview sub item.
        /// </summary>
        /// <param name="model">OrderDetailModel</param>
        /// <returns>ListViewItem</returns>
        private ListViewItem CreateListViewSubItem(OrderDetailModel model)
        {
            ListViewItem item;
            // Number
            string[] arr = new string[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_NUM];
            // Time
            arr[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_TIME] = string.Empty;
            // Name
            string materialName = DataPure.Instance.GetMaterialNameFromId(model.Materials_id);
            if (string.IsNullOrEmpty(materialName))
            {
                materialName = DataPure.Instance.GetPromoteNameFromId(model.Materials_id);
            }
            arr[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_PRODUCT_NAME] = materialName;

            arr[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_QUANTITY] = model.Quantity.ToString();
            arr[(int)OrderHistoryCoordinatorColumns.ORDER_HISTORY_COOR_COLUMN_NOTE] = string.Empty;
            item = new ListViewItem(arr);
            // Set tag value
            item.Tag = null;
            return item;
        }

        /// <summary>
        /// Update data for control.
        /// </summary>
        /// <param name="data">OrderHistoryResponseModel</param>
        public void UpdateData(OrderHistoryResponseModel data)
        {
            this._data = data;
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
    }
}
