<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFields.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
    <p>
        View Fields Page</p>
        Welcome
                <asp:Label ID="UserLabel" runat="server"></asp:Label>
&nbsp;<asp:LinkButton ID="SignOUtLNK" runat="server" onclick="SignOUtLNK_Click">Sign Out</asp:LinkButton>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="FieldID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="FieldID" HeaderText="FieldID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="FieldID" />
                <asp:BoundField DataField="OrgID" HeaderText="OrgID" SortExpression="OrgID" />
                <asp:BoundField DataField="ObjID" HeaderText="ObjID" SortExpression="ObjID" />
                <asp:BoundField DataField="FieldName" HeaderText="FieldName" 
                    SortExpression="FieldName" />
                <asp:BoundField DataField="Datatype" HeaderText="Datatype" 
                    SortExpression="Datatype" />
                <asp:BoundField DataField="FieldNumber" HeaderText="FieldNumber" 
                    SortExpression="FieldNumber" />
                <asp:BoundField DataField="MasterKey" HeaderText="MasterKey" 
                    SortExpression="MasterKey" />
                <asp:BoundField DataField="ForeignKeyFieldID" HeaderText="ForeignKeyFieldID" 
                    SortExpression="ForeignKeyFieldID" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:conn %>" 
            DeleteCommand="DELETE FROM [Fields] WHERE [FieldID] = @FieldID" 
            InsertCommand="INSERT INTO [Fields] ([OrgID], [ObjID], [FieldName], [Datatype], [FieldNumber], [MasterKey], [ForeignKeyFieldID]) VALUES (@OrgID, @ObjID, @FieldName, @Datatype, @FieldNumber, @MasterKey, @ForeignKeyFieldID)" 
            SelectCommand="SELECT * FROM [Fields]" 
            UpdateCommand="UPDATE [Fields] SET [OrgID] = @OrgID, [ObjID] = @ObjID, [FieldName] = @FieldName, [Datatype] = @Datatype, [FieldNumber] = @FieldNumber, [MasterKey] = @MasterKey, [ForeignKeyFieldID] = @ForeignKeyFieldID WHERE [FieldID] = @FieldID">
            <DeleteParameters>
                <asp:Parameter Name="FieldID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="OrgID" Type="Int32" />
                <asp:Parameter Name="ObjID" Type="Int32" />
                <asp:Parameter Name="FieldName" Type="String" />
                <asp:Parameter Name="Datatype" Type="String" />
                <asp:Parameter Name="FieldNumber" Type="Int32" />
                <asp:Parameter Name="MasterKey" Type="Int32" />
                <asp:Parameter Name="ForeignKeyFieldID" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="OrgID" Type="Int32" />
                <asp:Parameter Name="ObjID" Type="Int32" />
                <asp:Parameter Name="FieldName" Type="String" />
                <asp:Parameter Name="Datatype" Type="String" />
                <asp:Parameter Name="FieldNumber" Type="Int32" />
                <asp:Parameter Name="MasterKey" Type="Int32" />
                <asp:Parameter Name="ForeignKeyFieldID" Type="Int32" />
                <asp:Parameter Name="FieldID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
    <a class="style4" href="InsertField.aspx">Click here to add a new field</a></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
</asp:Content>

