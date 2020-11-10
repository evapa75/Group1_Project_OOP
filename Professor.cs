using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class Professor : Person
    {
        public List<Student> ListStudents { get; set; }


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

        public void AddProfessor(List<Professor> professorsList)
        {
            Professor teacher = new Professor(this.FirstName, this.Name, this.DateBirth);
            professorsList.Add(teacher);
        }
    }
}
