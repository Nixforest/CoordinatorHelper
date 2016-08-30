using MainPrj.Model.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    [DataContract]
    public class OrderHistoryResponseModel : BaseResponseModel
    {
        [DataMember(Name = "record", IsRequired = false)]
        protected CreateOrderModel[] record;
        /// <summary>
        /// List order
        /// </summary>
        public CreateOrderModel[] Record
        {
            get { return record; }
            set { record = value; }
        }
    }
}
