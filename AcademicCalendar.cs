using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class AcademicCalendar
    {
        public SortedList<string, DateTime> Calendar;

        public AcademicCalendar(SortedList<string, DateTime> calendar)
        {
            Calendar = calendar;
        }

        public void AcademicCalendarCSV()//A TERMINER
        {
            int counter = 0;
            StreamReader fichLect = new StreamReader("AcademicCalendar.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[2];
            while (fichLect.Peek() > 0)
            {
                line = fichLect.ReadLine();
                if (counter == 1)
                {
                    datas = line.Split(sep);

                    char[] sep2 = new char[1] { '/' };
                    string[] datas2 = new string[3];
                    datas2 = datas[1].Split(sep2);

                    int day = Convert.ToInt16(datas2[0]);
                    int month = Convert.ToInt16(datas2[1]);
                    int year = Convert.ToInt16(datas2[2]);

                    DateTime date = new DateTime(year, month, day);

                    Calendar.Add(datas[0], date);

                }
                counter = 1;
            }
        }

        public void AddAnEvent()//A FAIRE
        {
            Console.Clear();
            Console.WriteLine("What's the name of the event ? ");
            string eventName = Console.ReadLine();

            Console.WriteLine("What's the day of the beginning of the event");
            int day = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("What's the month of the beginning of the event");
            int month = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("What's the year of the beginning of the event ?");
            int year = Convert.ToInt16(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);

            //Parcourir la liste et comparer les dates pour mettre par ordre chronologique les événements

            IList<DateTime> values = Calendar.Values;

            foreach(DateTime d in values)
            {
                int compare = DateTime.Compare(d, date);
                if(compare < 0 )
                {
                    //l'événement est après cette date
                    //=> ajouter l'événement juste avant donc à son index et décaler le reste
                }
                else if(compare == 0)
                {
                    //l'événement est en même temps
                    //=> ajouter l'événement juste après
                }
                else if(compare > 0)
                {
                    //l'événement est après
                    //voir l'élément d'après
                }

            }

        }

        public void DeleteAnEvent()//A FAIRE
        {

        }

        public void ShowAcademicCalendar() //FAIRE UN AFFICHAGE PROPRE POUR QUE CA FASSE DEUX BELLES COLONNES
        {
            IList<string> allEvents = Calendar.Keys;
            IList<DateTime> allDates = Calendar.Values;

            Console.WriteLine("     ACADEMIC CALENDAR");

            for(int i = 0; i < allEvents.Count; i++)
            {
                Console.WriteLine(allEvents[i] + allDates[i].Day + "/" + allDates[i].Month + "/" + allDates[i].Year);
            }

        }

    }
}
