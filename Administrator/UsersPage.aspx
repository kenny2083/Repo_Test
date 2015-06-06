<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeFile="UsersPage.aspx.cs" Inherits="Administrator_UsersPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlacePageName" Runat="Server">
    <asp:Label ID="PageNameLabel" CssClass="PageNameLabel" runat="server" Text="Customers"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceTopMenu" Runat="Server">
    <div class="SearchDiv">
        <asp:TextBox ID="TextBoxSearch" CssClass="TextBoxSearch" placeholder="Search Customers" runat="server"></asp:TextBox>
        <asp:DropDownList ID="DropDownListSearchOptions" CssClass="DropDownListSearchOptions" runat="server"></asp:DropDownList>
        <asp:Button ID="ButtonSearch" CssClass="TopMenuButton" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
    </div>
    <asp:Button ID="ButtonExport" CssClass="ButtonExport" runat="server" Text="Export" OnClick="ButtonExport_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceData" Runat="Server">
    <asp:Repeater ID="RepeaterCustomers" runat="server">
        <HeaderTemplate>
            <table>
                <tr class="TableHeader">
                    <td>E-Mail</td>
                    <td>First Name</td>
                    <td>Last Name</td>
                    <td>Company Name</td>
                    <td>Phone</td>
                    <td>End Date</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr onclick="selectRecord(<%#Eval("Id") %>, this)">
                <td>
                    <%#Eval("Mail") %>
                </td>
                <td>
                    <%#Eval("FirstName") %>
                </td>
                <td>
                    <%#Eval("LastName") %>
                </td>
                <td>
                    <%#Eval("CompanyName") %>
                </td>
                <td>
                    <%#Eval("Phone") %>
                </td>
                <td>
                    <%#Eval("DateEnd", "{0:d}") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div class="DivPageNavigation">
        <asp:Button ID="ButtonPreviousPage" CssClass="TopMenuButton" runat="server" Text="Previous" OnClick="ButtonPreviousPage_Click" />
        <asp:Button ID="ButtonNextPage" CssClass="TopMenuButton" runat="server" Text="Next" OnClick="ButtonNextPage_Click" />
    </div>
    <div class="DivPageNumbers" id="DivPageNumbers" runat="server">

    </div>

    <asp:HiddenField ID="HiddenFieldPageNumber" runat="server" ClientIDMode="Static" OnValueChanged="HiddenFieldPageNumber_ValueChanged" />
    <asp:HiddenField ID="HiddenFieldPageSize" runat="server" />
    <asp:HiddenField ID="HiddenFieldPagesCount" runat="server" />

    <script type="text/javascript">

        var selectedRecord = null;
        var selectedRow = null;

        function selectRecord(id, objectRow)
        {
            if (selectedRow != null) {
                selectedRow.style.backgroundColor = "#ffffff";
                selectedRow.style.color = "#000000";
            }
            selectedRecord = id;
            objectRow.style.backgroundColor = "#4d90fe";
            objectRow.style.color = "#ffffff";
            selectedRow = objectRow;
            alert(id);
        }

        var currentButton = null;

        function pageNumberButtonClick(button) {
            if (currentButton != null) {
                currentButton.style.backgroundColor = "#efefef";
                currentButton.style.color = "#000000";
            }
            button.style.backgroundColor = "#4d90fe";
            button.style.color = "#ffffff";
            currentButton = button;
        }

    </script>
</asp:Content>

