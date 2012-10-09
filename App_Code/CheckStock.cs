using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for CheckStock
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CheckStock : System.Web.Services.WebService {

    string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    public CheckStock () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    //From order ID get items
    [System.Web.Services.WebMethod()]
    public void getItems(string orderID, int OrgID, ref int[] items, ref int[] itemTypes, ref string[] inStock)
    {
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(e4Conn);
        string itemList = "";
        string itemTypeList = "";
        string[] parseString;
        string[] parseTypes;

        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Data WHERE Value00 = '" + orderID + "' AND Name = 'Order' AND OrgID = '" + OrgID + "'";

        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
            read.Read();
            try
            {
                itemList = System.Convert.ToString(read["Value05"]);
                itemTypeList = System.Convert.ToString(read["Value06"]);
                parseString = itemList.Split(',');
                parseTypes = itemTypeList.Split(',');
                for (int y = 0; y < parseString.Length; y++)
                {
                    items[y] = System.Convert.ToInt32(parseString[y]);
                    itemTypes[y] = System.Convert.ToInt32(parseTypes[y]);
                    read.Close();
                    cmd.CommandText = "SELECT * FROM Data WHERE OrgID = '" + OrgID + "' AND Value00 = '" + items[y] + "' AND ObjID = '" + itemTypes[y] + "'";
                    read = cmd.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        if (System.Convert.ToInt32(read["Value06"]) > 0)
                        {
                            inStock[y] = "Yes";
                        }
                        else
                        {
                            inStock[y] = "No";
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
