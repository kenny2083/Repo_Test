using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentType
/// </summary>
/// 

namespace BusinessLogic
{
    public enum PaymentType
    {
        Cash = 1,
        CreditCard = 2,
        Check = 3,
        BankTransfer = 4
    }
}