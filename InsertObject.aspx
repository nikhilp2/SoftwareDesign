<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertObject.aspx.cs" Inherits="InsertObject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
    Insert Object</p>
    Welcome
                <asp:Label ID="UserLabel" runat="server"></asp:Label>
&nbsp;<asp:LinkButton ID="SignOUtLNK" runat="server" onclick="SignOUtLNK_Click">Sign Out</asp:LinkButton>
<p>
    <asp:Label ID="Label1" runat="server" Text="Orgnization ID"></asp:Label>
    :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</p>
<p>
    Object Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="InsertButton" runat="server" onclick="InsertButton_Click" 
        Text="Insert" />
</p>
</asp:Content>

