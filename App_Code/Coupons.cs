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
/// Summary description for Coupons
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Coupons : System.Web.Services.WebService {

    public Coupons () {
        //Uncomment the following line if using designed components 
        //InitializeComponent();
    }
    /**
     * Returns the new price
     */
    [System.Web.Services.WebMethod()]
    public double ValidateCoupon(int CouponID, int OrgID, double total)
    {
        bool valid = false;
        int ObjID = 0;
        int couponIDCol;
        int discountCol;
        //int newTotal = total;
        int couponDiscount = 0;
        string couponIDColVal = "";
        string discountColVal = "";
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        string value = "Value";
        int valNum = 0;
        int cID = 0;

        cmd.CommandText = "SELECT * FROM Objects WHERE OrgID='" + OrgID + "' AND ObjName='Coupon'";

        read = cmd.ExecuteReader();

        read.Read();
        if (read.HasRows)
        {
            ObjID = (int)read["ObjID"];
            cmd.CommandText = "select * from Fields where OrgID='" + OrgID + "' and ObjID='" + ObjID + "'";
            read.Close();
            read = cmd.ExecuteReader();
            //read.Read();
            if (read.HasRows)
            {
                while (read.Read()) //find field number of coupon id and discount %
                {
                    string name = (string)read["FieldName"];
                    switch ((string)read["FieldName"])
                    {
                        case "ID":
                            couponIDCol = (int)read["FieldNumber"];
                            if (couponIDCol < 10)
                            {
                                couponIDColVal = value + "0" + couponIDCol;
                            }
                            else couponIDColVal = value + couponIDCol;
                            break;
                        case "Discount %":
                            discountCol = (int)read["FieldNumber"];
                            if (discountCol < 10)
                            {
                                discountColVal = value + "0" + discountCol;
                            }
                            else discountColVal = value + discountCol;
                            break;
                    }
                }
                cmd.CommandText = "select * from Data where OrgID='" + OrgID + "' and ObjID='" + ObjID + "'";
                read.Close();
                read = cmd.ExecuteReader();
                //read.Read();
                if (read.HasRows)
                {
                    while (read.Read() & !valid)
                    {
                        cID = System.Convert.ToInt32(read[couponIDColVal]);
                        if (cID == CouponID)
                        {
                            couponDiscount = System.Convert.ToInt32(read[discountColVal]);
                            valid = true;
                        }
                    }
                }
            }
        }
        double newTotal = total - ((couponDiscount / 100.0) * total);
        read.Close();
        conn.Close();
        read = null;
        conn = null;
        return newTotal;
    }
}
