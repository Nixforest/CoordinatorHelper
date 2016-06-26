using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model.Address
{
    /// <summary>
    /// City model.
    /// </summary>
    [DataContract]
    public class CityModel : BaseModel
    {
        [DataMember(Name = "data", IsRequired = false)]
        private List<DistrictModel> data;
        /// <summary>
        /// District list.
        /// </summary>
        public List<DistrictModel> Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
