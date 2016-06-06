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

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        [DataMember(Name = "code", IsRequired = true)]
        protected string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        [DataMember(Name = "message", IsRequired = true)]
        protected string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        [DataMember(Name = "token", IsRequired = false)]
        protected string token;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}
