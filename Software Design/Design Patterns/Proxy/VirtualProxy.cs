using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class VirtualProxy : ISubject
    {
        ISubject? Subject;
        public VirtualProxy(ISubject? Subject = null) { if (Subject is not null) this.Subject = Subject; }
        public void Operation()
        {
            if (Subject is null)
            {
                Console.WriteLine("User triggered creation of expensive object.");
                this.Subject = new Subject();
            }
            else Console.WriteLine("Expensive object already exists.");
            Subject.Operation();
        }
    }
}
