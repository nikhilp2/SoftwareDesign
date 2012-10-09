using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddWebService : System.Web.UI.Page
{
    Data.usrInfo dat;
    int OrgID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("login.aspx");
        if (System.Convert.ToInt32(Session["admin"]) != 1)
        {
            Response.Redirect("CustomerLogin.aspx");
        }
        else
        {
            try
            {
                OrgID = System.Convert.ToInt32(Session["TenantID"]);
            }
            catch (Exception ex)
            {
                OrgID = 0;
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text; // Scrub user data
        string URL = txtURL.Text;
        DataLayer.insertNewWebService(OrgID, URL, name);
        Response.Redirect("home.aspx");
    }
}