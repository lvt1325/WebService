using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for MyASMXService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    [ServiceKnownType(typeof(ASMXCustomer))]
    public class MyASMXService : System.Web.Services.WebService
    {
        [WebMethod]
        public int CountData()
        {
            return GetCustomers().Count;
        }

        [WebMethod]
        //[AspNetCacheProfile("NoCache")]
        public ASMXCustomersResult GetCustomers()
        {
            List<ASMXCustomer> list = new List<ASMXCustomer>();
            for (int i = 0; i < 7; i++)
            {
                ASMXCustomer c = new ASMXCustomer()
                {
                    CustomerID = "CustomerID" + i.ToString(),
                    CompanyName = "CompanyName" + i.ToString(),
                    ContactName = "ContactName" + i.ToString(),
                    ContactTitle = "ContactTitle" + i.ToString(),
                    Address = "Address" + i.ToString()
                };
                list.Add(c);
            }
            return new ASMXCustomersResult
            {
                Data = list,
                Count = list.Count
            };
        }
    }

    public class ASMXCustomersResult
    {
        public List<ASMXCustomer> Data { get; set; }
        public int Count { get; set; }
    }

    [DataContract]
    public class ASMXCustomer
    {
        [DataMember]
        public string CustomerID { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string ContactName { get; set; }
        [DataMember]
        public string ContactTitle { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
}