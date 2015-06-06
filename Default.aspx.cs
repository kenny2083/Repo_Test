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
        //string ErrorMessage;
        //BusinessLogic.Customer Customer = 
        //    BusinessLogic.Customer.GetCustomerByMailAndPassword(TextBoxMail.Text, TextBoxPassword.Text, out ErrorMessage);

        //if (string.IsNullOrEmpty(ErrorMessage))
        //{
        //    if (Customer != null)
        //    {
        //        Session["Customer"] = Customer;
        //        HiddenFieldPageAddress.Value = "ExpensesPage.aspx";
        //    }
        //    else
        //    {
        //        LabelError.Text = Resources.Resource.ErrMsg_UserNameOrPasswordIncorrect;
        //    }
        //}
        //else
        //{
        //    LabelError.Text = ErrorMessage;
        //}

        string ErrorMessage;
        BusinessLogic.Customer Customer = BusinessLogic.Customer.GetCustomerByMail(TextBoxMail.Text, out ErrorMessage);
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            if (Customer != null)
            {
                if (BusinessLogic.Password.Verify(TextBoxPassword.Text, "SHA512", Customer.Password))
                {
                    Session["Customer"] = Customer;
                    HiddenFieldPageAddress.Value = "ExpensesPage.aspx";
                }
                else
                {
                    LabelError.Text = "Password incorrect";
                }
            }
            else
            {
                LabelError.Text = "Email incorrect";
            }
        }
        else
        {
            LabelError.Text = ErrorMessage;
        }
    }
}