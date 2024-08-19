using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorNamespace
{
    internal class Decorator2 : Decorators
    {
        public Decorator2(IDecorator encapsulate) : base(encapsulate) => this.Name = "Decorator2";
        public override string Operation()
        {
            string encapsuledValues = Encapsuled.Operation();
            return this.Name + '(' + encapsuledValues + ')';
        }
    }
}
