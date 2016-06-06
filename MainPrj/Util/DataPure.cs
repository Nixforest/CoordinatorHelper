using MainPrj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Util
{
    /// <summary>
    /// Data class
    /// </summary>
    public class DataPure
    {
        #region Data members
        private int currentChannel = 0;
        private TempDataModel tempData;
        /// <summary>
        /// Temp data.
        /// </summary>
        public TempDataModel TempData
        {
            get { return tempData; }
            set { tempData = value; }
        }

        /// <summary>
        /// Current channel.
        /// </summary>
        public int CurrentChannel
        {
            get { return currentChannel; }
            set { currentChannel = value; }
        } 
        #endregion

        #region Singleton Instance
        /// <summary>
        /// Instance
        /// </summary>
        private static DataPure instance;
        /// <summary>
        /// Constructor.
        /// </summary>
        private DataPure() { }
        /// <summary>
        /// Get instance
        /// </summary>
        public static DataPure Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataPure();
                }
                return instance;
            }
        }
        #endregion
    }
}
