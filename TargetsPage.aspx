<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TargetsPage.aspx.cs" Inherits="TargetsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlacePageName" Runat="Server">
    <asp:Label ID="PageNameLabel" CssClass="PageNameLabel" Text="Targets" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceTopMenu" Runat="Server">
    <asp:Button ID="TopMenuButton" CssClass="TopMenuButton" runat="server" Text="Add" OnClick="TopMenuButton_Click" />
    <asp:Button ID="TopMenuButton1" CssClass="TopMenuButton" runat="server" Text="Edit" />
    <asp:Button ID="TopMenuButton2" CssClass="TopMenuButton" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceData" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceEditData" Runat="Server">
    <asp:Label ID="EditTitleLabel" CssClass="EditTitleLabel" Text="Add a target" runat="server"></asp:Label>
    <asp:TextBox ID="TextBoxNewTargetText" runat="server"></asp:TextBox>
    <asp:CheckBox ID="CheckBoxTargetVAT" runat="server" />
    <asp:Button ID="ButtonSaveNewTarget" runat="server" Text="Add" OnClick="ButtonSaveNewTarget_Click"/>

    <asp:HiddenField ID="HiddenFieldMessage" runat="server" />

    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        function EndRequest() {
            var MessageObject = document.getElementById("<%=HiddenFieldMessage.ClientID %>");
            var MessageValue = MessageObject.value;
            if (MessageValue.length > 0) {
                alert(MessageValue);
            }
        }
    </script>
</asp:Content>

