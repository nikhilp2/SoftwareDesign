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
        string FieldName = FieldNameBox.Text;
        string Datatype = DataTypeBox.Text;
        string FieldNumber = FieldNumBox.Text;
        int MasterKey = 0;
        bool MasterBool = MasterKeyBox.Checked;
        string ForeignKey = ForeignKeyBox.Text;

        if (MasterBool)
        {
            MasterKey = 1;
        }

        try
        {
            SqlConnection MyConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\fadiDatabase.mdf;Integrated Security=True;User Instance=True");
            MyConnection.Open();

            String MyString = @"INSERT INTO [Fields] ([OrgID], [ObjID], [FieldName], [Datatype], [FieldNumber], [MasterKey], [ForeignKeyFieldID]) VALUES('" + OrgID + "', '" + ObjID + "', '" + FieldName + "', '" + Datatype + "', '" + FieldNumber + "', '" + MasterKey + "', '" + ForeignKey + "')";
            SqlCommand MyCmd = new SqlCommand(MyString, MyConnection);

            MyCmd.ExecuteNonQuery();
            MyConnection.Close();
            Response.Redirect("ViewFields.aspx");
        }
        catch (Exception ex)
        {
            //Log error message
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
}