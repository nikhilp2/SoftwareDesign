<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMasterPage.master" %>
<script runat="server">

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
   //  CustomersClass cc = new CustomersClass();
        if ((CustomersClass.setUsr(0, tb1FirstName.Text, tb1LastName.Text, tb1Address.Text, tb1City.Text, DropDownListState1.SelectedValue, tb1ZipCode.Text, tb2Address.Text, tb2City.Text, DropDownListState2.SelectedValue, tb2ZipCode.Text, tb1UserName.Text, tb1Password.Text, 0, tb1Email.Text)))
        {
                   
            Response.Redirect("CustomerConfirmation.aspx");
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
                <asp:TextBox ID="tb1UserName" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="UnReq" runat="server" 
                    ErrorMessage="User Name Required" ControlToValidate="tb1UserName" 
                    CssClass="style6" ForeColor="Red">* Please enter your Username</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                Password:</td>
            <td class="style5">
                <asp:TextBox ID="tb1Password" runat="server" TextMode="Password" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqPass" runat="server" 
                    ErrorMessage="Password Required" ControlToValidate="tb1Password" 
                    CssClass="style7" ForeColor="Red">* Please enter your Password</asp:RequiredFieldValidator>
                <span class="style7">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                E-mail:</td>
            <td class="style5">
                <asp:TextBox ID="tb1Email" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqEmail" runat="server" 
                    ErrorMessage="E-mail Required" ControlToValidate="tb1Email" ForeColor="Red" 
                    style="color: #FF0000">* Please enter you E-mail</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="tb1Email" ErrorMessage="Wrong E-mail Format" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    style="color: #FF0000"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                First Name:</td>
            <td class="style5">
                <asp:TextBox ID="tb1FirstName" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqFirstName" runat="server" 
                    ErrorMessage="First Name Required" ControlToValidate="tb1FirstName" 
                    CssClass="style6" ForeColor="Red">* Please enter your First name</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                Last Name:</td>
            <td class="style5">
                <asp:TextBox ID="tb1LastName" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqAddress" runat="server" 
                    ErrorMessage="Last Name Required" ControlToValidate="tb1LastName" 
                    CssClass="style7" ForeColor="Red">* Please enter your Last name</asp:RequiredFieldValidator>
                <span class="style7">&nbsp;</span></td>
        </tr>
        <tr>
       <td></td><td>Billing Information</td> 
        </tr>
        <tr>
            <td class="style4">
                Address:</td>
            <td class="style5">
                <asp:TextBox ID="tb1Address" runat="server" Height="40px" TextMode="MultiLine" 
                    Width="260px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="Address Required" ControlToValidate="tb1Address" 
                    CssClass="style6" ForeColor="Red">* Please enter your Address</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                City:</td>
            <td class="style5">
                <asp:TextBox ID="tb1City" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="ReqCity" runat="server" 
                    ErrorMessage="City Required" ControlToValidate="tb1City" CssClass="style7" 
                    ForeColor="Red">* Please enter your City</asp:RequiredFieldValidator>
                <span class="style7">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                State:</td>
            <td class="style5">
                <asp:DropDownList ID="DropDownListState1" runat="server">
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
                    ErrorMessage="State Required" ControlToValidate="DropDownListState1" 
                    CssClass="style6" ForeColor="Red">* Please select your State</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                Zip Code:</td>
            <td class="style5">
                <asp:TextBox ID="tb1ZipCode" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                 <asp:RequiredFieldValidator ID="ReqZip" runat="server" 
                    ErrorMessage="Zip Code Required" ControlToValidate="tb1ZipCode" 
                     ForeColor="Red">* Please type your zip code</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="tb1ZipCode" ErrorMessage="Zip Code must be 5 digits" 
                    ValidationExpression="\d{5}(-\d{4})?" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
   
         <tr>
       <td></td><td>Shipping Information</td> 
        </tr>
        <tr>
            <td class="style4">
                Address:</td>
            <td class="style5">
                <asp:TextBox ID="tb2Address" runat="server" Height="40px" TextMode="MultiLine" 
                    Width="260px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                    ErrorMessage="Address Required" ControlToValidate="tb2Address" 
                    CssClass="style6" ForeColor="Red">* Please enter your Address</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                City:</td>
            <td class="style5">
                <asp:TextBox ID="tb2City" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="City Required" ControlToValidate="tb2City" CssClass="style7" 
                    ForeColor="Red">* Please enter your City</asp:RequiredFieldValidator>
                <span class="style7">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                State:</td>
            <td class="style5">
                <asp:DropDownList ID="DropDownListState2" runat="server">
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" 
                    ErrorMessage="State Required" ControlToValidate="DropDownListState2" 
                    CssClass="style6" ForeColor="Red">* Please select your State</asp:RequiredFieldValidator>
                <span class="style6">&nbsp;</span></td>
        </tr>
        <tr>
            <td class="style4">
                Zip Code:</td>
            <td class="style5">
                <asp:TextBox ID="tb2ZipCode" runat="server" Width="199px"></asp:TextBox>
            </td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" 
                    ErrorMessage="Zip Code Required" ControlToValidate="tb2ZipCode" 
                     ForeColor="Red">* Please type your zip code</asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" 
                    ControlToValidate="tb2ZipCode" ErrorMessage="Zip Code must be 5 digits" 
                    ValidationExpression="\d{5}(-\d{4})?" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                <asp:Button ID="UserButton" runat="server" Text="Submit" Width="99px" 
                    onclick="btnSubmit_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


