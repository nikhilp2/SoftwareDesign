using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ApplyCoupon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user1"] == null)
            Response.Redirect("CustomerLogin.aspx");
    }
    protected void ApplyButton_Click(object sender, EventArgs e)
    {
        Coupons coupon = new Coupons();
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
        double total = 0; //TODO: change to get from order
        try
        {
            total = System.Convert.ToDouble(Session["total"]);
            int couponID = System.Convert.ToInt32(txtCID.Text);
            TempLabel.Text = System.Convert.ToString(coupon.ValidateCoupon(couponID, OrgID, total));
        }
        catch (FormatException ex)
        {
            TempLabel.Text = "Can not convert string";
        }
        catch (OverflowException ex)
        {
            TempLabel.Text = "Number too large";
        }
        catch (Exception ex)
        {
        }
        serviceOrder = serviceOrder + 1;
        Session["serviceOrder"] = serviceOrder;
        url = dLayer.getNextService(OrgID, serviceOrder, workflow);
        if (url == "")
        {
            url = "ApplyCoupon.aspx";
        }
        Response.Redirect(url);
    }
}