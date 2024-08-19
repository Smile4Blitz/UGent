using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class ImplementationA : IBridge
    {
        private static readonly string Platform = "the new platform.";
        public string Operation() => "Welcome to " + Platform;
    }
}
