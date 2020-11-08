using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetV1
{
    public class Administrator : Person
    {




        public Administrator() { }

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
    }
}
