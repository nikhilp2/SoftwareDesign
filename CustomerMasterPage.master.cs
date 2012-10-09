using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


public partial class CustomerMasterPage : System.Web.UI.MasterPage
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
        Header.InnerText = GUIDataLayer.getHeader(OrgID);
        footer.InnerText = GUIDataLayer.getFooter(OrgID);
        container.Style.Remove("background-image");
        container.Style.Add("background-image", "url('" + GUIDataLayer.getImage(OrgID) + "')");
        string[] linkIDs = GUIDataLayer.getLinks(OrgID);
        string[] linkNames = GUIDataLayer.getLinkNames(linkIDs);
        string[] linkURLs = GUIDataLayer.getLinkURLs(linkIDs);
        for(int x = 0; x < linkURLs.Length; x++)
        {
            links.Controls.Add(new LiteralControl("<li><a href=" + linkURLs[x] + " class=\"style1\">" + linkNames[x] + "</a></li>"));
        }
    }

    protected void SignOUtLNK_Click(object sender, EventArgs e)
    {
        Session["user1"] = null;
        Session["shopper"] = 0;
        Session["TenantID"] = 0;
        Response.Redirect("CustomerLogin.aspx");
    }
}
