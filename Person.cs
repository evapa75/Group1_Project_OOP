using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetV1
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Sexe { get; set; }
        public string EmailPerso { get; set; }
        public string EmailSchool { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public DateTime DateBirth { get; set; }
        public string PlaceBirth { get; set; }     
        List<Course> listCourse = new List<Course>();



        public Person(string firstName, string name, DateTime dateBirth)
        {
            //A recupérer lors de l'inscription : nom, prénom, date de naissance, lieu de naissance, emailperso, sexe, phoneNumber, Adress
            FirstName = firstName;
            Name = name;
            DateBirth = dateBirth;
            Age = AgeCalculation();
            EmailSchool = EmailAdress();
            Password = FirstPassword();
        }


        public override string ToString()
        {
            return $"First name : {FirstName}       Name : {Name}       Date of birth : {DateBirth.ToShortDateString()}         Age : {Age}\n" +
                $"      Email Adress : {EmailSchool}           Password : {Password}";
        }

        public int AgeCalculation()
        {
            int age = 0;
            DateTime anniversary = new DateTime(DateTime.Today.Year, DateBirth.Month, DateBirth.Day);
            if((anniversary.Month < DateTime.Today.Month) || ((anniversary.Month == DateTime.Today.Month) && (anniversary.Day <= DateTime.Today.Day)))
            {
                age = DateTime.Today.Year - DateBirth.Year;
            }
            else
            {
                age = DateTime.Today.Year - DateBirth.Year - 1;
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
