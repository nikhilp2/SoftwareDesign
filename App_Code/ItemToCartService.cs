using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for ItemToCartService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ItemToCartService : System.Web.Services.WebService {
    string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    public ItemToCartService () {
        //Uncomment the following line if using designed components 
        //InitializeComponent();
    }

    [System.Web.Services.WebMethod()]
    public string AddToCart(int itemID, int OrgID, int shopperID)
    {
        int ObjID = 0;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        string value = "Value";
        int cartIDCol = 0;
        int custIDCol = 0;
        int itemsCol = 0;
        int totalCol = 0;
        string returnString = "temp";
        string cartIDColVal = "";
        string custIDColVal = "";
        string itemsColVal = "";
        string totalColVal = "";
        string itemsInCart = "";

        //Step 1: get cart obj id for Org
        cmd.CommandText = "SELECT * FROM Objects WHERE OrgID='" + OrgID + "' AND ObjName='Cart'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            ObjID = (int)read["ObjID"];
            read.Close();
            cmd.CommandText = "select * from Fields where OrgID='" + OrgID + "' and ObjID='" + ObjID + "'";
            read = cmd.ExecuteReader();
            //read.Read();
            if (read.HasRows)
            {
                while (read.Read()) //Step 2: get customerID field number, get items field number
                {
                    switch ((string)read["FieldName"])
                    {
                        case "ID": //might not need
                            cartIDCol = (int)read["FieldNumber"];
                            if (cartIDCol < 10)
                            {
                                cartIDColVal = value + "0" + cartIDCol;
                            }
                            else cartIDColVal = value + cartIDCol;
                            break;
                        case "CustomerID":
                            custIDCol = (int)read["FieldNumber"];
                            if (custIDCol < 10)
                            {
                                custIDColVal = value + "0" + custIDCol;
                            }
                            else custIDColVal = value + custIDCol;
                            break;
                        case "Items":
                            itemsCol = (int)read["FieldNumber"];
                            if (itemsCol < 10)
                            {
                                itemsColVal = value + "0" + itemsCol;
                            }
                            else itemsColVal = value + itemsCol;
                            break;
                        case "Total":
                            totalCol = (int)read["FieldNumber"];
                            if (totalCol < 10)
                            {
                                totalColVal = value + "0" + totalCol;
                            }
                            else totalColVal = value + totalCol;
                            break;
                    }
                }
                read.Close(); //3. check to see if cart exists in Data 
                cmd.CommandText = "SELECT * FROM Data WHERE OrgID = '" + OrgID + "' AND ObjID = '" + ObjID + "' AND " + custIDColVal + " = '" + shopperID + "'";
                read = cmd.ExecuteReader();
                value = "Value";
                read.Read();
                if (read.HasRows) //cart already exists for customer, add to item list
                {
                    itemsInCart = (string)read[itemsColVal];
                    itemsInCart = itemsInCart + "," + itemID;
                    read.Close();
                    cmd.CommandText = "UPDATE [Data] SET [" + itemsColVal + "] = '" + itemsInCart + "' WHERE OrgID = '" + OrgID + "' AND ObjID = '" + ObjID + "' AND " + custIDColVal + " = '" + shopperID + "' AND Name = 'Cart'";
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        returnString = "" + ObjID + "," + totalColVal + "," + custIDColVal;
                        //returnString = "Added to cart";
                    }
                    else returnString = "Not added to cart";
                }
                else
                {
                    //need to generate an id somehow
                    read.Close();
                    cmd.CommandText = "INSERT INTO [Data] ([OrgID], [ObjID], [Name], [" + cartIDColVal + "], [" + custIDColVal + "], [" + itemsColVal + "], [" + totalColVal + "]) VALUES('" + OrgID + "', '" + ObjID + "', 'Cart', '0', '" + shopperID + "', '" + itemID + "', '" + 0 + "')";
                    cmd.ExecuteNonQuery();
                    returnString = "" + ObjID + "," + totalColVal + "," + custIDColVal;
                }
            }



        }

        //returnString = "cartIDcol: " + cartIDCol + ", customerIDCol: " + custIDCol + ", itemsIDCol: " + itemsIDCol;
        //4. if it exists, get items field, then update items field
        //5. if it doesn't exsit create new row with proper data
        
        return returnString;
    }
    
}
