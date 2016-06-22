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
            this.id       = incommingTime.ToString(Properties.Settings.Default.CallIdFormat);
            this.channel  = channel;
            this.customer = customer;
            this.phone    = phone;
            this.status   = status;
            this.type     = CallType.CALLTYPE_NUM;
            this.isFinish = false;
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
