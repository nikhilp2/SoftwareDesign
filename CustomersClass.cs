using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;
/// <summary>

/// <summary>
/// Summary description for CustomersClass
/// </summary>
public class CustomersClass
{

     public static SqlDataReader SQLOpen(string query)
    {

        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection conn = new SqlConnection(e4Conn);

        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
        System.Data.SqlClient.SqlDataReader read = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
         
        return read;
       
    }

   
    public static bool chkS(string sID)
    {
        SqlDataReader read = SQLOpen("SELECT * FROM usersTable WHERE session1='" + sID + "';");
        if (read.HasRows == true)
        {
            read.Close();
            return true;
        }
        read.Close();
        return false;
    }

    public static string setS(string usr, string sID)
    {
        SqlDataReader read = SQLOpen("UPDATE usersTable SET session1='" + sID + "' WHERE username1='" + usr + "';");
        read.Close();
        read = SQLOpen("SELECT session1 FROM usersTable WHERE username1='" + usr + "';");
        read.Read();
        return read["session1"].ToString();
    }

    public static bool setUsr(int part, string fname, string lname, string add, string city, string state, string zip, string add2, string city2, string state2, string zip2, string usr, string passwd, int type, string email)
    {
        string query = "";

        if (part == 0)
        {
            SqlDataReader read2 = SQLOpen("SELECT * FROM usersTable WHERE username1='" + usr + "'");
            if (read2.HasRows == true)
            {
                read2.Close();
                return false;
            }
            query = "insert into usersTable (username1, password1, firstname1, lastname1, address1, city1, state1, zip1, email1, address2, city2, state2, zip2) values ('" + usr + "', '" + passwd + "', '" + fname + "', '" + lname + "', '" + add + "', '" + city + "', '" + state + "', '" + zip + "', '" + email + "', '" + add2 + "', '" + city2 + "', '" + state2 + "', '" + zip2 + "')";
            SqlDataReader read = SQLOpen(query);
            read.Close();

            string e5Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection conn = new SqlConnection(e5Conn);
            SqlCommand cmd = new SqlCommand("select userID from usersTable where username1='" + usr + "'", conn);
            conn.Open();

            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        else if (part == 1)
        {
            query = "UPDATE usersTable SET password1='" + passwd + "', firstname1='" + fname + "', lastname1='" + lname + "', address1='" + add + "', city1='" + city + "', state1='" + state + "', zip1='" + zip + "',  address2='" + add2 + "', city2='" + city2 + "', state2='" + state2 + "', zip2='" + zip2 + "', type1='" + type.ToString() + "' WHERE username1='" + usr + "';";
            SqlDataReader read = SQLOpen(query);
            read.Close();

        }

        return true;
    }

    public static bool chkCred2(string usr, string passwd)
    {
        SqlDataReader read = SQLOpen("SELECT username1 FROM usersTable WHERE username1='" + usr + "' AND password1= '" + passwd + "'");

        bool x = read.HasRows;

        read.Close();

        return x;
    }

    public struct usrInfo
    {
        public string id;
        public string username;
        public string password;
        public string firstname;
        public string lastname;
        public string address;
        public string city;
        public string state;
        public string zip;
        public string type;
        public string email;
        public string OrgID;
        public string address2;
        public string city2;
        public string state2;
        public string zip2;
    }

    public static usrInfo GetUsrInfo(string sID)
    {
        usrInfo info = new usrInfo();
        SqlDataReader read = SQLOpen("SELECT * FROM usersTable WHERE session1='" + sID + "'");
        read.Read();
        info.id = read["userID"].ToString();
        info.username = read["username1"].ToString();
        info.password = read["password1"].ToString();
        info.firstname = read["firstname1"].ToString();
        info.lastname = read["lastname1"].ToString();
        info.address = read["address1"].ToString();
        info.city = read["city1"].ToString();
        info.state = read["state1"].ToString();
        info.zip = read["zip1"].ToString();
        info.type = read["type1"].ToString();
        info.email = read["email1"].ToString();
        info.OrgID = read["OrgID"].ToString();
        info.address2 = read["address2"].ToString();
        info.city2 = read["city2"].ToString();
        info.state2 = read["state2"].ToString();
        info.zip2 = read["zip2"].ToString();
        return info;
    }

    public static usrInfo GetOUsrInfo(string usr)
    {
        usrInfo info = new usrInfo();
        SqlDataReader read = SQLOpen("SELECT * FROM usersTable WHERE username1='" + usr + "'");
        if (read.HasRows == false)
        {
            read.Close();
            return info;
        }
        read.Read();
        info.id = read["userID"].ToString();
        info.username = read["username1"].ToString();
        info.password = read["password1"].ToString();
        info.firstname = read["firstname1"].ToString();
        info.lastname = read["lastname1"].ToString();
        info.address = read["address1"].ToString();
        info.city = read["city1"].ToString();
        info.state = read["state1"].ToString();
        info.zip = read["zip1"].ToString();
        info.type = read["type1"].ToString();
        info.address2 = read["address2"].ToString();
        info.city2 = read["city2"].ToString();
        info.state2 = read["state2"].ToString();
        info.zip2 = read["zip2"].ToString();
        return info;
    }

    public static bool confUser(string userID)
    {

        SqlDataReader read = SQLOpen("update usersTable set confirmation1=1 where userID=" + userID);
        read.Close();
        if (read.RecordsAffected > 0)
            return true;
        else return false;



    }

    public static bool AdminLogin(string usr, string password)
    {
        bool check;
        SqlDataReader read = SQLOpen("select* from Admin where username1='" + usr + "'and password1='" + password + "'");
        check = read.HasRows;
        read.Close();


        return check;

    }

}


