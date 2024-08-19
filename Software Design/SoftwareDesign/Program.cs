// See https://aka.ms/new-console-template for more information

using SoftwareDesign;

Person p = new Student("John Doe", 20180189);
string output = p.WelcomeMessage;
Console.WriteLine(output);

var classType = p.GetType();
if (classType == typeof(Student) || classType == typeof(Person))
{
    Console.WriteLine("Type of " + classType.Name.ToString());
}
else
{
    Console.WriteLine("Not Person & not student");
}

return 0;