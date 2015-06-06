<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestPage.aspx.cs" Inherits="TestPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentPageName" ContentPlaceHolderID="ContentPlacePageName" Runat="Server">
    <asp:Label ID="PageNameLabel" CssClass="PageNameLabel" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="ContentTopMenu" ContentPlaceHolderID="ContentPlaceTopMenu" runat="server">
    <asp:Button ID="TopMenuButton" CssClass="TopMenuButton" runat="server" OnClick="TopMenuButton_Click" />
    <asp:Button ID="TopMenuButton1" CssClass="TopMenuButton" runat="server" />
    <asp:Button ID="TopMenuButton2" CssClass="TopMenuButton" runat="server" />
</asp:Content>
<asp:Content ID="ContentData" ContentPlaceHolderID="ContentPlaceData" runat="server">
    <img class="TestTable" src="../Images/TestTable.png" />
</asp:Content>
