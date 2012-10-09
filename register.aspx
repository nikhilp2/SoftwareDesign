<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<script runat="server">

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Data.setUsr(0, tbFirstName.Text, tbLastName.Text, tbAddress.Text, tbCity.Text, DropDownListState.SelectedValue, tbZipCode.Text, tbUserName.Text, tbPassword.Text, 0, tbEmail.Text, System.Convert.ToInt32(txtTenantID.Text)))
        {

            Response.Redirect("Confirmation.aspx");
        }
        else
            Label1.Text = "User Already Exists. Please choose another user name!";
        
        
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="headers" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 113px;
        }
        .style5
        {
            width: 207px;
        }
        .style6
        {
            color: #FF0000;
        }
        .style7
        {
            color: #FF0000;
            background-color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ticker" Runat="Server">
    <p>
        Registration Page</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                User Name:</td>
            <td class="style5">
                <asp:TextBox ID="tbUserName" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="UnReq" runat="server" 
                    ErrorMessage="User Name Required" ControlToValidate="tbUserName" 
                    CssClass="style6" ForeColor="Red">* Please enter your Username</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                Password:</td>
            <td class="style5">
                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqPass" runat="server" 
                    ErrorMessage="Password Required" ControlToValidate="tbPassword" 
                    CssClass="style7" ForeColor="Red">* Please enter your Password</asp:RequiredFieldValidator>
                <span class="style7">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                E-mail:</td>
            <td class="style5">
                <asp:TextBox ID="tbEmail" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqEmail" runat="server" 
                    ErrorMessage="E-mail Required" ControlToValidate="tbEmail" ForeColor="Red" 
                    style="color: #FF0000">* Please enter you E-mail</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="tbEmail" ErrorMessage="Wrong E-mail Format" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    style="color: #FF0000"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                First Name:</td>
            <td class="style5">
                <asp:TextBox ID="tbFirstName" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqFirstName" runat="server" 
                    ErrorMessage="First Name Required" ControlToValidate="tbFirstName" 
                    CssClass="style6" ForeColor="Red">* Please enter your First name</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                Last Name:</td>
            <td class="style5">
                <asp:TextBox ID="tbLastName" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqAddress" runat="server" 
                    ErrorMessage="Last Name Required" ControlToValidate="tbLastName" 
                    CssClass="style7" ForeColor="Red">* Please enter your Last name</asp:RequiredFieldValidator>
                <span class="style7">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                Address:</td>
            <td class="style5">
                <asp:TextBox ID="tbAddress" runat="server" Height="95px" TextMode="MultiLine" 
                    Width="260px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="Address Required" ControlToValidate="tbAddress" 
                    CssClass="style6" ForeColor="Red">* Please enter your Address</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                City:</td>
            <td class="style5">
                <asp:TextBox ID="tbCity" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqCity" runat="server" 
                    ErrorMessage="City Required" ControlToValidate="tbCity" CssClass="style7" 
                    ForeColor="Red">* Please enter your City</asp:RequiredFieldValidator>
                <span class="style7">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                State:</td>
            <td class="style5">
                <asp:DropDownList ID="DropDownListState" runat="server">
	<asp:ListItem Value="AL">Alabama</asp:ListItem>
	<asp:ListItem Value="AK">Alaska</asp:ListItem>
	<asp:ListItem Value="AZ">Arizona</asp:ListItem>
	<asp:ListItem Value="AR">Arkansas</asp:ListItem>
	<asp:ListItem Value="CA">California</asp:ListItem>
	<asp:ListItem Value="CO">Colorado</asp:ListItem>
	<asp:ListItem Value="CT">Connecticut</asp:ListItem>
	<asp:ListItem Value="DC">District of Columbia</asp:ListItem>
	<asp:ListItem Value="DE">Delaware</asp:ListItem>
	<asp:ListItem Value="FL">Florida</asp:ListItem>
	<asp:ListItem Value="GA">Georgia</asp:ListItem>
	<asp:ListItem Value="HI">Hawaii</asp:ListItem>
	<asp:ListItem Value="ID">Idaho</asp:ListItem>
	<asp:ListItem Value="IL">Illinois</asp:ListItem>
	<asp:ListItem Value="IN">Indiana</asp:ListItem>
	<asp:ListItem Value="IA">Iowa</asp:ListItem>
	<asp:ListItem Value="KS">Kansas</asp:ListItem>
	<asp:ListItem Value="KY">Kentucky</asp:ListItem>
	<asp:ListItem Value="LA">Louisiana</asp:ListItem>
	<asp:ListItem Value="ME">Maine</asp:ListItem>
	<asp:ListItem Value="MD">Maryland</asp:ListItem>
	<asp:ListItem Value="MA">Massachusetts</asp:ListItem>
	<asp:ListItem Value="MI">Michigan</asp:ListItem>
	<asp:ListItem Value="MN">Minnesota</asp:ListItem>
	<asp:ListItem Value="MS">Mississippi</asp:ListItem>
	<asp:ListItem Value="MO">Missouri</asp:ListItem>
	<asp:ListItem Value="MT">Montana</asp:ListItem>
	<asp:ListItem Value="NE">Nebraska</asp:ListItem>
	<asp:ListItem Value="NV">Nevada</asp:ListItem>
	<asp:ListItem Value="NH">New Hampshire</asp:ListItem>
	<asp:ListItem Value="NJ">New Jersey</asp:ListItem>
	<asp:ListItem Value="NM">New Mexico</asp:ListItem>
	<asp:ListItem Value="NY">New York</asp:ListItem>
	<asp:ListItem Value="NC">North Carolina</asp:ListItem>
	<asp:ListItem Value="ND">North Dakota</asp:ListItem>
	<asp:ListItem Value="OH">Ohio</asp:ListItem>
	<asp:ListItem Value="OK">Oklahoma</asp:ListItem>
	<asp:ListItem Value="OR">Oregon</asp:ListItem>
	<asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
	<asp:ListItem Value="RI">Rhode Island</asp:ListItem>
	<asp:ListItem Value="SC">South Carolina</asp:ListItem>
	<asp:ListItem Value="SD">South Dakota</asp:ListItem>
	<asp:ListItem Value="TN">Tennessee</asp:ListItem>
	<asp:ListItem Value="TX">Texas</asp:ListItem>
	<asp:ListItem Value="UT">Utah</asp:ListItem>
	<asp:ListItem Value="VT">Vermont</asp:ListItem>
	<asp:ListItem Value="VA">Virginia</asp:ListItem>
	<asp:ListItem Value="WA">Washington</asp:ListItem>
	<asp:ListItem Value="WV">West Virginia</asp:ListItem>
	<asp:ListItem Value="WI">Wisconsin</asp:ListItem>
	<asp:ListItem Value="WY">Wyoming</asp:ListItem>
</asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqState" runat="server" 
                    ErrorMessage="State Required" ControlToValidate="DropDownListState" 
                    CssClass="style6" ForeColor="Red">* Please select your State</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                Zip Code:</td>
            <td class="style5">
                <asp:TextBox ID="tbZipCode" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                 <asp:RequiredFieldValidator ID="ReqZip" runat="server" 
                    ErrorMessage="Zip Code Required" ControlToValidate="tbZipCode" 
                     ForeColor="Red">* Please type in your zip code</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="tbZipCode" ErrorMessage="Zip Code must be 5 digits" 
                    ValidationExpression="\d{5}(-\d{4})?" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">Tenant ID:</td>
            <td class="style5"><asp:TextBox ID="txtTenantID" runat="server" Width="199px"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="ReqTID" runat="server" 
                    ErrorMessage="Tenant ID Required" ControlToValidate="txtTenantID" 
                     ForeColor="Red">* Please enter your tenant ID</asp:RequiredFieldValidator>
                <br />
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtTenantID" ErrorMessage="* Tenant ID must be a number" 
                    ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
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

