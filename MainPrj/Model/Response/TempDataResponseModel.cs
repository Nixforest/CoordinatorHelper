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
    public class TempDataResponseModel : BaseResponseModel
    {
        [DataMember(Name = "record", IsRequired = false)]
        protected TempDataModel record;

        public TempDataModel Record
        {
            get { return record; }
            set { record = value; }
        }
    }
}
