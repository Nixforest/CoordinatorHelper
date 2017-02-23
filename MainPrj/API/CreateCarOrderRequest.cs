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
        /// <param name="note">Note of customer</param>
        /// <param name="progressChangedHandler">Upload progress changed event handler</param>
        /// <param name="completedHandler">Completion action</param>
        public static void requestCreateCarOrder(String customerId, String user_id_executive,
            String b50, String b45, String b12, String b6, String note,
            UploadProgressChangedEventHandler progressChangedHandler,
            MainPrj.Util.CommonProcess.CompletionAction completedHandler)
        {
            CreateCarOrderRequest request = new CreateCarOrderRequest();
            request._data = String.Format("{{\"{0}\":\"{1}\", \"{2}\":\"{3}\", \"{4}\":\"{5}\", \"{6}\":\"{7}\", \"{8}\":\"{9}\", \"{10}\":\"{11}\", \"{12}\":\"{13}\", \"{14}\":\"{15}\"}}",
                        DomainConst.KEY_TOKEN, Properties.Settings.Default.UserToken,
                        DomainConst.KEY_CUSTOMER_ID, customerId,
                        DomainConst.KEY_USER_ID_EXECUTIVE, user_id_executive,
                        DomainConst.KEY_B50, b50,
                        DomainConst.KEY_B45, b45,
                        DomainConst.KEY_B12, b12,
                        DomainConst.KEY_B6, b6,
                        DomainConst.KEY_NOTE, note);
            request._progressChangedHandler = progressChangedHandler;
            request._completionAction = completedHandler;
            request.ExecuteAsync();
        }

        /// <summary>
        /// Convert response data to object
        /// </summary>
        /// <param name="js">DataContractJsonSerializer</param>
        /// <param name="msU">MemoryStream</param>
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
