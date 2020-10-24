using System;

namespace ProjetV1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string firstName = "Laura";
            string name = "Tran";
            DateTime dateBirth = new DateTime(1999, 10, 7);

            Student laura = new Student(firstName, name, dateBirth);
            FacultyMember celia = new FacultyMember("Celia", "Barras", dateBirth, "Professor");

            Console.WriteLine(laura.ToString());
            Console.WriteLine();
            Console.WriteLine(celia.ToString());



            /* Debut de console

            Console.WriteLine("1 : Sign in");
            Console.WriteLine("2 : Sign up");

            */
        }
    }
}
