using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetV1
{
    public class Student : Person
    {
        public int Year { get; set; }
        public string StudentID { get; set; }
        public string ModePayment { get; set; }
        public bool Fees { get; set; }
        public Tutors StudentTutor {get;set;}
        
        

        public Student() { }
        public Student(string firstName, string name, DateTime dateBirth, int year)
            :base(firstName, name, dateBirth)
        {
            Year = year;
            StudentTutor = new Tutors();
        }


        public override string ToString()
        {
            return $"Status : Student     Year: {Year} \n {base.ToString()} \n {StudentTutor}";
        }

        public override string EmailAdress()
        {
            return $"{FirstName.ToLower()}.{Name.ToLower()}@student-vgc.ie";

        }
        
        public void FirstConnection()
        {
            Console.WriteLine("Please complete the informations");
            Console.WriteLine("Sexe > F or M");
            Sexe = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("EmailPerso");
            EmailPerso = Console.ReadLine();
            Console.WriteLine("Phone Number");
            PhoneNumber = Console.ReadLine();
            Console.WriteLine("Adress");
            Adress = Console.ReadLine();
            Console.WriteLine("Place of Birth");
            PlaceBirth = Console.ReadLine();
        }


        public void Informations()
        {
            ConsoleKeyInfo cki;
            Console.WriteLine("Your informations >");
            Console.WriteLine(ToString());
            Console.WriteLine($"Sexe : {Sexe}  Phone Number : {PhoneNumber}    Personal Email : {EmailPerso}\n " +
                $"Adress : {Adress}   Place of birth : {PlaceBirth} ");
            do
            {
                Console.WriteLine("Enter the number of the information you want to change");
                Console.WriteLine("0 : nothing\n" +
                    "1 : adress\n" +
                    "2 : personnal email\n" +
                    "3 : phone number\n" +
                    "4 : tutors");
                int nb = Convert.ToInt16(Console.ReadLine());

                switch (nb)
                {
                    case 0:
                        break;

                    case 1:
                        Console.WriteLine("Enter your new address");
                        Adress = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Enter your new email adress");
                        EmailPerso = Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("Enter your new phone number");
                        PhoneNumber = Console.ReadLine();
                        break;

                    case 4:
                        StudentTutor.Modification();
                        break;
                }
                cki = Console.ReadKey();
            }
            while (cki.Key != ConsoleKey.Escape);
        }
    }
}
