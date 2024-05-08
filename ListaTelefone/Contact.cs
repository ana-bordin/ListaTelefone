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
        List<Phone> Phones = new();
        Address Address;
        string Email;

        public Contact(string name, List<Phone> phones, Address address, string email)
        {
            Name = name;
            Phones = phones; 
            Address = address;
            Email = email;
        }

        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }        
        public void SetPhone(List<Phone> phones)
        {
            Phones = phones;
        }        
        public void SetAddress(Address address)
        {
            Address = address;
        }     
        public void SetEmail(string email)
        {
            Email = email;
        }
        public override string ToString()
        {
            return Name + ";" + PhoneNumbers() + ";" + Address.ToString() + ";" + Email;
        }

        public string PhoneNumbers() 
        {
            string listPhone = null;
            foreach (Phone item in Phones)
            {
                listPhone += item.ToString() + ",";
            }
            return listPhone;
        }
    }
}
