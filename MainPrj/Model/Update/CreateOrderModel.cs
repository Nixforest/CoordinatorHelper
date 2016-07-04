using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MainPrj.Model.Update
{
    /// <summary>
    /// Create order model.
    /// </summary>
    [DataContract]
    public class CreateOrderModel
    {
        [DataMember(Name = "token", IsRequired = false)]
        protected string token;
        [DataMember(Name = "customer_id", IsRequired = false)]
        protected string customer_id;
        [DataMember(Name = "agent_id", IsRequired = false)]
        protected string agent_id;
        [DataMember(Name = "employee_maintain_id", IsRequired = false)]
        protected string employee_maintain_id;
        [DataMember(Name = "monitor_market_development_id", IsRequired = false)]
        protected string monitor_market_development_id;
        [DataMember(Name = "order_detail", IsRequired = false)]
        protected List<OrderDetailModel> order_detail;
        [DataMember(Name = "note", IsRequired = false)]
        protected string note;
        [DataMember(Name = "status", IsRequired = false)]
        protected int status;
        /// <summary>
        /// Status of order.
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// Note of order.
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        /// <summary>
        /// Order details.
        /// </summary>
        public List<OrderDetailModel> Order_detail
        {
            get { return order_detail; }
            set { order_detail = value; }
        }
        /// <summary>
        /// CCS id.
        /// </summary>
        public string Monitor_market_development_id
        {
            get { return monitor_market_development_id; }
            set { monitor_market_development_id = value; }
        }
        /// <summary>
        /// Deliver id.
        /// </summary>
        public string Employee_maintain_id
        {
            get { return employee_maintain_id; }
            set { employee_maintain_id = value; }
        }
        /// <summary>
        /// Agent id.
        /// </summary>
        public string Agent_id
        {
            get { return agent_id; }
            set { agent_id = value; }
        }
        /// <summary>
        /// Customer id.
        /// </summary>
        public string Customer_id
        {
            get { return customer_id; }
            set { customer_id = value; }
        }
        /// <summary>
        /// User token.
        /// </summary>
        public string Token
        {
            get { return token; }
            set { token = value; }
        }
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = String.Empty;
            MemoryStream msU = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CreateOrderModel));
            try
            {
                js.WriteObject(msU, this);
                msU.Position = 0;
                var sr = new StreamReader(msU);
                retVal = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
            }
            return retVal;
        }
    }
}
