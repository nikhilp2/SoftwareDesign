<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="DisplayBooks.aspx.cs" Inherits="DisplayBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
    <p>
        Books:</p>
    <p>
        <asp:Table ID="tblBooks" runat="server">
        </asp:Table>
    </p>
    <p>
        <asp:Button ID="btnAddToCart" runat="server" onclick="btnAddToCart_Click" 
            Text="Add to Cart" />
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
</asp:Content>

