using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderingClassLibrary
{
    abstract public class Codeer
    {
        public string OriginalMsg
        {
            get;
        }
        public string EncodedMsg
        {
            get;
            set;
        }
        public Codeer(string input)
        {
            OriginalMsg = input;
        }
        protected abstract string Encode(string input);
    }
}
