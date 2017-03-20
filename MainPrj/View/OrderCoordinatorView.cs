using MainPrj.Util;
using MainPrj.View.Component;
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
    public partial class OrderCoordinatorView : Form
    {
        /// <summary>
        /// Note
        /// </summary>
        private string note = string.Empty;
        private string mode = "1";

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public OrderCoordinatorView(string mode = "1")
        {
            InitializeComponent();
            this.mode = mode;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                note = coordinatorOrderView_v2.GetData();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        public CoordinatorOrderView_v2 getContent()
        {
            return coordinatorOrderView_v2;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                note = coordinatorOrderView_v2.GetData();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }

        }

        private bool ValidateData()
        {
            if (mode == "1")
            {
                if (coordinatorOrderView_v2.isEmpty())
                {
                    CommonProcess.ShowInformMessage("Bạn phải chọn vật tư trước.", MessageBoxButtons.OK);
                    return false;
                }
            }
            else if (mode == "2")
            {
                return true;
            }
            return true;
        }

        private void OrderCoordinatorView_Load(object sender, EventArgs e)
        {
            if (mode == "1")
            {
                this.Text = "Tạo đơn hàng";
                this.btnOK.Text = "Giao ngay";
                ActiveButton(this.btnOK);
                this.btnSaveData.Text = "Xe tải giao";
                ActiveButton(this.btnSaveData);
            }
            else if (mode == "2")
            {
                this.Text = "Tạo thẻ kho Thu vỏ";
                this.btnOK.Text = "OK";
                ActiveButton(this.btnOK);
                this.btnSaveData.Text = "Xe tải giao";
                ActiveButton(this.btnSaveData, false);
            }
        }
        /// <summary>
        /// Active button
        /// </summary>
        /// <param name="btn">Button</param>
        /// <param name="isActive">Active flag</param>
        private void ActiveButton(Button btn, bool isActive = true)
        {
            btn.Enabled = isActive;
            btn.Visible = isActive;
        }
    }
}
