using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ProcessOrder
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ProcessOrder : System.Web.Services.WebService {

    string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    public ProcessOrder () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    //this method checks to see that order id exists
    [System.Web.Services.WebMethod()]
    public bool chkS(string sID, int OrgID)
    {
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText =  "SELECT * FROM Data WHERE Value00 = '" + sID + "' AND Name = 'Order' AND OrgID = '" + OrgID + "'";

        read = cmd.ExecuteReader();

        bool x = read.HasRows;

        read.Close();
        conn.Close();
        cmd = null;

        return x;
    }
    
}
