using Activity2_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2_3.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAppointmentDetails(AppointmentModel appointment)
        {
            return View("ShowAppointmentDetails", appointment);
        }
    }
}