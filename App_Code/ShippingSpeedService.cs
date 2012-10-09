using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for ShippingService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ShippingSpeedService : System.Web.Services.WebService {

    public ShippingSpeedService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod()]
    public double CalcShippingCost(int orderID, int OrgID, string shippingSpeed, double cost)
    {
        double totalCost = 0.0;

        if(shippingSpeed == "Next Day"){
            totalCost = cost + 10;
        }else if(shippingSpeed == "Two Day"){
            totalCost = cost + 7;
        }else if(shippingSpeed == "Standard"){
            totalCost = cost + 3;
        }else
        {
            totalCost = cost;
        }
        

        return totalCost;
    }
}
