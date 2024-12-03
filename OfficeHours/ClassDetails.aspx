<!-- written by chaitra daggubati -->
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
            Overall Ratings:
        </h3>
        <br />
        <asp:Label ID="LabelDRating" runat="server" Text=""></asp:Label>
        <br /> 
        <asp:Label ID="LabelNumDRatings" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelURating" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelNumURatings" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelAskingForReview" runat="server" Text="Want to add a Review? Rate the class out of 5 below!"></asp:Label> <!-- not meant to be changed -->
        <br />
        <asp:Label ID="LabelDiffPrompt" runat="server" Text="Rate on Difficulty:"></asp:Label> <!-- not meant to be changed -->
        <asp:TextBox ID="txtDiffRating" runat="server" />
        <asp:Button ID = "ButtonDiffInsert" runat ="server" Text="Submit Rating" OnClick="ButtonDiffInsert_Click"></asp:Button>
        <asp:Label ID="LabelDButtonConfirm" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelUsePrompt" runat="server" Text="Rate on Usefulness:"></asp:Label> <!-- not meant to be changed -->
        <asp:TextBox ID="txtUseRating" runat="server" />
        <asp:Button ID = "ButtonUseInsert" runat ="server" Text="Submit Rating" OnClick="ButtonUseInsert_Click"></asp:Button>
        <asp:Label ID="LabelUButtonConfirm" runat="server" Text=""></asp:Label>
        <br />
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
        <div class="comments-section">
            <asp:GridView ID="CommentsGrid" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Content" HeaderText="Comment" />
                    <asp:BoundField DataField="Timestamp" HeaderText="Date Posted" DataFormatString="{0:g}" />
                </Columns>
            </asp:GridView>

            <div style="margin-top: 20px;">
                <asp:TextBox ID="CommentText" runat="server" TextMode="MultiLine" Rows="3" Width="100%"></asp:TextBox>
                <br />
                <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" OnClick="btnAddComment_Click" />
                <asp:Label ID="LabelCommentConfirm" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
