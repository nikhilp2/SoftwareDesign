<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="PlaceOrder.aspx.cs" Inherits="PlaceOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
        Cart ID:&nbsp;&nbsp;
        <asp:TextBox ID="txtCartID" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnPlaceOrder" runat="server" onclick="btnPlaceOrder_Click" 
            Text="Place Order" />
    </p>
    <p>
        <asp:Label ID="TempLabel" runat="server"></asp:Label>
    </p>
</asp:Content>

