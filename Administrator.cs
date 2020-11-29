using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Group1_OOP
{
    public class Administrator : Person
    {
        public Administrator(string id, string firstName, string name, string gender, string birthdate, string persoEmailAdress, string phoneNumber, string adress, string password)
            : base(id, firstName, name, gender, birthdate, persoEmailAdress, phoneNumber, adress, password)
        {

        }

        public override string ToString()
        {
            return $"Status : Administrator \n{base.ToString()} ";
        }

        public override string SchoolEmailAdress()
        {
            return ID + "@admin.faculty-vgc.ie";
        }

        public void ShowAndModifyPersonalInformation()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                Console.WriteLine($"Administrator Profile {FirstName} { Name.ToUpper()} \n\n");
                Console.WriteLine("Personal identifying information : \n\n" +
                    FirstName + " " + Name.ToUpper() +
                    $"\nID : {ID}" +
                    $"\nGender : {Gender}" +
                    $"\nBirthdate : {Birthdate.ToShortDateString()}\n\n");
                Console.WriteLine("Contact information : \n\n" +
                    $"Adress : {Adress}" +
                    $"\nPhone Number : {PhoneNumber}" +
                    $"\nSchool email adress : {SchoolEmail}" +
                    $"\nPersonnal email adress : {PersoEmail}\n\n\n");


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
                        PersoEmail = Console.ReadLine();
                        break;
                }
            }
        }

        public void FeesModification(List<Student> studentList)
        {
            Console.WriteLine("Do you want to change the fees for one student or all the student ?");
            Console.WriteLine("1 : 1 student");
            Console.WriteLine("2 : all the student");
            //si possible, juste une année
            int nb = Convert.ToInt16(Console.ReadLine());
            if (nb == 1)
            {
                Console.WriteLine("Enter the first name of the student");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter the last name of the student");
                string lastName = Console.ReadLine();
                foreach (Student student in studentList)
                {
                    if (student.Name == lastName && student.FirstName == firstName)
                    {
                        Console.WriteLine("Fees of the student : " + student.Fees);
                        Console.WriteLine("New fees :");
                        student.Fees = Convert.ToDouble(Console.ReadLine());
                    }
                }
            }
            else if (nb == 2)
            {
                Console.WriteLine("New fees :");
                double fees = Convert.ToDouble(Console.ReadLine());
                foreach (Student student in studentList)
                {
                    student.Fees = fees;
                }
            }
            else
            {
                Console.WriteLine("Aucune modification apportée");
            }
        }
    }
}
