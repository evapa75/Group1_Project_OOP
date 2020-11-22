using System;
using System.Collections.Generic;
using System.Text;

namespace Group1_OOP
{
    public class Student : Person
    {
        public double Fees { get; set; }
        public int Year { get; set; }
        public string StudentID { get; set; }
        public bool FeesOK { get; set; }
        public string ModePayment { get; set; }
        public Tutor StudentTutor {get;set;}
        List<Course> CoursesList { get; set; }
        List<Course> Timetable { get; set; }
        List<Professor> ProfessorsList { get; set; } //Récupère au fur et à mesure les noms des profs après qie l'emploi du temps soit crée
        


        public Student(string firstName, string name, DateTime dateBirth, int year)
            :base(firstName, name, dateBirth)
        {
            Fees = 3500;
            Year = year;
            StudentTutor = new Tutor();
        }

        public Student(string firstName, string name, char sex, DateTime dateBirth, int year, string persoEmailAdress, string phoneNumber, string adress, string password, /*Professor tutor*/double fees)
            : base(firstName, name, sex, dateBirth, persoEmailAdress, phoneNumber, adress, password)
        {

            Year = year;
            //Tutor = tutor;
            Fees = fees;
        }


        public override string ToString()
        {
            return $"Status : Student     Year : {Year} \n {base.ToString()} \n  {StudentTutor}";
        }

        public void AddStudent(List<Student> studentsList)
        {
            Student student = new Student(this.FirstName, this.Name, this.BirthDate, this.Year);
            studentsList.Add(student);
        }

        public override string EmailAdress()
        {
            return $"{FirstName.ToLower()}.{Name.ToLower()}@student-vgc.ie";

        }

        public void FirstConnection()
        {
            Console.WriteLine("Please complete the informations");
            Console.WriteLine("Sex > F or M");
            Sex = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("EmailPerso");
            EmailPerso = Console.ReadLine();
            Console.WriteLine("Phone Number");
            PhoneNumber = Console.ReadLine();
            Console.WriteLine("Adress");
            Adress = Console.ReadLine();
            Console.WriteLine("Place of Birth");
            PlaceBirth = Console.ReadLine();
            Console.WriteLine("Choose your mode of payment");
            Console.WriteLine("OS : one-shot transfer");
            Console.WriteLine("MO : monthly transfer");
            ModePayment = Console.ReadLine();
        }


        /*
        public void Informations()
        {
            ConsoleKeyInfo cki;
            Console.WriteLine("Your informations >");
            Console.WriteLine(ToString());
            Console.WriteLine($"Sex : {Sex}  Phone Number : {PhoneNumber}    Personal Email : {EmailPerso}\n " +
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
        */

        public void ShowAndModifyPersonalInformation()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                Console.WriteLine($"Student Profile {FirstName} { Name.ToUpper()} \n\n");
                Console.WriteLine("Personal identifying information : \n\n" +
                    FirstName + " " + Name.ToUpper() +
                    $"\nID : {ID}" +
                    $"\nSex : {Sex}" +
                    $"\nBirthdate : {BirthDate}\n\n");
                Console.WriteLine("Contact information : \n\n" +
                    $"Adress : {Adress}" +
                    $"\nPhone Number : {PhoneNumber}" +
                    $"\nSchool email adress : {EmailSchool}" +
                    $"\nPersonnal email adress : {EmailPerso}\n\n\n");


                Console.WriteLine("Do you want to modify some of your information? ");
                Console.WriteLine("0 - Nothing\n" +
                    "1 - Adress\n" +
                    "2 - Phone number\n" +
                    "3 - Personal email adress\n");
                int nb = Convert.ToInt32(Console.ReadLine());

                switch (nb)
                {
                    case 0:
                        finish = true;
                        break;

                    case 1:
                        Console.WriteLine("\nEnter your new address");
                        Adress = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("\nEnter your new phone number");
                        PhoneNumber = Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("\nEnter your new personal email adress");
                        EmailPerso = Console.ReadLine();
                        break;
                }
            }
        }


        public bool PaymentVerification() //A TERMINER
        {
            bool payment = false;
            if(ModePayment == "OS")
            {
                if(Fees == 0)
                {
                    payment = true;
                }
            }
            else if (ModePayment == "MO")
            {
                double FeesMonth = Fees / 8;
                //Imposer une date, pour cette date à chaque mois, vérifier si c'est à 0 ou pas puis insérer dans une list les paiments
            }
            return payment;
        }


    }
}
