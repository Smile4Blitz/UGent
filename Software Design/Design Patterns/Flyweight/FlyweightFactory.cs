using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweights
{
    internal class FlyweightFactory
    {
        public Dictionary<string, Flyweight> Flyweights;
        public FlyweightFactory() { Flyweights = []; }
        public bool Add(string Name, Flyweight Flyweight) => Flyweights.TryAdd(Name, Flyweight);
    }
}
