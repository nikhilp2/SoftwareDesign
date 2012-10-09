using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PlaceOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PlaceOrderService wsPlaceOrder = new PlaceOrderService();
        DataLayer dLayer = new DataLayer();
        int OrgID;
        int serviceOrder;
        int shopperID;
        int cartID;
        string url;
        string workflow;
        if (Session["user1"] == null)
            Response.Redirect("CustomerLogin.aspx");
        try
        {
            workflow = Session["workflow"].ToString();
        }
        catch (Exception ex)
        {
            workflow = "";
        }
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
        try
        {
            cartID = System.Convert.ToInt32(Session["cartID"]);
        }
        catch (Exception ex)
        {
            cartID = 0;
        }
        Session["orderID"] = wsPlaceOrder.PlaceOrder(OrgID, shopperID, cartID);
        serviceOrder = serviceOrder + 1;
        Session["serviceOrder"] = serviceOrder;
        url = dLayer.getNextService(OrgID, serviceOrder, workflow);
        if (url == "")
        {
            url = "PlaceOrder.aspx";
        }
        Response.Redirect(url);
    }
    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        PlaceOrderService wsPlaceOrder = new PlaceOrderService();
        DataLayer dLayer = new DataLayer();
        int OrgID;
        int serviceOrder;
        int shopperID;
        int cartID;
        string url;
        string workflow;
        try
        {
            workflow = Session["workflow"].ToString();
        }
        catch(Exception ex)
        {
            workflow = "";
        }
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
        try
        {
            cartID = System.Convert.ToInt32(Session["cartID"]);
        }
        catch (Exception ex)
        {
            cartID = 0;
        }
        Session["orderID"] = wsPlaceOrder.PlaceOrder(OrgID, shopperID, cartID);
        serviceOrder = serviceOrder + 1;
        Session["serviceOrder"] = serviceOrder;
        url = dLayer.getNextService(OrgID, serviceOrder, workflow);
        if (url == "")
        {
            url = "PlaceOrder.aspx";
        }
        Response.Redirect(url);
    }
}