using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krohalev_1
{


    public enum SuperheroType
    {
        superman,
        batman
    }
    public class Superhero
    {
        public readonly string Name;

        private static Dictionary<SuperheroType, int> superheroes = new Dictionary<SuperheroType, int>();

        private Superhero(string name )
        {
            this.Name=name;
        }
        public static Superhero CreateSuperhero(SuperheroType superheroType)
        {
            if (superheroes.ContainsKey(superheroType))
            {
                if (superheroes[superheroType] >= 1)
                    return null;
            }
            else
            {
                superheroes.Add(superheroType, 1);
            }

            //superheroes[superheroType]++;
            return new Superhero(superheroType.ToString());



        }
    }

}
