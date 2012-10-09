using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataLayer dl = new DataLayer();
    ProcessOrder wsProcessOrder = new ProcessOrder();
    private int OrgID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (System.Convert.ToInt32(Session["admin"]) != 1)
        {
            Response.Redirect("CustomerPage.aspx");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool check = wsProcessOrder.chkS(txtOrderID.Text, OrgID);
        if (check == true)
        {
            Session["OrgID"] = OrgID;
            Session["OrderID"] = txtOrderID.Text;
            string url = dl.getNextService(OrgID, 1, "Order Processing");
            Response.Redirect(url);
        }
        else
        { TempLabel.Text = "Invalid"; }
    }
}
