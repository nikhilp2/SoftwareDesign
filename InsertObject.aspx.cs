using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class InsertObject : System.Web.UI.Page
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
        string name = TextBox1.Text; // Scrub user data
        string two = TextBox2.Text;
        try
        {
            SqlConnection MyConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\fadiDatabase.mdf;Integrated Security=True;User Instance=True");
            MyConnection.Open();

            String MyString = @"INSERT INTO Objects VALUES('" + name + "', '" + two + "')";
            SqlCommand MyCmd = new SqlCommand(MyString, MyConnection);
            
            MyCmd.ExecuteNonQuery();
            MyConnection.Close();
            Response.Redirect("ViewObjects.aspx");
        }
        catch (Exception ex)
        {
            //Log error message
        }
            
    }
}
