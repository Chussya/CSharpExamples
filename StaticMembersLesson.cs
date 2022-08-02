using System;

namespace CSharpHints
{
    class StaticMembersLesson : ILesson
    {
        public class Man
        {
            public static bool hasEyes = false;

            public string eyesColor = "brown";

            public Man(string eyesColor)
            {
                this.eyesColor = eyesColor;
            }

            static Man()
            {
                hasEyes = true;
            }
        }

        public void StartLesson()
        {
            // Static field is false before start

            Man man1, man2;
            man1 = new Man("blue");
            Console.WriteLine($"Static field is: {Man.hasEyes}"); // Static field is: true

            man2 = new Man("brown");
            Console.WriteLine($"Static field is: {Man.hasEyes}"); // Static field is: true
        }
    }
}
