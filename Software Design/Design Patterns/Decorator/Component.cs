using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorNamespace
{
    internal class Component : IDecorator
    {
        string Name { get; set; }
        public Component() => this.Name = "Component";
        public string Operation() => this.Name;
    }
}
