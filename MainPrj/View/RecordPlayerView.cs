using MainPrj.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.View
{
    public partial class RecordPlayerView : Form
    {
        //private string path = string.Empty;
        private string path = @"C:\Users\saigo\Desktop\234\01--A-0822108100---20161025094207.wav";

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
            lblPath.Text = path;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                CommonProcess.PlaySound(Path, new System.IntPtr(), CommonProcess.PlaySoundFlags.SND_ASYNC);

                //_sound = new SoundPlayer(Path);
                //_sound.Play();
                //CommonProcess.NotificationSound.PlayLooping();
            }
        }

        private void RecordPlayerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (_sound != null)
            //{
            //    _sound.Stop();
            //}
            CommonProcess.PlaySound(null, new System.IntPtr(), CommonProcess.PlaySoundFlags.SND_ASYNC);
        }
    }
}
