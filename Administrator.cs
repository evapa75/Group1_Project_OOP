using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Group1_OOP
{
    public class Administrator : Person
    {
        public List<Student> AllStudents { get; set; }
        public List<Professor> AllProfessors { get; set; }

        public Administrator(string id, string firstName, string name, string gender, string birthdate, string persoEmailAdress, string phoneNumber, string adress, string password, List<Student> allStudents, List<Professor> allProfessors)
            : base(id, firstName, name, gender, birthdate, persoEmailAdress, phoneNumber, adress, password)
        {
            AllStudents = allStudents;
            AllProfessors = allProfessors;
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


        public void AddStudent() //A FAIRE
        {

        }

        public void AddProfesseur() //A TERMINER => cas de l'id, du mot de passe, subject, tutor, et 4 classes 
        {
            bool complete = false;
            string firstName = "";
            string name = "";
            char sex = ' ';
            DateTime birthdate = new DateTime();
            string personalEmailAdress = "";
            string phoneNumber = "";
            string adress = "";

            while (complete == false)
            {
                Console.Clear();
                Console.WriteLine("Let's complete the registration of a new teacher. \n\nPlease complete the following informations about this teacher:");

                Console.WriteLine(" \nFirst Name :");
                firstName = Console.ReadLine();

                Console.WriteLine(" \nName :");
                name = Console.ReadLine();

                Console.WriteLine(" \nSex : F or M");
                sex = Convert.ToChar(Console.ReadLine());

                Console.WriteLine(" \nBirthdate : ");
                Console.Write("Day : ");
                int day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Month : (number, example: February -> 2) ");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Year : ");
                int year = Convert.ToInt32(Console.ReadLine());
                birthdate = new DateTime(year, month, day);

                Console.WriteLine(" \nPersonal email adress :");
                personalEmailAdress = Console.ReadLine();

                Console.WriteLine(" \nTelephone number :");
                phoneNumber = Console.ReadLine();

                Console.WriteLine(" \nAdress (street number, street, postal code, city) :");
                adress = Console.ReadLine();

                if (firstName != null && name != null && sex != null && day != 0 && month != 0 && year != 0 && personalEmailAdress != null && phoneNumber != null && adress != null)
                {
                    complete = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Your form is incomplete. Please, complete it again");
                    System.Threading.Thread.Sleep(3000);
                }
            }
            Console.Clear();
            Console.WriteLine("The form is complete.");

        }

        public void AddAministrator()//A VERIFIER => cas de l'id et du mot de passe
        {
            bool complete = false;
            string firstName = "";
            string name = "";
            char sex = ' ';
            DateTime birthdate = new DateTime();
            string personalEmailAdress = "";
            string phoneNumber = "";
            string adress = "";

            while (complete == false)
            {
                Console.Clear();
                Console.WriteLine("Let's complete the registration of a new admin. \n\nPlease complete the following informations :");

                Console.WriteLine(" \nFirst Name :");
                firstName = Console.ReadLine();

                Console.WriteLine(" \nName :");
                name = Console.ReadLine();

                Console.WriteLine(" \nSex : F or M");
                sex = Convert.ToChar(Console.ReadLine());

                Console.WriteLine(" \nBirthdate : ");
                Console.Write("Day : ");
                int day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Month : (number, example: February -> 2) ");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Year : ");
                int year = Convert.ToInt32(Console.ReadLine());
                birthdate = new DateTime(year, month, day);

                Console.WriteLine(" \nPersonal email adress :");
                personalEmailAdress = Console.ReadLine();

                Console.WriteLine(" \nTelephone number :");
                phoneNumber = Console.ReadLine();

                Console.WriteLine(" \nAdress (street number, street, postal code, city) :");
                adress = Console.ReadLine();

                if (firstName != null && name != null && sex != null && day != 0 && month != 0 && year != 0 && personalEmailAdress != null && phoneNumber != null && adress != null)
                {
                    complete = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Your form is incomplete. Please, complete it again");
                    System.Threading.Thread.Sleep(3000);
                }
            }
            Console.Clear();
            Console.WriteLine("The form is complete.");
        }


        //public void CourseCreation(List<Course>schoolCourses)
        //{
        //    Console.WriteLine("Subject of the course : ");
        //    string subject = Console.ReadLine();
        //    Console.WriteLine("Which year : ");
        //    int year = Convert.ToInt16(Console.ReadLine());
        //    Console.WriteLine("Duration of the course (hh,mm)");
        //    double duration = Convert.ToDouble(Console.ReadLine());

        //    Course course = new Course(subject, year, duration);
        //    schoolCourses.Add(course);
        //    Console.WriteLine("Add a new course ? Yes or No");
        //    string a = Console.ReadLine();
        //    if (a == "Yes")
        //    {
        //        CourseCreation(schoolCourses);
        //    }       
        //}
    }
}
