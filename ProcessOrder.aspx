<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProcessOrder.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        Order ID:&nbsp;
        <asp:TextBox ID="txtOrderID" runat="server" Width="238px"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
&nbsp;<asp:Button ID="btnOrderButton" runat="server" onclick="Button1_Click" 
            Text="Submit" />
    </p>
    <p>
        <asp:Label ID="TempLabel" runat="server"></asp:Label>
    </p>
</asp:Content>

