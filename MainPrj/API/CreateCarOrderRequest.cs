using MainPrj.Model.Response;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MainPrj.API
{
    /// <summary>
    /// Create card order request class
    /// </summary>
    class CreateCarOrderRequest : BaseRequest
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateCarOrderRequest()
            : base(Properties.Resources.API_CREATE_CAR_ORDER)
        {
            this._respType = typeof(CreateCarOrderRespModel);
        }

        /// <summary>
        /// Request 
        /// </summary>
        /// <param name="customerId">Customer Id</param>
        /// <param name="user_id_executive">User id executive</param>
        /// <param name="b50">Quantity of 50kg type</param>
        /// <param name="b45">Quantity of 45kg type</param>
        /// <param name="b12">Quantity of 12kg type</param>
        /// <param name="b6">Quantity of 6kg type</param>
        /// <param name="progressChangedHandler">Upload progress changed event handler</param>
        /// <param name="completedHandler">Completion action</param>
        public static void requestCreateCarOrder(String customerId, String user_id_executive,
            String b50, String b45, String b12, String b6,
            UploadProgressChangedEventHandler progressChangedHandler,
            MainPrj.Util.CommonProcess.CompletionAction completedHandler)
        {
            CreateCarOrderRequest request = new CreateCarOrderRequest();
            request._data = String.Format("{{\"token\":\"{0}\", \"customer_id\":\"{1}\", \"user_id_executive\":\"{2}\", \"b50\":\"{3}\", \"b45\":\"{4}\", \"b12\":\"{5}\", \"b6\":\"{6}\"}}",
                        Properties.Settings.Default.UserToken,
                        customerId, user_id_executive,
                        b50, b45, b12, b6);
            request._progressChangedHandler = progressChangedHandler;
            request._completionAction = completedHandler;
            request.ExecuteAsync();
        }

        protected override void ConvertData(System.Runtime.Serialization.Json.DataContractJsonSerializer js, System.IO.MemoryStream msU)
        {
            // Convert json to object
            CreateCarOrderRespModel resp = (CreateCarOrderRespModel)js.ReadObject(msU);
            if (resp != null)
            {
                // Response result is success
                if (resp.Status.Equals(Properties.Resources.RESPONSE_STATUS_SUCCESS))
                {
                    if (this._completionAction != null)
                    {
                        this._completionAction(resp);
                    }
                }
                else
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + resp.Message);
                }
            }
        }
    }
}
