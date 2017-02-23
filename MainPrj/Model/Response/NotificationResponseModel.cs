using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model.Response
{
    /// <summary>
    /// Model class use for notification response.
    /// </summary>
    [DataContract]
    public class NotificationResponseModel : BaseResponseModel
    {
        [DataMember(Name = "record", IsRequired = false)]
        protected NotificationModel record;
        /// <summary>
        /// Notification data.
        /// </summary>
        public NotificationModel Record
        {
            get { return record; }
            set { record = value; }
        }
    }
}
