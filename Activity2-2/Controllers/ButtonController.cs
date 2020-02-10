using Activity2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2_2.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random random = new Random(); 

        // GET: Button
        public ActionResult Index()
        {
            //loop to add 25 buttons of random states
            for(int i =0; i<25; i++)
            {
                if (random.Next(10) > 5)
                { 
                    buttons.Add(new ButtonModel(true)); 
                }
                else
                {
                    buttons.Add(new ButtonModel(false));
                }
            }

            return View("Button", buttons);
        }

        public ActionResult HandleButtonClick (string mine)
        {
            //get which button has been clicked
            int buttonNumber = Int32.Parse(mine);

            //change the state of the button 
            buttons[buttonNumber].State = !buttons[buttonNumber].State; 
            return View("Button", buttons);

        }
    }
}