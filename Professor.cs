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

        public Professor(string firstName, string name, char sex, DateTime dateBirth, string persoEmailAdress, string phoneNumber, string adress, string password)
            : base(firstName, name, sex, dateBirth, persoEmailAdress, phoneNumber, adress, password)
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
            Professor teacher = new Professor(this.FirstName, this.Name, this.BirthDate);
            professorsList.Add(teacher);
        }
    }
}
