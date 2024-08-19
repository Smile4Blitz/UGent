using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BestandsSysteem.Model
{
    internal class Folder : File
    {
        /* Is het zinvol om de HashSet te vervangen door een Dictionary? Waarom wel/niet?
         * Ja, aangezien onze input parameters telkens een string: naam bevat, zou het beter zijn om een dictionary<string, File> te gebruiken 
         * die adhv de naam onmiddelijk de overeenkomende File kan ophalen
        */
        internal HashSet<File> files = [];
        public Folder(string name) : base(name)
        {
        }
        public override string ListName => this.Name + '/';

        // Allow use of 'this[name]' to execute 'GetFile(string)' function, ex.: this["filename.txt"] or this[VarContainingFileName]
        public File? this[string name] => GetFile(name);
        private File? GetFile(string name)
        {
            foreach (File file in files)
            {
                if (file.ListName.Equals(name)) return file;
            }
            return null;
        }
        public File CreateTextFile(string name)
        {
            if (name.Equals("")) throw new FileSystemException("Lege naam niet toegelaten");

            File? file = this[name];
            if (file is not null) throw new FileSystemException("Map bevat al bestand met naam '" + name + "'");

            TextFile NewFile = new(name);
            NewFile.parent = this;
            if (this.IsRoot)
            {
                NewFile.root = this;
            }
            else
            {
                NewFile.root = this.root;
            }

            files.Add(NewFile);
            return NewFile;
        }
        public File CreateFolder(string name)
        {
            if (name.Equals("")) throw new FileSystemException("Lege naam niet toegelaten");

            File? file = this[name];
            if (file is not null) throw new FileSystemException("Map bevat al bestand met naam '" + name + "'");

            Folder NewFolder = new(name);
            NewFolder.parent = this;

            if (this.IsRoot)
            {
                NewFolder.root = this;
            }
            else
            {
                NewFolder.root = this.root;
            }

            files.Add(NewFolder);
            return NewFolder;
        }
        public void PrintList()
        {
            StringBuilder sb = new();
            foreach (File file in files)
            {
                sb.AppendLine(file.ListName);
            }
            Console.WriteLine(sb.ToString());
        }
        public void PrintTree(string indent = "  ")
        {
            if (this.IsRoot)
            {
                Console.WriteLine('/');
            }
            else
            {
                Console.WriteLine(this.ListName);
            }

            foreach (File file in files)
            {
                if (file is Folder folder)
                {
                    PrintSubFolder(folder, indent);
                }
                else
                {
                    Console.WriteLine(indent + file.ListName);
                }
            }
        }
        private static void PrintSubFolder(Folder f, string indent)
        {
            Console.WriteLine(indent + f.ListName);
            indent += "  ";
            foreach (File file in f.files)
            {
                if (file is Folder folder)
                {
                    PrintSubFolder(folder, indent);
                }
                else
                {
                    Console.WriteLine(indent + file.ListName);
                }
            }
        }
    }
}