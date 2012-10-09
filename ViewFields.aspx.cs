using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Data.usrInfo dat;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("login.aspx");
        else
        {

            dat = Data.GetUsrInfo(Session["user"].ToString());
            UserLabel.Text = dat.firstname;
        }
        if (System.Convert.ToInt32(Session["admin"]) != 1)
        {
            Response.Redirect("CustomerLogin.aspx");
        }
    }
    protected void SignOUtLNK_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Response.Redirect("login.aspx");
    }
}