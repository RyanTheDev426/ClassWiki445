<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OfficeHoursControl.ascx.cs" Inherits="OfficeHours.WebUserControl1" %>

     <div>
         <asp:Label ID="Label1" runat="server" Text="Add Office Hours" Font-Bold="True" Font-Italic="True" Font-Size="Large"></asp:Label>
         <br />
         <br />
         <asp:Label ID="Label2" runat="server" Text="Professor Name" Width="150px"></asp:Label>
         &nbsp;
         <asp:TextBox ID="txtprofName" runat="server" Width="200px"></asp:TextBox>
          <br />
         <asp:Label ID="Label3" runat="server" Text="Professor Office Hours" Width="150px"></asp:Label>
          &nbsp;
         <asp:TextBox ID="txtprofTime" runat="server" Width="200px"></asp:TextBox>
          <br />
          <asp:Label ID="Label4" runat="server" Text="Professor Office Location" Width="150px"></asp:Label>
          &nbsp;
          <asp:TextBox ID="txtprofLocation" runat="server" Width="200px"></asp:TextBox>
          <br />
          <asp:Label ID="Label5" runat="server" Text="TA Name" Width="150px"></asp:Label>
          &nbsp;
          <asp:TextBox ID="txttaName" runat="server" Width="200px"></asp:TextBox>
          <br />
          <asp:Label ID="Label6" runat="server" Text="TA Office Hours" Width="150px"></asp:Label>
          &nbsp;
          <asp:TextBox ID="txttaTime" runat="server" Width="200px"></asp:TextBox>
          <br />
          <asp:Label ID="Label7" runat="server" Text="TA Office Location" Width="150px"></asp:Label>
          &nbsp;
          <asp:TextBox ID="txttaLocation" runat="server" Width="200px"></asp:TextBox>
          <br />
         <br />
         <asp:Label ID="Label8" runat="server" Text="" Width="150px"></asp:Label>
         &nbsp;
         <asp:Button ID="addHoursBtn" runat="server"   Text="Add Office Hours" OnClick="Button2_Click" />
          <asp:Label ID="Label9" runat="server" Width="150px" ForeColor="#006699"></asp:Label>
     </div>
 