using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Response data from server.
    /// </summary>
    [DataContract]
    public class BaseResponseModel
    {
        [DataMember(Name = "status", IsRequired = true)]
        protected string status;
        [DataMember(Name = "code", IsRequired = true)]
        protected string code;
        [DataMember(Name = "message", IsRequired = true)]
        protected string message;
        [DataMember(Name = "token", IsRequired = false)]
        protected string token;
        /// <summary>
        /// Response status.
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// Response code.
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        /// <summary>
        /// Response message.
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        /// <summary>
        /// Response token.
        /// </summary>
        public string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}
