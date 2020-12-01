using System;
using System.Collections.Generic;
using System.IO;
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

        public string FirstPassword()
        {
            string password = "";
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                password += (char)random.Next('a', 'z');
            }
            return password;
        }

        public List<Administrator> AllAdministrators()
        {
            List<Administrator> allAdministrators = new List<Administrator>();
            int counter = 0;
            StreamReader file = new StreamReader("Administrators.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[11];
            while (file.Peek() > 0)
            {
                line = file.ReadLine(); //Lecture d'une ligne
                if (counter == 1)
                {
                    datas = line.Split(sep);
                    string id = datas[0];
                    string firstname = datas[1];
                    string name = datas[2];
                    string gender = datas[3];
                    string birthdate = datas[4];
                    string personalEmailAdress = datas[5];
                    string phoneNumber = datas[6];
                    string adress = datas[7];
                    string password = datas[8];
                    //Console.WriteLine(id + ";" + firstname + ";" + name + ";" + gender + ";" + birthdate + ";" + personalEmailAdress + ";" + phoneNumber + ";" + adress + ";" + password);
                    Administrator A = new Administrator(id, firstname, name, gender, birthdate, personalEmailAdress, phoneNumber, adress, password, this.AllStudents, this.AllProfessors);
                    allAdministrators.Add(A);
                }
                counter = 1;
            }


            return allAdministrators;
        }

        public Student AddStudent() 
        {
            bool complete = false;
            string firstName = "";
            string name = "";
            string sex = "";
            string birthdate = "";
            string _class = "";
            string personalEmailAdress = "";
            string phoneNumber = "";
            string adress = "";

            string password = FirstPassword();
            int fees = 5000;

            List<Student> allStudents = this.AllStudents;
            Student s = allStudents.ElementAt(allStudents.Count - 1);
            int i = Convert.ToInt32(s.ID) + 1;
            string id = Convert.ToString(i);

            string tutorID = "";
            List<Professor> tutors = new List<Professor>();
            foreach(Professor p in this.AllProfessors)
            {
                if(p.Tutor == true)
                {
                    tutors.Add(p);
                }
            }


            while (complete == false)
            {
                Console.Clear();
                Console.WriteLine("Let's complete the registration of a new student. \n\nPlease complete the following informations :");

                Console.WriteLine(" \nFirst Name :");
                firstName = Console.ReadLine();

                Console.WriteLine(" \nName :");
                name = Console.ReadLine();

                Console.WriteLine(" \nSex : Female or Male");
                sex = Console.ReadLine();

                Console.WriteLine(" \nBirthdate : dd/mm/yyyy");
                birthdate = Console.ReadLine();

                Console.WriteLine("In which grade do you want to register this student ? (A1, A2, A3, A4, A5, B1, B2, B3)");
                _class = Console.ReadLine();

                Console.WriteLine(" \nPersonal email adress :");
                personalEmailAdress = Console.ReadLine();

                Console.WriteLine(" \nTelephone number :");
                phoneNumber = Console.ReadLine();

                Console.WriteLine(" \nAdress (street number, street, postal code, city) :");
                adress = Console.ReadLine();

                Console.WriteLine("\nChoose a tutor for the student from the following list");
                foreach (Professor p in tutors)
                {
                    Console.WriteLine($"Professor ID : {p.ID}    Number of students tutored: " + p.TutorStudentList.Count);
                }
                Console.WriteLine("ID of the professor >");
                tutorID = Console.ReadLine();



                if (tutorID != null && firstName != null && name != null && sex != null && _class != null && birthdate != null && personalEmailAdress != null && phoneNumber != null && adress != null)
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

            Student student = new Student(id, firstName, name, sex, birthdate, _class, personalEmailAdress, phoneNumber, adress, password, tutorID, fees);

            return student;
        }

        public Professor AddProfesseur()
        {
            bool complete = false;
            string firstName = "";
            string name = "";
            string sex = "";
            string birthdate = "";
            string personalEmailAdress = "";
            string phoneNumber = "";
            string adress = "";
            string subject = "";
            string password = FirstPassword();

            string tutor = "";
            string name_class1 = "";
            string name_class2 = "";
            string name_class3 = "";
            string name_class4 = "";

            List<Professor> allProfessors = AllProfessors;
            Professor p = allProfessors.ElementAt(allProfessors.Count - 1);
            int i = Convert.ToInt32(p.ID) + 1;
            string id = Convert.ToString(i);

            while (complete == false)
            {
                Console.Clear();
                Console.WriteLine("Let's complete the registration of a new teacher. \n\nPlease complete the following informations about this teacher:");

                Console.WriteLine(" \nFirst Name :");
                firstName = Console.ReadLine();

                Console.WriteLine(" \nName :");
                name = Console.ReadLine();

                Console.WriteLine(" \nSex : Female or Male");
                sex = Console.ReadLine();

                Console.WriteLine(" \nBirthdate : dd/mm/yyyy");
                birthdate = Console.ReadLine();

                Console.WriteLine(" \nPersonal email adress :");
                personalEmailAdress = Console.ReadLine();

                Console.WriteLine(" \nTelephone number :");
                phoneNumber = Console.ReadLine();

                Console.WriteLine(" \nAdress (street number, street, postal code, city) :");
                adress = Console.ReadLine();

                Console.WriteLine("\nSubject :");
                subject = Console.ReadLine();

                Console.WriteLine("Is this professor a tutor ? yes or no");
                tutor = Console.ReadLine();

                Console.WriteLine("Number of class  > ");
                int nb = Convert.ToInt16(Console.ReadLine());
                if(nb == 1)
                {
                    Console.WriteLine("Class : (A1,A2,A3,A4,A5,B1,B2,B3)");
                    name_class1 = Console.ReadLine();
                }
                if(nb == 2)
                {
                    Console.WriteLine("First class : (A1,A2,A3,A4,A5,B1,B2,B3)");
                    name_class1 = Console.ReadLine();
                    Console.WriteLine("Second class : ");
                    name_class2 = Console.ReadLine();
                }
                if(nb == 3)
                {
                    Console.WriteLine("First class : (A1,A2,A3,A4,A5,B1,B2,B3)");
                    name_class1 = Console.ReadLine();
                    Console.WriteLine("Second class : ");
                    name_class2 = Console.ReadLine();
                    Console.WriteLine("Third class :)");
                    name_class3 = Console.ReadLine();
                }
                if(nb ==4)
                {
                    Console.WriteLine("First class : (A1,A2,A3,A4,A5,B1,B2,B3)");
                    name_class1 = Console.ReadLine();
                    Console.WriteLine("Second class : ");
                    name_class2 = Console.ReadLine();
                    Console.WriteLine("Third class : ");
                    name_class3 = Console.ReadLine();
                    Console.WriteLine("Fourth class : ");
                    name_class4 = Console.ReadLine();
                }



                if (subject != null && tutor != null && firstName != null && name != null && sex != null && birthdate != null && personalEmailAdress != null && phoneNumber != null && adress != null)
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

            Professor professor = new Professor(id, firstName, name, sex, birthdate, personalEmailAdress, phoneNumber, adress, password, subject, tutor, name_class1, name_class2, name_class3, name_class4);

            return professor;
        }

        public Administrator AddAministrator()
        {
            bool complete = false;
            string firstName = "";
            string name = "";
            string sex = "";
            string birthdate = "";
            string personalEmailAdress = "";
            string phoneNumber = "";
            string adress = "";

            List<Student> allStudents = this.AllStudents;
            List<Professor> allProfessors = this.AllProfessors;
            List<Administrator> allAdministrators = AllAdministrators();

            string password = FirstPassword();

            Administrator a = allAdministrators.ElementAt(allAdministrators.Count - 1);
            int i = Convert.ToInt32(a.ID) + 1;
            string id = Convert.ToString(i);

            while (complete == false)
            {
                Console.Clear();
                Console.WriteLine("Let's complete the registration of a new admin. \n\nPlease complete the following informations :");

                Console.WriteLine(" \nFirst Name :");
                firstName = Console.ReadLine();

                Console.WriteLine(" \nName :");
                name = Console.ReadLine();

                Console.WriteLine(" \nSex : Female or Male");
                sex = Console.ReadLine();

                Console.WriteLine(" \nBirthdate : (dd/mm/yyyy");
                birthdate = Console.ReadLine();

                Console.WriteLine(" \nPersonal email adress :");
                personalEmailAdress = Console.ReadLine();

                Console.WriteLine(" \nTelephone number :");
                phoneNumber = Console.ReadLine();

                Console.WriteLine(" \nAdress (street number, street, postal code, city) :");
                adress = Console.ReadLine();

                if (firstName != null && name != null && sex != null && birthdate != null && personalEmailAdress != null && phoneNumber != null && adress != null)
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

            Administrator administrator = new Administrator(id, firstName, name, sex, birthdate, personalEmailAdress, phoneNumber, adress, password, allStudents, allProfessors);

            return administrator;
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
