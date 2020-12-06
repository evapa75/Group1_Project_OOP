using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Group1_OOP
{
    public class Course
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD

        public string Subject { get; set; }
        public Professor Teacher { get; set; }
        public string ProfessorID_or_NameOfClass { get; set; }
        public string CourseIndex { get; set; }
        public string Day { get; set; }
        public string Schedule { get; set; }
        public double Duration { get; set; }
        public List<Professor> professorList { get; set; }

        public int Number_of_times { get; set; }
        public int Attendance { get; set; }


        public Course(double course_index, string professorID_or_name_of_class, string subject, int number_of_times, int attendance, List<Student> studentList)
        {
            CourseIndex = "";
            CourseIndex = Convert.ToString(course_index);

            ProfessorID_or_NameOfClass = professorID_or_name_of_class;

            Subject = subject;
            Day = CourseDay(course_index);
            Schedule = CourseSchedule(course_index);
            Duration = 1.45;
            Number_of_times = number_of_times;
            Attendance = attendance;
        }


        public override string ToString()
        {
            return $"Subject : {Subject}    " /* Date : {Date}    Professor : {Teacher.Name}" */;
        }

        public void ModifyCourseIndex(double newIndexCourse)
        {
            this.CourseIndex = newIndexCourse.ToString();
            this.Day = CourseDay(newIndexCourse);
            this.Schedule = CourseSchedule(newIndexCourse);
        }

        public string CourseDay(double index)
        {
            string day = "";
            if (index < 2) { day = "Monday"; }
            if ((index > 2) && (index < 3)) { day = "Tuesday"; }
            if ((index > 3) && (index < 4)) { day = "Wednesday"; }
            if ((index > 4) && (index < 5)) { day = "Thursday"; }
            if ((index > 5)) { day = "Friday"; }
            return day;
        }

        public string CourseSchedule(double index)
        {
            string schedule = "";
            if (index == 1.1 || index == 2.1 || index == 3.1 || index == 4.1 || index == 5.1) { schedule = "8h30-10h15"; }
            if (index == 1.2 || index == 2.2 || index == 3.2 || index == 4.2 || index == 5.2) { schedule = "10h30-12h15"; }
            if (index == 1.3 || index == 2.3 || index == 3.3 || index == 4.3 || index == 5.3) { schedule = "13h30-15h15"; }
            if (index == 1.4 || index == 2.4 || index == 3.4 || index == 4.4 || index == 5.4) { schedule = "15h30-17h15"; }
            if (index == 1.5 || index == 2.5 || index == 3.5 || index == 4.5 || index == 5.5) { schedule = "17h30-19h15"; }
            return schedule;
        }
    }
}
