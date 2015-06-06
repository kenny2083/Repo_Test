using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataManager
/// </summary>
/// 

namespace DataLayer
{
    public static class DataManager
    {
        public static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();
            }
        }

        public static bool Administrator_Update(BusinessLogic.Administrator Admin, out string ErrorMessage)
        {
            bool Result = false;
            ErrorMessage = string.Empty;
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "Administrator_Update";
            CurrentCommand.Parameters.AddWithValue("@UserName", Admin.UserName);
            CurrentCommand.Parameters.AddWithValue("@Password", Admin.Password);
            CurrentCommand.Parameters.AddWithValue("@Email", Admin.Mail);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                CurrentCommand.ExecuteNonQuery();
                Result = true;
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
                Result = false;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return Result;
        }

        public static bool Administrator_Select(BusinessLogic.Administrator Admin, out string ErrorMessage)
        {
            bool Result = false;
            ErrorMessage = string.Empty;
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "Administrator_Select";
            CurrentCommand.Parameters.AddWithValue("@UserName", Admin.UserName);
            CurrentCommand.Parameters.AddWithValue("@Password", Admin.Password);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                int AdminCount = Convert.ToInt32(CurrentCommand.ExecuteScalar());
                if (AdminCount == 1)
                {
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return Result;
        }

        public static BusinessLogic.Administrator Administrator_SelectFullDataByUserName(string UserName, out string ErrorMessage)
        {
            BusinessLogic.Administrator ResultAdmin = new BusinessLogic.Administrator();
            ErrorMessage = string.Empty;
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "Administrator_SelectFullDataByUserName";
            CurrentCommand.Parameters.AddWithValue("@UserName", UserName);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                SqlDataReader CurrentDataReader = CurrentCommand.ExecuteReader();
                while (CurrentDataReader.Read())
                {
                    //ResultAdmin.UserName = CurrentDataReader.GetString(0);
                    ResultAdmin.Password = CurrentDataReader.GetString(0);
                    ResultAdmin.Mail = CurrentDataReader.GetString(1);
                }
                CurrentDataReader.Close();
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                    CurrentCommand.Connection.Close();
            }

            return ResultAdmin;
        }

        public static void InsertCustomer(BusinessLogic.Customer Customer, out string ErrorMessage)
        {
            ErrorMessage = string.Empty;
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "InsertCustomer";
            CurrentCommand.Parameters.AddWithValue("@Email", Customer.Mail);
            CurrentCommand.Parameters.AddWithValue("@Password", Customer.Password);
            CurrentCommand.Parameters.AddWithValue("@Name", Customer.FirstName);
            CurrentCommand.Parameters.AddWithValue("@LastName", Customer.LastName);
            CurrentCommand.Parameters.AddWithValue("@CompanyName", Customer.CompanyName);
            CurrentCommand.Parameters.AddWithValue("@Phone", Customer.Phone);
            CurrentCommand.Parameters.AddWithValue("@DateEnd", Customer.DateEnd);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                CurrentCommand.ExecuteNonQuery();
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }
        }

        public static List<BusinessLogic.Customer> SelectCustomers(out string ErrorMessage)
        {
            ErrorMessage = string.Empty;
            List<BusinessLogic.Customer> ResultCustomersList = new List<BusinessLogic.Customer>();
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "SelectCustomers";
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                SqlDataReader CurrentDataReader = CurrentCommand.ExecuteReader();
                while (CurrentDataReader.Read())
                {
                    BusinessLogic.Customer CurrentCustomer = new BusinessLogic.Customer();
                    CurrentCustomer.Id = CurrentDataReader.GetInt32(0);
                    CurrentCustomer.Mail = CurrentDataReader.GetString(1);
                    CurrentCustomer.Password = CurrentDataReader.GetString(2);
                    CurrentCustomer.FirstName = CurrentDataReader.GetString(3);
                    CurrentCustomer.LastName = CurrentDataReader.GetString(4);
                    CurrentCustomer.CompanyName = CurrentDataReader.GetString(5);
                    CurrentCustomer.Phone = CurrentDataReader.GetString(6);
                    CurrentCustomer.DateEnd = CurrentDataReader.GetDateTime(7);
                    ResultCustomersList.Add(CurrentCustomer);
                }
                CurrentDataReader.Close();
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return ResultCustomersList;
        }

        public static DataTable GetCustomersDataTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM T_Customers";
            SqlDataAdapter sda = new SqlDataAdapter(query, ConnectionString);
            sda.Fill(dt);
            return dt;
        }

        public static BusinessLogic.Customer SelectCustomerByMailAndPassword(string Mail, string Password, out string ErrorMessage)
        {
            BusinessLogic.Customer Customer = null;
            ErrorMessage = string.Empty;
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "SelectCustomerByMailAndPassword";
            CurrentCommand.Parameters.AddWithValue("Email", Mail);
            CurrentCommand.Parameters.AddWithValue("Password", Password);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                SqlDataReader CurrentReader = CurrentCommand.ExecuteReader();
                if (CurrentReader.HasRows)
                {
                    Customer = new BusinessLogic.Customer();
                    Customer.Mail = Mail;
                    Customer.Password = Password;
                    while (CurrentReader.Read())
                    {
                        Customer.FirstName = CurrentReader.GetString(1);
                        Customer.LastName = CurrentReader.GetString(2);
                        Customer.CompanyName = CurrentReader.GetString(3);
                        Customer.Phone = CurrentReader.GetString(4);
                        Customer.DateEnd = CurrentReader.GetDateTime(5);
                    }
                }
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return Customer;
        }

        public static BusinessLogic.Customer SelectCustomerByMail(string Mail, out string ErrorMessage)
        {
            BusinessLogic.Customer Customer = null;
            ErrorMessage = string.Empty;
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "SelectCustomerByMail";
            CurrentCommand.Parameters.AddWithValue("@Email", Mail);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                SqlDataReader CurrentReader = CurrentCommand.ExecuteReader();
                if (CurrentReader.HasRows)
                {
                    Customer = new BusinessLogic.Customer();
                    Customer.Mail = Mail;
                    while (CurrentReader.Read())
                    {
                        Customer.Password = CurrentReader.GetString(1);
                        Customer.FirstName = CurrentReader.GetString(2);
                        Customer.LastName = CurrentReader.GetString(3);
                        Customer.CompanyName = CurrentReader.GetString(4);
                        Customer.Phone = CurrentReader.GetString(5);
                        Customer.DateEnd = CurrentReader.GetDateTime(6);
                    }
                }
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return Customer;
        }

        public static int GetCustomersCount(out string errorMessage)
        {
            errorMessage = string.Empty;
            int customersCount = 0;

            string query = "SELECT COUNT(*) FROM T_Customers";

            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.Text;
            CurrentCommand.CommandText = query;
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                customersCount = Convert.ToInt32(CurrentCommand.ExecuteScalar());
            }
            catch (System.Exception CurrentException)
            {
                errorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return customersCount;
        }

        public static List<BusinessLogic.Customer> SelectCustomersByPage(int pageNum, int pageSize, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<BusinessLogic.Customer> ResultCustomersList = new List<BusinessLogic.Customer>();
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "SelectCustomersByPage";
            CurrentCommand.Parameters.AddWithValue("@intPage", pageNum);
            CurrentCommand.Parameters.AddWithValue("@intPageSize", pageSize);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                SqlDataReader CurrentDataReader = CurrentCommand.ExecuteReader();
                while (CurrentDataReader.Read())
                {
                    BusinessLogic.Customer CurrentCustomer = new BusinessLogic.Customer();
                    CurrentCustomer.Id = CurrentDataReader.GetInt32(0);
                    CurrentCustomer.Mail = CurrentDataReader.GetString(1);
                    CurrentCustomer.Password = CurrentDataReader.GetString(2);
                    CurrentCustomer.FirstName = CurrentDataReader.GetString(3);
                    CurrentCustomer.LastName = CurrentDataReader.GetString(4);
                    CurrentCustomer.CompanyName = CurrentDataReader.GetString(5);
                    CurrentCustomer.Phone = CurrentDataReader.GetString(6);
                    CurrentCustomer.DateEnd = CurrentDataReader.GetDateTime(7);
                    ResultCustomersList.Add(CurrentCustomer);
                }
                CurrentDataReader.Close();
            }
            catch (System.Exception CurrentException)
            {
                errorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return ResultCustomersList;

        }

        public static List<BusinessLogic.Customer> SearchCustomersByName(string exp, out string ErrorMessage)
        {
            ErrorMessage = string.Empty;
            List<BusinessLogic.Customer> ResultCustomersList = new List<BusinessLogic.Customer>();
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "SearchCustomersByName";
            CurrentCommand.Parameters.AddWithValue("@Exp", exp);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                SqlDataReader CurrentDataReader = CurrentCommand.ExecuteReader();
                while (CurrentDataReader.Read())
                {
                    BusinessLogic.Customer CurrentCustomer = new BusinessLogic.Customer();
                    CurrentCustomer.Id = CurrentDataReader.GetInt32(0);
                    CurrentCustomer.Mail = CurrentDataReader.GetString(1);
                    CurrentCustomer.Password = CurrentDataReader.GetString(2);
                    CurrentCustomer.FirstName = CurrentDataReader.GetString(3);
                    CurrentCustomer.LastName = CurrentDataReader.GetString(4);
                    CurrentCustomer.CompanyName = CurrentDataReader.GetString(5);
                    CurrentCustomer.Phone = CurrentDataReader.GetString(6);
                    CurrentCustomer.DateEnd = CurrentDataReader.GetDateTime(7);
                    ResultCustomersList.Add(CurrentCustomer);
                }
                CurrentDataReader.Close();
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return ResultCustomersList;
        }

        public static List<BusinessLogic.Bank> SelectBanksList(out string ErrorMessage)
        {
            ErrorMessage = string.Empty;
            List<BusinessLogic.Bank> ResultBankList = new List<BusinessLogic.Bank>();
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "SelectBanksList";
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                SqlDataReader CurrentDataReader = CurrentCommand.ExecuteReader();
                while (CurrentDataReader.Read())
                {
                    BusinessLogic.Bank CurrentBank = new BusinessLogic.Bank();
                    CurrentBank.BankId = CurrentDataReader.GetInt32(0);
                    CurrentBank.BankName = CurrentDataReader.GetString(1);
                    ResultBankList.Add(CurrentBank);
                }
                CurrentDataReader.Close();
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return ResultBankList;
        }

        public static void InsertNewTarget(BusinessLogic.TargetOut NewTarget, out string ErrorMessage)
        {
            ErrorMessage = string.Empty;
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "InsertNewTarget";
            CurrentCommand.Parameters.AddWithValue("@Text", NewTarget.Text);
            CurrentCommand.Parameters.AddWithValue("@VAT", NewTarget.VAT);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                CurrentCommand.ExecuteNonQuery();
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }
        }

        public static List<BusinessLogic.TargetOut> SelectTargetsList(out string ErrorMessage)
        {
            ErrorMessage = string.Empty;
            List<BusinessLogic.TargetOut> ResultTargetsList = new List<BusinessLogic.TargetOut>();
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "SelectTargets";
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                SqlDataReader CurrentDataReader = CurrentCommand.ExecuteReader();
                while (CurrentDataReader.Read())
                {
                    BusinessLogic.TargetOut CurrentTargetOut = new BusinessLogic.TargetOut();
                    CurrentTargetOut.Id = CurrentDataReader.GetInt32(0);
                    CurrentTargetOut.Text = CurrentDataReader.GetString(1);
                    CurrentTargetOut.VAT = CurrentDataReader.GetBoolean(2);
                    ResultTargetsList.Add(CurrentTargetOut);
                }
                CurrentDataReader.Close();
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }

            return ResultTargetsList;
        }

        public static void InsertNewExpense(BusinessLogic.Expense NewExpense, out string ErrorMessage)
        {
            ErrorMessage = string.Empty;
            SqlCommand CurrentCommand = new SqlCommand();
            CurrentCommand.CommandType = CommandType.StoredProcedure;
            CurrentCommand.CommandText = "InsertNewExpense";
            CurrentCommand.Parameters.AddWithValue("@Amount", NewExpense.Amount);
            CurrentCommand.Parameters.AddWithValue("@TargetId", NewExpense.Target.Id);
            CurrentCommand.Parameters.AddWithValue("@ExpenseDate", NewExpense.ExpenseDate);
            CurrentCommand.Parameters.AddWithValue("@PaymentType", NewExpense.Type.ToString());
            CurrentCommand.Parameters.AddWithValue("@CreditCard", NewExpense.CreditCard);
            CurrentCommand.Parameters.AddWithValue("@BankId", NewExpense.Bank.BankId);
            CurrentCommand.Parameters.AddWithValue("@AccountNumber", NewExpense.AccountNumber);
            CurrentCommand.Parameters.AddWithValue("@BranchName", NewExpense.BranchName);
            CurrentCommand.Parameters.AddWithValue("@checkNumber", NewExpense.CheckNumber);
            CurrentCommand.Connection = new SqlConnection(ConnectionString);
            try
            {
                CurrentCommand.Connection.Open();
                CurrentCommand.ExecuteNonQuery();
            }
            catch (System.Exception CurrentException)
            {
                ErrorMessage = CurrentException.Message;
            }
            finally
            {
                if (CurrentCommand.Connection.State != ConnectionState.Closed)
                {
                    CurrentCommand.Connection.Close();
                }
            }
        }
    }
}