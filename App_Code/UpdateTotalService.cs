using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;

/// <summary>
/// Summary description for UpdateTotalService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class UpdateTotalService : System.Web.Services.WebService {

    string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    public UpdateTotalService () {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod()]
    public string UpdateTotal(int OrgID, int ObjID, int cartObjID, int shopperID, int cartID, int itemID, string totalColVal, string custIDColVal)
    {
        //OrgID, shopperID, cartID, itemid, tota
        int total = 0;
        int priceCol = 0;
        int price = 0;
        int curTotal = 0;
        string value = "Value";
        string priceColVal = "";
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(e4Conn);
        string returnString = "";

        conn.Open();
        cmd.Connection = conn;

        //Step1: find which column contains price
        cmd.CommandText = "SELECT * FROM Fields WHERE FieldName = 'Price' AND OrgID = '" + OrgID + "' AND ObjID = '" + ObjID + "'"; 
        //cmd.CommandText = "SELECT * FROM Objects WHERE OrgID='" + OrgID + "' AND ObjName='Cart'";
        read = cmd.ExecuteReader();

        read.Read();
        if (read.HasRows)
        {
            priceCol = (int)read["FieldNumber"];
            if (priceCol < 10)
            {
                priceColVal = value + "0" + priceCol;
            }
            else priceColVal = value + priceCol;
            //Step 2: find price
            cmd.CommandText = "select * from Data where OrgID='" + OrgID + "' and ObjID='" + ObjID + "' AND Value00 = '" + itemID + "'";
            read.Close();
            read = cmd.ExecuteReader();
            read.Read();
            if (read.HasRows)
            {
                price = System.Convert.ToInt32(read[priceColVal]);

                //Step 3: add price to current price
                //Get current cart price
                cmd.CommandText = "select * from Data where OrgID='" + OrgID + "' and ObjID='" + cartObjID + "' AND Name = 'Cart' AND " + custIDColVal + " = '" + shopperID + "'";
                read.Close();
                read = cmd.ExecuteReader();
                read.Read();
                if (read.HasRows)
                {
                    curTotal = System.Convert.ToInt32(read[totalColVal]);
                    total = curTotal + price;
                    cmd.CommandText = "UPDATE [Data] SET [" + totalColVal + "] = '" + total + "' WHERE OrgID = '" + OrgID + "' AND ObjID = '" + cartObjID + "' AND " + custIDColVal + " = '" + shopperID + "' AND Name ='Cart'";
                    read.Close();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        returnString = "Added to cart";
                    }
                    else returnString = "Not added to cart";
                }
            }
        }
        
        return returnString;
    }
}
