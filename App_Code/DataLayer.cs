using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer
{   
    public DataLayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string getNextService(int OrgID, int serviceOrder, string workflowName)
    {
        int workflowID = 0;
        int serviceID = 0;
        int lastService = 0;
        string url = "";

        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM Workflows WHERE orgID = '" + OrgID + "' AND Name = '" + workflowName + "'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            workflowID = (int)read["workflowID"];
        }
        else
        {
            read.Close();
            cmd.CommandText = "SELECT * FROM Workflows WHERE orgID = '0' AND Name = '" + workflowName + "'";
            read = cmd.ExecuteReader();
            read.Read();
            if (read.HasRows)
            {
                workflowID = (int)read["workflowID"];
            }
        }
        read.Close();
        cmd.CommandText = "SELECT * FROM WorkflowServices WHERE workflowID = '" + workflowID + "' AND serviceOrder = '"+ serviceOrder +"'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            serviceID = (int)read["serviceID"];
            read.Close();
            cmd.CommandText = "SELECT * FROM Services WHERE (serviceID = '" + serviceID + "')";
            read = cmd.ExecuteReader();
            read.Read();
            if (read.HasRows)
            {
                url = (string)read["URL"];  
                
            }
        }
        else
        {
            url = "home.aspx";
        }
        cmd = null;
        read.Close();
        conn.Close();
        read = null;
        conn = null;
        return url;
    }

    public static void insertNewWebService(int OrgID, string URL, string Name)
    {
        try
        {
            SqlConnection MyConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\fadiDatabase.mdf;Integrated Security=True;User Instance=True");
            MyConnection.Open();

            String MyString = @"INSERT INTO [Services] ([serviceName], [URL], [orgID]) VALUES('" + Name + "', '" + URL + "', '" + OrgID + "')";
            SqlCommand MyCmd = new SqlCommand(MyString, MyConnection);

            MyCmd.ExecuteNonQuery();
            MyCmd = null;
            MyConnection.Close();
            
        }
        catch (Exception ex)
        {
            //Log error message
        }
    }

    public static string[] getServices(int workflowID)
    {
        string[] services = new string[20];
        int counter = 0;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM WorkflowServices WHERE workflowID = '" + workflowID + "'";
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
            while (read.Read() & counter < 20)
            {
                try
                {
                    services[counter] = System.Convert.ToString(read["serviceID"]);
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
        return services;
    }

    public static string[] getServiceNames(string[] services)
    {
        string[] serviceNames = new string[20];
        int counter = services.Length;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        for (int x = 0; x < counter; x++)
        {
            cmd.CommandText = "SELECT * FROM Services WHERE serviceID = '" + services[x] + "'";
            read = cmd.ExecuteReader();
            read.Read();
            if (read.HasRows)
            {
                serviceNames[x] = System.Convert.ToString(read["serviceName"]);
            }
            read.Close();
        }
        cmd = null;
        conn.Close();
        read = null;
        conn = null;
        return serviceNames;
    }

    public static string getServiceName(string serviceURL)
    {
        string serviceName = "";
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Services WHERE URL = '" + serviceURL + "'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            serviceName = System.Convert.ToString(read["serviceName"]);
        }
        read.Close();
        cmd = null;
        conn.Close();
        read = null;
        conn = null;
        return serviceName;
    }

    public static void insertWorkflowServices(int workflowID, int[] serviceIDs)
    {
        //string SQLupdate = "UPDATE WorkflowServices
        int lastService = 0;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        for (int x=0; x < serviceIDs.Length; x++)
        {
            cmd.CommandText = "SELECT * FROM WorkflowServices WHERE workflowID = '" + workflowID + "' AND serviceID = '" + serviceIDs[x] + "' AND serviceOrder = '" + x + "'";
            read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                try
                {
                    read.Read();
                    lastService = System.Convert.ToInt32(read["lastService"]);
                    if (lastService == 1 && x < serviceIDs.Length-1)
                    {
                        
                        cmd.CommandText = "UPDATE WorkflowServices SET lastService = '0' WHERE ID = '" + read["ID"] + "'";
                        read.Close();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                read.Close();
                if (x == serviceIDs.Length - 1)
                {
                    lastService = 1;
                }
                else
                {
                    lastService = 0;
                }
                cmd.CommandText = "INSERT INTO WorkflowServices (workflowID, serviceID, serviceOrder, lastService) VALUES ('" + workflowID + "', '" + serviceIDs[x] + "', '" + x + "', '" + lastService + "')";
                cmd.ExecuteNonQuery();
            }
            read.Close();
        }

        conn.Close();
        cmd = null;
        read = null;
        conn = null;
    }

    public static void getLaptop(int OrgID, ref string[] fields, ref int[] fieldNums, ref string[,] laptops)
    {
        int ObjID = 0;
        int counter = 0;

        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Objects WHERE OrgID = '" + OrgID + "' AND ObjName = 'Laptop'";
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
            read.Read();
            try
            {
                ObjID = System.Convert.ToInt32(read["ObjID"]);
                read.Close();
                cmd.CommandText = "Select * FROM Fields WHERE ObjID = '" + ObjID + "'";
                read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        fields[counter] = System.Convert.ToString(read["FieldName"]);
                        fieldNums[counter] = System.Convert.ToInt32(read["FieldNumber"]);
                        counter++;
                    }
                    read.Close();
                    cmd.CommandText = "SELECT * FROM Data WHERE ObjID = '" + ObjID + "'";
                    read = cmd.ExecuteReader();
                    if (read.HasRows)
                    {
                        counter = 0;
                        while (read.Read())
                        {
                            laptops[counter,0] = System.Convert.ToString(read["Value00"]);
                            laptops[counter, 1] = System.Convert.ToString(read["Value01"]);
                            laptops[counter, 2] = System.Convert.ToString(read["Value02"]);
                            laptops[counter, 3] = System.Convert.ToString(read["Value03"]);
                            laptops[counter, 4] = System.Convert.ToString(read["Value04"]);
                            laptops[counter,5] = System.Convert.ToString(read["Value05"]);
                            laptops[counter, 6] = System.Convert.ToString(read["Value06"]);
                            laptops[counter, 7] = System.Convert.ToString(read["Value07"]);
                            laptops[counter, 8] = System.Convert.ToString(read["Value08"]);
                            laptops[counter, 9] = System.Convert.ToString(read["Value09"]);
                            laptops[counter, 10] = System.Convert.ToString(read["Value10"]);
                            counter++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
    public static void getBook(int OrgID, ref string[] fields, ref int[] fieldNums, ref string[,] books)
    {
        int ObjID = 0;
        int counter = 0;

        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Objects WHERE OrgID = '" + OrgID + "' AND ObjName = 'Book'";
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
            read.Read();
            try
            {
                ObjID = System.Convert.ToInt32(read["ObjID"]);
                read.Close();
                cmd.CommandText = "Select * FROM Fields WHERE ObjID = '" + ObjID + "'";
                read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        fields[counter] = System.Convert.ToString(read["FieldName"]);
                        fieldNums[counter] = System.Convert.ToInt32(read["FieldNumber"]);
                        counter++;
                    }
                    read.Close();
                    cmd.CommandText = "SELECT * FROM Data WHERE ObjID = '" + ObjID + "'";
                    read = cmd.ExecuteReader();
                    if (read.HasRows)
                    {
                        counter = 0;
                        while (read.Read())
                        {
                            books[counter, 0] = System.Convert.ToString(read["Value00"]);
                            books[counter, 1] = System.Convert.ToString(read["Value01"]);
                            books[counter, 2] = System.Convert.ToString(read["Value02"]);
                            books[counter, 3] = System.Convert.ToString(read["Value03"]);
                            books[counter, 4] = System.Convert.ToString(read["Value04"]);
                            books[counter, 5] = System.Convert.ToString(read["Value05"]);
                            books[counter, 6] = System.Convert.ToString(read["Value06"]);
                            books[counter, 7] = System.Convert.ToString(read["Value07"]);
                            books[counter, 8] = System.Convert.ToString(read["Value08"]);
                            books[counter, 9] = System.Convert.ToString(read["Value09"]);
                            books[counter, 10] = System.Convert.ToString(read["Value10"]);
                            counter++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    public static void getCart(int OrgID, ref string[] fields, ref int[] fieldNums, ref string[] cart)
    {
        int ObjID = 0;
        int counter = 0;
        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT * FROM Objects WHERE OrgID = '" + OrgID + "' AND ObjName = 'Cart'";
        read = cmd.ExecuteReader();
        if (read.HasRows)
        {
            read.Read();
            try
            {
                ObjID = System.Convert.ToInt32(read["ObjID"]);
                read.Close();
                cmd.CommandText = "Select * FROM Fields WHERE ObjID = '" + ObjID + "'";
                read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        fields[counter] = System.Convert.ToString(read["FieldName"]);
                        fieldNums[counter] = System.Convert.ToInt32(read["FieldNumber"]);
                        counter++;
                    }
                    read.Close();
                    cmd.CommandText = "SELECT * FROM Data WHERE ObjID = '" + ObjID + "' AND Value00 = '0'";
                    read = cmd.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                            cart[0] = System.Convert.ToString(read["Value00"]);
                            cart[1] = System.Convert.ToString(read["Value01"]);
                            cart[2] = System.Convert.ToString(read["Value02"]);
                            cart[3] = System.Convert.ToString(read["Value03"]);
                            cart[4] = System.Convert.ToString(read["Value04"]);
                            cart[5] = System.Convert.ToString(read["Value05"]);
                            cart[6] = System.Convert.ToString(read["Value06"]);
                            cart[7] = System.Convert.ToString(read["Value07"]);
                            cart[8] = System.Convert.ToString(read["Value08"]);
                            cart[9] = System.Convert.ToString(read["Value09"]);
                            cart[10] = System.Convert.ToString(read["Value10"]);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }    
}