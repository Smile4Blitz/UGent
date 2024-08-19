using CLICodering;
using CoderingClassLibrary;

int encodingOption = 0;
do
{
    Console.Write("Do you want to encode a sentence or a file?\n1. Sentence\n2. File\nOption nr.: ");
    encodingOption = Console.ReadLine();
} while (encodingOption < 1 || encodingOption > 2);

int TypeOfEncodingOption;
do
{
    Console.Write("What encoding type do you want to use?\n1. Blok\n2. Wissel\n3. Cijfer\nOption nr.: ");
    TypeOfEncodingOption = Console.Read();
} while (TypeOfEncodingOption < 1 || TypeOfEncodingOption > 3);

string TypeOfEncoding;
if (TypeOfEncodingOption == 1) TypeOfEncoding = "Blok";
else if (TypeOfEncodingOption == 2) TypeOfEncoding = "Wissel";
else TypeOfEncoding = "Cijfer";

if (encodingOption == 1)
{
    string? InputSentence;
    do
    {
        Console.WriteLine("Enter a sentence: ");
        InputSentence = Console.ReadLine();
    } while (InputSentence is null || InputSentence.Equals(""));

    CodeerOption codeerZin = new CodeerOption(InputSentence, TypeOfEncoding);
    Console.WriteLine($"Encoded: {codeerZin.EncodedMsg}");
}
else
{
    string? FileInput;
    string? FileOutput;
    do
    {
        Console.Write("Geef bestandsnaam voor invoer: ");
        FileInput = Console.ReadLine();
        Console.Write("Geef bestandsnaam voor uitvoer: ");
        FileOutput = Console.ReadLine();
    } while (FileInput is null || FileOutput is null);

    FileStream InputStream = new FileStream(FileInput, FileMode.Open, FileAccess.Read);
    FileStream OutputStream = new FileStream(FileOutput, FileMode.OpenOrCreate, FileAccess.Write);

    CodeerOption codeerBestand = new CodeerOption(InputStream, OutputStream);

}
