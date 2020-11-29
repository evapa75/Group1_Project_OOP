using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class ApplicationForCourse
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public int StudyYear { get; set; }
        public string Class { get; set; }
        public List<Course> Courses { get; set; }
        public Timetable StudentTimetable { get; set; }
        public Timetable ProfessorTimetable { get; set; }
        public string Index_course { get; set; }

        string Status { get; set; } //En attente, Acceptée, Refusée


        public ApplicationForCourse(string id, string firstname, string name, int year, string _class, List<Course> courses, Timetable timetable, string index_course)
        {
            ID = id;
            FirstName = firstname;
            Name = name;
            StudyYear = year;
            Class = _class;
            Courses = courses;
            StudentTimetable = timetable;
            Index_course = index_course;

            //Ajouter Trouver nom du cours et du prof

            Status = "Pending";
        }

        public void ShowApplicationForRegistration()
        {
            Console.WriteLine($"STUDENT APPLICATION FOR A COURSE \n\nID : {ID} \nFirstname : {FirstName} \nName : {Name} \nYear : {StudyYear} \n Class : {Class} \n\n\n");

            StudentTimetable.ShowTimetable();
            ProfessorTimetable.ShowTimetable();
        }
    }
}
