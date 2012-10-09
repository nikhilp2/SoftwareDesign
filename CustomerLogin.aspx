<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="CustomerLogin.aspx.cs" Inherits="CustomerLogin" %>

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
    .style8
    {
        color: #FF0000;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
<p>Welcome to our webpage</p>
    <table style="width:100%; height: 138px;" bgcolor="#99FFCC">
        <tr>
            <td class="style4" colspan="3">
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                User Name:</td>
            <td class="style5">
                <asp:TextBox ID="tb1UserName" runat="server" Width="178px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqUserName" runat="server" 
                    ControlToValidate="tb1UserName" ErrorMessage="User Name Required" 
                    CssClass="style7">* Please enter your Username</asp:RequiredFieldValidator>
              
        </tr>
        <tr>
            <td class="style6">
                Password:</td>

            <td class="style5">
                <asp:TextBox ID="tb1Password" runat="server" TextMode="Password" Width="176px"></asp:TextBox>
            </td>
            <td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tb1UserName" ErrorMessage="Password Required" 
                    CssClass="style7">* Please enter your Password</asp:RequiredFieldValidator>
            
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                <asp:Button ID="btn2Login" runat="server" onclick="btn2Login_Click" Text="Log In" 
                    Width="107px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>