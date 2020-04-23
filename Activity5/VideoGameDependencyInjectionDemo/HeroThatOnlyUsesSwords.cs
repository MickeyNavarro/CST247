using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyInjectionDemo
{
    class HeroThatOnlyUsesSwords : IHero
    {
        public string Name { get; set; }

        public HeroThatOnlyUsesSwords(string name)
        {
            Name = name;
        }

        public void Attack()
        {
            //incorrect example - do not create a new instance of one class in another 
            Sword sword = new Sword("Excaliur");
            Console.WriteLine(Name + " prepares themself for battle.");
            sword.AttackWithMe(); 
        }


    }
}
