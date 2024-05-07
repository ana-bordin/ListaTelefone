using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListaTelefone
{
    internal class Contact
    {
        string Name;
        PhoneNumberList PhoneList;
        Address Address;
        string Email;

        Contact Next;

        public Contact(string name, PhoneNumberList phone, Address address, string email)
        {
            Name = name;
            PhoneList = phone; 
            Address = address;
            Email = email;
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
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetAddress(Address address)
        {
            Address = address;
        }     
        public void SetEmail(string email)
        {
            Email = email;
        }
        public void ContactToString()
        {
            Console.WriteLine($"Nome:\n {Name};");
            Console.WriteLine($"Telefones:");
            PhoneList.Print();
            Console.WriteLine($"{Address.ToString()}");
            Console.WriteLine($"Email:\n{Email};");
        }
    }
}
