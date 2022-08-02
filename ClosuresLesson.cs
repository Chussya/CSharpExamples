namespace CSharpHints
{
    internal class ClosuresLesson : ILesson
    {
        public void StartLesson()
        {

            // For .NET < 6.0
            //var fn = Outer();
            //fn();
            //fn();
            //fn();
            //
            //Action Outer()
            //{
            //    int x = 5;
            //    void Inner()
            //    {
            //        x++;
            //        Console.WriteLine(x);
            //    }
            //    return Inner;
            //}

            // For .NET >= 6.0
            var multiply = () =>
            {
                int x = 5;
                return () => ++x;
            };
            dynamic fn = multiply();    // fn = 'return () => ++x' and x inited at once

            Console.WriteLine(fn());    // 6
            Console.WriteLine(fn());    // 7
            Console.WriteLine(fn());    // 8

            // How to fix it?

            fn = multiply;   // fn = signature of multiply (all code into multiply)

            Console.WriteLine(fn()());    // 6
            Console.WriteLine(fn()());    // 6
            Console.WriteLine(fn()());    // 6

            // or

            var multiplyFix = () =>
            {
                int x = 5;
                return () => { int y = x; return ++y; };
            };
            fn = multiplyFix(); // fn = 'return () => { int y = x; return ++y; }' and x inited at once, but it doesn't matter, cause return 'y' value;

            Console.WriteLine(fn());    // 6
            Console.WriteLine(fn());    // 6
            Console.WriteLine(fn());    // 6
        }
    }
}
