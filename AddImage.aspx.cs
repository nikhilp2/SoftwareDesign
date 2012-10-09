using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("CustomerLogin.aspx");
        if (System.Convert.ToInt32(Session["admin"]) != 1)
        {
            Response.Redirect("CustomerLogin.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GUIDataLayer.insertImage(txtName.Text, txtURL.Text);
    }
}