using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Response data from server.
    /// </summary>
    [DataContract]
    public class CreateOrderResponseModel : BaseResponseModel
    {
        [DataMember(Name = "id", IsRequired = false)]
        protected string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
