using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHints
{
    internal class PatternMatching : ILesson
    {
        public class Person
        {
            public string Name { get; set; } = "Jack";
            public int Age { get; set; } = 18;

            public void Deconstruct(out string name, out int age)
            {
                name = Name;
                age = Age;
            }
        }

        string Max(int l, int r) => (l, r) switch
        {
            (1, 2) => "Right bigger",
            (2, 1) => "Left bigger",
            _ => "Not supported"
        };

        bool IsJackand18(Person person) => person switch
        {
            ("Jack", 18) => true,
            _ => false
        };

        bool BetweenZeroAndTen(int x) => x switch
        {
            <= 0 => false,
            > 0 and < 100 => true,
            >= 100 => false
        };

        int GetLength(int[] values) => values switch
        {
            [1, 2, 3, 4, 5] => 5,
            [1, 2, 3] => 3,
            [1, 2] => 2,
            [] => 0,
            _ => -1
        };

        public void StartLesson()
        {
            dynamic i = 1;
            Person person = new Person();

            // Type pattern and constant pattern:
            Console.WriteLine($"Value i is not string && i is int && i is 1: {i is not string && i is int && i is 1}");

            // Property pattern:
            Console.WriteLine("Value person is Person { Name: \"Jack\", Age: 18 }:" + $"{person is Person { Name: "Jack", Age: 18}}");

            // Tuple pattern:
            Console.WriteLine(Max(1, 2));

            // Composition pattern:
            Console.WriteLine(IsJackand18(person));

            // Relation and Logical patterns:
            Console.WriteLine(BetweenZeroAndTen(50));

            // List and Array patterns:
            int[] ints = { 1, 2, 3 };
            Console.WriteLine($"Match ints is [1, 2, 3] && GetLength(ints) == 3 is { ints is [1, 2, 3] && GetLength(ints) == 3}");
        }
    }
}
