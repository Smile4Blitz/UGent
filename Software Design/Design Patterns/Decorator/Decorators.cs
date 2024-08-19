using DecoratorNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Abstract class is not mandatory

namespace DecoratorNamespace
{
    internal abstract class Decorators : IDecorator
    {
        protected IDecorator Encapsuled;
        internal string? Name { get; set; }
        public Decorators(IDecorator Encapsulate) => this.Encapsuled = Encapsulate;
        public abstract string Operation();
    }
}
