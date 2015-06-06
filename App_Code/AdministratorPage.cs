using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdministratorPage
/// </summary>
public class AdministratorPage : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        if (Session["Administrator"] == null)
        {
            Response.End();
        }
    }
}