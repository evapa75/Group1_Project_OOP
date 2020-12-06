using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class CoursePlan
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD

        public string Class { get; set; }
        public string ProfessorID { get; set; }
        public string Subject { get; set; }
        public Professor Professor { get; set; }
        public List<Student> StudentList { get; set; }
        public List<Professor> ProfessorList { get; set; }

        public string S1week1 { get; set; }
        public string S1week2 { get; set; }
        public string S1week3 { get; set; }
        public string S1week4 { get; set; }
        public string S1week5 { get; set; }
        public string S1week6 { get; set; }
        public string S1week7 { get; set; }
        public string S1week8 { get; set; }
        public string S1week9 { get; set; }
        public string S1week10 { get; set; }
        public string S1week11 { get; set; }
        public string S1week12 { get; set; }

        public string S2week1 { get; set; }
        public string S2week2 { get; set; }
        public string S2week3 { get; set; }
        public string S2week4 { get; set; }
        public string S2week5 { get; set; }
        public string S2week6 { get; set; }
        public string S2week7 { get; set; }
        public string S2week8 { get; set; }
        public string S2week9 { get; set; }
        public string S2week10 { get; set; }
        public string S2week11 { get; set; }
        public string S2week12 { get; set; }

        public List<string> Exams { get; set; }
        public List<string> Assignments { get; set; }

        public CoursePlan(string professorID, string _class, List<Student> studentList, List<Professor> professorList, string s1week1, string s1week2, string s1week3, string s1week4, string s1week5, string s1week6,
            string s1week7, string s1week8, string s1week9, string s1week10, string s1week11, string s1week12,
            string s2week1, string s2week2, string s2week3, string s2week4, string s2week5, string s2week6,
            string s2week7, string s2week8, string s2week9, string s2week10, string s2week11, string s2week12)
        {
            ProfessorID = professorID;
            Class = _class;
            StudentList = studentList;
            ProfessorList = professorList;
            Professor = ProfessorList.Find(x => x.ID.Contains(professorID));
            Subject = Professor.Subject;

            S1week1 = s1week1;
            S1week2 = s1week2;
            S1week3 = s1week3;
            S1week4 = s1week4;
            S1week5 = s1week5;
            S1week6 = s1week6;
            S1week7 = s1week7;
            S1week8 = s1week8;
            S1week9 = s1week9;
            S1week10 = s1week10;
            S1week11 = s1week11;
            S1week12 = s1week12;

            S2week1 = s2week1;
            S2week2 = s2week2;
            S2week3 = s2week3;
            S2week4 = s2week4;
            S2week5 = s2week5;
            S2week6 = s2week6;
            S2week7 = s2week7;
            S2week8 = s2week8;
            S2week9 = s2week9;
            S2week10 = s2week10;
            S2week11 = s2week11;
            S2week12 = s2week12;

            Exams = new List<string>();
            Assignments = new List<string>();
        }

        public override string ToString()
        {
            string content = "                                             COURSE PLAN"
                + "\n\n                                             " + Professor.Subject + " - Class " + Class
                + "\n\n\nGENERAL INFORMATION \n\nModule title = " + Professor.Subject + "\nProfessor name : " + Professor.FirstName + " " + Professor.Name + "\nProfessor email : " + Professor.SchoolEmail
                + "\n\nSEMESTER 1 "
                + "\n\nSemester 1 - Week 1 : \n" + S1week1
                + "\n\nSemester 1 - Week 2 : \n" + S1week2
                + "\n\nSemester 1 - Week 3 : \n" + S1week3
                + "\n\nSemester 1 - Week 4 : \n" + S1week4
                + "\n\nSemester 1 - Week 5 : \n" + S1week5
                + "\n\nSemester 1 - Week 6 : \n" + S1week6
                + "\n\nSemester 1 - Week 7 : \n" + S1week7
                + "\n\nSemester 1 - Week 8 : \n" + S1week8
                + "\n\nSemester 1 - Week 9 : \n" + S1week9
                + "\n\nSemester 1 - Week 10 : \n" + S1week10
                + "\n\nSemester 1 - Week 11 : \n" + S1week11
                + "\n\nSemester 1 - Week 12 : \n" + S1week12

                + "\n\n\nSEMESTER 2"
                + "\n\nSemester 2 - Week 1 : \n" + S2week1
                + "\n\nSemester 2 - Week 2 : \n" + S2week2
                + "\n\nSemester 2 - Week 3 : \n" + S2week3
                + "\n\nSemester 2 - Week 4 : \n" + S2week4
                + "\n\nSemester 2 - Week 5 : \n" + S2week5
                + "\n\nSemester 2 - Week 6 : \n" + S2week6
                + "\n\nSemester 2 - Week 7 : \n" + S2week7
                + "\n\nSemester 2 - Week 8 : \n" + S2week8
                + "\n\nSemester 2 - Week 9 : \n" + S2week9
                + "\n\nSemester 2 - Week 10 : \n" + S2week10
                + "\n\nSemester 2 - Week 11 : \n" + S2week11
                + "\n\nSemester 2 - Week 12 : \n" + S2week12
                ;
            return content;
        }

        public void ShowCoursePlan(int mode)
        {
            if (mode == 2)
            {
                Console.Clear();
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("______________");
                Console.WriteLine("\n");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("| COURSE PLAN |");
                Console.WriteLine("");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("______________");
                Console.WriteLine("\n\n\n\n" + Professor.Subject + " - Class " + Class);

                Console.WriteLine("\n\n\nGENERAL INFORMATION \n\nModule title = " + Professor.Subject + "\nProfessor name : " + Professor.FirstName + " " + Professor.Name + "\nProfessor email : " + Professor.SchoolEmail
                + "\n\n\nSEMESTER 1 "
                + "\n\nSemester 1 - Week 1 : \n" + S1week1
                + "\n\nSemester 1 - Week 2 : \n" + S1week2
                + "\n\nSemester 1 - Week 3 : \n" + S1week3
                + "\n\nSemester 1 - Week 4 : \n" + S1week4
                + "\n\nSemester 1 - Week 5 : \n" + S1week5
                + "\n\nSemester 1 - Week 6 : \n" + S1week6
                + "\n\nSemester 1 - Week 7 : \n" + S1week7
                + "\n\nSemester 1 - Week 8 : \n" + S1week8
                + "\n\nSemester 1 - Week 9 : \n" + S1week9
                + "\n\nSemester 1 - Week 10 : \n" + S1week10
                + "\n\nSemester 1 - Week 11 : \n" + S1week11
                + "\n\nSemester 1 - Week 12 : \n" + S1week12

                + "\n\n\nSEMESTER 2"
                + "\n\nSemester 2 - Week 1 : \n" + S2week1
                + "\n\nSemester 2 - Week 2 : \n" + S2week2
                + "\n\nSemester 2 - Week 3 : \n" + S2week3
                + "\n\nSemester 2 - Week 4 : \n" + S2week4
                + "\n\nSemester 2 - Week 5 : \n" + S2week5
                + "\n\nSemester 2 - Week 6 : \n" + S2week6
                + "\n\nSemester 2 - Week 7 : \n" + S2week7
                + "\n\nSemester 2 - Week 8 : \n" + S2week8
                + "\n\nSemester 2 - Week 9 : \n" + S2week9
                + "\n\nSemester 2 - Week 10 : \n" + S2week10
                + "\n\nSemester 2 - Week 11 : \n" + S2week11
                + "\n\nSemester 2 - Week 12 : \n" + S2week12); ;

                Console.WriteLine("\n\n\n");
                ShowExams();

                Console.WriteLine("\n\n\n");
                ShowAssignements();
            }
            else
            {
                bool finish = false;
                while (finish == false)
                {
                    Console.Clear();
                    for (int i = 0; i < 95; i++) { Console.Write(" "); }
                    Console.Write("______________");
                    Console.WriteLine("\n");
                    for (int i = 0; i < 95; i++) { Console.Write(" "); }
                    Console.Write("| COURSE PLAN |");
                    Console.WriteLine("");
                    for (int i = 0; i < 95; i++) { Console.Write(" "); }
                    Console.Write("______________");
                    Console.WriteLine("\n\n\n\n" + Professor.Subject + " - Class " + Class);

                    Console.WriteLine("\n\n\nGENERAL INFORMATION \n\nModule title = " + Professor.Subject + "\nProfessor name : " + Professor.FirstName + " " + Professor.Name + "\nProfessor email : " + Professor.SchoolEmail
                    + "\n\n\nSEMESTER 1 "
                    + "\n\nSemester 1 - Week 1 : \n" + S1week1
                    + "\n\nSemester 1 - Week 2 : \n" + S1week2
                    + "\n\nSemester 1 - Week 3 : \n" + S1week3
                    + "\n\nSemester 1 - Week 4 : \n" + S1week4
                    + "\n\nSemester 1 - Week 5 : \n" + S1week5
                    + "\n\nSemester 1 - Week 6 : \n" + S1week6
                    + "\n\nSemester 1 - Week 7 : \n" + S1week7
                    + "\n\nSemester 1 - Week 8 : \n" + S1week8
                    + "\n\nSemester 1 - Week 9 : \n" + S1week9
                    + "\n\nSemester 1 - Week 10 : \n" + S1week10
                    + "\n\nSemester 1 - Week 11 : \n" + S1week11
                    + "\n\nSemester 1 - Week 12 : \n" + S1week12

                    + "\n\n\nSEMESTER 2"
                    + "\n\nSemester 2 - Week 1 : \n" + S2week1
                    + "\n\nSemester 2 - Week 2 : \n" + S2week2
                    + "\n\nSemester 2 - Week 3 : \n" + S2week3
                    + "\n\nSemester 2 - Week 4 : \n" + S2week4
                    + "\n\nSemester 2 - Week 5 : \n" + S2week5
                    + "\n\nSemester 2 - Week 6 : \n" + S2week6
                    + "\n\nSemester 2 - Week 7 : \n" + S2week7
                    + "\n\nSemester 2 - Week 8 : \n" + S2week8
                    + "\n\nSemester 2 - Week 9 : \n" + S2week9
                    + "\n\nSemester 2 - Week 10 : \n" + S2week10
                    + "\n\nSemester 2 - Week 11 : \n" + S2week11
                    + "\n\nSemester 2 - Week 12 : \n" + S2week12); ;

                    Console.WriteLine("\n\n\n");
                    ShowExams();

                    Console.WriteLine("\n\n\n");
                    ShowAssignements();

                    Console.WriteLine("\n\n\nDo you want to close the course plan ? \n1 - YES \n2 - NO");
                    if (Console.ReadLine() == "1")
                    {
                        finish = true;
                    }
                }
            }
        }

        public void ShowExams()
        {

            Console.WriteLine("\nEXAM SECTION");
            foreach (string exam in Exams)
            {
                Console.WriteLine("\n\n" + exam);
            }

        }

        public void ShowAssignements()
        {
            Console.WriteLine("\nASSIGNEMENT SECTION");
            foreach (string assign in Assignments)
            {
                Console.WriteLine("\n\n" + assign);
            }
        }



        public void ModifyCoursePlan()
        {
            ShowCoursePlan(2);
            Console.WriteLine("\n\n\n\n\nThis is your current Course Plan");

            bool finish = false;
            bool nb2 = false;
            while (finish == false)
            {
                Console.WriteLine("\n\nFor which semester do you want to do a modification ? 1 or 2");
                int semester = Convert.ToInt32(Console.ReadLine());
                if (semester == 1)
                {
                    nb2 = false;
                    while (nb2 == false)
                    {
                        Console.WriteLine("\n\nFor which week do you want to do a modification ? 1 to 12");
                        int week = Convert.ToInt16(Console.ReadLine());
                        if (week == 1)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 1 \n\nEnter a new content :\n");
                            S1week1 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 2)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 2 \n\nEnter a new content :\n");
                            S1week2 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 3)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 3 \n\nEnter a new content :\n");
                            S1week3 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 4)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 4 \n\nEnter a new content :\n");
                            S1week4 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 5)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 5 \n\nEnter a new content :\n");
                            S1week5 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 6)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 6 \n\nEnter a new content :\n");
                            S1week6 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 7)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 7 \n\nEnter a new content :\n");
                            S1week7 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 8)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 8 \n\nEnter a new content :\n");
                            S1week8 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 9)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 9 \n\nEnter a new content :\n");
                            S1week9 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 10)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 10 \n\nEnter a new content :\n");
                            S1week10 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 11)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 11 \n\nEnter a new content :\n");
                            S1week11 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 12)
                        {
                            Console.WriteLine("\n\nSemester 1 - Week 12 \n\nEnter a new content :\n");
                            S1week12 = Console.ReadLine();
                            nb2 = true;
                        }
                    }
                }
                if (semester == 2)
                {
                    nb2 = false;
                    while (nb2 == false)
                    {
                        Console.WriteLine("\n\nFor which week do you want to do a modification ? 1 to 12");
                        int week = Convert.ToInt16(Console.ReadLine());
                        if (week == 1)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 1 \n\nEnter a new content :\n");
                            S2week1 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 2)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 2 \n\nEnter a new content :\n");
                            S2week2 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 3)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 3 \n\nEnter a new content :\n");
                            S2week3 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 4)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 4 \n\nEnter a new content :\n");
                            S2week4 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 5)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 5 \n\nEnter a new content :\n");
                            S2week5 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 6)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 6 \n\nEnter a new content :\n");
                            S2week6 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 7)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 7 \n\nEnter a new content :\n");
                            S2week7 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 8)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 8 \n\nEnter a new content :\n");
                            S2week8 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 9)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 9 \n\nEnter a new content :\n");
                            S2week9 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 10)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 10 \n\nEnter a new content :\n");
                            S2week10 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 11)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 11 \n\nEnter a new content :\n");
                            S2week11 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 12)
                        {
                            Console.WriteLine("\n\nSemester 2 - Week 12 \n\nEnter a new content :\n");
                            S2week12 = Console.ReadLine();
                            nb2 = true;
                        }
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

        public void ModifyExamSection()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                ShowExams();
                Console.WriteLine("\n\n\n\nWhat do you want to do with your exam ?\n1 - Add\n2 - Modify \n3 - Delete \n4 - Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("__________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| ADD A NEW EXAM |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("__________________\n\n\n\n");

                        Console.WriteLine("\nEnter the name of the exam");
                        string name = Console.ReadLine();
                        Console.WriteLine("\nEnter the date of the exam");
                        string date = Console.ReadLine();
                        Console.WriteLine("\nEnter the hour of the exam");
                        string hour = Console.ReadLine();
                        Console.WriteLine("\nEnter the duration of the exam");
                        string duration = Console.ReadLine();
                        string content = "";
                        Console.WriteLine("\nDo you want to add some information ?\n1 - YES \n2 - NO");
                        if (Console.ReadLine() == "1")
                        {
                            Console.WriteLine("\nEnter the additional information");
                            content = Console.ReadLine();
                        }
                        string examA = $"Name : {name}    Date : {date}    Hour : {hour}    Duration : {duration}    Additional Information : {content}";
                        Exams.Add(examA);
                        break;


                    case "2":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("__________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| MODIFY AN EXAM |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("__________________\n\n\n\n");

                        int number = 1;
                        int index = 0;
                        if (Exams.Count == 0)
                        {
                            Console.WriteLine("\nThere is no exam for the moment.");
                        }
                        else
                        {
                            Console.WriteLine("\nWhich exam do you want to modify ?");
                            foreach (string ex in Exams)
                            {
                                Console.WriteLine(number + " - " + ex + "\n");
                                number++;
                            }
                            index = Convert.ToInt32(Console.ReadLine()) - 1;

                            Console.Clear();
                            Console.WriteLine("\nEnter the new name of the exam");
                            name = Console.ReadLine();
                            Console.WriteLine("\nEnter the new date of the exam");
                            date = Console.ReadLine();
                            Console.WriteLine("\nEnter the new hour of the exam");
                            hour = Console.ReadLine();
                            Console.WriteLine("\nEnter the new duration of the exam");
                            duration = Console.ReadLine();
                            content = "";
                            Console.WriteLine("\nDo you want to add new additional information ?\n1 - YES \n2 - NO");
                            if (Console.ReadLine() == "1")
                            {
                                Console.WriteLine("\nEnter the new additional information");
                                content = Console.ReadLine();
                            }
                            string examM = $"Name : {name}    Date : {date}    Hour : {hour}    Duration : {duration}    Additional Information : {content}";
                            Exams[index] = examM;
                        }
                        break;


                    case "3":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("__________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| DELETE AN EXAM |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("__________________\n\n\n\n");

                        if (Exams.Count == 0)
                        {
                            Console.WriteLine("\nThere is no exam for the moment.");
                        }
                        else
                        {
                            number = 1;
                            Console.WriteLine("\n\nWhich exam do you want to delete ?");
                            foreach (string ex in Exams)
                            {
                                Console.WriteLine(number + " - " + ex + "\n");
                                number++;
                            }
                            index = Convert.ToInt32(Console.ReadLine()) - 1;
                            Exams.RemoveAt(index);
                        }
                        break;


                    case "4":
                        finish = true;
                        break;
                }

                Console.WriteLine("\n\nDo you want to add, modify or delete an other exam ?\n1 - YES \n2 - NO");
                if (Console.ReadLine() == "2")
                {
                    finish = true;
                }
            }
        }

        public void ModifyAssignementSection()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                ShowAssignements();
                Console.WriteLine("\n\nWhat do you want to do with your assignement ?\n1 - Add\n2 - Modify \n3 - Delete \n4 - Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("_________________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| ADD A NEW ASSIGNEMENT |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("_________________________\n\n\n\n");

                        Console.WriteLine("\nEnter the name of the assignement");
                        string name = Console.ReadLine();
                        Console.WriteLine("\nEnter the date of the assignement");
                        string date = Console.ReadLine();
                        Console.WriteLine("\nEnter the hour of the assignement");
                        string hour = Console.ReadLine();
                        Console.WriteLine("\nEnter the duration of the exam");
                        string duration = Console.ReadLine();
                        string content = "";
                        Console.WriteLine("\nDo you want to add some information ?\n1 - YES \n2 - NO");
                        if (Console.ReadLine() == "1")
                        {
                            Console.WriteLine("\nEnter the additional information");
                            content = Console.ReadLine();
                        }
                        string assignementA = $"Name : {name}    Date : {date}    Hour : {hour}    Duration : {duration}    Additional information : {content}";
                        Assignments.Add(assignementA);
                        break;

                    case "2":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("________________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| MODIFY AN ASSIGNEMENT |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("________________________\n\n\n\n");

                        int number = 1;
                        int index = 0;
                        if (Assignments.Count == 0)
                        {
                            Console.WriteLine("\nThere is no assignement for the moment.");
                        }
                        else
                        {
                            Console.WriteLine("\nWhich assignement do you want to modify ?");
                            foreach (string assign in Assignments)
                            {
                                Console.WriteLine(number + " - " + assign + "\n");
                                number++;
                            }
                            index = Convert.ToInt32(Console.ReadLine()) - 1;

                            Console.Clear();
                            Console.WriteLine("\nEnter the new name of the assignement");
                            name = Console.ReadLine();
                            Console.WriteLine("\nEnter the new date of the assignement");
                            date = Console.ReadLine();
                            Console.WriteLine("\nEnter the new hour of the assignement");
                            hour = Console.ReadLine();
                            Console.WriteLine("\nEnter the new duration of the exam");
                            duration = Console.ReadLine();
                            content = "";
                            Console.WriteLine("\nDo you want to add new additional information ?\n1 - YES \n2 - NO");
                            if (Console.ReadLine() == "1")
                            {
                                Console.WriteLine("\nEnter the new additional information");
                                content = Console.ReadLine();
                            }
                            string assignementM = $"Name : {name}    Date : {date}    Hour : {hour}    Duration : {duration}    Additional information :{content}";
                            Assignments[index] = assignementM;
                        }
                        break;


                    case "3":
                        Console.Clear();
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("________________________");
                        Console.WriteLine("\n");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("| DELETE AN ASSIGNEMENT |");
                        Console.WriteLine("");
                        for (int i = 0; i < 90; i++) { Console.Write(" "); }
                        Console.Write("________________________\n\n\n\n");

                        if (Assignments.Count == 0)
                        {
                            Console.WriteLine("\nThere is no assignement for the moment.");
                        }
                        else
                        {
                            number = 1;
                            Console.WriteLine("\nWhich assignement do you want to delete ?");
                            foreach (string assign in Assignments)
                            {
                                Console.WriteLine(number + " - " + assign + "\n");
                                number++;
                            }
                            index = Convert.ToInt32(Console.ReadLine()) - 1;
                            Assignments.RemoveAt(index);
                        }
                        break;


                    case "4":
                        finish = true;
                        break;
                }

                Console.WriteLine("\nDo you want to add, modify or delete an other assignement ?\n1 - YES \n2 - NO");
                if (Console.ReadLine() == "2")
                {
                    finish = true;
                }
            }
        }

    }
}
