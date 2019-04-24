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
    [ServiceKnownType(typeof(Product))]
    public class MyASMXService : System.Web.Services.WebService
    {
        [WebMethod]
        public int CountData()
        {
            return GetCustomers().Count;
        }

        //[WebMethod]
        ////[AspNetCacheProfile("NoCache")]
        //public CustomersResult GetCustomers()
        //{
        //    List<ServiceCustomer> list = new List<ServiceCustomer>();
        //    for (int i = 0; i < 7; i++)
        //    {
        //        ServiceCustomer c = new ServiceCustomer()
        //        {
        //            CustomerID = "CustomerID" + i.ToString(),
        //            CompanyName = "CompanyName" + i.ToString(),
        //            ContactName = "ContactName" + i.ToString(),
        //            ContactTitle = "ContactTitle" + i.ToString(),
        //            Address = "Address" + i.ToString()
        //        };
        //        list.Add(c);
        //    }
        //    return new CustomersResult
        //    {
        //        Data = list,
        //        Count = list.Count
        //    };

        //}

        [WebMethod]
        public CustomersResult GetCustomers()
        {
            List<ServiceCustomer> list = new List<ServiceCustomer>();
            for (int i = 0; i < 7; i++)
            {
                ServiceCustomer c = new ServiceCustomer()
                {
                    CustomerID = "CustomerID" + i.ToString(),
                    CompanyName = "CompanyName" + i.ToString(),
                    ContactName = "ContactName" + i.ToString(),
                    ContactTitle = "ContactTitle" + i.ToString(),
                    Address = "Address" + i.ToString()
                };
                list.Add(c);
            }
            return new CustomersResult
            {
                Data = list,
                Count = list.Count
            };
        }

        [WebMethod]
        public ResultData GetDataAndCount(int startRowIndex, int maximumRows, string sortExpression, string filterExpression)
        {
            ResultData result = new ResultData();
            result.Data = new List<Product>();

            for (int i = 0; i < 100; i++)
            {
                Product c = new Product()
                {
                    ProductID = i,
                    ProductName = "CompanyName" + i.ToString(),
                    UnitPrice = i * 10,
                    ReorderLevel = i * 100,
                    Discontinued = i % 2 == 0
                };
                result.Data.Add(c);
            }
            result.Count = result.Data.Count;
            return result;
        }
    }
}


public class ResultData
{
    public int Count { get; set; }
    public List<Product> Data { get; set; }
}

[DataContract]
public class Product
{
    [DataMember]
    public int ProductID { get; set; }
    [DataMember]
    public string ProductName { get; set; }
    [DataMember]
    public decimal? UnitPrice { get; set; }
    [DataMember]
    public int ReorderLevel { get; set; }
    [DataMember]
    public bool Discontinued { get; set; }
}

[DataContract]
public class Customer
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