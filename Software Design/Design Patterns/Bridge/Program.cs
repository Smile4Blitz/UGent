using Bridge;

Console.WriteLine("Choosing platform.");
Abstraction AbstractionObj = new(new ImplementationA());
AbstractionObj.Operation();

Console.WriteLine("Changing platform.");
AbstractionObj = new Abstraction(new ImplementationB());
AbstractionObj.Operation();