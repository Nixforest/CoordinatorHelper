using MainPrj.Model;
using MainPrj.Model.Response;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MainPrj.API
{
    /// <summary>
    /// Base request object
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// Request url.
        /// </summary>
        protected String _url = String.Empty;

        /// <summary>
        /// Request data.
        /// </summary>
        protected String _data = String.Empty;

        /// <summary>
        /// Response object type.
        /// </summary>
        protected Type _respType = typeof(BaseResponseModel);

        /// <summary>
        /// Upload progress changed event handler.
        /// </summary>
        protected UploadProgressChangedEventHandler _progressChangedHandler = null;

        /// <summary>
        /// Completion action.
        /// </summary>
        protected MainPrj.Util.CommonProcess.CompletionAction _completionAction = null;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">Request url</param>
        /// <param name="data">Request data</param>
        public BaseRequest(String url, String data)
        {
            this._url = url;
            this._data = data;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">Request url</param>
        public BaseRequest(String url)
        {
            this._url = url;
            this._data = String.Empty;
        }

        /// <summary>
        /// Execute async request.
        /// </summary>
        public void ExecuteAsync()
        {
            using (WebClient client = new WebClient())
            {
                if (this._progressChangedHandler != null)
                {
                    client.UploadProgressChanged += this._progressChangedHandler;
                }
                else
                {
                    client.UploadProgressChanged += progressChanged;
                }

                client.UploadValuesCompleted += completedHandler;
                
                try
                {
                    client.UploadValuesAsync(
                        new Uri(Properties.Settings.Default.ServerURL + this._url),
                        new NameValueCollection()
                        {
                            { Properties.Resources.JSON_ROOT_KEY, this._data }
                        });
                }
                catch (System.Net.WebException)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.InternetConnectionError);
                    CommonProcess.HasError = true;
                }
            }
        }
        
        /// <summary>
        /// Execute request.
        /// </summary>
        public virtual void Execute()
        {
            
        }

        /// <summary>
        /// Progress changed handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        protected virtual void progressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Completed handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        protected virtual void completedHandler(object sender, UploadValuesCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + Properties.Resources.Cancel);
                CommonProcess.HasError = true;
            }
            else if (e.Error != null)
            {
                CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + e.Error.Message);
                CommonProcess.HasError = true;
            }
            else
            {
                byte[] response = e.Result;
                string respStr = String.Empty;
                respStr = System.Text.Encoding.UTF8.GetString(response);
                Console.Write(respStr);
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(_respType);
                    byte[] encodingBytes = null;
                    try
                    {
                        // Encoding response data
                        encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);
                        if (encodingBytes != null)
                        {
                            MemoryStream msU = new MemoryStream(encodingBytes);
                            ConvertData(js, msU);
                        }
                    }
                    catch (System.Text.EncoderFallbackException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.EncodingError);
                        CommonProcess.HasError = true;
                    }
                    catch (Exception ex)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.ErrorCause + ex.Message);
                        CommonProcess.HasError = true;
                    }
                }
            }
        }

        /// <summary>
        /// Convert json data to object data
        /// </summary>
        /// <param name="js">Data contract</param>
        /// <param name="msU">Memory stream</param>
        protected virtual void ConvertData(DataContractJsonSerializer js, MemoryStream msU)
        {
            // Convert json to object
            BaseResponseModel resp = (BaseResponseModel)js.ReadObject(msU);
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
