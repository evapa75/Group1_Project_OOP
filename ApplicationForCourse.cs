using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class ApplicationForCourse
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD

        public string StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentName { get; set; }
        public int StudyYear { get; set; }
        public string StudentClass { get; set; }
        public List<Course> StudentCourses { get; set; }
        public Timetable StudentTimetable { get; set; }

        public string CourseName { get; set; }
        public string ProfID { get; set; }
        public string ProfFirstName { get; set; }
        public string ProfName { get; set; }


        public List<Student> StudentList { get; set; }
        public List<Professor> ProfessorList { get; set; }

        public ApplicationForCourse(string id, string firstname, string name, int year, string _class, List<Course> courses, Timetable timetable, string courseName, string profID, string profFirstName, string profName, List<Student> studentList)
        {
            StudentID = id;
            StudentFirstName = firstname;
            StudentName = name;
            StudyYear = year;
            StudentClass = _class;
            StudentCourses = courses;
            StudentTimetable = timetable;

            CourseName = courseName;
            ProfID = profID;
            ProfFirstName = profFirstName;
            ProfName = profName;

            StudentList = studentList;
        }

        public void ShowApplicationForRegistration(int number)
        {
            Console.WriteLine(number + "- " + $"First name: { StudentFirstName}  Name: { StudentName}  Year: { StudyYear}  Class : { StudentClass} \n   Requested course : {CourseName}  with {ProfFirstName} {ProfName} \n\n");
        }

        public void AddNewApplication()
        {
            StreamWriter fichEcr = new StreamWriter("ApplicationsForCourses.csv", true);
            string lastLine = StudentID + ";" + StudentFirstName + ";" + StudentName + ";" + StudyYear + ";" + StudentClass + ";" + CourseName + ";" + ProfID + ";" + ProfFirstName + ";" + ProfName;
            fichEcr.WriteLine(lastLine);
            fichEcr.Close();
        }

        public void RemoveApplication()
        {
            int counter = 0;
            List<List<string>> list = new List<List<string>>();

            StreamReader fichLect = new StreamReader("ApplicationsForCourses.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[9];
            while (fichLect.Peek() > 0)
            {
                List<string> l = new List<string>();
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

                    l.Add(studentID);
                    l.Add(studentFirstName);
                    l.Add(studentName);
                    l.Add(Convert.ToString(studyYear));
                    l.Add(_class);
                    l.Add(course);
                    l.Add(profID);
                    l.Add(profFirstName);
                    l.Add(profName);

                    list.Add(l);
                }
                counter = 1;
            }
            fichLect.Close();

            int index = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Contains(StudentID))
                {
                    index = i;
                }
            }
            list.RemoveAt(index);

            StreamWriter fichEcr = new StreamWriter("ApplicationsForCourses.csv");
            string firstLine = "StudentID" + ";" + "First name" + ";" + "Name" + ";" + "Study year" + ";" + "Class" + ";" + "Course" + ";" + "ProfID" + ";" + "First name" + ";" + "Name";
            fichEcr.WriteLine(firstLine);

            foreach (List<string> l in list)
            {
                string Line = "";
                for (int i = 0; i < l.Count - 1; i++)
                {
                    Line += l[i] + ";";
                }
                fichEcr.WriteLine(Line);
            }

            fichEcr.Close();
        }

        //public void FillInApplicationsList()
        //{
        //    int counter = 0;
        //    StreamReader fichLect = new StreamReader("ApplicationsForCourses.csv");
        //    char[] sep = new char[1] { ';' };
        //    string line = "";
        //    string[] datas = new string[9];
        //    while (fichLect.Peek() > 0)
        //    {
        //        line = fichLect.ReadLine();
        //        if (counter == 1)
        //        {
        //            datas = line.Split(sep);
        //            string studentID = datas[0];
        //            string studentFirstName = datas[1];
        //            string studentName = datas[2];
        //            int studyYear = Convert.ToInt32(datas[3]);
        //            string _class = datas[4];
        //            string course = datas[5];
        //            string profID = datas[6];
        //            string profFirstName = datas[7];
        //            string profName = datas[8];
        //            
        //            ApplicationForCourse app = new ApplicationForCourse(studentID, studentFirstName, studentName, studyYear, _class, StudentList.Find(x => x.ID.Contains(studentID)).Courses, StudentList.Find(x => x.ID.Contains(studentID)).Timetable, course, profID, profFirstName, profName, StudentList);
        //            //ListApplications.Add(app);
        //        }
        //        counter = 1;
        //    }
        //    fichLect.Close();
        //}
    }
}
