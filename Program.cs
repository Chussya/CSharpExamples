using System;

namespace CSharpHints
{
    internal class Program
    {
        public static void Main()
        {
            string lines = new string('=', 30);
            Console.WriteLine($"{lines}Start Lesson{lines}");

            ILesson lesson = new EnumeratorAndEnumerableLesson();  // For check another lesson just rename class name ;)
            lesson.StartLesson();

            Console.WriteLine($"{lines}End Lesson{lines}");
        }
    }
}