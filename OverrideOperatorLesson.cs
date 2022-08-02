using System;

namespace CSharpHints
{
    public class Counter
    {
        public int value = 0;

        public Counter() { }

        public Counter(int value)
        {
            this.value = value;
        }

        // Unori:
        public static Counter operator ++(Counter c)
        {
            ++c.value;
            return c;
        }

        // Binary
        public static Counter operator +(Counter c1, Counter c2)
        {
            c1.value += c2.value;
            return c1;
        }

        // Equality:
        public static bool operator ==(Counter c1, Counter c2)
        {
            return c1.value == c2.value;
        }

        public static bool operator !=(Counter c1, Counter c2)
        {
            return c1.value != c2.value;
        }
    }

    class OverrideOperatorLesson : ILesson
    {
        public void StartLesson()
        {
            Counter c1 = new Counter(10);
            Counter c2 = new Counter(5);

            Console.WriteLine($"++: {(++c1).value}");
            Console.WriteLine($"+ : {(c1 + c2).value}");
        }
    }
}
