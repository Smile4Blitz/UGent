using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweights
{
    internal struct Flyweight : IFlyweight
    {
        public readonly string Name => "Intrinsic";
        public Flyweight() { }
        public readonly string Load() => "Extrinsic";
    }
}
