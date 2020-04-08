using Activity1_3.Models;
using Activity1_3.Services.Business;
using Activity1_3.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Activity1_3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            MyLogger.GetInstance().Info("Entering LoginController.Login()");
            MyLogger.GetInstance().Info("Parameters are: new JavaScriptSerializer().Serialize(user)");

            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Login");
                }

                //return "Here " + model.Username + " and " + model.Password;
                SecurityService ss = new SecurityService();
                Boolean success = ss.Authenticate(user);

                if (success)
                {
                    MyLogger.GetInstance().Info("Exiting LoginController.Login() with login passing");
                    return View("LoginSuccess", user);
                }
                else
                {
                    MyLogger.GetInstance().Info("Exiting LoginController.Login() with login failing");
                    return View("LoginFail");
                }
            }
            catch(Exception e)
            {
                MyLogger.GetInstance().Error("Exception LoginController.Login()", e.Message);
                return View("LoginError"); 
            }
        }
    }
}