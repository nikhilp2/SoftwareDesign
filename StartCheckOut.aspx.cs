using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StartCheckOut : System.Web.UI.Page
{
    int OrgID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user1"] == null)
            Response.Redirect("CustomerLogin.aspx");
        try
        {
            OrgID = System.Convert.ToInt32(Session["TenantID"]);
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        DataLayer dLayer = new DataLayer();
        string workflow = "Check out";
        string url = dLayer.getNextService(OrgID, 0, workflow);
        if (url == "")
        {
            url = "StartCheckOut.aspx";
        }
        Session["OrgID"] = OrgID;
        Session["shopperID"] = 0;
        Session["serviceOrder"] = 0;
        Session["worfkflow"] = workflow;
        Response.Redirect(url);
    }
}