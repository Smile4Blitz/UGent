using DecoratorNamespace;

IDecorator DecoratorObj = new Component(); // Component
Console.WriteLine(DecoratorObj.Operation());

DecoratorObj = new Decorator1(DecoratorObj); // Decorator1(Component)
Console.WriteLine(DecoratorObj.Operation());

DecoratorObj = new Decorator2(DecoratorObj); // Decorator2(Decorator1(Component))
Console.WriteLine(DecoratorObj.Operation());