using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerLogin : System.Web.UI.Page
{
    int OrgID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user1"] != null)
            Response.Redirect("CustomerPage.aspx");
        DataLayer dl = new DataLayer();
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
        string customURL = dl.getNextService(OrgID, 0, "User Login");

    }
    protected void btn2Login_Click(object sender, EventArgs e)
    {
      //  CustomersClass customerLogin = new Customer();

        bool check = CustomersClass.chkCred2(tb1UserName.Text, tb1Password.Text);
        if (check == true)
        {
            string session1;
            session1 = tb1UserName.Text + DateTime.Now.ToLongTimeString();
            Session["user1"] = session1;
            Session["shopper"] = 1;
            Session["TenantID"] = CustomersClass.setS(tb1UserName.Text, session1);
            Response.Redirect("CustomerPage.aspx");
        }
        else
        { Label1.Text = "Invalide User Name or Password"; }
    }
}