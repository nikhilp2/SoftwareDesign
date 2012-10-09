<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomizeLinks.aspx.cs" Inherits="CustomizeLinks"%>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    Cuztomize Sidebar Links:
    <asp:DropDownList ID="ddlLink" runat="server" DataSourceID="SqlDataSource1" 
        DataTextField="LinkName" DataValueField="idLinks">
    </asp:DropDownList>
    &nbsp;Order:&nbsp;
    <asp:TextBox ID="txtOrder" runat="server"></asp:TextBox>
&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conn %>" 
        SelectCommand="SELECT [idLinks], [LinkName], [URL] FROM [Links] WHERE ([CustomerID] = @CustomerID) ORDER BY [LinkName]">
        <SelectParameters>
            <asp:Parameter DefaultValue="1001" Name="CustomerID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
        Text="Add Link" />
    <br />
    <asp:BulletedList ID="blLinks" runat="server">
    </asp:BulletedList>
    <br />
    Remove Item Number:
    <asp:TextBox ID="txtRemove" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnRemove" runat="server" Text="Remove" 
        onclick="btnRemove_Click" />
    <br />
    <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="Submit" />
    </asp:Content>

