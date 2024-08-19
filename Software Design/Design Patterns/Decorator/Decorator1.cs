using DecoratorNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorNamespace
{
    internal class Decorator1 : Decorators
    {
        public Decorator1(IDecorator Encapsulate) : base(Encapsulate) => this.Name = "Decorator1";
        public override string Operation()
        {
            string encapsuledValues = Encapsuled.Operation();
            return this.Name + '(' + encapsuledValues + ')';
        }
    }
}
