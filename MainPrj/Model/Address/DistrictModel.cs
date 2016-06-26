using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model.Address
{
    /// <summary>
    /// District model.
    /// </summary>
    [DataContract]
    public class DistrictModel : BaseModel
    {
        [DataMember(Name = "data", IsRequired = false)]
        private List<WardModel> data;
        /// <summary>
        /// List of wards.
        /// </summary>
        public List<WardModel> Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
