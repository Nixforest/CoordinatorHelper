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
        /// <summary>
        /// Id.
        /// </summary>
        public string Id
        {
            get { return customer_id; }
            set { customer_id = value; }
        }
        [DataMember(Name = "customer_name", IsRequired = true)]
        private string customer_name;

        public string Name
        {
            get { return customer_name; }
            set { customer_name = value; }
        }
        [DataMember(Name = "customer_address", IsRequired = true)]
        private string customer_address;

        public string Address
        {
            get { return customer_address; }
            set { customer_address = value; }
        }
        [DataMember(Name = "customer_phone", IsRequired = true)]
        private string customer_phone;

        public string PhoneList
        {
            get { return customer_phone; }
            set { customer_phone = value; }
        }
        [DataMember(Name = "customer_agent", IsRequired = true)]
        private string customer_agent;

        public string AgencyName
        {
            get { return customer_agent; }
            set { customer_agent = value; }
        }
        [DataMember(Name = "customer_type", IsRequired = true)]
        private string customer_type;

        public string CustomerType
        {
            get { return customer_type; }
            set { customer_type = value; }
        }
        [DataMember(Name = "contact", IsRequired = false)]
        private string contact;

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        [DataMember(Name = "contact_note", IsRequired = false)]
        private string contact_note;

        public string Contact_note
        {
            get { return contact_note; }
            set { contact_note = value; }
        }
        [DataMember(Name = "sale_name", IsRequired = true)]
        private string sale_name;

        public string Sale_name
        {
            get { return sale_name; }
            set { sale_name = value; }
        }
        [DataMember(Name = "sale_phone", IsRequired = true)]
        private string sale_phone;

        public string Sale_phone
        {
            get { return sale_phone; }
            set { sale_phone = value; }
        }
        [DataMember(Name = "sale_type", IsRequired = true)]
        private string sale_type;

        public string Sale_type
        {
            get { return sale_type; }
            set { sale_type = value; }
        }
        [DataMember(Name = "customer_delivery_agent", IsRequired = false)]
        private string agencyNearest;

        public string AgencyNearest
        {
            get { return agencyNearest; }
            set { agencyNearest = value; }
        }

        //private string note;

        //public string Note
        //{
        //    get { return note; }
        //    set { note = value; }
        //}
        public CustomerModel()
        {
            this.customer_id = String.Empty;
            this.customer_name = String.Empty;
            this.customer_address = String.Empty;
            this.customer_phone = String.Empty;
            this.customer_agent = String.Empty;
            this.customer_type = String.Empty;
            this.contact = String.Empty;
            this.contact_note = String.Empty;
            this.sale_name = String.Empty;
            this.sale_phone = String.Empty;
            this.sale_type = String.Empty;
            this.agencyNearest = String.Empty;
            //this.note = String.Empty;
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
