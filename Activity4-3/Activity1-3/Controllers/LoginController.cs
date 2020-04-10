using Activity1_3.Models;
using Activity1_3.Services.Business;
using Activity1_3.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
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

        [HttpGet]
        [CustomAuthorization]
        public ActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am a protected method if the proper attribute is applied to me."); 
        }

        [HttpGet]
        public string GetUsers()
        {
            //get the default memory cache 
            var cache = MemoryCache.Default;

            //get users from the cache and if users do not exist in the cache, put them in the cache
            List<UserModel> users = cache.Get("Users") as List<UserModel>; 
            if(users == null)
            {
                //log message 
                MyLogger.GetInstance().Info("Mickey's App: Creating Users and putting them into the cache");

                //create a list of users 
                users = new List<UserModel>();
                users.Add(new UserModel("Chael","Test"));
                users.Add(new UserModel("Kylie", "Test"));
                users.Add(new UserModel("Laine", "Test"));

                //save the users in the cache with 60s expiration policy 
                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60.0);
                cache.Set("Users", users, policy); 
            }
            else
            {
                //Log message
                MyLogger.GetInstance().Info("Mickey's App: Got Users from the cache");

            }

            //return JSON serialized list of users 
            return new JavaScriptSerializer().Serialize(users); 
        }
    }
}