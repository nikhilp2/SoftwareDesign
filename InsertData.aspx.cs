using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    Data.usrInfo dat;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("login.aspx");
        else
        {

            dat = Data.GetUsrInfo(Session["user"].ToString());
            UserLabel.Text = dat.firstname;
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
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        string OrgID = OrgIDBox.Text; // Scrub user data
        string ObjID = ObjIDBox.Text;
        string ObjectName = ObjNameBox.Text;
        string Value00 = Value00Box.Text;
        string Value01 = Value01Box.Text;
        string Value02 = Value02Box.Text;
        string Value03 = Value03Box.Text;
        string Value04 = Value04Box.Text;
        string Value05 = Value05Box.Text;
        string Value06 = Value06Box.Text;
        string Value07 = Value07Box.Text;
        string Value08 = Value08Box.Text;
        string Value09 = Value09Box.Text;
        string Value10 = Value10Box.Text;

        try
        {
            SqlConnection MyConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\fadiDatabase.mdf;Integrated Security=True;User Instance=True");
            MyConnection.Open();

            String MyString = @"INSERT INTO [Data] VALUES('" + OrgID + "', '" + ObjID + "', '" + ObjectName + "', '" + Value00 + "', '" + Value01 + "', '" + Value02 + "', '" + Value03 + "', '" + Value04 + "', '" + Value05 + "', '" + Value06 + "', '" + Value07 + "', '" + Value08 + "', '" + Value09 + "', '" + Value10 + "')";
            SqlCommand MyCmd = new SqlCommand(MyString, MyConnection);

            MyCmd.ExecuteNonQuery();
            MyConnection.Close();
            Response.Redirect("ViewData.aspx");
        }
        catch (Exception ex)
        {
            //Log error message
        }
    }
}