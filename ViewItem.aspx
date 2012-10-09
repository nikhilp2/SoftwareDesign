<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="ViewItem.aspx.cs" Inherits="ViewItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
        Item Type ID:&nbsp;
        <asp:TextBox ID="txtItemTypeID" runat="server"></asp:TextBox>
    </p>
    <p>
        Item Number:&nbsp;
        <asp:TextBox ID="TextBoxItemNum" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="AddToCartButton" runat="server" onclick="AddToCartButton_Click" 
            Text="Add To Cart" />
    </p>
    <p>
        <asp:Label ID="TempLabel" runat="server"></asp:Label>
    </p>
</asp:Content>

