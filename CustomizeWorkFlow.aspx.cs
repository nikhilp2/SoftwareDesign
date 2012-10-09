using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class CustomizeWorkFlow : System.Web.UI.Page
{
    string[] services = new string[20];
    string[] serviceNames = new string[20];
    int workflowID = 0;
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
        btnAddService.Enabled = false;
    }

    protected void btnAddService_Click(object sender, EventArgs e)
    {
        ListItem toAdd = new ListItem();
        toAdd.Text = ddlService.SelectedItem.Text;
        toAdd.Value = ddlService.SelectedValue;

        if (txtOrder.Text.CompareTo("") == 0)
        {
            blServices.Items.Add(toAdd);
        }
        else
        {
            try
            {
                blServices.Items.Insert(System.Convert.ToInt32(txtOrder.Text) - 1, toAdd);
            }
            catch
            {
                blServices.Items.Add(toAdd);
            }
        }
    }

    protected void btnCustomize_Click(object sender, EventArgs e)
    {
        ListItem toAdd;
        blServices.Items.Clear();
        try
        {
            workflowID = System.Convert.ToInt32(ddlWorkflow.SelectedValue);
        }
        catch(Exception ex)
        {
            workflowID = 0;
        }
        int count = 0;
        bool done = false;
        services = DataLayer.getServices(workflowID);
        serviceNames = DataLayer.getServiceNames(services);
        while(count < 20 & !done)
        {
            if (services[count] == null)
            {
                done = true;
            }
            else
            {
                toAdd = null;
                toAdd = new ListItem();
                toAdd.Text = serviceNames[count];
                toAdd.Value =  services[count];
                blServices.Items.Add(toAdd);
                count++;
            }
            
        }
        btnAddService.Enabled = true;
    }

    protected void btnAddWorkflow_Click(object sender, EventArgs e)
    {
        int[] serviceIDs = new int[blServices.Items.Count];
        int counter = 0;
        int curWorkflowID;
        IEnumerator itemsList = blServices.Items.GetEnumerator();
        ListItem curItem;
        try
        {
            curWorkflowID = System.Convert.ToInt32(ddlWorkflow.SelectedValue);
        }
        catch (Exception ex)
        {
            curWorkflowID = 0;
        }
        while (itemsList.MoveNext())
        {
            curItem = (ListItem)itemsList.Current;
            try
            {
                serviceIDs[counter] = System.Convert.ToInt32(curItem.Value);
                counter++;
            }
            catch (Exception ex)
            {
            }
        }
        DataLayer.insertWorkflowServices(curWorkflowID, serviceIDs);
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        int remove = 0;
        try
        {
            remove = System.Convert.ToInt32(txtRemove.Text) - 1;
            blServices.Items.RemoveAt(remove);
        }
        catch
        {
        }
    }
}