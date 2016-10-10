using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainPrj.Util
{
    /// <summary>
    /// Class use for cross thread handle.
    /// </summary>
    public static class CrossThreadUtility
    {
        /// <summary>
        /// Set text for control.
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="text">Text</param>
        public delegate void SetTextCallBack(Control control, string text);
        /// <summary>
        /// Set control enabled/disabled.
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="isEnable">Enabled status</param>
        public delegate void EnableCallBack(Control control, bool isEnable);
    }
}
