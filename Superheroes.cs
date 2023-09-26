public class Superhero
{
    private static Superhero superman;
    private static Superhero batman;

    public string Name { get; private set; }

    private Superhero(string name)
    {
        Name = name;
    }

    public static Superhero GetSuperman()
    {
        if (superman == null)
        {
            superman = new Superhero("Superman");
        }
        return superman;
    }

    public static Superhero GetBatman()
    {
        if (batman == null)
        {
            batman = new Superhero("Batman");
        }
        return batman;
    }
}
