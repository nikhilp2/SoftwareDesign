using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomizeGUI : System.Web.UI.Page
{
    string[] GUI;
    private int OrgID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("login.aspx");
        if (System.Convert.ToInt32(Session["admin"]) != 1)
        {
            Response.Redirect("CustomerLogin.aspx");
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
        if (!IsPostBack)
        {
            GUI = GUIDataLayer.getGUI(OrgID);
            txtHeader.Text = GUI[0];
            try
            {
                ddlBackground.SelectedIndex = System.Convert.ToInt32(GUI[1])-1;
            }
            catch
            {
            }
            txtFooter.Text = GUI[2];
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GUIDataLayer.insertGUI(OrgID, txtHeader.Text, ddlBackground.SelectedValue, txtFooter.Text);
    }
}