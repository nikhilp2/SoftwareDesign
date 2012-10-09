using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
            Response.Redirect("members.aspx");

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        bool check = Data.chkCred(tbUserName.Text, tbPassword.Text);
        if (check == true)
        {
            string session;
            session = tbUserName.Text + DateTime.Now.ToLongTimeString();
            Session["user"] = session;
            Session["shopper"] = 0;
            Session["admin"] = 1;
            Session["TenantID"] = Data.setS(tbUserName.Text, session);
            Response.Redirect("members.aspx");
        }
        else
        { Label1.Text = "Invalide User Name or Password"; }
    }
}
