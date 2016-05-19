using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainPrj.Model
{
    /// <summary>
    /// Type of call.
    /// </summary>
    public enum CallType
    {
        CALLTYPE_ORDER = 0,             // Dat hang ngay
        CALLTYPE_ORDER_SAVE,            // Dat hang sau
        CALLTYPE_UPHOLD,                // Bao tri
        CALLTYPE_NUM
    }
}
