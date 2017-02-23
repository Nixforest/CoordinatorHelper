using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Response data from server when request find customer.
    /// </summary>
    [DataContract]
    public class CustomerResponseModel : BaseResponseModel
    {
        [DataMember(Name = "record", IsRequired = false)]
        protected CustomerModel[] record;
        /// <summary>
        /// Customer information data.
        /// </summary>
        public CustomerModel[] Record
        {
            get { return record; }
            set { record = value; }
        }
    }
}
