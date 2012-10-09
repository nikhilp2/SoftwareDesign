using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayBooks : System.Web.UI.Page
{
    string[] fields = new string[11];
    int[] fieldNums = new int[11];
    string[,] books = new string[20, 11];
    CheckBox[] chkBox = new CheckBox[20];
    TableRow[] row = new TableRow[21];
    TableCell[,] cell = new TableCell[21, 12];
    int OrgID = 1001;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            OrgID = System.Convert.ToInt32(Session["TenantID"]);
        }
        catch (Exception ex)
        {
        }
        //get information about laptops
        DataLayer.getBook(OrgID, ref fields, ref fieldNums, ref books);
        int x = 0;
        int y = 0;
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
        cell[0, 11] = new TableCell();
        cell[0, 11].Text = "Add to Cart";
        row[0].Cells.Add(cell[0, 11]);
        tblBooks.Rows.Add(row[0]);
        while (y < 20 && !stop2)
        {
            row[y + 1] = new TableRow();
            stop = false;
            display = "";
            x = 0;
            while (x < 11 && !stop && !stop2)
            {
                if (books[y, fieldNumber] == null)
                {
                    stop2 = true;
                    break;
                }
                cell[y + 1, x] = new TableCell();
                fieldNumber = fieldNums[x];
                cell[y + 1, x].Text = books[y, fieldNumber];
                row[y + 1].Cells.Add(cell[y + 1, x]);
                x++;
                if (fields[x] == null)
                {
                    stop = true;
                }
            }
            chkBox[y] = new CheckBox();
            cell[y + 1, 11] = new TableCell();
            cell[y + 1, 11].Controls.Add(chkBox[y]);
            row[y + 1].Cells.Add(cell[y + 1, 11]);
            tblBooks.Rows.Add(row[y + 1]);
            y++;
        }
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        DataLayer dl = new DataLayer();
        string items = "";
        for (int x = 0; x < chkBox.Length; x++)
        {
            try
            {
                if (chkBox[x].Checked)
                {
                    if (items == "")
                    {
                        items = cell[x + 1, 1].Text;
                    }
                    else
                    {
                        items = items + "," + cell[x + 1, 1].Text;
                    }
                }
            }
            catch
            {
            }
        }
        Session["Items"] = items;
        Session["ObjID"] = 2;
        Session["orgID"] = OrgID;
        Response.Redirect(dl.getNextService(OrgID, 0, "Add to cart"));
    }
}