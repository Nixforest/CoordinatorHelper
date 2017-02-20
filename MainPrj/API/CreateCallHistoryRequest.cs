using MainPrj.Model;
using MainPrj.Model.Response;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MainPrj.API
{
    /// <summary>
    /// Create call history
    /// </summary>
    public class CreateCallHistoryRequest : BaseRequest
    {
        /// <summary>
        /// Data model
        /// </summary>
        private CallModel _model = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model">Call model</param>
        public CreateCallHistoryRequest(CallModel model)
            : base(Properties.Resources.API_CALL_HISTORY)
        {
            this._model = model;
            // Back-up filepath
            String filepath = this._model.File_record_name;
            if (!String.IsNullOrEmpty(filepath))
            {
                // Get file name
                this._model.File_record_name = CommonProcess.GetFileNameFromRecordFilePath(filepath);
            }
            base._data = this._model.ToString();
            // Restore filepath
            this._model.File_record_name = filepath;
        }

        /// <summary>
        /// Completed handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        override protected void completedHandler(object sender, UploadValuesCompletedEventArgs e)
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
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CreateCallHistoryResp));
                    byte[] encodingBytes = null;
                    try
                    {
                        // Encoding response data
                        encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);
                        if (encodingBytes != null)
                        {
                            MemoryStream msU = new MemoryStream(encodingBytes);
                            // Convert json to object
                            CreateCallHistoryResp resp = (CreateCallHistoryResp)js.ReadObject(msU);
                            if (resp != null)
                            {
                                // Response result is success
                                if (resp.Status.Equals(Properties.Resources.RESPONSE_STATUS_SUCCESS))
                                {
                                    if (String.IsNullOrEmpty(this._model.CallId))
                                    {
                                        // Update call id from server
                                        this._model.CallId = resp.Id;
                                    }
                                }
                            }
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
        /// Progress changed handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        override protected void progressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            
        }

        /// <summary>
        /// Execute request.
        /// </summary>
        public override void Execute()
        {
            using (WebClient client = new WebClient())
            {
                string respStr = String.Empty;
                try
                {
                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        LogUtility.Log(this._data, w);
                        //LogUtility.Log("List calls: " + DataPure.Instance.ListCalls.ToString(), w);
                    }
                    // Post keyword to server
                    byte[] response = client.UploadValues(
                        Properties.Settings.Default.ServerURL + this._url,
                        new System.Collections.Specialized.NameValueCollection()
                    {
                        { Properties.Resources.JSON_ROOT_KEY, this._data }
                    });
                    // Get response
                    respStr = System.Text.Encoding.UTF8.GetString(response);
                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        LogUtility.Log(respStr, w);
                        //LogUtility.Log("List calls: " + DataPure.Instance.ListCalls.ToString(), w);
                    }
                }
                catch (System.Net.WebException)
                {
                    CommonProcess.ShowErrorMessage(Properties.Resources.InternetConnectionError);
                    CommonProcess.HasError = true;
                }

                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(CreateCallHistoryResp));
                    byte[] encodingBytes = null;
                    try
                    {
                        // Encoding response data
                        encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);
                        if (encodingBytes != null)
                        {
                            MemoryStream msU = new MemoryStream(encodingBytes);
                            // Convert json to object
                            CreateCallHistoryResp resp = (CreateCallHistoryResp)js.ReadObject(msU);
                            if (resp != null)
                            {
                                // Response result is success
                                if (resp.Status.Equals(Properties.Resources.RESPONSE_STATUS_SUCCESS))
                                {
                                    // Update id of call
                                    if (String.IsNullOrEmpty(this._model.CallId))
                                    {
                                        this._model.CallId = resp.Id;
                                        using (StreamWriter w = File.AppendText("log.txt"))
                                        {
                                            LogUtility.Log("Call id created: " + resp.Id, w);
                                        }
                                    }
                                    // Mark this model was updated to server
                                    this._model.IsUpdateToServer = true;
                                }
                            }
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
    }
}
