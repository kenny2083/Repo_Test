using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestPage : CustomerPage
{

    protected override void OnInit(EventArgs e)
    {
        PageNameLabel.Text = Resources.Resource.PageTitle;

        TopMenuButton.Text = Resources.Resource.Action;
        TopMenuButton1.Text = Resources.Resource.Action;
        TopMenuButton2.Text = Resources.Resource.Action;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        //System.Web.UI.HtmlControls.HtmlGenericControl EditDataDiv =
        //    (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("EditDataDiv");
        //if (EditDataDiv.Style["visibility"] == "visible")
        //{
        //    EditDataDiv.Style.Add("visibility", "hidden");
        //}
    }
    protected void TopMenuButton_Click(object sender, EventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl EditDataDiv = 
            (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("EditDataDiv");

        EditDataDiv.Style.Add("visibility", "visible");
    }
}