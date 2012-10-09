using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectShippingSpeed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user1"] == null)
            Response.Redirect("CustomerLogin.aspx");
    }
    protected void bnNext_Click(object sender, EventArgs e)
    {
        ShippingSpeedService wsShippingSpeed = new ShippingSpeedService();
        DataLayer dLayer = new DataLayer();
        int OrgID;
        int serviceOrder;
        int shopperID;
        string url;
        string workflow = Session["workflow"].ToString();
        try
        {
            OrgID = System.Convert.ToInt32(Session["OrgID"]);
        }
        catch (Exception ex)
        {
            OrgID = 0;
        }
        try
        {
            shopperID = System.Convert.ToInt32(Session["shopperID"]);
        }
        catch (Exception ex)
        {
            shopperID = 0;
        }
        try
        {
            serviceOrder = System.Convert.ToInt32(Session["serviceOrder"]);
        }
        catch (Exception ex)
        {
            serviceOrder = 0;
        }
        double newCost = wsShippingSpeed.CalcShippingCost(0, OrgID, ddlShippingSpeed.Text, 180.0);
        lblCurTotal.Text = newCost + "";
        serviceOrder = serviceOrder + 1;
        Session["serviceOrder"] = serviceOrder;
        url = dLayer.getNextService(OrgID, serviceOrder, workflow);
        if (url == "")
        {
            url = "SelectShippingSpeed.aspx";
        }
        Response.Redirect(url);
    }

}