using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Group1_OOP
{
    public class GradeBook
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD

        public List<string> Subjects { get; set; }
        public List<string> GradesAssignements { get; set; }
        public List<string> GradesExams { get; set; }

        public GradeBook(string studID, string Class, List<Course> Courses)
        {
            string nomFichier = "GradeBookClass" + Class + ".csv";

            List<string> ListSubjects = new List<string>();
            List<string> ListGradesAssignements = new List<string>();
            List<string> ListGradesExams = new List<string>();

            SortedList<string, List<string>> list = new SortedList<string, List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader(nomFichier);
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[31];
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

            int key = list.IndexOfKey(studID);
            //Console.WriteLine(key);
            for (int i = 0; i < datas.Length - 3; i = i + 3)
            {
                ListSubjects.Add(list.ElementAt(key).Value[i]);
                ListGradesAssignements.Add(list.ElementAt(key).Value[i + 1]);
                ListGradesExams.Add(list.ElementAt(key).Value[i + 2]);
            }

            Subjects = ListSubjects;
            GradesAssignements = ListGradesAssignements;
            GradesExams = ListGradesExams;
        }
    }
}
