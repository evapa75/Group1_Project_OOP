using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProjetV1
{
    public class Mark
    {
        public int Score { get; set; }
        public int Coefficient { get; set; }
        public Student Stud { get; set; }
        public string CourseMarked {get;set;}

        public Mark(Student stud, string courseMarked, int score, int coefficient)
        {
            Stud = stud;
            CourseMarked = courseMarked;
            Score = score;
            Coefficient = coefficient;
        }

    }
