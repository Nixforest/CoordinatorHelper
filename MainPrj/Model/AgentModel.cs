using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    [DataContract]
    public class AgentModel : BaseModel
    {
        [DataMember(Name = "phone", IsRequired = false)]
        private string phone;
        [DataMember(Name = "address", IsRequired = false)]
        private string address;
        /// <summary>
        /// Address.
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// Phone.
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public AgentModel()
        {
            this.Id      = string.Empty;
            this.Name    = string.Empty;
            this.Detail  = string.Empty;
            this.phone   = string.Empty;
            this.address = string.Empty;
        }
        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="model">Model to copy</param>
        public AgentModel(BaseModel model)
        {
            this.Id      = model.Id;
            this.Name    = model.Name;
            this.Detail  = model.Detail;
            this.phone   = string.Empty;
            this.address = string.Empty;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AgentModel(string id, string name, string detail, string phone, string address)
        {
            this.Id      = id;
            this.Name    = name;
            this.Detail  = detail;
            this.phone   = phone;
            this.address = address;
        }
    }
}
