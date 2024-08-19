using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EersteProject
{
    internal abstract class Person
    {
        public readonly string Name;
        public Person(string name)
        {
            this.Name = name;
        }
        public virtual string WelcomeMessage
        {
            get
            {
                return "Hello " + this.Name;
            }
        }
        public abstract void RandomFunction();
    }
}
