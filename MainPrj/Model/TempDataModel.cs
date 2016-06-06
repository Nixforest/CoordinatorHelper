using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Temp data model
    /// </summary>
    [DataContract]
    public class TempDataModel
    {
        [DataMember(Name = "agent_id", IsRequired = false)]
        protected string agent_id;
        [DataMember(Name = "agent_name", IsRequired = false)]
        protected string agent_name;
        [DataMember(Name = "employee_maintain", IsRequired = false)]
        protected SelectorModel[] employee_maintain;
        [DataMember(Name = "monitor_market_development", IsRequired = false)]
        protected SelectorModel[] monitor_market_development;
        [DataMember(Name = "material_gas", IsRequired = false)]
        protected MaterialModel[] material_gas;

        protected MaterialModel[] Material_gas
        {
            get { return material_gas; }
            set { material_gas = value; }
        }

        protected SelectorModel[] Monitor_market_development
        {
            get { return monitor_market_development; }
            set { monitor_market_development = value; }
        }

        public SelectorModel[] Employee_maintain
        {
            get { return employee_maintain; }
            set { employee_maintain = value; }
        }

        public string Agent_name
        {
            get { return agent_name; }
            set { agent_name = value; }
        }

        public string Agent_id
        {
            get { return agent_id; }
            set { agent_id = value; }
        }
    }
}
