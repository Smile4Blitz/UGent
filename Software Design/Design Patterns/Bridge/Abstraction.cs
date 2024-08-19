using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Abstraction
    {
        protected IBridge Platform;
        public Abstraction(IBridge bridge) => this.Platform = bridge;
        public void Operation() => Console.WriteLine("Abstraction: " + Platform.Operation());
    }
}
