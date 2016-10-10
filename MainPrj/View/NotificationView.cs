using MainPrj.Model;
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
    public partial class NotificationView : Form
    {
        private const int MAX_ITEM_NUMBER = 7;
        private const int ITEM_HEIGHT = 67;
        private const int ITEM_WIDTH = 430;
        private const int ITEM_OFFSET = 38;
        private const int MAX_HEIGHT = MAX_ITEM_NUMBER * (ITEM_HEIGHT - 1) + ITEM_OFFSET + 1;
        private Point _location;
        private Dictionary<string, NotificationModel> listData = null;

        internal Dictionary<string, NotificationModel> ListData
        {
            get { return listData; }
            set { listData = value; }
        }
        public NotificationView(int x, int y)
        {
            InitializeComponent();
            _location = new Point(x, y);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotificationView_Load(object sender, EventArgs e)
        {
            int height = this.listData.Count * (ITEM_HEIGHT - 1) + ITEM_OFFSET + 1;
            if (height > MAX_HEIGHT)
            {
                height = MAX_HEIGHT;
                //this.pnlMain.AutoScroll = true;

                //this.pnlMain.HorizontalScroll.Enabled = false;
                //this.pnlMain.HorizontalScroll.Visible = false;
                this.pnlMain.HorizontalScroll.Maximum = 0;
                this.pnlMain.AutoScroll = false;
                this.pnlMain.VerticalScroll.Visible = false;
                this.pnlMain.AutoScroll = true;
            }
            this.Location = new Point(_location.X - this.Size.Width, _location.Y - height);
            List<NotificationModel> list = this.listData.Values.ToList();
            list.Sort();
            //int offset = 38;
            int offset = 0;
            foreach (NotificationModel item in list)
            {
                NotificationItem notItem = new NotificationItem(item);
                notItem.Location = new System.Drawing.Point(0, offset);
                offset += ITEM_HEIGHT - 1;
                //this.Controls.Add(notItem);
                this.pnlMain.Controls.Add(notItem);
                if (item.IsNew)
                {
                    notItem.BackColor = CommonProcess.ConvertColorFromString(CommonProcess.FACEBOOK_NEW_ITEM_COLOR);
                }
                else
                {
                    notItem.BackColor = Color.White;
                }
                notItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                notItem.Cursor = System.Windows.Forms.Cursors.Hand;
                notItem.Name = "notificationItem" + offset.ToString();
                notItem.Size = new System.Drawing.Size(ITEM_WIDTH, ITEM_HEIGHT);
                notItem.TabIndex = 0;
            }
            this.Size = new Size(this.Size.Width, height);
            this.pnlMain.Size = new Size(this.Size.Width, height - ITEM_OFFSET);
            if (list.Count == 0)
            {
                labelInfo.Text = "Bạn không có thông báo nào";
            }
        }
    }
}
