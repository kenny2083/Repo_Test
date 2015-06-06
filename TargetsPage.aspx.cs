using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TargetsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonSaveNewTarget_Click(object sender, EventArgs e)
    {
        HiddenFieldMessage.Value = string.Empty;
        if (!string.IsNullOrEmpty(TextBoxNewTargetText.Text))
        {
            string ErrorMessage;
            BusinessLogic.TargetOut NewTarget = new BusinessLogic.TargetOut();
            NewTarget.Text = TextBoxNewTargetText.Text;
            NewTarget.VAT = CheckBoxTargetVAT.Checked;
            NewTarget.Save(out ErrorMessage);
            if (string.IsNullOrEmpty(ErrorMessage))
            {
                TextBoxNewTargetText.Text = string.Empty;
                CheckBoxTargetVAT.Checked = false;

                System.Web.UI.HtmlControls.HtmlGenericControl EditDataDiv =
                    (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("EditDataDiv");

                EditDataDiv.Style.Add("visibility", "hidden");
            }
            else
            {
                HiddenFieldMessage.Value = ErrorMessage;
            }
        }
    }
    protected void TopMenuButton_Click(object sender, EventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl EditDataDiv =
                    (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("EditDataDiv");

        EditDataDiv.Style.Add("visibility", "visible");
    }
}