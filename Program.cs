using System;
using System.Collections.Generic;

namespace Group1_OOP
{
    public class Program
    {

        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();
            List<Administrator> adminsList = new List<Administrator>();
            List<Professor> professorsList = new List<Professor>();



            DateTime birth = new DateTime(1999, 12, 30);
            Administrator admin = new Administrator("Célia", "Barras", birth);
            admin.AddAdminisrator(adminsList);

            foreach (Administrator administrator in adminsList)
            {
                Console.WriteLine(administrator.ToString());
            }


            Console.ReadKey();
        }
    }
}
