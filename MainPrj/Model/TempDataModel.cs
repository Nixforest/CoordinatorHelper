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
        [DataMember(Name = "agent_cell_phone", IsRequired = false)]
        protected string agent_cell_phone;
        [DataMember(Name = "agent_address", IsRequired = false)]
        protected string agent_address;
        [DataMember(Name = "employee_maintain", IsRequired = false)]
        protected List<SelectorModel> employee_maintain;
        [DataMember(Name = "monitor_market_development", IsRequired = false)]
        protected List<SelectorModel> monitor_market_development;
        [DataMember(Name = "material_gas", IsRequired = false)]
        protected List<MaterialModel> material_gas;
        [DataMember(Name = "material_promotion", IsRequired = false)]
        protected List<MaterialModel> material_promotion;
        [DataMember(Name = "agent_list", IsRequired = false)]
        protected List<SelectorModel> agent_list;
        [DataMember(Name = "material_vo", IsRequired = false)]
        protected List<MaterialModel> material_vo;
        [DataMember(Name = "list_province", IsRequired = false)]
        protected List<CityModel> list_province;
        [DataMember(Name = "list_street", IsRequired = false)]
        protected List<StreetModel> list_street;
        [DataMember(Name = "agent_province", IsRequired = false)]
        protected string agent_province;
        [DataMember(Name = "agent_district", IsRequired = false)]
        protected string agent_district;
        [DataMember(Name = "list_user_executive", IsRequired = false)]
        protected List<SelectorModel> list_user_executive;

        public List<SelectorModel> List_user_executive
        {
            get { return list_user_executive; }
            set { list_user_executive = value; }
        }
        //++ BUG0006-SPJ (NguyenPT 20161111) Call history
        [DataMember(Name = "list_order_reason", IsRequired = false)]
        protected List<SelectorModel> list_order_reason;

        /// <summary>
        /// List type of call.
        /// </summary>
        public List<SelectorModel> List_order_reason
        {
            get { return list_order_reason; }
            set { list_order_reason = value; }
        }
        //-- BUG0006-SPJ (NguyenPT 20161111) Call history
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
        /// Agent cell phone.
        /// </summary>
        public string Agent_cell_phone
        {
            get { return agent_cell_phone; }
            set { agent_cell_phone = value; }
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
        public List<SelectorModel> Agent_list
        {
            get { return agent_list; }
            set { agent_list = value; }
        }
        /// <summary>
        /// Promotes.
        /// </summary>
        public List<MaterialModel> Material_promotion
        {
            get { return material_promotion; }
            set { material_promotion = value; }
        }
        /// <summary>
        /// Gas.
        /// </summary>
        public List<MaterialModel> Material_gas
        {
            get { return material_gas; }
            set { material_gas = value; }
        }

        public List<SelectorModel> Monitor_market_development
        {
            get { return monitor_market_development; }
            set { monitor_market_development = value; }
        }

        public List<SelectorModel> Employee_maintain
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
            if (material_vo != null)
            {
                material_vo.Sort();
            }
        }
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TempDataModel()
        {
            this.agent_address              = string.Empty;
            this.agent_district             = string.Empty;
            this.agent_id                   = string.Empty;
            this.agent_list                 = new List<SelectorModel>();
            this.agent_name                 = string.Empty;
            this.agent_phone                = string.Empty;
            this.agent_province             = string.Empty;
            this.employee_maintain          = new List<SelectorModel>();
            this.list_province              = new List<CityModel>();
            this.list_street                = new List<StreetModel>();
            this.material_gas               = new List<MaterialModel>();
            this.material_promotion         = new List<MaterialModel>();
            this.material_vo                = new List<MaterialModel>();
            this.monitor_market_development = new List<SelectorModel>();
        }
    }
}
