using Activity3_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity3_1.Controllers
{
    public class CustomerController : Controller
    {
        Customer customer;
        List<Customer> customers;  

        public CustomerController()
        {
            customers = new List<Customer>();
            customers.Add(new Customer(0, "Mickey", 20));
            customers.Add(new Customer(1, "Chael", 19));
            customers.Add(new Customer(2, "Kylie", 23));
            customers.Add(new Customer(3, "Ashley", 24));
            customers.Add(new Customer(4, "Shaley", 21));
            customers.Add(new Customer(5, "Shawn", 20));
        }


        // GET: Customer
        public ActionResult Index()
        {
            Tuple<List<Customer>, Customer> tuple;

            tuple = new Tuple<List<Customer>, Customer>(customers, customers[0]);

            return View("Customer", tuple);
        }

        [HttpPost]
        public ActionResult OnSelectCustomer(string customerNumber )
        {
            Tuple<List<Customer>, Customer> tuple; 

            tuple = new Tuple<List<Customer>, Customer>(customers, customers[Int32.Parse(customerNumber)]);

            return PartialView("_CustomerDetails", customers[Int32.Parse(customerNumber)]);
        }
    }
}