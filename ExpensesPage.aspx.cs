using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ExpensesPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ErrorMessage = string.Empty;
            List<BusinessLogic.TargetOut> TargetsList = DataLayer.DataManager.SelectTargetsList(out ErrorMessage);
            if (string.IsNullOrEmpty(ErrorMessage))
            {
                foreach (BusinessLogic.TargetOut target in TargetsList)
                {
                    ListItem item = new ListItem(target.Text, target.Id.ToString());
                    DropDownListTargets.Items.Add(item);
                }
            }

            DropDownListPaymentType.DataSource = Enum.GetNames(typeof(BusinessLogic.PaymentType));
            DropDownListPaymentType.DataBind();

            DropDownListCreditCards.DataSource = BusinessLogic.Utils.GetCreditCardList();
            DropDownListCreditCards.DataBind();

            ErrorMessage = string.Empty;
            List<BusinessLogic.Bank> BankList = BusinessLogic.Bank.GetList(out ErrorMessage);
            if (string.IsNullOrEmpty(ErrorMessage))
            {
                foreach (BusinessLogic.Bank bank in BankList)
                {
                    ListItem item = new ListItem(bank.BankName, bank.BankId.ToString());
                    DropDownListBanks.Items.Add(item);
                }
            }
        }
    }
    protected void TopMenuButton_Click(object sender, EventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl EditDataDiv =
                    (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("EditDataDiv");

        EditDataDiv.Style.Add("visibility", "visible");
    }
    protected void DropDownListPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListPaymentType.SelectedItem.Text == BusinessLogic.PaymentType.Cash.ToString())
        {
            DropDownListCreditCards.Enabled = false;
            DropDownListBanks.Enabled = false;
            TextBoxAccountNumber.Enabled = false;
            TextBoxBranchName.Enabled = false;
            TextBoxCheckNumber.Enabled = false;
        }
        else if (DropDownListPaymentType.SelectedItem.Text == BusinessLogic.PaymentType.CreditCard.ToString())
        {
            DropDownListCreditCards.Enabled = true;
            DropDownListBanks.Enabled = false;
            TextBoxAccountNumber.Enabled = false;
            TextBoxBranchName.Enabled = false;
            TextBoxCheckNumber.Enabled = false;
        }
        else if (DropDownListPaymentType.SelectedItem.Text == BusinessLogic.PaymentType.BankTransfer.ToString())
        {
            DropDownListCreditCards.Enabled = false;
            DropDownListBanks.Enabled = true;
            TextBoxAccountNumber.Enabled = true;
            TextBoxBranchName.Enabled = true;
            TextBoxCheckNumber.Enabled = false;
        }
        else if (DropDownListPaymentType.SelectedItem.Text == BusinessLogic.PaymentType.Check.ToString())
        {
            DropDownListCreditCards.Enabled = false;
            DropDownListBanks.Enabled = false;
            TextBoxAccountNumber.Enabled = false;
            TextBoxBranchName.Enabled = false;
            TextBoxCheckNumber.Enabled = true;
        }
    }
}