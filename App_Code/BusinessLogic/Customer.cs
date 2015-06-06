using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
/// 

namespace BusinessLogic
{
    public class Customer
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public DateTime DateEnd { get; set; }

        public void InsertCustomer(out string ErrorMessage)
        {
            DataLayer.DataManager.InsertCustomer(this, out ErrorMessage);
        }

        public static Customer GetCustomerByMailAndPassword(string Mail, string Password, out string ErrorMessage)
        {
            return DataLayer.DataManager.SelectCustomerByMailAndPassword(Mail, Password, out ErrorMessage);
        }

        public static Customer GetCustomerByMail(string Mail, out string ErrorMessage)
        {
            return DataLayer.DataManager.SelectCustomerByMail(Mail, out ErrorMessage);
        }

        public static List<Customer> GetCustomersList(out string ErrorMessage)
        {
            return DataLayer.DataManager.SelectCustomers(out ErrorMessage);
        }

        public static List<Customer> GetCustomersList(int pageNum, int pageSize, out string errorMessage)
        {
            return DataLayer.DataManager.SelectCustomersByPage(pageNum, pageSize, out errorMessage);
        }

        public static List<Customer> SearchCustomersByName(string exp, out string ErrorMessage)
        {
            return DataLayer.DataManager.SearchCustomersByName(exp, out ErrorMessage);
        }

        public static int GetCustomersCount(out string errorMessage)
        {
            return DataLayer.DataManager.GetCustomersCount(out errorMessage);
        }

        public static System.Data.DataTable GetCustomersDataTable()
        {
            return DataLayer.DataManager.GetCustomersDataTable();
        }
    }
}