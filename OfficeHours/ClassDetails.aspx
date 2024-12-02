<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassDetails.aspx.cs" Inherits="OfficeHours.ClassDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>
    Class Details
    </h2>
    <form id="form1" runat="server">
        <br />
        <asp:Label ID="LabelClass" runat="server" Text=""></asp:Label>
        <h3>
            Overall Rating:
        </h3>
        <br />
        <asp:Label ID="LabelRating" runat="server" Text=""></asp:Label>
        <br /> 
        Professor: <asp:Label ID="LabelProf" runat="server" Text=""></asp:Label>
        <br />
        TA(s): <asp:Label ID="LabelTAs" runat="server" Text=""></asp:Label>
        <br />
        Office Hours: <asp:Label ID="LabelOfficeHours" runat="server" Text=""></asp:Label>
        <br />
        TA Hours: <asp:Label ID="LabelTAHours" runat="server" Text=""></asp:Label>
        <br />
        <br />
        Comments: 
        <br />

    </form>
</body>
</html>
