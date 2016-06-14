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
