namespace Superhero;

public enum Heroes
{
    Superman,
    Batman
}

public class Superhero
{
    // Создайте класс Superhero с одним свойством Name. Сделайте так, чтобы у этого класса могло быть не более двух
    // экземпляров: Супермен и Бэтмен. При этом создавались эти экземпляры только по мере первой необходимости.
    // В частности, если понадобился только бэтмен, то экземпляр супермена не должен создаваться.
    public readonly string Name;
    private static readonly Dictionary<Heroes, int> HeroesExisting = new();

    private Superhero(string name) => Name = name;

    public static Superhero? Create(Heroes type)
    {
        HeroesExisting.TryAdd(type, 0);
        if (HeroesExisting[type] >= 1)
            return null;
        HeroesExisting[type]++;
        return new Superhero(type.ToString());
    }
}