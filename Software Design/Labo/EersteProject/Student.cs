using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EersteProject
{
    internal class Student : Person
    {
        public int inschrijvingsnummer;

        public Student(string name,  int inschrijvingsnummer) : base(name)
        {
            this.inschrijvingsnummer = inschrijvingsnummer;
        }

        public override string WelcomeMessage => "Hello " + this.Name + ", your student number is " + this.inschrijvingsnummer;
        public override void RandomFunction()
        {
            Console.WriteLine("You're not permitted");
        }
    }
}
