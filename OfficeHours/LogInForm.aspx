<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInForm.aspx.cs" Inherits="OfficeHours.LogInForm" %>
<%@ Register TagPrefix = "uc" TagName ="UserCaptcha" Src="~/UserCaptcha.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username: " Width="150px"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" />
            <br />
             <asp:Label ID="Label2" runat="server" Text="Password: " Width="150px"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            <br />
            <uc:UserCaptcha ID="UserCaptcha1" runat="server" />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="" Width="200px"></asp:Label>
        </div>
    </form>
</body>
</html>
