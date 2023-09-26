using System;

namespace ConsoleApp5
{
    class Program
    {
        public static bool IsSuperman = false;
        public static bool IsBatman = false;

        public class Superhero
        {
            private string name;
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    if (value == "Супермен" && IsSuperman == false)
                    {
                        name = value;
                        IsSuperman = true;
                    }
                    else if (value == "Бэтмен" && IsBatman == false)
                    {
                        name = value;
                        IsBatman = true;
                    }
                    else
                    {
                        name = "Это не true-супергерой или это супергерой-позер";
                    }
                }
            }

            public Superhero(string name)
            {
                Name = name;
            }

        }

        static void Main(string[] args)
        {
            var batman = new Superhero("Бэтмен");
            var superman = new Superhero("Супермен");
            var batman2 = new Superhero("Супермен");
            Console.WriteLine(batman.Name);
            Console.WriteLine(superman.Name);
            Console.WriteLine(batman2.Name);

        }

    }
}
