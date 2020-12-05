using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class Timetable
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD


        public List<Course> Courses { get; set; }
        public string[] tab_save_subject { get; set; }

        //Courses on Monday
        public Course CourseM1 { get; set; }
        public Course CourseM2 { get; set; }
        public Course CourseM3 { get; set; }
        public Course CourseM4 { get; set; }
        public Course CourseM5 { get; set; }

        //Courses on Tuesday
        public Course CourseT1 { get; set; }
        public Course CourseT2 { get; set; }
        public Course CourseT3 { get; set; }
        public Course CourseT4 { get; set; }
        public Course CourseT5 { get; set; }

        //Courses on Wednesday
        public Course CourseW1 { get; set; }
        public Course CourseW2 { get; set; }
        public Course CourseW3 { get; set; }
        public Course CourseW4 { get; set; }
        public Course CourseW5 { get; set; }

        //Courses on Thursday
        public Course CourseTH1 { get; set; }
        public Course CourseTH2 { get; set; }
        public Course CourseTH3 { get; set; }
        public Course CourseTH4 { get; set; }
        public Course CourseTH5 { get; set; }

        //Courses on Friday
        public Course CourseF1 { get; set; }
        public Course CourseF2 { get; set; }
        public Course CourseF3 { get; set; }
        public Course CourseF4 { get; set; }
        public Course CourseF5 { get; set; }


        public Timetable(List<Course> courses)
        {
            Courses = courses;

            SaveSubjects();

            //Courses on Monday
            CourseM1 = courses[0];
            CourseM2 = courses[1];
            CourseM3 = courses[2];
            CourseM4 = courses[3];
            CourseM5 = courses[4];

            //Courses on Tuesday
            CourseT1 = courses[5];
            CourseT2 = courses[6];
            CourseT3 = courses[7];
            CourseT4 = courses[8];
            CourseT5 = courses[9];

            //Courses on Wednesday
            CourseW1 = courses[10];
            CourseW2 = courses[11];
            CourseW3 = courses[12];
            CourseW4 = courses[13];
            CourseW5 = courses[14];

            //Courses on Thursday
            CourseTH1 = courses[15];
            CourseTH2 = courses[16];
            CourseTH3 = courses[17];
            CourseTH4 = courses[18];
            CourseTH5 = courses[19];

            //Courses on Friday
            CourseF1 = courses[20];
            CourseF2 = courses[21];
            CourseF3 = courses[22];
            CourseF4 = courses[23];
            CourseF5 = courses[24];
        }


        public void ShowTimetableStudent()
        {
            foreach (Course c in Courses)
            {
                if (c.Subject.Length <= 4)
                {
                    c.Subject = "      " + c.Subject + "          ";
                }
                if (c.Subject.Length > 4 && c.Subject.Length <= 8)
                {
                    c.Subject = "    " + c.Subject + "        ";
                }
                if (c.Subject.Length > 8 && c.Subject.Length < 12)
                {
                    c.Subject = "  " + c.Subject + "       ";
                }
                if (c.Subject.Length >= 12 && c.Subject.Length < 15)
                {
                    c.Subject = " " + c.Subject + "    ";
                }
                if (c.Subject.Length >= 15)
                {
                    c.Subject = c.Subject + "  ";
                }
            }

            for (int i = 0; i < 95; i++) { Console.Write(" "); }
            Console.Write("_____________");
            Console.WriteLine("\n");
            for (int i = 0; i < 95; i++) { Console.Write(" "); }
            Console.Write("| TIMETABLE |");
            Console.WriteLine("");
            for (int i = 0; i < 95; i++) { Console.Write(" "); }
            Console.Write("_____________\n\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n\n\n                      Monday             Tuesday               Wednesday              Thursday               Friday");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n8h30-10h15       " + CourseM1.Subject +/* length1 +*/ CourseT1.Subject + /*length2 +*/ CourseW1.Subject + /*length3*/ /*+*/ CourseTH1.Subject + /*length4 +*/ CourseF1.Subject + "\n");
            Console.WriteLine("10h30-12h15      " + CourseM2.Subject + /*length1 +*/ CourseT2.Subject + /*length2 +*/ CourseW2.Subject + /*length3*/ /*+*/ CourseTH2.Subject + /*length4 + */CourseF2.Subject + "\n");
            Console.WriteLine();
            Console.WriteLine("13h30-15h15      " + CourseM3.Subject + /*length1 +*/ CourseT3.Subject + /*length2 +*/ CourseW3.Subject + /*length3*/ /*+*/ CourseTH3.Subject + /*length4 + */CourseF3.Subject + "\n");
            Console.WriteLine("15h30-17h15      " + CourseM4.Subject + /*length1 +*/ CourseT4.Subject + /*length2 +*/ CourseW4.Subject + /*length3 +*/ CourseTH4.Subject +/* length4 +*/ CourseF4.Subject + "\n");
            Console.WriteLine("17h30-19h15      " + CourseM5.Subject + /*length1 + */ CourseT5.Subject + /*length2 +*/ CourseW5.Subject + /*length3 + */CourseTH5.Subject +/* length4 +*/ CourseF5.Subject + "\n");

            //Remettre les bonnes valeurs aux sujets sans les espaces
            Courses[0].Subject = tab_save_subject[0];
            Courses[1].Subject = tab_save_subject[1];
            Courses[2].Subject = tab_save_subject[2];
            Courses[3].Subject = tab_save_subject[3];
            Courses[4].Subject = tab_save_subject[4];

            Courses[5].Subject = tab_save_subject[5];
            Courses[6].Subject = tab_save_subject[6];
            Courses[7].Subject = tab_save_subject[7];
            Courses[8].Subject = tab_save_subject[8];
            Courses[9].Subject = tab_save_subject[9];

            Courses[10].Subject = tab_save_subject[10];
            Courses[11].Subject = tab_save_subject[11];
            Courses[12].Subject = tab_save_subject[12];
            Courses[13].Subject = tab_save_subject[13];
            Courses[14].Subject = tab_save_subject[14];

            Courses[15].Subject = tab_save_subject[15];
            Courses[16].Subject = tab_save_subject[16];
            Courses[17].Subject = tab_save_subject[17];
            Courses[18].Subject = tab_save_subject[18];
            Courses[19].Subject = tab_save_subject[19];

            Courses[20].Subject = tab_save_subject[20];
            Courses[21].Subject = tab_save_subject[21];
            Courses[22].Subject = tab_save_subject[22];
            Courses[23].Subject = tab_save_subject[23];
            Courses[24].Subject = tab_save_subject[24];
        }

        public void ShowTimetableProfessor()
        {
            string space = "                   ";

            for (int i = 0; i < 95; i++) { Console.Write(" "); }
            Console.Write("_____________");
            Console.WriteLine("\n");
            for (int i = 0; i < 95; i++) { Console.Write(" "); }
            Console.Write("| TIMETABLE |");
            Console.WriteLine("");
            for (int i = 0; i < 95; i++) { Console.Write(" "); }
            Console.Write("_____________\n\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n\n                    Monday             Tuesday           Wednesday            Thursday             Friday");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n8h30-10h15            " + CourseM1.ProfessorID_or_NameOfClass + space + CourseT1.ProfessorID_or_NameOfClass + space + CourseW1.ProfessorID_or_NameOfClass + space + CourseTH1.ProfessorID_or_NameOfClass + space + CourseF1.ProfessorID_or_NameOfClass + "\n");
            Console.WriteLine("10h30-12h15           " + CourseM2.ProfessorID_or_NameOfClass + space + CourseT2.ProfessorID_or_NameOfClass + space + CourseW2.ProfessorID_or_NameOfClass + space + CourseTH2.ProfessorID_or_NameOfClass + space + CourseF2.ProfessorID_or_NameOfClass + "\n");
            Console.WriteLine();
            Console.WriteLine("13h30-15h15           " + CourseM3.ProfessorID_or_NameOfClass + space + CourseT3.ProfessorID_or_NameOfClass + space + CourseW3.ProfessorID_or_NameOfClass + space + CourseTH3.ProfessorID_or_NameOfClass + space + CourseF3.ProfessorID_or_NameOfClass + "\n");
            Console.WriteLine("15h30-17h15           " + CourseM4.ProfessorID_or_NameOfClass + space + CourseT4.ProfessorID_or_NameOfClass + space + CourseW4.ProfessorID_or_NameOfClass + space + CourseTH4.ProfessorID_or_NameOfClass + space + CourseF4.ProfessorID_or_NameOfClass + "\n");
            Console.WriteLine("17h30-19h15           " + CourseM5.ProfessorID_or_NameOfClass + space + CourseT5.ProfessorID_or_NameOfClass + space + CourseW5.ProfessorID_or_NameOfClass + space + CourseTH5.ProfessorID_or_NameOfClass + space + CourseF5.ProfessorID_or_NameOfClass + "\n");

        }

        public void SaveSubjects()
        {
            tab_save_subject = new string[Courses.Count];
            for (int i = 0; i < tab_save_subject.Length; i++)
            {
                tab_save_subject[i] = Courses[i].Subject;
            }
        }
    }
}
