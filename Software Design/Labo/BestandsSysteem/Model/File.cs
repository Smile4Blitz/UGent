namespace BestandsSysteem.Model
{
    internal abstract class File
    {
        internal Folder? root = null;

        /* Momenteel heeft elke bestand een referentie naar zijn ouder, terwijl elke ouder een lijst heeft van zijn kinderen. 
         * Is deze dubbele referentie zinvol en kan je deze eventueel wegwerken? Waarom wel/niet?
         *
         *  m.a.w.: Momenteel een bidirectionele boom, is het aangeraden om een directionele boom te gebruiken?
         *  Ik denk dat het niet aangeraden is, we werken met een bestandsysteem, dit betekent we vaak omhoog of omlaag in de boom moeten kunnen;
         *  Alhoewel het mogelijk is om bv.: adhv een PathName telkens de boom af te dalen (root -> .. -> .. -> target), is dit niet erg efficient
        */
        internal Folder? parent;
        internal string Name
        {
            get;
        }
        internal bool IsRoot
        {
            get
            {
                if (this.root == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        internal string? PathName
        {
            get;
        }
        public abstract string ListName
        {
            get;
        }
        internal File(string? Name)
        {
            if (Name == null || Name.Contains('/'))
            {
                throw new FileSystemException("Name is null or contains illegal character.");
            }
            else
            {
                this.Name = Name;
            }
        }
    }
}
