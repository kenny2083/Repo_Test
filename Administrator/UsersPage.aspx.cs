using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_UsersPage : System.Web.UI.Page
{

    protected override void OnInit(EventArgs e)
    {
        int pageSize = 4;

        string errorMessage = string.Empty;
        int customersCount = BusinessLogic.Customer.GetCustomersCount(out errorMessage);
        int pagesCount = customersCount / pageSize + (customersCount % pageSize > 0 ? 1 : 0);
        HiddenFieldPagesCount.Value = pagesCount.ToString();

        for (int i = 0; i < pagesCount; i++)
        {
            Button pageButton = new Button();
            pageButton.ID = "ButtonPageNumber" + (i + 1).ToString();
            pageButton.CssClass = "ButtonPageNumber";
            pageButton.Text = (i + 1).ToString();
            pageButton.Click += ButtonPageNumber_Click;
            //pageButton.OnClientClick = "pageNumberButtonClick(this); return false;";
            DivPageNumbers.Controls.Add(pageButton);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownListSearchOptions.Items.Add("By E-Mail");
            DropDownListSearchOptions.Items.Add("By Name");
            DropDownListSearchOptions.Items.Add("By Company Name");

            HiddenFieldPageNumber.Value = "1";
            ButtonPreviousPage.Enabled = false;

            string errorMessage = string.Empty;
            List<BusinessLogic.Customer> customersList = BusinessLogic.Customer.GetCustomersList(Convert.ToInt32(HiddenFieldPageNumber.Value), 4, out errorMessage);
            if (string.IsNullOrEmpty(errorMessage))
            {
                DisplayData(customersList);
            }
        }
    }
    
    protected void DisplayData(List<BusinessLogic.Customer> customers)
    {
        RepeaterCustomers.DataSource = customers;
        RepeaterCustomers.DataBind();
    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        string exp = TextBoxSearch.Text;
        string errorMessage = string.Empty;
        List<BusinessLogic.Customer> foundCustomersList = BusinessLogic.Customer.SearchCustomersByName(exp, out errorMessage);
        if (foundCustomersList.Count > 0)
        {
            DisplayData(foundCustomersList);
        }
    }
    protected void ButtonPreviousPage_Click(object sender, EventArgs e)
    {
        int currentPageNum = Convert.ToInt32(HiddenFieldPageNumber.Value);
        HiddenFieldPageNumber.Value = (currentPageNum - 1).ToString();
        string errorMessage = string.Empty;
        DisplayData(BusinessLogic.Customer.GetCustomersList(Convert.ToInt32(HiddenFieldPageNumber.Value), 4, out errorMessage));

        ButtonNextPage.Enabled = true;

        if (Convert.ToInt32(HiddenFieldPageNumber.Value) <= 1)
        {
            ButtonPreviousPage.Enabled = false;
        }
    }
    protected void ButtonNextPage_Click(object sender, EventArgs e)
    {
        int currentPageNum = Convert.ToInt32(HiddenFieldPageNumber.Value);
        HiddenFieldPageNumber.Value = (currentPageNum + 1).ToString();
        string errorMessage = string.Empty;
        DisplayData(BusinessLogic.Customer.GetCustomersList(Convert.ToInt32(HiddenFieldPageNumber.Value), 4, out errorMessage));

        ButtonPreviousPage.Enabled = true;

        if (Convert.ToInt32(HiddenFieldPageNumber.Value) >= Convert.ToInt32(HiddenFieldPagesCount.Value))
        {
            ButtonNextPage.Enabled = false;
        }
    }

    protected void ButtonPageNumber_Click(object sender, EventArgs e)
    {
        int pageNumber = Convert.ToInt32(((Button)sender).Text);
        string errorMessage = string.Empty;
        List<BusinessLogic.Customer> customersList = DataLayer.DataManager.SelectCustomersByPage(pageNumber, 4, out errorMessage);
        if (string.IsNullOrEmpty(errorMessage))
        {
            DisplayData(customersList);
        }

        HiddenFieldPageNumber.Value = pageNumber.ToString();

        if (pageNumber >= Convert.ToInt32(HiddenFieldPagesCount.Value))
        {
            ButtonNextPage.Enabled = false;
            ButtonPreviousPage.Enabled = true;
        }
        else if (pageNumber <= 1)
        {
            ButtonNextPage.Enabled = true;
            ButtonPreviousPage.Enabled = false;
        }
        else
        {
            ButtonNextPage.Enabled = true;
            ButtonPreviousPage.Enabled = true;
        }
    }
    protected void HiddenFieldPageNumber_ValueChanged(object sender, EventArgs e)
    {
        Button currentButton = (Button)FindControl("ButtonPageNumber" + HiddenFieldPageNumber.Value);
        currentButton.Style.Add("background-color", "blue");
    }
    protected void ButtonExport_Click(object sender, EventArgs e)
    {
        System.Data.DataTable dtdata = BusinessLogic.Customer.GetCustomersDataTable();

        string attach = "attachment;filename=journal.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attach);
        Response.ContentType = "application/ms-excel";
        if (dtdata != null)
        {
            foreach (System.Data.DataColumn dc in dtdata.Columns)
            {
                Response.Write(dc.ColumnName + "\t");
                //sep = ";";
            }
            Response.Write(System.Environment.NewLine);
            foreach (System.Data.DataRow dr in dtdata.Rows)
            {
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    Response.Write(dr[i].ToString() + "\t");
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
}