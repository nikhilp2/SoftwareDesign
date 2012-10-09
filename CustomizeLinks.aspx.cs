using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class CustomizeLinks : System.Web.UI.Page
{
    string[] links = new string[20];
    string[] linkNames = new string[20];
    private int OrgID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("login.aspx");
        if (System.Convert.ToInt32(Session["admin"]) != 1)
        {
            Response.Redirect("CustomerLogin.aspx");
        }
        else
        {
            try
            {
                OrgID = System.Convert.ToInt32(Session["TenantID"]);
            }
            catch (Exception ex)
            {
                OrgID = 0;
            }
        }
        ListItem toAdd;
        int count = 0;
        bool done = false;
        if (!IsPostBack)
        {
            links = GUIDataLayer.getLinks(OrgID);
            linkNames = GUIDataLayer.getLinkNames(links);
            while (count < 20 & !done)
            {
                if (links[count] == null)
                {
                    done = true;
                }
                else
                {
                    toAdd = null;
                    toAdd = new ListItem();
                    toAdd.Text = linkNames[count];
                    toAdd.Value = links[count];
                    blLinks.Items.Add(toAdd);
                    count++;
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int[] linkIDs = new int[blLinks.Items.Count];
        int counter = 0;
        IEnumerator itemsList = blLinks.Items.GetEnumerator();
        ListItem curItem;
        while (itemsList.MoveNext())
        {
            curItem = (ListItem)itemsList.Current;
            try
            {
                linkIDs[counter] = System.Convert.ToInt32(curItem.Value);
                counter++;
            }
            catch (Exception ex)
            {
            }
        }
        GUIDataLayer.insertSideBarLinks(OrgID, linkIDs);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ListItem toAdd = new ListItem();
        toAdd.Text = ddlLink.SelectedItem.Text;
        toAdd.Value = ddlLink.SelectedValue;
        if (txtOrder.Text.CompareTo("") == 0)
        {
            blLinks.Items.Add(toAdd);
        }
        else
        {
            try
            {
                blLinks.Items.Insert(System.Convert.ToInt32(txtOrder.Text)-1, toAdd);
            }
            catch
            {
                blLinks.Items.Add(toAdd);
            }
        }
        
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        int remove = 0;
        try
        {
            remove = System.Convert.ToInt32(txtRemove.Text) - 1;
            blLinks.Items.RemoveAt(remove);
        }
        catch
        {
        }
    }
}