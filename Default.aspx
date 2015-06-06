<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_Themes/SiteTheme/EnterPageStyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="formData" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="MainDiv">
                    <div class="LeftContentDiv">
                        <img src="../Images/Logo_b.png" class="Logo" />
                        <div class="Separator"></div>
                        <asp:TextBox ID="TextBoxMail" CssClass="TextBox" runat="server" placeholder='<%$ Resources:Resource, Mail %>' ></asp:TextBox>
                        <asp:TextBox ID="TextBoxPassword" CssClass="TextBox" runat="server" TextMode="Password" placeholder='<%$ Resources:Resource, Password %>'></asp:TextBox>
                        <asp:Button ID="ButtonSend" CssClass="ButtonSend" runat="server" Text='<%$ Resources:Resource, Enter %>' OnClick="ButtonSend_Click"  />
                        <asp:Label ID="LabelError" CssClass="LabelError" runat="server"></asp:Label>
                    </div>
                </div>
                <asp:HiddenField ID="HiddenFieldPageAddress" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
            function EndRequest()
            {
                var PageAddressObject = document.getElementById("<%=HiddenFieldPageAddress.ClientID %>");
                var PageAddressValue = PageAddressObject.value;
                if (PageAddressValue.length > 0)
                {
                    location.replace(PageAddressValue);
                    return;
                }
            }
        </script>

    </form>
</body>
</html>
