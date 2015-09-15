using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace sortedSet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //create the SortedSet
            SortedSet<Person> people = new SortedSet<Person>(new PersonComparer());

            //add some random folks:
            Random rnd = new Random();
            for (int i = 1; i <= 25000; i++)
            {
                //new person
                Person person = new Person();
                person.name = "Bob " + i.ToString();
                person.location = "Miami" + i.ToString();

                //random age
                int r = rnd.Next(1, 99);
                person.age = r;

                //add person to set
                people.Add(person);
            }

            //show our list:
            foreach (Person person in people)
            {
                // Console.WriteLine(person.name + " - Age: " + person.age.ToString());
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            stopWatch.Reset();
            stopWatch.Start();
            //create the SortedSet
            IList<Person> ipeople = new List<Person>();

            //add some random folks:

            for (int i = 1; i <= 25000; i++)
            {
                //new person
                Person person = new Person();
                person.name = "Bob " + i.ToString();
                person.location = "Miami" + i.ToString();

                //random age
                int r = rnd.Next(1, 99);
                person.age = r;

                //add person to set
                ipeople.Add(person);
            }

            //show our list:
            foreach (Person person in ipeople.OrderBy(a => a.age).ThenBy(n => n.name).ThenBy(l => l.location))
            {
                // Console.WriteLine(person.name + " - Age: " + person.age.ToString());
            }

            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
               ts.Milliseconds / 10);
            Console.WriteLine("RunTime2 " + elapsedTime);

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }

    //create comparer
    internal class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            //first by age
            int result = x.age.CompareTo(y.age);

            //then name
            if (result == 0)
                result = x.name.CompareTo(y.name);

            //a third sort
            if (result == 0)
                result = x.location.CompareTo(y.location);

            return result;
        }
    }

    internal class Person
    {
        public string name { get; set; }
        public string location { get; set; }
        public int age { get; set; }
    }
}
