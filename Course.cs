using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetV1
{
    public class Course
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        FacultyMember Professor { get; set; }


        public Course(string subject, DateTime date, FacultyMember professor)
        {
            Subject = subject;
            Date = date;
            Professor = professor;
        }


        public override string ToString()
        {
            return $"Subject : {Subject}     Date : {Date}    Professor : {Professor.Name}";
        }

    }
}
