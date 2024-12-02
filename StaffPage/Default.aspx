<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StaffPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="classList">Class List</h1>
        </section>

        <div class="row">
       
            <asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
                <ItemTemplate>
                    <div>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# "ClassDetails.aspx?class=" + Eval("Name") %>' />
                    </div>
                </ItemTemplate>
            </asp:ListView>
       
        </div>
    </main>

</asp:Content>
