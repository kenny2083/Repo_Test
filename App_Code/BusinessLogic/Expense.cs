using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Expense
/// </summary>

namespace BusinessLogic
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public double Amount { get; set; }
        public TargetOut Target { get; set; }
        public DateTime ExpenseDate { get; set; }
        public PaymentType Type { get; set; }
        public string CreditCard { get; set; }
        public Bank Bank { get; set; }
        public long AccountNumber { get; set; }
        public string BranchName { get; set; }
        public long CheckNumber { get; set; }


        public void Save(out string ErrorMessage)
        {
            DataLayer.DataManager.InsertNewExpense(this, out ErrorMessage);
        }
    }
}