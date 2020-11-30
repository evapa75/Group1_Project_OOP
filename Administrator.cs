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

        public void AddStudent() //A AJOUTER : id, password, tutorID, fees + enregistrer dans la liste d'étudiants
        {
            bool complete = false;
            string firstName = "";
            string name = "";
            char sex = ' ';
            DateTime birthdate = new DateTime();
            string grade = "";
            string personalEmailAdress = "";
            string phoneNumber = "";
            string adress = "";

            while (complete == false)
            {
                Console.Clear();
                Console.WriteLine("Let's complete the registration of a new student. \n\nPlease complete the following informations :");

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

                Console.WriteLine("In which grade do you want to register this student ? (A1, A2, A3, A4, A5, B1, B2, B3)");
                grade = Console.ReadLine();

                Console.WriteLine(" \nPersonal email adress :");
                personalEmailAdress = Console.ReadLine();

                Console.WriteLine(" \nTelephone number :");
                phoneNumber = Console.ReadLine();

                Console.WriteLine(" \nAdress (street number, street, postal code, city) :");
                adress = Console.ReadLine();

                if (firstName != null && name != null && sex != null && grade != null && day != 0 && month != 0 && year != 0 && personalEmailAdress != null && phoneNumber != null && adress != null)
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

        public void AddProfesseur() //A AJOUTER => id, password, subject, tutor, et 4 classes + enregistrement 
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

        public void AddAministrator()//A AJOUTER => id, password, 2 lists
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

        public void ManagingStudentInformations(Student student)
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                Console.WriteLine($"Student Profile {student.FirstName} {student.Name.ToUpper()} \n\n");
                Console.WriteLine("Personal identifying information : \n\n" +
                    student.FirstName + " " + student.Name.ToUpper() +
                    $"\nID : {student.ID}" +
                    $"\nGender : {student.Gender}" +
                    $"\nBirthdate : {student.Birthdate.ToShortDateString()}\n\n");
                Console.WriteLine("Contact information : \n\n" +
                    $"Adress : {student.Adress}" +
                    $"\nPhone Number : {student.PhoneNumber}" +
                    $"\nSchool email adress : {student.SchoolEmail}" +
                    $"\nPersonnal email adress : {student.PersoEmail}\n\n");
                Console.WriteLine("School information : \n\n" +
                    $"\nGrade : {student.Class}" +
                    $"\nTutorID : {student.TutorID}" +
                    $"\nFees : {student.Fees}\n\n\n");

                Console.WriteLine("Do you want to change any of the student's information? ");
                Console.WriteLine("0 - Nothing\n" +
                    "1 - Adress\n" +
                    "2 - Phone number\n" +
                    "3 - Personal email adress\n" +
                    "4 - Grade\n" +
                    "5 - TutorID\n" +
                    "6 - Fees\n");
                int nb = Convert.ToInt32(Console.ReadLine());

                switch (nb)
                {
                    case 0:
                        finish = true;
                        break;

                    case 1:
                        Console.WriteLine("\nEnter the new address of the student");
                        student.Adress = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("\nEnter the new phone number of the student");
                        student.PhoneNumber = Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("\nEnter the new personal email adress of the student");
                        student.PersoEmail = Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("\nEnter the new grade of the student of the student");
                        student.Class = Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine("Enter the new tutor ID of the student");
                        student.TutorID = Console.ReadLine();
                        break;

                    case 6:
                        Console.WriteLine("Enter the new amount that the student will have to pay");
                        student.Fees = Convert.ToDouble(Console.ReadLine());
                        break;
                }
            }
        }

        public void ManagingProfessorInformations(Professor professor)
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                Console.WriteLine($"Professor Profile {professor.FirstName} {professor.Name.ToUpper()} \n\n");
                Console.WriteLine("Personal identifying information : \n\n" +
                    professor.FirstName + " " + professor.Name.ToUpper() +
                    $"\nID : {professor.ID}" +
                    $"\nGender : {professor.Gender}" +
                    $"\nBirthdate : {professor.Birthdate.ToShortDateString()}\n\n");
                Console.WriteLine("Contact information : \n\n" +
                    $"Adress : {professor.Adress}" +
                    $"\nPhone Number : {professor.PhoneNumber}" +
                    $"\nSchool email adress : {professor.SchoolEmail}" +
                    $"\nPersonnal email adress : {professor.PersoEmail}\n\n");
                Console.WriteLine("School information : \n\n" +
                    $"\nTutorID : {professor.Tutor}");

                Console.WriteLine("Do you want to change any of the professor's information? ");
                Console.WriteLine("0 - Nothing\n" +
                    "1 - Adress\n" +
                    "2 - Phone number\n" +
                    "3 - Personal email adress\n" +
                    "4 - Tutor\n");
                int nb = Convert.ToInt32(Console.ReadLine());

                switch (nb)
                {
                    case 0:
                        finish = true;
                        break;

                    case 1:
                        Console.WriteLine("\nEnter the new address of the professor");
                        professor.Adress = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("\nEnter the new phone number of the professor");
                        professor.PhoneNumber = Console.ReadLine();
                        break;

                    case 3:
                        Console.WriteLine("\nEnter the new personal email adress of the professor");
                        professor.PersoEmail = Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("Is the professor a tutor :\n1 - YES\n2 - NO");
                        int nb2 = Convert.ToInt32(Console.ReadLine());
                        switch(nb2)
                        {
                            case 1:
                                professor.Tutor = true;
                                break;

                            case 2:
                                professor.Tutor = false;
                                break;
                        }
                        break;
                }
            }
        }

    }
}
