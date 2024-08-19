using System.Text;

namespace CoderingClassLibrary
{
    public class Wissel : Codeer
    {
        public Wissel(string input) : base(input)
        {
            if (input != null) EncodedMsg = Encode(input);
            else throw new Exception("Couldn't encode using: Wissel");
        }

        override protected string Encode(string input)
        {
            StringBuilder sb = new();
            if (input.Length % 2 != 0) input += '0';
            for (int i = 0; i < input.Length; i += 2) sb.Append(input[i + 1]).Append(input[i]);
            
            EncodedMsg = sb.ToString();
            
            return sb.ToString();
        }
    }
}
