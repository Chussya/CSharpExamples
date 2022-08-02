using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpHints
{
    class DelegateLesson : ILesson
    {
        private delegate string Greeting();

        public void StartLesson()
        {
            // Create delegates:
            // #1
            // without constructor:
            Greeting greeting = BilboGreeting;
            ToConsole(greeting);
            Console.WriteLine();

            // #2
            // with constructor
            greeting = null;
            greeting = new Greeting(BilboGreeting);
            ToConsole(greeting);
            Console.WriteLine();

            // #3
            // send name of foo
            ToConsole(this.BilboGreeting);
            Console.WriteLine();

            // Edit delegate:
            // add to delegate
            greeting = null;
            greeting += BilboGreeting;
            greeting += GendalfGreeting;

            ToConsole(greeting);
            Console.WriteLine();
            ToConsole(this.BilboGreeting, this.GendalfGreeting);
            Console.WriteLine();

            // remove from delegate
            greeting -= GendalfGreeting;
            ToConsole(greeting);
            Console.WriteLine();
        }

        private static void ToConsole(Greeting greetings)
        {
            foreach (Delegate greeting in greetings.GetInvocationList())
                Console.WriteLine(greeting.DynamicInvoke());
        }


        private static void ToConsole(params Greeting[] greetings)
        {
            foreach (Greeting greeting in greetings)
                Console.WriteLine(greeting());
        }

        private string BilboGreeting()
        {
            return "Bilbo: Good morning!";
        }

        private string GendalfGreeting()
        {
            return "Gendalf: Bilbo Baggins!";
        }
    }
}
