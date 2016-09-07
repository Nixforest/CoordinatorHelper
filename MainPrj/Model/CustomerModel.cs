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
    [DataContract]
    /// <summary>
    /// Customer datamodel.
    /// </summary>
    public class CustomerModel
    {
        [DataMember(Name = "customer_id", IsRequired = true)]
        private string customer_id;
        [DataMember(Name = "customer_name", IsRequired = true)]
        private string customer_name;
        [DataMember(Name = "customer_address", IsRequired = true)]
        private string customer_address;
        [DataMember(Name = "customer_phone", IsRequired = true)]
        private string customer_phone;
        [DataMember(Name = "customer_agent", IsRequired = true)]
        private string customer_agent;
        [DataMember(Name = "customer_type", IsRequired = true)]
        private string customer_type;
        [DataMember(Name = "contact", IsRequired = false)]
        private string contact;
        [DataMember(Name = "contact_note", IsRequired = false)]
        private string contact_note;
        [DataMember(Name = "sale_name", IsRequired = true)]
        private string sale_name;
        [DataMember(Name = "sale_phone", IsRequired = true)]
        private string sale_phone;
        [DataMember(Name = "sale_type", IsRequired = true)]
        private string sale_type;
        [DataMember(Name = "customer_delivery_agent", IsRequired = false)]
        private string agencyNearest;
        [DataMember(Name = "activePhone", IsRequired = false)]
        private string activePhone;
        [DataMember(Name = "agent_id", IsRequired = false)]
        private string agent_id;
        //++ BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
        [DataMember(Name = "customer_delivery_agent_id", IsRequired = false)]
        private string customer_delivery_agent_id;

        /// <summary>
        /// Id of agent delivery.
        /// </summary>
        public string Customer_delivery_agent_id
        {
            get { return customer_delivery_agent_id; }
            set { customer_delivery_agent_id = value; }
        }
        //-- BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
        /// <summary>
        /// Agent id.
        /// </summary>
        public string Agent_id
        {
            get { return agent_id; }
            set { agent_id = value; }
        }
        /// <summary>
        /// Id.
        /// </summary>
        public string Id
        {
            get { return customer_id; }
            set { customer_id = value; }
        }

        public string Name
        {
            get { return customer_name; }
            set { customer_name = value; }
        }

        public string Address
        {
            //++ BUG0067-SPJ (NguyenPT 20160904) Replace html character
            //get { return customer_address; }
            get { return customer_address.Replace("&gt;", ">").Replace("&lt;", "<"); }
            //-- BUG0067-SPJ (NguyenPT 20160904) Replace html character
            set { customer_address = value; }
        }

        public string PhoneList
        {
            get { return customer_phone; }
            set { customer_phone = value; }
        }

        public string AgencyName
        {
            get { return customer_agent; }
            set { customer_agent = value; }
        }

        public string CustomerType
        {
            get { return customer_type; }
            set { customer_type = value; }
        }

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public string Contact_note
        {
            get { return contact_note; }
            set { contact_note = value; }
        }

        public string Sale_name
        {
            get { return sale_name; }
            set { sale_name = value; }
        }

        public string Sale_phone
        {
            get { return sale_phone; }
            set { sale_phone = value; }
        }

        public string Sale_type
        {
            get { return sale_type; }
            set { sale_type = value; }
        }

        public string AgencyNearest
        {
            get { return agencyNearest; }
            set { agencyNearest = value; }
        }

        public string ActivePhone
        {
            get
            {
                //++ BUG0002-SPJ (NguyenPT 20160904) If active phone is not exist, take phonelist
                if (string.IsNullOrEmpty(activePhone))
                {
                    string[] phoneList = PhoneList.Split(Properties.Settings.Default.PhoneListToken.ToCharArray());
                    if ((phoneList != null) && (phoneList.Length > 0))
                    {
                        return phoneList[0];
                    }
                }
                //-- BUG0002-SPJ (NguyenPT 20160904) If active phone is not exist, take phonelist
                return activePhone;
            }
            set { activePhone = value; }
        }


        //private string note;

        //public string Note
        //{
        //    get { return note; }
        //    set { note = value; }
        //}
        public CustomerModel()
        {
            this.customer_id      = String.Empty;
            this.customer_name    = String.Empty;
            this.customer_address = String.Empty;
            this.customer_phone   = String.Empty;
            this.customer_agent   = String.Empty;
            this.customer_type    = String.Empty;
            this.contact          = String.Empty;
            this.contact_note     = String.Empty;
            this.sale_name        = String.Empty;
            this.sale_phone       = String.Empty;
            this.sale_type        = String.Empty;
            this.agencyNearest    = String.Empty;
            this.activePhone      = String.Empty;
            //this.note           = String.Empty;
        }
        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="copy">Copy object</param>
        public CustomerModel(CustomerModel copy)
        {
            this.customer_id                = copy.customer_id      ;
            this.customer_name              = copy.customer_name    ;
            this.customer_address           = copy.customer_address ;
            this.customer_phone             = copy.customer_phone   ;
            this.customer_agent             = copy.customer_agent   ;
            this.customer_type              = copy.customer_type;
            this.contact                    = copy.contact          ;
            this.contact_note               = copy.contact_note     ;
            this.sale_name                  = copy.sale_name        ;
            this.sale_phone                 = copy.sale_phone       ;
            this.sale_type                  = copy.sale_type        ;
            this.agencyNearest              = copy.agencyNearest;
            this.activePhone                = copy.activePhone;
            //this.note                     = copy;
            //++ BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
            this.agent_id                   = copy.agent_id;
            this.customer_delivery_agent_id = copy.customer_delivery_agent_id;
            //-- BUG0069-SPJ (NguyenPT 20160905) Choose delivery agent
        }
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>String object</returns>
        public override string ToString()
        {
            string retVal = String.Empty;
            MemoryStream msU = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CustomerModel));
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
