using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebTestMVC_Jquery.Models
{
    public class CustomerModel
    {
        public String CustomerID { get; set ;}
        [DisplayName("Company Name")]
        [Required]
        public String CompanyName { get; set; }
        [DisplayName("Contact Name")]
        public String ContactName { get; set; }
        [DisplayName("Contact Title")]
        public String ContactTitle { get; set; }
        [DisplayName("Address")]
        public String Address { get; set; }
        public String City { get; set; }
        public String Region { get; set; }
        public String PostalCode { get; set; }
        [DisplayName("Country")]
        public String Country { get; set; }
        [DisplayName("Phone Number")]
        public String Phone { get; set; }
        [DisplayName("Fax Number")]
        public String Fax { get; set; }

        [DisplayName("Full Address")]
        public String GetFullAddress()
        {
            return Address + "," + City + "," + Region + "," + PostalCode;
        }

        //public class CustomerDBContext : NORTHWNDContext
        //{
        //    public DbSet<Customer> Customers {get; set;}
        //}
    }
}