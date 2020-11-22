using System;
using System.Collections.Generic;
using System.Text;

namespace Group1_OOP
{
    public abstract class Person
    {
        public bool LoginStatus { get; set; }
        public string ID { get; }
        public string Password { get; set; }



        public string FirstName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        public string EmailPerso { get; set; }
        public string EmailSchool { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceBirth { get; set; }
        

        Timetable Timetable { get; set; }



        public Person(string firstName, string name, DateTime dateBirth)
        {
            FirstName = firstName;
            Name = name;
            BirthDate = dateBirth;
            Age = AgeCalculation();
            EmailSchool = EmailAdress();
            Password = FirstPassword();
        }


        public Person(string firstName, string name, char sex, DateTime dateBirth, string persoEmailAdress, string phoneNumber, string adress, string password)
        {
            FirstName = firstName;
            Name = name;
            Sex = sex;
            BirthDate = dateBirth;
            Age = AgeCalculation();
            EmailSchool = EmailAdress();
            EmailPerso = persoEmailAdress;
            PhoneNumber = phoneNumber;
            Adress = adress;
            ID = EmailSchool;
            Password = password;
        }



        public override string ToString()
        {
            return $"First name : {FirstName}       Name : {Name}       Date of birth : {BirthDate.ToShortDateString()}         Age : {Age}\n" +
                $"      Email Adress : {EmailSchool}           Password : {Password}";
        }

        public int AgeCalculation()
        {
            int age = 0;
            DateTime anniversary = new DateTime(DateTime.Today.Year, BirthDate.Month, BirthDate.Day);
            if((anniversary.Month < DateTime.Today.Month) || ((anniversary.Month == DateTime.Today.Month) && (anniversary.Day <= DateTime.Today.Day)))
            {
                age = DateTime.Today.Year - BirthDate.Year;
            }
            else
            {
                age = DateTime.Today.Year - BirthDate.Year - 1;
            }
            return age;
        }


        public string FirstPassword()
        {
            string pass = "";
            Random random = new Random();
            for(int i=0; i < 7; i++)
            {
                pass += (char)random.Next('a', 'z');
            }
            return pass;
        }

        public abstract string EmailAdress();

    }
}
