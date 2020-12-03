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
            bool testIdentity = false;

            while (testID == false || testPassword == false || testIdentity == false)
            {
                Console.WriteLine("Welcome to the Virtual Global College Portal ! \n\n");
                Console.WriteLine("Enter your ID");
                id = Console.ReadLine();

                Console.WriteLine("\nEnter your password : ");
                password = Console.ReadLine();

                if (id[0] == '1')
                {
                    userType = "student";
                    testID = studentList.Exists(x => x.ID == id);
                    testPassword = studentList.Exists(x => x.Password == password);
                    if (studentList.Find(x => x.ID.Contains(id)) == studentList.Find(x => x.Password.Contains(password)))
                    {
                        testIdentity = true;
                    }
                }
                if (id[0] == '2')
                {
                    userType = "professor";
                    testID = professorList.Exists(x => x.ID == id);
                    testPassword = professorList.Exists(x => x.Password == password);
                    if (studentList.Find(x => x.ID.Contains(id)) == studentList.Find(x => x.Password.Contains(password)))
                    {
                        testIdentity = true;
                    }
                }
                if (id[0] == '3')
                {
                    userType = "administrator";
                    testID = adminList.Exists(x => x.ID == id);
                    testPassword = adminList.Exists(x => x.Password == password);
                    if (studentList.Find(x => x.ID.Contains(id)) == studentList.Find(x => x.Password.Contains(password)))
                    {
                        testIdentity = true;
                    }
                }

                if (testID == false || testPassword == false || testIdentity == false)
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
                        student.ShowAndModifyPersonalInformation(1);
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
                            student.Timetable.ShowTimetableStudent();
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
                        student.ShowGradeBook(1);
                        break;

                    case "6":
                        Console.Clear();
                        student.PayementOfFees();
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("\nYou've been disconnected. Press any key on your keyboard to close the application.");
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
                Console.Clear();
                Console.WriteLine("PROFESSOR PORTAL - Virtual Global College \n \n");
                Console.WriteLine($"Professor Dashboard {professor.FirstName} {professor.Name.ToUpper()} \n");
                Console.WriteLine("1 - Contact and personal identifying information \n");
                Console.WriteLine("2 - Timetable \n");
                Console.WriteLine("3 - Student's Attendance \n");
                Console.WriteLine("4 - Grade a student \n");
                Console.WriteLine("5 - Edit your course plan - Create an exam \n");
                Console.WriteLine("6 - Display information of one of your student \n");
                if (professor.Tutor == true)
                {
                    Console.WriteLine("7 - Display information from a student you are tutoring \n");
                    Console.WriteLine("8 - Disconnect");
                }
                else
                {
                    Console.WriteLine("7 - Disconnect");
                }

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

                    case "3":
                        Console.Clear();
                        professor.StudentsAttendance();
                        break;

                    case "4":
                        Console.Clear();
                        professor.GradeAStudent();
                        break;

                    //case "5":
                    //    Console.Clear();
                    //    professor.ShowCoursePlane();

                    //    professor.EditCoursePlan();
                    //    break;

                    case "6":
                        Console.Clear();
                        professor.DisplayInformationStudent();
                        break;

                    case "7":
                        if (professor.Tutor == true)
                        {
                            Console.Clear();
                            professor.DisplayInformationTutoringStudent();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou've been disconnected. Press any key on your keyboard to close the application.");
                            professor.LoginStatus = false;
                        }
                        break;

                    case "8":
                        if (professor.Tutor == true)
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou've been disconnected. Press any key on your keyboard to close the application.");
                            professor.LoginStatus = false;
                        }
                        break;
                }
            }
        }
        static void AdministratorPortal(Administrator admin)
        {
            admin.LoginStatus = true;
            while (admin.LoginStatus == true)
            {
                Console.Clear();
                Console.WriteLine("ADMINISTRATOR PORTAL - Virtual Global College \n \n");
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
                        admin.AddStudent();
                        break;


                    case "3":
                        admin.AddProfessor();
                        break;

                    case "4":
                        admin.AddAministrator();
                        break;

                    case "5":
                        Console.Clear();
                        admin.CreateACourse();
                        break;

                    case "6":
                        Console.Clear();
                        admin.ManageApplicationsForCourses();
                        break;

                    //case "7":
                    //    Console.Clear();
                    //    admin.ManageTimetables();
                    //break;

                    case "8":
                        Console.Clear();
                        admin.ManageStudentInformation();
                        break;

                    case "9":
                        Console.Clear();
                        admin.ManageProfessorInformation();
                        break;

                    case "10":
                        Console.Clear();
                        Console.WriteLine("\nYou've been disconnected. Press any key on your keyboard to close the application.");
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
                line = fichLect.ReadLine();
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
                    Student S = new Student(id, firstname, name, gender, birthdate, _class, personalEmailAdress, phoneNumber, adress, password, tutorID, fees, studentList);
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
                line2 = fichLect2.ReadLine();
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
                    string name_class1 = "";
                    if (datas2[11] != "") { name_class1 = datas2[11]; }
                    string name_class2 = "";
                    if (datas2[12] != "") { name_class2 = datas2[12]; }
                    string name_class3 = "";
                    if (datas2[13] != "") { name_class3 = datas2[13]; }
                    string name_class4 = "";
                    if (datas2[14] != "") { name_class4 = datas2[14]; }

                    //Console.WriteLine(id + ";" + firstname + ";" + name + ";" + gender + ";" + birthdate + ";" + personalEmailAdress + ";" + phoneNumber + ";" + adress + ";" + password + ";" + subject + ";" + tutor);
                    Professor P = new Professor(id, firstname, name, gender, birthdate, personalEmailAdress, phoneNumber, adress, password, subject, tutor, name_class1, name_class2, name_class3, name_class4, studentList);
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
                line3 = fichLect3.ReadLine();
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
                    Administrator A = new Administrator(id, firstname, name, gender, birthdate, personalEmailAdress, phoneNumber, adress, password, studentList, professorList, adminList);
                    adminList.Add(A);
                }
                counter = 1;
            }



            Connection(studentList, professorList, adminList);


            //Enregistrer données de l'Excel Courses.csv dans une List<List<string>>
            // PAS LES EMPLOIS DU TEMPS PARCE QUE MIS A JOUR AU FUR ET A MESURE

            //List<List<string>> lines = new List<List<string>>();
            //int counter = 0;
            //StreamReader fichLect = new StreamReader("Courses.csv");
            //char[] sep = new char[1] { ';' };
            //string line = "";
            //string[] datas = new string[4];
            //while (fichLect.Peek() > 0)
            //{
            //    line = fichLect.ReadLine();
            //    if (counter == 1)
            //    {
            //        datas = line.Split(sep);
            //        List<string> l = new List<string>();
            //        l.Add(datas[0]);
            //        l.Add(datas[1]);
            //        l.Add(datas[2]);
            //        l.Add(datas[3]);
            //        lines.Add(l);
            //    }
            //    counter = 1;
            //}

            //string filename2 = "Courses.csv";
            //StreamWriter fichEcr = new StreamWriter(filename2);
            //string line1 = "Subject" + ";" + "Professor's ID" + ";" + "First Name" + ";" + "Name";
            //fichEcr.WriteLine(line1);
            //foreach (List<string> list in lines)
            //{
            //    string l = list[0] + ";" + list[1] + ";" + list[2] + ";" + list[3];
            //    fichEcr.WriteLine(l);
            //}

            //string lastLine = subject + ";" + professorID + ";" + firstname + ";" + name;
            //fichEcr.WriteLine(lastLine);
            //fichEcr.Close();


            // Faire une sauvegarde des listes (élèves, profs, admins, edt élèves, edt profs, cours) potentiellement modifiées avant de fermer le portail



            Console.ReadKey();
        }
    }
}
