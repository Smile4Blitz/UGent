using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BestandsSysteem.Model
{
    internal class FileSystem
    {
        Folder CurrentFolder;
        readonly Folder Root;
        public FileSystem()
        {
            Folder root = new("root");
            this.Root = root;
            CurrentFolder = root;
        }
#pragma warning disable IDE1006 // Naming Styles
        public void cd(string path)
        {
            try
            {
                if (path.Equals("/"))
                {
                    CurrentFolder = Root;
                }
                else if (path.Equals("..") && CurrentFolder.parent != null)
                {
                    CurrentFolder = CurrentFolder.parent;
                }
                else if (path.Contains('/') && path.Length > 1)
                {
                    throw new FileSystemException("Can't have '/' in path.");
                }
                else if (path.Equals("..") && CurrentFolder.parent == null)
                {
                    throw new FileSystemException("No parent folder.");
                }
                else
                {
                    bool failed = true;
                    foreach (File f in CurrentFolder.files)
                    {
                        if (f is Folder folder && f.Name.Equals(path))
                        {
                            CurrentFolder = folder;
                            failed = false;
                            break;
                        }
                    }
                    if (failed) throw new FileSystemException("Ongeldig pad");
                }
            } catch {}
        }
        public void pwd()
        {
            if (CurrentFolder.parent is not null)
            {
                StringBuilder sb = new();
                Folder folder = CurrentFolder;
                while (folder.parent is not null)
                {
                    sb.Insert(0, folder.ListName);
                    folder = folder.parent;
                }
                Console.WriteLine(sb.ToString());
            }
            else Console.WriteLine("/");
        }
        public void dir()
        {
            foreach (File file in CurrentFolder.files)
            {
                Console.WriteLine(file.ListName);
            }
        }
        public void tree()
        {
            CurrentFolder.PrintTree();
        }
        public void mktext(string naam)
        {
            try
            {
                CurrentFolder.CreateTextFile(naam);
            } catch { }
        }
        public void mkdir(string naam)
        {
            try
            {
                CurrentFolder.CreateFolder(naam);
            }
            catch {}
        }
#pragma warning restore IDE1006 // Naming Styles
    }
}
