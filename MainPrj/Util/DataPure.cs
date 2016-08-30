using MainPrj.Model;
using MainPrj.Model.Address;
using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MainPrj.Util
{
    /// <summary>
    /// Data class
    /// </summary>
    public class DataPure
    {
        #region Data members
        private int currentChannel                                       = 0;
        private TempDataModel tempData                                   = null;
        private UserLoginModel user                                      = null;
        private List<CallModel> listCalls                                = null;
        private CustomerModel customerInfo                               = null;
        private AgentModel agent                                         = null;
        private List<OrderModel> listOrders                              = null;
        private Dictionary<string, MaterialBitmap> listRecentProductsImg = null;
        private Dictionary<string, MaterialBitmap> listRecentPromotesImg = null;
        #region SIP handling
        private PacketDevice netDevice = null;
        /// <summary>
        /// Net layer device.
        /// </summary>
        public PacketDevice NetDevice
        {
            get { return netDevice; }
            set { netDevice = value; }
        } 
        #endregion
        /// <summary>
        /// List of recent promtes (BITMAP.)
        /// </summary>
        public Dictionary<string, MaterialBitmap> ListRecentPromotesImg
        {
            get { return listRecentPromotesImg; }
            set { listRecentPromotesImg = value; }
        }
        /// <summary>
        /// List of recent products (BITMAP).
        /// </summary>
        public Dictionary<string, MaterialBitmap> ListRecentProductsImg
        {
            get { return listRecentProductsImg; }
            set { listRecentProductsImg = value; }
        }
        /// <summary>
        /// List of orders.
        /// </summary>
        public List<OrderModel> ListOrders
        {
            get { return listOrders; }
            set { listOrders = value; }
        }
        /// <summary>
        /// Agent.
        /// </summary>
        public AgentModel Agent
        {
            get { return agent; }
            set { agent = value; }
        }
        /// <summary>
        /// Customer information.
        /// </summary>
        public CustomerModel CustomerInfo
        {
            get { return customerInfo; }
            set { customerInfo = value; }
        }
        /// <summary>
        /// List of calls.
        /// </summary>
        public List<CallModel> ListCalls
        {
            get { return listCalls; }
            set { listCalls = value; }
        }
        /// <summary>
        /// User login information
        /// </summary>
        public UserLoginModel User
        {
            get { return user; }
            set { user = value; }
        }
        /// <summary>
        /// Temp data.
        /// </summary>
        public TempDataModel TempData
        {
            get
            {
                if (tempData != null)
                {
                    return tempData;
                }
                return new TempDataModel();
            }
            set { tempData = value; }
        }

        /// <summary>
        /// Current channel.
        /// </summary>
        public int CurrentChannel
        {
            get { return currentChannel; }
            set { currentChannel = value; }
        }
        /// <summary>
        /// Get User role.
        /// </summary>
        /// <returns>User role, if data is invalid, return RoleType.ROLETYPE_NUM</returns>
        public RoleType GetUserRole()
        {
            if (this.user != null)
            {
                return this.user.Role;
            }
            return RoleType.ROLETYPE_NUM;
        }
        /// <summary>
        /// Check if user is in Accounting Agent Role.
        /// </summary>
        /// <returns>True if User is Accounting Agent, False otherwise</returns>
        public bool IsAccountingAgentRole()
        {
            return GetUserRole().Equals(RoleType.ROLE_ACCOUNTING_AGENT) || GetUserRole().Equals(RoleType.ROLE_ACCOUNTING_ZONE);
        }
        /// <summary>
        /// Check if user is in Coordinator Role.
        /// </summary>
        /// <returns>True if User is Coordinator, False otherwise</returns>
        public bool IsCoordinatorRole()
        {
            return GetUserRole().Equals(RoleType.ROLE_DIEU_PHOI);
        }
        /// <summary>
        /// Get list of cities.
        /// </summary>
        /// <returns>Return list of cities in TempData</returns>
        public List<CityModel> GetListCities()
        {
            if (tempData != null && (tempData.List_province != null))
            {
                return tempData.List_province;
            }
            return new List<CityModel>();
        }
        /// <summary>
        /// Get list of streets.
        /// </summary>
        /// <returns>Return list of streets in TempData</returns>
        public List<StreetModel> GetListStreets()
        {
            if ((tempData != null) && (tempData.List_street != null))
            {
                return tempData.List_street;
            }
            return new List<StreetModel>();
        }
        /// <summary>
        /// Get list of delivers.
        /// </summary>
        /// <returns></returns>
        public List<SelectorModel> GetListDelivers()
        {
            if ((tempData != null) && (tempData.Employee_maintain != null))
            {
                return tempData.Employee_maintain.ToList();
            }
            return new List<SelectorModel>();
        }
        /// <summary>
        /// Get list of CCS.
        /// </summary>
        /// <returns></returns>
        public List<SelectorModel> GetListCCSs()
        {
            if ((tempData != null) && (tempData.Monitor_market_development != null))
            {
                return tempData.Monitor_market_development.ToList();
            }
            return new List<SelectorModel>();
        }
        /// <summary>
        /// Get list of all materials gas.
        /// </summary>
        /// <returns>List of all materials gas</returns>
        public Dictionary<string, MaterialModel> GetListMaterialGas()
        {
            if ((tempData != null) && (tempData.Material_gas != null))
            {
                Dictionary<string, MaterialModel> result = new Dictionary<string, MaterialModel>();
                foreach (MaterialModel item in tempData.Material_gas)
                {
                    result.Add(item.Materials_no, item);
                }
                return result;
            }
            return new Dictionary<string, MaterialModel>();
        }
        /// <summary>
        /// Get list of all materials promote.
        /// </summary>
        /// <returns>List of all materials promote</returns>
        public Dictionary<string, MaterialModel> GetListMaterialPromote()
        {
            if ((tempData != null) && (tempData.Material_promotion != null))
            {
                Dictionary<string, MaterialModel> result = new Dictionary<string, MaterialModel>();
                foreach (MaterialModel item in tempData.Material_promotion)
                {
                    result.Add(item.Materials_no, item);
                }
                return result;
            }
            return new Dictionary<string, MaterialModel>();
        }
        /// <summary>
        /// Get list of agents.
        /// </summary>
        /// <returns>List of all agents</returns>
        public List<SelectorModel> GetListAgents()
        {
            if ((tempData != null) && (tempData.Agent_list != null))
            {
                return tempData.Agent_list;
            }
            return new List<SelectorModel>();
        }
        /// <summary>
        /// Get name of agent by Agent id.
        /// </summary>
        /// <param name="agentId">Agent id</param>
        /// <returns>If agent id is exist, return name of agent, or return empty string otherwise</returns>
        public string GetAgentNameById(string agentId)
        {
            if ((tempData != null) && (tempData.Agent_list != null))
            {
                foreach (SelectorModel item in tempData.Agent_list)
                {
                    if (item.Id.Equals(agentId))
                    {
                        return item.Name;
                    }
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Get deliver name by Id.
        /// </summary>
        /// <param name="id">Id of deliver</param>
        /// <returns>Name of deliver, if id is not exist, return EMPTY</returns>
        public string GetDeliverNameById(string id)
        {
            string retVal = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                if ((tempData != null) && (tempData.Employee_maintain != null))
                {
                    foreach (SelectorModel deliver in tempData.Employee_maintain)
                    {
                        if (id.Equals(deliver.Id))
                        {
                            retVal = deliver.Name;
                            break;
                        }
                    }
                }
            }
            return retVal;
        }
        /// <summary>
        /// Get CCS name by Id.
        /// </summary>
        /// <param name="id">Id of CCS</param>
        /// <returns>Name of CCS, if id is not exist, return EMPTY</returns>
        public string GetCCSNameById(string id)
        {
            string retVal = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                if ((tempData != null) && (tempData.Monitor_market_development != null))
                {
                    foreach (SelectorModel ccs in tempData.Monitor_market_development)
                    {
                        if (id.Equals(ccs.Id))
                        {
                            retVal = ccs.Name;
                            break;
                        }
                    }
                }
            }
            return retVal;
        }
        /// <summary>
        /// Get deliver name in order.
        /// </summary>
        /// <param name="model">Order model</param>
        /// <returns>Name of deliver</returns>
        public string GetDeliverNameInOrder(OrderModel model)
        {
            string retVal = string.Empty;
            if (model != null)
            {
                // Get deliver name
                retVal = GetDeliverNameById(model.DeliverId);
                // If deliver does not exist
                if (String.IsNullOrEmpty(retVal))
                {
                    // Get CCS name
                    retVal = GetCCSNameById(model.CCSId) + Properties.Resources.CCSSuffix;
                }
            }
            return retVal;
        }
        //++ BUG0008-SPJ (NguyenPT 20160830) Order history
        /// <summary>
        /// Get Material name by Id.
        /// </summary>
        /// <param name="materialId">Id of material</param>
        /// <returns>Name of material</returns>
        public string GetMaterialNameFromId(string materialId)
        {
            if ((tempData != null) && (tempData.Material_gas != null))
            {
                foreach (MaterialModel item in tempData.Material_gas)
                {
                    if (materialId.Equals(item.Id))
                    {
                        return item.Name;
                    }
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Get Material No by Id.
        /// </summary>
        /// <param name="materialId">Id of material</param>
        /// <returns>No of material</returns>
        public string GetMaterialNoFromId(string materialId)
        {
            if ((tempData != null) && (tempData.Material_gas != null))
            {
                foreach (MaterialModel item in tempData.Material_gas)
                {
                    if (materialId.Equals(item.Id))
                    {
                        return item.Materials_no;
                    }
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Get Promote name by Id.
        /// </summary>
        /// <param name="materialId">Id of material</param>
        /// <returns>Name of promote</returns>
        public string GetPromoteNameFromId(string materialId)
        {
            if ((tempData != null) && (tempData.Material_promotion != null))
            {
                foreach (MaterialModel item in tempData.Material_promotion)
                {
                    if (materialId.Equals(item.Id))
                    {
                        return item.Name;
                    }
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Get Promote No by Id.
        /// </summary>
        /// <param name="materialId">Id of material</param>
        /// <returns>No of promote</returns>
        public string GetPromoteNoFromId(string materialId)
        {
            if ((tempData != null) && (tempData.Material_promotion != null))
            {
                foreach (MaterialModel item in tempData.Material_promotion)
                {
                    if (materialId.Equals(item.Id))
                    {
                        return item.Materials_no;
                    }
                }
            }
            return string.Empty;
        }
        //-- BUG0008-SPJ (NguyenPT 20160830) Order history
        #endregion

        #region Singleton Instance
        /// <summary>
        /// Instance
        /// </summary>
        private static DataPure instance;
        /// <summary>
        /// Constructor.
        /// </summary>
        private DataPure()
        {
            this.listCalls             = new List<CallModel>();
            this.listOrders            = new List<OrderModel>();
            this.agent                 = new AgentModel();
            this.tempData              = new TempDataModel();
            this.listRecentProductsImg = new Dictionary<string, MaterialBitmap>();
            this.listRecentPromotesImg = new Dictionary<string, MaterialBitmap>();
        }
        /// <summary>
        /// Get instance
        /// </summary>
        public static DataPure Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataPure();
                }
                return instance;
            }
        }
        #endregion
    }
}
