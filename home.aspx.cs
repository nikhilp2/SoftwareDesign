using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class home : System.Web.UI.Page
{
    int OrgID = 1001;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            OrgID = System.Convert.ToInt32(Session["TenantID"]);
        }
        catch (Exception ex)
        {
            try
            {
                OrgID = System.Convert.ToInt32(Request.QueryString["OrgID"]);
            }
            catch (Exception ex2)
            {
            }
        }
        DataLayer dl = new DataLayer();
        string loginurl = dl.getNextService(OrgID,0,"User Login");
        string registerurl = dl.getNextService(OrgID, 0, "User Registration");
        login.HRef = loginurl;
        register.HRef = registerurl;
        
        if (Session["user"] != null)
            Response.Redirect("members.aspx");
        if (Session["user1"] != null)
            Response.Redirect("CustomerPage.aspx");
    }
}
