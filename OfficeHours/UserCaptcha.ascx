<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserCaptcha.ascx.cs" Inherits="OfficeHours.UserCaptcha" %>
<div>
    <asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label>
    <br />
    <asp:TextBox ID="txtAnswer" runat="server" />
    <asp:Label ID="CorrectAnswer" runat="server" Visible ="false"></asp:Label>
</div>