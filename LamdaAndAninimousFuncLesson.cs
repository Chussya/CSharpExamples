using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpHints
{
    class LamdaAndAninimousFuncLesson : ILesson
    {
        private delegate bool IsEquals(int integer);

        public void StartLesson()
        {
            int[] integers = new int[] { 1, 2, 3, 4, 5 };

            // Use anonimous funnction:
            IsEquals anonimousFunction = delegate (int x)
            {
                return x > 3;
            };

            IsEquals lambdaFunction = x => x > 2;

            calc(integers, anonimousFunction);
            calc(integers, lambdaFunction);
            calc(integers, x => x > 1);
        }

        private void calc(int[] integers, IsEquals func)
        {
            foreach (int i in integers)
            {
                Console.WriteLine($"Result {i} > 3 is {func(i)}");
            }
            Console.WriteLine();
        }
    }
}
