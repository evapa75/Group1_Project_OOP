using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetV1
{
    public class Student : Person
    {
        public string StudentID { get; set; }
        public bool Fees { get; set; }
        public string ModePayment { get; set; }


        public Student(string firstName, string name, DateTime dateBirth)
            :base(firstName, name, dateBirth)
        {

        }


        public override string ToString()
        {
            return $"Student => {base.ToString()}";
        }

        public override string EmailAdress()
        {
            return $"{FirstName.ToLower()}.{Name.ToLower()}@student-vgc.ie";

        }
    }
}
