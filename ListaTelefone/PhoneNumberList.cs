using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefone
{
    internal class PhoneNumberList
    {
        Phone Head;
        Phone Tail;

        public PhoneNumberList()
        {
            Head = null;
            Tail = null;
        }
        public void Add(Phone phone)
        {
            if (IsEmpty())
                Head = Tail = phone;
            else
            {

                int compare = string.Compare(phone.GetPhone(), Head.GetPhone(), comparisonType: StringComparison.OrdinalIgnoreCase);
                if (compare <= 0)
                {
                    Phone aux = Head;
                    Head = phone;
                    Head.SetNext(aux);
                }
                else
                {
                    Phone aux = Head;
                    Phone prev = Head;
                    do
                    {
                        compare = string.Compare(phone.GetPhone(), aux.GetPhone(), comparisonType: StringComparison.OrdinalIgnoreCase);
                        if (compare > 0)
                        {
                            prev = aux;
                            aux = aux.GetNext();
                        }
                    } while (aux != null && compare > 0);
                    prev.SetNext(phone);
                    phone.SetNext(aux);
                    if (aux == null)
                        Tail = phone;
                }
            }
        }
        public void Print()
        {
            if (IsEmpty())
                EmptyMessage();
            else
            {
                Phone aux = Head;
                do
                {
                    Console.WriteLine(aux.ToString());
                    aux = aux.GetNext();
                } while (aux != Tail.GetNext());
            }
        }
        
        bool IsEmpty()
        {
            return Head == null && Tail == null;
        }
        string EmptyMessage()
        {
            return "Fila Vazia!";
        }
    }
}
