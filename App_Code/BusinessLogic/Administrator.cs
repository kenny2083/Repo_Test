using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Administrator
/// </summary>
/// 

namespace BusinessLogic
{
    public class Administrator
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        public bool Update(out string ErrorMessage)
        {
            return DataLayer.DataManager.Administrator_Update(this, out ErrorMessage);
        }

        public bool IsAdministrator(out string ErrorMessage)
        {
            return DataLayer.DataManager.Administrator_Select(this, out ErrorMessage);
        }

        public void GetFullData(out string ErrorMessage)
        {
            Administrator Temp = DataLayer.DataManager.Administrator_SelectFullDataByUserName(UserName, out ErrorMessage);
            this.Password = Temp.Password;
            this.Mail = Temp.Mail;
        }
    }
}