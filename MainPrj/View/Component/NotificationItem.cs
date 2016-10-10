using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainPrj.Model;
using MainPrj.Util;

namespace MainPrj.View.Component
{
    public partial class NotificationItem : UserControl
    {
        /// <summary>
        /// Data object.
        /// </summary>
        private NotificationModel data = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public NotificationItem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor with data object in parameter.
        /// </summary>
        /// <param name="model">Data</param>
        public NotificationItem(NotificationModel model)
        {
            InitializeComponent();
            data = model;
            // Assign click event handler for all control (except btnMarkRead)
            foreach (Control control in this.Controls)
            {
                if (!control.Name.Equals("btnMarkRead"))
                {
                    control.Click += new EventHandler(NotificationItem_Click);
                }
            }
        }
        /// <summary>
        /// Load item event.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void NotificationItem_Load(object sender, EventArgs e)
        {
            if (data != null)
            {
                string avatarString = string.Empty;
                if (!String.IsNullOrEmpty(data.Sender))
                {
                    string[] token = data.Sender.Split(' ');
                    if (token != null)
                    {
                        foreach (string item in token)
                        {
                            avatarString += String.Format("{0}", item[0]).ToUpper();
                        }
                    }
                }
                pbxAvatar.Image = CommonProcess.CreateAvatar(avatarString, pbxAvatar.Size.Height);
                // Set sender
                lblSender.Text = CommonProcess.GetRoleString(data.Role) + " " + data.Sender;
                // Set message
                lblMessage.Text = data.Message;
                // Set time
                lblTime.Text = data.NotifyTime;
                // Set tooltip
                this.toolTip.SetToolTip(this, data.Message);
                this.toolTip.SetToolTip(this.lblMessage, data.Message);
            }
        }
        /// <summary>
        /// Handle click notification.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void NotificationItem_Click(object sender, EventArgs e)
        {
            //if (this.data != null)
            //{
            //    this.data.IsNew = false;
            //}
            HandleClickNotificationItem();
        }
        /// <summary>
        /// Handle click notification item.
        /// </summary>
        private void HandleClickNotificationItem()
        {
            HandleInformReceiveNotification();
        }
        /// <summary>
        /// Mouse hover on item.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void NotificationItem_MouseHover(object sender, EventArgs e)
        {
            MouseHoverHandler();
        }
        /// <summary>
        /// Mouse leave out of item.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void NotificationItem_MouseLeave(object sender, EventArgs e)
        {
            // Check if cursor is outside the region
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                if (this.data != null)
                {
                    if (this.data.IsNew)
                    {
                        this.BackColor = CommonProcess.ConvertColorFromString(CommonProcess.FACEBOOK_NEW_ITEM_COLOR);
                    }
                    else
                    {
                        this.BackColor = Color.White;
                    }
                }
                btnMarkRead.Visible = false;
                btnMarkedRead.Visible = false;
            }
        }
        /// <summary>
        /// Mouse hover.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void pbxAvatar_MouseHover(object sender, EventArgs e)
        {
            MouseHoverHandler();
        }
        /// <summary>
        /// Handle mouse hover event.
        /// </summary>
        private void MouseHoverHandler()
        {
            this.BackColor = CommonProcess.ConvertColorFromString(CommonProcess.FACEBOOK_ITEM_HOVER_COLOR);
            if (this.data != null)
            {
                if (this.data.IsNew)
                {
                    btnMarkRead.Visible = true;
                }
                else
                {
                    btnMarkedRead.Visible = true;
                }
            }
        }

        /// <summary>
        /// Mouse hover.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void lblSender_MouseHover(object sender, EventArgs e)
        {
            MouseHoverHandler();
        }

        /// <summary>
        /// Mouse hover.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void lblMessage_MouseHover(object sender, EventArgs e)
        {
            MouseHoverHandler();
        }

        /// <summary>
        /// Mouse hover.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            MouseHoverHandler();
        }

        /// <summary>
        /// Mouse hover.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void lblTime_MouseHover(object sender, EventArgs e)
        {
            MouseHoverHandler();
        }

        /// <summary>
        /// Mouse hover.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnMarkRead_MouseHover(object sender, EventArgs e)
        {
            MouseHoverHandler();
        }
        /// <summary>
        /// Click on mark read icon.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnMarkRead_Click(object sender, EventArgs e)
        {
            HandleInformReceiveNotification();
        }
        private void HandleInformReceiveNotification()
        {
            if (this.data != null && (this.data.IsNew))
            {
                CommonProcess.NotificationSound.Stop();
                if (DataPure.Instance.IsAccountingAgentRole())
                {
                    CommonProcess.RequestNotifyReceived(this.data.Id,
                        DataPure.Instance.User.User_id, DataPure.Instance.User.First_name, string.Empty);
                }
                if (CommonProcess.HasError)
                {
                    CommonProcess.HasError = false;
                    CommonProcess.ShowErrorMessage(Properties.Resources.ConnectedWithNotifyCenterError, DataPure.Instance.MainForm);
                }
                else
                {
                    CommonProcess.HandleInformReceivedNotificationSuccess(this.data.Id);
                }
            }
        }
    }
}
