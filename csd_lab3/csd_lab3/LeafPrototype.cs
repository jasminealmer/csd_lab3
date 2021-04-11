using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class LeafPrototype : IPrototype
    {
        public IComponent Copy(string id, int layer)
        {
            IComponent component = new LeafBoard(id, layer);
            return component;
        }
    }
}
