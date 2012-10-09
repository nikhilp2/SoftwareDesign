<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="DisplayLaptops.aspx.cs" Inherits="DisplayLaptops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
    <p>
        Laptops:</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Table ID="tblLaptops" runat="server" BorderStyle="Solid">
        </asp:Table>
    </p>
    <p>
        <asp:Button ID="btnAddToCart" runat="server" onclick="btnAddToCart_Click" 
            Text="Add to Cart" />
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
</asp:Content>

