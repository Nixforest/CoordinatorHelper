using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPrj
{
    /// <summary>
    /// Type of data get from Tansonic card.
    /// </summary>
    public enum CardDataStatus
    {
        CARDDATA_RINGING = 0,           // Do chuong
        CARDDATA_CALLING,               // Goi di
        CARDDATA_HANDLING,              // Xu ly
        CARDDATA_HANGUP,                // Cup
        CARDDATA_MISS,                  // Nho
        CARDDATA_RECORD,                // Da ghi am
        CARDDATA_NUM,
    }
}
