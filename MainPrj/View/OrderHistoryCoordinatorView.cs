using MainPrj.Model;
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
    public partial class OrderHistoryCoordinatorView : Form
    {
        /// <summary>
        /// Data.
        /// </summary>
        private OrderHistoryResponseModel _data = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public OrderHistoryCoordinatorView()
        {
            InitializeComponent();
        }
        public void UpdateData(OrderHistoryResponseModel data)
        {
            this._data = data;
        }

        /// <summary>
        /// Handle load form event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void OrderHistoryCoordinatorView_Load(object sender, EventArgs e)
        {
            if (this._data != null)
            {
                this.orderHistory.UpdateData(_data);
            }
        }
    }
}
