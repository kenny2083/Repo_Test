<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Add_Customer.aspx.cs" Inherits="Administrator_Add_User" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
    <%--<link href="../App_Themes/SiteTheme/AdminPagesStyle.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="ContentPageName" ContentPlaceHolderID="ContentPlacePageName" Runat="Server">
    <asp:Label ID="PageNameLabel" CssClass="PageNameLabel" runat="server" Text='<%$ Resources:Resource, AddCustomer %>'></asp:Label>
</asp:Content>
<asp:Content ID="ContentTopMenu" ContentPlaceHolderID="ContentPlaceTopMenu" Runat="Server">
    <asp:Button ID="ButtonSave" CssClass="TopMenuButton" runat="server" Text='<%$ Resources:Resource, Save %>' OnClick="ButtonSave_Click" />
    <asp:Button ID="ButtonReset" CssClass="TopMenuButton" runat="server" Text='<%$ Resources:Resource, Reset %>' />
</asp:Content>
<asp:Content ID="ContentData" ContentPlaceHolderID="ContentPlaceData" Runat="Server">
    <div class="Content">
        <div class="FormDiv">
            <div class="PropertyDiv">
                <asp:Label ID="LabelUserMail" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, Mail %>'></asp:Label>
                <asp:TextBox ID="TextBoxMail" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="PropertyDiv">
                <asp:Label ID="LabelPassword" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, Password %>'></asp:Label>
                <asp:TextBox ID="TextBoxPassword" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="PropertyDiv">
                <asp:Label ID="LabelFistName" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, FirstName %>'></asp:Label>
                <asp:TextBox ID="TextBoxFirstName" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="PropertyDiv">
                <asp:Label ID="LabelLastName" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, LastName %>'></asp:Label>
                <asp:TextBox ID="TextBoxLastName" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="PropertyDiv">
                <asp:Label ID="LabelCompanyName" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, CompanyName %>'></asp:Label>
                <asp:TextBox ID="TextBoxCompanyName" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="PropertyDiv">
                <asp:Label ID="LabelPhone" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, Phone %>'></asp:Label>
                <asp:TextBox ID="TextBoxPhone" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="PropertyDiv">
                <asp:Label ID="LabelDateEnd" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, DateEnd %>'></asp:Label>
                <asp:TextBox ID="TextBoxDateEnd" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:HiddenField ID="HiddenFieldAlertMessage" runat="server" />
    </div>

    <script type="text/javascript">

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        function EndRequest() {
            var HiddenFieldMessage = document.getElementById("<%=HiddenFieldAlertMessage.ClientID %>");
            var AlertMessage = HiddenFieldMessage.value;
            if (AlertMessage.length > 0) {
                alert(AlertMessage);
                HiddenFieldMessage.value = "";
            }
            return false;
        }
    </script>
</asp:Content>

