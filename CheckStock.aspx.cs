using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    Test.Info dat;
    int[] itemList = new int[20];
    int[] itemType = new int[20];
    string[] inStock = new string[20];
    CheckStock wsCheckStock = new CheckStock();
    string orderID;
    int orgID;
    TableRow[] row = new TableRow[21];
    TableCell[,] cell = new TableCell[21, 11];

    protected void Page_Load(object sender, EventArgs e)
    {
        int x = 0;
        int y = 0;
        int fieldNumber = 0;
        bool stop = false;
        bool stop2 = false;
        string display = "";

        if (Session["user"] == null)
            Response.Redirect("login.aspx");
        else
        {

            //dat = Test.GetInfo(Session["user"].ToString());
            //UserLabel.Text = dat.Fieldname;

        }
        try
        {
            orderID = System.Convert.ToString(Session["OrderID"]);
        }
        catch
        {
            orderID = "0";
        }
        try
        {
            orgID = System.Convert.ToInt32(Session["OrgID"]);
        }
        catch
        {
            orgID = 0;
        }
        wsCheckStock.getItems(orderID, orgID, ref itemList, ref itemType, ref inStock);

        //row[0] = new TableRow();
        /*for (int z = 0; z < fields.Length; z++)
        {
            cell[0, z] = new TableCell();
            cell[0, z].Text = fields[z];
            row[0].Cells.Add(cell[0, z]);
        }*/
        //tblItems.Rows.Add(row[0]);

        cell[0, 0] = new TableCell();
        cell[0, 0].Text = "Item ID";
        row[0] = new TableRow();
        row[0].Cells.Add(cell[0, 0]);
        cell[0, 1] = new TableCell();
        cell[0, 1].Text = "Item Type";
        row[0].Cells.Add(cell[0, 1]);
        cell[0, 2] = new TableCell();
        cell[0, 2].Text = "In Stock";
        row[0].Cells.Add(cell[0, 2]);
        tblItems.Rows.Add(row[0]);

        x = 0;
        while (x < itemList.Length && !stop)
        {
            if (itemList[x] == 0)
            {
                stop = true;
            }
            else
            {
                row[x + 1] = new TableRow();
                cell[x, 0] = new TableCell();
                cell[x, 0].Text = "" + itemList[x];
                row[x + 1].Cells.Add(cell[x, 0]);
                cell[x, 2] = new TableCell();
                cell[x, 2].Text = "" + itemType[x];
                row[x + 1].Cells.Add(cell[x, 2]);
                cell[x, 3] = new TableCell();
                cell[x, 3].Text = "" + inStock[x];
                row[x + 1].Cells.Add(cell[x, 3]);
                tblItems.Rows.Add(row[x + 1]);
            }
            x++;
        }

        /*
        while (y < 20 && !stop2)
        {
            row[y + 1] = new TableRow();
            stop = false;
            display = "";
            x = 0;
            while (x < 11 && !stop && !stop2)
            {
                if (itemList[y, fieldNumber] == null)
                {
                    stop2 = true;
                    break;
                }
                cell[y + 1, x] = new TableCell();
                fieldNumber = fieldNums[x];
                cell[y + 1, x].Text = itemList[y, fieldNumber];
                row[y + 1].Cells.Add(cell[y + 1, x]);
                x++;
                if (fields[x] == null)
                {
                    stop = true;
                }
            }
            tblItems.Rows.Add(row[y + 1]);
            y++;
        }*/
    }
    protected void btnShipInStock_Click(object sender, EventArgs e)
    {
        string Message;
        Message = "Items: ";
        for (int t = 0; t < itemList.Length; t++)
        {
            if (inStock[t] == "Yes")
            {
                Message = Message + " " + itemList[t];
            }
        }
        UserLabel.Text = Message + " were shipped";
    }
    protected void btnShipAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}