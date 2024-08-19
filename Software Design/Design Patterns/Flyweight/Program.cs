using Flyweights;
using System.Threading.Channels;

FlyweightFactory Flyweights = new();
Flyweight flyweight = new();

Flyweights.Add("First", flyweight);
flyweight = new();
Flyweights.Add("Second", flyweight);
flyweight = new();
Flyweights.Add("Third", flyweight);

foreach (var component in Flyweights.Flyweights)
{
    Console.WriteLine("Flyweight: " + component.Key);
    Console.WriteLine("Intrinsic: " + (component.Value).Name);
    Console.WriteLine("Extrinsic: " + (component.Value).Load());
    Console.WriteLine();
}