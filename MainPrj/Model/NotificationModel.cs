using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Notification model class.
    /// </summary>
    [DataContract]
    public class NotificationModel : BaseModel, IComparable<NotificationModel>
    {
        [DataMember(Name = "type", IsRequired = false)]
        private string type = string.Empty;
        [DataMember(Name = "sender", IsRequired = false)]
        private string sender = string.Empty;
        [DataMember(Name = "sender_role_name", IsRequired = false)]
        private string sender_role_name = string.Empty;
        [DataMember(Name = "message", IsRequired = false)]
        private string message = string.Empty;
        [DataMember(Name = "sender_role_id", IsRequired = false)]
        private string role = string.Empty;
        [DataMember(Name = "isNew", IsRequired = false)]
        private bool isNew = true;
        [DataMember(Name = "created_date", IsRequired = false)]
        private string notifyTime = string.Empty;
        /// <summary>
        /// Type of notification.
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// Sender of notification.
        /// </summary>
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        /// <summary>
        /// Role of sender.
        /// </summary>
        public string Sender_role_name
        {
            get { return sender_role_name; }
            set { sender_role_name = value; }
        }
        /// <summary>
        /// Message.
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        /// <summary>
        /// Role of sender (string).
        /// </summary>
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        /// <summary>
        /// Status of notification (New/Read).
        /// </summary>
        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }
        /// <summary>
        /// Moment notification.
        /// </summary>
        public string NotifyTime
        {
            get { return notifyTime; }
            set { notifyTime = value; }
        }
        /// <summary>
        /// Compare method.
        /// </summary>
        /// <param name="other">Compared object</param>
        /// <returns>True/False</returns>
        public int CompareTo(NotificationModel other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return other.notifyTime.CompareTo(this.notifyTime);
            }
        }
    }
}
