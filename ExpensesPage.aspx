<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExpensesPage.aspx.cs" Inherits="ExpensesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlacePageName" Runat="Server">
    <asp:Label ID="PageNameLabel" CssClass="PageNameLabel" Text="Expenses" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceTopMenu" Runat="Server">
    <asp:Button ID="TopMenuButton" CssClass="TopMenuButton" runat="server" Text="Add" OnClick="TopMenuButton_Click"/>
    <asp:Button ID="TopMenuButton1" CssClass="TopMenuButton" runat="server" Text="Edit" />
    <asp:Button ID="TopMenuButton2" CssClass="TopMenuButton" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceData" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceEditData" Runat="Server">
    <asp:Label ID="EditTitleLabel" CssClass="EditTitleLabel" Text="Add an expense" runat="server"></asp:Label>
    <asp:TextBox ID="TextBoxAmount" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownListTargets" runat="server"></asp:DropDownList>
    <asp:DropDownList ID="DropDownListPaymentType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListPaymentType_SelectedIndexChanged"></asp:DropDownList>
    <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>
    <asp:DropDownList ID="DropDownListCreditCards" runat="server" Enabled="false"></asp:DropDownList>
    <asp:DropDownList ID="DropDownListBanks" runat="server" Enabled="false"></asp:DropDownList>
    <asp:TextBox ID="TextBoxAccountNumber" runat="server" Enabled="false"></asp:TextBox>
    <asp:TextBox ID="TextBoxBranchName" runat="server" Enabled="false"></asp:TextBox>
    <asp:TextBox ID="TextBoxCheckNumber" runat="server" Enabled="false"></asp:TextBox>
</asp:Content>

