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
}
