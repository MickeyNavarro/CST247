using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyInjectionDemo
{
    class Grenade : IWeapon
    {
        public string WeaponName { get; set; }

        public Grenade(string weaponName)
        {
            WeaponName = weaponName;
        }

        public void AttackWithMe()
        {
            Console.WriteLine(WeaponName + " sizzles for a moment and then explodes into a shower of deadly fragments."); 
        }
    }
}
