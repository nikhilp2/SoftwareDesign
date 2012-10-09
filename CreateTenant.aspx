<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateTenant.aspx.cs" Inherits="CreateTenant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Tenant Name:</td>
            <td class="style5">
                <asp:TextBox ID="txtTenatName" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="TenatNameReq" runat="server" 
                    ErrorMessage="Tenant Name Required" ControlToValidate="txtTenatName" 
                    CssClass="style6" ForeColor="Red">* Please enter your tenant name</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="99px" 
                    onclick="btnSubmit_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

