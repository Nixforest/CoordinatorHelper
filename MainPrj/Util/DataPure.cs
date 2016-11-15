using MainPrj.Model;
using MainPrj.Model.Address;
using PcapDotNet.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        //++ BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
        private Dictionary<string, List<OrderModel>> listOrderHistory    = null;
        //-- BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance

        //++ BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
        private Dictionary<string, NotificationModel> listNotification = null;
        private bool isCloseWebSocketConnection                        = false;
        private WebSocketSharp.WebSocket webSocket                     = null;
        private Form _mainForm                                         = null;
        /// <summary>
        /// Flag check if websocket is connecting.
        /// </summary>
        public bool IsCloseWebSocketConnection
        {
            get { return isCloseWebSocketConnection; }
            set { isCloseWebSocketConnection = value; }
        }
        /// <summary>
        /// Return main form.
        /// </summary>
        public Form MainForm
        {
            get { return _mainForm; }
            set { _mainForm = value; }
        }
        /// <summary>
        /// List notification
        /// </summary>
        internal Dictionary<string, NotificationModel> ListNotification
        {
            get { return listNotification; }
            set { listNotification = value; }
        }
        /// <summary>
        /// Get count of new notifications.
        /// </summary>
        /// <returns>Count of new notifications</returns>
        public int GetNewNotificationCount()
        {
            int retVal = 0;
            foreach (var item in this.listNotification.Values)
            {
                if (item.IsNew)
                {
                    retVal += 1;
                }
            }
            return retVal;
        }
        /// <summary>
        /// Websocket object.
        /// </summary>
        public WebSocketSharp.WebSocket WebSocket
        {
            get { return webSocket; }
            set { webSocket = value; }
        }
        //-- BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
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
        //++ BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
        /// <summary>
        /// List order histories.
        /// </summary>
        public Dictionary<string, List<OrderModel>> ListOrderHistory
        {
            get { return listOrderHistory; }
            set { listOrderHistory = value; }
        }
        //-- BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
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

        //++ BUG0006-SPJ (NguyenPT 20161111) Call history
        /// <summary>
        /// Get list of type call.
        /// </summary>
        /// <returns>List of type call</returns>
        public List<SelectorModel> GetListCallType()
        {
            if ((tempData != null) && (tempData.List_order_reason != null))
            {
                return tempData.List_order_reason;
            }
            return new List<SelectorModel>();
        }

        /// <summary>
        /// Get type call string.
        /// </summary>
        /// <param name="id">Id of type call</param>
        /// <returns>Name of type call</returns>
        public string GetTypeCallString(string id)
        {
            foreach (SelectorModel item in this.GetListCallType())
            {
                if (item.Id.Equals(id))
                {
                    return item.Name;
                }
            }
            return string.Empty;
        }
        //-- BUG0006-SPJ (NguyenPT 20161111) Call history

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
        //++ BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
        /// <summary>
        /// Mard notification as read.
        /// </summary>
        /// <param name="id">Notify id</param>
        public void MarkNotificationAsRead(string id)
        {
            if (this.ListNotification.ContainsKey(id))
            {
                this.ListNotification[id].IsNew = false;
            }
        }
        //-- BUG0084-SPJ (NguyenPT 20161004) Web socket Notification

        //++ BUG0006-SPJ (NguyenPT 20161111) Call history
        /// <summary>
        /// Upate order id value to call model.
        /// </summary>
        /// <param name="callId">Id of call model</param>
        /// <param name="orderId">Order id</param>
        public void UpdateOrderIdToCallModel(string callId, string orderId)
        {
            if (!String.IsNullOrEmpty(callId))
            {
                foreach (CallModel item in this.listCalls)
                {
                    if (item.Id.Equals(callId))
                    {
                        item.Order_id = orderId;

                        CommonProcess.RequestCreateCallHistory(item);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Upate type of call value to call model.
        /// </summary>
        /// <param name="callId">Id of call model</param>
        /// <param name="typeCall">Order id</param>
        public void UpdateTypeCallToCallModel(string callId, string typeCall)
        {
            if (!String.IsNullOrEmpty(callId))
            {
                foreach (CallModel item in this.listCalls)
                {
                    if (item.Id.Equals(callId))
                    {
                        item.Type_call = typeCall;
                        CommonProcess.RequestCreateCallHistory(item);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Get type call string from call id.
        /// </summary>
        /// <param name="callId">Id of call</param>
        /// <returns>Type call</returns>
        public string GetTypeCallByCallId(string callId)
        {
            if (!String.IsNullOrEmpty(callId))
            {
                foreach (CallModel item in this.listCalls)
                {
                    if (item.Id.Equals(callId))
                    {
                        return item.Type_call;
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Get call model from call id.
        /// </summary>
        /// <param name="callId">Id of call</param>
        /// <returns>Model of call</returns>
        public CallModel GetCallModelByCallId(string callId)
        {
            if (!String.IsNullOrEmpty(callId))
            {
                foreach (CallModel item in this.listCalls)
                {
                    if (item.Id.Equals(callId))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Upate type of call value to call model.
        /// </summary>
        /// <param name="callId">Id of call model</param>
        /// <param name="typeCall">Order id</param>
        public void UpdateRecordToCallModel(string callId, string recordName)
        {
            if (!String.IsNullOrEmpty(callId))
            {
                foreach (CallModel item in this.listCalls)
                {
                    if (item.Id.Equals(callId))
                    {
                        item.File_record_name = recordName;
                        CommonProcess.RequestCreateCallHistory(item);
                        break;
                    }
                }
            }
        }
        //-- BUG0006-SPJ (NguyenPT 20161111) Call history
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
            //++ BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
            this.listOrderHistory      = new Dictionary<string, List<OrderModel>>();
            //-- BUG0066-SPJ (NguyenPT 20160904) Increate List Order view performance
            //++ BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
            this.listNotification = new Dictionary<string, NotificationModel>();
            this._mainForm        = new Form();
            //-- BUG0084-SPJ (NguyenPT 20161004) Web socket Notification
            //NotificationModel model = new NotificationModel();
            //model.Id = "1";
            //model.Sender = "Trần Quang Chương";
            //model.Role = "17";
            //model.Message = "đã tạo một đơn hàng mới cho Khách hàng Quán Biển Đông";
            //string dateTime = "30/09/2016 12:50:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //this.listNotification.Add(model.Id, model);
            //model = new NotificationModel();
            //model.Id = "2";
            //model.Sender = "Phạm Thị Nguyệt";
            //model.Role = "9";
            //model.Message = "đã xác nhận đơn hàng mới cho Khách hàng Quán Biển Đông";
            //dateTime = "30/09/2016 13:50:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //model.IsNew = false;
            //this.listNotification.Add(model.Id, model);
            //model = new NotificationModel();
            //model.Id = "3";
            //model.Sender = "Đường Thị Thảo";
            //model.Role = "9";
            //model.Message = "đã xác nhận đơn hàng mới cho Khách hàng Quán Hủ Tiếu Nam Vang";
            //dateTime = "30/09/2016 14:30:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //this.listNotification.Add(model.Id, model);
            //model = new NotificationModel();
            //model.Id = "4";
            //model.Sender = "Đường Thị Thảo";
            //model.Role = "9";
            //model.Message = "đã xác nhận đơn hàng mới cho Khách hàng Quán Hủ Tiếu Nam Vang";
            //dateTime = "30/09/2016 14:50:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //this.listNotification.Add(model.Id, model);
            //model = new NotificationModel();
            //model.Id = "5";
            //model.Sender = "Phạm Ngọc Thùy Trang";
            //model.Role = "17";
            //model.Message = "đã tạo một đơn hàng mới cho Khách hàng Lẩu Dê 79";
            //dateTime = "30/09/2016 17:50:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //model.IsNew = false;
            //this.listNotification.Add(model.Id, model);
            //model = new NotificationModel();
            //model.Id = "6";
            //model.Sender = "Trần Thị Phượng";
            //model.Role = "9";
            //model.Message = "đã xác nhận đơn hàng mới cho Khách hàng Lẩu Dê 79";
            //dateTime = "01/10/2016 11:15:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //model.IsNew = true;
            //this.listNotification.Add(model.Id, model);
            //model = new NotificationModel();
            //model.Id = "7";
            //model.Sender = "Trần Thị Phượng";
            //model.Role = "9";
            //model.Message = "đã xác nhận đơn hàng mới cho Khách hàng Lẩu Dê 79";
            //dateTime = "01/10/2016 11:15:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //model.IsNew = true;
            //this.listNotification.Add(model.Id, model);
            //model = new NotificationModel();
            //model.Id = "8";
            //model.Sender = "Trần Thị Phượng";
            //model.Role = "9";
            //model.Message = "đã xác nhận đơn hàng mới cho Khách hàng Lẩu Dê 79";
            //dateTime = "01/10/2016 11:15:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //model.IsNew = true;
            //this.listNotification.Add(model.Id, model);
            //model = new NotificationModel();
            //model.Id = "9";
            //model.Sender = "Trần Thị Phượng";
            //model.Role = "9";
            //model.Message = "đã xác nhận đơn hàng mới cho Khách hàng Lẩu Dê 79";
            //dateTime = "01/10/2016 11:15:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //model.IsNew = true;
            //this.listNotification.Add(model.Id, model);
            //model = new NotificationModel();
            //model.Id = "10";
            //model.Sender = "Trần Thị Phượng";
            //model.Role = "9";
            //model.Message = "đã xác nhận đơn hàng mới cho Khách hàng Lẩu Dê 79";
            //dateTime = "01/10/2016 11:15:50.42";
            ////model.NotifyTime = Convert.ToDateTime(dateTime);
            //model.NotifyTime = dateTime;
            //model.IsNew = true;
            //this.listNotification.Add(model.Id, model); model = new NotificationModel();
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
