using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerPage : System.Web.UI.Page
{
    int OrgID = 0;

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
        string url = "";
        string name = "";
        int next = 0;
        url = dl.getNextService(OrgID, next, "Display Items");
        while (url.CompareTo("") != 0 && url.CompareTo("home.aspx") != 0)
        {
            name = DataLayer.getServiceName(url);
            itemsToDisplay.Controls.Add(new LiteralControl("<a href=" + url + ">" + name + "</a> | "));
            next = next + 1;
            url = dl.getNextService(OrgID, next, "Display Items");
        }
    }
}