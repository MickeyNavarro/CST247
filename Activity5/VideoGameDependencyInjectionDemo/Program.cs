using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace VideoGameDependencyInjectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //a container is a list of items that can be used as parameters in my hero class
            UnityContainer container = new UnityContainer();
            container.RegisterType<IWeapon, Grenade>(new InjectionConstructor("Ball of Fire"));
            container.RegisterType<IHero, HeroThatCanUseAnyWeapon>(new InjectionConstructor("Bomber", typeof(IWeapon)));

            var hero5 = container.Resolve<IHero>();

            hero5.Attack();

            Console.WriteLine(); 

            //embedded depedency
            HeroThatOnlyUsesSwords hero1 = new HeroThatOnlyUsesSwords("Ultraman");
            hero1.Attack();
            Console.WriteLine();

            //injected dependency
            HeroThatCanUseAnyWeapon hero2 = new HeroThatCanUseAnyWeapon("SuperGreatWoman", new Grenade("Pineapple"));
            hero2.Attack();
            Console.WriteLine();

            HeroThatCanUseAnyWeapon hero3 = new HeroThatCanUseAnyWeapon("SwordSwinger", new Sword("Brissinger"));
            hero3.Attack();
            Console.WriteLine();

            HeroThatCanUseAnyWeapon hero4 = new HeroThatCanUseAnyWeapon("GI Joe", new Gun("Six Shooter", new List<Bullet> { new Bullet("silver", 10), new Bullet("lead", 20), new Bullet("dead point", 3), new Bullet("Hollow Point", 5)}));
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();
            hero4.Attack();

            Console.WriteLine(); 

            Console.ReadLine(); 
        }
    }
}
