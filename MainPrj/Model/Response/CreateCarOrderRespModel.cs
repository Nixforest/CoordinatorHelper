using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model.Response
{
    /// <summary>
    /// Response data from server when request create call history.
    /// </summary>
    [DataContract]
    class CreateCarOrderRespModel : BaseResponseModel
    {
        [DataMember(Name = "id", IsRequired = false)]
        protected string id;
        /// <summary>
        /// Customer information data.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
