using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class CoursePlan
    {
        public string Class { get; set; }
        public string ProfessorID { get; set; }

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

        string Exams { get; set; }
        string Assignments { get; set; }

        public CoursePlan(string professorID, string _class, string s1week1, string s1week2, string s1week3, string s1week4, string s1week5, string s1week6, 
            string s1week7, string s1week8, string s1week9, string s1week10, string s1week11, string s1week12,
            string s2week1, string s2week2, string s2week3, string s2week4, string s2week5, string s2week6,
            string s2week7, string s2week8, string s2week9, string s2week10, string s2week11, string s2week12, string exams, string assignements)
        {
            ProfessorID = professorID;
            Class = _class;
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

            Exams = exams;
            Assignments = assignements;
        }

        public override string ToString()
        {
            string content = "Course plan :\n"
                + "\nSemester 1 - Week 1 :          " + S1week1
                + "\n\nSemester 1 - Week 2 :          " + S1week2
                + "\n\nSemester 1 - Week 3 :          " + S1week3
                + "\n\nSemester 1 - Week 4 :          " + S1week4
                + "\n\nSemester 1 - Week 5 :          " + S1week5
                + "\n\nSemester 1 - Week 6 :          " + S1week6
                + "\n\nSemester 1 - Week 7 :          " + S1week7
                + "\n\nSemester 1 - Week 8 :          " + S1week8
                + "\n\nSemester 1 - Week 9 :          " + S1week9
                + "\n\nSemester 1 - Week 10 :         " + S1week10
                + "\n\nSemester 1 - Week 11 :         " + S1week11
                + "\n\nSemester 1 - Week 12 :         " + S1week12
                + "\n\nSemester 2 - Week 1 :          " + S2week1
                + "\n\nSemester 2 - Week 2 :          " + S2week2
                + "\n\nSemester 2 - Week 3 :          " + S2week3
                + "\n\nSemester 2 - Week 4 :          " + S2week4
                + "\n\nSemester 2 - Week 5 :          " + S2week5
                + "\n\nSemester 2 - Week 6 :          " + S2week6
                + "\n\nSemester 2 - Week 7 :          " + S2week7
                + "\n\nSemester 2 - Week 8 :          " + S2week8
                + "\n\nSemester 2 - Week 9 :          " + S2week9
                + "\n\nSemester 2 - Week 10 :         " + S2week10
                + "\n\nSemester 2 - Week 11 :         " + S2week11
                + "\n\nSemester 2 - Week 12 :         " + S2week12
                ;
            return content;
        }

        public void ModifyCoursePlan()
        {
            bool nb1 = false;
            bool nb2 = false;
            while (nb1 == false)
            {
                Console.Clear();
                Console.WriteLine("For which semester do you want to do a modification ? 1 or 2");
                int semester = Convert.ToInt16(Console.ReadLine());
                if (semester == 1)
                {
                    while (nb2 == false)
                    {
                        Console.Clear();
                        Console.WriteLine("For which week do you want to do a modification ? 1 to 12");
                        int week = Convert.ToInt16(Console.ReadLine());
                        if (week == 1)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week1 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 2)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week2 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 3)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week3 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 4)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week4 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 5)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week5 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 6)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week6 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 7)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week7 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 8)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week8 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 9)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week9 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 10)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week10 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 11)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week11 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 12)
                        {
                            Console.WriteLine("Enter a new content");
                            S1week12 = Console.ReadLine();
                            nb2 = true;
                        }
                    }
                    nb1 = true;
                }
                if (semester == 2)
                {
                    while (nb2 == false)
                    {
                        Console.Clear();
                        Console.WriteLine("For which week do you want to do a modification ? 1 to 12");
                        int week = Convert.ToInt16(Console.ReadLine());
                        if (week == 1)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week1 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 2)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week2 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 3)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week3 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 4)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week4 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 5)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week5 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 6)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week6 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 7)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week7 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 8)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week8 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 9)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week9 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 10)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week10 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 11)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week11 = Console.ReadLine();
                            nb2 = true;
                        }
                        if (week == 12)
                        {
                            Console.WriteLine("Enter a new content");
                            S2week12 = Console.ReadLine();
                            nb2 = true;
                        }
                    }
                    nb1 = true;
                }
            }

        }

        public void ModifyExamAndAssignmentSections()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.WriteLine("Do you want to modify the exam or the assignment section ?\n0 - Exit\n1 - Exam\n2 - Assignment");
                switch(Console.ReadLine())
                {
                    case "0":
                        finish = true;
                        break;

                    case "1":
                        Console.Clear();
                        Console.WriteLine("Do you want to add or to modify an exam ?\n1 - Add\n2 - Modify");
                        switch(Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Enter the name of the exam");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter the date of the exam");
                                string date = Console.ReadLine();
                                Console.WriteLine("Enter the hour of the exam");
                                string hour = Console.ReadLine();
                                string content = "";
                                Console.WriteLine("Do you want to add some informations ?\n1 - YES\n2 - NO");
                                if(Console.ReadLine() == "1")
                                {
                                    Console.WriteLine("Enter the informations");
                                    content = "Informations : " + Console.ReadLine();
                                }
                                Exams += $"Name : {name}    Date : {date}    Hour : {hour}    {content}\n";
                                break;

                            case "2":
                                Console.Clear();
                                Console.WriteLine("If you want to modify the exam section, it will be completely erased.\nYou will have to enter all the previous information that you wish to keep.");
                                Console.WriteLine("Do you want to continue ?\n1 - YES\n2 - NO");
                                switch(Console.ReadLine())
                                {
                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine("Enter your content");
                                        Exams = Console.ReadLine();
                                        break;

                                    case "2":
                                        finish = true;
                                        break;

                                }
                                break;
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Do you want to add or to modify an assignment ?\n1 - Add\n2 - Modify");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Enter the name of the assignment");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter the date of the assignment");
                                string date = Console.ReadLine();
                                Console.WriteLine("Enter the hour of the assignment");
                                string hour = Console.ReadLine();
                                string content = "";
                                Console.WriteLine("Do you want to add some informations ?\n1 - YES\n2 - NO");
                                if (Console.ReadLine() == "1")
                                {
                                    Console.WriteLine("Enter the informations");
                                    content = "Informations : " + Console.ReadLine();
                                }
                                Assignments += $"Name : {name}    Date : {date}    Hour : {hour}    {content}\n";
                                break;

                            case "2":
                                Console.Clear();
                                Console.WriteLine("If you want to modify the assignment section, it will be completely erased.\nYou will have to enter all the previous information that you wish to keep.");
                                Console.WriteLine("Do you want to continue ?\n1 - YES\n2 - NO");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine("Enter your content");
                                        Assignments = Console.ReadLine();
                                        break;

                                    case "2":
                                        finish = true;
                                        break;

                                }
                                break;
                        }
                        break;

                }

            }
        }

    }
}
