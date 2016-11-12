using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Model of call data.
    /// </summary>
    [DataContract]
    public class CallModel : IComparable<CallModel>
    {
        [DataMember(Name = "id", IsRequired = false)]
        private string id;
        [DataMember(Name = "channel", IsRequired = false)]
        private int channel;
        [DataMember(Name = "customer", IsRequired = false)]
        private CustomerModel customer;
        [DataMember(Name = "phone", IsRequired = false)]
        private string phone;
        [DataMember(Name = "status", IsRequired = false)]
        private int status;
        [DataMember(Name = "type", IsRequired = false)]
        private CallType type;
        [DataMember(Name = "isFinish", IsRequired = false)]
        private bool isFinish = false;
        //++ BUG0006-SPJ (NguyenPT 20161111) Call history
        [DataMember(Name = "type_call", IsRequired = false)]
        private string type_call;
        [DataMember(Name = "order_id", IsRequired = false)]
        private string order_id;
        [DataMember(Name = "file_record_name", IsRequired = false)]
        private string file_record_name;
        [DataMember(Name = "call_id", IsRequired = false)]
        private string call_id = string.Empty;
        [DataMember(Name = "created_date", IsRequired = false)]
        private string created_date;
        [DataMember(Name = "agent_id", IsRequired = false)]
        private string agent_id;
        [DataMember(Name = "user_id", IsRequired = false)]
        private string user_id;
        [DataMember(Name = "token", IsRequired = false)]
        private string token;

        /// <summary>
        /// Token
        /// </summary>
        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        /// <summary>
        /// User id
        /// </summary>
        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        /// <summary>
        /// Agent id
        /// </summary>
        public string Agent_id
        {
            get { return agent_id; }
            set { agent_id = value; }
        }

        /// <summary>
        /// Id of model.
        /// </summary>
        public string CallId
        {
            get { return call_id; }
            set { call_id = value; }
        }

        /// <summary>
        /// Created date
        /// </summary>
        public string Created_date
        {
            get { return created_date; }
            set { created_date = value; }
        }

        /// <summary>
        /// Name of record file
        /// </summary>
        public string File_record_name
        {
            get
            {
                return String.IsNullOrEmpty(file_record_name) ? string.Empty : file_record_name;
            }
            set { file_record_name = value; }
        }

        /// <summary>
        /// Order id
        /// </summary>
        public string Order_id
        {
            get
            {
                return String.IsNullOrEmpty(order_id) ? string.Empty : order_id;
            }
            set { order_id = value; }
        }

        /// <summary>
        /// Type of call:
        /// 0 - Other type
        /// 1 - Create customer
        /// 2 - Create order
        /// 3 - Request price
        /// 4 - Customer comment
        /// 5 - Repeat order
        /// </summary>
        public string Type_call
        {
            get
            {
                return String.IsNullOrEmpty(type_call) ? string.Empty : type_call;
            }
            set { type_call = value; }
        }
        //-- BUG0006-SPJ (NguyenPT 20161111) Call history

        /// <summary>
        /// Id of model.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Channel.
        /// </summary>
        public int Channel
        {
            get { return channel; }
            set { channel = value; }
        }
        /// <summary>
        /// Customer information.
        /// </summary>
        public CustomerModel Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        /// <summary>
        /// Incomming phone.
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        /// <summary>
        /// Status of call.
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// Type of call.
        /// </summary>
        public CallType Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// Call is handled.
        /// </summary>
        public bool IsFinish
        {
            get { return isFinish; }
            set { isFinish = value; }
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="incommingTime">Incomming Time</param>
        /// <param name="channel">Channel</param>
        /// <param name="customer">Customer</param>
        /// <param name="phone">Phone number</param>
        /// <param name="status">Status</param>
        public CallModel(DateTime incommingTime, int channel, CustomerModel customer,
            string phone, int status)
        {
            this.id               = incommingTime.ToString(Properties.Settings.Default.CallIdFormat);
            this.channel          = channel;
            this.customer         = customer;
            this.phone            = phone;
            this.status           = status;
            this.type             = CallType.CALLTYPE_NUM;
            this.isFinish = false;
            //++ BUG0006-SPJ (NguyenPT 20161111) Call history
            this.order_id         = "";
            this.file_record_name = "";
            this.created_date     = incommingTime.ToString(Properties.Resources.CallDateTimeFormat);
            this.type_call        = "";
            //-- BUG0006-SPJ (NguyenPT 20161111) Call history
        }
        
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = String.Empty;
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CallModel));
            using (var msU = new MemoryStream())
            {
                try
                {
                    js.WriteObject(msU, this);
                    msU.Position = 0;
                    var sr       = new StreamReader(msU);
                    retVal       = sr.ReadToEnd();
                    sr.Close();
                }
                catch (Exception ex)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                }
            }
            return retVal;
        }
        /// <summary>
        /// Check if keyword is contained inside object.
        /// </summary>
        /// <param name="keyword">Keyword</param>
        /// <returns>True if contained, False otherwise</returns>
        public bool IsContainString(string keyword)
        {
            bool result = false;
            if (String.IsNullOrEmpty(keyword))
            {
                return true;
            }
            result |= CommonProcess.NormalizationString(this.phone).Contains(keyword.ToLower());
            result |= CommonProcess.NormalizationString(this.customer.Name.ToLower()).Contains(keyword.ToLower());
            result |= CommonProcess.NormalizationString(this.customer.Address.ToLower()).Contains(keyword.ToLower());
            return result;
        }
        /// <summary>
        /// Compare delegate
        /// </summary>
        /// <param name="other">Compared object</param>
        /// <returns>Id compare result</returns>
        public int CompareTo(CallModel other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return other.Id.CompareTo(this.Id);
            }
        }
    }
}
