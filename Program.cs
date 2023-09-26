public class ServiceCollectionsSuperHero
{
    public class SuperHero
    {
        public string Name { get; }

        private static SuperHero? _batman;
        private static SuperHero? _superman;


        private SuperHero(string name)
        {
            Name = name;
        }

        public static SuperHero GetSuperMan()
        {
            if (_superman == null)
            {
                _superman = new SuperHero("SuperMan");
            }
            
            return _superman;
        }

        public static SuperHero GetBatman()
        {
            if (_batman == null)
            {
                _batman = new SuperHero("BatMan");
            }

            return _batman;
        }
    }
}
