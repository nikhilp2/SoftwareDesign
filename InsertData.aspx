<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertData.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
        Insert Data</p>
        Welcome
                <asp:Label ID="UserLabel" runat="server"></asp:Label>
&nbsp;<asp:LinkButton ID="SignOUtLNK" runat="server" onclick="SignOUtLNK_Click">Sign Out</asp:LinkButton>
    <p>
        Organization ID:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="OrgIDBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Object ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="ObjIDBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Object Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="ObjNameBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Value00:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value00Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value01:&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value01Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value02:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value02Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value03:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value03Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value04:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value04Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value05:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value05Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value06:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value06Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value07:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value07Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value08:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value08Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value09:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Value09Box" runat="server"></asp:TextBox>
    </p>
    <p>
        Value10:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="Value10Box" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="InsertButton" runat="server" onclick="InsertButton_Click" 
        Text="Insert" />
    </p>
</asp:Content>

