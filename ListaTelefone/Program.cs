using System;
using System.Data;
using System.IO;
using System.Reflection.Emit;

namespace ListaTelefone
{
    internal class Program
    {
        static string path = @"C:\Dados\";
        static string file = "telephoneList.txt";
        static List<Contact> list = new List<Contact>();
        static void Menu()
        {
            Console.WriteLine("Digite a opção desejada:\n" +
                "1 - Adicionar Contato;\n" +
                "2 - Editar Contato;\n" +
                "3 - Listar Contatos;\n" +
                "4 - Deletar Contato;\n" +
                "0 - Sair;");
        }
        static List<Phone> CreateListPhones()
        {
            List<Phone> phones = new();
            int op = 0;
            Console.WriteLine("Digite o número de telefone");
            do
            {
                phones.Add(new Phone(Console.ReadLine()));
                Console.WriteLine("Digite 0 se deseja adicionar mais um número:");
                op = int.Parse(Console.ReadLine());
            } while (op == 0);
            return phones;
        }
        static Address CreateAddress()
        {
            string zipCode, city, state, typePatio, streetAvenue, neighborhood, complement;
            int number;
            Console.WriteLine("Digite o CEP:");
            zipCode = Console.ReadLine();
            Console.WriteLine("Digite a cidade:");
            city = Console.ReadLine();
            Console.WriteLine("Digite o Estado:");
            state = Console.ReadLine();
            Console.WriteLine("Digite o tipo de Logradouro:");
            typePatio = Console.ReadLine();
            Console.WriteLine("Digite o Logradouro:");
            streetAvenue = Console.ReadLine();
            Console.WriteLine("Digite o Bairro:");
            neighborhood = Console.ReadLine();
            Console.WriteLine("Digite o número:");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Complemento:");
            complement = Console.ReadLine();

            return new Address(zipCode, city, state, typePatio, streetAvenue, neighborhood, number, complement);
        }
        static Contact CreateContact()
        {
            string name, email;
            int opcao = 0;
            List<Phone> phones = new();

            Console.WriteLine("Digite o nome do contato:");
            name = Console.ReadLine();
            phones = CreateListPhones();
            Address address = CreateAddress();

            Console.WriteLine("Digite o E-mail:");
            email = Console.ReadLine();

            Contact contact = new Contact(name, phones, address, email);
            return contact;
        }
        static void Choice(int choice)
        {
            Contact contact = null;
            switch (choice)
            {
                case 1:
                    list = LoadFile(path, file);
                    Console.WriteLine("ADICIONAR CONTATO:");
                    list.Add(CreateContact());
                    SaveFile(list, path, file);
                    break;
                case 2:

                    Console.WriteLine("EDITAR CONTATO:");
                    Console.WriteLine("Digite o nome do contato:");
                    contact = FindByName(Console.ReadLine());
                    list = LoadFile(path, file);

                    if (contact != null)
                    {
                        Console.WriteLine(contact.ToString());
                        Console.WriteLine("Escolha o número correspondente ao campo que deseja editar:\n" +
                            "1 - Nome \n" +
                            "2 - Número de telefone \n" +
                            "3 - Endereço\n" +
                            "4 - E-mail");
                        int editOp = int.Parse(Console.ReadLine());
                        RemoveByName(contact.GetName());
                        switch (editOp)
                        {
                            case 1:
                                Console.WriteLine("Digite o novo nome:");
                                contact.SetName(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Digite novos números:");
                                contact.SetPhone(CreateListPhones());
                                break;
                            case 3:
                                Console.WriteLine("Digite um novo endereço:");
                                contact.SetAddress(CreateAddress());
                                break;
                            case 4:
                                Console.WriteLine("Digite o novo e-mail:");
                                contact.SetEmail(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Opção inválida.");
                                break;
                        }
                        list.Add(contact);
                        SaveFile(list, path, file);
                        Console.WriteLine("Contato atualizado com sucesso!");
                    }

                    else
                        Console.WriteLine("Contato não encontrado!");

                    break;
                case 3:
                    Console.WriteLine("1 - Listar todos Contatos;\n" +
                        "2 - Mostrar só um contato;\n" +
                        "0 - Voltar");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            List();
                            break;
                        case 2:
                            Console.WriteLine("Digite o nome:");
                            contact = FindByName(Console.ReadLine());
                            if (contact != null)
                                Console.WriteLine(contact.ToString());
                            else
                                Console.WriteLine("Contato não encontrado!");
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Digite uma opção válida!");
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("Digite o nome da pessoa que quer apagar:");
                    RemoveByName(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Digite uma opção válida!");
                    break;
            }

        }
        static void CheckIfExists(string p, string f)
        {
            if (!Directory.Exists(p))
                Directory.CreateDirectory(p);
            if (!File.Exists(p + f))
                File.Create(p + f);
        }
        static Contact FindByName(string name)
        {
            Contact contact = null;
            foreach (string line in File.ReadLines(path + file))
            {
                if (line.Contains(name))
                    contact = GetContact(line);
            }
            return contact;
        }
        static void List()
        {
            foreach (string line in File.ReadLines(path + file))
                Console.WriteLine(GetContact(line).ToString());
        }
        static Contact GetContact(string line)
        {
            string[] data = line.Split(";");
            string Name = data[0];
            string phone = data[1];
            string[] arrayPhones = phone.Split(",");
            List<Phone> listPhones = new List<Phone>();
            foreach (string item in arrayPhones)
            {
                if (item != "")
                    listPhones.Add(new Phone(item));
            }

            string address = data[2];
            string[] arrayAddres = address.Split(",");
            string Email = data[3];
            return new Contact(data[0], listPhones, new Address(arrayAddres[0], arrayAddres[1], arrayAddres[2], arrayAddres[3], arrayAddres[4], arrayAddres[5], int.Parse(arrayAddres[6]), arrayAddres[7]), data[3]);
        }
        static List<Contact> LoadFile(string p, string f)
        {
            List<Contact> l = new List<Contact>();
            foreach (var line in File.ReadAllLines(p + f))
                l.Add(GetContact(line));
            return l;
        }
        static void SaveFile(List<Contact> l, string p, string f)
        {
            StreamWriter sw = new StreamWriter(p + f);
            foreach (Contact item in l)
                sw.WriteLine(item.ToString());
            sw.Close();
        }
        static void RemoveByName(string name)
        {
            //Contact contact = FindByName(name);
            List<Contact> l = LoadFile(path, file);
            l.Remove()
            SaveFile(l, path, file);
        }
        static void Main(string[] args)
        {
            CheckIfExists(path, file);
            int op = 0;
            do
            {
                Menu();
                op = int.Parse(Console.ReadLine());
                Choice(op);
            } while (op != 0);
        }
    }
}
