using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign
{
    internal class Student : Person
    {
        private readonly int studentnr;
        public Student(string name, int studentnr) : base(name)
        {
            this.studentnr = studentnr;
        }
        public override string WelcomeMessage
        {
            get { return this.name + ", your student number is " + this.studentnr; }
        }
    }
}
