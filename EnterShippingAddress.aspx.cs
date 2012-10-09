using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EnterShippingAddress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblSessionInfo.Text = Session["OrgID"].ToString();
        if (Session["user1"] == null)
            Response.Redirect("CustomerLogin.aspx");
    }

    protected void VerifyAddressButton_Click(object sender, EventArgs e)
    {
        string Street = txtStreet.Text;
        string City = txtCity.Text;
        string State = ddlState.Text;
        string Zip = txtZip.Text;
        string url;
        string workflow = Session["workflow"].ToString();
        int shopperID;
        int OrgID;
        int serviceOrder;
        DataLayer dLayer = new DataLayer();
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

        GetShippingInfo wsShippingInfo = new GetShippingInfo();
        if (wsShippingInfo.VerifyShippingInfo(Street, City, State, Zip))
        {
            lblVerified.Text = wsShippingInfo.StoreShippingInfo(shopperID, Street, City, State, Zip, OrgID);
            serviceOrder = serviceOrder + 1;
            Session["serviceOrder"] = serviceOrder;
            url = dLayer.getNextService(OrgID, serviceOrder, workflow);
            if (url == "")
            {
                url = "EnterShippingAddress.aspx";
            }
            Response.Redirect(url);
        }
        else
        {
            lblVerified.Text = "Not Verified";
        }
        
    }
}