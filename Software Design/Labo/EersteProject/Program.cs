using EersteProject;

/*
 * Only applicable when Person class wasn't abstract
string? name = null;
while (name is null)
{
    Console.WriteLine("What's your name? ");
    name = Console.ReadLine();
}

Person person = new(name);
Console.WriteLine(person.WelcomeMessage);
*/

Person p = new Student("John Doe", 20180189);
string output = p.WelcomeMessage;
Console.WriteLine(output);

Console.Write("Type of class: ");
string ClassName = p.GetType().Name;
if (p is Student or Person)
{
    Console.WriteLine(ClassName);
    if (p is Student)
    {
        p.RandomFunction();
    }
}
else
{
    Console.Write("Unknown");
}