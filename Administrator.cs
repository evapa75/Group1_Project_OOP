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
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD


        public List<Student> StudentList { get; set; }
        public List<Professor> ProfessorList { get; set; }
        public List<Administrator> AdminList { get; set; }
        public List<ApplicationForCourse> ApplicationForCourseList { get; set; }


        public Administrator(string id, string firstName, string name, string gender, string birthdate, string persoEmailAdress, string phoneNumber, string adress, string password, List<Student> studentList, List<Professor> professorList, List<Administrator> adminList)
            : base(id, firstName, name, gender, birthdate, persoEmailAdress, phoneNumber, adress, password)
        {
            StudentList = studentList;
            ProfessorList = professorList;
            AdminList = adminList;
        }

        public override string ToString()
        {
            return $"Status : Administrator \n{base.ToString()} ";
        }

        public override string SchoolEmailAdress()
        {
            return ID + "@admin.faculty-vgc.ie";
        }

        public string FirstPassword()
        {
            string password = "";
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                password += (char)random.Next('a', 'z');
            }
            return password;
        }



        // 1 - Contact and personal identifying information
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


        // 2 - Add a new student
        public void AddStudent()
        {
            bool finish = false;
            while (finish == false)
            {
                bool complete = false;
                string firstName = "";
                string name = "";
                string gender = "";
                string birthdate = "";
                string _class = "";
                string personalEmailAdress = "";
                string phoneNumber = "";
                string adress = "";

                string password = FirstPassword();
                int fees = 5000;

                Student s = StudentList.ElementAt(StudentList.Count - 1);
                int i = Convert.ToInt32(s.ID) + 1;
                string id = Convert.ToString(i);

                string tutorID = "";
                List<Professor> tutors = new List<Professor>();
                foreach (Professor p in ProfessorList)
                {
                    if (p.Tutor == true)
                    {
                        tutors.Add(p);
                    }
                }

                while (complete == false)
                {
                    Console.Clear();
                    for (int j = 0; j < 90; j++) { Console.Write(" "); }
                    Console.WriteLine("ADD A NEW STUDENT \n\n");

                    Console.WriteLine("Let's complete the registration of a new student. \n\nPlease complete the following information :");

                    Console.WriteLine(" \nFirst Name :");
                    firstName = Console.ReadLine();

                    Console.WriteLine(" \nName :");
                    name = Console.ReadLine();

                    Console.WriteLine(" \nGender : Female or Male");
                    gender = Console.ReadLine();

                    Console.WriteLine(" \nBirthdate : dd/mm/yyyy");
                    birthdate = Console.ReadLine();

                    Console.WriteLine("\nIn which year do you want to register this student ? (1, 2, 3, 4 or 5 ?)");
                    int year = Convert.ToInt32(Console.ReadLine());
                    _class = ChooseClass(year, "s");
                    CompleteTimetableNewStudent(id, _class);
                    CompleteGradebookNewStudent(id, _class);

                    Console.WriteLine(" \nPersonal email adress :");
                    personalEmailAdress = Console.ReadLine();

                    Console.WriteLine(" \nTelephone number :");
                    phoneNumber = Console.ReadLine();

                    Console.WriteLine(" \nAdress (street number, street, postal code, city) :");
                    adress = Console.ReadLine();

                    bool test = false;
                    while (test == false)
                    {
                        Console.Clear();
                        Console.WriteLine("\nChoose a new tutor for the student in the following list (max 10 students for a tutor) :");
                        foreach (Professor p in tutors)
                        {
                            Console.WriteLine($"\n{p.FirstName} {p.Name} - {p.Subject} Professor ID : {p.ID} - Number of students tutored: " + p.TutorStudentList.Count);
                        }
                        Console.WriteLine("ID of the new tutor : ");
                        string answer = Console.ReadLine();
                        if (tutors.Contains(tutors.Find(x => x.ID.Contains(answer))))
                        {
                            tutorID = answer;
                        }
                    }

                    if (tutorID != null && firstName != null && name != null && gender != null && _class != null && birthdate != null && personalEmailAdress != null && phoneNumber != null && adress != null)
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

                Student student = new Student(id, firstName, name, gender, birthdate, _class, personalEmailAdress, phoneNumber, adress, password, tutorID, fees, StudentList);
                //Console.WriteLine(student.ID, student.FirstName, student.Name, student.Gender, student.Birthdate, student.Class, student.PersoEmail, student.PhoneNumber, student.Adress, student.Password, student.TutorID, student.Fees);
                StudentList.Add(student);

                ProfessorList.Find(x => x.ID.Contains(tutorID)).TutorStudentList.Add(student);

                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }
        public string ChooseClass(int year, string mode)
        {
            string _class = "";
            List<string> classesYear1 = new List<string>();
            List<string> classesYear2 = new List<string>();
            List<string> classesYear3 = new List<string>();
            List<string> classesYear4 = new List<string>();
            List<string> classesYear5 = new List<string>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Classes.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[5];
            while (fichLect.Peek() > 0)
            {
                line = fichLect.ReadLine();
                if (counter == 1)
                {
                    datas = line.Split(sep);
                    string classYear1 = datas[0];
                    string classYear2 = datas[1];
                    string classYear3 = datas[2];
                    string classYear4 = datas[3];
                    string classYear5 = datas[4];

                    classesYear1.Add(classYear1);
                    classesYear2.Add(classYear2);
                    classesYear3.Add(classYear3);
                    classesYear4.Add(classYear4);
                    classesYear5.Add(classYear5);
                }
                counter = 1;
            }
            fichLect.Close();

            string answer = "";
            if (year == 1)
            {
                bool exist = false;
                while (exist == false)
                {
                    if (mode == "s")
                    {
                        Console.WriteLine("\nIn which class do you want to register this student ? ");
                        for (int i = 0; i < classesYear1.Count; i++)
                        {
                            Console.WriteLine(classesYear1[i]);
                        }
                        answer = Console.ReadLine();

                        for (int i = 0; i < classesYear1.Count; i++)
                        {
                            if (classesYear1[i] == answer)
                            {
                                exist = true;
                                _class = answer;
                            }
                        }
                    }

                    if (mode == "p")
                    {
                        Console.WriteLine("\nChoose a class : ");
                        for (int i = 0; i < classesYear1.Count; i++)
                        {
                            Console.WriteLine(classesYear1[i]);
                        }
                        answer = Console.ReadLine();

                        if (StudentList.Find(x => x.Class.Contains(answer)).NumberOfCourses == 10)
                        {
                            Console.WriteLine("This class has reached its maximum possible number of courses (10)");
                            System.Threading.Thread.Sleep(4000);
                            _class = "";
                            exist = true;
                        }
                        else
                        {
                            for (int i = 0; i < classesYear1.Count; i++)
                            {
                                if (classesYear1[i] == answer)
                                {
                                    exist = true;
                                    _class = answer;
                                }
                            }
                        }
                    }
                }
            }

            if (year == 2)
            {
                bool exist = false;
                while (exist == false)
                {
                    if (mode == "s")
                    {
                        Console.WriteLine("\nIn which class do you want to register this student ? ");
                        for (int i = 0; i < classesYear2.Count; i++)
                        {
                            Console.WriteLine(classesYear2[i]);
                        }
                        answer = Console.ReadLine();

                        for (int i = 0; i < classesYear2.Count; i++)
                        {
                            if (classesYear2[i] == answer)
                            {
                                exist = true;
                                _class = answer;
                            }
                        }
                    }

                    if (mode == "p")
                    {
                        Console.WriteLine("\nChoose a class : ");
                        for (int i = 0; i < classesYear2.Count; i++)
                        {
                            Console.WriteLine(classesYear2[i]);
                        }
                        answer = Console.ReadLine();

                        if (StudentList.Find(x => x.Class.Contains(answer)).NumberOfCourses == 10)
                        {
                            Console.WriteLine("This class has reached its maximum possible number of courses (10)");
                            System.Threading.Thread.Sleep(4000);
                            _class = "";
                            exist = true;
                        }

                        else
                        {
                            for (int i = 0; i < classesYear2.Count; i++)
                            {
                                if (classesYear2[i] == answer)
                                {
                                    exist = true;
                                    _class = answer;
                                }
                            }
                        }
                    }
                }
            }

            if (year == 3)
            {
                bool exist = false;
                while (exist == false)
                {
                    if (mode == "s")
                    {
                        Console.WriteLine("\nIn which class do you want to register this student ? ");
                        for (int i = 0; i < classesYear3.Count; i++)
                        {
                            Console.WriteLine(classesYear3[i]);
                        }
                        answer = Console.ReadLine();

                        for (int i = 0; i < classesYear3.Count; i++)
                        {
                            if (classesYear3[i] == answer)
                            {
                                exist = true;
                                _class = answer;
                            }
                        }
                    }

                    if (mode == "p")
                    {
                        Console.WriteLine("\nChoose a class : ");
                        for (int i = 0; i < classesYear3.Count; i++)
                        {
                            Console.WriteLine(classesYear3[i]);
                        }
                        answer = Console.ReadLine();

                        if (StudentList.Find(x => x.Class.Contains(answer)).NumberOfCourses == 10)
                        {
                            Console.WriteLine("This class has reached its maximum possible number of courses (10)");
                            System.Threading.Thread.Sleep(4000);
                            _class = "";
                            exist = true;
                        }

                        else
                        {
                            for (int i = 0; i < classesYear3.Count; i++)
                            {
                                if (classesYear3[i] == answer)
                                {
                                    exist = true;
                                    _class = answer;
                                }
                            }
                        }
                    }
                }
            }

            if (year == 4)
            {
                bool exist = false;
                while (exist == false)
                {
                    if (mode == "s")
                    {
                        Console.WriteLine("\nIn which class do you want to register this student ? ");
                        for (int i = 0; i < classesYear4.Count; i++)
                        {
                            Console.WriteLine(classesYear4[i]);
                        }
                        answer = Console.ReadLine();

                        for (int i = 0; i < classesYear4.Count; i++)
                        {
                            if (classesYear4[i] == answer)
                            {
                                exist = true;
                                _class = answer;
                            }
                        }
                    }

                    if (mode == "p")
                    {
                        Console.WriteLine("\nChoose a class : ");
                        for (int i = 0; i < classesYear4.Count; i++)
                        {
                            Console.WriteLine(classesYear4[i]);
                        }
                        answer = Console.ReadLine();

                        if (StudentList.Find(x => x.Class.Contains(answer)).NumberOfCourses == 10)
                        {
                            Console.WriteLine("This class has reached its maximum possible number of courses (10)");
                            System.Threading.Thread.Sleep(4000);
                            _class = "";
                            exist = true;
                        }

                        else
                        {
                            for (int i = 0; i < classesYear4.Count; i++)
                            {
                                if (classesYear4[i] == answer)
                                {
                                    exist = true;
                                    _class = answer;
                                }
                            }
                        }
                    }
                }
            }

            if (year == 5)
            {
                bool exist = false;
                while (exist == false)
                {
                    if (mode == "s")
                    {
                        Console.WriteLine("\nIn which class do you want to register this student ? ");
                        for (int i = 0; i < classesYear5.Count; i++)
                        {
                            Console.WriteLine(classesYear5[i]);
                        }
                        answer = Console.ReadLine();

                        for (int i = 0; i < classesYear5.Count; i++)
                        {
                            if (classesYear5[i] == answer)
                            {
                                exist = true;
                                _class = answer;
                            }
                        }
                    }

                    if (mode == "p")
                    {
                        Console.WriteLine("\nChoose a class : ");
                        for (int i = 0; i < classesYear5.Count; i++)
                        {
                            Console.WriteLine(classesYear5[i]);
                        }
                        answer = Console.ReadLine();

                        if (StudentList.Find(x => x.Class.Contains(answer)).NumberOfCourses == 10)
                        {
                            Console.WriteLine("This class has reached its maximum possible number of courses (10)");
                            System.Threading.Thread.Sleep(4000);
                            _class = "";
                            exist = true;
                        }

                        else
                        {
                            for (int i = 0; i < classesYear5.Count; i++)
                            {
                                if (classesYear5[i] == answer)
                                {
                                    exist = true;
                                    _class = answer;
                                }
                            }
                        }
                    }
                }
            }

            return _class;
        }
        public void CompleteTimetableNewStudent(string id, string _class)
        {
            List<List<string>> list = new List<List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Timetables_Students.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[127];
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
                    list.Add(l);
                }
                counter = 1;
            }
            fichLect.Close();

            bool copy = false;
            string[] tab = new string[127];
            List<string> courses = new List<string>();
            foreach (List<string> l in list)
            {
                if (l[l.Count - 1] == _class && copy == false)
                {
                    l.CopyTo(tab);
                    for (int i = 0; i < tab.Length; i++)
                    {
                        courses.Add(tab[i]);
                    }
                    copy = true;
                }
            }
            courses[0] = id;

            string filename = "Timetables_Students.csv";
            StreamWriter fichEcr = new StreamWriter(filename, true);
            string lastLine = "";
            foreach (string course in courses)
            {
                lastLine += course + ";";
            }
            fichEcr.WriteLine(lastLine);
            fichEcr.Close();

        }
        public void CompleteGradebookNewStudent(string id, string _class)
        {
            List<string> GradebookNewStudent = new List<string>();
            List<List<string>> list = new List<List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("GradeBookClass" + _class + ".csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[21];
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
                    list.Add(l);
                }
                counter = 1;
            }
            fichLect.Close();


            string[] tab = new string[21];
            list[0].CopyTo(tab);
            for (int i = 0; i < tab.Length; i++)
            {
                GradebookNewStudent.Add(tab[i]);
            }
            GradebookNewStudent[0] = id;
            for (int i = 2; i < GradebookNewStudent.Count; i = i + 2)
            {
                GradebookNewStudent[i] = " ";
            }

            string filename = "GradeBookClass" + _class + ".csv";
            StreamWriter fichEcr = new StreamWriter(filename, true);
            string lastLine = "";
            foreach (string word in GradebookNewStudent)
            {
                lastLine += word + ";";
            }
            fichEcr.WriteLine(lastLine);
            fichEcr.Close();
        }


        // 3 - Add a new professor
        public void AddProfessor()
        {
            bool finish = false;
            while (finish == false)
            {
                bool complete = false;
                string firstName = "";
                string name = "";
                string gender = "";
                string birthdate = "";
                string personalEmailAdress = "";
                string phoneNumber = "";
                string adress = "";
                string subject = "";
                string password = FirstPassword();

                string tutor = "no";
                string name_class1 = "";
                string name_class2 = "";
                string name_class3 = "";
                string name_class4 = "";

                Professor p = ProfessorList.ElementAt(ProfessorList.Count - 1);
                int i = Convert.ToInt32(p.ID) + 1;
                string id = Convert.ToString(i);

                while (complete == false)
                {
                    Console.Clear();
                    for (int j = 0; j < 90; j++) { Console.Write(" "); }
                    Console.WriteLine("ADD A NEW PROFESSOR \n\n");
                    Console.WriteLine("Let's complete the registration of a new professor. \n\nPlease complete the following information about this professor:");

                    Console.WriteLine(" \nFirst Name :");
                    firstName = Console.ReadLine();

                    Console.WriteLine(" \nName :");
                    name = Console.ReadLine();

                    Console.WriteLine(" \nGender : Female or Male");
                    gender = Console.ReadLine();

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

                    Console.WriteLine("\nNumber of class (4 maximum) ");
                    int nb = Convert.ToInt32(Console.ReadLine());
                    double index1 = 0;
                    double index2 = 0;
                    double index3 = 0;
                    double index4 = 0;

                    int indexfile1 = 0;
                    int indexfile2 = 0;
                    int indexfile3 = 0;
                    int indexfile4 = 0;

                    if (nb <= 4)
                    {
                        if (nb == 1)
                        {
                            Console.WriteLine("\nWhat’s the year of first class? (1, 2, 3, 4 or 5 ?)");
                            int year = Convert.ToInt32(Console.ReadLine());
                            name_class1 = ChooseClass(year, "p");

                            if (name_class1 != "")
                            {
                                index1 = FindIndexCourse(name_class1);

                                indexfile1 = FindIndexFile(index1);
                            }
                        }
                        if (nb == 2)
                        {
                            Console.WriteLine("\nWhat’s the year of first class? (1, 2, 3, 4 or 5 ?)");
                            int year = Convert.ToInt32(Console.ReadLine());
                            name_class1 = ChooseClass(year, "p");
                            Console.WriteLine("\n\nWhat’s the year of second class? (1, 2, 3, 4 or 5 ?)");
                            year = Convert.ToInt32(Console.ReadLine());
                            name_class2 = ChooseClass(year, "p");

                            if (name_class1 != "" && name_class2 != "")
                            {
                                index1 = FindIndexCourse(name_class1);
                                index2 = FindIndexCourse(name_class2);

                                indexfile1 = FindIndexFile(index1);
                                indexfile2 = FindIndexFile(index2);
                            }
                        }
                        if (nb == 3)
                        {
                            Console.WriteLine("\nWhat’s the year of first class? (1, 2, 3, 4 or 5 ?)");
                            int year = Convert.ToInt32(Console.ReadLine());
                            name_class1 = ChooseClass(year, "p");
                            Console.WriteLine("\n\nWhat’s the year of second class? (1, 2, 3, 4 or 5 ?)");
                            year = Convert.ToInt32(Console.ReadLine());
                            name_class2 = ChooseClass(year, "p");
                            Console.WriteLine("\n\nWhat’s the year of third class? (1, 2, 3, 4 or 5 ?)");
                            year = Convert.ToInt32(Console.ReadLine());
                            name_class3 = ChooseClass(year, "p");

                            if (name_class1 != "" && name_class2 != "" && name_class3 != "")
                            {
                                index1 = FindIndexCourse(name_class1);
                                index2 = FindIndexCourse(name_class2);
                                index3 = FindIndexCourse(name_class3);

                                indexfile1 = FindIndexFile(index1);
                                indexfile2 = FindIndexFile(index2);
                                indexfile3 = FindIndexFile(index3);
                            }
                        }
                        if (nb == 4)
                        {
                            Console.WriteLine("\nWhat’s the year of first class? (1, 2, 3, 4 or 5 ?)");
                            int year = Convert.ToInt32(Console.ReadLine());
                            name_class1 = ChooseClass(year, "p");
                            Console.WriteLine("\n\nWhat’s the year of second class? (1, 2, 3, 4 or 5 ?)");
                            year = Convert.ToInt32(Console.ReadLine());
                            name_class2 = ChooseClass(year, "p");
                            Console.WriteLine("\nWhat’s the year of third class? (1, 2, 3, 4 or 5 ?)");
                            year = Convert.ToInt32(Console.ReadLine());
                            name_class3 = ChooseClass(year, "p");
                            Console.WriteLine("\n\nWhat’s the year of fourth class? (1, 2, 3, 4 or 5 ?)");
                            year = Convert.ToInt32(Console.ReadLine());
                            name_class4 = ChooseClass(year, "p");

                            if (name_class1 != "" && name_class2 != "" && name_class3 != "" && name_class4 != "")
                            {
                                index1 = FindIndexCourse(name_class1);
                                index2 = FindIndexCourse(name_class2);
                                index3 = FindIndexCourse(name_class3);
                                index4 = FindIndexCourse(name_class4);

                                indexfile1 = FindIndexFile(index1);
                                indexfile2 = FindIndexFile(index2);
                                indexfile3 = FindIndexFile(index3);
                                indexfile4 = FindIndexFile(index4);
                            }
                        }

                    }
                    if (subject != null && tutor != null && firstName != null && name != null && gender != null && birthdate != null && personalEmailAdress != null && phoneNumber != null && adress != null)
                    {
                        if (tutor == "yes" || tutor == "no")
                        {
                            if (name_class1 != null && name_class2 != null && name_class3 != null && name_class4 != null)
                            {
                                if (name_class1 != "")
                                {
                                    complete = true;
                                    CompleteTimetableProfessor(id, subject, nb, name_class1, name_class2, name_class3, name_class4, indexfile1, indexfile2, indexfile3, indexfile4);
                                    foreach (Student s in StudentList)
                                    {
                                        if (s.Class == name_class1)
                                        {
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index1))).Subject = subject;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index1))).ProfessorID_or_NameOfClass = id;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index1))).Number_of_times = 0;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index1))).Attendance = 0;

                                            //Update the gradebook of the class concerned
                                            int counter = 0;
                                            for (int j = 0; j < s.Gradebook.Subjects.Count; j++)
                                            {
                                                if (s.Gradebook.Subjects[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.Subjects[j] = subject;
                                                    counter++;
                                                }
                                            }

                                            counter = 0;
                                            for (int j = 0; j < s.Gradebook.GradesAssignements.Count; j++)
                                            {
                                                if (s.Gradebook.GradesAssignements[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.GradesAssignements[j] = "";
                                                    counter++;
                                                }
                                            }

                                            counter = 0;
                                            for (int j = 0; j < s.Gradebook.GradesExams.Count; j++)
                                            {
                                                if (s.Gradebook.GradesExams[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.GradesExams[j] = "";
                                                    counter++;
                                                }
                                            }
                                        }

                                        if (s.Class == name_class2)
                                        {
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index2))).Subject = subject;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index2))).ProfessorID_or_NameOfClass = id;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index2))).Number_of_times = 0;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index2))).Attendance = 0;

                                            int counter = 0;
                                            for (int j = 0; j < s.Gradebook.Subjects.Count; j++)
                                            {
                                                if (s.Gradebook.Subjects[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.Subjects[j] = subject;
                                                    counter++;
                                                }
                                            }

                                            counter = 0;
                                            for (int j = 0; j < s.Gradebook.GradesAssignements.Count; j++)
                                            {
                                                if (s.Gradebook.GradesAssignements[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.GradesAssignements[j] = "";
                                                    counter++;
                                                }
                                            }

                                            counter = 0;
                                            for (int j = 0; j < s.Gradebook.GradesExams.Count; j++)
                                            {
                                                if (s.Gradebook.GradesExams[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.GradesExams[j] = "";
                                                    counter++;
                                                }
                                            }
                                        }

                                        if (s.Class == name_class3)
                                        {
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index3))).Subject = subject;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index3))).ProfessorID_or_NameOfClass = id;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index3))).Number_of_times = 0;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index3))).Attendance = 0;

                                            int counter = 0;
                                            for (int j = 0; j < s.Gradebook.Subjects.Count; j++)
                                            {
                                                if (s.Gradebook.Subjects[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.Subjects[j] = subject;
                                                    counter++;
                                                }
                                            }

                                            counter = 0;
                                            for (int j = 0; j < s.Gradebook.GradesAssignements.Count; j++)
                                            {
                                                if (s.Gradebook.GradesAssignements[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.GradesAssignements[j] = "";
                                                    counter++;
                                                }
                                            }

                                            counter = 0;
                                            for (int j = 0; j < s.Gradebook.GradesExams.Count; j++)
                                            {
                                                if (s.Gradebook.GradesExams[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.GradesExams[j] = "";
                                                    counter++;
                                                }
                                            }
                                        }

                                        if (s.Class == name_class4)
                                        {
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index4))).Subject = subject;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index4))).ProfessorID_or_NameOfClass = id;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index4))).Number_of_times = 0;
                                            s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(index4))).Attendance = 0;

                                            int counter = 0;
                                            for (int j = 0; j < s.Gradebook.Subjects.Count; j++)
                                            {
                                                if (s.Gradebook.Subjects[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.Subjects[j] = subject;
                                                    counter++;
                                                }
                                            }

                                            counter = 0;
                                            for (int j = 0; j < s.Gradebook.GradesAssignements.Count; j++)
                                            {
                                                if (s.Gradebook.GradesAssignements[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.GradesAssignements[j] = "";
                                                    counter++;
                                                }
                                            }

                                            counter = 0;
                                            for (int j = 0; j < s.Gradebook.GradesExams.Count; j++)
                                            {
                                                if (s.Gradebook.GradesExams[j] == "" && counter <= 0)
                                                {
                                                    s.Gradebook.GradesExams[j] = "";
                                                    counter++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your form is incomplete or incorrectly completed. Please, complete it again");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
                Console.Clear();
                Console.WriteLine("The form is complete.");

                Professor professor = new Professor(id, firstName, name, gender, birthdate, personalEmailAdress, phoneNumber, adress, password, subject, tutor, name_class1, name_class2, name_class3, name_class4, StudentList);
                ProfessorList.Add(professor);
                //AddCoursePlan(professor);
                if (name_class1 != "")
                {
                    CoursePlan coursePlan = new CoursePlan(id, name_class1, StudentList, ProfessorList, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    professor.CoursePlan.Add(coursePlan);
                }
                if (name_class2 != "")
                {
                    CoursePlan coursePlan = new CoursePlan(id, name_class2, StudentList, ProfessorList, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    professor.CoursePlan.Add(coursePlan);
                }
                if (name_class3 != "")
                {
                    CoursePlan coursePlan = new CoursePlan(id, name_class3, StudentList, ProfessorList, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    professor.CoursePlan.Add(coursePlan);
                }
                if (name_class4 != "")
                {
                    CoursePlan coursePlan = new CoursePlan(id, name_class4, StudentList, ProfessorList, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    professor.CoursePlan.Add(coursePlan);
                }

                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }
        public double FindIndexCourse(string name_class)
        {
            double index = 0;
            Console.Clear();
            Console.WriteLine("Course with class " + name_class);
            Console.WriteLine("\n\nChoose the day of the course : " + "\n1- Monday \n2- Tuesday \n3- Wednesday \n4- Thursday \n5- Friday");
            switch (Console.ReadLine())
            {
                case "1":
                    index = 1;
                    break;

                case "2":
                    index = 2;
                    break;

                case "3":
                    index = 3;
                    break;

                case "4":
                    index = 4;
                    break;

                case "5":
                    index = 5;
                    break;
            }

            Console.WriteLine("\n\nChoose the course shedule : " + "\n1- 8h30-10h15 \n2- 10h30-12h15 \n3- 13h30-15h15 \n4- 15h30-17h15 \n5- 17h30-19h15");
            switch (Console.ReadLine())
            {
                case "1":
                    index += 0.1;
                    break;

                case "2":
                    index += 0.2;
                    break;

                case "3":
                    index += 0.3;
                    break;

                case "4":
                    index += 0.4;
                    break;

                case "5":
                    index += 0.5;
                    break;
            }
            return index;
        }
        public int FindIndexFile(double index)
        {
            int indexfile = 0;
            if (index == 1.1) { indexfile = 2; }
            if (index == 1.2) { indexfile = 7; }
            if (index == 1.3) { indexfile = 12; }
            if (index == 1.4) { indexfile = 17; }
            if (index == 1.5) { indexfile = 22; }

            if (index == 2.1) { indexfile = 27; }
            if (index == 2.2) { indexfile = 32; }
            if (index == 2.3) { indexfile = 37; }
            if (index == 2.4) { indexfile = 42; }
            if (index == 2.5) { indexfile = 47; }

            if (index == 3.1) { indexfile = 52; }
            if (index == 3.2) { indexfile = 57; }
            if (index == 3.3) { indexfile = 62; }
            if (index == 3.4) { indexfile = 67; }
            if (index == 3.5) { indexfile = 72; }

            if (index == 4.1) { indexfile = 77; }
            if (index == 4.2) { indexfile = 82; }
            if (index == 4.3) { indexfile = 87; }
            if (index == 4.4) { indexfile = 92; }
            if (index == 4.5) { indexfile = 97; }

            if (index == 5.1) { indexfile = 102; }
            if (index == 5.2) { indexfile = 107; }
            if (index == 5.3) { indexfile = 112; }
            if (index == 5.4) { indexfile = 117; }
            if (index == 5.5) { indexfile = 122; }

            return indexfile;
        }
        //public void AddCoursePlan(Professor professor)
        //{
        //    foreach(string c in professor.NameClasses)
        //    {
        //        if (c != "")
        //        {
        //            StreamWriter fichEcr = new StreamWriter("CoursePlan" + c + ".csv", true);
        //            string line1 = "";
        //            string line2 = "Professor ID" + ";" + "Semester1 Week1" + ";" + "S1W2" + ";" + "S1W3" + ";" + "S1W4" + ";" + "S1W5" + ";" + "S1W6" + ";" + "S1W7" + ";" + "S1W8" + ";" + "S1W9" + ";" + "S1W10" + ";" + "S1W11" + ";" + "S1W12" + ";" + "Semester2 Week1" + ";" + "S2W2" + ";" + "S2W3" + ";" + "S2W4" + ";" + "S2W5" + ";" + "S2W6" + ";" + "S2W7" + ";" + "S2W8" + ";" + "S2W9" + ";" + "S2W10" + ";" + "S2W11" + ";" + "S2W12";
        //            string line3 = professor.ID + ";";
        //            string line4 = "Exams" + ";";
        //            string line5 = "";
        //            string line6 = "Assignements" + ";";
        //            string line7 = "";
        //            fichEcr.WriteLine(line1);
        //            fichEcr.WriteLine(line2);
        //            fichEcr.WriteLine(line3);
        //            fichEcr.WriteLine(line4);
        //            fichEcr.WriteLine(line5);
        //            fichEcr.WriteLine(line6);
        //            fichEcr.WriteLine(line7);
        //            fichEcr.Close();
        //        }
        //    }
        //}
        public void CompleteTimetableProfessor(string id, string subject, int nb, string name_class1, string name_class2, string name_class3, string name_class4, int indexfile1, int indexfile2, int indexfile3, int indexfile4)
        {
            List<List<string>> list = new List<List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Timetables_Professors.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[127];
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
                    list.Add(l);
                }
                counter = 1;
            }
            fichLect.Close();

            string[] tab = new string[127];
            list[list.Count - 1].CopyTo(tab);
            List<string> courses = new List<string>();
            for (int i = 0; i < tab.Length; i++)
            {
                courses.Add(tab[i]);
            }

            //We change the professor's id
            courses[0] = id;

            //We change the  course of the professor
            for (int i = 3; i < courses.Count; i = i + 5)
            {
                courses[i] = subject;
            }

            //We delete the data in the Class columns
            for (int i = 2; i < courses.Count; i = i + 5)
            {
                courses[i] = " ";
            }

            //Fill in the data in the columns Class
            if (nb == 1) { courses[indexfile1] = name_class1; }
            if (nb == 2) { courses[indexfile1] = name_class1; courses[indexfile2] = name_class2; }
            if (nb == 3) { courses[indexfile1] = name_class1; courses[indexfile2] = name_class2; courses[indexfile3] = name_class3; }
            if (nb == 4) { courses[indexfile1] = name_class1; courses[indexfile2] = name_class2; courses[indexfile3] = name_class3; courses[indexfile4] = name_class4; }

            //The data in the columns Attendance for this course are deleted
            for (int i = 4; i < courses.Count; i = i + 5)
            {
                courses[i] = "0";
            }

            //The data in the columns Number of times of this course are deleted
            for (int i = 5; i < courses.Count; i = i + 5)
            {
                courses[i] = "0";
            }

            string filename = "Timetables_Professors.csv";
            StreamWriter fichEcr = new StreamWriter(filename, true);
            string lastLine = "";
            foreach (string course in courses)
            {
                lastLine += course + ";";
            }
            fichEcr.WriteLine(lastLine);
            fichEcr.Close();
        }


        // 4 - Add a new administrator
        public void AddAministrator()
        {
            bool finish = false;
            while (finish == false)
            {
                bool complete = false;
                string firstName = "";
                string name = "";
                string gender = "";
                string birthdate = "";
                string personalEmailAdress = "";
                string phoneNumber = "";
                string adress = "";
                string password = FirstPassword();

                Administrator a = AdminList.ElementAt(AdminList.Count - 1);
                int i = Convert.ToInt32(a.ID) + 1;
                string id = Convert.ToString(i);

                while (complete == false)
                {
                    Console.Clear();
                    for (int j = 0; j < 70; j++) { Console.Write(" "); }
                    Console.WriteLine("ADD A NEW ADMINISTRATOR \n\n");
                    Console.WriteLine("Let's complete the registration of a new administrator. \n\nPlease complete the following information :");

                    Console.WriteLine(" \nFirst Name :");
                    firstName = Console.ReadLine();

                    Console.WriteLine(" \nName :");
                    name = Console.ReadLine();

                    Console.WriteLine(" \nGender : Female or Male");
                    gender = Console.ReadLine();

                    Console.WriteLine(" \nBirthdate : dd/mm/yyyy");
                    birthdate = Console.ReadLine();

                    Console.WriteLine(" \nPersonal email adress :");
                    personalEmailAdress = Console.ReadLine();

                    Console.WriteLine(" \nTelephone number :");
                    phoneNumber = Console.ReadLine();

                    Console.WriteLine(" \nAdress (street number, street, postal code, city) :");
                    adress = Console.ReadLine();

                    if (firstName != null && name != null && gender != null && birthdate != null && personalEmailAdress != null && phoneNumber != null && adress != null)
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

                Administrator administrator = new Administrator(id, firstName, name, gender, birthdate, personalEmailAdress, phoneNumber, adress, password, StudentList, ProfessorList, AdminList);
                AdminList.Add(administrator);

                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }


        // 5 - Create a course
        public void CreateACourse()
        {
            bool finish = false;
            string subject = "";
            string professorID = "";
            string firstname = "";
            string name = "";

            while (finish == false)
            {
                int testSubject = ProfessorList.Count();
                while (testSubject != 0)
                {
                    testSubject = ProfessorList.Count();
                    Console.Clear();
                    for (int i = 0; i < 70; i++) { Console.Write(" "); }
                    Console.Write("CREATE A COURSE \n\n");
                    Console.WriteLine("What is the subject of this new course ?\n");
                    subject = Console.ReadLine();

                    for (int i = 0; i < ProfessorList.Count; i++)
                    {
                        if (ProfessorList[i].Subject != subject)
                        {
                            testSubject--;
                        }
                    }
                    if (testSubject != 0)
                    {
                        Console.WriteLine("This course already exists. Enter a new subject.");
                        System.Threading.Thread.Sleep(3000);
                    }
                }

                int testID = ProfessorList.Count();
                while (testID != 0)
                {
                    testID = ProfessorList.Count();
                    Console.Clear();
                    for (int i = 0; i < 70; i++) { Console.Write(" "); }
                    Console.Write("CREATE A COURSE \n\n");
                    Console.WriteLine("Enter the ID of the professor for this course");
                    professorID = Console.ReadLine();

                    for (int i = 0; i < ProfessorList.Count; i++)
                    {
                        if (ProfessorList[i].ID != professorID)
                        {
                            testID--;
                        }
                    }
                    if (testID != 0)
                    {
                        Console.WriteLine("This professor already has a course assigned to him. Enter the ID of another professor");
                        System.Threading.Thread.Sleep(3000);
                    }
                }

                Console.WriteLine("\nEnter the first name of the professor for this course");
                firstname = Console.ReadLine();
                Console.WriteLine("\n\nEnter the name of the professor for this course");
                name = Console.ReadLine();


                string filename2 = "Courses.csv";
                StreamWriter fichEcr = new StreamWriter(filename2, true);
                string lastLine = subject + ";" + professorID + ";" + firstname + ";" + name;
                fichEcr.WriteLine(lastLine);
                fichEcr.Close();

                Console.WriteLine("The course has been created");
                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }


        // 6 - Manage applications for courses
        public void ManageApplicationsForCourses()
        {
            bool finish = false;

            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 70; i++) { Console.Write(" "); }
                Console.Write("MANAGE APPLICATIONS FOR COURSES \n\n");
                Console.WriteLine("Here is the list of pending applications :\n");
                List<ApplicationForCourse> listApplications = ListApplications();
                if (listApplications.Count == 0)
                {
                    Console.WriteLine("\nThe list of applications is empty.");
                }
                else
                {
                    int number = 1;
                    foreach (ApplicationForCourse app in listApplications)
                    {
                        app.ShowApplicationForRegistration(number);
                        number++;
                    }

                    Console.WriteLine("\n\nWhich request do you want to deal with ?");
                    int index = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\n\nDo you want to accept this request ? \n1- YES \n2- NO");
                    if (Console.ReadLine() == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("The student has the possibility to follow the requested course with one of the following classes \nChoose one of them :");
                        Console.WriteLine(ProfessorList.Find(x => x.ID.Contains(listApplications[index - 1].ProfID)).NameClass1);
                        if (ProfessorList.Find(x => x.ID.Contains(listApplications[index - 1].ProfID)).NameClass2 != "")
                        {
                            Console.WriteLine(ProfessorList.Find(x => x.ID.Contains(listApplications[index - 1].ProfID)).NameClass2);
                        }
                        if (ProfessorList.Find(x => x.ID.Contains(listApplications[index - 1].ProfID)).NameClass3 != "")
                        {
                            Console.WriteLine(ProfessorList.Find(x => x.ID.Contains(listApplications[index - 1].ProfID)).NameClass3);
                        }
                        if (ProfessorList.Find(x => x.ID.Contains(listApplications[index - 1].ProfID)).NameClass4 != "")
                        {
                            Console.WriteLine(ProfessorList.Find(x => x.ID.Contains(listApplications[index - 1].ProfID)).NameClass4);
                        }
                        string choiceClass = Console.ReadLine();

                        CompleteTimetable(listApplications[index - 1].StudentID, choiceClass, listApplications[index - 1].ProfID);
                        StudentList.Find(x => x.ID.Contains(listApplications[index - 1].StudentID)).Gradebook.Subjects.Add(listApplications[index - 1].CourseName);
                        StudentList.Find(x => x.ID.Contains(listApplications[index - 1].StudentID)).Gradebook.GradesAssignements.Add(" ");
                        StudentList.Find(x => x.ID.Contains(listApplications[index - 1].StudentID)).Gradebook.GradesExams.Add(" ");
                        StudentList.Find(x => x.ID.Contains(listApplications[index - 1].StudentID)).ShowGradeBook(2);
                        Console.Clear();
                        Console.WriteLine("Request accepted");
                        listApplications[index - 1].RemoveApplication();
                        listApplications.Remove(listApplications[index - 1]);

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Request refused");
                        listApplications[index - 1].RemoveApplication();
                        listApplications.Remove(listApplications[index - 1]);
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
        public List<ApplicationForCourse> ListApplications()
        {
            List<ApplicationForCourse> listApplications = new List<ApplicationForCourse>();
            int counter = 0;
            StreamReader fichLect = new StreamReader("ApplicationsForCourses.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[9];
            while (fichLect.Peek() > 0)
            {
                line = fichLect.ReadLine();
                if (counter == 1)
                {
                    datas = line.Split(sep);
                    string studentID = datas[0];
                    string studentFirstName = datas[1];
                    string studentName = datas[2];
                    int studyYear = Convert.ToInt32(datas[3]);
                    string _class = datas[4];
                    string course = datas[5];
                    string profID = datas[6];
                    string profFirstName = datas[7];
                    string profName = datas[8];
                    //Console.WriteLine(id + ";" + firstname + ";" + name + ";" + gender + ";" + birthdate + ";" + _class + ";" + personalEmailAdress + ";" + phoneNumber + ";" + adress + ";" + password + ";" + tutorID + ";" + fees);

                    ApplicationForCourse app = new ApplicationForCourse(studentID, studentFirstName, studentName, studyYear, _class, StudentList.Find(x => x.ID.Contains(studentID)).Courses, StudentList.Find(x => x.ID.Contains(studentID)).Timetable, course, profID, profFirstName, profName, StudentList);
                    listApplications.Add(app);
                }
                counter = 1;
            }
            fichLect.Close();
            return listApplications;
        }
        public void CompleteTimetable(string studentID, string nameClass, string profID)
        {
            List<List<string>> list = new List<List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Timetables_Students.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[127];
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
                    list.Add(l);
                }
                counter = 1;
            }
            fichLect.Close();

            //We retrieve the line of one of the pupils who is in the chosen class.
            bool one = false;
            List<string> listClass = new List<string>();
            foreach (List<string> l in list)
            {
                if (l[l.Count - 1] == nameClass && one == false)
                {
                    listClass = l;
                }
            }

            //We retrieve the index with the teacher's ID in the retrieved student's line.
            int index = 0;
            for (int i = 0; i < listClass.Count; i++)
            {
                if (listClass[i] == profID)
                {
                    index = i;
                }
            }

            //The line of the student who wants to follow the new course is filled in. 
            foreach (List<string> l in list)
            {
                if (l[0] == studentID)
                {
                    l[index] = listClass[index]; //profID
                    l[index + 1] = listClass[index + 1]; //subject
                    l[index + 2] = "0"; //attendance at this course
                    l[index + 3] = "0"; //number of times of this course
                }
            }

            //The .csv file is rewritten with the modifications.
            StreamWriter fichEcr = new StreamWriter("Timetables_Students.csv");
            string firstLine = "StudentID" + ";" + "CourseM1 index" + ";" + "ProfID" + ";" + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT1 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW1 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH1 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF1 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "Class";
            fichEcr.WriteLine(firstLine);

            foreach (List<string> l in list)
            {
                string Line = "";
                for (int i = 0; i < l.Count; i++)
                {
                    Line += l[i] + ";";
                }
                fichEcr.WriteLine(Line);
            }

            fichEcr.Close();
        }


        // 7 - Manage Timetables
        public void ManageTimetables()
        {
            bool finish = false;

            while (finish == false)
            {
                Console.Clear();
                string _class = "";
                for (int i = 0; i < 80; i++) { Console.Write(" "); }
                Console.Write("MANAGE TIMETABLES \n\n");
                Console.WriteLine("Do you want to modify the timetable of a professor or of a class of students ? :\n1- Professor  \n2- Class of students");
                switch (Console.ReadLine())
                {
                    case "1":
                        Professor professor = ChooseProfessor();
                        professor.Timetable.ShowTimetableProfessor();
                        Console.WriteLine("Here is the timetable of " + professor.FirstName + " " + professor.Name + " :");

                        bool classCorrect = false;
                        while (classCorrect == false)
                        {
                            Console.WriteLine("\nFor which class do you want to change the course slot ?");
                            Console.WriteLine(professor.NameClass1);
                            if (professor.NameClass2 != "")
                            {
                                Console.WriteLine(professor.NameClass2);
                            }
                            if (professor.NameClass3 != "")
                            {
                                Console.WriteLine(professor.NameClass3);
                            }
                            if (professor.NameClass2 != "")
                            {
                                Console.WriteLine(professor.NameClass4);
                            }
                            _class = Console.ReadLine();

                            if (professor.NameClasses.Contains(_class))
                            {
                                classCorrect = true;
                            }
                            else
                            {
                                Console.WriteLine("You didn't enter the class name correctly.");
                            }
                        }

                        Course c = professor.Courses.Find(x => x.ProfessorID_or_NameOfClass.Contains(_class));
                        double oldIndexCourse = Convert.ToDouble(c.CourseIndex);
                        int oldIndexFile = FindIndexFile(oldIndexCourse);
                        Console.WriteLine("old index course = " + oldIndexCourse + "\nold index file = " + oldIndexFile);

                        StudentList.Find(x => x.Class.Contains(_class)).Timetable.ShowTimetableStudent();
                        Console.WriteLine("Here is the timetable of class " + _class);

                        //Choice of a timeslot
                        double newIndexCourse = ChooseIndexCourse();
                        int newIndexFile = FindIndexFile(newIndexCourse);

                        if (professor.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(newIndexCourse))).ProfessorID_or_NameOfClass == "" && StudentList.Find(x => x.Class.Contains(_class)).Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(newIndexCourse))).Subject == "Free")
                        {
                            ModifyTimetableStudents(professor, _class, c, oldIndexFile, newIndexFile);
                            foreach (Student s in StudentList)
                            {
                                if (s.Class.Contains(_class))
                                {
                                    s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(oldIndexCourse))).ModifyCourseIndex(newIndexCourse);
                                }
                            }

                            ModifyTimetableProfessor(professor, _class, c, oldIndexFile, newIndexFile);
                            professor.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(oldIndexCourse))).ModifyCourseIndex(newIndexCourse);

                            //Console.Clear();
                            //professor.Timetable.ShowTimetableProfessor();
                            //Console.WriteLine("Here is the new timetable of " + professor.FirstName + " " + professor.Name + " :");

                            //StudentList.Find(x => x.Class.Contains(_class)).Timetable.ShowTimetableStudent();
                            //Console.WriteLine("Here is the new timetable of class " + _class);

                            Console.WriteLine("Timetables updated");
                        }

                        else
                        {
                            Console.WriteLine("This timeslot is not available.");
                        }
                        break;



                    case "2":
                        Console.WriteLine("What's the year of this class ? (1, 2, 3, 4 or 5)");
                        int year = Convert.ToInt32(Console.ReadLine());
                        _class = ChooseClass(year, "p");

                        StudentList.Find(x => x.Class.Contains(_class)).Timetable.ShowTimetableStudent();
                        Console.WriteLine("Here is the timetable of class " + _class);

                        bool nameCorrect = false;
                        string courseName = "";
                        while (nameCorrect == false)
                        {
                            Console.WriteLine("\nFor which course do you want to change the timeslot ?");
                            courseName = Console.ReadLine();
                            if (StudentList.Find(x => x.Class.Contains(_class)).CoursesName.Contains(courseName))
                            {
                                nameCorrect = true;
                            }
                            else
                            {
                                Console.WriteLine("You didn't enter the course name correctly.");
                            }
                        }

                        Course c2 = StudentList.Find(x => x.Class.Contains(_class)).Courses.Find(x => x.Subject.Contains(courseName));
                        double oldIndexCourse2 = Convert.ToDouble(c2.CourseIndex);
                        int oldIndexFile2 = FindIndexFile(oldIndexCourse2);

                        ProfessorList.Find(x => x.Subject.Contains(c2.Subject)).Timetable.ShowTimetableProfessor();
                        Console.WriteLine("Here is the timetable of the professor for this course");

                        //Choice of a timeslot
                        double newIndexCourse2 = ChooseIndexCourse();
                        int newIndexFile2 = FindIndexFile(newIndexCourse2);

                        if (StudentList.Find(x => x.Class.Contains(_class)).Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(newIndexCourse2))).Subject == "Free" && ProfessorList.Find(x => x.Subject.Contains(c2.Subject)).Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(newIndexCourse2))).ProfessorID_or_NameOfClass == "")
                        {
                            ModifyTimetableStudents(ProfessorList.Find(x => x.Subject.Contains(c2.Subject)), _class, c2, oldIndexFile2, newIndexFile2);
                            foreach (Student s in StudentList)
                            {
                                if (s.Class.Contains(_class))
                                {
                                    s.Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(oldIndexCourse2))).CourseIndex = Convert.ToString(newIndexCourse2);
                                }
                            }

                            ModifyTimetableProfessor(ProfessorList.Find(x => x.Subject.Contains(c2.Subject)), _class, c2, oldIndexFile2, newIndexFile2);
                            ProfessorList.Find(x => x.Subject.Contains(c2.Subject)).Courses.Find(x => x.CourseIndex.Contains(Convert.ToString(oldIndexCourse2))).CourseIndex = Convert.ToString(newIndexCourse2);

                            //Console.Clear();
                            //StudentList.Find(x => x.Class.Contains(_class)).Timetable.ShowTimetableStudent();
                            //Console.WriteLine("Here is the new timetable of class " + _class);

                            //ProfessorList.Find(x => x.Subject.Contains(c2.Subject)).Timetable.ShowTimetableProfessor();
                            //Console.WriteLine("Here is the new timetable of " + ProfessorList.Find(x => x.Subject.Contains(c2.Subject)).FirstName + ProfessorList.Find(x => x.Subject.Contains(c2.Subject)).Name + " :");

                            Console.WriteLine("Timetables updated");
                        }

                        else
                        {
                            Console.WriteLine("This timeslot is not available.");
                        }
                        break;
                }

                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }
        public double ChooseIndexCourse()
        {
            double index = 0;
            Console.WriteLine("\n\nChoose the day of the new course slot, a slot where the class and the professor don't already have another course : " + "\n1- Monday \n2- Tuesday \n3- Wednesday \n4- Thursday \n5- Friday");
            switch (Console.ReadLine())
            {
                case "1":
                    index = 1;
                    break;

                case "2":
                    index = 2;
                    break;

                case "3":
                    index = 3;
                    break;

                case "4":
                    index = 4;
                    break;

                case "5":
                    index = 5;
                    break;
            }

            Console.WriteLine("\n\nChoose the new course shedule : " + "\n1- 8h30-10h15 \n2- 10h30-12h15 \n3- 13h30-15h15 \n4- 15h30-17h15 \n5- 17h30-19h15");
            switch (Console.ReadLine())
            {
                case "1":
                    index += 0.1;
                    break;

                case "2":
                    index += 0.2;
                    break;

                case "3":
                    index += 0.3;
                    break;

                case "4":
                    index += 0.4;
                    break;

                case "5":
                    index += 0.5;
                    break;
            }
            return index;
        }
        public void ModifyTimetableStudents(Professor professor, string _class, Course c, int oldIndexFile, int newIndexFile)
        {
            List<List<string>> list = new List<List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Timetables_Students.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[127];
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
                    list.Add(l);
                }
                counter = 1;
            }
            fichLect.Close();


            foreach (List<string> l in list)
            {
                if (l[l.Count - 1] == _class)
                {
                    l[newIndexFile] = l[oldIndexFile];
                    l[newIndexFile + 1] = l[oldIndexFile + 1];
                    l[newIndexFile + 2] = l[oldIndexFile + 2];
                    l[newIndexFile + 3] = l[oldIndexFile + 3];

                    l[oldIndexFile] = " ";
                    l[oldIndexFile + 1] = "Free";
                    l[oldIndexFile + 2] = "0";
                    l[oldIndexFile + 3] = "0";
                }
            }

            StreamWriter fichEcr = new StreamWriter("Timetables_Students.csv");
            string firstLine = "StudentID" + ";" + "CourseM1 index" + ";" + "ProfID" + ";" + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT1 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW1 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH1 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF1 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF2 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF3 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF4 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF5 index" + "; " + "ProfID" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "Class";
            fichEcr.WriteLine(firstLine);

            foreach (List<string> l in list)
            {
                string Line = "";
                for (int i = 0; i < l.Count; i++)
                {
                    Line += l[i] + ";";
                }
                fichEcr.WriteLine(Line);
            }
            fichEcr.Close();
        }
        public void ModifyTimetableProfessor(Professor professor, string _class, Course c, int oldIndexFile, int newIndexFile)
        {
            List<List<string>> list = new List<List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Timetables_Professors.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[126];
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
                    list.Add(l);
                }
                counter = 1;
            }
            fichLect.Close();


            foreach (List<string> l in list)
            {
                if (l[0] == professor.ID)
                {
                    l[newIndexFile] = l[oldIndexFile];
                    l[newIndexFile + 2] = l[oldIndexFile + 2];
                    l[newIndexFile + 3] = l[oldIndexFile + 3];

                    l[oldIndexFile] = " ";
                    l[oldIndexFile + 2] = "0";
                    l[oldIndexFile + 3] = "0";
                }
            }

            StreamWriter fichEcr = new StreamWriter("Timetables_Professors.csv");
            string firstLine = "ProfessorID" + ";" + "CourseM1 index" + ";" + "Class number" + ";" + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM2 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM3 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM4 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseM5 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT1 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT2 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT3 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT4 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseT5 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW1 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW2 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW3 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW4 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseW5 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH1 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH2 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH3 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH4 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseTH5 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF1 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF2 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF3 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF4 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course" + "; " + "CourseF5 index" + "; " + "Class number" + "; " + "Subject" + "; " + "Attendance at this course" + "; " + "Number of this course";
            fichEcr.WriteLine(firstLine);

            foreach (List<string> l in list)
            {
                string Line = "";
                for (int i = 0; i < l.Count; i++)
                {
                    Line += l[i] + ";";
                }
                fichEcr.WriteLine(Line);
            }
            fichEcr.Close();
        }


        // 8 - Manage student information (contact, fees, tutor)
        public void ManageStudentInformation()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 70; i++) { Console.Write(" "); }
                Console.Write("MANAGE STUDENT INFORMATION\n\n");
                Student student = ChooseStudent();

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
                Console.WriteLine("School information : \n" +
                    $"\n Year of study : {student.Year}" +
                    $"\nClass : {student.Class}" +
                    $"\nTutorID : {student.TutorID}" +
                    $"\nFees to pay : {student.Fees}\n\n\n");

                Console.WriteLine("Do you want to change any of the student's information? ");
                Console.WriteLine("0 - Nothing\n" +
                    "1 - First Name\n" +
                    "2 - Name\n" +
                    "3 - Gender\n" +
                    "4 - Birthdate\n" +
                    "5 - Adress\n" +
                    "6 - Phone number\n" +
                    "7 - Personal email adress\n" +
                    "8 - TutorID\n" +
                    "9 - Fees\n");

                switch (Console.ReadLine())
                {
                    case "0":
                        finish = true;
                        break;

                    case "1":
                        Console.WriteLine("\nEnter the new first name of the student");
                        student.FirstName = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("\nEnter the new name of the student");
                        student.Name = Console.ReadLine();
                        break;

                    case "3":
                        Console.WriteLine("\nEnter the new gender of the student");
                        student.Adress = Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("\nEnter the new birthdate of the student (dd/mm/yyyy)");
                        string birthdate = Console.ReadLine();
                        student.Birthdate = student.BirthdateCalculation(birthdate);
                        break;

                    case "5":
                        Console.WriteLine("\nEnter the new address of the student");
                        student.Adress = Console.ReadLine();
                        break;

                    case "6":
                        Console.WriteLine("\nEnter the new phone number of the student");
                        student.PhoneNumber = Console.ReadLine();
                        break;

                    case "7":
                        Console.WriteLine("\nEnter the new personal email adress of the student");
                        student.PersoEmail = Console.ReadLine();
                        break;

                    case "8":
                        string tutorID = "";
                        List<Professor> tutors = new List<Professor>();
                        foreach (Professor p in ProfessorList)
                        {
                            if (p.Tutor == true)
                            {
                                tutors.Add(p);
                            }
                        }
                        bool test = false;
                        while (test == false)
                        {
                            Console.Clear();
                            Console.WriteLine("\nChoose a new tutor for the student in the following list (max 10 students for a tutor) : \n");
                            foreach (Professor p in tutors)
                            {
                                Console.WriteLine($"\n{p.FirstName} {p.Name} - {p.Subject} Professor ID : {p.ID} - Number of students tutored: " + p.TutorStudentList.Count);
                            }
                            Console.WriteLine("\n\nID of the new tutor : ");
                            tutorID = Console.ReadLine();
                            if (tutors.Contains(tutors.Find(x => x.ID.Contains(tutorID))))
                            {
                                if (tutorID != student.TutorID)
                                {
                                    ModifyTutor(student, tutorID);
                                    student.TutorID = tutorID;
                                    test = true;
                                }
                            }
                        }


                        break;

                    case "9":
                        Console.WriteLine("Enter the new amount that the student will have to pay");
                        student.Fees = Convert.ToDouble(Console.ReadLine());
                        break;
                }
                Console.WriteLine("The changes have been taken into account \n\n");
                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }
        public Student ChooseStudent()
        {
            Console.WriteLine("\nEnter the FIRST NAME of the student whose information you want to manage :");
            string firstname = Console.ReadLine();

            Console.WriteLine("\nEnter the NAME of the student whose information you want to manage :");
            string name = Console.ReadLine();

            Student s = StudentList.Find(x => x.FirstName.ToLower().Contains(firstname.ToLower()) && x.Name.ToLower().Contains(name.ToLower()));

            return s;
        }
        public void ModifyTutor(Student s, string tutorID)
        {
            List<List<string>> list = new List<List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Tutors.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[11];
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
                    list.Add(l);
                }
                counter = 1;
            }
            fichLect.Close();

            foreach (List<string> l in list)
            {
                if (l[0] == s.TutorID)
                {
                    l.Remove(s.ID);
                }
            }

            foreach (List<string> l in list)
            {
                if (l.Contains(tutorID))
                {
                    int i = l.IndexOf("");
                    l[i] = s.ID;
                }
            }

            StreamWriter fichEcr = new StreamWriter("Tutors.csv");
            string firstLine = "Tutor's ID" + ";" + "Student 1" + ";" + "Student 2" + ";" + "Student 3" + ";" + "Student 4" + ";" + "Student 5" + ";" + "Student 6" + ";" + "Student 7" + ";" + "Student 8" + ";" + "Student 9" + ";" + "Student 10";
            fichEcr.WriteLine(firstLine);
            foreach (List<string> l in list)
            {
                string Line = "";
                foreach (string word in l)
                {
                    Line += word + ";";
                }
                fichEcr.WriteLine(Line);
            }
            fichEcr.Close();
        }


        // 9 - Manage professor information (contact, tutoring)
        public void ManageProfessorInformation()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 70; i++) { Console.Write(" "); }
                Console.Write("MANAGE PROFESSOR INFORMATION\n\n");
                Professor professor = ChooseProfessor();

                Console.Clear();
                Console.WriteLine($"Student Profile {professor.FirstName} {professor.Name.ToUpper()} \n\n");
                Console.WriteLine("Personal identifying information : \n\n" +
                    professor.FirstName + " " + professor.Name.ToUpper() +
                    $"\nID : {professor.ID}" +
                    $"\nGender : {professor.Gender}" +
                    $"\nBirthdate : {professor.Birthdate.ToShortDateString()}\n\n");
                Console.WriteLine("Contact information : \n" +
                    $"\nAdress : {professor.Adress}" +
                    $"\nPhone Number : {professor.PhoneNumber}" +
                    $"\nSchool email adress : {professor.SchoolEmail}" +
                    $"\nPersonnal email adress : {professor.PersoEmail}\n\n");
                Console.WriteLine("School information : \n" +
                    $"\nSubject : {professor.Subject}" +
                    $"\nClasses : {professor.NameClass1} {professor.NameClass2} {professor.NameClass3} {professor.NameClass4} ");
                if (professor.Tutor == true)
                {
                    Console.WriteLine("\nTutor of : ");
                    for (int i = 0; i < professor.TutorStudentList.Count; i++)
                    {
                        Console.WriteLine("- " + professor.TutorStudentList[i].FirstName + " " + professor.TutorStudentList[i].Name);
                    }
                }

                Console.WriteLine("Do you want to change any of the student's information? ");
                Console.WriteLine("0 - Nothing\n" +
                    "1 - First Name\n" +
                    "2 - Name\n" +
                    "3 - Gender\n" +
                    "4 - Birthdate\n" +
                    "5 - Adress\n" +
                    "6 - Phone number\n" +
                    "7 - Personal email adress\n");
                if (professor.Tutor == true)
                {
                    Console.Write("8 - Take this professor off the tutor's list");
                }
                else
                {
                    Console.Write("8 - Add this professor to the list of tutors");
                }

                switch (Console.ReadLine())
                {
                    case "0":
                        finish = true;
                        break;

                    case "1":
                        Console.WriteLine("\nEnter the new first name of the student");
                        professor.FirstName = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("\nEnter the new name of the student");
                        professor.Name = Console.ReadLine();
                        break;

                    case "3":
                        Console.WriteLine("\nEnter the new gender of the student");
                        professor.Adress = Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("\nEnter the new birthdate of the student (dd/mm/yyyy)");
                        string birthdate = Console.ReadLine();
                        professor.Birthdate = professor.BirthdateCalculation(birthdate);
                        break;

                    case "5":
                        Console.WriteLine("\nEnter the new address of the student");
                        professor.Adress = Console.ReadLine();
                        break;

                    case "6":
                        Console.WriteLine("\nEnter the new phone number of the student");
                        professor.PhoneNumber = Console.ReadLine();
                        break;

                    case "7":
                        Console.WriteLine("\nEnter the new personal email adress of the student");
                        professor.PersoEmail = Console.ReadLine();
                        break;

                    case "8":
                        if (professor.Tutor == true)
                        {
                            RemoveProfessorFromTutorsList(professor);
                            for (int i = 0; i < professor.StudentList.Count; i++)
                            {
                                ModifyTutor(professor.StudentList[i], professor.ID);
                            }
                            professor.Tutor = false;
                            Console.WriteLine("The professor has been taken off the list of tutors ");
                        }
                        else
                        {
                            AddProfessorToTutorsList(professor);
                            professor.Tutor = true;
                            Console.WriteLine("The professor has been added to the list of tutors ");
                        }
                        break;
                }
                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }
        public Professor ChooseProfessor()
        {
            Console.WriteLine("\nEnter the FIRST NAME of the professor whose information you want to manage :");
            string firstname = Console.ReadLine();

            Console.WriteLine("\nEnter the NAME of the professor whose information you want to manage :");
            string name = Console.ReadLine();

            Professor p = ProfessorList.Find(x => x.FirstName.ToLower().Contains(firstname.ToLower()) && x.Name.ToLower().Contains(name.ToLower()));

            return p;
        }
        public void RemoveProfessorFromTutorsList(Professor p)
        {
            List<List<string>> list = new List<List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Tutors.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[11];
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
                    list.Add(l);
                }
                counter = 1;
            }
            fichLect.Close();

            foreach (List<string> l in list)
            {
                if (l[0] == p.ID)
                {
                    list.Remove(l);
                    Console.WriteLine("removed");
                }
            }

            StreamWriter fichEcr = new StreamWriter("Tutors.csv");
            string firstLine = "Tutor's ID" + ";" + "Student 1" + ";" + "Student 2" + ";" + "Student 3" + ";" + "Student 4" + ";" + "Student 5" + ";" + "Student 6" + ";" + "Student 7" + ";" + "Student 8" + ";" + "Student 9" + ";" + "Student 10";
            fichEcr.WriteLine(firstLine);
            foreach (List<string> l in list)
            {
                string Line = "";
                foreach (string word in l)
                {
                    Line += word + ";";
                }
                fichEcr.WriteLine(Line);
            }
            fichEcr.Close();
        }
        public void AddProfessorToTutorsList(Professor p)
        {
            StreamWriter fichEcr = new StreamWriter("Tutors.csv", true);
            string line = p.ID + ";";
            fichEcr.WriteLine(line);

            fichEcr.Close();
        }
    }
}
