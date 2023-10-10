using HOMM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOMM
{
    public interface IInteractor
    {
    }

    public interface ICollector : IInteractor
    {
        public int Value { get; set; }
        void Collect(int value);
    }

    public interface IFighter : IInteractor
    {
        int Strength { get; set; }
        bool IsAlive { get; set; }
        void Die();
        bool CanBeat(IBeatable enemy);
    }

    public interface IOwner : IInteractor
    {
    }

    public interface IPlayer : ICollector, IFighter, IOwner
    {
        void Interact(IInteractable<IInteractor> interactObj);
    }

    public class Player : IPlayer
    {
        public int Value { get; set; }
        public int Strength { get; set; }
        public bool IsAlive { get; set; }

        public bool CanBeat(IBeatable enemy)
        {
            return enemy.Strength <= Strength;
        }

        public void Collect(int value)
        {
            Value += value;
        }

        public void Die()
        {
            IsAlive = false;
        }

        public void Interact(IInteractable<IInteractor> interactObj)
        {
            interactObj.Interact(this);
        }
    }
}
