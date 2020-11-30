using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class Professor : Person
    {
        public string Subject { get; set; }
        public List<Student> Class1 { get; set; }
        public List<Student> Class2 { get; set; }
        public List<Student> Class3 { get; set; }
        public List<Student> Class4 { get; set; }
        public bool Tutor { get; set; }
        public List<Student> TutorStudentList { get; set; }

        public List<Course> Courses { get; set; }
        public Timetable Timetable { get; set; }

        public CoursePlan CoursePlan { get; set; }

        public Professor(string id, string firstName, string name, string gender, string birthdate, string persoEmailAdress, string phoneNumber, string adress, string password, string subject, string tutor, string name_class1, string name_class2, string name_class3, string name_class4)
            : base(id, firstName, name, gender, birthdate, persoEmailAdress, phoneNumber, adress, password)
        {

            Subject = subject;

            List<Student> allStudents = AllStudents();

            //Remplissage des classes du professeur
            Class1 = new List<Student>();
            Class2 = new List<Student>();
            Class3 = new List<Student>();
            Class4 = new List<Student>();

            foreach (Student s in allStudents)
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


            if (tutor == "yes")
            {
                Tutor = true;
            }
            else
            {
                Tutor = false;
            }

            if (Tutor == true)
            {
                List<string> StudentList = ResearchStudentsIDForTutoring();

                TutorStudentList = ResearchStudentsForTutoring(StudentList);
            }



            Courses = new List<Course>();

            //Remplissage de la liste de cours Courses
            List<string> listCourses = new List<string>();
            SortedList<string, List<string>> list = new SortedList<string, List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("Timetables_Professors.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[126];
            while (fichLect.Peek() > 0)
            {
                line = fichLect.ReadLine(); //Lecture d'une ligne
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
                Course c = new Course(Convert.ToDouble(listCourses[i]), listCourses[i + 1], listCourses[i + 2], Convert.ToInt32(listCourses[i + 3]), Convert.ToInt32(listCourses[i + 4]));
                //Console.WriteLine(Convert.ToDouble(listCourses[i]) + ";" + listCourses[i + 1] + ";" + listCourses[i + 2] + ";" + listCourses[i + 3] + ";" + listCourses[i + 4]);
                Courses.Add(c);
            }

            //Création de l'edt à partir de la liste de cours
            Timetable = new Timetable(Courses);
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
                line = fichLect.ReadLine(); //Lecture d'une ligne
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

            int key = list.IndexOfKey(ID);
            for (int i = 0; i < 10; i++)
            {
                listStudents.Add(list.ElementAt(key).Value[i]);
            }
            return listStudents;
        }


        public List<Student> AllStudents()
        {
            List<Student> allStudents = new List<Student>();
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
                    allStudents.Add(S);
                }
                counter = 1;
            }
            return allStudents;
        }


        // On génère la liste d'élèves à partir du fichier .csv
        // A partir de la liste de string avec les ID des élèves, on trouve les élèves correspondants dans le fichier .csv
        // et on remplit une List<Student> qui contient les élèves (et leurs infos persos) dont le prof est le tuteur 
        public List<Student> ResearchStudentsForTutoring(List<string> StudentList_string)
        {
            List<Student> studentList = new List<Student>();

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
                    string id = datas[0]; //conversion des elements du fichier ATTENTION TOUS LES ELEMENTS SONT PLACES DANS L ELEMENT ZERO !
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
                    //Console.WriteLine(id + ";" + firstname + ";" + name + ";" + gender + ";" + birthdate + ";" + year + ";" + personalEmailAdress + ";" + phoneNumber + ";" + adress + ";" + password + ";" + tutorID + ";" + fees);
                    Student S = new Student(id, firstname, name, gender, birthdate, _class, personalEmailAdress, phoneNumber, adress, password, tutorID, fees);
                    studentList.Add(S);
                }
                counter = 1;
            }

            foreach (string studentID in StudentList_string)
            {
                Student s = studentList.Find(x => x.ID.Contains(studentID));
                studentList.Add(s);
            }

            return studentList;
        }


        public void ShowAndModifyPersonalInformation()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                Console.WriteLine($"Professor Profile {FirstName} { Name.ToUpper()} \n\n");
                Console.WriteLine("Personal identifying information : \n\n" +
                    FirstName + " " + Name.ToUpper() +
                    $"\nID : {ID}" +
                    $"\nSubject : {Subject}" +
                    $"\nTutor? : {Tutor}" +
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
    }
}
