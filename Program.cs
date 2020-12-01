using System;
using System.Collections.Generic;
using System.IO;

namespace Group1_OOP
{
    public class Program
    {
        static void Connection(List<Student> studentList, List<Professor> professorList, List<Administrator> adminList)
        {
            string id = "";
            string password = "";
            string userType = "";

            bool testID = false;
            bool testPassword = false;

            while (testID == false || testPassword == false)
            {
                Console.WriteLine("Enter your ID");
                id = Console.ReadLine();

                Console.WriteLine("\nEnter your password : ");
                password = Console.ReadLine();

                if (id[0] == '1')
                {
                    userType = "student";
                    testID = studentList.Exists(x => x.ID == id);
                    testPassword = studentList.Exists(x => x.Password == password);
                    Console.WriteLine(testID);
                    Console.WriteLine(testPassword);
                }
                if (id[0] == '2')
                {
                    userType = "professor";
                    testID = professorList.Exists(x => x.ID == id);
                    testPassword = professorList.Exists(x => x.Password == password);
                }
                if (id[0] == '3')
                {
                    userType = "administrator";
                    testID = adminList.Exists(x => x.ID == id);
                    testPassword = adminList.Exists(x => x.Password == password);
                }

                if (testID == false || testPassword == false)
                {
                    Console.WriteLine("Wrong ID or password. \nTry again.");
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine("Successful login. \n");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            if (userType == "student")
            {
                Student s = studentList.Find(x => x.ID.Contains(id));
                s.LoginStatus = true;
                Console.WriteLine("Welcome " + s.FirstName + " " + s.Name + "\n \n");
                StudentPortal(s);
            }
            if (userType == "professor")
            {
                Professor p = professorList.Find(x => x.ID.Contains(id));
                p.LoginStatus = true;
                Console.WriteLine("Welcome " + p.FirstName + " " + p.Name + "\n \n");
                ProfessorPortal(p);
            }
            if (userType == "administrator")
            {
                Administrator a = adminList.Find(x => x.ID.Contains(id));
                a.LoginStatus = true;
                Console.WriteLine("Welcome " + a.FirstName + " " + a.Name + "\n \n");
                AdministratorPortal(a);
            }
        }

        static void StudentPortal(Student student)
        {
            student.LoginStatus = true;
            while (student.LoginStatus == true)
            {
                Console.Clear();
                Console.WriteLine("STUDENT PORTAL - Virtual Global College \n \n");
                Console.WriteLine($"Student Dashboard {student.FirstName} {student.Name.ToUpper()} \n");
                Console.WriteLine("1 - Contact and personal identifying information \n");
                Console.WriteLine("2 - Courses\n");
                Console.WriteLine("3 - Timetable \n");
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

                    case "2":
                        Console.Clear();
                        Console.WriteLine("1- Display your courses");
                        Console.WriteLine("\n2- Register for a course");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                student.ShowCourses();
                                break;

                            case "2":
                                Console.Clear();
                                student.RegisterForACourse();
                                break;
                        }
                        break;

                    case "3":
                        Console.Clear();
                        bool finish = false;
                        while (finish == false)
                        {
                            student.Timetable.ShowTimetable();
                            Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                            int decision = Convert.ToInt32(Console.ReadLine());
                            if (decision == 1)
                            {
                                finish = true;
                            }
                        }
                        break;

                    case "4":
                        Console.Clear();
                        student.ShowAttendance();
                        break;

                    case "5":
                        Console.Clear();
                        student.ShowGradeBook();
                        break;

                    case "6":
                        Console.Clear();
                        student.PayementOfFees();
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("You've been disconnected. Press any key on your keyboard to close the application.");
                        student.LoginStatus = false;
                        break;
                }
            }

        }

        static void ProfessorPortal(Professor professor)
        {
            professor.LoginStatus = true;
            while (professor.LoginStatus == true)
            {
                Console.WriteLine("PROFESSOR PORTAL - Virtual Global College \n \n");
                Console.WriteLine($"Professor Dashboard {professor.FirstName} {professor.Name.ToUpper()} \n");
                Console.WriteLine("1 - Contact and personal identifying information \n");
                Console.WriteLine("2 - Timetable/ \n");
                Console.WriteLine("3 - Student's Attendance \n");
                Console.WriteLine("4 - Grade a student \n");
                Console.WriteLine("5 - Edit your course plan - Create an exam \n");
                Console.WriteLine("6 - Display information of one of your student \n");
                Console.WriteLine("7 - Display information from a student you are tutoring \n");
                Console.WriteLine("8 - Disconnect");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        professor.ShowAndModifyPersonalInformation();
                        break;

                    case "2":
                        Console.Clear();
                        bool finish = false;
                        while (finish == false)
                        {
                            professor.Timetable.ShowTimetableProfessor();
                            Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                            int decision = Convert.ToInt32(Console.ReadLine());
                            if (decision == 1)
                            {
                                finish = true;
                            }
                        }
                        break;


                    //case "3":
                    //Console.Clear();
                    //    professor.StudentsAttendance(); Afficher la liste des classes du prof, il choisit la classe dont il souhaite faire la présence
                    // pour chaque élève : P pour présent et A pour absent
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

                    case "8":
                        Console.Clear();
                        Console.WriteLine("You've been disconnected. Press any key on your keyboard to close the application.");
                        professor.LoginStatus = false;
                        break;
                }
            }
        }

        static void AdministratorPortal(Administrator admin)
        {
            admin.LoginStatus = true;
            while (admin.LoginStatus == true)
            {
                Console.WriteLine("PROFESSOR PORTAL - Virtual Global College \n \n");
                Console.WriteLine($"Administrator Dashboard {admin.FirstName} {admin.Name.ToUpper()} \n");
                Console.WriteLine("1 - Contact and personal identifying information \n");
                Console.WriteLine("2 - Add a new student \n");
                Console.WriteLine("3 - Add a new professor \n");
                Console.WriteLine("4 - Add a new administrator \n");
                Console.WriteLine("5 - Create a course \n");
                Console.WriteLine("6 - Manage applications for courses \n");
                Console.WriteLine("7 - Manage Timetables \n");
                Console.WriteLine("8 - Manage student information (contact, fees, tutor) \n");
                Console.WriteLine("9 - Manage professor information (contact, tutoring) \n");
                Console.WriteLine("10 - Disconnect");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        admin.ShowAndModifyPersonalInformation();
                        break;

                    case "2":
                        Console.Clear();
                        //Student s = admin.AddStudent();
                        break;


                    case "3":
                        Console.Clear();
                        //Professor p = admin.AddProfesseur();
                        break;

                    case "4":
                        Console.Clear();
                        //Administrator a = admin.AddAministrator();
                        break;

                        //case "5":
                        //    Console.Clear();
                        //    break;

                        //case "6":
                        //    Console.Clear();
                        //    break;

                        //case "7":
                        //    Console.Clear();
                        //    break;

                    case "8":
                        Console.Clear();
                        //Student s;
                        //admin.ManagingStudentInformations(s);
                        break;

                    case "9":
                        Console.Clear();
                        //Professor p;
                        //admin.ManagingProfessorInformations(p);
                        break;

                    case "10":
                        Console.Clear();
                        Console.WriteLine("You've been disconnected. Press any key on your keyboard to close the application.");
                        admin.LoginStatus = false;
                        break;
                }
            }
        }



        static void Main(string[] args)
        {



            List<Student> studentList = new List<Student>();
            List<Professor> professorList = new List<Professor>();
            List<Administrator> adminList = new List<Administrator>();


            // List of students
            int counter = 0;
            StreamReader fichLect = new StreamReader("Students.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[12];
            while (fichLect.Peek() > 0)
            {
                line = fichLect.ReadLine(); //Lecture d'une ligne
                if (counter == 1)
                {
                    datas = line.Split(sep);
                    string id = datas[0];
                    string firstname = datas[1];
                    string name = datas[2];
                    string gender = datas[3];
                    string birthdate = datas[4];
                    string _class = datas[5];
                    string personalEmailAdress = datas[6];
                    string phoneNumber = datas[7];
                    string adress = datas[8];
                    string password = datas[9];
                    string tutorID = datas[10];
                    double fees = Convert.ToDouble(datas[11]);
                    //Console.WriteLine(id + ";" + firstname + ";" + name + ";" + gender + ";" + birthdate + ";" + _class + ";" + personalEmailAdress + ";" + phoneNumber + ";" + adress + ";" + password + ";" + tutorID + ";" + fees);
                    Student S = new Student(id, firstname, name, gender, birthdate, _class, personalEmailAdress, phoneNumber, adress, password, tutorID, fees);
                    studentList.Add(S);
                }
                counter = 1;
            }

            //List of professors
            counter = 0;
            StreamReader fichLect2 = new StreamReader("Professors.csv");
            char[] sep2 = new char[1] { ';' };
            string line2 = "";
            string[] datas2 = new string[15];
            while (fichLect2.Peek() > 0)
            {
                line2 = fichLect2.ReadLine(); //Lecture d'une ligne
                if (counter == 1)
                {
                    datas2 = line2.Split(sep2);
                    string id = datas2[0];
                    string firstname = datas2[1];
                    string name = datas2[2];
                    string gender = datas2[3];
                    string birthdate = datas2[4];
                    string personalEmailAdress = datas2[5];
                    string phoneNumber = datas2[6];
                    string adress = datas2[7];
                    string password = datas2[8];
                    string subject = datas2[9];
                    string tutor = datas2[10];
                    string name_class1 = datas2[11];
                    string name_class2 = datas2[12];
                    string name_class3 = datas2[13];
                    string name_class4 = datas2[14];
                    //Console.WriteLine(id + ";" + firstname + ";" + name + ";" + gender + ";" + birthdate + ";" + personalEmailAdress + ";" + phoneNumber + ";" + adress + ";" + password + ";" + subject + ";" + tutor);
                    Professor P = new Professor(id, firstname, name, gender, birthdate, personalEmailAdress, phoneNumber, adress, password, subject, tutor, name_class1, name_class2, name_class3, name_class4);
                    professorList.Add(P);
                }
                counter = 1;
            }

            // List of administrators
            counter = 0;
            StreamReader fichLect3 = new StreamReader("Administrators.csv");
            char[] sep3 = new char[1] { ';' };
            string line3 = "";
            string[] datas3 = new string[11];
            while (fichLect3.Peek() > 0)
            {
                line3 = fichLect3.ReadLine(); //Lecture d'une ligne
                if (counter == 1)
                {
                    datas3 = line3.Split(sep3);
                    string id = datas3[0];
                    string firstname = datas3[1];
                    string name = datas3[2];
                    string gender = datas3[3];
                    string birthdate = datas3[4];
                    string personalEmailAdress = datas3[5];
                    string phoneNumber = datas3[6];
                    string adress = datas3[7];
                    string password = datas3[8];
                    //Console.WriteLine(id + ";" + firstname + ";" + name + ";" + gender + ";" + birthdate + ";" + personalEmailAdress + ";" + phoneNumber + ";" + adress + ";" + password);
                    Administrator A = new Administrator(id, firstname, name, gender, birthdate, personalEmailAdress, phoneNumber, adress, password, studentList, professorList);
                    adminList.Add(A);
                }
                counter = 1;
            }

            /*
            studentList[0].Timetable.ShowTimetable();
            Console.WriteLine("\n\n\n");
            professorList[0].Timetable.ShowTimetable();
            */

            Console.WriteLine("Welcome to the Virtual Global College Portal ! \n\n");

            Connection(studentList, professorList, adminList);





            // Faire une sauvegarde des listes (élèves, profs, admins, edt élèves, edt profs, cours) potentiellement modifiées avant de fermer le portail



            Console.ReadKey();
        }
    }
}
