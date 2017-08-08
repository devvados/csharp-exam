using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "DataLines.txt";

            var lines = GetAllLinesFromFile(path);
            var people = InitializeObjects(lines);

            PrintDataOrderedByAge(people.OrderBy(x => x.Age));
            PrintDataByAverageAge(people);
        }

        public static IEnumerable<string> GetAllLinesFromFile(string path)
        {
            var lines = from line in File.ReadLines(path)
                        select line;
            return lines;
        }

        public static IEnumerable<Person> InitializeObjects(IEnumerable<string> lines)
        {
            List<Person> people = new List<Person>();

            foreach (var line in lines)
            {
                var output = String.Join(" ", Regex.Matches(line, @"\<(.+?)\>")
                                    .Cast<Match>()
                                    .Select(m => m.Groups[1].Value)).Split(' ').ToArray();
                people.Add(new Person
                {
                    Surname = output[0],
                    Name = output[1],
                    Age = Convert.ToInt32(output[2]),
                    Telephone = output[3]
                });                  
            }
            return people;
        }

        public static double GetAverageAge(IEnumerable<Person> people)
        {
            int count = people.Count();
            double average = 0;

            foreach (var person in people)
            {
                average += person.Age;
            }

            return average / count;
        }

        public static IEnumerable<Person> GetPeopleYoungerThanAverageAge(IEnumerable<Person> people)
        {
            double average = GetAverageAge(people);

            var temp = from person in people
                       where person.Age < (average - 10)
                       select person;

            return temp;
        }

        public static void PrintDataOrderedByAge(IEnumerable<Person> people)
        {
            Console.WriteLine("Упорядоченные по возрасту:");
            foreach (var person in people)
            {
                Console.WriteLine($" {person.Age} лет, {person.Surname}, {person.Name}, {person.Telephone}");
            }
        }

        public static void PrintDataByAverageAge(IEnumerable<Person> people)
        {
            var temp = GetPeopleYoungerThanAverageAge(people);

            Console.WriteLine($"Средний возраст: {GetAverageAge(people)} лет.\nМоложе среднего возраста на 10 лет:");
            foreach (var person in temp)
            {
                Console.WriteLine($" {person.Age} лет, {person.Surname}, {person.Name}, {person.Telephone}");
            }
        }
    }
}
