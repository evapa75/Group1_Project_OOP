using System;
using System.Collections.Generic;
using System.Text;

namespace Group1_OOP
{
    public class Course
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public Professor Teacher { get; set; }
        public int Year { get; set; }


        public Course(string subject, DateTime date, Professor teacher, double duration)
        {
            Subject = subject;
            Date = date;
            Teacher = teacher;
            Duration = duration;
        }

        public Course(string subject, int year, double duration)
        {
            Subject = subject;
            Year = year;
            Duration = duration;
        }


        public override string ToString()
        {
            return $"Subject : {Subject}    " /* Date : {Date}    Professor : {Teacher.Name}" */;
        }

    }
}
