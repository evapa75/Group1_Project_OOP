using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Group1_OOP
{
    public class GradeBook
    {
        public List<string> Subjects { get; set; }
        public List<string> Grades { get; set; }
        //public SortedList<string, List<string>> Gradebook {get;set;}

        public GradeBook(string studID, string Class, List<Course> Courses)
        {
            string nomFichier = "GradeBookClass" + Class + ".csv";
            //Console.WriteLine(nomFichier);

            List<string> ListSubjects = new List<string>();
            List<string> ListGrades = new List<string>();
            SortedList<string, List<string>> list = new SortedList<string, List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader(nomFichier);
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[21];
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
                        //Console.WriteLine(studentID + " " + datas[i]);
                    }
                    list.Add(studentID, l);
                }
                counter = 1;
                //Console.WriteLine();
            }

            int key = list.IndexOfKey(studID);
            //Console.WriteLine(key);
            for (int i = 0; i < datas.Length - 1; i = i + 2)
            {
                ListSubjects.Add(list.ElementAt(key).Value[i]);
                ListGrades.Add(list.ElementAt(key).Value[i + 1]);
                //Console.WriteLine(list.ElementAt(key).Value[i] + " " + list.ElementAt(key).Value[i + 1]);
            }

            Subjects = ListSubjects;
            Grades = ListGrades;
        }

        //public List<string> FindSubjects(List<string> ListProfID, List<Course> Courses)
        //{
        //    List<string> Subjects = new List<string>();
        //    foreach (string profID in ListProfID)
        //    {
        //        Course c = Courses.Find(x => x.TeacherID_or_NameOfClass.Contains(profID));
        //        Console.WriteLine(c.Subject);
        //        if (c.Subject != "Free")
        //        {
        //            Subjects.Add(c.Subject);
        //        }
        //    }
        //    return Subjects;
        //}


        public void EditGradeBook()
        {

        }
    }
}
