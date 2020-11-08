using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetV1
{
    public class Professor : Person
    {
        public List<Student> ListStudents { get; set; }



        public Professor() { }
        public Professor(string firstName, string name, DateTime dateBirth)
            : base(firstName, name, dateBirth)
        {
            
        }

        public override string ToString()
        {
            return $"Professor => {base.ToString()}";
        }

        public override string EmailAdress()
        {
            return $"{FirstName.ToLower()}.{Name.ToLower()}@professor.faculty-vgc.ie";
        }
    }
}
