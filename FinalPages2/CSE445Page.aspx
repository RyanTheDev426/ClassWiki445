<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CSE445Page.aspx.cs" Inherits="FinalPages2.CSE445Page" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="ClassName" runat="server" Text="Class ID:" Font-Size="24px"></asp:Label>
        <br />
        <asp:Label ID="ClassReq" runat="server" Text="Class Requirements:" ></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="DiffRatingLabel" runat="server" Text="Difficulty Rating:"></asp:Label>
        <br />
        <asp:Label ID="DiffNumLabel" runat="server" Text="Ratings:"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter your Rating for Difficulty (1-5):"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Submit Rating" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="UseRatingLabel" runat="server" Text="Usefulness Rating:"></asp:Label>
        <br />
        <asp:Label ID="UseNumLabel" runat="server" Text="Ratings:"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Enter your Rating for Usefulness (1-5):"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Submit Rating" OnClick="Button2_Click" />
    </div>
</form>
</body>
</html>

