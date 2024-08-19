using Composite;
using System.ComponentModel;


// Add Information.dat file to /bin folder!

StreamReader reader = new("Information.dat");
Dictionary<string, IComponent<string>> compositeObj = [];
string? input;

do
{
    input = reader.ReadLine();
    if (input is not null)
    {
        string[] values = input.Split();
        if (values[0] == "AddComposite") { compositeObj.Add(values[1], new Composites<string>(values[1])); }
        else if (values[0] == "AddComponent" && compositeObj.TryGetValue(values[1], out IComponent<string>? value))
        {
            string Description = "";
            for (int i = 3; i < values.Length; i++) Description += (values[i]) + " ";
            var component = new Component<string>(values[2], Description);
            (value).Add(component);
        }
    }
} while (input != null);

foreach (var pair in compositeObj)
{
    var composite = pair.Value;
    composite.Print();
}