using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
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

        public String Data
        {
            get { return _data; }
            set { _data = value; }
        }

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
                client.UploadProgressChanged += progressChanged;
                client.UploadValuesCompleted += completedHandler;
                try
                {
                    client.UploadValuesAsync(
                        new Uri(Properties.Settings.Default.ServerURL + this._url),
                        new NameValueCollection()
                        {
                            { Properties.Resources.JSON_ROOT_KEY, this.Data }
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Completed handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        protected virtual void completedHandler(object sender, UploadValuesCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
