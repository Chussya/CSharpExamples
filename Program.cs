using System;
using InterfaceExample;

namespace CSharpHints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========================Start Lesson===========================");
            ILesson lesson = new AsyncLesson();
            lesson.StartLesson();
            while (true)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("============================End Lesson============================");
        }
    }
}