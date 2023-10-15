using HOMM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOMM.CombinedObjects
{
    public interface IFighterAndConsumer : IFighter, ICollector
    { }

    public interface IMine : IBeatable<IFighterAndConsumer>, IConsumable<IFighterAndConsumer> { }

    public class Mine : IMine
    {
        public int Value { get; set; }
        public int Strength { get; set; }

        public void Interact(IFighterAndConsumer consumer)
        {
            if (!consumer.CanBeat(this))
            {
                consumer.Die();
                return;
            }

            consumer.Collect(Value);
            Value = 0;
        }
    }
}
