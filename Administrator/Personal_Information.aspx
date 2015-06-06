<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Personal_Information.aspx.cs" Inherits="Administrator_Personal_Information" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
    <%--<link href="../App_Themes/SiteTheme/AdminPagesStyle.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="ContentPageName" ContentPlaceHolderID="ContentPlacePageName" Runat="Server">
    <asp:Label ID="PageNameLabel" CssClass="PageNameLabel" runat="server" Text='<%$ Resources:Resource, PersonalInfo %>'></asp:Label>
</asp:Content>
<asp:Content ID="ContentTopMenu" ContentPlaceHolderID="ContentPlaceTopMenu" runat="server">
    <asp:Button ID="ButtonSave" CssClass="TopMenuButton" runat="server" Text='<%$ Resources:Resource, Save %>' OnClick="ButtonSave_Click" />
    <asp:Button ID="ButtonReset" CssClass="TopMenuButton" runat="server" Text='<%$ Resources:Resource, Reset %>' OnClientClick="ResetFields()" />
</asp:Content>
<asp:Content ID="ContentData" ContentPlaceHolderID="ContentPlaceData" runat="server">
    <div class="Content">
        <div class="FormDiv">
            <div class="PropertyDiv">
                <asp:Label ID="LabelUserName" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, UserName %>'></asp:Label>
                <asp:TextBox ID="TextBoxUserName" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="PropertyDiv">
                <asp:Label ID="LabelMail" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, Mail %>'></asp:Label>
                <asp:TextBox ID="TextBoxMail" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="PropertyDiv">
                <asp:Label ID="LabelPassword" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, Password %>'></asp:Label>
                <asp:TextBox ID="TextBoxPassword" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
            <div class="PropertyDiv">
                <asp:Label ID="LabelConfirmPassword" CssClass="PropertyLabel" runat="server" Text='<%$ Resources:Resource, ConfirmPassword %>'></asp:Label>
                <asp:TextBox ID="TextBoxConfirmPassword" CssClass="PropertyTextBox" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:HiddenField ID="HiddenFieldAlertMessage" runat="server" />
        <asp:HiddenField ID="HiddenFieldUserName" runat="server" />
        <asp:HiddenField ID="HiddenFieldMail" runat="server" />
        <asp:HiddenField ID="HiddenFieldPassword" runat="server" />
    </div>

    <script type="text/javascript">

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        function EndRequest()
        {
            var HiddenFieldMessage = document.getElementById("<%=HiddenFieldAlertMessage.ClientID %>");
            var AlertMessage = HiddenFieldMessage.value;
            if (AlertMessage.length > 0)
            {
                alert(AlertMessage);
                HiddenFieldMessage.value = "";
            }
            return false;
        }

        function ResetFields()
        {
            var UserName = document.getElementById("<%=HiddenFieldUserName.ClientID %>").value;
            var Mail = document.getElementById("<%=HiddenFieldMail.ClientID %>").value;
            var Password = document.getElementById("<%=HiddenFieldPassword.ClientID %>").value;

            document.getElementById("<%=TextBoxUserName.ClientID %>").value = UserName;
            document.getElementById("<%=TextBoxMail.ClientID %>").value = Mail;
            document.getElementById("<%=TextBoxPassword.ClientID %>").value = Password;
            document.getElementById("<%=TextBoxConfirmPassword.ClientID %>").value = Password;

            return false;
        }

        <%--function Alert()
        {
            var AlertMessage = document.getElementById("<%=HiddenFieldAlertMessage.ClientID %>").value;
            alert(AlertMessage);
            return false;
        }--%>
    </script>
</asp:Content>