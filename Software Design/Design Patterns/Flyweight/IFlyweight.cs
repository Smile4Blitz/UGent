using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweights
{
    internal interface IFlyweight
    {
        public string Name { get; }
        string Load();
    }
}
