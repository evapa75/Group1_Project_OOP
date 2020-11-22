using System;
using System.Collections.Generic;

namespace Group1_OOP
{
    public class Program
    {
        static void Connection(string userType, List<Student> studentsList, List<Professor> professorsList, List<Administrator> adminsList)
        {
            string id = "";
            string password = "";

            bool testID = false;
            bool testPassword = false;

            while (testID == false || testPassword == false)
            {
                Console.Clear();
                Console.WriteLine("Enter your ID (college email adress) :");
                id = Convert.ToString(Console.ReadLine());

                Console.WriteLine("\nEnter your password : ");
                password = Convert.ToString(Console.ReadLine());

                if (userType == "student")
                {
                    testID = studentsList.Exists(x => x.ID == id);
                    testPassword = studentsList.Exists(x => x.Password == password);
                }
                if (userType == "professor")
                {
                    testID = professorsList.Exists(x => x.ID == id);
                    testPassword = professorsList.Exists(x => x.Password == password);
                }
                if (userType == "administrator")
                {
                    testID = studentsList.Exists(x => x.ID == id);
                    testPassword = studentsList.Exists(x => x.Password == password);
                }

                if (testID == false || testPassword == false)
                {
                    Console.WriteLine("Wrong ID or password. \nTry again.");
                    System.Threading.Thread.Sleep(3000);
                }
            }

            Console.Clear();
            Console.WriteLine("Successful login. \n");
            System.Threading.Thread.Sleep(2000);

            if (userType == "student")
            {
                Student s = studentsList.Find(x => x.ID.Contains(id));
                s.LoginStatus = true;
                Console.WriteLine("Welcome " + s.FirstName + " " + s.Name + "\n \n");
                StudentPortal(s);
            }
            if (userType == "professor")
            {
                Professor p = professorsList.Find(x => x.ID.Contains(id));
                p.LoginStatus = true;
                Console.WriteLine("Welcome " + p.FirstName + " " + p.Name + "\n \n");
                ProfessorPortal(p);
            }
            if (userType == "administrator")
            {
                Administrator a = adminsList.Find(x => x.ID.Contains(id));
                a.LoginStatus = true;
                Console.WriteLine("Welcome " + a.FirstName + " " + a.Name + "\n \n");
                AdministratorPortal(a);
            }
        }

        static string FirstPassword()
        {
            bool correct = false;
            string password = "";
            string confirm = "";
            while (correct == false)
            {
                Console.WriteLine("Choose a password :");
                password = Console.ReadLine();

                Console.WriteLine("\n\nConfirm your password :");
                confirm = Console.ReadLine();

                if (confirm == password)
                {
                    correct = true;
                }

                if (correct == false)
                {
                    Console.Clear();
                    Console.WriteLine("Error : The two passwords are different");
                    System.Threading.Thread.Sleep(2000);
                }
            }
            Console.Clear();
            return password;
        }

        static void StudentRegistration(List<ApplicationForRegistration> studentWaitingList)
        {
            bool complete = false;
            string firstName = "";
            string name = "";
            char sex = ' ';
            DateTime birthdate = new DateTime();
            int studyYear = 0;
            string personalEmailAdress = "";
            string phoneNumber = "";
            string adress = "";

            while (complete == false)
            {
                Console.Clear();
                Console.WriteLine("Let's complete your registration. \n\nPlease complete the following informations :");

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

                Console.WriteLine(" \nIn which grade do you wish to register? ( 1,2,3. . . )");
                studyYear = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(" \nPersonal email adress :");
                personalEmailAdress = Console.ReadLine();

                Console.WriteLine(" \nTelephone number :");
                phoneNumber = Console.ReadLine();

                Console.WriteLine(" \nAdress (street number, street, postal code, city) :");
                adress = Console.ReadLine();

                if (firstName != null && name != null && sex != null && day != 0 && month != 0 && year != 0 && studyYear != 0 && personalEmailAdress != null && phoneNumber != null && adress != null)
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
            Console.WriteLine("The form is complete. \nYour request will be processed as soon as possible. \nYou will receive an email to keep you informed of the status of your application.");
            ApplicationForRegistration application = new ApplicationForRegistration(firstName, name, sex, birthdate, studyYear, personalEmailAdress, phoneNumber, adress);
            studentWaitingList.Add(application);
        }

        static void StudentPortal(Student student)
        {
            bool finish = false;
            while (finish == false)
            {
                Console.WriteLine("STUDENT PORTAL - Virtual Global College \n \n");
                Console.WriteLine($"Student Dashboard {student.FirstName} {student.Name.ToUpper()} \n");
                Console.WriteLine("1 - See and modify contact and personal identifying information \n");
                Console.WriteLine("2 - Timetable \n");
                Console.WriteLine("3 - Registering for courses \n");
                Console.WriteLine("4 - Attendance \n");
                Console.WriteLine("5 - Grade Book \n");
                Console.WriteLine("6 - Payment of fees \n");
                Console.WriteLine("7 - Disconnect");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        student.ShowAndModifyPersonalInformation();
                        break;

                    //case "2":
                    //    Console.Clear();
                    //    student.ShowTimetable();
                    //    break;

                    //case "3":
                    //    Console.Clear();
                    //    student.RegisterForCourses();
                    //    break;

                    //case "4":
                    //    Console.Clear();
                    //    Console.WriteLine("ATTENDANCE \n1 - Manage Attendance \n\n2 - Show Attendance");
                    //    switch (Console.ReadLine())
                    //    {
                    //        case "1":
                    //            Console.Clear();
                    //            student.ManageAttendance();
                    //            break;
                    //        case "2":
                    //            Console.Clear();
                    //            student.ShowAttendance();
                    //            break;
                    //    }
                    //    student.RegisterForCourses();
                    //    break;

                    //case "5":
                    //    Console.Clear();
                    //    student.ShowGradeBook();
                    //    break;

                    //case "6":
                    //    Console.Clear();
                    //    Console.WriteLine("PAYEMENT OF FEES \n1 - Manage payment of fees \n\n2 - Show payment of fees");
                    //    switch (Console.ReadLine())
                    //    {
                    //        case "1":
                    //            Console.Clear();
                    //            student.ManagePayementFees();
                    //            break;
                    //        case "2":
                    //            Console.Clear();
                    //            student.ShowPayementFees();
                    //            break;
                    //    }
                    //break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("You've been disconnected. Press any key on your keyboard to close the application.");
                        finish = true;
                        break;
                }
            }

        }

        static void ProfessorPortal(Professor professor)
        {
            Console.WriteLine("Professor portal");
        }

        static void AdministratorPortal(Administrator admin)
        {
            Console.WriteLine("Administrator portal");
        }

        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            List<Professor> professorList = new List<Professor>();
            List<Administrator> adminList = new List<Administrator>();

            List<ApplicationForRegistration> studentWaitingList = new List<ApplicationForRegistration>();


            // Remplir les listes à partir des 3 fichiers Excel
            Professor P = new Professor("Daniel", "Paddy", 'M', new DateTime(1999, 12, 30), "daniel.paddy@gmail.com", "0698741246", "2 rue Molière, Antony", "abcde");
            Student S = new Student("Marie", "Donier", 'F', new DateTime(2000, 02, 17), 2, "marie.donier@gmail.com", "0660638465", "24 avenue des Coutayes, 78570 Andresy", "abcde", 3500);

            professorList.Add(P);
            studentList.Add(S);



            Console.WriteLine("Welcome to the Virtual Global College Portal ! \n \n 1 - Submit an application for registration \n 2 - Access the portal");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    StudentRegistration(studentWaitingList);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("You are : \n 1 - Student \n 2 - Professor \n 3 - Administrator");
                    string userType = "";

                    switch (Console.ReadLine())
                    {
                        case "1":
                            userType = "student";
                            break;

                        case "2":
                            userType = "professor";
                            break;

                        case "3":
                            userType = "administrator";
                            break;
                    }

                    Console.Clear();

                    Console.WriteLine("Is it your first connection on the portal ? \n 1 - YES \n 2 - NO");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Enter your first name (ex : Mike) :");
                            string firstname = Console.ReadLine();
                            Console.WriteLine(" \nEnter your name (ex : Davis) :");
                            string name = Console.ReadLine();

                            if (userType == "student")
                            {
                                Student s = studentList.Find(x => x.FirstName.Contains(firstname) && x.Name.Contains(name));
                                Console.WriteLine("\nYour ID is your college email adress : " + s.ID + "\n");
                                s.Password = FirstPassword();
                            }
                            if (userType == "professor")
                            {
                                Professor p = professorList.Find(x => x.FirstName.Contains(firstname) && x.Name.Contains(name));
                                Console.WriteLine("\nYour ID is your college email adress : " + p.ID + "\n");
                                p.Password = FirstPassword();
                            }
                            if (userType == "administrator")
                            {
                                Administrator a = adminList.Find(x => x.FirstName.Contains(firstname) && x.Name.Contains(name));
                                Console.WriteLine("\nYour ID is your college email adress : " + a.ID + "\n");
                                a.Password = FirstPassword();
                            }
                            Console.WriteLine("\n\nPress Enter to continue");
                            Connection(userType, studentList, professorList, adminList);
                            break;

                        case "2":
                            Connection(userType, studentList, professorList, adminList);
                            break;
                    }
                    break;



            }




            //foreach (ApplicationForRegistration app in studentWaitingList)
            //{
            //    app.ShowApplicationForRegistration();
            //}




            // Connection(userType, studentsList, professorsList, adminsList);




            // Faire une sauvegarde des listes (élèves, profs, admins, edt élèves, edt profs, cours) potentiellement modifiées avant de fermer le portail



            Console.ReadKey();
        }
    }
}
