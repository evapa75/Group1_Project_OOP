using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class Mark
    {
        public int Score { get; set; }
        public int Coefficient { get; set; }
        public Student Stud { get; set; }
        public string CourseMarked { get; set; }

        public Mark(Student stud, string courseMarked, int score, int coefficient)
        {
            Stud = stud;
            CourseMarked = courseMarked;
            Score = score;
            Coefficient = coefficient;
        }
    }
}
