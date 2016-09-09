using MainPrj.Model;
using MainPrj.Util;
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
    public partial class CancelOrderView : Form
    {
        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        //private string id = string.Empty;
        private OrderModel _data = null;

        ///// <summary>
        ///// Order's id.
        ///// </summary>
        //public string Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}
        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        /// <summary>
        /// Constructor.
        /// </summary>
        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        //public CancelOrderView(string id)
        public CancelOrderView(OrderModel data)
        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        {
            InitializeComponent();
            //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
            //this.Id = id;
            _data = data;
            //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        }
        /// <summary>
        /// Handle when click Finish button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
            //if (!string.IsNullOrEmpty(id))
            //{
            //    foreach (OrderModel item in DataPure.Instance.ListOrders)
            //    {
            //        if (item.Id.Equals(id))
            //        {
            //            item.Status           = OrderStatus.ORDERSTATUS_CANCEL;
            //            item.IsUpdateToServer = false;
            //            item.Note             = tbxReason.Text.Trim();

            //            // Update to server
            //            string retId = CommonProcess.UpdateOrderToServer(item);
            //            if (!String.IsNullOrEmpty(retId))
            //            {
            //                item.IsUpdateToServer = true;
            //            }
            //            break;
            //        }
            //    }

            //    this.Close();
            //}
            if (_data != null)
            {
                //++ BUG0072-SPJ (NguyenPT 20160909) Handle Cancel order is not success
                //_data.Status = OrderStatus.ORDERSTATUS_CANCEL;
                //-- BUG0072-SPJ (NguyenPT 20160909) Handle Cancel order is not success
                _data.IsUpdateToServer = false;
                _data.Note             = tbxReason.Text.Trim();

                // Update to server
                string retId = CommonProcess.UpdateOrderToServer(_data);
                if (!String.IsNullOrEmpty(retId))
                {
                    //++ BUG0072-SPJ (NguyenPT 20160909) Handle Cancel order is not success
                    _data.Status = OrderStatus.ORDERSTATUS_CANCEL;
                    //-- BUG0072-SPJ (NguyenPT 20160909) Handle Cancel order is not success
                    _data.IsUpdateToServer = true;
                    CommonProcess.UpdateOrderToFile(_data);
                }
            }
            this.Close();
            //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        }
    }
}
