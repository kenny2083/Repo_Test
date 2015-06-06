using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButtonClose_Click(object sender, ImageClickEventArgs e)
    {
        EditDataDiv.Style.Add("visibility", "hidden");
    }
    protected void ButtonExit_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Administrator/Default.aspx");
    }
}
