using System;
using System.Collections.Generic;
using System.Text;

namespace Group1_OOP
{
    public abstract class Person
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD

        public bool LoginStatus { get; set; }
        public string ID { get; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PersoEmail { get; set; }
        public string SchoolEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public Person(string id, string firstName, string name, string gender, string birthdate, string persoEmailAdress, string phoneNumber, string adress, string password)
        {
            ID = id;
            FirstName = firstName;
            Name = name;
            Gender = gender;
            Birthdate = BirthdateCalculation(birthdate);
            Age = AgeCalculation();
            SchoolEmail = SchoolEmailAdress();
            PersoEmail = persoEmailAdress;
            PhoneNumber = phoneNumber;
            Adress = adress;
            Password = password;
        }



        public override string ToString()
        {
            return $"ID: {ID} \nPassword: { Password} \nFirst name : {FirstName} \nName : {Name}  \nDate of birth : {Birthdate.ToShortDateString()}   \nAge : {Age}" +
                $"\nSchool Email Adress : {SchoolEmail} \nPersonal email adress : {PersoEmail} \nPhone number : {PhoneNumber} \nAdress : {Adress}";
        }

        public int AgeCalculation()
        {
            int age = 0;
            DateTime anniversary = new DateTime(DateTime.Today.Year, Birthdate.Month, Birthdate.Day);
            if ((anniversary.Month < DateTime.Today.Month) || ((anniversary.Month == DateTime.Today.Month) && (anniversary.Day <= DateTime.Today.Day)))
            {
                age = DateTime.Today.Year - Birthdate.Year;
            }
            else
            {
                age = DateTime.Today.Year - Birthdate.Year - 1;
            }
            return age;
        }

        public DateTime BirthdateCalculation(string date)
        {
            int day = Convert.ToInt32(date[0] + "" + date[1]);
            int month = Convert.ToInt32(date[3] + "" + date[4]);
            int year = Convert.ToInt32(date[6] + "" + date[7] + "" + date[8] + "" + date[9]);
            DateTime Birthdate = new DateTime(year, month, day);

            return Birthdate;
        }


        public abstract string SchoolEmailAdress();


    }
}
