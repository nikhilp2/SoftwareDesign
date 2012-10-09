<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomizeWorkFlow.aspx.cs" Inherits="CustomizeWorkFlow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
        Customize a Workflow:<asp:SqlDataSource ID="FadiSqlDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:conn %>" 
            SelectCommand="SELECT [workflowID], [Name] FROM [Workflows]">
        </asp:SqlDataSource>
    </p>
    <p>
        Select a workflow:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlWorkflow" runat="server" 
            DataSourceID="FadiSqlDataSource" DataTextField="Name" 
            DataValueField="workflowID" >
        </asp:DropDownList>
    &nbsp;
        <asp:Button ID="btnCustomize" runat="server" onclick="btnCustomize_Click" 
            Text="Customize Workflow" />
    </p>
    <p>
        Select next service:&nbsp;&nbsp;
        <asp:DropDownList ID="ddlService" runat="server" 
            DataSourceID="FadiSqlDataSource2" DataTextField="serviceName" 
            DataValueField="serviceID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="FadiSqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:conn %>" 
            SelectCommand="SELECT [serviceID], [serviceName] FROM [Services] WHERE (([orgID] = @orgID) OR ([orgID] = @orgID2))">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="orgID" SessionField="OrgID" 
                    Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="orgID2" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        Order of service:
        <asp:TextBox ID="txtOrder" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddService" runat="server" onclick="btnAddService_Click" 
            Text="Add Service" />
    </p>
    <asp:BulletedList ID="blServices" runat="server" BulletStyle="Numbered">
    </asp:BulletedList>
    &nbsp;<br />
    <asp:Button ID="btnAddWorkflow" runat="server" Text="Update Workflow" 
        onclick="btnAddWorkflow_Click" />
<br />
<br />
Remove service (please enter a number):&nbsp;&nbsp;
<asp:TextBox ID="txtRemove" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnRemove" runat="server" onclick="btnRemove_Click" 
    Text="Remove Service" />
</asp:Content>

