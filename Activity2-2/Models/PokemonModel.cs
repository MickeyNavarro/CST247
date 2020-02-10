using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity2_2.Models
{
    public class PokemonModel
    {
        public int Evolve { get; set; }

        public PokemonModel(int evolve)
        {
            Evolve = evolve;
        }
    }
}