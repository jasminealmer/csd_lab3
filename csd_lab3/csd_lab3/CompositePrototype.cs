using System;
using System.Collections.Generic;
using System.Text;

namespace csd_lab3
{
    class CompositePrototype : IPrototype
    {
        public IComponent Copy(string id, int layer)
        {
            IComponent leaf = new LeafBoard(layer + 1);
            IComponent composite = new CompositeBoard(leaf.Siblings, id, layer);
            return composite;
        }
    }
}
