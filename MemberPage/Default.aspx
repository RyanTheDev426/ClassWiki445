<%@ Page Title="Class List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalPages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header-container" style="display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px;">
        <h2>Class List</h2>
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
    </div>

    <div class="class-list">
        <asp:Repeater ID="ClassRepeater" runat="server" OnItemCommand="ClassRepeater_ItemCommand">
            <ItemTemplate>
                <div class="class-item" style="margin-bottom: 10px;">
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                                  CommandName="ViewClass" 
                                  CommandArgument='<%# Eval("ClassID") %>'
                                  CssClass="btn btn-link">
                        <%# Eval("ClassName") %>
                    </asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <% if (User.IsInRole("Staff")) { %>
    <div class="add-class" style="margin-top: 20px;">
        <asp:Button ID="btnAddClass" runat="server" Text="Add New Class" 
                    OnClick="btnAddClass_Click" CssClass="btn btn-primary" />
    </div>
    <% } %>

</asp:Content>