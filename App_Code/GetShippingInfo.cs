using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for GetShippingInfo
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GetShippingInfo : System.Web.Services.WebService {

    public GetShippingInfo () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod()]
    public string StoreShippingInfo(int shopperID, string Street, string City, string State, string Zip, int OrgID)
    {
        //find billing info ID
        int billingInfoID;
        string shippingIDColVal = "";
        string custIDColVal = "";
        string streetColVal = "";
        string cityColVal = "";
        string stateColVal = "";
        string zipColVal = "";
        int billingIDCol;
        int custIDCol;
        int streetCol;
        int cityCol;
        int stateCol;
        int zipCol;
        int ObjID;
        string value = "Value";
        string returnString = "Fail";
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;



        //Step 1: get cart obj id for Org
        cmd.CommandText = "SELECT * FROM Objects WHERE OrgID='" + OrgID + "' AND ObjName='ShippingAddress'";
        read = cmd.ExecuteReader();
        read.Read();

        if (read.HasRows)
        {
            ObjID = (int)read["ObjID"];
            read.Close();
            cmd.CommandText = "select * from Fields where OrgID='" + OrgID + "' and ObjID='" + ObjID + "'";
            read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    string fieldName = System.Convert.ToString(read["FieldName"]);
                    switch ((string)read["FieldName"])
                    {
                        case "ID": //might not need
                            billingIDCol = (int)read["FieldNumber"];
                            if (billingIDCol < 10)
                            {
                                shippingIDColVal = value + "0" + billingIDCol;
                            }
                            else shippingIDColVal = value + billingIDCol;
                            break;
                        case "CustomerID":
                            custIDCol = (int)read["FieldNumber"];
                            if (custIDCol < 10)
                            {
                                custIDColVal = value + "0" + custIDCol;
                            }
                            else custIDColVal = value + custIDCol;
                            break;
                        case "Street":
                            streetCol = (int)read["FieldNumber"];
                            if (streetCol < 10)
                            {
                                streetColVal = value + "0" + streetCol;
                            }
                            else streetColVal = value + streetCol;
                            break;
                        case "City":
                            cityCol = (int)read["FieldNumber"];
                            if (cityCol < 10)
                            {
                                cityColVal = value + "0" + cityCol;
                            }
                            else cityColVal = value + cityCol;
                            break;
                        case "State":
                            stateCol = (int)read["FieldNumber"];
                            if (stateCol < 10)
                            {
                                stateColVal = value + "0" + stateCol;
                            }
                            else stateColVal = value + stateCol;
                            break;
                        case "Zip":
                            zipCol = (int)read["FieldNumber"];
                            if (zipCol < 10)
                            {
                                zipColVal = value + "0" + zipCol;
                            }
                            else zipColVal = value + zipCol;
                            break;
                    }
                }
                read.Close();
                //need to generate an id somehow
                cmd.CommandText = "INSERT INTO [Data] ([OrgID], [ObjID], [Name], [" + shippingIDColVal + "], [" + custIDColVal + "], [" + streetColVal + "], [" + cityColVal + "], [" + stateColVal + "], [" + zipColVal + "]) VALUES('" + OrgID + "', '" + ObjID + "', 'ShippingAddress', '0', '" + shopperID + "', '" + Street + "', '" + City + "', '" + State + "', '" + Zip + "')";
                cmd.ExecuteNonQuery();
                returnString = "Inserted";
            }
        }
        return returnString;
    }

    [System.Web.Services.WebMethod()]
    public bool VerifyShippingInfo(string Street, string City, string State, string Zip)
    {
        bool verified = false;

        if (Regex.IsMatch(Street, @"[0-9]+\s[a-zA-Z]*"))
        {
            if (Zip.Length == 5)
            {
                verified = true;
            }
        }

        return verified;
    }
}
