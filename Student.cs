using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Group1_OOP
{
    public class Student : Person
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD

        public int Year { get; set; }
        public string Class { get; set; }
        public double Fees { get; set; }
        public string ModePayment { get; set; }
        public string TutorID { get; set; }

        public List<Course> Courses { get; set; }
        public List<string> CoursesName { get; set; }
        public int NumberOfCourses { get; set; }
        public Timetable Timetable { get; set; }
        public GradeBook Gradebook { get; set; }

        public List<CoursePlan> CoursePlan { get; set; }

        public List<Student> StudentList { get; set; }

        public Student(string id, string firstName, string name, string gender, string birthdate, string _class, string persoEmailAdress, string phoneNumber, string adress, string password, string tutorID, double fees, List<Student> studentList)
            : base(id, firstName, name, gender, birthdate, persoEmailAdress, phoneNumber, adress, password)
        {
            Class = _class;
            char ch = _class[1];
            Year = (int)Char.GetNumericValue(ch);
            Fees = fees;
            TutorID = tutorID;
            Courses = new List<Course>();
            StudentList = studentList;

            // Filling in the course list Courses
            List<string> listCourses = new List<string>();
            SortedList<string, List<string>> list = new SortedList<string, List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Timetables_Students.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[126];
            while (fichLect.Peek() > 0)
            {
                line = fichLect.ReadLine();
                if (counter == 1)
                {
                    datas = line.Split(sep);
                    string studentID = datas[0];
                    List<string> l = new List<string>();
                    for (int i = 1; i < datas.Length; i++)
                    {
                        l.Add(datas[i]);
                    }
                    list.Add(studentID, l);
                }
                counter = 1;
            }
            fichLect.Close();


            int key = list.IndexOfKey(ID);
            //Console.WriteLine(key);
            for (int i = 0; i < datas.Length - 1; i++)
            {
                listCourses.Add(list.ElementAt(key).Value[i]);
            }

            // Filling in the course list
            for (int i = 0; i < 125; i = i + 5)
            {
                Course c = new Course(Convert.ToDouble(listCourses[i]), listCourses[i + 1], listCourses[i + 2], Convert.ToInt32(listCourses[i + 3]), Convert.ToInt32(listCourses[i + 4]), studentList);
                Courses.Add(c);
            }

            CoursesName = new List<string>();
            foreach (Course c in Courses)
            {
                if (c.Subject != "Free")
                {
                    CoursesName.Add(c.Subject);
                }
            }

            NumberOfCourses = 0;
            foreach (Course c in Courses)
            {
                if (c.Subject != "Free")
                {
                    NumberOfCourses++;
                }
            }


            //Creation of the edt from the list of courses
            Timetable = new Timetable(Courses);

            //Création du livret de notes de l'étudiant
            Gradebook = new GradeBook(ID, Class, Courses);

            //Creation of the student's gradebook
            CoursePlan = new List<CoursePlan>();
        }

        public override string SchoolEmailAdress()
        {
            return ID + "@student-vgc.ie";
        }

        public override string ToString()
        {
            return $"Status : Student \nYear : {Year} \nClass : {Class} \n {base.ToString()} \n  ";
        }



        // 1 - Contact and personal identifying information
        public void ShowAndModifyPersonalInformation(int mode)
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                Console.WriteLine($"\n\nStudent Profile {FirstName} { Name.ToUpper()} \n\n");
                Console.WriteLine("\nPersonal identifying information : \n\n" +
                    FirstName + " " + Name.ToUpper() +
                    $"\nID : {ID}" +
                    $"\nYear of studies : {Year}" +
                    $"\nClass : {Class}" +
                    $"\nGender : {Gender}" +
                    $"\nBirthdate : {Birthdate.ToShortDateString()}\n\n");
                Console.WriteLine("\nContact information : \n\n" +
                    $"Adress : {Adress}" +
                    $"\nPhone Number : {PhoneNumber}" +
                    $"\nSchool email adress : {SchoolEmail}" +
                    $"\nPersonnal email adress : {PersoEmail}\n\n\n");

                if (mode == 1)
                {
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
                else
                {
                    finish = true;
                }
            }
        }



        // 2 - Courses
        public void ShowCourses()
        {
            Console.Clear();
            bool finish = false;
            while (finish == false)
            {
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("_______________");
                Console.WriteLine("\n");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("| YOUR COURSES |");
                Console.WriteLine("");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("_______________\n\n");

                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].Subject != "Free" && Courses[i].Subject != "")
                    {
                        Console.WriteLine("\n" + Courses[i].Subject);
                    }
                }

                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }


        }
        public void RegisterForACourse()
        {
            Console.Clear();
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("_______________________");
                Console.WriteLine("\n");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("| REGISTER FOR A COURSE |");
                Console.WriteLine("");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("_______________________\n\n");

                Console.Write("\n\nHere is the list of all courses available at Virtual Global College :\n\n");

                List<List<string>> listCourses = new List<List<string>>();

                int counter = 0;
                StreamReader fichLect = new StreamReader("Courses.csv");
                char[] sep = new char[1] { ';' };
                string line = "";
                string[] datas = new string[4];


                while (fichLect.Peek() > 0)
                {
                    line = fichLect.ReadLine();
                    if (counter == 1)
                    {
                        datas = line.Split(sep);
                        List<string> l = new List<string>();
                        for (int i = 0; i < datas.Length; i++)
                        {
                            l.Add(datas[i]);
                        }
                        listCourses.Add(l);
                    }
                    counter = 1;
                }

                fichLect.Close();

                int index = 1;
                foreach (List<string> l in listCourses)
                {
                    Console.WriteLine("\n" + index + " - " + l[0] + " - with Professor " + l[2] + " " + l[3]);
                    index++;
                }

                Console.WriteLine("\n\nWhich course do you want to register for ?");
                int choice = Convert.ToInt32(Console.ReadLine());

                int number = 0;
                foreach (Course c in Courses)
                {
                    if (c.Subject != "Free")
                    {
                        number++;
                    }
                }
                if (number >= 10)
                {
                    Console.WriteLine("\nYou have already reached the maximum of 10 courses possible.");
                }
                else
                {
                    List<string> LIST = listCourses[choice - 1];
                    if (CoursesName.Contains(LIST[0]))
                    {
                        Console.WriteLine("\n\nYou are already registered for this course.");
                    }
                    else
                    {
                        ApplicationForCourse application = new ApplicationForCourse(ID, FirstName, Name, Year, Class, Courses, Timetable, LIST[0], LIST[1], LIST[2], LIST[3], StudentList);
                        application.AddNewApplication();
                        Console.WriteLine("\n\nYour request will be processed by an administrator as soon as possible.");
                    }
                }

                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }



        // 5 - Attendance
        public void ShowAttendance()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();

                for (int i = 0; i < 92; i++) { Console.Write(" "); }
                Console.Write("_____________");
                Console.WriteLine("\n");
                for (int i = 0; i < 92; i++) { Console.Write(" "); }
                Console.Write("| ATTENDANCE |");
                Console.WriteLine("");
                for (int i = 0; i < 92; i++) { Console.Write(" "); }
                Console.Write("_____________\n\n\n\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Taken sessions / Total number of sessions \n\n");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (Course c in Courses)
                {
                    if (c.Subject != "Free")
                    {
                        Console.WriteLine("\n" + c.Subject + " : " + c.Attendance + "/" + c.Number_of_times);
                    }
                }

                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }



        // 6 - Gradebook
        public void ShowGradeBook(int mode)
        {
            if (mode == 1)
            {
                bool finish = false;
                while (finish == false)
                {
                    Console.Clear();
                    for (int i = 0; i < 92; i++) { Console.Write(" "); }
                    Console.Write("_____________");
                    Console.WriteLine("\n");
                    for (int i = 0; i < 92; i++) { Console.Write(" "); }
                    Console.Write("| GRADEBOOK |");
                    Console.WriteLine("");
                    for (int i = 0; i < 92; i++) { Console.Write(" "); }
                    Console.Write("_____________\n\n\n\n");

                    Console.WriteLine("\n" + FirstName + " " + Name + " " + Class + "\n\n");
                    for (int i = 0; i < Gradebook.Subjects.Count; i++)
                    {
                        Console.WriteLine(Gradebook.Subjects[i] + " : " + "\n -> Assignements : " + Gradebook.GradesAssignements[i] + "\n -> Exams : " + Gradebook.GradesExams[i] + "\n");
                    }

                    Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                    int decision = Convert.ToInt32(Console.ReadLine());
                    if (decision == 1)
                    {
                        finish = true;
                    }
                }
            }
            if (mode == 2)
            {
                for (int i = 0; i < 92; i++) { Console.Write(" "); }
                Console.Write("_____________");
                Console.WriteLine("\n");
                for (int i = 0; i < 92; i++) { Console.Write(" "); }
                Console.Write("| GRADEBOOK |");
                Console.WriteLine("");
                for (int i = 0; i < 92; i++) { Console.Write(" "); }
                Console.Write("_____________\n\n\n\n");

                Console.WriteLine("\n" + FirstName + " " + Name + " " + Class + "\n\n");
                for (int i = 0; i < Gradebook.Subjects.Count; i++)
                {
                    Console.WriteLine(Gradebook.Subjects[i] + " : " + "\n -> Assignements : " + Gradebook.GradesAssignements[i] + "\n -> Exams : " + Gradebook.GradesExams[i] + "\n");
                }
            }
        }



        // 7 - Payment of fees
        public void PayementOfFees()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("___________________");
                Console.WriteLine("\n");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("| PAYEMENT OF FEES |");
                Console.WriteLine("");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("___________________\n\n\n\n\n");

                Console.Write("The amount of your current fees to be paid is : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Fees + " euros");
                Console.ForegroundColor = ConsoleColor.White;

                if (Fees != 0)
                {
                    Console.WriteLine("\n\nDo you want to pay some of them right now ? \n1- YES \n2- NO");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            bool paid = false;
                            while (paid == false)
                            {
                                Console.WriteLine("\n\nWhat amount do you want to pay right away ? ");
                                double amount = Convert.ToDouble(Console.ReadLine());
                                if (amount > 0 && amount <= Fees)
                                {
                                    Fees = Fees - amount;
                                    if (Fees == 0)
                                    {
                                        Console.WriteLine("\n\nYou've paid all your fees");
                                    }
                                    else
                                    {
                                        Console.Write("\n\n\n\nHere is the new amount of your fees : ");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(Fees + " euros");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    paid = true;
                                }
                            }
                            break;
                    }
                }
                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }

            }
        }
    }
}
