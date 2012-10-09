using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TenantDataLayer
/// </summary>
public class TenantDataLayer
{
	public TenantDataLayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static bool createTenant(string tenantName)
    {
        bool success=false;

        SqlDataReader read;
        SqlCommand cmd = new SqlCommand();
        string e4Conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection conn = new SqlConnection(e4Conn);

        conn.Open();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM Tenant WHERE tenantName = '" + tenantName + "'";
        read = cmd.ExecuteReader();
        read.Read();
        if (read.HasRows)
        {
            success = false;
        }
        else
        {
            read.Close();
            cmd.CommandText = "INSERT INTO Tenant (TenantName) values ('" + tenantName + "')";
            cmd.ExecuteNonQuery();
            success = true;
        }

        return success;
    }

    public static Boolean updateTenant(int tenantID, string tenantName)
    {
        bool success = false;

        return success;
    }
}