namespace VideoGameDependencyInjectionDemo
{
    internal class Sword : IWeapon
    {
        public string SwordName { get; set; }

        public Sword(string swordName)
        {
            SwordName = swordName;
        }

        public void AttackWithMe()
        {
            System.Console.WriteLine(SwordName + " slices through the air, devestating all enemies."); 
        }
    }
}