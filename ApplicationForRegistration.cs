using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class ApplicationForRegistration
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD

        string FirstName { get; set; }
        string Name { get; set; }
        char Sex { get; set; }
        DateTime Birthdate { get; set; }
        int StudyYear { get; set; }
        string PersonalEmailAdress { get; set; }
        string PhoneNumber { get; set; }
        string Adress { get; set; }

        string Status { get; set; }


        public ApplicationForRegistration(string firstName, string name, char sex, DateTime birthdate, int studyYear, string personalEmailAdress, string phoneNumber, string adress)
        {
            FirstName = firstName;
            Name = name;
            Sex = sex;
            Birthdate = birthdate;
            StudyYear = studyYear;
            PersonalEmailAdress = personalEmailAdress;
            PhoneNumber = phoneNumber;
            Adress = adress;
            Status = "Pending";
        }

        public void ShowApplicationForRegistration()
        {
            Console.WriteLine($"STUDENT REGISTRATION FORM \n\nFirstname : {FirstName} \nName : {Name} \nSex : {Sex} \nBirthdate : {Birthdate.Date} \nYear of study : {StudyYear} " +
                $"\nPersonal email adress : {PersonalEmailAdress} \nPhone number : {PhoneNumber} \nAdress : {Adress}");
        }
    }
}
