using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefone
{
    internal class Phone
    {
        string PhoneNumber;

        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string GetPhone() 
        {
            return PhoneNumber;
        }
        public override string ToString()
        {
            return $"{PhoneNumber}";
        }
    }
}
