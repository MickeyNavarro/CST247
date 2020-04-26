using BibleVerseApp.Models;
using BibleVerseApp.Services.Business;
using BibleVerseApp.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApp.Controllers
{
    public class BibleController : Controller
    {

        // GET: Entry

        //methods used to return vertain pages only
        public ActionResult Home()
        {
            return View("Home");
        }

        public ActionResult Entry()
        {
            return View("Entry");
        }

        public ActionResult Search()
        {
            return View("Search");
        }

        [HttpPost]
        public ActionResult EnterVerse(BibleVerseModel verseModel)
        {
            MyLogger.GetInstance().Info("Entering BibleController.EnterVerse()");

            //create an instance of the security service to access the create method 
            SecurityService securityService = new SecurityService();

            //return the results to a bool to show if the creation was successful or not
            Boolean success = securityService.Create(verseModel);

            try
            {
                //check the results and return the appropriate page
                if (success)
                {
                    MyLogger.GetInstance().Info("Exiting BibleController.EnterVerse() with successful creation of a new verse.");
                    return View("NewVerseSuccess", verseModel);
                }
                else
                {
                    MyLogger.GetInstance().Info("Exiting BibleController.EnterVerse() with failed creation of a new verse.");
                    return View("NewVerseFailure");
                }
            }
            catch (Exception e)
            {
                MyLogger.GetInstance().Error("Exception BibleController.EnterVerse()", e.Message);
                string errMessage = e.Message;
                return View("Error", errMessage);
            }
        }

        [HttpPost]
        public ActionResult FindVerse(BibleVerseModel verseModel)
        {
            MyLogger.GetInstance().Info("Entering BibleController.FindVerse()");

            //create an instance of the security service to access the search method 
            SecurityService securityService = new SecurityService();

            

            try
            {
                //return the results to a bool to show if the search was successful or not
                Boolean success = securityService.Search(verseModel);
                //check the results and return the appropriate page
                if (success)
                {
                    MyLogger.GetInstance().Info("Exiting BibleController.FindVerse() with successful search of a certain verse.");
                    return View("FindVerseSuccess", verseModel);
                }
                else
                {
                    MyLogger.GetInstance().Info("Exiting BibleController.FindVerse() with failed search of a certain verse.");
                    return View("FindVerseFailure");
                }
            }
            catch(Exception e)
            {
                MyLogger.GetInstance().Error("Exception BibleController.FindVerse()", e.Message);
                string errMessage = e.Message; 
                return View("Error", errMessage); 
            }
        }

    }
}