<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewObjects.aspx.cs" Inherits="ViewObjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
    <style type="text/css">
    .style4
    {
        color: #66CCFF;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <p>
    View Object Page</p>
    Welcome
                <asp:Label ID="UserLabel" runat="server"></asp:Label>
&nbsp;<asp:LinkButton ID="SignOUtLNK" runat="server" onclick="SignOUtLNK_Click">Sign Out</asp:LinkButton>
<p>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="ObjID" DataSourceID="SqlDataSource1" 
        ForeColor="Black" GridLines="Horizontal">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ObjID" HeaderText="ObjID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ObjID" />
            <asp:BoundField DataField="OrgID" HeaderText="OrgID" SortExpression="OrgID" />
            <asp:BoundField DataField="ObjName" HeaderText="ObjName" 
                SortExpression="ObjName" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" BorderStyle="Inset" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:conn %>" 
        DeleteCommand="DELETE FROM [Objects] WHERE [ObjID] = @ObjID" 
        InsertCommand="INSERT INTO [Objects] ([OrgID], [ObjName]) VALUES (@OrgID, @ObjName)" 
        SelectCommand="SELECT * FROM [Objects]" 
        UpdateCommand="UPDATE [Objects] SET [OrgID] = @OrgID, [ObjName] = @ObjName WHERE [ObjID] = @ObjID">
        <DeleteParameters>
            <asp:Parameter Name="ObjID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="OrgID" Type="Int32" />
            <asp:Parameter Name="ObjName" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="OrgID" Type="Int32" />
            <asp:Parameter Name="ObjName" Type="String" />
            <asp:Parameter Name="ObjID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
&nbsp;
</p>
<p>
    <a class="style4" href="InsertObject.aspx">&nbsp;Click here to add a new object&nbsp;</a></p>
<p>
    &nbsp;</p>
</asp:Content>

