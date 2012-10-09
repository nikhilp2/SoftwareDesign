<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewData.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
    <p>
        View Data Page</p>
    <p>
                Welcome
                <asp:Label ID="UserLabel" runat="server"></asp:Label>
&nbsp;<asp:LinkButton ID="SignOUtLNK" runat="server" onclick="SignOUtLNK_Click">Sign Out</asp:LinkButton>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="GUID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="GUID" HeaderText="GUID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="GUID" />
                <asp:BoundField DataField="OrgID" HeaderText="OrgID" SortExpression="OrgID" />
                <asp:BoundField DataField="ObjID" HeaderText="ObjID" SortExpression="ObjID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Value00" HeaderText="Value00" 
                    SortExpression="Value00" />
                <asp:BoundField DataField="Value01" HeaderText="Value01" 
                    SortExpression="Value01" />
                <asp:BoundField DataField="Value02" HeaderText="Value02" 
                    SortExpression="Value02" />
                <asp:BoundField DataField="Value03" HeaderText="Value03" 
                    SortExpression="Value03" />
                <asp:BoundField DataField="Value04" HeaderText="Value04" 
                    SortExpression="Value04" />
                <asp:BoundField DataField="Value05" HeaderText="Value05" 
                    SortExpression="Value05" />
                <asp:BoundField DataField="Value06" HeaderText="Value06" 
                    SortExpression="Value06" />
                <asp:BoundField DataField="Value07" HeaderText="Value07" 
                    SortExpression="Value07" />
                <asp:BoundField DataField="Value08" HeaderText="Value08" 
                    SortExpression="Value08" />
                <asp:BoundField DataField="Value09" HeaderText="Value09" 
                    SortExpression="Value09" />
                <asp:BoundField DataField="Value10" HeaderText="Value10" 
                    SortExpression="Value10" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:conn %>" 
            DeleteCommand="DELETE FROM [Data] WHERE [GUID] = @GUID" 
            InsertCommand="INSERT INTO [Data] ([OrgID], [ObjID], [Name], [Value00], [Value01], [Value02], [Value03], [Value04], [Value05], [Value06], [Value07], [Value08], [Value09], [Value10]) VALUES (@OrgID, @ObjID, @Name, @Value00, @Value01, @Value02, @Value03, @Value04, @Value05, @Value06, @Value07, @Value08, @Value09, @Value10)" 
            SelectCommand="SELECT * FROM [Data]" 
            UpdateCommand="UPDATE [Data] SET [OrgID] = @OrgID, [ObjID] = @ObjID, [Name] = @Name, [Value00] = @Value00, [Value01] = @Value01, [Value02] = @Value02, [Value03] = @Value03, [Value04] = @Value04, [Value05] = @Value05, [Value06] = @Value06, [Value07] = @Value07, [Value08] = @Value08, [Value09] = @Value09, [Value10] = @Value10 WHERE [GUID] = @GUID">
            <DeleteParameters>
                <asp:Parameter Name="GUID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="OrgID" Type="Int32" />
                <asp:Parameter Name="ObjID" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Value00" Type="String" />
                <asp:Parameter Name="Value01" Type="String" />
                <asp:Parameter Name="Value02" Type="String" />
                <asp:Parameter Name="Value03" Type="String" />
                <asp:Parameter Name="Value04" Type="String" />
                <asp:Parameter Name="Value05" Type="String" />
                <asp:Parameter Name="Value06" Type="String" />
                <asp:Parameter Name="Value07" Type="String" />
                <asp:Parameter Name="Value08" Type="String" />
                <asp:Parameter Name="Value09" Type="String" />
                <asp:Parameter Name="Value10" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="OrgID" Type="Int32" />
                <asp:Parameter Name="ObjID" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Value00" Type="String" />
                <asp:Parameter Name="Value01" Type="String" />
                <asp:Parameter Name="Value02" Type="String" />
                <asp:Parameter Name="Value03" Type="String" />
                <asp:Parameter Name="Value04" Type="String" />
                <asp:Parameter Name="Value05" Type="String" />
                <asp:Parameter Name="Value06" Type="String" />
                <asp:Parameter Name="Value07" Type="String" />
                <asp:Parameter Name="Value08" Type="String" />
                <asp:Parameter Name="Value09" Type="String" />
                <asp:Parameter Name="Value10" Type="String" />
                <asp:Parameter Name="GUID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <a href="InsertData.aspx">Click here to add data</a></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
</asp:Content>

