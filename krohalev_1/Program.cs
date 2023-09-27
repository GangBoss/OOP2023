using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krohalev_1
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            var b1 =  Superhero.CreateSuperhero( SuperheroType.batman);
            var b2 = Superhero.CreateSuperhero(SuperheroType.batman);
            var s1 = Superhero.CreateSuperhero(SuperheroType.superman);
            var s2 = Superhero.CreateSuperhero(SuperheroType.superman);

            Console.WriteLine("Второго бетмена не существет:   {0}", b2 is null);
            Console.WriteLine("Второго супермена не существет: {0}", s2 is null);

            Console.ReadKey();
            



        }
    }
}
