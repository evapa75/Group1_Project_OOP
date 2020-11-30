using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Group1_OOP
{
    public class Student : Person
    {
        public int Year { get; set; }
        public string Class { get; set; }
        public double Fees { get; set; }
        public string ModePayment { get; set; }
        public string TutorID { get; set; }

        public List<Course> Courses { get; set; }
        public Timetable Timetable { get; set; }
        public GradeBook GradeBook { get; set; }


        public Student(string id, string firstName, string name, string gender, string birthdate, string _class, string persoEmailAdress, string phoneNumber, string adress, string password, string tutorID, double fees)
            : base(id, firstName, name, gender, birthdate, persoEmailAdress, phoneNumber, adress, password)
        {
            Class = _class;
            char ch = _class[1];
            Year = (int)Char.GetNumericValue(ch);
            Fees = fees;
            TutorID = tutorID;
            Courses = new List<Course>();

            //Remplissage de la liste de cours Courses
            List<string> listCourses = new List<string>();
            SortedList<string, List<string>> list = new SortedList<string, List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Timetables_Students.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[126];
            while (fichLect.Peek() > 0)
            {
                line = fichLect.ReadLine(); //Lecture d'une ligne
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

            int key = list.IndexOfKey(ID);
            //Console.WriteLine(key);
            for (int i = 0; i < datas.Length - 1; i++)
            {
                listCourses.Add(list.ElementAt(key).Value[i]);
                //Console.WriteLine(list.ElementAt(key).Value[i]);
            }

            //Remplissage de la liste des cours
            for (int i = 0; i < 125; i = i + 5)
            {
                Course c = new Course(Convert.ToDouble(listCourses[i]), listCourses[i + 1], listCourses[i + 2], Convert.ToInt32(listCourses[i + 3]), Convert.ToInt32(listCourses[i + 4]));
                //Console.WriteLine(Convert.ToDouble(listCourses[i]) + ";" + listCourses[i + 1] + ";" + listCourses[i + 2] + ";" + listCourses[i + 3] + ";" + listCourses[i + 4]);
                Courses.Add(c);
            }

            //Création de l'edt à partir de la liste de cours
            Timetable = new Timetable(Courses);

            GradeBook = new GradeBook(ID, Class, Courses);
        }

        public override string SchoolEmailAdress()
        {
            return ID + "@student-vgc.ie";
        }

        public override string ToString()
        {
            return $"Status : Student \nYear : {Year} \nClass : {Class} \n {base.ToString()} \n  ";
        }

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
                    $"\nYear of studies : {Year}" +
                    $"\nClass : {Class}" +
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

        public void ShowCourses()
        {
            Console.Clear();
            bool finish = false;
            while (finish == false)
            {
                for (int i = 0; i < 40; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("YOUR COURSES \n\n");
                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].Subject != "Free")
                    {
                        Console.WriteLine(Courses[i].Subject + " with " + Courses[i].Teacher);
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
                for (int i = 0; i < 70; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("REGISTER FOR A COURSE \n\n");

                Console.Write("Here is the list of all courses available at Virtual Global College :\n");

                List<List<string>> listCourses = new List<List<string>>();

                int counter = 0;
                StreamReader fichLect = new StreamReader("Courses.csv");
                char[] sep = new char[1] { ';' };
                string line = "";
                string[] datas = new string[4];


                while (fichLect.Peek() > 0)
                {
                    line = fichLect.ReadLine(); //Lecture d'une ligne
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

                int index = 1;
                foreach (List<string> l in listCourses)
                {
                    Console.WriteLine(index + "- " + l[0] + " - with Professor " + l[2] + " " + l[3]);
                    index++;
                }

                Console.WriteLine("\n\nWhich course do you want to register for ?");
                string choice = Console.ReadLine();
                ApplicationForCourse application = new ApplicationForCourse(ID, FirstName, Name, Year, Class, Courses, Timetable, choice);
                
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
                    Console.WriteLine("You have already reached the maximum of 10 courses possible.");
                }
                else
                {
                    Console.WriteLine("\n\nYour request will be processed by an administrator as soon as possible.");
                }


                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }

        public void ShowAttendance()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 40; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("ATTENDANCE \n\n");

                foreach (Course c in Courses)
                {
                    if (c.Subject != "Free")
                    {
                        Console.WriteLine(c.Subject + " : " + c.Attendance + "/" + c.Number_of_times);
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

        //public GradeBook CreateGradeBook()
        //{
        //    string nomFichier = "GradeBookClass" + Class + ".csv";

        //    List<string> ListProfID = new List<string>();
        //    List<string> ListGrades = new List<string>();
        //    SortedList<string, List<string>> list = new SortedList<string, List<string>>();

        //    int counter = 0;
        //    StreamReader fichLect = new StreamReader(nomFichier);
        //    char[] sep = new char[1] { ';' };
        //    string line = "";
        //    string[] datas = new string[21];
        //    while (fichLect.Peek() > 0)
        //    {
        //        line = fichLect.ReadLine(); //Lecture d'une ligne
        //        if (counter == 1)
        //        {
        //            datas = line.Split(sep);
        //            string studentID = datas[0];
        //            List<string> l = new List<string>();
        //            for (int i = 1; i < datas.Length; i++)
        //            {
        //                l.Add(datas[i]);
        //            }
        //            list.Add(studentID, l);
        //        }
        //        counter = 1;
        //    }

        //    int key = list.IndexOfKey(ID);
        //    //Console.WriteLine(key);
        //    for (int i = 0; i < datas.Length - 1; i=i+2)
        //    {
        //        ListProfID.Add(list.ElementAt(key).Value[i]);
        //        ListGrades.Add(list.ElementAt(key).Value[i+1]);
        //    }

        //    List<string> Subjects = FindSubjects(ListProfID);

        //    GradeBook gb = new GradeBook(Subjects, ListGrades);
        //}

        //public List<string> FindSubjects(List<string> ListProfID)
        //{
        //    List<string> Subjects = new List<string>();
        //    foreach (string profID in ListProfID)
        //    {
        //        Course c  = Courses.Find(x => x.TeacherID_or_NameOfClass.Contains(profID));
        //        Subjects.Add(c.Subject);
        //    }
        //    return Subjects;
        //}




        public void ShowGradeBook()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 40; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("GRADEBOOK \n\n");
                Console.WriteLine("Subjects :                         Grades\n");

                for (int i = 0; i < Gradebook.Subjects.Count; i++)
                {
                    Console.WriteLine(Gradebook.Subjects[i] + " : " + Gradebook.Grades[i] + "\n");
                }

                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }

        public void PayementOfFees()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 40; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("PAYEMENT OF FEES \n\n");

                Console.WriteLine("The amount of your current fees to be paid is : " + Fees + " euros");
                if (Fees != 0)
                {
                    Console.WriteLine("\nDo you want to pay some of them right now ? \n1- YES \n2- NO");
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
                                        Console.WriteLine("\nYou've paid all your fees");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nHere is the new amount of your fees : " + Fees + " euros");
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
