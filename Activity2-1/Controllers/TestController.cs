using Activity2_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2_1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //make a list of users 
            List<UserModel> users = new List<UserModel>();

            //add users to the list 
            users.Add(new UserModel("Mickey Mouse", "mickmouse@disney.com", "(123)-456-7890"));
            users.Add(new UserModel("Minnie Mouse", "minmouse@disney.com", "(123)-456-7890"));
            users.Add(new UserModel("Donald Duck", "donduck@disney.com", "(123)-456-7890"));
            users.Add(new UserModel("Daisy Duck", "daisduck@disney.com", "(123)-456-7890"));


            return View("Test", users);
        }
    }
}