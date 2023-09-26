var batman = SuperHero.CreateOrGetExisted(HeroName.Batman);
var superman = SuperHero.CreateOrGetExisted(HeroName.Superman);

var newBatman = SuperHero.CreateOrGetExisted(HeroName.Batman);
var newSuperman = SuperHero.CreateOrGetExisted(HeroName.Superman);

Console.WriteLine(batman == newBatman);
Console.WriteLine(superman == newSuperman);
Console.WriteLine(superman == batman);

public class SuperHero
{
  private static SuperHero batman = null;
  private static SuperHero superMan = null;

  public static SuperHero CreateOrGetExisted(HeroName Name)
  {
    if (Name == HeroName.Batman)
    {
      batman ??= new SuperHero(Name.ToString());
      return batman;
    }

    superMan ??= new SuperHero(Name.ToString());
    return superMan;
  }

  private readonly string Name;
  private SuperHero(string Name)
  {
    this.Name = Name;
  }
}

public enum HeroName
{
  Batman,
  Superman,
}
