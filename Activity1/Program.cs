namespace Activity1
{
    class Program
    {
        public static void Main(string[] args)
        {

        }
    }

    public class Superhero
    {
        public string Name { get; }
        private static Superhero batman;
        private static Superhero superman;

        private Superhero(string name)
        {
            Name = name;
        }

        public static Superhero CreateOrGetSuperhero(string name)
        {
            if (name == "Batman")
            {
                if (batman == null)
                    batman = new Superhero("Batman");
                return batman;
            }
            else if (name == "Superman")
            {
                if (superman == null)
                    superman = new Superhero("Superman");
                return superman;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
