using System.Text;

namespace CoderingClassLibrary
{
    public class Blok : Codeer
    {
        private static readonly char[,] codingReference = { { 'a', 'z', 'e', 'r', 't', '1' }, { '2', 'y', 'u', 'i', 'o', 'p' }, { 'q', '3', 's', '4', '8', 'd' }, { 'f', 'g', 'h', 'n', 'j', 'k' }, { '9', '7', 'l', 'm', '6', 'w' }, { '5', '0', 'x', 'c', 'v', 'b' } };
        private readonly Dictionary<char, int[]> AvailableChars = [];
        public Blok(string input) : base(input)
        {
            AddCodingCharsToDictionary();
            if (input != null) EncodedMsg = Encode(input);
            else throw new Exception("Couldn't encode using: Blok");
        }
        override protected string Encode(string input)
        {
            StringBuilder sb = new();

            foreach (char c in input)
            {
                if (sb.Length > 1 && (sb.Length + 1) % 3 == 0)
                {
                    char first = sb[^2];
                    char second = sb[^1];

                    if (!first.Equals(second) && AvailableChars.TryGetValue(first, out int[]? p1) && AvailableChars.TryGetValue(second, out int[]? p2))
                    {
                        // swap if same row or column
                        if (p1[0] == p2[0] || p1[1] == p2[1])
                        {
                            sb[^2] = second;
                            sb[^1] = first;
                        }
                        else
                        {
                            sb[^1] = codingReference[p2[0], p1[1]];
                            sb[^2] = codingReference[p1[0], p2[1]];
                        }
                    }

                    //sb.Append(' '); // group by 2
                }
                if (c >= 'A' && c <= 'Z') sb.Append(char.ToLower(c)); // to lower case
                else if (!char.IsLetter(c)) sb.Append('0'); // replace foreign char
                else sb.Append(c);
            }

            EncodedMsg = sb.ToString();

            return sb.ToString();
        }
        private void AddCodingCharsToDictionary()
        {
            for (int i = 0; i < codingReference.GetLength(0); i++)
            {
                for (int j = 0; j < codingReference.GetLength(1); j++)
                {
                    int[] index = [i, j];
                    AvailableChars.Add(codingReference[i, j], index);
                }
            }
        }
    }
}
