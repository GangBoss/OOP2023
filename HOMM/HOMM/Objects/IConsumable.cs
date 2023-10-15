﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOMM.Objects
{
    public interface IConsumable<T> : IInteractable<T>
    {
        public int Value { get; set; }
    }

    public class Treasure : IConsumable<ICollector>
    {
        public int Value { get; set; }

        public void Interact(ICollector collector)
        {
            collector.Collect(Value);
            Value = 0;
        }
    }
}
