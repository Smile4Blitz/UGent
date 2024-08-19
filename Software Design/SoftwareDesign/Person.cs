using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign
{
    internal abstract class Person
    {
        protected readonly string name;
        public Person(string name)
        {
            this.name = name;
        }
        abstract public string WelcomeMessage { get; }
    }
}
