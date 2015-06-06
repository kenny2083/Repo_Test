using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Bank
/// </summary>
/// 

namespace BusinessLogic
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }

        public static List<Bank> GetList(out string ErrorMessage)
        {
            return DataLayer.DataManager.SelectBanksList(out ErrorMessage);
        }

    }
}