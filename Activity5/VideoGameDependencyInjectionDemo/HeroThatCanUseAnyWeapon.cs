using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyInjectionDemo
{
    class HeroThatCanUseAnyWeapon : IHero
    {
        public string Name { get; set; }

        public IWeapon MyWeapon { get; set; }

        public HeroThatCanUseAnyWeapon(string name, IWeapon weapon)
        {
            Name = name;
            MyWeapon = weapon; 
        }

        public void Attack()
        {
            Console.WriteLine(Name + " prepares to attack.");
            MyWeapon.AttackWithMe(); 
             
        }
    }
}
