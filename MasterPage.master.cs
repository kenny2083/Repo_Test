using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ButtonExit.Text = Resources.Resource.Exit;

            string LanguageString = System.Configuration.ConfigurationManager.AppSettings["Languages"];
            List<BusinessLogic.Language> LanguageList = BusinessLogic.Language.GetLanguagesList(LanguageString);
            foreach (BusinessLogic.Language Language in LanguageList)
            {
                DropDownListLanguages.Items.Add(Language.Name);
            }
        }
    }
    protected void ImageButtonClose_Click(object sender, ImageClickEventArgs e)
    {
        EditDataDiv.Style.Add("visibility", "hidden");
    }
    protected void ButtonExit_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Default.aspx");
    }
    protected void DropDownListLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        string CurrentUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
        string SelectedLanguageName = ((DropDownList)sender).SelectedValue;
        Response.Redirect(CurrentUrl + "?Lang=" + SelectedLanguageName);
    }
}
