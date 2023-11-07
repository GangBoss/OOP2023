using System;

namespace Inheritance.MapObjects
{
    public interface IOwnable
    {
        int Owner { get; set; }
    }

    public interface IBeatable
    {
        Army Army { get; set; }
    }

    public interface ILootable
    {
        Treasure Treasure { get; set; }
    }

    public interface IVisitor
    {
        void Visit(Dwelling dwelling);
        void Visit(Mine mine);
        void Visit(Creeps creeps);
        void Visit(Wolves wolves);
        void Visit(ResourcePile resourcePile);
    }

    public interface IInteractable
    {
        void Accept(IVisitor visitor);
    }

    public class Dwelling : IOwnable, IInteractable
    {
        public int Owner { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Mine : IOwnable, IBeatable, ILootable, IInteractable
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Creeps : IBeatable, ILootable, IInteractable
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Wolves : IBeatable, IInteractable
    {
        public Army Army { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ResourcePile : ILootable, IInteractable
    {
        public Treasure Treasure { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public static class Interaction
    {
        public static void Visit(IBeatable interactable, Player player)
        {
            if (!player.CanBeat(interactable.Army))
            {
                player.Die();
            }
        }

        public static void Visit(ILootable interactable, Player player)
        {
            player.Consume(interactable.Treasure);
        }

        public static void Visit(IOwnable interactable, Player player)
        {
            interactable.Owner = player.Id;
        }

        public static void Make(Player player, IInteractable interactable)
        {
            interactable.Accept(new InteractionVisitor(player));
        }
    }

    public class InteractionVisitor : IVisitor
    {
        private readonly Player player;

        public InteractionVisitor(Player player)
        {
            this.player = player;
        }

        public void Visit(Dwelling dwelling)
        {
            Interaction.Visit(dwelling, player);
        }

        public void Visit(Mine mine)
        {
            Interaction.Visit((ILootable) mine, player);
        }

        public void Visit(Creeps creeps)
        {
            Interaction.Visit((IBeatable) creeps, player);
        }

        public void Visit(Wolves wolves)
        {
            Interaction.Visit(wolves, player);
        }

        public void Visit(ResourcePile resourcePile)
        {
            Interaction.Visit(resourcePile, player);
        }
    }
}