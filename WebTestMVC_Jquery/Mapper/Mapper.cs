using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTestMVC_Jquery.Models;

namespace WebTestMVC_Jquery
{
    public class Mapper
    {
        public static CustomerModel CustomerEntityToModel(Customer customer)
        {
            CustomerModel customerModel = new CustomerModel();
            customerModel.CustomerID = customer.CustomerID;
            customerModel.CompanyName = customer.CompanyName;
            customerModel.ContactName = customer.ContactName;
            customerModel.ContactTitle = customer.ContactTitle;
            customerModel.Address = customer.Address;
            customerModel.City = customer.City;
            customerModel.PostalCode = customer.PostalCode;
            customerModel.Region = customer.Region;
            customerModel.Country = customer.Country;
            customerModel.Phone = customer.Phone;
            customerModel.Fax = customer.Fax;
            return customerModel;
        }
        public static List<CustomerModel> CustomerEntitiesToModels(List<Customer> customers)
        {
            List<CustomerModel> cusModels = new List<CustomerModel>();

            foreach (var cus in customers)
            {
                cusModels.Add(CustomerEntityToModel(cus));
            }

            return cusModels;
        }
            
        public static Customer CustomerModelToEntity(CustomerModel cusModel)
        {
            Customer customer = new Customer();
            customer.CustomerID = cusModel.CustomerID;
            customer.CompanyName = cusModel.CompanyName;
            customer.ContactName = cusModel.ContactName;
            customer.ContactTitle = cusModel.ContactTitle;
            customer.Address = cusModel.Address;
            customer.City = cusModel.City;
            customer.PostalCode = cusModel.PostalCode;
            customer.Region = cusModel.Region;
            customer.Country = cusModel.Country;
            customer.Phone = cusModel.Phone;
            customer.Fax = cusModel.Fax;

            return customer;
        }

        public static Customer UpdateCustomerModelToEntity(Customer customer, CustomerModel cusModel)
        {
            //Customer customer = new Customer();
            customer.CustomerID = cusModel.CustomerID;
            customer.CompanyName = cusModel.CompanyName;
            customer.ContactName = cusModel.ContactName;
            customer.ContactTitle = cusModel.ContactTitle;
            customer.Address = cusModel.Address;
            customer.City = cusModel.City;
            customer.PostalCode = cusModel.PostalCode;
            customer.Region = cusModel.Region;
            customer.Country = cusModel.Country;
            customer.Phone = cusModel.Phone;
            customer.Fax = cusModel.Fax;

            return customer;
        }
    }
}