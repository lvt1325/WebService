﻿//using Model.ReadWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;
using Telerik.Web.UI;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication1
{
    [ServiceKnownType(typeof(ServiceCustomer))]
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EditingWcfService
    {
        [OperationContract]
        public RadListBoxItemData[] LoadCustomerId()
        {
            List<RadListBoxItemData> x = new List<RadListBoxItemData>();
            for (int i = 0; i < 5; i++)
            {
                x.Add(new RadListBoxItemData());
            }
            return x.ToArray();
        }

        [WebGet]
        //[AspNetCacheProfile("NoCache")]
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

        [WebGet]
        //[AspNetCacheProfile("NoCache")]
        public void UpdateCustomers(string customersJSON)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<ServiceCustomer> customers = (List<ServiceCustomer>)serializer.Deserialize(customersJSON, typeof(List<ServiceCustomer>));
            //NorthwindReadWriteEntities entities = new NorthwindReadWriteEntities();
            //foreach (ServiceCustomer serviceCustomer in customers)
            //{
            //    Customer customer = entities.Customers.FirstOrDefault(c => c.CustomerID == serviceCustomer.CustomerID);
            //    customer.CompanyName = serviceCustomer.CompanyName;
            //    customer.ContactName = serviceCustomer.ContactName;
            //    customer.ContactTitle = serviceCustomer.ContactTitle;
            //    customer.Address = serviceCustomer.Address;
            //}
            //entities.SaveChanges();
        }

        [WebGet]
        //[AspNetCacheProfile("NoCache")]
        public CustomersResult InsertCustomers(string customersJSON)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<ServiceCustomer> customers = (List<ServiceCustomer>)serializer.Deserialize(customersJSON, typeof(List<ServiceCustomer>));
            //NorthwindReadWriteEntities entities = new NorthwindReadWriteEntities();
            //foreach (ServiceCustomer serviceCustomer in customers)
            //{
            //    Customer newCustomer = new Customer()
            //    {
            //        CustomerID = Regex.Replace(Guid.NewGuid().ToString("N"), "[0-9]", "").Substring(0, 5).ToUpper(),
            //        CompanyName = serviceCustomer.CompanyName,
            //        ContactName = serviceCustomer.ContactName,
            //        ContactTitle = serviceCustomer.ContactTitle,
            //        Address = serviceCustomer.Address
            //    };
            //    serviceCustomer.CustomerID = newCustomer.CustomerID;
            //    entities.AddToCustomers(newCustomer);
            //}
            //entities.SaveChanges();
            return new CustomersResult
            {
                Data = customers
            };
        }

        [WebGet]
        //[AspNetCacheProfile("NoCache")]
        public object DeleteCustomers(string customersJSON)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<ServiceCustomer> customers = (List<ServiceCustomer>)serializer.Deserialize(customersJSON, typeof(List<ServiceCustomer>));
            ////NorthwindReadWriteEntities entities = new NorthwindReadWriteEntities();
            ////foreach (ServiceCustomer serviceCustomer in customers)
            ////{
            ////    Customer customer = entities.Customers.FirstOrDefault(c => c.CustomerID == serviceCustomer.CustomerID);
            ////    entities.DeleteObject(customer);
            ////}
            //entities.SaveChanges();
            return customersJSON;
        }
    }

    [DataContract]
    public class ServiceCustomer
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

        [DataMember]
        public string __type { get; set; }
    }

    public class CustomersResult
    {
        public List<ServiceCustomer> Data { get; set; }
        public int Count { get; set; }
    }

    public class CustomersEditResult
    {
        public List<ServiceCustomer> models { get; set; }
    }
}