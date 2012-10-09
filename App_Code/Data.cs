using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Data
/// </summary>
public class Data
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
        SqlDataReader read = SQLOpen("SELECT * FROM users WHERE session='" + sID + "';");
        if (read.HasRows == true)
        {
            read.Close();
            return true;
        }
        read.Close();
        return false;
    }

    public static int setS(string usr, string sID)
    {
        SqlDataReader read = SQLOpen("UPDATE users SET session='" + sID + "' WHERE username='" + usr + "';");
        read.Close();
        read = SQLOpen("SELECT session FROM users WHERE username='" + usr + "';");
        read.Read();
        if (read.HasRows)
        {
            try
            {
                return System.Convert.ToInt32(read["OrgID"]);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        return 0;
    }

    public static bool setUsr(int part, string fname, string lname, string add, string city, string state, string zip, string usr, string passwd, int type, string email, int tenantID)
    {
        string query = "";
    
        if (part == 0)
        {
            SqlDataReader read2 = SQLOpen("SELECT * FROM users WHERE username='" + usr + "'");
            if (read2.HasRows == true)
            {
                read2.Close();
                return false;
            }
        //here//    query = "INSERT INTO users (username, password, firstname, lastname, address, city, state, zip,email) VALUES ( \"" + usr + "\", '" + passwd + "', \"" + fname + "\", \"" + lname + "\", \"" + add + "\", \"" + city + "\", \"" + state + "\", \"" + zip + "\",\"" + email + "\")";
           // query = ("INSERT INTO users (username, password, firstname, lastname, address, city, state, zip,email) VALUES ( \"" + usr + "\", '" + passwd + "', \"" + fname + "\", \"" + lname + "\", \"" + add + "\", \"" + city + "\", \"" + state + "\", \"" + zip + "\",\"" + email + "\")");

            query = "insert into users (username, password, firstname, lastname, address, city, state, zip, email, OrgID) values ('" + usr + "', '" + passwd + "', '" + fname + "', '" + lname + "', '" + add + "', '" + city + "', '" + state + "', '" + zip + "', '" + email + "', '" + tenantID + "')"; 
            SqlDataReader read = SQLOpen(query);                                                                   
            read.Close();

         ///   SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"].ToString());

            string e5Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            SqlConnection conn = new SqlConnection(e5Conn);

         ///   SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["conn"]);
            SqlCommand cmd = new SqlCommand("select userID from users where username='" + usr + "'", conn);
            conn.Open();
          //  cmd = new SqlCommand("insert into users (username, Surname, Gender, Email, Country, Interest) values ('" + usr + "', '" + passwd + "', '" + genderRadio.Text + "', '" + emailText.Text + "', '" + countryDropDown.Text + "', '" + interestCheck.Text + "', )");
         //   cmd =new SqlCommand("INSERT INTO users (username, password, firstname, lastname, address, city, state, zip,email) VALUES ( \"" + usr + "\", '" + passwd + "', \"" + fname + "\", \"" + lname + "\", \"" + add + "\", \"" + city + "\", \"" + state + "\", \"" + zip + "\",\"" + email + "\")");

            cmd.Connection = conn; 
            cmd.ExecuteNonQuery(); 
            conn.Close();
        }
        else if (part == 1)
        {
            query = "UPDATE users SET password='" + passwd + "', firstname='" + fname + "', lastname='" + lname + "', address='" + add + "', city='" + city + "', state='" + state + "', zip='" + zip + "', type='" + type.ToString() + "', OrgID='" + tenantID + "' WHERE username='" + usr + "';";
            SqlDataReader read = SQLOpen(query);
            read.Close();

        }




        return true;
    }


    public static bool chkCred(string usr, string passwd)
    {
        SqlDataReader read = SQLOpen("SELECT username FROM users WHERE username='" + usr + "' AND password= '" + passwd + "'");

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
    }

    public static usrInfo GetUsrInfo(string sID)
    {
        usrInfo info = new usrInfo();
        SqlDataReader read = SQLOpen("SELECT * FROM users WHERE session='" + sID + "'");
        read.Read();
        info.id = read["userID"].ToString();
        info.username = read["username"].ToString();
        info.password = read["password"].ToString();
        info.firstname = read["firstname"].ToString();
        info.lastname = read["lastname"].ToString();
        info.address = read["address"].ToString();
        info.city = read["city"].ToString();
        info.state = read["state"].ToString();
        info.zip = read["zip"].ToString();
        info.type = read["type"].ToString();
        info.email = read["email"].ToString();
        info.OrgID = read["OrgID"].ToString();
        return info;
    }

    public static usrInfo GetOUsrInfo(string usr)
    {
        usrInfo info = new usrInfo();
        SqlDataReader read = SQLOpen("SELECT * FROM users WHERE username='" + usr + "'");
        if (read.HasRows == false)
        {
            read.Close();
            return info;
        }
        read.Read();
        info.id = read["userID"].ToString();
        info.username = read["username"].ToString();
        info.password = read["password"].ToString();
        info.firstname = read["firstname"].ToString();
        info.lastname = read["lastname"].ToString();
        info.address = read["address"].ToString();
        info.city = read["city"].ToString();
        info.state = read["state"].ToString();
        info.zip = read["zip"].ToString();
        info.type = read["type"].ToString();
        return info;
    }

    public static bool confUser(string userID)
    {

        SqlDataReader read = SQLOpen("update users set confirmation=1 where userID=" + userID);
        read.Close();
        if (read.RecordsAffected > 0)
            return true;
        else return false;



    }

    public static bool AdminLogin(string usr, string password)
    {
        bool check;
        SqlDataReader read = SQLOpen("select* from Admin where username='" + usr + "'and password='" + password + "'");
        check = read.HasRows;
        read.Close();


        return check;

    }

}
