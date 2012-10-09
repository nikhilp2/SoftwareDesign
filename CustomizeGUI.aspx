<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomizeGUI.aspx.cs" Inherits="CustomizeGUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
        Header Text:<asp:TextBox ID="txtHeader" runat="server"></asp:TextBox>
    </p>
    <p>
        Background Image:<asp:DropDownList ID="ddlBackground" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="idImage">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:conn %>" 
            SelectCommand="SELECT * FROM [Images] ORDER BY [Name]"></asp:SqlDataSource>
    </p>
    <p>
        Footer Text:<asp:TextBox ID="txtFooter" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
            Text="Submit" />
    </p>
</asp:Content>

