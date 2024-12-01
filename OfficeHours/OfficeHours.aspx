<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficeHours.aspx.cs" Inherits="OfficeHours.WebForm1" %>
<%@ Register TagPrefix = "uc" TagName ="OfficeHours" Src="~/OfficeHoursControl.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
    Enter office hour information to save to a file.
        <br />
        url: http://webstrar9.fulton.asu.edu/page1/OfficeHoursService.asmx
        <br />
        <br />

    </div>
    <form id="form1" runat="server">
        
        <uc:OfficeHours id ="myControl" runat ="server">
        </uc:OfficeHours>

    </form>
    <br />
    <br />
</body>
</html>
