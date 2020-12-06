using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class Professor : Person
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD

        public string Subject { get; set; }

        public string NameClass1 { get; set; }
        public string NameClass2 { get; set; }
        public string NameClass3 { get; set; }
        public string NameClass4 { get; set; }
        public List<string> NameClasses { get; set; }

        public List<Student> Class1 { get; set; }
        public List<Student> Class2 { get; set; }
        public List<Student> Class3 { get; set; }
        public List<Student> Class4 { get; set; }
        public bool Tutor { get; set; }
        public List<Student> TutorStudentList { get; set; }
        public List<Student> StudentList { get; set; }

        public List<Course> Courses { get; set; }
        public Timetable Timetable { get; set; }

        public CoursePlan CoursePlanClass1 { get; set; }
        public CoursePlan CoursePlanClass2 { get; set; }
        public CoursePlan CoursePlanClass3 { get; set; }
        public CoursePlan CoursePlanClass4 { get; set; }

        public List<CoursePlan> CoursePlan { get; set; }


        public Professor(string id, string firstName, string name, string gender, string birthdate, string persoEmailAdress, string phoneNumber, string adress, string password, string subject, string tutor, string name_class1, string name_class2, string name_class3, string name_class4, List<Student> studentList)
            : base(id, firstName, name, gender, birthdate, persoEmailAdress, phoneNumber, adress, password)
        {
            Subject = subject;

            NameClass1 = name_class1;
            NameClass2 = name_class2;
            NameClass3 = name_class3;
            NameClass4 = name_class4;

            NameClasses = new List<string>();
            NameClasses.Add(NameClass1);
            NameClasses.Add(NameClass2);
            NameClasses.Add(NameClass3);
            NameClasses.Add(NameClass4);

            StudentList = studentList;

            //Remplissage des classes du professeur
            Class1 = new List<Student>();
            Class2 = new List<Student>();
            Class3 = new List<Student>();
            Class4 = new List<Student>();

            foreach (Student s in StudentList)
            {
                if (name_class1 != "")
                {
                    if (s.Class == name_class1) { Class1.Add(s); }
                }
                if (name_class2 != "")
                {
                    if (name_class2 != "" && s.Class == name_class2) { Class2.Add(s); }
                }
                if (name_class3 != "")
                {
                    if (name_class3 != "" && s.Class == name_class3) { Class3.Add(s); }
                }
                if (name_class4 != "")
                {
                    if (name_class4 != "" && s.Class == name_class4) { Class4.Add(s); }
                }
            }

            //Tuteur ou non?
            if (tutor == "yes")
            {
                Tutor = true;
            }
            else
            {
                Tutor = false;
            }

            //Liste des élèves dont c'est le tuteur
            if (Tutor == true)
            {
                List<string> StudentList = ResearchStudentsIDForTutoring();

                TutorStudentList = ResearchStudentsForTutoring(StudentList);
            }

            //Remplissage de la liste de cours Courses
            Courses = new List<Course>();

            List<string> listCourses = new List<string>();
            SortedList<string, List<string>> list = new SortedList<string, List<string>>();

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
                    string professorID = datas[0];
                    List<string> l = new List<string>();
                    for (int i = 1; i < datas.Length; i++)
                    {
                        l.Add(datas[i]);
                    }
                    list.Add(professorID, l);
                }
                counter = 1;
            }
            fichLect.Close();

            int key = list.IndexOfKey(ID);
            //Console.WriteLine(key);
            for (int i = 0; i < datas.Length - 1; i++)
            {
                listCourses.Add(list.ElementAt(key).Value[i]);
                //Console.Write(list.ElementAt(key).Value[i] + " ");
            }

            //Remplissage de la liste des cours
            for (int i = 0; i < 125; i = i + 5)
            {
                Course c = new Course(Convert.ToDouble(listCourses[i]), listCourses[i + 1], listCourses[i + 2], Convert.ToInt32(listCourses[i + 3]), Convert.ToInt32(listCourses[i + 4]), StudentList);
                //Console.WriteLine(Convert.ToDouble(listCourses[i]) + ";" + listCourses[i + 1] + ";" + listCourses[i + 2] + ";" + listCourses[i + 3] + ";" + listCourses[i + 4]);
                Courses.Add(c);
            }

            //Création de l'edt à partir de la liste de cours
            Timetable = new Timetable(Courses);

            CoursePlan = new List<CoursePlan>();
        }

        public override string ToString()
        {
            return $"Status: Professor \nSubject : {Subject}  \nTutor : {Tutor} \n{ base.ToString()}";
        }

        public override string SchoolEmailAdress()
        {
            return ID + "@professor.faculty-vgc.ie";
        }



        //On récupère une SortedList<ID prof, liste des ID des élèves dont le prof est tuteur>
        //A partir de cette SortedList, on extrait une liste de string avec les ID des élèves
        public List<string> ResearchStudentsIDForTutoring()
        {
            List<string> listStudents = new List<string>();

            SortedList<string, List<string>> list = new SortedList<string, List<string>>();

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
                    string tutorID = datas[0];
                    List<string> l = new List<string>();
                    for (int i = 1; i < datas.Length; i++)
                    {
                        l.Add(datas[i]);
                    }
                    list.Add(tutorID, l);
                }
                counter = 1;
            }
            fichLect.Close();

            int key = list.IndexOfKey(ID);
            for (int i = 0; i < list[ID].Count; i++)
            {
                listStudents.Add(list.ElementAt(key).Value[i]);
            }
            return listStudents;
        }


        // On génère la liste d'élèves à partir du fichier .csv
        // A partir de la liste de string avec les ID des élèves, on trouve les élèves correspondants dans le fichier .csv
        // et on remplit une List<Student> qui contient les élèves (et leurs infos persos) dont le prof est le tuteur 
        public List<Student> ResearchStudentsForTutoring(List<string> StudentList_string)
        {
            List<Student> studentList = new List<Student>();

            int index = 0;
            foreach (string studentID in StudentList_string)
            {
                if (StudentList_string[index] != "")
                {
                    Student s = StudentList.Find(x => x.ID.Contains(studentID));
                    studentList.Add(s);
                }
                index++;
            }

            return studentList;
        }



        // 1 - Contact and personal identifying information
        public void ShowAndModifyPersonalInformation()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                Console.WriteLine($"\nProfessor Profile {FirstName} { Name.ToUpper()} \n\n");
                Console.WriteLine("\nPersonal identifying information : \n\n" +
                    FirstName + " " + Name.ToUpper() +
                    $"\nID : {ID}" +
                    $"\nSubject : {Subject}" +
                    $"\nTutor? : {Tutor}" +
                    $"\nGender : {Gender}" +
                    $"\nBirthdate : {Birthdate.ToShortDateString()}\n\n");
                Console.WriteLine("\nContact information : \n\n" +
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
                Console.Clear();
            }
        }


        // 3 - Student's Attendance
        public void StudentsAttendance()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("_____________________");
                Console.WriteLine("\n");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("| MANAGE ATTENDANCE |");
                Console.WriteLine("");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("_____________________\n\n\n\n");

                Console.WriteLine("\n\nFor which class would you like to record attendance?\n");
                Console.WriteLine("0- Exit \n");
                if (NameClass1 != "")
                {
                    Console.WriteLine("1- " + NameClass1 + "\n");
                }
                if (NameClass2 != "")
                {
                    Console.WriteLine("2- " + NameClass2 + "\n");
                }
                if (NameClass3 != "")
                {
                    Console.WriteLine("3- " + NameClass3 + "\n");
                }
                if (NameClass4 != "")
                {
                    Console.WriteLine("4- " + NameClass4 + "\n");
                }


                Console.WriteLine("\n\n\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("\nAttendance for class " + NameClass1);
                        Console.WriteLine("\n\nType 'P' for Present and 'A' for Absent \n");
                        for (int i = 0; i < Class1.Count; i++)
                        {
                            Console.Write("\n" + Class1[i].FirstName + " " + Class1[i].Name + " : ");
                            string answer = Console.ReadLine().ToUpper();
                            if (answer == "P")
                            {
                                Class1[i].Courses.Find(x => x.Subject.Contains(Subject)).Attendance += 1;
                                Class1[i].Courses.Find(x => x.Subject.Contains(Subject)).Number_of_times += 1;
                            }
                            if (answer == "A")
                            {
                                Class1[i].Courses.Find(x => x.Subject.Contains(Subject)).Number_of_times += 1;
                            }
                        }

                        Console.WriteLine("\n \nAttendance recorded.");
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nAttendance for class " + NameClass2);
                        Console.WriteLine("\n\nType 'P' for Present and 'A' for Absent \n");
                        for (int i = 0; i < Class2.Count; i++)
                        {
                            Console.Write("\n" + Class2[i].FirstName + " " + Class2[i].Name + " : ");
                            string answer = Console.ReadLine().ToUpper();
                            if (answer == "P")
                            {
                                Class2[i].Courses.Find(x => x.Subject.Contains(Subject)).Attendance += 1;
                                Class2[i].Courses.Find(x => x.Subject.Contains(Subject)).Number_of_times += 1;
                            }
                            if (answer == "A")
                            {
                                Class2[i].Courses.Find(x => x.Subject.Contains(Subject)).Number_of_times += 1;
                            }
                        }
                        Console.WriteLine("\n \nAttendance recorded.");
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("\nAttendance for class " + NameClass3);
                        Console.WriteLine("\n\nType 'P' for Present and 'A' for Absent \n");
                        for (int i = 0; i < Class3.Count; i++)
                        {
                            Console.Write("\n" + Class3[i].FirstName + " " + Class3[i].Name + " : ");
                            string answer = Console.ReadLine().ToUpper();
                            if (answer == "P")
                            {
                                Class3[i].Courses.Find(x => x.Subject.Contains(Subject)).Attendance += 1;
                                Class3[i].Courses.Find(x => x.Subject.Contains(Subject)).Number_of_times += 1;
                            }
                            if (answer == "A")
                            {
                                Class3[i].Courses.Find(x => x.Subject.Contains(Subject)).Number_of_times += 1;
                            }
                        }
                        Console.WriteLine("\n \nAttendance recorded.");
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("\nAttendance for class " + NameClass4);
                        Console.WriteLine("\n\nType 'P' for Present and 'A' for Absent \n");
                        for (int i = 0; i < Class4.Count; i++)
                        {
                            Console.Write("\n" + Class4[i].FirstName + " " + Class4[i].Name + " : ");
                            string answer = Console.ReadLine().ToUpper();
                            if (answer == "P")
                            {
                                Class4[i].Courses.Find(x => x.Subject.Contains(Subject)).Attendance += 1;
                                Class4[i].Courses.Find(x => x.Subject.Contains(Subject)).Number_of_times += 1;
                            }
                            if (answer == "A")
                            {
                                Class4[i].Courses.Find(x => x.Subject.Contains(Subject)).Number_of_times += 1;
                            }
                        }
                        Console.WriteLine("\n \nAttendance recorded.");
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


        // 4 - Grade a student
        public void GradeAStudent()
        {
            Console.Clear();
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("___________________");
                Console.WriteLine("\n");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("| GRADE A STUDENT |");
                Console.WriteLine("");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("___________________\n\n\n\n");

                Console.WriteLine("\nChoose the class of the student you want to grade :\n");
                Console.WriteLine("0- Exit \n");
                if (NameClass1 != "")
                {
                    Console.WriteLine("1- " + NameClass1 + "\n");
                }
                if (NameClass2 != "")
                {
                    Console.WriteLine("2- " + NameClass2 + "\n");
                }
                if (NameClass3 != "")
                {
                    Console.WriteLine("3- " + NameClass3 + "\n");
                }
                if (NameClass4 != "")
                {
                    Console.WriteLine("4- " + NameClass4 + "\n");
                }

                Console.WriteLine("\n\n\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("___________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| GRADE A STUDENT |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("___________________\n\n\n\n");

                        int index = 1;
                        Console.WriteLine("Choose the student you want to grade : \n");
                        for (int i = 0; i < Class1.Count; i++)
                        {
                            Console.WriteLine(index + "- " + Class1[i].FirstName + " " + Class1[i].Name);
                            index++;
                        }
                        int answer = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine("\n\nHere is the current Gradebook of " + Class1[answer - 1].FirstName + " " + Class1[answer - 1].Name + " : \n");
                        Class1[answer - 1].ShowGradeBook(2);

                        Console.WriteLine("\nDo you want to grade this student for an : \n1 - Assignement \n2 - Exam ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("\n\n\nEnter the grade you want to give to this student : (ex : 17/20) ");
                                string grade = Console.ReadLine();
                                int indexGrade = Class1[answer - 1].Gradebook.Subjects.IndexOf(Subject);
                                Class1[answer - 1].Gradebook.GradesAssignements[indexGrade] += grade + ", ";

                                Console.Clear();
                                Console.WriteLine("\n \nStudent graded.");
                                Console.WriteLine("\n\nHere is the new Gradebook of " + Class1[answer - 1].FirstName + " " + Class1[answer - 1].Name + " : \n");
                                Class1[answer - 1].ShowGradeBook(2);
                                break;

                            case "2":
                                Console.WriteLine("\n\n\nEnter the grade you want to give to this student : (ex : 17/20) ");
                                grade = Console.ReadLine();
                                indexGrade = Class1[answer - 1].Gradebook.Subjects.IndexOf(Subject);
                                Class1[answer - 1].Gradebook.GradesExams[indexGrade] += grade + ", ";

                                Console.Clear();
                                Console.WriteLine("\n \nStudent graded.");
                                Console.WriteLine("\n\nHere is the new Gradebook of " + Class1[answer - 1].FirstName + " " + Class1[answer - 1].Name + " : \n");
                                Class1[answer - 1].ShowGradeBook(2);
                                break;
                        }
                        break;

                    case "2":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("___________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| GRADE A STUDENT |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("___________________\n\n\n\n");

                        index = 1;
                        Console.WriteLine("Choose the student you want to grade \n");
                        for (int i = 0; i < Class2.Count; i++)
                        {
                            Console.WriteLine(index + "- " + Class2[i].FirstName + " " + Class2[i].Name);
                            index++;
                        }
                        answer = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine("\n\nHere is the current Gradebook of " + Class2[answer - 1].FirstName + " " + Class2[answer - 1].Name + " : \n");
                        Class2[answer - 1].ShowGradeBook(2);

                        Console.WriteLine("\nDo you want to grade this student for an : \n1 - Assignement \n2 - Exam ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("\n\n\nEnter the grade you want to give to this student : (ex : 17/20) ");
                                string grade = Console.ReadLine();
                                int indexGrade = Class2[answer - 1].Gradebook.Subjects.IndexOf(Subject);
                                Class2[answer - 1].Gradebook.GradesAssignements[indexGrade] += grade + ", ";

                                Console.Clear();
                                Console.WriteLine("\n \nStudent graded.");
                                Console.WriteLine("\n\nHere is the new Gradebook of " + Class2[answer - 1].FirstName + " " + Class2[answer - 1].Name + " : \n");
                                Class2[answer - 1].ShowGradeBook(2);
                                break;

                            case "2":
                                Console.WriteLine("\n\n\nEnter the grade you want to give to this student : (ex : 17/20) ");
                                grade = Console.ReadLine();
                                indexGrade = Class2[answer - 1].Gradebook.Subjects.IndexOf(Subject);
                                Class2[answer - 1].Gradebook.GradesExams[indexGrade] += grade + ", ";

                                Console.Clear();
                                Console.WriteLine("\n \nStudent graded.");
                                Console.WriteLine("\n\nHere is the new Gradebook of " + Class2[answer - 1].FirstName + " " + Class2[answer - 1].Name + " : \n");
                                Class2[answer - 1].ShowGradeBook(2);
                                break;
                        }
                        break;

                    case "3":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("___________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| GRADE A STUDENT |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("___________________\n\n\n\n");

                        index = 1;
                        Console.WriteLine("Choose the student you want to grade \n");
                        for (int i = 0; i < Class3.Count; i++)
                        {
                            Console.WriteLine(index + "- " + Class3[i].FirstName + " " + Class3[i].Name);
                            index++;
                        }
                        answer = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine("\n\nHere is the current Gradebook of " + Class3[answer - 1].FirstName + " " + Class3[answer - 1].Name + " : \n");
                        Class3[answer - 1].ShowGradeBook(2);

                        Console.WriteLine("\nDo you want to grade this student for an : \n1 - Assignement \n2 - Exam ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("\n\n\nEnter the grade you want to give to this student : (ex : 17/20) ");
                                string grade = Console.ReadLine();
                                int indexGrade = Class3[answer - 1].Gradebook.Subjects.IndexOf(Subject);
                                Class3[answer - 1].Gradebook.GradesAssignements[indexGrade] += grade + ", ";

                                Console.Clear();
                                Console.WriteLine("\n \nStudent graded.");
                                Console.WriteLine("\n\nHere is the new Gradebook of " + Class3[answer - 1].FirstName + " " + Class3[answer - 1].Name + " : \n");
                                Class3[answer - 1].ShowGradeBook(2);
                                break;

                            case "2":
                                Console.WriteLine("\n\n\nEnter the grade you want to give to this student : (ex : 17/20) ");
                                grade = Console.ReadLine();
                                indexGrade = Class3[answer - 1].Gradebook.Subjects.IndexOf(Subject);
                                Class3[answer - 1].Gradebook.GradesExams[indexGrade] += grade + ", ";

                                Console.Clear();
                                Console.WriteLine("\n \nStudent graded.");
                                Console.WriteLine("\n\nHere is the new Gradebook of " + Class3[answer - 1].FirstName + " " + Class3[answer - 1].Name + " : \n");
                                Class3[answer - 1].ShowGradeBook(2);
                                break;
                        }
                        break;


                    case "4":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("___________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| GRADE A STUDENT |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("___________________\n\n\n\n");

                        index = 1;
                        Console.WriteLine("Choose the student you want to grade \n");
                        for (int i = 0; i < Class4.Count; i++)
                        {
                            Console.WriteLine(index + "- " + Class4[i].FirstName + " " + Class4[i].Name);
                            index++;
                        }
                        answer = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine("\n\nHere is the current Gradebook of " + Class4[answer - 1].FirstName + " " + Class4[answer - 1].Name + " : \n");
                        Class4[answer - 1].ShowGradeBook(2);

                        Console.WriteLine("\nDo you want to grade this student for an : \n1 - Assignement \n2 - Exam ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("\n\n\nEnter the grade you want to give to this student : (ex : 17/20) ");
                                string grade = Console.ReadLine();
                                int indexGrade = Class4[answer - 1].Gradebook.Subjects.IndexOf(Subject);
                                Class4[answer - 1].Gradebook.GradesAssignements[indexGrade] += grade + ", ";

                                Console.Clear();
                                Console.WriteLine("\n \nStudent graded.");
                                Console.WriteLine("\n\nHere is the new Gradebook of " + Class4[answer - 1].FirstName + " " + Class4[answer - 1].Name + " : \n");
                                Class4[answer - 1].ShowGradeBook(2);
                                break;

                            case "2":
                                Console.WriteLine("\n\n\nEnter the grade you want to give to this student : (ex : 17/20) ");
                                grade = Console.ReadLine();
                                indexGrade = Class4[answer - 1].Gradebook.Subjects.IndexOf(Subject);
                                Class4[answer - 1].Gradebook.GradesExams[indexGrade] += grade + ", ";

                                Console.Clear();
                                Console.WriteLine("\n \nStudent graded.");
                                Console.WriteLine("\n\nHere is the new Gradebook of " + Class4[answer - 1].FirstName + " " + Class4[answer - 1].Name + " : \n");
                                Class4[answer - 1].ShowGradeBook(2);
                                break;
                        }
                        break;
                }

                Console.WriteLine("\nDo you want to grade another student ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 2)
                {
                    finish = true;
                }
            }
        }


        // 6 - Display information of one of your student
        public void DisplayInformationStudent()
        {
            Console.Clear();
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("______________________");
                Console.WriteLine("\n");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("| STUDENT INFORMATION |");
                Console.WriteLine("");
                for (int i = 0; i < 90; i++) { Console.Write(" "); }
                Console.Write("______________________\n\n\n\n");

                Console.WriteLine("\n\nChoose the class of the student whose information you want to display\n");
                if (NameClass1 != "")
                {
                    Console.WriteLine("1- " + NameClass1 + "\n");
                }
                if (NameClass2 != "")
                {
                    Console.WriteLine("2- " + NameClass2 + "\n");
                }
                if (NameClass3 != "")
                {
                    Console.WriteLine("3- " + NameClass3 + "\n");
                }
                if (NameClass4 != "")
                {
                    Console.WriteLine("4- " + NameClass4 + "\n");
                }

                Console.WriteLine("\n\n\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("______________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| STUDENT INFORMATION |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("______________________\n\n\n\n");

                        int index = 1;
                        Console.WriteLine("\n\nChoose the student whose information you want to display \n");
                        for (int i = 0; i < Class1.Count; i++)
                        {
                            Console.WriteLine("\n" + index + "- " + Class1[i].FirstName + " " + Class1[i].Name);
                            index++;
                        }
                        int answer = Convert.ToInt32(Console.ReadLine());

                        bool finish2 = false;
                        while (finish2 == false)
                        {
                            Console.WriteLine("\n\n\nWhat information about this student would you like to consult? \n\n1- Gradebook \n2- Attendance \n3- Nothing");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Class1[answer - 1].ShowGradeBook(1);
                                    break;

                                case "2":
                                    Class1[answer - 1].ShowAttendance();
                                    break;

                                case "3":
                                    finish2 = true;
                                    break;
                            }
                        }
                        break;

                    case "2":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("______________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| STUDENT INFORMATION |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("______________________\n\n\n\n");

                        index = 1;
                        Console.WriteLine("\n\nChoose the student whose information you want to display\n");
                        for (int i = 0; i < Class2.Count; i++)
                        {
                            Console.WriteLine("\n" + index + "- " + Class2[i].FirstName + " " + Class2[i].Name);
                            index++;
                        }
                        answer = Convert.ToInt32(Console.ReadLine());

                        finish2 = false;
                        while (finish2 == false)
                        {
                            Console.WriteLine("\n\n\nWhat information about this student would you like to consult? \n\n1- Gradebook \n2- Attendance \n3- Nothing");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Class1[answer - 1].ShowGradeBook(1);
                                    break;

                                case "2":
                                    Class1[answer - 1].ShowAttendance();
                                    break;

                                case "3":
                                    finish2 = true;
                                    break;
                            }
                        }
                        break;


                    case "3":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("______________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| STUDENT INFORMATION |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("______________________\n\n\n\n");

                        index = 1;
                        Console.WriteLine("\n\nChoose the student whose information you want to display \n");
                        for (int i = 0; i < Class3.Count; i++)
                        {
                            Console.WriteLine("\n" + index + "- " + Class3[i].FirstName + " " + Class3[i].Name);
                            index++;
                        }
                        answer = Convert.ToInt32(Console.ReadLine());

                        finish2 = false;
                        while (finish2 == false)
                        {
                            Console.WriteLine("\n\n\nWhat information about this student would you like to consult? \n\n1- Gradebook \n2- Attendance \n3- Nothing");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Class1[answer - 1].ShowGradeBook(1);
                                    break;

                                case "2":
                                    Class1[answer - 1].ShowAttendance();
                                    break;

                                case "3":
                                    finish2 = true;
                                    break;
                            }
                        }
                        break;


                    case "4":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("______________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| STUDENT INFORMATION |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("______________________\n\n\n\n");

                        index = 1;
                        Console.WriteLine("\n\nChoose the student whose information you want to display \n");
                        for (int i = 0; i < Class4.Count; i++)
                        {
                            Console.WriteLine("\n" + index + "- " + Class4[i].FirstName + " " + Class4[i].Name);
                            index++;
                        }
                        answer = Convert.ToInt32(Console.ReadLine());

                        finish2 = false;
                        while (finish2 == false)
                        {
                            Console.WriteLine("\n\n\nWhat information about this student would you like to consult? \n \n1- Gradebook \n2- Attendance \n3- Nothing");
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Class1[answer - 1].ShowGradeBook(1);
                                    break;

                                case "2":
                                    Class1[answer - 1].ShowAttendance();
                                    break;

                                case "3":
                                    finish2 = true;
                                    break;
                            }
                        }
                        break;
                }

                Console.WriteLine("\nDo you want to display another student's information ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 2)
                {
                    finish = true;
                }
            }
        }


        // 7 - Display information from a student you are tutoring
        public void DisplayInformationTutoringStudent()
        {
            Console.Clear();
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 85; i++) { Console.Write(" "); }
                Console.Write("_________________________________");
                Console.WriteLine("\n");
                for (int i = 0; i < 85; i++) { Console.Write(" "); }
                Console.Write("| STUDENT INFORMATION - TUTORING |");
                Console.WriteLine("");
                for (int i = 0; i < 85; i++) { Console.Write(" "); }
                Console.Write("_________________________________\n\n\n\n");

                Console.WriteLine("\n\nThese are the students you are tutoring :\n");

                for (int i = 0; i < TutorStudentList.Count; i++)
                {
                    Console.WriteLine(i + 1 + "- " + TutorStudentList[i].FirstName + " " + TutorStudentList[i].Name + "\n");
                }

                Console.WriteLine("\n\n\nChoose the student whose information you want to display");
                int answer = Convert.ToInt32(Console.ReadLine());

                bool finish2 = false;
                while (finish2 == false)
                {
                    Console.WriteLine("\n\n\nWhat information about this student would you like to consult? \n1- Contact and personal details \n2- Gradebook \n3- Attendance \n4- Nothing");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            TutorStudentList[answer - 1].ShowAndModifyPersonalInformation(2);
                            break;

                        case "2":
                            TutorStudentList[answer - 1].ShowGradeBook(1);
                            break;

                        case "3":
                            TutorStudentList[answer - 1].ShowAttendance();
                            break;

                        case "4":
                            finish2 = true;
                            break;
                    }
                }

                Console.WriteLine("\n\n\nDo you want to display another student's information ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 2)
                {
                    finish = true;
                }
            }
        }


        public double FindIndexCourse()
        {
            double index = 0;
            DateTime date = DateTime.Now;
            if (Convert.ToString(date.DayOfWeek) == "Monday")
            {
                index = 1;
            }
            if (Convert.ToString(date.DayOfWeek) == "Tuesday")
            {
                index = 2;
            }
            if (Convert.ToString(date.DayOfWeek) == "Wednesday")
            {
                index = 3;
            }
            if (Convert.ToString(date.DayOfWeek) == "Thursday")
            {
                index = 4;
            }
            if (Convert.ToString(date.DayOfWeek) == "Friday")
            {
                index = 5;
            }

            double hour = date.Hour;
            double minute = date.Minute;
            double time = minute / 100 + hour;

            if (time >= 8.30 && time <= 10.15)
            {
                index = index + 0.1;
            }
            if (time >= 10.30 && time <= 12.15)
            {
                index = index + 0.2;
            }
            if (time >= 13.30 && time <= 15.15)
            {
                index = index + 0.3;
            }
            if (time >= 15.30 && time <= 17.15)
            {
                index = index + 0.4;
            }
            if (time >= 17.30 && time <= 19.15)
            {
                index = index + 0.5;
            }
            return index;
        }
    }
}

