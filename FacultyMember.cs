using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetV1
{
    public class FacultyMember : Person
    {
        public string Position { get; set; }
        public double Wage { get; set; }

        //List<Student> Students;


        public FacultyMember(string firstName, string name, DateTime dateBirth, string position)
            :base(firstName,name,dateBirth)
        {
            Position = position;
        }

        //calcul du salaire automatique selon la position ?

        public override string ToString()
        {
            return $"Faculty member => {base.ToString()}       Position : {Position}";
        }

        public override string EmailAdress()
        {
            return $"{FirstName.ToLower()}.{Name.ToLower()}@faculty-vgc.ie";
        }
    }
}
