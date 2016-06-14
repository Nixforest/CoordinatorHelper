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
        [DataMember(Name = "material_promotion", IsRequired = false)]
        protected MaterialModel[] material_promotion;
        [DataMember(Name = "agent_list", IsRequired = false)]
        protected SelectorModel[] agent_list;
        [DataMember(Name = "material_vo", IsRequired = false)]
        protected List<MaterialModel> material_vo;
        /// <summary>
        /// Gas cylinder.
        /// </summary>
        public List<MaterialModel> Material_vo
        {
            get { return material_vo; }
            set { material_vo = value; }
        }
        /// <summary>
        /// Agents list.
        /// </summary>
        public SelectorModel[] Agent_list
        {
            get { return agent_list; }
            set { agent_list = value; }
        }
        /// <summary>
        /// Promotes.
        /// </summary>
        public MaterialModel[] Material_promotion
        {
            get { return material_promotion; }
            set { material_promotion = value; }
        }
        /// <summary>
        /// Gas.
        /// </summary>
        public MaterialModel[] Material_gas
        {
            get { return material_gas; }
            set { material_gas = value; }
        }

        public SelectorModel[] Monitor_market_development
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
        public void Sort()
        {
            material_vo.Sort();
        }
    }
}
