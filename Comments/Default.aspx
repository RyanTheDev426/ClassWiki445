<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5_AGon.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My ASP.NET Application</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" Width="100%" BackColor="#4A6DA7" Height="60px">
            <asp:Label ID="Label1" runat="server" Text=" TryIt - Comment System" 
                Font-Size="XX-Large" ForeColor="White" Style="margin: 10px;"></asp:Label>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" BackColor="#375580" Width="100%" Height="30px">
            <asp:Button ID="Button1" runat="server" Text="Home" BackColor="Transparent" 
                BorderStyle="None" ForeColor="White" />
            <asp:Button ID="Button2" runat="server" Text="About" BackColor="Transparent" 
                BorderStyle="None" ForeColor="White" />
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" Style="margin: 20px;">
            <h2>CSE 445</h2>
            <h2>Overall Rating</h2>
            <p>
                Resources</p>
            <h2>&nbsp;</h2>
            <h2>&nbsp;</h2>
            <h2>Comments Service</h2>
            <p>Add and retrieve comments for specific pages</p>

            <div style="margin-bottom: 10px;">
                <asp:Label ID="Label2" runat="server" Text="Username:"></asp:Label><br />
                <asp:TextBox ID="UsernameTextBox" runat="server" Width="300px"></asp:TextBox>
            </div>

            <div style="margin-bottom: 10px;">
                <asp:Label ID="Label4" runat="server" Text="Page ID:"></asp:Label><br />
                <asp:TextBox ID="PageId" runat="server" Width="300px"></asp:TextBox>
            </div>

            <div style="margin-bottom: 10px;">
                <asp:Label ID="Label3" runat="server" Text="Comment:"></asp:Label><br />
                <asp:TextBox ID="CommentToAddTextBox" runat="server" Width="300px" 
                    Height="100px" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div style="margin-bottom: 20px;">
                <asp:Button ID="Button3" runat="server" Text="Add Comment" OnClick="Button3_Click" 
                    BackColor="#4A6DA7" ForeColor="White" />
                <asp:Label ID="ResultLabel" runat="server" ForeColor="Green"></asp:Label>
            </div>

            <h3>Comments:</h3>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                OnRowCommand="GridView1_RowCommand"
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                CellPadding="4" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Content" HeaderText="Comment" />
                    <asp:BoundField DataField="Date" DataFormatString="{0:g}" HeaderText="Date Posted" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="DeleteButton" runat="server" 
                                CommandName="DeleteComment" 
                                CommandArgument='<%# string.Format("{0}|{1}|{2}",
                                    Eval("Date", "{0:M/d/yyyy h:mm:ss tt}"), 
                                    Eval("Username"), 
                                    Eval("Content")) %>'
                                Text="Delete" 
                                CssClass="button" 
                                OnClientClick="return confirm('Are you sure you want to delete this comment?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#4A6DA7" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="White" ForeColor="#000066" />
                <AlternatingRowStyle BackColor="#F0F0F0" />
            </asp:GridView>

            <div style="margin-top: 40px;">
                <h2>Hash Service</h2>
                <p>Test SHA256 hashing functionality</p>

                <div style="margin-bottom: 10px;">
                    <asp:Label ID="Label5" runat="server" Text="Text to Hash:"></asp:Label><br />
                    <asp:TextBox ID="HashInput" runat="server" Width="300px"></asp:TextBox>
                </div>

                <div style="margin-bottom: 20px;">
                    <asp:Button ID="HashButton" runat="server" Text="Generate Hash" OnClick="HashButton_Click" BackColor="#4A6DA7" ForeColor="White" />
                    <br />
                    <asp:Label ID="HashResult" runat="server" ForeColor="White"></asp:Label>
                </div>
            </div>

            </asp:Panel>
            </form>
            </body>
            </html>