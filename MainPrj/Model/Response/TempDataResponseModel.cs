using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Response data from server when get temp data.
    /// </summary>
    [DataContract]
    public class TempDataResponseModel : BaseResponseModel
    {
        [DataMember(Name = "record", IsRequired = false)]
        protected TempDataModel record;
        /// <summary>
        /// Temp data.
        /// </summary>
        public TempDataModel Record
        {
            get { return record; }
            set { record = value; }
        }
    }
}
