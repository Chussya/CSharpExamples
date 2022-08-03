namespace CSharpHints
{
    internal class AsyncLesson : ILesson
    {
        class Storage
        {
            private int[] account = {123, 40, 900};

            public async IAsyncEnumerable<int> GetMoney()
            {
                foreach (var money in account)
                {
                    await Task.Delay(500);
                    yield return money;
                }
            }
        }

        public void StartLesson()
        {
            Console.WriteLine($"Start async...");
            try
            {
                StartAsync().Wait();
            }
            finally
            {
                Console.WriteLine($"End async...");
            }
        }

        public async Task StartAsync() // Task type necessary for .Wait(). If you'll use void, Wait will not wait =)
        {
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

            Console.WriteLine($"Result from WhenAll:\narr[0]={arr[0]}\narr[1]={arr[1]}\nResult from WhenAny:\nresult={result}\n");

            // From C# 8.0:
            IAsyncEnumerable<int> account = new Storage().GetMoney();
            await foreach (var money in account)
            {
                Console.WriteLine(money);
            }
        }

        private async Task Print(int n)
        {
            Console.WriteLine($"Task{n} starts: ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(1000); // Sleeping... Thread go next
            Console.WriteLine($"Task{n} ends: ThreadId:{Thread.CurrentThread.ManagedThreadId}");
        }

        private async Task<int> Sum(int a, int b)
        {
            await Task.Delay(1000);
            return a + b;
        }
    }
}
