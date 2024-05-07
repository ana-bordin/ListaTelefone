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
        Phone Next;

        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            Next = null;
        }

        public string GetPhone() 
        {
            return PhoneNumber;
        }
        public Phone GetNext()
        {
            return Next;
        }
        public void SetNext(Phone phoneAux)
        {
            Next = phoneAux;
        }

        public override string ToString()
        {
            return $"{PhoneNumber}";
        }
    }
}
