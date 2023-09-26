public class SuperHero
{
    private static SuperHero? _superMan;
    private static SuperHero? _batman;
    
    public string Name { get; }

    public SuperHero(string name)
    {
        Name = name;
    }

    public SuperHero GetOrCreateSuperMan()
    {
        if (_superMan == null)
            _superMan = new SuperHero("SuperMan");
        return _superMan;
    }

    public SuperHero GetOrCreateBatman()
    {
        if (_batman == null)
            _batman = new SuperHero("Batman");
        return _batman;
    }
}