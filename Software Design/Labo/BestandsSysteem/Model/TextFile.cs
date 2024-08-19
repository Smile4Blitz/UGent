using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestandsSysteem.Model
{
    internal class TextFile : File
    {
        public string Text;
        public TextFile(string FileName, string Text = "") : base(FileName)
        { 
            this.Text = Text;
        }
        public override string ListName
        {
            get
            {
                return this.Name;
            }
        }
    }
}
