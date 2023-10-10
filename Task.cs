using System.Collections.Generic;

namespace Inheritance.MapObjects
{
    public interface IPlayerInteraction
    {
        void InteractWith(Player player);
    }

    public class AbstractMapObject
    {
        public IReadOnlyList<IPlayerInteraction> Interactions { get; }
        public AbstractMapObject(params IPlayerInteraction[] interactions)
        {
            Interactions = interactions;
        }

        public void InteractWith(Player player)
        {
            foreach (var trait in Interactions)
            {
                if (player.Dead) 
                    break;
                trait.InteractWith(player);
            }
        }
    }

    public class Dwelling : AbstractMapObject
    {
        public Dwelling() : base(new Ownable())
        {
        }
    }

    public class Ownable : IPlayerInteraction
    {
        public int Owner { get; private set; } = -1;
        public void InteractWith(Player player)
        {
            Owner = player.Id;
        }
    }

    public class Combatable : IPlayerInteraction
    {
        public Army Army { get; set; }

        public Combatable(Army army)
        {
            Army = army;
        }

        public void InteractWith(Player player)
        {
            if (!player.CanBeat(Army))
                player.Die();
        }
    }

    public class Collectable : IPlayerInteraction
    {
        public Treasure Treasure { get; set; }

        public Collectable(Treasure treasure)
        {
            Treasure = treasure;
        }

        public void InteractWith(Player player)
        {
            player.Consume(Treasure);
        }
    }

    public class Creeps : AbstractMapObject
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public Creeps(Army army, Treasure treasure) : base(new Combatable(army), new Collectable(treasure))
        {
        }
    }

    public class Mine : AbstractMapObject
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public Mine(Army army, Treasure treasure) : base(new Combatable(army), new Ownable(), new Collectable(treasure))
        {
        }
    }


    public class Wolves : AbstractMapObject
    {
        public Army Army { get; set; }

        public Wolves(Army army) : base(new Combatable(army))
        {
            Army = army;
        }
    }

    public class ResourcePile : AbstractMapObject
    {
        public Treasure Treasure { get; set; }
        public ResourcePile(Treasure treasure)
        {
            Treasure = treasure;
        }
    }
}
