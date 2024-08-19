using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class AuthenticationProxy : ISubject
    {
        ISubject? Subject;
        readonly Dictionary<string, string> UserBase = new()
        {
            {"arno","BobIsGay!" },
            {"bob", "BobIsGay!" },
            {"silke","BobIsGay!" }
        };
        public AuthenticationProxy(ISubject? Subject) { if (Subject is not null) this.Subject = Subject; }
        public void Operation()
        {
            Console.Write("username: ");
            string name = Console.ReadLine();
            name = name.ToLower();
            if (UserBase.ContainsKey(name))
            {
                Console.Write("password: ");
                string password = Console.ReadLine();
                if (password == UserBase[name])
                {
                    Console.WriteLine("Authentication successful.");
                    Subject ??= new Subject();
                    Subject.Operation();
                }
                else Console.WriteLine("Invalid password.");
            }
            else Console.WriteLine("Invalid username.");
        }
    }
}
