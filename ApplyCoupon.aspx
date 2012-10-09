<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="ApplyCoupon.aspx.cs" Inherits="ApplyCoupon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
        Enter Coupon ID:&nbsp;
        <asp:TextBox ID="txtCID" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="ApplyButton" runat="server" onclick="ApplyButton_Click" 
            Text="Apply" />
    </p>
    <p>
        <asp:Label ID="TempLabel" runat="server"></asp:Label>
    </p>
</asp:Content>

