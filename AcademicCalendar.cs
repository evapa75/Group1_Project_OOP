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

        public void AcademicCalendarCSV()
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

        public void AddAnEvent()
        {
            Console.Clear();
            bool size = false;
            SortedList<string, DateTime> memoryList = new SortedList<string, DateTime>();
            string eventName = "";

            while (size == false)
            {
                Console.WriteLine("What's the name of the event ? (only 100 characters)");
                eventName = Console.ReadLine();
                if (eventName.Length <= 100)
                {
                    size = true;
                }
            }

            Console.WriteLine("What's the day of the beginning of the event");
            int day = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("What's the month of the beginning of the event");
            int month = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("What's the year of the beginning of the event ?");
            int year = Convert.ToInt16(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);

            //Parcourir la liste et comparer les dates pour mettre par ordre chronologique les événements
            IList<DateTime> values = Calendar.Values;
            IList<string> keys = Calendar.Keys;

            int count = 0;
            bool finish = false;
            while (finish == false)
            {
                foreach (DateTime d in values)
                {
                    int compare = DateTime.Compare(d, date);
                    if (compare < 0)
                    {
                        //l'événement est avant cette date
                        //=> ajouter l'événement juste avant donc à son index et décaler le reste
                        for (int i = 0; i <= count; i++)
                        {
                            memoryList.Add(keys[i], values[i]);
                        }
                        memoryList.Add(eventName, date);
                        for (int i = count + 1; i < keys.Count; i++)
                        {
                            memoryList.Add(keys[i], values[i]);
                        }
                        finish = true;
                    }
                    count++;
                }
            }
            Calendar = memoryList;

        }

        public void DeleteAnEvent()
        {
            bool finish = false;

            while (finish == false)
            {
                Console.Clear();
                Console.WriteLine("What's the day of the event you want to delete ?");
                int day = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("What's the month of the event you want to delete ?");
                int month = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("What's the year of the event you want to delete ?");
                int year = Convert.ToInt16(Console.ReadLine());

                DateTime date = new DateTime(year, month, day);

                IList<DateTime> values = Calendar.Values;
                IList<string> keys = Calendar.Keys;

                int count = 0;
                int index = 0;
                List<int> indexList = new List<int>();

                foreach (DateTime d in values)
                {
                    int compare = DateTime.Compare(d, date);
                    if (compare == 0)
                    {
                        count++;
                        indexList.Add(index);
                    }
                    index++;
                }

                Console.Clear();
                if (count == 0)
                {
                    Console.WriteLine("There are no events on the date indicated.");
                    Console.WriteLine("Do you want to enter a new date ?\n1 - YES\n2 - NO");
                    int nb = Convert.ToInt16(Console.ReadLine());
                    switch (nb)
                    {
                        case 1:
                            finish = false;
                            break;

                        case 2:
                            finish = true;
                            break;
                    }

                }
                else if (count == 1)
                {
                    Console.WriteLine("There is an event on the indicated date.");
                    Console.WriteLine("Event : " + keys[indexList[0]]);
                    Console.WriteLine("Do you want to delete this event?\n1 - YES\n2 - NO");
                    int nb = Convert.ToInt16(Console.ReadLine());
                    switch(nb)
                    {
                        case 1:
                            Calendar.RemoveAt(indexList[0]);
                            finish = true;
                            break;

                        case 2:
                            Console.WriteLine("Do you want to enter a new date ?\n1 - YES\n2 - NO");
                            int nb2 = Convert.ToInt16(Console.ReadLine());
                            switch (nb2)
                            {
                                case 1:
                                    finish = false;
                                    break;

                                case 2:
                                    finish = true;
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("There are " + count + " on the indicated date");
                    for(int i = 0; i < count; i++)
                    {
                        Console.WriteLine((i+1) + " : " + keys[indexList[i]]);
                    }
                    Console.WriteLine("Which event do you want to delete?\nEnter 0 to exit");
                    int eventNb = Convert.ToInt16(Console.ReadLine());
                    if(eventNb <= count && eventNb > 0)
                    {
                        int indexTab = eventNb - 1;
                        Calendar.RemoveAt(indexList[indexTab]);

                    }
                    finish = true;
                }
            }
        }

        public void ShowAcademicCalendar()
        {
            IList<string> allEvents = Calendar.Keys;
            IList<DateTime> allDates = Calendar.Values;

            Console.WriteLine("ACADEMIC CALENDAR");

            for(int i = 0; i < allEvents.Count; i++)
            {
                Console.Write(allEvents[i]);
                for (int j = allEvents[i].Length; j <= 100; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("   " + allDates[i].Day + "/" + allDates[i].Month + "/" + allDates[i].Year);

            }

        }

    }
}
