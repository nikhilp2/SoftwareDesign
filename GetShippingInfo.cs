using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for GetShippingInfo
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GetShippingInfo : System.Web.Services.WebService {

    public GetShippingInfo () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod()]
    public string GetShippingInfo(int shopperID, string Street, string City, string State, string Zip)
    {
        //Insert to Data where ObjID = ObjID and shopperID = shopperID and OrgID = OrgID
        return "Fail";
    }

    [System.Web.Services.WebMethod()]
    public bool VerifyShippingInfo(string Street, string City, string State, string Zip)
    {
        bool verified = false;

        if (Zip.Length == 5)
        {
            verified = true;
        }

        return verified;
    }
}
