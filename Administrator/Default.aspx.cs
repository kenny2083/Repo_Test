using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Abandon();
        }
    }
    protected void ButtonSend_Click(object sender, EventArgs e)
    {
        if (((Dictionary<string, BusinessLogic.Administrator>)Application["Administrators"]).Count > 0)
        {
            LabelError.Text = Resources.Resource.ErrMsg_AdminAlreadyLoggedIn;
        }
        else
        {
            BusinessLogic.Administrator Admin = new BusinessLogic.Administrator();
            Admin.UserName = TextBoxUserName.Text;
            Admin.Password = TextBoxPassword.Text;

            string ErrorMessage;
            bool LoginResult = Admin.IsAdministrator(out ErrorMessage);
            if (ErrorMessage != string.Empty)
            {
                LabelError.Text = ErrorMessage;
            }
            else
            {
                if (LoginResult == false)
                {
                    LabelError.Text = Resources.Resource.ErrMsg_UserNameOrPasswordIncorrect;
                }
                else if (LoginResult == true)
                {
                    Application.Lock();
                    ((Dictionary<string, BusinessLogic.Administrator>)Application["Administrators"]).Add(Session.SessionID, Admin);
                    Application.UnLock();

                    Session["Administrator"] = Admin;
                    HiddenFieldPageAddress.Value = "Personal_Information.aspx";
                }
            }
        }
    }
}