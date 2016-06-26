using MainPrj.Model.Address;
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
        [DataMember(Name = "agent_phone", IsRequired = false)]
        protected string agent_phone;
        [DataMember(Name = "agent_address", IsRequired = false)]
        protected string agent_address;
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
        [DataMember(Name = "list_province", IsRequired = false)]
        protected List<CityModel> list_province;
        [DataMember(Name = "list_street", IsRequired = false)]
        protected List<StreetModel> list_street;
        /// <summary>
        /// List of streets.
        /// </summary>
        public List<StreetModel> List_street
        {
            get { return list_street; }
            set { list_street = value; }
        }

        /// <summary>
        /// List of cities.
        /// </summary>
        public List<CityModel> List_province
        {
            get { return list_province; }
            set { list_province = value; }
        }
        /// <summary>
        /// Agent address.
        /// </summary>
        public string Agent_address
        {
            get { return agent_address; }
            set { agent_address = value; }
        }
        /// <summary>
        /// Agent's phone.
        /// </summary>
        public string Agent_phone
        {
            get { return agent_phone; }
            set { agent_phone = value; }
        }
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
