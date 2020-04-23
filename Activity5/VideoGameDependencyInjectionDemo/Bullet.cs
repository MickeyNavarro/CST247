namespace VideoGameDependencyInjectionDemo
{
    public class Bullet
    {
        public string Name { get; set; }
        public int GramsOfPowder { get; set; }

        public Bullet(string name, int gramsOfPowder)
        {
            Name = name;
            GramsOfPowder = gramsOfPowder;
        }
    }
}