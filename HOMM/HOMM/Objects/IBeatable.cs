using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOMM.Objects
{
    public interface IBeatable : IInteractable<IFighter>
    {
        public int Strength { get; set; }
    }

    public class Wolf : IBeatable
    {
        public int Strength { get; set; }

        public void Interact(IFighter fighter)
        {
            if (!fighter.CanBeat(this))
                fighter.Die();
        }
    }
}
