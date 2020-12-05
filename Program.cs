using System;
using System.Collections.Generic;
using System.IO;

namespace Group1_OOP
{
    public class Program
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD


        static void Connection(List<Student> studentList, List<Professor> professorList, List<Administrator> adminList, AcademicCalendar academicCalendar)
        {
            string id = "";
            string password = "";
            string userType = "";

            bool testID = false;
            bool testPassword = false;
            bool testIdentity = false;

            while (testID == false || testPassword == false || testIdentity == false)
            {
                Console.WriteLine("\n**************************************************");
                Console.WriteLine("* Welcome to the Virtual Global College Portal ! *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("\n\n\nEnter your ID");
                id = Console.ReadLine();

                Console.WriteLine("\n\nEnter your password : ");
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
                    Console.WriteLine("\n\nWrong ID or password. \nTry again.");
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine("\nSuccessful login. \n");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            if (userType == "student")
            {
                Student s = studentList.Find(x => x.ID.Contains(id));
                s.LoginStatus = true;
                Console.WriteLine("Welcome " + s.FirstName + " " + s.Name + "\n \n");
                StudentPortal(s, academicCalendar);
            }
            if (userType == "professor")
            {
                Professor p = professorList.Find(x => x.ID.Contains(id));
                p.LoginStatus = true;
                Console.WriteLine("Welcome " + p.FirstName + " " + p.Name + "\n \n");
                ProfessorPortal(p, academicCalendar);
            }
            if (userType == "administrator")
            {
                Administrator a = adminList.Find(x => x.ID.Contains(id));
                a.LoginStatus = true;
                Console.WriteLine("Welcome " + a.FirstName + " " + a.Name + "\n \n");
                AdministratorPortal(a, academicCalendar);
            }
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

        static void StudentPortal(Student student, AcademicCalendar academicCalendar)
        {
            student.LoginStatus = true;
            while (student.LoginStatus == true)
            {
                Console.Clear();
                Console.WriteLine("\n ___________________________________________");
                Console.WriteLine("\n | STUDENT PORTAL - Virtual Global College |");
                Console.WriteLine(" ___________________________________________");
                Console.WriteLine($"\n\n Student Dashboard {student.FirstName} {student.Name.ToUpper()} ");
                Console.WriteLine(" ________________________________________");
                Console.WriteLine("\n\n\n1 - Contact and personal identifying information \n\n");
                Console.WriteLine("2 - Courses\n\n");
                Console.WriteLine("3 - Course Plans\n\n");
                Console.WriteLine("4 - Timetable \n\n");
                Console.WriteLine("5 - Attendance \n\n");
                Console.WriteLine("6 - Gradebook \n\n");
                Console.WriteLine("7 - Payment of fees \n\n");
                Console.WriteLine("8 - Academic Calendar\n\n");
                Console.WriteLine("9 - Disconnect");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        student.ShowAndModifyPersonalInformation(1);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n\n1- Display your courses");
                        Console.WriteLine("\n\n2- Register for a course");

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
                        Console.WriteLine("\nFor which subject would you like to consult the course plan ? \n\n");
                        int number = 1;
                        foreach (CoursePlan c in student.CoursePlan)
                        {
                            Console.WriteLine(number + " - " + c.Subject + "\n");
                            number++;
                        }
                        int index = Convert.ToInt32(Console.ReadLine()) - 1;
                        student.CoursePlan[index].ShowCoursePlan(1);
                        break;

                    case "4":
                        Console.Clear();
                        bool finish = false;
                        while (finish == false)
                        {
                            Console.Clear();
                            student.Timetable.ShowTimetableStudent();
                            Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                            int decision = Convert.ToInt32(Console.ReadLine());
                            if (decision == 1)
                            {
                                finish = true;
                            }
                        }
                        break;

                    case "5":
                        Console.Clear();
                        student.ShowAttendance();
                        break;

                    case "6":
                        Console.Clear();
                        student.ShowGradeBook(1);
                        break;

                    case "7":
                        Console.Clear();
                        student.PayementOfFees();
                        break;

                    case "8":
                        Console.Clear();
                        academicCalendar.ShowAcademicCalendar();
                        break;

                    case "9":
                        Console.Clear();
                        Console.WriteLine("\nYou've been disconnected. \n\nPress any key on your keyboard to close the application.");
                        student.LoginStatus = false;
                        break;
                }
            }

        }

        static void ProfessorPortal(Professor professor, AcademicCalendar academicCalendar)
        {
            professor.LoginStatus = true;
            while (professor.LoginStatus == true)
            {
                Console.Clear();
                Console.WriteLine("\n _____________________________________________");
                Console.WriteLine("\n | PROFESSOR PORTAL - Virtual Global College |");
                Console.WriteLine(" _____________________________________________");
                Console.WriteLine($"\n\n Professor Dashboard {professor.FirstName} {professor.Name.ToUpper()} ");
                Console.WriteLine(" ________________________________________");
                Console.WriteLine("\n\n\n1 - Contact and personal identifying information \n\n");
                Console.WriteLine("2 - Timetable \n\n");
                Console.WriteLine("3 - Student's Attendance \n\n");
                Console.WriteLine("4 - Grade a student \n\n");
                Console.WriteLine("5 - Show the academic calendar\n\n");
                Console.WriteLine("6 - Edit your course plan - Create an exam - Create an assignement\n\n");
                Console.WriteLine("7 - Display information of one of your student \n\n");
                if (professor.Tutor == true)
                {
                    Console.WriteLine("8 - Display information from a student you are tutoring \n\n");
                    Console.WriteLine("9 - Disconnect");
                }
                else
                {
                    Console.WriteLine("8 - Disconnect");
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
                            Console.Clear();
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

                    case "5":
                        Console.Clear();
                        academicCalendar.ShowAcademicCalendar();
                        break;

                    case "6":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("_______________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| COURSE PLAN |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("_______________\n\n\n\n");
                        Console.WriteLine("\n\nWhat do you want to do ? \n\n1 - Look at one of your course plan \n\n2 - Edit one of your course plan \n\n3 - Edit the Exam section of a course plan \n\n4 - Edit the Assignement section of a course plan");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("_______________");
                                Console.WriteLine("\n");
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("| COURSE PLAN |");
                                Console.WriteLine("");
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("_______________\n\n\n\n");
                                Console.WriteLine("\nChoose one of your class : \n");
                                foreach (string c in professor.NameClasses)
                                {
                                    Console.WriteLine(c + "\n");
                                }
                                string _class = Console.ReadLine().ToUpper();
                                professor.CoursePlan.Find(x => x.Class.Contains(_class)).ShowCoursePlan(1);
                                break;

                            case "2":
                                Console.Clear();
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("________________");
                                Console.WriteLine("\n");
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("| COURSE PLAN |");
                                Console.WriteLine("");
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("________________\n\n\n\n");
                                Console.WriteLine("\nChoose one of your class : \n");
                                foreach (string c in professor.NameClasses)
                                {
                                    Console.WriteLine(c + "\n");
                                }
                                _class = Console.ReadLine().ToUpper();
                                professor.CoursePlan.Find(x => x.Class.Contains(_class)).ModifyCoursePlan();
                                break;

                            case "3":
                                Console.Clear();
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("_______________");
                                Console.WriteLine("\n");
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("| COURSE PLAN |");
                                Console.WriteLine("");
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("_______________\n\n\n\n");
                                Console.WriteLine("\nChoose one of your class : \n");
                                foreach (string c in professor.NameClasses)
                                {
                                    Console.WriteLine(c + "\n");
                                }
                                _class = Console.ReadLine().ToUpper();
                                professor.CoursePlan.Find(x => x.Class.Contains(_class)).ModifyExamSection();
                                break;

                            case "4":
                                Console.Clear();
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("_______________");
                                Console.WriteLine("\n");
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("| COURSE PLAN |");
                                Console.WriteLine("");
                                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                                Console.Write("_______________\n\n\n\n");
                                Console.WriteLine("\nChoose one of your class : \n");
                                foreach (string c in professor.NameClasses)
                                {
                                    Console.WriteLine(c + "\n");
                                }
                                _class = Console.ReadLine().ToUpper();
                                professor.CoursePlan.Find(x => x.Class.Contains(_class)).ModifyAssignementSection();
                                break;
                        }
                        break;

                    case "7":
                        Console.Clear();
                        professor.DisplayInformationStudent();
                        break;

                    case "8":
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

                    case "9":
                        if (professor.Tutor == true)
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou've been disconnected. \n\nPress any key on your keyboard to close the application.");
                            professor.LoginStatus = false;
                        }
                        break;
                }
            }
        }

        static void AdministratorPortal(Administrator admin, AcademicCalendar academicCalendar)
        {

            admin.LoginStatus = true;
            while (admin.LoginStatus == true)
            {
                Console.Clear();
                Console.WriteLine("\nADMINISTRATOR PORTAL - Virtual Global College \n \n");
                Console.WriteLine($"Administrator Dashboard {admin.FirstName} {admin.Name.ToUpper()} \n\n\n");
                Console.WriteLine("1 - Contact and personal identifying information \n\n");
                Console.WriteLine("2 - Add a new student \n\n");
                Console.WriteLine("3 - Add a new professor \n\n");
                Console.WriteLine("4 - Add a new administrator \n\n");
                Console.WriteLine("5 - Create a course \n\n");
                Console.WriteLine("6 - Manage applications for courses \n\n");
                Console.WriteLine("7 - Manage Timetables \n\n");
                Console.WriteLine("8 - Manage student information (contact, fees, tutor) \n\n");
                Console.WriteLine("9 - Manage professor information (contact, tutoring) \n\n");
                Console.WriteLine("10 - Manage the academic calendar\n\n");
                Console.WriteLine("11 - Disconnect");

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

                    case "7":
                        Console.Clear();
                        admin.ManageTimetables();
                        break;

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
                        admin.ManageAcademicCalendar(academicCalendar);
                        break;

                    case "11":
                        Console.Clear();
                        Console.WriteLine("\nYou've been disconnected. \n\nPress any key on your keyboard to close the application.");
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
            AcademicCalendar academicCalendar = new AcademicCalendar();

            // List of students
            int counter = 0;
            StreamReader fichLect = new StreamReader("StudentsBIS.csv");
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
            fichLect.Close();

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
            fichLect2.Close();

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
            fichLect3.Close();


            //List of classes
            List<string> classes = new List<string>();
            counter = 0;
            StreamReader fichLectClasses = new StreamReader("Classes.csv");
            char[] sepClasses = new char[1] { ';' };
            string lineClasses = "";
            string[] datasClasses = new string[5];
            while (fichLectClasses.Peek() > 0)
            {
                lineClasses = fichLectClasses.ReadLine();
                if (counter == 1)
                {
                    datasClasses = lineClasses.Split(sepClasses);
                    classes.Add(datasClasses[0]);
                    classes.Add(datasClasses[1]);
                    classes.Add(datasClasses[2]);
                    classes.Add(datasClasses[3]);
                    classes.Add(datasClasses[4]);
                }
                counter = 1;
            }
            fichLectClasses.Close();


            //Course Plans
            foreach (string c in classes)
            {
                counter = 0;
                List<CoursePlan> CoursePlans = new List<CoursePlan>();
                StreamReader fichLectCoursePlan = new StreamReader("CoursePlan" + c + ".csv");
                char[] sep4 = new char[1] { ';' };
                string lineCoursePlan = "";
                string[] datasCoursePlan = new string[25];

                string profID = "";

                string s1week1 = "";
                string s1week2 = "";
                string s1week3 = "";
                string s1week4 = "";
                string s1week5 = "";
                string s1week6 = "";
                string s1week7 = "";
                string s1week8 = "";
                string s1week9 = "";
                string s1week10 = "";
                string s1week11 = "";
                string s1week12 = "";

                string s2week1 = "";
                string s2week2 = "";
                string s2week3 = "";
                string s2week4 = "";
                string s2week5 = "";
                string s2week6 = "";
                string s2week7 = "";
                string s2week8 = "";
                string s2week9 = "";
                string s2week10 = "";
                string s2week11 = "";
                string s2week12 = "";


                List<string> exams = new List<string>();
                List<string> assignements = new List<string>();

                while (fichLectCoursePlan.Peek() > 0)
                {
                    lineCoursePlan = fichLectCoursePlan.ReadLine();
                    if (counter == 1 || counter == 7 || counter == 13 || counter == 19 || counter == 25 || counter == 31 || counter == 37 || counter == 43 || counter == 49 || counter == 55)
                    {
                        datasCoursePlan = lineCoursePlan.Split(sep4);
                        profID = datasCoursePlan[0];
                        s1week1 = datasCoursePlan[1];
                        s1week2 = datasCoursePlan[2];
                        s1week3 = datasCoursePlan[3];
                        s1week4 = datasCoursePlan[4];
                        s1week5 = datasCoursePlan[5];
                        s1week6 = datasCoursePlan[6];
                        s1week7 = datasCoursePlan[7];
                        s1week8 = datasCoursePlan[8];
                        s1week9 = datasCoursePlan[9];
                        s1week10 = datasCoursePlan[10];
                        s1week11 = datasCoursePlan[11];
                        s1week12 = datasCoursePlan[12];

                        s2week1 = datasCoursePlan[13];
                        s2week2 = datasCoursePlan[14];
                        s2week3 = datasCoursePlan[15];
                        s2week4 = datasCoursePlan[16];
                        s2week5 = datasCoursePlan[17];
                        s2week6 = datasCoursePlan[18];
                        s2week7 = datasCoursePlan[19];
                        s2week8 = datasCoursePlan[20];
                        s2week9 = datasCoursePlan[21];
                        s2week10 = datasCoursePlan[22];
                        s2week11 = datasCoursePlan[23];
                        s2week12 = datasCoursePlan[24];
                    }

                    if (counter == 3 || counter == 9 || counter == 15 || counter == 21 || counter == 27 || counter == 33 || counter == 39 || counter == 45 || counter == 51 || counter == 57)
                    {
                        datasCoursePlan = lineCoursePlan.Split(sep4);
                        exams = new List<string>();
                        for (int i = 0; i < datasCoursePlan.Length; i++)
                        {
                            if (datasCoursePlan[i] != "")
                            {
                                exams.Add(datasCoursePlan[i]);
                            }
                        }
                    }

                    if (counter == 5 || counter == 11 || counter == 17 || counter == 23 || counter == 29 || counter == 35 || counter == 41 || counter == 47 || counter == 53 || counter == 59)
                    {
                        datasCoursePlan = lineCoursePlan.Split(sep4);
                        assignements = new List<string>();
                        for (int i = 0; i < datasCoursePlan.Length; i++)
                        {
                            if (datasCoursePlan[i] != "")
                            {
                                assignements.Add(datasCoursePlan[i]);
                            }
                        }
                        CoursePlan courseplan = new CoursePlan(profID, c, studentList, professorList, s1week1, s1week2, s1week3, s1week4, s1week5, s1week6, s1week7, s1week8, s1week9, s1week10, s1week11, s1week12, s2week1, s2week2, s2week3, s2week4, s2week5, s2week6, s2week7, s2week8, s2week9, s2week10, s2week11, s2week12);
                        foreach (Professor p in professorList)
                        {
                            if (p.ID == profID)
                            {
                                p.CoursePlan.Add(courseplan);
                            }
                        }
                        CoursePlans.Add(courseplan);
                    }
                    counter++;
                }
                foreach (Student s in studentList)
                {
                    if (s.Class == c)
                    {
                        s.CoursePlan = CoursePlans;
                    }
                }
                fichLectCoursePlan.Close();
            }


            Connection(studentList, professorList, adminList, academicCalendar);



            // Save changes for Students
            StreamWriter fichEcrStudent = new StreamWriter("StudentsBIS.csv");
            string firstLineStudent = "ID (begins by 1 for all students)" + ";" + "First name" + ";" + "Name" + ";" + "Gender" + ";" + "Birthdate" + ";" + "Class" + ";" + "Personal email adress" + ";" + "Phone number" + ";" + "Adress" + ";" + "Password" + ";" + "Tutor's ID" + ";" + "Fees to pay";
            fichEcrStudent.WriteLine(firstLineStudent);
            foreach (Student s in studentList)
            {
                string lineStudent = s.ID + ";" + s.FirstName + ";" + s.Name + ";" + s.Gender + ";" + s.Birthdate.ToShortDateString() + ";" + s.Class + ";" + s.PersoEmail + ";" + s.PhoneNumber + ";" + s.Adress + ";" + s.Password + ";" + s.TutorID + ";" + s.Fees;
                fichEcrStudent.WriteLine(lineStudent);
            }
            fichEcrStudent.Close();


            // Save changes for Professors
            StreamWriter fichEcrProfessor = new StreamWriter("ProfessorsBIS.csv");
            string firstLineProfessor = "ID (begins by 2 for all professors)" + ";" + "First name" + ";" + "Name" + ";" + "Gender" + ";" + "Birthdate" + ";" + "Personal email adress" + ";" + "Phone number" + ";" + "Adress" + ";" + "Password" + ";" + "Subject" + ";" + "Tutor?" + ";" + "Classes";
            fichEcrProfessor.WriteLine(firstLineProfessor);
            foreach (Professor p in professorList)
            {
                string tutor = "";
                if (p.Tutor == true) { tutor = "yes"; }
                else { tutor = "no"; }
                string lineProfessor = p.ID + ";" + p.FirstName + ";" + p.Name + ";" + p.Gender + ";" + p.Birthdate.ToShortDateString() + ";" + p.PersoEmail + ";" + p.PhoneNumber + ";" + p.Adress + ";" + p.Password + ";" + p.Subject + ";" + tutor + ";" + p.NameClass1 + ";" + p.NameClass2 + ";" + p.NameClass3 + ";" + p.NameClass4;
                fichEcrProfessor.WriteLine(lineProfessor);
            }
            fichEcrProfessor.Close();


            // Save changes for Administrators
            StreamWriter fichEcrAdmin = new StreamWriter("AdministratorsBIS.csv");
            string firstLineAdmin = "ID (begins by 3 for all administrators)" + ";" + "First name" + ";" + "Name" + ";" + "Gender" + ";" + "Birthdate" + ";" + "Personal email adress" + ";" + "Phone number" + ";" + "Adress" + ";" + "Password";
            fichEcrAdmin.WriteLine(firstLineAdmin);
            foreach (Administrator a in adminList)
            {
                string lineAdmin = a.ID + ";" + a.FirstName + ";" + a.Name + ";" + a.Gender + ";" + a.Birthdate.ToShortDateString() + ";" + a.PersoEmail + ";" + a.PhoneNumber + ";" + a.Adress + ";" + a.Password;
                fichEcrAdmin.WriteLine(lineAdmin);
            }
            fichEcrAdmin.Close();


            //Save changes for Gradebook
            foreach (string c in classes)
            {
                string filename = "GradeBookClass" + c + "BIS.csv";
                StreamWriter fichEcrGradebook = new StreamWriter(filename);
                string firstLineGradebook = "StudentID" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams" + ";" + "Subject" + ";" + "Grades Assignements" + ";" + "Grades Exams";
                fichEcrGradebook.WriteLine(firstLineGradebook);

                foreach (Student s in studentList)
                {
                    string lineGradebook = s.ID + ";";
                    if (s.Class == c)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            lineGradebook += s.Gradebook.Subjects[i] + ";" + s.Gradebook.GradesAssignements[i] + ";" + s.Gradebook.GradesExams[i] + ";";
                        }
                        fichEcrGradebook.WriteLine(lineGradebook);
                    }
                }
                fichEcrGradebook.Close();
            }


            //Save changes for Course Plan
            foreach (string c in classes)
            {
                string filename = "CoursePlan" + c + "BIS.csv";
                StreamWriter fichEcrCoursePlan = new StreamWriter(filename);

                string firstLineCoursePlan = "Professor ID" + ";" + "Semester1 Week1" + ";" + "S1W2" + ";" + "S1W3" + ";" + "S1W4" + ";" + "S1W5" + ";" + "S1W6" + ";" + "S1W7" + ";" + "S1W8" + ";" + "S1W9" + ";" + "S1W10" + ";" + "S1W11" + ";" + "S1W12" + ";" + "Semester2 Week1" + ";" + "S2W2" + ";" + "S2W3" + ";" + "S2W4" + ";" + "S2W5" + ";" + "S2W6" + ";" + "S2W7" + ";" + "S2W8" + ";" + "S2W9" + ";" + "S2W10" + ";" + "S2W11" + ";" + "S2W12";
                string line2CoursePlan = "";
                string line3CoursePlan = "";
                string line4CoursePlan = "";
                string line5CoursePlan = "";
                string line6CoursePlan = "";

                foreach (Professor p in professorList)
                {
                    line3CoursePlan = "Exams" + ";";
                    line4CoursePlan = "";
                    line5CoursePlan = "Assignements" + ";";
                    line6CoursePlan = "_";

                    if (p.NameClasses.Contains(c))
                    {
                        fichEcrCoursePlan.WriteLine(firstLineCoursePlan);

                        line2CoursePlan = p.ID + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week1 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week2 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week3 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week4 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week5 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week6 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week7
                        + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week8 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week9 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week10 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week11 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S1week12 + ";"
                        + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week1 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week2 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week3 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week4 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week5 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week6 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week7 + ";"
                        + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week8 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week9 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week10 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week11 + ";" + p.CoursePlan.Find(x => x.Class.Contains(c)).S2week12;
                        fichEcrCoursePlan.WriteLine(line2CoursePlan);

                        fichEcrCoursePlan.WriteLine(line3CoursePlan);

                        foreach (string ex in p.CoursePlan.Find(x => x.Class.Contains(c)).Exams)
                        {
                            line4CoursePlan += ex + ";";
                        }
                        fichEcrCoursePlan.WriteLine(line4CoursePlan);

                        fichEcrCoursePlan.WriteLine(line5CoursePlan);

                        foreach (string assign in p.CoursePlan.Find(x => x.Class.Contains(c)).Assignments)
                        {
                            line6CoursePlan += assign + ";";
                        }
                        fichEcrCoursePlan.WriteLine(line6CoursePlan);
                    }
                }
                fichEcrCoursePlan.Close();
            }


            //Save changes for Timetable Students
            StreamWriter fichEcrTimetableStudents = new StreamWriter("Timetables_StudentsBIS.csv");
            string firstLineTimetable = "StudentID" + ";" + "CourseM1 index" + ";" + "ProfID" + ";" + "Subject" + ";" + " Attendance at this course" + ";" + " Number of this course" + ";" + "CourseM2 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseM3 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseM4 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseM5 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseT1 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseT2 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseT3 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseT4 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseT5 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseW1 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseW2 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseW3 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseW4 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseW5 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseTH1 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseTH2 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseTH3 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseTH4 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseTH5 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseF1 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseF2 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseF3 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseF4 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "CourseF5 index" + ";" + "ProfID" + ";" + "Subject" + ";" + "Attendance at this course" + ";" + "Number of this course" + ";" + "Class";
            fichEcrTimetableStudents.WriteLine(firstLineTimetable);
            foreach (Student s in studentList)
            {
                string lineTimetable = s.ID + ";";
                foreach (Course c in s.Courses)
                {
                    lineTimetable += c.CourseIndex + ";" + c.ProfessorID_or_NameOfClass + ";" + c.Subject + ";" + c.Attendance + ";" + c.Number_of_times + ";";
                }
                lineTimetable += s.Class + ";";
                fichEcrTimetableStudents.WriteLine(lineTimetable);
            }
            fichEcrTimetableStudents.Close();

            Console.ReadKey();
        }
    }
}
