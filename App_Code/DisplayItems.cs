using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DisplayItems
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DisplayItems : System.Web.Services.WebService {

    public DisplayItems () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    public static void getItem(int OrgID, ref string[] fields, ref int[] fieldNums, ref string[,] items, string ObjName)
    {
        int ObjID = 0;
        int counter = 0;

        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Objects WHERE OrgID = '" + OrgID + "' AND ObjName = '" + ObjName + "'";
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
            read.Read();
            try
            {
                ObjID = System.Convert.ToInt32(read["ObjID"]);
                read.Close();
                cmd.CommandText = "Select * FROM Fields WHERE ObjID = '" + ObjID + "'";
                read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        fields[counter] = System.Convert.ToString(read["FieldName"]);
                        fieldNums[counter] = System.Convert.ToInt32(read["FieldNumber"]);
                        counter++;
                    }
                    read.Close();
                    cmd.CommandText = "SELECT * FROM Data WHERE ObjID = '" + ObjID + "'";
                    read = cmd.ExecuteReader();
                    if (read.HasRows)
                    {
                        counter = 0;
                        while (read.Read())
                        {
                            items[counter, 0] = System.Convert.ToString(read["Value00"]);
                            items[counter, 1] = System.Convert.ToString(read["Value01"]);
                            items[counter, 2] = System.Convert.ToString(read["Value02"]);
                            items[counter, 3] = System.Convert.ToString(read["Value03"]);
                            items[counter, 4] = System.Convert.ToString(read["Value04"]);
                            items[counter, 5] = System.Convert.ToString(read["Value05"]);
                            items[counter, 6] = System.Convert.ToString(read["Value06"]);
                            items[counter, 7] = System.Convert.ToString(read["Value07"]);
                            items[counter, 8] = System.Convert.ToString(read["Value08"]);
                            items[counter, 9] = System.Convert.ToString(read["Value09"]);
                            items[counter, 10] = System.Convert.ToString(read["Value10"]);
                            counter++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    
}
