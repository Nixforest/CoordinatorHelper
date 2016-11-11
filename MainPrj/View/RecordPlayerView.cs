using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class RecordPlayerView : Form
    {
        private string path = string.Empty;

        /// <summary>
        /// Path of record file.
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public RecordPlayerView()
        {
            InitializeComponent();
        }

        private void RecordPlayerView_Load(object sender, EventArgs e)
        {
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                CommonProcess.PlaySound(Path, new System.IntPtr(), CommonProcess.PlaySoundFlags.SND_SYNC);
            }
        }
    }
}
