<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="DisplayCart.aspx.cs" Inherits="DisplayCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
    <p>
        Cart:</p>
    <p>
        <asp:Table ID="tblCart" runat="server">
        </asp:Table>
    </p>
    <p>
        <asp:Button ID="btnCheckOut" runat="server" onclick="btnCheckOut_Click" 
            Text="Check out" />
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
</asp:Content>

