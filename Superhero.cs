class Superhero
{
    private string Name { get; set; }

    private static Superhero instanceBatman;
    private static Superhero instanceSuperman;

    public Superhero(string name)
    {
        Name = name;
    }

    public static Superhero GetOrCreateHero(SuperHero hero)
    {
        return hero switch
        {
            SuperHero.Batman => instanceSuperman ??= new Superhero(hero.ToString()),
            SuperHero.SuperMan => instanceBatman ??= new Superhero(hero.ToString())
        };
    }

}
enum SuperHero
{
    Batman,
    SuperMan
}