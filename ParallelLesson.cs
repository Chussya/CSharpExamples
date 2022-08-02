namespace CSharpHints
{
    internal class ParallelLesson : ILesson
    {
        public void StartLesson()
        {
            // Invoke(params Action[] actions)
            Action<int, int> Sum = (int a, int b) =>
            {
                Console.WriteLine($"Start sum function: a={a}, b={b}");
                Console.WriteLine($"Sum: {a + b}");
            };
            Action<int> Square = (int a) =>
            {
                Console.WriteLine($"Start square function: a={a}");
                Console.WriteLine($"Square: {a*a}");
            };
            Parallel.Invoke(() => Sum(1, 2), () => Square(3));
            Console.WriteLine();

            // For(int startIndex, int endIndex, Action<int> action)
            Parallel.For(2, 9, Square);
            Console.WriteLine();

            // ForEach(IEnumerable<TSource>, Action<TSource> action)
            ParallelLoopResult result = Parallel.ForEach(new List<int>() { 1, 2, 3, 4 }, ShowNum);
        }

        private void ShowNum(int num, ParallelLoopState pls)
        {
            if (num > 3)
            {
                Console.WriteLine($"Num is more than 3, exit from cycle.");
                pls.Break();
            }
            Console.WriteLine($"Num: {num}");
        }
    }
}
