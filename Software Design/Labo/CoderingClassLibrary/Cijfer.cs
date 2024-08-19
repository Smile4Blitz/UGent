using System.Text;

namespace CoderingClassLibrary
{
    public class Cijfer : Codeer
    {
        public Cijfer(string input) : base(input)
        {
            if (input != null) EncodedMsg = Encode(input);
            else throw new Exception("Couldn't encode using: Cijfer");
        }
        override protected string Encode(string input)
        {
            StringBuilder sb = new();
            foreach (char c in input) sb.Append((int)c);

            EncodedMsg = sb.ToString();

            return sb.ToString();
        }
    }
}
