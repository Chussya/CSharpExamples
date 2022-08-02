namespace CSharpHints
{
    class QueueLesson : ILesson
    {
        public class IntegerQueue
        {
            private Queue<int> integers = new Queue<int>();
            private bool running = false;

            public IntegerQueue() { }

            public void Enqueue(int number)
            {
                lock (this.integers)
                {
                    this.integers.Enqueue(number);
                    if (!running)
                    {
                        running = true;
                        ThreadPool.UnsafeQueueUserWorkItem(this.ProcessQueuedItems, null);
                    }
                }
            }

            private void ProcessQueuedItems(object ignored)
            {
                Queue<int> skippedItems = new Queue<int>();
                while (true)
                {
                    int item;
                    lock (integers)
                    {
                        if (integers.Count == 0)
                        {
                            if (skippedItems.Count == 0)
                            {
                                running = false;
                                break;
                            }
                            else
                            {
                                integers.Concat(skippedItems);
                                skippedItems.Clear();
                            }
                        }
                        item = integers.Dequeue();
                    }
                    try
                    {
                        Console.WriteLine($"item : {item}");
                    }
                    catch (Exception ex)
                    {
                        // todo:
                    }
                }
            }
        }

        IntegerQueue integerQueue = new IntegerQueue();

        public void StartLesson()
        {
            for (int i = 0; i < 10; ++i)
                integerQueue.Enqueue(i);
        }
    }
}
