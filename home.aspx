<%@ Page Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headers" runat="server">

    <style type="text/css">
    .style4
    {
        width: 356px;
        height: 299px;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" runat="server">
    <h2>Welcome to Sun Devil Inc</h2>
            <a id="login" href="login.aspx" runat="server">Login</a> | <a id="register" href="register.aspx" runat="server">Register Now!</a>
			<h1>
                <img class="style4" src="images/welcome.jpg" /></h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" runat="server">
</asp:Content>
