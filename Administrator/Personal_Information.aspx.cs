using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Personal_Information : AdministratorPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BusinessLogic.Administrator CurrentAdmin = (BusinessLogic.Administrator) Session["Administrator"];
            string ErrorMessage;
            CurrentAdmin.GetFullData(out ErrorMessage);
            if (ErrorMessage == string.Empty)
            {
                TextBoxUserName.Text = CurrentAdmin.UserName;
                TextBoxMail.Text = CurrentAdmin.Mail;
                TextBoxPassword.Text = CurrentAdmin.Password;
                TextBoxConfirmPassword.Text = CurrentAdmin.Password;

                HiddenFieldUserName.Value = CurrentAdmin.UserName;
                HiddenFieldMail.Value = CurrentAdmin.Mail;
                HiddenFieldPassword.Value = CurrentAdmin.Password;
            }
        }
    }
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        if (TextBoxPassword.Text == TextBoxConfirmPassword.Text)
        {
            BusinessLogic.Administrator NewAdmin = new BusinessLogic.Administrator();
            NewAdmin.UserName = TextBoxUserName.Text;
            NewAdmin.Mail = TextBoxMail.Text;
            NewAdmin.Password = TextBoxPassword.Text;
            string ErrorMessage;
            NewAdmin.Update(out ErrorMessage);
            if (ErrorMessage != string.Empty)
            {
                HiddenFieldAlertMessage.Value = ErrorMessage;
            }
            else
            {
                Application.Lock();
                ((Dictionary<string, BusinessLogic.Administrator>)Application["Administrators"])[Session.SessionID] = NewAdmin;
                Application.UnLock();

                Session["Administrator"] = NewAdmin;

                HiddenFieldUserName.Value = NewAdmin.UserName;
                HiddenFieldMail.Value = NewAdmin.Mail;
                HiddenFieldPassword.Value = NewAdmin.Password;

                HiddenFieldAlertMessage.Value = Resources.Resource.Msg_ChangesSaved;
            }
        }
        else
        {
            HiddenFieldAlertMessage.Value = Resources.Resource.ErrMsg_PasswordConfirm;
        }

        //ScriptManager.RegisterStartupScript((UpdatePanel)Master.FindControl("UpdatePanelContentPlace"), GetType(), "Alert", "Alert()", true);

    }
}