using Inheritance.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.MapObjects
{
    public interface IArmy
    {
        Army Army { get; set; }
    }

    public interface IOwnership
    {
        int Owner { get; set; }
    }

    public interface ITreasure
    {
        Treasure Treasure { get; set; }
    }
    public class MapObject
    {
        public List<IInteractionObject> Interactions { get; set; }
        public void Interact(Player player)
        {
            foreach (var interaction in Interactions)
            {
                interaction.Interact(player);
            }
        }
    }

    public interface IInteractionObject
    {
        void Interact(Player player);
    }

    public class ArmyObj: IInteractionObject
    {
        private IArmy MapObject { get; }
        public void Interact(Player player)
        {
            if (!player.CanBeat(MapObject.Army))
                player.Die();
        }
        public ArmyObj(IArmy mapObj)
        {
            MapObject = mapObj;
        }
    }

    public class OwnershipObj: IInteractionObject
    {
        private IOwnership MapObject { get; }
        public void Interact(Player player)
        {
            if (!player.Dead)
            MapObject.Owner = player.Id;
        }
        public OwnershipObj(IOwnership mapObject)
        {
            MapObject = mapObject;
        }
    }


    public class TreasureObj : IInteractionObject
    {
        private ITreasure MapObject { get; }
        public void Interact(Player player) 
        {
            if (!player.Dead) 
                player.Consume(MapObject.Treasure);
        }
        public TreasureObj(ITreasure mapObject)
        {
            MapObject = mapObject;
        }
    }

    public class Dwelling: MapObject, IOwnership
    {
        public int Owner { get; set; }
        public Dwelling()
        {
            Interactions = new List<IInteractionObject>() { new OwnershipObj(this)};
        }
    }

    public class Mine: MapObject, IOwnership, IArmy, ITreasure
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
        public Mine()
        {
            Interactions = new List<IInteractionObject>() {new ArmyObj(this), new OwnershipObj(this), new TreasureObj(this) };
        }
    }

    public class Creeps : MapObject, ITreasure, IArmy
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
        public Creeps()
        {
            Interactions = new List<IInteractionObject>() { new ArmyObj(this), new TreasureObj(this) };
        }
    }

    public class Wolves : MapObject, IArmy
    {
        public Army Army { get; set; }
        public Wolves()
        {
            Interactions = new List<IInteractionObject>() { new ArmyObj(this)};
        }
    }

    public class ResourcePile : MapObject, ITreasure
    {
        public Treasure Treasure { get; set; }
        public ResourcePile()
        {
            Interactions = new List<IInteractionObject>() {new TreasureObj(this) };
        }
    }

    public static class Interaction
    {
        public static void Make(Player player, object mapObject)
        {
            if (mapObject is MapObject obj)
            {
                obj.Interact(player);
            }
        }
    }
}