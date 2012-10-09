<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="SelectShippingSpeed.aspx.cs" Inherits="SelectShippingSpeed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <asp:DropDownList ID="ddlShippingSpeed" runat="server" >
        <asp:ListItem>Next Day</asp:ListItem>
        <asp:ListItem>Two Day</asp:ListItem>
        <asp:ListItem>Standard</asp:ListItem>
        <asp:ListItem>Saver</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="bnNext" runat="server" onclick="bnNext_Click" Text="Next" />
    <br />
    <br />
    <asp:Label ID="lblCurTotal" runat="server"></asp:Label>
    <br />
</asp:Content>

