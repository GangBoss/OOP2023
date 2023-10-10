
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.MapObjects
{

    public abstract class MapObject
    {
        public abstract void Interact(Player player);
    }
    
    public interface IOwner
    {
        int Owner { get; set; }
    }

    public interface IArmy
    {
        Army Army { get; }
    }

    public interface ITreasure
    {
        Treasure Treasure { get; set; }
    }
    public class Dwelling : MapObject, IOwner
    {
        public int Owner { get; set; }

        public override void Interact(Player player)
        {
            Owner = player.Id;
        }
    }

    public class Mine : MapObject, IOwner, ITreasure, IArmy
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public override void Interact(Player player)
        {
            if (!player.CanBeat(Army))
            {
                player.Die();
            }
            else
            {
                player.Consume(Treasure);
                Owner = player.Id;
            }
        }
    }

    public class Creeps : MapObject, IArmy, ITreasure
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public override void Interact(Player player)
        {
            if (player.CanBeat(Army))
            {
                player.Consume(Treasure);
            }
        }
    }

    public class Wolves : MapObject, IArmy
    {
        public Army Army { get; set; }

        public override void Interact(Player player)
        {
            if (!player.CanBeat(Army))
            {
                player.Die();
            }
        }
    }

    public class ResourcePile : MapObject, ITreasure
    {
        public Treasure Treasure { get; set; }

        public override void Interact(Player player)
        {
            player.Consume(Treasure);
        }
    }
    public static class Interaction //Взаимодействие
    {
        public static void Make(Player player, MapObject mapObject)
        {
            mapObject.Interact(player);
        }

    }
}


