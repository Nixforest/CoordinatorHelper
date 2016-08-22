﻿using MainPrj.Util;
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
    public class UpdateOrderModel
    {
        [DataMember(Name = "token", IsRequired = false)]
        protected string token;
        [DataMember(Name = "id", IsRequired = false)]
        protected string id;
        [DataMember(Name = "order_detail", IsRequired = false)]
        protected List<OrderDetailModel> order_detail;
        [DataMember(Name = "note", IsRequired = false)]
        protected string note;
        [DataMember(Name = "status", IsRequired = false)]
        protected int status;
        //++ BUG0011-SPJ (NguyenPT 20160822) Add Created date property
        [DataMember(Name = "created_date", IsRequired = false)]
        private string created_date;

        /// <summary>
        /// Created date.
        /// </summary>
        public string Created_date
        {
            get { return created_date; }
            set { created_date = value; }
        }
        //-- BUG0011-SPJ (NguyenPT 20160822) Add Created date property
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
        /// Id.
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
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
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(UpdateOrderModel));
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
