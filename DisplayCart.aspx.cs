using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayCart : System.Web.UI.Page
{
    string[] fields = new string[11];
    int[] fieldNums = new int[11];
    string[] cart = new string[11];
    TableRow[] row = new TableRow[2];
    TableCell[,] cell = new TableCell[2, 12];
    int OrgID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user1"] == null)
            Response.Redirect("CustomerLogin.aspx");
        try
        {
            OrgID = System.Convert.ToInt32(Session["TenantID"]);
        }
        catch (Exception ex)
        {
        }
        //get information about cart
        DataLayer.getCart(OrgID, ref fields, ref fieldNums, ref cart);
        int x = 0;
        int fieldNumber = 0;
        bool stop = false;
        bool stop2 = false;
        string display = "";
        row[0] = new TableRow();
        for (int z = 0; z < fields.Length; z++)
        {
            cell[0, z] = new TableCell();
            cell[0, z].Text = fields[z];
            row[0].Cells.Add(cell[0, z]);
        }
        tblCart.Rows.Add(row[0]);
        row[1] = new TableRow();
        stop = false;
        display = "";
        x = 0;
        while (x < 11 && !stop && !stop2)
        {
            if (cart[fieldNumber] == null)
            {
                stop2 = true;
                break;
            }
            cell[1, x] = new TableCell();
            fieldNumber = fieldNums[x];
            cell[1, x].Text = cart[fieldNumber];
            row[1].Cells.Add(cell[1, x]);
            x++;
            if (fields[x] == null)
            {
                stop = true;
            }
        }
        tblCart.Rows.Add(row[1]);
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        Session["workflow"] = "Check out";
        Session["OrgID"] = OrgID;
        Session["shopperID"] = cell[1, 1];
        Session["serviceOrder"] = 0;
        Session["cartID"] = cell[1, 0];
        Session["total"] = cell[1, 3].Text;
        Response.Redirect(dl.getNextService(OrgID, 0, "Check out"));
    }
}