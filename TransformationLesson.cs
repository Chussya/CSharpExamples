using System;

namespace CSharpHints
{
    class TransformationLesson : ILesson
    {
        class Hours
        {
            public int hours = 0;

            public static implicit operator int(Hours h)
            {
                return h.hours;
            }

            public static implicit operator Hours(int h)
            {
                return new Hours() { hours = h };
            }

            public static implicit operator Clocker(Hours h)
            {
                return new Clocker() { Seconds = h.hours * 3600 };
            }
        }

        class Clocker
        {
            public int Seconds { get; set; }

            public static implicit operator Clocker(int x)
            {
                return new Clocker { Seconds = x };
            }

            public static implicit operator Hours(Clocker clocker)
            {
                return new Hours { hours = clocker.Seconds / 3600 };
            }

            public static explicit operator int(Clocker clocker)
            {
                return clocker.Seconds;
            }
        }

        public void StartLesson()
        {
            Clocker clocker1 = new Clocker { Seconds = 7200 };

            int x = (int)clocker1;
            Console.WriteLine(x);

            Clocker clocker2 = x;
            Console.WriteLine(clocker2.Seconds);

            Hours hours = clocker2;
            Console.WriteLine(hours.hours);
        }
    }
}
