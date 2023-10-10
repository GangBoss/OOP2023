using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOMM.Objects
{
    public interface IInteractable<TInteractor>
    {
        public void Interact(TInteractor consumer);
    }
}
