<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="members.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 315px">
                &nbsp;</td>
            <td>
                Welcome
                <asp:Label ID="UserLabel" runat="server"></asp:Label>
&nbsp;<asp:LinkButton ID="SignOUtLNK" runat="server" onclick="SignOUtLNK_Click">Sign Out</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 315px">
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="userID" DataSourceID="SqlDataSource1" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:BoundField DataField="username" HeaderText="username" 
                            SortExpression="username" />
                        <asp:BoundField DataField="password" HeaderText="password" 
                            SortExpression="password" />
                        <asp:BoundField DataField="firstname" HeaderText="firstname" 
                            SortExpression="firstname" />
                        <asp:BoundField DataField="lastname" HeaderText="lastname" 
                            SortExpression="lastname" />
                        <asp:BoundField DataField="address" HeaderText="address" 
                            SortExpression="address" />
                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                        <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
                        <asp:BoundField DataField="zip" HeaderText="zip" SortExpression="zip" />
                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                        <asp:BoundField DataField="OrgID" HeaderText="OrgID" SortExpression="OrgID" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:conn %>" 
                    SelectCommand="SELECT * FROM [users] WHERE ([session] = @session)"
                    UpdateCommand="UPDATE [users] SET [username] = @username, [password] = @password, [firstname] = @firstname, [lastname] = @lastname, [address] = @address, [city] = @city, [state] = @state, [zip] = @zip, [email] = @email, [OrgID] = @OrgID WHERE [userID] = @userID">
                    <SelectParameters>
                        <asp:SessionParameter Name="session" SessionField="user" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="userID" Type="Int32" />
                        <asp:Parameter Name="username" Type="String" />
                        <asp:Parameter Name="password" Type="String" />
                        <asp:Parameter Name="firstname" Type="String" />
                        <asp:Parameter Name="lastname" Type="String" />
                        <asp:Parameter Name="address" Type="String" />
                        <asp:Parameter Name="city" Type="String" />
                        <asp:Parameter Name="state" Type="String" />
                        <asp:Parameter Name="zip" Type="String" />
                        <asp:Parameter Name="email" Type="String" />
                        <asp:Parameter Name="OrgID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 315px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

