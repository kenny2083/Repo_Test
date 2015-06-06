using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerPage
/// </summary>
public class CustomerPage : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        if (Session["Customer"] == null)
        {
            Response.End();
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        BusinessLogic.Language Language = null;

        if (Request.QueryString["Lang"] != null)
        {
            string LanguageName = Request.QueryString["Lang"];
            string LanguageString = System.Configuration.ConfigurationManager.AppSettings["Languages"];
            Language = BusinessLogic.Language.GetLanguageByName(LanguageString, LanguageName);
            Response.Cookies["Language"].Value = Language.Name;
        }
        else
        {
            if (Session["Language"] != null)
            {
                Language = (BusinessLogic.Language)Session["Language"];
            }
            else
            {
                string LanguageString = System.Configuration.ConfigurationManager.AppSettings["Languages"];
                if (Request.Cookies["Language"] != null)
                {
                    string LanguageName = Request.Cookies["Language"].Value;
                    Language = BusinessLogic.Language.GetLanguageByName(LanguageString, LanguageName);
                }
                else
                {
                    Language = BusinessLogic.Language.GetDefaultLanguage(LanguageString);
                    Response.Cookies["Language"].Value = Language.Name;
                }
            }
        }

        Session["Language"] = Language;

        this.SetLanguage(Language);
    }

    public void SetLanguage(BusinessLogic.Language Language)
    {
        this.Culture = Language.Culture;
        this.UICulture = Language.UICulture;

        if (Language.Direction == BusinessLogic.Language.TextDirection.ltr)
        {
            ((System.Web.UI.HtmlControls.HtmlLink)Master.FindControl("CSSLink1")).Attributes["href"] = "../App_Themes/SiteTheme/MainStyleSheet_ltr.css";
            ((System.Web.UI.HtmlControls.HtmlLink)Master.FindControl("CSSLink2")).Attributes["href"] = "../App_Themes/SiteTheme/AdminPagesStyle_ltr.css";
        }
        else if (Language.Direction == BusinessLogic.Language.TextDirection.rtl)
        {
            ((System.Web.UI.HtmlControls.HtmlLink)Master.FindControl("CSSLink1")).Attributes["href"] = "../App_Themes/SiteTheme/MainStyleSheet_rtl.css";
            ((System.Web.UI.HtmlControls.HtmlLink)Master.FindControl("CSSLink2")).Attributes["href"] = "../App_Themes/SiteTheme/AdminPagesStyle_rtl.css";
        }
    }
}