using Activity2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2_2.Controllers
{
    public class PokemonController : Controller
    {
        // GET: PokemonModel
        public ActionResult Index()
        {
            PokemonModel squirtle = new PokemonModel(1);

            return View("Pokemon", squirtle);
        }
        
        public ActionResult HandleButtonClick(string evolve)
        {
            //parse the string
            int e = Int32.Parse(evolve); 

            //create a new instance of a pokemon
            PokemonModel poke = new PokemonModel(1);

            //check if the evolution is at 1 or 2 
            if (e == 1 || e == 2)
            {
                //if yes, increase the evolution by 1
                poke.Evolve = e + 1;
            } 
         
            //return the pokemon to the view
            return View("Pokemon", poke);

        }
    }
}