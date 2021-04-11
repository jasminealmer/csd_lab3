using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    interface IPrototype
    {
        public IComponent Copy(string id, int layer);
    }
}
