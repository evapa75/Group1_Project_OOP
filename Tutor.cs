using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class Tutor
    {
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string EmailAddress { get; set; }
        public string Relationship { get; set; }


        public Tutor() { }
        public Tutor(string firstName, string name, string phoneNumber, string address, string emailAdress, string relationship)
        {
            FirstName = firstName;
            Name = name;
            PhoneNumber = phoneNumber;
            Adress = address;
            EmailAddress = emailAdress;
            Relationship = relationship;
        }

        public override string ToString()
        {
            return $"{FirstName} {Name}  Relationship : {Relationship}    Contacts : {PhoneNumber}    {Adress}   {EmailAddress}";
        }


        public void Modification()
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine("Enter the number of the information you want to change");
                Console.WriteLine("0 : First Name\n" +
                    "1 : Name\n" +
                    "2 : Relationship\n" +
                    "3 : Phone number\n" +
                    "4 : Adress\n" +
                    "5 : Email Adress");
                int nb = Convert.ToInt16(Console.ReadLine());

                switch (nb)
                {
                    case 0:
                        Console.WriteLine("Enter the new first name");
                        FirstName = Console.ReadLine();
                        break;

                    case 1:
                        Console.WriteLine("Enter the new name");
                        Name = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Enter a new relationship");
                        Relationship = Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Enter the new phone number");
                        PhoneNumber = Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("Enter the new adress");
                        Adress = Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine("Enter the new email address");
                        EmailAddress = Console.ReadLine();
                        break;
                }
                cki = Console.ReadKey();
            }
            while (cki.Key != ConsoleKey.Escape);
        }
    }
}
