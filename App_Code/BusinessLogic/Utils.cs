using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utils
/// </summary>
namespace BusinessLogic
{
    public static class Utils
    {
        public static List<string> GetCreditCardList()
        {
            string CreditCardsString = System.Configuration.ConfigurationManager.AppSettings["CreditCards"];
            List<string> CreditCardList = CreditCardsString.Split(',').ToList();
            return CreditCardList;
        }
    }
}