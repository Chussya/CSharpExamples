namespace CSharpHints
{
    internal class AsyncLesson : ILesson
    {
        public void StartLesson()
        {
            Task task = new Task(AsyncStart);
            task.Start();
            task.Wait();
        }

        public async void AsyncStart()
        {
            Console.WriteLine($"Start async...");

            // Way 1:
            await Print(1); // call Print and await it
            await Print(2); // same

            // Way 2:
            Task t1 = Print(1); // call Print and go next
            Task t2 = Print(2); // same

            await t1; // await of Print ending
            await t2; // same

            Console.WriteLine();

            // Get result from Tasks:
            int[] arr = await Task.WhenAll(Sum(1, 1), Sum(2, 3));
            int result = await await Task.WhenAny(Sum(1, 1), Sum(2, 3));

            Console.WriteLine($"Result from WhenAll:\narr[0]={arr[0]}\narr[1]={arr[1]}\nResult from WhenAny:\nresult={result}");

            Console.WriteLine($"End async...");
        }

        private async Task Print(int n)
        {
            Console.WriteLine($"Task{n} starts: ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(5000); // Sleeping... Thread go next
            Console.WriteLine($"Task{n} ends: ThreadId:{Thread.CurrentThread.ManagedThreadId}");
        }

        private async Task<int> Sum(int a, int b)
        {
            await Task.Delay(1000);
            return a + b;
        }
    }
}
