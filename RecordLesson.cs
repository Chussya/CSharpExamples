using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHints
{
    internal class RecordLesson : ILesson
    {
        public record class PositionRecords(string first, string second, string third); // also then example under:

        /*
         * public record PositionRecords
         * {
         *     public string First { get; init; }
         *     public string Second { get; init; }
         *     public string Third { get; init; }
         *     public Person(string first, string second, string third)
         *     {
         *         First = first;
         *         Second = second;
         *         Third = third;
         *     }
         *     public void Deconstruct(out string first, out string second, out string third) => (first, second, third) = (First, Second, Third);
         * }
         */

        public record Person
        {
            public string Login { get; init; }
            public string Name { get; set; }
            public Person(string name, string login)
            {
                Name = name;
                Login = login;
            }
        }

        public void StartLesson()
        {
            PositionRecords pr = new PositionRecords("First", "Second", "Third");
            Person person = new Person("Name1", "Login1");
            Person person1 = new Person("Name1", "Login1");

            var (first, second, third) = pr;
            var prChanged = pr with { first = "changedFirst" }; // initialisation with operator 'with'; also can write '= pr with {};' and get copy of record.

            Console.WriteLine(person.Equals(person1)); // True, because person equals person1 by VALUE!!!
            Console.WriteLine(pr);
            Console.WriteLine(prChanged);
        }
    }
}
