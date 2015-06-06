using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Payment
/// </summary>
namespace BusinessLogic
{
    public class Payment
    {
        public double Amount { get; set; }
        public PaymentType CurrentPaymentType { get; set; }
        public List<Bank> BankList { get; set; }
        public Bank SelectedBank { get; set; }
        public string BankBranch { get; set; }
        public int Account { get; set; }
        public List<string> CreditCards { get; set; }
        public string CurrentCreditCard { get; set; }
        public int? Check { get; set; }
    }
}