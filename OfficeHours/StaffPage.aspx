<!-- written by chaitra daggubati -->
<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffPage.aspx.cs" Inherits="OfficeHours.StaffPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="classList">Class List</h1>
        </section>

        <div class="row">
       
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <div>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# "ClassDetails.aspx?class=" + Eval("Name") %>' />
                    </div>
                </ItemTemplate>
            </asp:ListView>
       
        </div>
        <div class="row">
            
            <asp:Button ID="BtnAddClass" runat="server" Text="Add Class" OnClick="BtnAddClass_Click" />
            
        </div>
    </main>

</asp:Content>
