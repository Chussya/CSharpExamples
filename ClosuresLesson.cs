using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var multiply = () => { int n = 5; return () => n *= 2; };

            var fn = multiply();

            Console.WriteLine(fn());
            Console.WriteLine(fn());
            Console.WriteLine(fn());
        }
    }
}
