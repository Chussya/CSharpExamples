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

            Calc(integers, anonimousFunction);
            Calc(integers, lambdaFunction);
            Calc(integers, x => x > 1);
        }

        private void Calc(int[] integers, IsEquals func)
        {
            foreach (int i in integers)
            {
                Console.WriteLine($"Result {i} > 3 is {func(i)}");
            }
            Console.WriteLine();
        }
    }
}
