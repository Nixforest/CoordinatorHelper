using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Enum use for index of HistoryView columns.
    /// </summary>
    public enum OrderHistoryColumns
    {
        ORDER_HISTORY_COLUMN_NO = 0,
        ORDER_HISTORY_COLUMN_TIME,
        ORDER_HISTORY_COLUMN_PRODUCT_ID,
        ORDER_HISTORY_COLUMN_PRODUCT_NAME,
        ORDER_HISTORY_COLUMN_QUANTITY,
        ORDER_HISTORY_COLUMN_NOTE,
        ORDER_HISTORY_COLUMN_NUM
    }
    /// <summary>
    /// Enum use for index of HistoryView columns.
    /// </summary>
    public enum OrderHistoryCoordinatorColumns
    {
        ORDER_HISTORY_COOR_COLUMN_TIME = 0,
        ORDER_HISTORY_COOR_COLUMN_PRODUCT_NAME,
        ORDER_HISTORY_COOR_COLUMN_QUANTITY,
        ORDER_HISTORY_COOR_COLUMN_NOTE,
        ORDER_HISTORY_COOR_COLUMN_NUM
    }
}
