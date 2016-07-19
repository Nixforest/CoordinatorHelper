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
        [DataMember(Name = "agent_province", IsRequired = false)]
        protected string agent_province;
        [DataMember(Name = "agent_district", IsRequired = false)]
        protected string agent_district;
        [DataMember(Name = "agent_cell_phone", IsRequired = false)]
        protected string agent_cell_phone;
        /// <summary>
        /// Agent cell phone.
        /// </summary>
        public string Agent_cell_phone
        {
            get { return agent_cell_phone; }
            set { agent_cell_phone = value; }
        }
        /// <summary>
        /// District of agent.
        /// </summary>
        public string Agent_district
        {
            get { return agent_district; }
            set { agent_district = value; }
        }
        /// <summary>
        /// Provice of agent.
        /// </summary>
        public string Agent_province
        {
            get { return agent_province; }
            set { agent_province = value; }
        }
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
            this.Id               = string.Empty;
            this.Name             = string.Empty;
            this.Detail           = string.Empty;
            this.phone            = string.Empty;
            this.address          = string.Empty;
            this.agent_province   = string.Empty;
            this.agent_district   = string.Empty;
            this.agent_cell_phone = string.Empty;
        }
        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="model">Model to copy</param>
        public AgentModel(BaseModel model)
        {
            this.Id               = model.Id;
            this.Name             = model.Name;
            this.Detail           = model.Detail;
            this.phone            = string.Empty;
            this.address          = string.Empty;
            this.agent_province   = string.Empty;
            this.agent_district   = string.Empty;
            this.agent_cell_phone = string.Empty;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AgentModel(string id, string name, string detail, string phone, string address,
            string agent_province, string agent_district, string cellphone)
        {
            this.Id               = id;
            this.Name             = name;
            this.Detail           = detail;
            this.phone            = phone;
            this.address          = address;
            this.agent_province   = agent_province;
            this.agent_district   = agent_district;
            this.agent_cell_phone = cellphone;
        }
    }
}
