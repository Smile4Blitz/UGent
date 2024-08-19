using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Subject : ISubject
    {
        public void Operation() => Console.WriteLine("Very expensive operation.");
    }
}
