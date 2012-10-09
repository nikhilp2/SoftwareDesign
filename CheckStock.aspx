<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CheckStock.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="content">
    Items:<br />
    <asp:Table ID="tblItems" runat="server">
    </asp:Table>
    <asp:Button ID="btnShipInStock" runat="server" onclick="btnShipInStock_Click" 
        Text="Ship Items That Are In Stock" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnShipAll" runat="server" onclick="btnShipAll_Click" 
        Text="Wait Until All Items Are In Stock" />
    <br />
    <br />
    <asp:Label ID="UserLabel" runat="server"></asp:Label>
</asp:Content>


