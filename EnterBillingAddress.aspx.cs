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
        if (Session["user1"] == null)
            Response.Redirect("CustomerLogin.aspx");
    }
    protected void VerifyAdressButton_Click(object sender, EventArgs e)
    {
        string Street = txtStreet.Text;
        string City = txtCity.Text;
        string State = ddlState.Text;
        string Zip = txtZip.Text;
        string workflow = Session["workflow"].ToString();
        string url;
        int shopperID;
        int OrgID;
        int serviceOrder;
        double total;
        GetBillingInfo wsBillingInfo = new GetBillingInfo();
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
        try
        {
            total = System.Convert.ToDouble(Session["total"]);
        }
        catch (Exception ex)
        {
            total = 0;
        }
        if (wsBillingInfo.VerifyBillingInfo(Street, City, State, Zip))
        {
            txtVerified.Text = wsBillingInfo.StoreBillingInfo(shopperID, Street, City, State, Zip, OrgID);
            //txtVerified.Text = "Verified";
            serviceOrder = serviceOrder + 1;
            Session["serviceOrder"] = serviceOrder;
            url = dLayer.getNextService(OrgID, serviceOrder, workflow);
            if (url == "")
            {
                url = "EnterBillingAddress.aspx";
            }
            Response.Redirect(url);
        }
        else
        {
            txtVerified.Text = "Not Verified";
        }
    }
}