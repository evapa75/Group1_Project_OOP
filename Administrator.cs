using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Group1_OOP
{
    public class Administrator : Person
    {
        public Administrator(string firstName, string name, DateTime dateBirth)
            : base(firstName, name, dateBirth)
        {

        }

        public override string ToString()
        {
            return $"Administrator => {base.ToString()} ";
        }

        public override string EmailAdress()
        {
            return $"{FirstName.ToLower()}.{Name.ToLower()}@faculty-vgc.ie";
        }

        /*
        public void AddAdminisrator(List<Administrator> adminsList)
        {
            Administrator admin = new Administrator(this.FirstName, this.Name, this.DateBirth);
            adminsList.Add(admin);
        }
        */

        public void FeesModification(List<Student> studentList)
        {
            Console.WriteLine("Do you want to change the fees for one student or all the student ?");
            Console.WriteLine("1 : 1 student");
            Console.WriteLine("2 : all the student");
            //si possible, juste une année
            int nb = Convert.ToInt16(Console.ReadLine());
            if(nb == 1)
            {
                Console.WriteLine("Enter the first name of the student");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter the last name of the student");
                string lastName = Console.ReadLine();
                foreach(Student student in studentList)
                {
                    if(student.Name == lastName && student.FirstName == firstName)
                    {
                        Console.WriteLine("Fees of the student : " + student.Fees);
                        Console.WriteLine("New fees :");
                        student.Fees = Convert.ToDouble(Console.ReadLine());
                    }
                }
            }
            else if (nb == 2)
            {
                Console.WriteLine("New fees :");
                double fees = Convert.ToDouble(Console.ReadLine());
                foreach (Student student in studentList)
                {
                    student.Fees = fees;
                }
            }
            else
            {
                Console.WriteLine("Aucune modification apportée");
            }
        }

        /*
        public void CourseCreation(List<Course>schoolCourses)
        {
            Console.WriteLine("Subject of the course : ");
            string subject = Console.ReadLine();
            Console.WriteLine("Which year : ");
            int year = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Duration of the course (hh,mm)");
            double duration = Convert.ToDouble(Console.ReadLine());

            Course course = new Course(subject, year, duration);
            schoolCourses.Add(course);
            Console.WriteLine("Add a new course ? Yes or No");
            string a = Console.ReadLine();
            if (a == "Yes")
            {
                CourseCreation(schoolCourses);
            }       
        }
        */
    }
}
