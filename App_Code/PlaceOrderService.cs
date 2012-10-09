using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for PlaceOrderService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PlaceOrderService : System.Web.Services.WebService {
    string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    public PlaceOrderService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod()]
    public int PlaceOrder(int OrgID, int shopperID, int cartID)
    {
        int ObjID = 0;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        int orderIDCol = 0;
        int custIDCol = 0;
        int itemsCol = 0;
        int totalCol = 0;
        int cartIDCol = 0;
        int cartObjID = 0;
        int custCartIDCol = 0;
        int itemsCartCol = 0;
        int totalCartCol = 0;
        int orderID = 0;
        double total = 0.0;
        string value = "Value";
        //string returnString = "temp";
        string orderIDColVal = "";
        string custIDColVal = "";
        string itemsColVal = "";
        string totalColVal = "";
        string cartIDColVal = "";
        string custCartIDColVal = "";
        string itemsCartColVal = "";
        string totalCartColVal = "";
        string items = "";
        
        //get ObjID
        //Step 1: get cart obj id for Org
        cmd.CommandText = "SELECT * FROM Objects WHERE OrgID='" + OrgID + "' AND ObjName='Order'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            ObjID = (int)read["ObjID"];
            read.Close();
            cmd.CommandText = "select * from Fields where OrgID='" + OrgID + "' and ObjID='" + ObjID + "'";
            read = cmd.ExecuteReader();
            //get col values
            if (read.HasRows)
            {
                while (read.Read()) //Step 2: get customerID field number, get items field number
                {
                    switch ((string)read["FieldName"])
                    {
                        case "ID": //might not need
                            orderIDCol = (int)read["FieldNumber"];
                            if (orderIDCol < 10)
                            {
                                orderIDColVal = value + "0" + orderIDCol;
                            }
                            else orderIDColVal = value + orderIDCol;
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
                //get cart info
                read.Close();
                cmd.CommandText = "SELECT * FROM Objects WHERE OrgID='" + OrgID + "' AND ObjName='Cart'";
                read = cmd.ExecuteReader();
                read.Read();
                if (read.HasRows)
                {
                    cartObjID = (int)read["ObjID"];
                    read.Close();
                    cmd.CommandText = "select * from Fields where OrgID='" + OrgID + "' and ObjID='" + cartObjID + "'";
                    read = cmd.ExecuteReader();
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
                                    custCartIDCol = (int)read["FieldNumber"];
                                    if (custCartIDCol < 10)
                                    {
                                        custCartIDColVal = value + "0" + custCartIDCol;
                                    }
                                    else custCartIDColVal = value + custCartIDCol;
                                    break;
                                case "Items":
                                    itemsCartCol = (int)read["FieldNumber"];
                                    if (itemsCartCol < 10)
                                    {
                                        itemsCartColVal = value + "0" + itemsCartCol;
                                    }
                                    else itemsCartColVal = value + itemsCartCol;
                                    break;
                                case "Total":
                                    totalCartCol = (int)read["FieldNumber"];
                                    if (totalCartCol < 10)
                                    {
                                        totalCartColVal = value + "0" + totalCartCol;
                                    }
                                    else totalCartColVal = value + totalCartCol;
                                    break;
                            }
                        }
                    }
                }
                //get items in cart
                read.Close(); //3. check to see if customerID exists in Data 
                cmd.CommandText = "SELECT * FROM Data WHERE OrgID = '" + OrgID + "' AND ObjID = '" + cartObjID + "' AND " + custIDColVal + " = '" + shopperID + "'";
                read = cmd.ExecuteReader();
                value = "Value";
                read.Read();
                if (read.HasRows) //cart already exists for customer, add to item list
                {
                    items = (string)read[itemsCartColVal];
                    total = System.Convert.ToDouble(read[totalCartColVal]);
                    //get total from cart
                    read.Close();
                    cmd.CommandText = "INSERT INTO [Data] ([OrgID], [ObjID], [Name], [" + orderIDColVal + "], [" + custIDColVal + "], [" + itemsColVal + "], [" + totalColVal + "]) VALUES('" + OrgID + "', '" + ObjID + "', 'Order', '0', '" + shopperID + "', '" + items + "', '" + total + "')";
                    cmd.ExecuteNonQuery();
                    orderID = 0;
                }
            }
        }
        return orderID;
    }
    
}
