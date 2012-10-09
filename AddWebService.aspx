<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddWebService.aspx.cs" Inherits="AddWebService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
    <style type="text/css">

    .style7
    {
        color: #FF3300;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
    Add a new Web Service:</p>
<p>
    Name:
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="ReqName" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="Name Required" 
                    CssClass="style7">* Please enter a name</asp:RequiredFieldValidator>
              
</p>
<p>
    URL:&nbsp;
    <asp:TextBox ID="txtURL" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorURL" runat="server" 
                    ControlToValidate="txtURL" ErrorMessage="URL Required" 
                    CssClass="style7">* Please enter a URL</asp:RequiredFieldValidator>
            
</p>
<p>
    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
        Text="Submit" />
</p>
</asp:Content>

