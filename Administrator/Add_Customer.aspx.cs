using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Add_User : AdministratorPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBoxPassword.Text = BusinessLogic.Password.GeneratePassword();
        }
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        if (BusinessLogic.Password.ValidatePassword(TextBoxPassword.Text))
        {
            BusinessLogic.Customer NewCustomer = new BusinessLogic.Customer();
            NewCustomer.Mail = TextBoxMail.Text;
            //NewCustomer.Password = TextBoxPassword.Text;
            NewCustomer.Password = BusinessLogic.Password.Encrypt(TextBoxPassword.Text, "SHA512", null);
            NewCustomer.FirstName = TextBoxFirstName.Text;
            NewCustomer.LastName = TextBoxLastName.Text;
            NewCustomer.CompanyName = TextBoxCompanyName.Text;
            NewCustomer.Phone = TextBoxPhone.Text;
            NewCustomer.DateEnd = DateTime.Parse(TextBoxDateEnd.Text);
            string ErrorMessage;
            NewCustomer.InsertCustomer(out ErrorMessage);
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                HiddenFieldAlertMessage.Value = ErrorMessage;
            }
            else
            {
                HiddenFieldAlertMessage.Value = Resources.Resource.Msg_CustomerAdded;
            }
        }
        else
        {
            HiddenFieldAlertMessage.Value = Resources.Resource.ErrMsg_WeakPassword;
        }
    }
}