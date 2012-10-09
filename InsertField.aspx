<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsertField.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
        Insert Field</p>
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
        Field Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="FieldNameBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Datatype:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="DataTypeBox" runat="server"></asp:TextBox>
    </p>
    <p>
        Field Number:&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="FieldNumBox" runat="server"></asp:TextBox>
    </p>
    <p>
        MasterKey:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="MasterKeyBox" runat="server" 
            oncheckedchanged="CheckBox1_CheckedChanged" Text="Yes" />
    </p>
    <p>
        Foreign Key ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="ForeignKeyBox" runat="server"></asp:TextBox>
    </p>
    <p>
    <asp:Button ID="InsertButton" runat="server" onclick="InsertButton_Click" 
        Text="Insert" />
    </p>
    </asp:Content>

