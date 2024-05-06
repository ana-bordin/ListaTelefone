using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefone
{
    internal class Contact
    {
        string Name;
        string Phone;
        Contact Next;

        public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;
            Next = null;
        }

        public string GetName()
        {
            return Name;
        }
        public void SetNext(Contact nextContact)
        {
            Next = nextContact;
        }
        public Contact GetNext()
        {
            return Next;
        }
    }
}
