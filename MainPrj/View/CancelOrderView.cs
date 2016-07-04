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
        private string id = string.Empty;

        /// <summary>
        /// Order's id.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public CancelOrderView(string id)
        {
            InitializeComponent();
            this.Id = id;
        }
        /// <summary>
        /// Handle when click Finish button.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id))
            {
                foreach (OrderModel item in DataPure.Instance.ListOrders)
                {
                    if (item.Id.Equals(id))
                    {
                        item.Status           = OrderStatus.ORDERSTATUS_CANCEL;
                        item.IsUpdateToServer = false;
                        item.Note             = tbxReason.Text.Trim();

                        // Update to server
                        string retId = CommonProcess.UpdateOrderToServer(item);
                        if (!String.IsNullOrEmpty(retId))
                        {
                            item.IsUpdateToServer = true;
                        }
                        break;
                    }
                }

                this.Close();
            }
        }
    }
}
