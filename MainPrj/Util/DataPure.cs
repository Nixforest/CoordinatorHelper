using MainPrj.Model;
using MainPrj.Model.Address;
using System;
using System.Collections.Generic;
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
        private int currentChannel          = 0;
        private TempDataModel tempData      = null;
        private UserLoginModel user         = null;
        private List<CallModel> listCalls   = null;
        private CustomerModel customerInfo  = null;
        private AgentModel agent            = null;
        private List<OrderModel> listOrders = null;
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
            get { return tempData; }
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
            return GetUserRole().Equals(RoleType.ROLE_ACCOUNTING_AGENT);
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
            else
            {
                return new List<CityModel>();
            }
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
            else
            {
                return new List<StreetModel>();
            }
        }
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
            this.listCalls  = new List<CallModel>();
            this.listOrders = new List<OrderModel>();
            this.agent      = new AgentModel();
            this.tempData   = new TempDataModel();
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
