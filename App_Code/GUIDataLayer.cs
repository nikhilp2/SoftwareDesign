using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for GUIDataLayer
/// </summary>
public class GUIDataLayer
{
	public GUIDataLayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string getImage(int customerID)
    {
        string ImageID = "";
        string URL = "";
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);
        SqlDataReader read;

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM GUIs WHERE CustomerID = '" + customerID + "'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            try
            {
                ImageID = System.Convert.ToString(read["BackgroundImageID"]);
                cmd.CommandText = "SELECT * FROM Images WHERE idImage = '" + ImageID + "'";
                read.Close();
                read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    URL = System.Convert.ToString(read["URL"]);
                }
            }
            catch
            {
            }
        }

        return URL;
    }

    public static string getHeader(int customerID)
    {
        string header = "";

        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);
        SqlDataReader read;

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM GUIs WHERE CustomerID = '" + customerID + "'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            try
            {
                header = System.Convert.ToString(read["BannerText"]);
            }
            catch
            {
            }
        }

        return header;
    }

    public static string getFooter(int customerID)
    {
        string footer = "";

        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);
        SqlDataReader read;

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM GUIs WHERE CustomerID = '" + customerID + "'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            try
            {
                footer = System.Convert.ToString(read["FooterText"]);
            }
            catch
            {
            }
        }

        return footer;
    }

    public static string getImageURL(int value)
    {
        string URL = "";

        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);
        SqlDataReader read;

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM Images WHERE idImage = '" + value + "'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            try
            {
                URL = System.Convert.ToString(read["URL"]);
            }
            catch
            {
            }
        }

        return URL;
    }

    public static string[] getGUI(int customerID)
    {
        string[] GUI = new string[3];
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);
        SqlDataReader read;

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM GUIs WHERE CustomerID = '" + customerID + "'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            try
            {
                GUI[0] = System.Convert.ToString(read["BannerText"]);
                GUI[1] = System.Convert.ToString(read["BackgroundImageID"]);
                GUI[2] = System.Convert.ToString(read["FooterText"]);
            }
            catch
            {
            }
        }
        return GUI;
    }

    public static void insertGUI(int customerID, string BannerText, string BackgroundImage, string FooterText)
    {
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "UPDATE GUIs SET BackgroundImageID='" + BackgroundImage + "', BannerText='" + BannerText + "', FooterText='" + FooterText + "' WHERE customerID='" + customerID + "'";
        cmd.ExecuteNonQuery();

        cmd = null;
        conn.Close();
        conn = null;
    }

    public static void insertImage(string ImageName, string URL)
    {
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "INSERT INTO Images (Name, URL) VALUES ('" + ImageName + "','" + URL + "')";
        cmd.ExecuteNonQuery();

        cmd = null;
        conn.Close();
        conn = null;
    }

    public static void insertLink(string LinkName, string URL, int CustomerID)
    {
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "INSERT INTO Links (LinkName, URL, CustomerID) VALUES ('" + LinkName + "','" + URL + "','" + CustomerID + "')";
        cmd.ExecuteNonQuery();

        cmd = null;
        conn.Close();
        conn = null;
    }

    public static string[] getLinkURLs(string[] links)
    {
        string[] linkNames = new string[20];
        int counter = links.Length;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        for (int x = 0; x < counter; x++)
        {
            cmd.CommandText = "SELECT * FROM Links WHERE idLinks = '" + links[x] + "'";
            read = cmd.ExecuteReader();
            read.Read();
            if (read.HasRows)
            {
                linkNames[x] = System.Convert.ToString(read["URL"]);
            }
            read.Close();
        }
        cmd = null;
        conn.Close();
        read = null;
        conn = null;
        return linkNames;
    }

    public static string[] getLinkNames(string[] links)
    {
        string[] linkNames = new string[20];
        int counter = links.Length;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        for (int x = 0; x < counter; x++)
        {
            cmd.CommandText = "SELECT * FROM Links WHERE idLinks = '" + links[x] + "'";
            read = cmd.ExecuteReader();
            read.Read();
            if (read.HasRows)
            {
                linkNames[x] = System.Convert.ToString(read["LinkName"]);
            }
            read.Close();
        }
        cmd = null;
        conn.Close();
        read = null;
        conn = null;
        return linkNames;
    }

    public static void insertSideBarLinks(int CustomerID, int[] linkIDs)
    {
        int lastService = 0;
        int GUIID;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM GUIs WHERE CustomerID = '" + CustomerID + "'";
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
            try
            {
                read.Read();
                GUIID = System.Convert.ToInt32(read["idGUI"]);
                read.Close();
            }
            catch
            {
                GUIID = 0;
            }
            cmd.CommandText = "DELETE FROM SidebarLinks WHERE GUIID = '" + GUIID + "'";
            cmd.ExecuteNonQuery();
            for (int x = 0; x < linkIDs.Length; x++)
            {
                cmd.CommandText = "INSERT INTO SidebarLinks (GUIID, LinkID) VALUES ('" + GUIID + "','" + linkIDs[x] + "')";
                cmd.ExecuteNonQuery();
            }
        }

        conn.Close();
        cmd = null;
        read = null;
        conn = null;
    }

    public static string[] getLinks(int CustomerID)
    {
        string[] links = new string[20];
        int counter = 0;
        int GUIID;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM GUIs WHERE CustomerID = '" + CustomerID + "'";
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
            try
            {
                read.Read();
                GUIID = System.Convert.ToInt32(read["idGUI"]);
                read.Close();
            }
            catch
            {
                GUIID = 0;
            }
            cmd.CommandText = "SELECT * FROM SidebarLinks WHERE GUIID = '" + GUIID + "'";
            read = cmd.ExecuteReader();
            while (read.Read() & counter < 20)
            {
                try
                {
                    links[counter] = System.Convert.ToString(read["LinkID"]);
                    counter++;
                }
                catch (Exception ex)
                {
                    //Log error message
                }

            }
        }
        read.Close();
        cmd = null;
        conn.Close();
        read = null;
        conn = null;
        return links;
    }
}