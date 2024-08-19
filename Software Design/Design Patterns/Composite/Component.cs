using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Component<T> : IComponent<T>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Component(string Name, string Description) { this.Name = Name; this.Description = Description; }
        public void Add(IComponent<T> component) { }
        public void Clear() { }
        public void Print() => Console.WriteLine($"Name: {this.Name} \nDescription: {this.Description}");
        public void Remove(IComponent<T> component) { }
    }
}
