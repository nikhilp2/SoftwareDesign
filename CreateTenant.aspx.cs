using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateTenant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (TenantDataLayer.createTenant(txtTenatName.Text))
        {
            Response.Redirect("TenantConfirmation.aspx");
        }
        else
            lblError.Text = "Tenat Already Exists. Please choose another tenant name!";
    }
}