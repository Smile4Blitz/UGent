using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Composites<T> : IComponent<T>
    {
        List<IComponent<T>> Components;
        public string Name { get; set; }
        public string? Description { get; set; }
        public Composites(string Name) { this.Components = []; this.Name = Name; }
        public void Add(IComponent<T> component) => Components.Add(component);
        public void Clear() => Components = [];
        public void Print() { foreach (IComponent<T> _ in Components) { _.Print(); } }
        public void Remove(IComponent<T> component) => Components.Remove(component);
    }
}
