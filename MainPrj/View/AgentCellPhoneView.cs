using MainPrj.Model;
using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class AgentCellPhoneView : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AgentCellPhoneView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load event handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void AgentCellPhoneView_Load(object sender, EventArgs e)
        {
            tbxPhone.Text = DataPure.Instance.Agent.Agent_cell_phone;
        }
        /// <summary>
        /// Click OK button event handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!DataPure.Instance.Agent.Agent_cell_phone.Equals(tbxPhone.Text))
            {
                tbxPhone.Enabled = false;
                CommonProcess.UpdateAgentCellPhone(DataPure.Instance.Agent.Id,
                    tbxPhone.Text,
                    updateAgentProgressChanged,
                    updateAgentCompleted);
            }
        }
        /// <summary>
        /// Update agent completed handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadValuesCompletedEventArgs</param>
        private void updateAgentCompleted(object sender, System.Net.UploadValuesCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + "Hủy";
            }
            else if (e.Error != null)
            {
                toolStripStatusLabel.Text = Properties.Resources.ErrorCause + e.Error.Message;
            }
            else
            {
                byte[] response = e.Result;
                string respStr = String.Empty;
                respStr = System.Text.Encoding.UTF8.GetString(response);
                if (!String.IsNullOrEmpty(respStr))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(BaseResponseModel));
                    byte[] encodingBytes = null;
                    try
                    {
                        // Encoding response data
                        encodingBytes = System.Text.UnicodeEncoding.Unicode.GetBytes(respStr);
                    }
                    catch (System.Text.EncoderFallbackException)
                    {
                        CommonProcess.ShowErrorMessage(Properties.Resources.EncodingError);
                    }
                    if (encodingBytes != null)
                    {
                        MemoryStream msU = new MemoryStream(encodingBytes);
                        BaseResponseModel baseResp = (BaseResponseModel)js.ReadObject(msU);
                        if (baseResp != null && baseResp.Status.Equals("1"))
                        {
                            toolStripStatusLabel.Text = Properties.Resources.RequestAgentInfoSuccess;
                            DataPure.Instance.Agent.Agent_cell_phone = tbxPhone.Text;
                        }
                        else
                        {
                            toolStripStatusLabel.Text = Properties.Resources.UpdateAgentCellPhoneError;
                            CommonProcess.ShowErrorMessage(Properties.Resources.UpdateAgentCellPhoneError);
                        }
                    }
                }
            }
            tbxPhone.Enabled = true;
        }
        /// <summary>
        /// Update agent progress changed handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">UploadProgressChangedEventArgs</param>
        private void updateAgentProgressChanged(object sender, System.Net.UploadProgressChangedEventArgs e)
        {
            if ((e.ProgressPercentage <= 50) && (e.ProgressPercentage >= 0))
            {
                toolStripProgressBar.Value = e.ProgressPercentage * 2;
            }
            toolStripStatusLabel.Text = Properties.Resources.RequestUpdateAgentCellPhone;
        }
    }
}
