using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTelefone
{
    internal class ContactList
    {
        Contact Head;
        Contact Tail;

        public ContactList()
        {
            Head = null;
            Tail = null;
        }

        //public void Add(Contact contact)
        //{
        //    if (IsEmpty())
        //        Head = Tail = contact;
        //    else
        //    {

        //        int compare = string.Compare(contact.GetName(), Head.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);
        //        if (compare <= 0)
        //        {
        //            Contact aux = Head;
        //            Head = contact;
        //            Head.SetNext(aux);
        //        }
        //        else
        //        {
        //            Contact aux = Head;
        //            Contact prev = Head;
        //            do
        //            {
        //                compare = string.Compare(contact.GetName(), aux.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);
        //                if (compare > 0)
        //                {
        //                    prev = aux;
        //                    aux = aux.GetNext();
        //                }
        //            } while (aux != null && compare > 0);
        //            prev.SetNext(contact);
        //            contact.SetNext(aux);
        //            if (aux == null)
        //                Tail = contact;
        //        }
        //    }
        //}
        //public void Print()
        //{
        //    if (IsEmpty())
        //        EmptyMessage();
        //    else
        //    {
        //        Contact aux = Head;
        //        do
        //        {
        //            aux.ContactToString();
        //            aux = aux.GetNext();
        //        } while (aux != Tail.GetNext());
        //    }
        //}
        //public void RemoveByName(string name)
        //{
        //    if (!IsEmpty())
        //    {
        //        Contact prev = Head;
        //        Contact aux = Head;
        //        int compare;
        //        do
        //        {
        //            compare = string.Compare(name, aux.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);
        //            if (compare == 0)
        //            {
        //                if (aux == Head)
        //                {
        //                    if (Head == Tail)
        //                        Head = Tail = null;
        //                    else
        //                        Head = aux.GetNext();
        //                }
        //                else
        //                {
        //                    prev.SetNext(aux.GetNext());
        //                    if (aux.GetNext() == null)
        //                        Tail = prev;
        //                }
        //            }
        //            else
        //            {
        //                prev = aux;
        //                aux = aux.GetNext();
        //            }
        //        } while (aux != null && compare != 0);
        //    }
        //}
        //public void FindName(string name)
        //{

        //    Contact aux = Head;
        //    int compare;
        //    do
        //    {
        //        compare = string.Compare(name, aux.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);
        //        if (compare == 0)
        //            aux.ContactToString();
        //        else
        //            aux = aux.GetNext();
        //    } while (aux != null && compare != 0);
        //    if (compare != 0)
        //        Console.WriteLine("Contato não encontrado!");
        //}
        //bool IsEmpty()
        //{
        //    if (Head == null && Tail == null)
        //        return true;
        //    else
        //        return false;
        //}
        //string EmptyMessage()
        //{
        //    return "Fila Vazia!";
        //}
    }
}
