using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestandsSysteem.Model
{
    internal class FileSystemException : Exception
    {
        public FileSystemException(string ex) : base(ex)
        {
            Console.WriteLine(ex.ToString());
        }
        public override string ToString()
        {
            return Message;
        }
    }
}
