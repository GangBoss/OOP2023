using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes
{
    public enum SuperHeroNames
    {
        Batman,
        Superman
    }
    public class SuperHero
    {
        public SuperHeroNames Name { get; }
        private static SuperHero? superman;
        private static SuperHero? batman;

        public static SuperHero CreateorGetSuperHero(SuperHeroNames name)
        {
            if (name == SuperHeroNames.Superman)
            {
                return superman ?? new SuperHero(SuperHeroNames.Superman);
            }
            return batman ?? new SuperHero(SuperHeroNames.Batman);
        }

        private SuperHero(SuperHeroNames name)
        {
            Name = name;
            if (name == SuperHeroNames.Superman)
            {
                superman = this;
            }
            else
            {
                batman = this;
            }
        }

    }
}
