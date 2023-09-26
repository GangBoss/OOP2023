using System;

namespace HeroSolution
{
    public enum Hero
    {
        Superman,
        Batman
    }

    public class Superhero
    {
        private static Dictionary<Hero, int> _countHeroes = new();

        public string Name { get; private set; }

        private Superhero(string name)
        {
            Name = name;
        }

        public static Superhero? CreateInstance(Hero hero)
        {
            _countHeroes.TryAdd(hero, 0);
            if (_countHeroes[hero] >= 1)
                return null;
            _countHeroes[hero]++;
            return new Superhero(hero.ToString());
        }
    }

    class Program
    {
        public static void Main()
        {
            var superman = Superhero.CreateInstance(Hero.Superman);
            Console.WriteLine(superman?.Name);
            var batman = Superhero.CreateInstance(Hero.Batman);
            Console.WriteLine(batman?.Name);
            var secondSuperman = Superhero.CreateInstance(Hero.Superman);
            Console.WriteLine(secondSuperman is null);
            var secondBatman = Superhero.CreateInstance(Hero.Batman);
            Console.WriteLine(secondBatman is null);
        }
    }
}