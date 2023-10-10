namespace Inheritance.MapObjects
{
    public interface IInteractable
    {
        void Interact(Player player);
    }

    public interface IOwned
    {
        int Owner { get; set; }
    }

    public interface IArmy
    {
        Army Army { get; set; }
    }

    public interface ITreasure
    {
        Treasure Treasure { get; set; }
    }

    public class Dwelling : IOwned, IInteractable
    {
        public int Owner { get; set; }

        public void Interact(Player player)
        {
            Owner = player.Id;
        }
    }

    public class Mine : IArmy, ITreasure, IOwned, IInteractable
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void Interact(Player player)
        {
            Owner = player.Id;
        }
    }

    public class Creeps : IArmy, ITreasure, IInteractable
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void Interact(Player player)
        {
            player.Fight(Army);
            player.Consume(Treasure);
        }
    }

    public class Wolves : IArmy, IInteractable
    {
        public Army Army { get; set; }

        public void Interact(Player player)
        {
            player.Fight(Army);
        }
    }

    public class ResourcePile : ITreasure, IInteractable
    {
        public Treasure Treasure { get; set; }

        public void Interact(Player player)
        {
            player.Consume(Treasure);
        }
    }
}
