using System.Collections.Generic;

namespace Inheritance.MapObjects
{
    public interface IInteractable
    {
        public void Interact(Player player);
    }
    
    public abstract class Treasure : IInteractable
    {
        public int Amount { get; private set; }
        
        public void Interact(Player player)
        {
            player.Consume(this);
        }
    }

    public abstract class Building : IInteractable
    {
        public bool HasOwner { get; private set; }

        public void Interact(Player player)
        {
            if (HasOwner)
                return;
            player.Obtain(this);
            HasOwner = true;
        }
    }
    
    public abstract class Army : IInteractable
    {
        public int Power { get; private set; }
        
        public void Interact(Player player)
        {
            if(player.CanBeat(this))
                player.Die();
        }
    }
    
    public class Map
    {
        private List<IInteractable> _objects = new();
        private Player _player;
            
        public void InteractAllObjects()
        {
            foreach(var obj in _objects)
                obj.Interact(_player);
        }
    }
}