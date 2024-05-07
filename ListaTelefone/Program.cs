using System;

namespace ListaTelefone
{
    internal class Program
    {
        static ContactList list = new ContactList();
        static void Menu()
        {
            Console.WriteLine("Digite a opção desejada:\n" +
                "1 - Adicionar Contato;\n" +
                "2 - Editar Contato;\n" +
                "3 - Listar Contatos;\n" +
                "4 - Deletar Contato;\n" +
                "0 - Sair;");
        }
        static Contact CreateContact()
        {
            string name, zipCode, city, state, typePatio, streetAvenue, neighborhood, complement, email;
            int number, opcao = 0;
            PhoneNumberList phoneNumbers = new PhoneNumberList();

            Console.WriteLine("Digite o nome do contato:");
            name = Console.ReadLine();

            Console.WriteLine("Digite o número de telefone");

            do
            {
                Phone phone = new Phone(Console.ReadLine());
                Console.WriteLine("Digite 0 se deseja adicionar mais um número:");
                phoneNumbers.Add(phone);
                opcao = int.Parse(Console.ReadLine());
            } while (opcao == 0);

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
            Address address = new Address(zipCode, city, state, typePatio, streetAvenue, neighborhood, number, complement);

            Console.WriteLine("Digite o E-mail:");
            email = Console.ReadLine();

            Contact contact = new Contact(name, phoneNumbers, address, email);
            return contact;
        }
        static void Choice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("ADICIONAR CONTATO:");
                    list.Add(CreateContact());
                    break;
                case 2:

                    break;
                case 3:
                    Console.WriteLine("1 - Listar todos Contatos;\n" +
                        "2 - Mostrar só um contato;\n" +
                        "0 - Voltar");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            list.Print();
                            break;
                        case 2:
                            Console.WriteLine("Digite o nome:");
                            list.FindName(Console.ReadLine());
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
                    list.RemoveByName(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Digite uma opção válida!");
                    break;
            }

        }
        static void Main(string[] args)
        {
            int op = 0;
            do
            {
                Menu();
                op = int.Parse(Console.ReadLine());
                Choice(op);
            } while (op == 0);



        }
    }
}
