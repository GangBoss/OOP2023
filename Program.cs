public class ServiceCollectionsSuperHero
{
    public class SuperHero
    {
        public string Name { get; }
        public static Lazy<SuperHero> Batman = new Lazy<SuperHero>(() => new SuperHero("BatMan"));
        public static Lazy<SuperHero> Superman = new Lazy<SuperHero>(new SuperHero("SuperMan"));

        private SuperHero(string name)
        {
            Name = name;
        }
    }

    public static void Main()
    {
        var b = SuperHero.Batman;
        var s = SuperHero.Superman;
    }
}
