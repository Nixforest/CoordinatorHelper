using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Status of orders.
    /// 1: New. 2: Paid, 3: Cancel
    /// </summary>
    public enum OrderStatus
    {
        ORDERSTATUS_NEW = 1,            // New
        ORDERSTATUS_PAID,               // Paid
        ORDERSTATUS_CANCEL,             // Cancel
        ORDERSTATUS_NUM
    }
    //++ BUG0056-SPJ (NguyenPT 20160830) Handle order type
    /// <summary>
    /// Order type:
    /// 1. Normal
    /// 2. Sell_vo
    /// 3. The chan
    /// </summary>
    public enum OrderType
    {
        ORDERTYPE_NORMAL = 1,
        ORDERTYPE_SELLVO,
        ORDERTYPE_THECHAN,
        //++ BUG0059-SPJ (NguyenPT 20160831) Return cylinder
        ORDERTYPE_THUVO,
        //-- BUG0059-SPJ (NguyenPT 20160831) Return cylinder
        ORDERTYPE_NUM
    }
    //-- BUG0056-SPJ (NguyenPT 20160830) Handle order type
}
