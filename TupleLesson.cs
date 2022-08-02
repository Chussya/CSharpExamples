namespace CSharpHints
{
    internal class TupleLesson : ILesson
    {
        static class SomeClass
        {
            public static string Name { get; set; } = "DoomGuy";
            public static int Age { get; set; } = 30; // idk his age 0_0
        }

        public void StartLesson()
        {
            var tuple1 = (5, "string");
            Console.WriteLine(tuple1.Item1);
            Console.WriteLine(tuple1.Item2);

            // Field's name:
            (string name, int num) tuple2 = ("Name", 10);
            Console.WriteLine(tuple2.name);
            Console.WriteLine(tuple2.num);

            // projection initializers:
            var tuple3 = (SomeClass.Name, SomeClass.Age);
            Console.WriteLine(tuple3.Name);
            Console.WriteLine(tuple3.Age);

            // Decomposition:
            var (str1, str2) = ("first", "second");
            Console.WriteLine(str1);
            Console.WriteLine(str2);

            // Swap elements:
            (str1, str2) = (str2, str1);
            Console.WriteLine(str1);
            Console.WriteLine(str2);
        }
    }
}
