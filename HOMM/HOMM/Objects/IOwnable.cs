using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOMM.Objects
{
    public interface IOwnable : IInteractable<IOwner>
    {
        IPlayer? Owner { get; set; }
    }

    public class House : IOwnable
    {
        public IPlayer? Owner { get; set; }

        public void Interact(IOwner owner)
        {
            Owner = owner;
        }
    }
}
