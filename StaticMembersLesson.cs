using System;

namespace CSharpHints
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

    class StaticMembersLesson : ILesson
    {
        public void StartLesson()
        {
            // Static field is: false

            Man man1, man2;
            man1 = new Man("blue");
            Console.WriteLine($"Static field is: {Man.hasEyes}"); // Static field is: true

            man2 = new Man("brown");
            Console.WriteLine($"Static field is: {Man.hasEyes}"); // Static field is: true
        }
    }
}
