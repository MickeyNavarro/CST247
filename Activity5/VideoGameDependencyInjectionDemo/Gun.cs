using System.Collections.Generic;

namespace VideoGameDependencyInjectionDemo
{
    internal class Gun : IWeapon
    {
        private string WeaponName { get; set; }
        public List<Bullet> Bullets { get; set; }
        public Gun(string weaponName, List<Bullet> bullets)
        {
            this.WeaponName = weaponName;
            this.Bullets = bullets; 
        }

        public void AttackWithMe()
        {
            if (Bullets.Count > 0)
            {
                System.Console.WriteLine(WeaponName + " fires a round called " + Bullets[0].Name + ". The victim now has a deadly hole in them.");
                Bullets.RemoveAt(0);
            }
            else
            {
                System.Console.WriteLine("The gun has no bullets. Nothing happens."); 
            }
        }
    }
}