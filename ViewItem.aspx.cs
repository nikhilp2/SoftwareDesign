using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ItemToCartService wsToCart = new ItemToCartService();
        UpdateTotalService wsUpdateTotal = new UpdateTotalService();
        int orgID;
        int itemID;
        int cartObjID = 0;
        int ObjID;
        string totalColVal = "";
        string parseString = "";
        string custIDColVal = "";
        string items = "";
        string[] lines;
        string[] itemLines;
        if (Session["user1"] == null)
            Response.Redirect("CustomerLogin.aspx");
        try
        {
            items = System.Convert.ToString(Session["Items"]);
            ObjID = System.Convert.ToInt32(Session["ObjID"]);
            orgID = System.Convert.ToInt32(Session["orgID"]);

            itemLines = items.Split(',');
            for (int x = 0; x < itemLines.Length; x++)
            {
                itemID = System.Convert.ToInt32(itemLines[x]);

                parseString = System.Convert.ToString(wsToCart.AddToCart(itemID, orgID, 0));
                //TempLabel.Text = System.Convert.ToString(wsToCart.AddToCart(itemID,orgID,0));
                if (parseString != "Not added to cart")
                {
                    lines = parseString.Split(',');
                    cartObjID = System.Convert.ToInt32(lines[0]);
                    totalColVal = lines[1];
                    custIDColVal = lines[2];
                    TempLabel.Text = System.Convert.ToString(wsUpdateTotal.UpdateTotal(orgID, ObjID, cartObjID, 0, 0, itemID, totalColVal, custIDColVal));
                }
            }
            Response.Redirect("home.aspx");
        }
        catch (FormatException ex)
        {
            TempLabel.Text = "Can not convert string";
        }
        catch (OverflowException ex)
        {
            TempLabel.Text = "Number too large";
        }
    }
    protected void AddToCartButton_Click(object sender, EventArgs e)
    {
    }
}