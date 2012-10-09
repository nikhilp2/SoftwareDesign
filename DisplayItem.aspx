<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="DisplayItem.aspx.cs" Inherits="DisplayItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
    <p id="itemDisplayName" runat="server">
    </p>
    <p>
        <asp:Table ID="tblItems" runat="server">
        </asp:Table>
    </p>
    <p>
        <asp:Button ID="btnAddToCart" runat="server" onclick="btnAddToCart_Click" 
            Text="Add to Cart" />
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
</asp:Content>

