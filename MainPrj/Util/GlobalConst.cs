using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Util
{
    /// <summary>
    /// Global const.
    /// </summary>
    public class GlobalConst
    {
        #region Server
        /// <summary>
        /// Response status code: Success.
        /// </summary>
        public static string RESPONSE_STATUS_SUCCESS = "1";
        /// <summary>
        /// Response status code: Failed.
        /// </summary>
        public static string RESPONSE_STATUS_FAILED = "0";
        /// <summary>
        /// Json root key.
        /// </summary>
        public static string JSON_ROOT_KEY = "q"; 
        #endregion

        #region Text string
        public static string CONTENT00001 = "Không có file ghi âm";
        public static string CONTENT00002 = "Đơn hàng đang xử lý";
        #endregion

        #region Domain Constant
        /// <summary>
        /// Spliter.
        /// </summary>
        public static string    SPLITER_STR             = "-";
        /// <summary>
        /// Spliter.
        /// </summary>
        public static string    SPLITER_SPACE_STR       = " - ";
        /// <summary>
        /// Spliter.
        /// </summary>
        public static char      SPLITER_CHR             = '-';
        /// <summary>
        /// Button color: Normal state
        /// </summary>
        public static string    COLOR_BUTTON_NORMAL     = "EE3224";
        /// <summary>
        /// Button color: Selected state
        /// </summary>
        public static string    COLOR_BUTTON_SELECTED   = "08C012";
        #endregion
    }
}
