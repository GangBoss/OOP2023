namespace Superhero
{
    public class Program
    {
        public static void Main()
        {
            var batman1 = Superhero.Create(Heroes.Batman);
            var batman2 = Superhero.Create(Heroes.Batman);
            var superman1 = Superhero.Create(Heroes.Superman);
            var superman2 = Superhero.Create(Heroes.Superman);
            Console.WriteLine(batman2 is null);
            Console.WriteLine(superman2 is null);
        }
    }
}