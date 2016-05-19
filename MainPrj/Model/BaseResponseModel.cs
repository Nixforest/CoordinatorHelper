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
    class BaseResponseModel
    {
        [DataMember(Name = "status", IsRequired = true)]
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        [DataMember(Name = "code", IsRequired = true)]
        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        [DataMember(Name = "message", IsRequired = true)]
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        [DataMember(Name = "record", IsRequired = false)]
        private CustomerModel[] record;

        public CustomerModel[] Record
        {
            get { return record; }
            set { record = value; }
        }
    }
}
