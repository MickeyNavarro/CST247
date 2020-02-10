using Activity2_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2_1.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Test2
        public ActionResult Index()
        {
            //make a list of airline tickets 
            List<AirlineTicketModel> tickets = new List<AirlineTicketModel>();

            //add tickets to the list 
            tickets.Add(new AirlineTicketModel(1, "Los Angeles, CA", new DateTime(2020, 7, 10, 4, 15, 00)));
            tickets.Add(new AirlineTicketModel(2, "New York, NY", new DateTime(2020, 8, 1, 7, 10, 00)));
            tickets.Add(new AirlineTicketModel(3, "Seatle, WA", new DateTime(2020, 9, 13, 10, 30, 00)));
            tickets.Add(new AirlineTicketModel(4, "Phoenix, AZ", new DateTime(2020, 10, 23, 12, 00, 00)));


            return View("Tickets", tickets);
        }
    }
}