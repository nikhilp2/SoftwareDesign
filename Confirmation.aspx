<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
    <style type="text/css">
    .style4
    {
        color: #66FF33;
    }
    .style5
    {
        color: #FF0000;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <h4 class="style4">
        Your registration has been successfully created!</h4>
<p class="style4">
        &nbsp;</p>
<p class="style5">
        <a href="login.aspx">Click here to login</a></p>
</asp:Content>

