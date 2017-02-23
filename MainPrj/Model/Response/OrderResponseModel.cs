using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Response data from server when request create/update order.
    /// </summary>
    [DataContract]
    public class OrderResponseModel : BaseResponseModel
    {
        [DataMember(Name = "id", IsRequired = false)]
        protected string id;
        /// <summary>
        /// Order id response from server.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
