using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTestMVC_Jquery.Models;

namespace WebTestMVC_Jquery.Controllers
{
    public class DefaultController : Controller
    {
        //private NORTHWNDContext dbContext = new NORTHWNDContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Search()
        //{
        //    return View();
        //}
        public JsonResult GetCostumers(String query, String type)
        {
            List<Customer> customers = null;
            try
            {
                using (var dbContext = new NORTHWNDContext())
                {
                   customers = dbContext.Customers.ToList();
                }
            }
            catch (Exception ex )
            {
                throw new ArgumentException(ex.Message);
            }

            
            //List<Customer> customers = null;
            //try
            //{
            //    using (dbContext = new NORTHWNDContext())
            //    {
            //        customers = dbContext.Customers.Where(o => o.ContactTitle == query).ToList();
            //        if (customers == null)
            //        {
            //            throw new Exception("Customer resutrn null");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
                
            //    throw new ArgumentException(ex.Message);
            //}

            return Json(customers, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(String query)
        {

            List<Customer> customers = null;
            try
            {
                using (var dbContext = new NORTHWNDContext())
                {
                    if (query == null)
                    {
                        customers = dbContext.Customers.ToList();
                    }
                    else
                    {
                        customers = dbContext.Customers.Where(o => o.ContactTitle == query || o.CompanyName == query || o.ContactName == query).ToList();
                        if (customers == null)
                        {
                            throw new Exception("Customer resutrn null");
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }

            return View(customers);
        }
        public ActionResult Details(String id)
        {
            CustomerModel cusModel = null;

            try
            {
                
                using (var dbContext = new NORTHWNDContext())
                {
                    Customer customer = dbContext.Customers.Where(o => o.CustomerID == id).First();
                    if (customer == null)
                    {
                        ViewBag.ErrorMessage = "User was not found";
                    }
                    else
                    {
                        cusModel = Mapper.CustomerEntityToModel(customer);
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw new ArgumentException(ex.Message);
            }

            return View(cusModel);
        }
        [HttpGet]
        public ActionResult Edit(String id)
        {
            CustomerModel cusModel = null;

            try
            {

                using (var dbContext = new NORTHWNDContext())
                {
                    Customer customer = dbContext.Customers.Where(o => o.CustomerID == id).First();
                    if (customer == null)
                    {
                        ViewBag.ErrorMessage = "User was not found";
                    }
                    else
                    {
                        cusModel = Mapper.CustomerEntityToModel(customer);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            return View(cusModel);
        }
        [HttpPost]
        public ActionResult Edit(CustomerModel cusModel)
        {
            try
            {

                using (var dbContext = new NORTHWNDContext())
                {
                    Customer customer = dbContext.Customers.Where(o => o.CustomerID == cusModel.CustomerID).First();
                    if (customer == null)
                    {
                        ViewBag.ErrorMessage = "User was not found";
                    }
                    else
                    {
                        customer = Mapper.UpdateCustomerModelToEntity(customer, cusModel);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            return RedirectToAction("Index", "Default");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CustomerModel());
        }
        [HttpPost]
        public ActionResult Create(CustomerModel cusModel)
        {
            try
            {
                using (var dbContext = new NORTHWNDContext())
                {
                    Customer customer = Mapper.CustomerModelToEntity(cusModel);
                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();

                }

            }
            catch (Exception ex) 
            {
                
                throw new ArgumentException(ex.Message);
            }
            return RedirectToAction("Index", "Default");

        }
    }
}