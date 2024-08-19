using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoderingClassLibrary;

namespace CLICodering
{
    internal class CodeerOption
    {
        public string OriginalMsg
        {
            get;
        }
        public Codeer EncodedMsg
        {
            get;
        }

        public CodeerOption(string OrignalMsg, string TypeOfEncoding)
        {
            this.OriginalMsg = OrignalMsg;
            if (TypeOfEncoding.Equals("Blok"))
            {
                this.EncodedMsg = new Blok(this.OriginalMsg);
            }
            else if (TypeOfEncoding.Equals("Wissel"))
            {
                this.EncodedMsg = new Wissel(this.OriginalMsg);
            }
            else if (TypeOfEncoding.Equals("Cijfer"))
            {
                this.EncodedMsg = new Cijfer(this.OriginalMsg);
            } else
            {
                throw new Exception($"Not a valid encoding type: {TypeOfEncoding}");
            }
        }

        public CodeerOption(FileStream input, FileStream output) 
        {
            
        }
    }
}
