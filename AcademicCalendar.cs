using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Group1_OOP
{
    public class AcademicCalendar
    {
        // GROUP 1
        // 23173 Marie DONIER
        // 22843 Célia BARRAS
        // 22835 Laura TRAN
        // 23187 Eva PADRINO
        // 23207 Théo GALLAIS
        // 23025 Romain LANDRAUD


        public SortedList<DateTime, List<string>> Calendar;

        public AcademicCalendar()
        {
            Calendar = new SortedList<DateTime, List<string>>();

            int counter = 0;
            StreamReader fichLect = new StreamReader("AcademicCalendar.csv");
            char[] sep = new char[1] { ';' };
            string line = "";
            string[] datas = new string[6];
            while (fichLect.Peek() > 0)
            {
                line = fichLect.ReadLine();
                List<string> l = new List<string>();
                if (counter == 1)
                {
                    datas = line.Split(sep);

                    string date = datas[0];

                    int day = Convert.ToInt32(date[0] + "" + date[1]);
                    int month = Convert.ToInt32(date[3] + "" + date[4]);
                    int year = Convert.ToInt32(date[6] + "" + date[7] + "" + date[8] + "" + date[9]);
                    DateTime Date = new DateTime(year, month, day);

                    for (int i = 1; i < datas.Length; i++)
                    {
                        l.Add(datas[i]);
                    }

                    Calendar.Add(Date, l);
                }
                counter = 1;
            }
            fichLect.Close();
        }


        public void AddAnEvent()
        {
            bool finish = false;
            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("________________");
                Console.WriteLine("\n");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("| ADD AN EVENT |");
                Console.WriteLine("");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("________________\n\n");

                Console.WriteLine("\n\nWhat's the name of the event ?");
                string eventName = Console.ReadLine();

                Console.WriteLine("\n\nWhat's the date of the event (jj/mm/dddd) ?");
                string date = Console.ReadLine();

                int day = Convert.ToInt32(date[0] + "" + date[1]);
                int month = Convert.ToInt32(date[3] + "" + date[4]);
                int year = Convert.ToInt32(date[6] + "" + date[7] + "" + date[8] + "" + date[9]);
                DateTime Date = new DateTime(year, month, day);

                bool exist = false;

                foreach (KeyValuePair<DateTime, List<string>> c in Calendar)
                {
                    if (Date == c.Key)
                    {
                        c.Value.Add(eventName);
                        exist = true;
                    }
                }
                if (exist == false)
                {
                    List<string> l = new List<string>();
                    l.Add(eventName);

                    Calendar.Add(Date, l);
                }

                Console.WriteLine("\n\nDo you want to add another event to the calendar? \n1 - YES \n2 - NO");
                if (Console.ReadLine() == "2")
                {
                    finish = true;
                }
            }
        }

        public void DeleteAnEvent()
        {
            bool finish = false;

            while (finish == false)
            {
                Console.Clear();
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("__________________");
                Console.WriteLine("\n");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("| DELETE AN EVENT |");
                Console.WriteLine("");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("__________________\n\n");

                int index = 1;
                foreach (KeyValuePair<DateTime, List<string>> c in Calendar)
                {
                    Console.Write(index + " - " + c.Key.ToShortDateString() + " : ");
                    foreach (string Event in c.Value)
                    {
                        Console.Write(Event + "          ");
                    }
                    index++;
                    Console.WriteLine("\n");
                }

                Console.WriteLine("\n\nChoose the index of the event you want to delete : ");
                int answer = Convert.ToInt32(Console.ReadLine()) - 1;

                if (Calendar.ElementAt(answer).Value.Count > 1)
                {
                    int index2 = 1;
                    Console.WriteLine("\n\nChoose the event that you want to delete :");
                    foreach (string Event in Calendar.ElementAt(answer).Value)
                    {
                        Console.WriteLine(index2 + " - " + Event);
                        index2++;
                    }
                    int answer2 = Convert.ToInt32(Console.ReadLine()) - 1;
                    Calendar.ElementAt(answer).Value.RemoveAt(answer2);
                }
                else
                {
                    Calendar.RemoveAt(answer);
                }

                Console.WriteLine("\n\n\nDo you want to delete another event from the calendar? \n1 - YES \n2 - NO");
                if (Console.ReadLine() == "2")
                {
                    finish = true;
                }
            }
        }

        public void ShowAcademicCalendar()
        {
            bool finish = false;
            while (finish == false)
            {
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("_____________________");
                Console.WriteLine("\n");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("| ACADEMIC CALENDAR |");
                Console.WriteLine("");
                for (int i = 0; i < 95; i++) { Console.Write(" "); }
                Console.Write("_____________________\n\n\n\n");

                foreach (KeyValuePair<DateTime, List<string>> c in Calendar)
                {
                    Console.Write(c.Key.ToShortDateString() + " : ");
                    foreach (string Event in c.Value)
                    {
                        Console.Write(Event + "          ");
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n\n\nReturn to the dashboard ? \n1- YES \n2- NO");
                int decision = Convert.ToInt32(Console.ReadLine());
                if (decision == 1)
                {
                    finish = true;
                }
            }
        }

    }
}
