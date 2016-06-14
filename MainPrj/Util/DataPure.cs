using MainPrj.Model;
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
        private int currentChannel         = 0;
        private TempDataModel tempData     = null;
        private UserLoginModel user        = null;
        private List<CallModel> listCalls  = null;
        private CustomerModel customerInfo = null;
        private SelectorModel agent = null;
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
        public SelectorModel Agent
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
            this.listCalls = new List<CallModel>();
            this.listOrders = new List<OrderModel>();
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
