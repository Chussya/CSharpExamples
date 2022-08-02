namespace CSharpHints
{
    internal class TupleLesson : ILesson
    {
        public void StartLesson()
        {
            var tuple1 = (5, "string");
            Console.WriteLine(tuple1.Item1);
            Console.WriteLine(tuple1.Item2);

            // Field's name:
            (string name, int num) tuple2 = ("Name", 10);
            Console.WriteLine(tuple2.name);
            Console.WriteLine(tuple2.num);

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
