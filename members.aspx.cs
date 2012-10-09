using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    Data.usrInfo dat;
    string first = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("login.aspx");
        else
        {

            dat = Data.GetUsrInfo(Session["user"].ToString());
            UserLabel.Text = dat.firstname;
    //        tbAddress.Text = dat.address;
    //        tbCity.Text = dat.city;
    //        DropDownListState.Text = dat.state;
   //         tbEmail.Text = dat.email;
   //         tbZip.Text = dat.zip;
   //         tbFirstName.Text = dat.firstname;
   //         tbLastName.Text = dat.lastname;
   //         tbPassword.Text = dat.password;

        }
        if (System.Convert.ToInt32(Session["admin"]) != 1)
        {
            Response.Redirect("CustomerLogin.aspx");
        }
    }
    protected void SignOUtLNK_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Response.Redirect("login.aspx");
    }
}
