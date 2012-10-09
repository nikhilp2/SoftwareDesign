using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Test
/// </summary>
public class Test
{
	public static SqlDataReader SQLOpen(string query)
    {
        ///SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"].ToString()); 
     ///   SqlConnection connn = new SqlConnection(ConfigurationSettings.AppSettings["data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\fadiDatabase.mdf;User Instance=true"]);


        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection conn = new SqlConnection(e4Conn);

       /// SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["conn"].ToString());
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        System.Data.SqlClient.SqlDataReader read = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
         
        return read;
       
    }
    public static bool chkS(string sID)
    {
        
        SqlDataReader read = SQLOpen("SELECT FieldNumber FROM Fields WHERE FieldNumber='" + sID + "'");

        bool x = read.HasRows;

        read.Close();

        return x;
    }

    /*public static string setS(string oderid)
    {
        SqlDataReader read = SQLOpen("UPDATE Fields SET FieldNumber='" + oderid + "';");
        read.Close();
        read = SQLOpen("SELECT FieldName FROM Fields WHERE FieldNumber ='" + oderid + "';");
        read.Read();
        return read["session"].ToString();
    }*/
    public struct Info
    {
        public string FieldId;
        public string OrgId;
        public string ObjId;
        public string Fieldname;
        public string Datatype;
        public string FieldNumber;
        public string MasterKey;
        public string ForignKeyFieldID;
        
    }

    public static Info GetInfo(string sID)
    {
        Info info = new Info();
        SqlDataReader read = SQLOpen("SELECT * FROM fields ");
        read.Read();
        info.FieldId = read["FieldId"].ToString();
        info.OrgId = read["OrgID"].ToString();
        info.ObjId = read["ObjId"].ToString();
        info.Fieldname = read["Fieldname"].ToString();
        info.Datatype = read["Datatype"].ToString();
        info.FieldNumber = read["FieldNumber"].ToString();
        info.MasterKey = read["MasterKey"].ToString();
        info.ForignKeyFieldID = read["ForeignKeyFieldID"].ToString();
        return info;
    }
	}
