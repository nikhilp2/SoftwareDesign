<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
    <style type="text/css">
        .style4
        {
        }
        .style5
        {
            width: 182px;
        }
        .style6
        {
            width: 94px;
        }
    .style7
    {
        color: #FF3300;
    }
        .style9
        {
            color: #66CCFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
<p class="style7">For Admin Users Only</p>
    <table style="width:100%;">
        <tr>
            <td class="style4" colspan="3">
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                User Name:</td>
            <td class="style5">
                <asp:TextBox ID="tbUserName" runat="server" Width="178px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqUserName" runat="server" 
                    ControlToValidate="tbUserName" ErrorMessage="User Name Required" 
                    CssClass="style7">* Please enter your Username</asp:RequiredFieldValidator>
              
        </tr>
        <tr>
            <td class="style6">
                Password:</td>

            <td class="style5">
                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="176px"></asp:TextBox>
            </td>
            <td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tbUserName" ErrorMessage="Password Required" 
                    CssClass="style7">* Please enter your Password</asp:RequiredFieldValidator>
            
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" Text="Log In" 
                    Width="107px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    <p> If you are not an admin user. Please click <span class="style9">
        <a href="CustomerLogin.aspx">Here</a></span>
    </p>
</asp:Content>