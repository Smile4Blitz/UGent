using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal interface IComponent<T>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public void Add(IComponent<T> component);
        public void Remove(IComponent<T> component);
        public void Print();
        public void Clear();
    }
}
