using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHints
{
    internal class ThreadLesson : ILesson
    {
        private int x = 0;
        private object locker = new();
        private AutoResetEvent auto = new AutoResetEvent(true);
        private Mutex mutex = new Mutex();
        private Semaphore semaphore = new Semaphore(2, 2);

        public void StartLesson()
        {
            Thread t1 = new Thread(PrintWithLock);
            Thread t2 = new Thread(PrintWithLock);
            t1.Name = $"Thread 1";
            t2.Name = $"Thread 2";
            t1.Start();
            t2.Start();
            t1 = new Thread(PrintWithMonitor);
            t2 = new Thread(PrintWithMonitor);
            t1.Start();
            t2.Start();
        }

        public void PrintWithLock()
        {
            lock (locker)
            {
                for (x = 1; x < 6; ++x)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
                }
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }

        public void PrintWithMonitor()
        {
            bool locked = false;

            try
            {
                Monitor.Enter(locker, ref locked);

                for (x = 1; x < 6; ++x)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
                }
                Console.WriteLine();
            }
            finally
            {
                if (locked) Monitor.Exit(locker);
                Thread.Sleep(1000);
            }
        }

        public void PrintWithARE()
        {
            auto.WaitOne();

            for (x = 1; x < 6; ++x)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
            }
            Console.WriteLine();

            auto.Set();
            Thread.Sleep(1000);
        }

        public void PrintWithMutex()
        {
            mutex.WaitOne();

            for (x = 1; x < 6; ++x)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
            }
            Console.WriteLine();

            mutex.ReleaseMutex();
            Thread.Sleep(1000);
        }

        public void PrintWithSemaphore()
        {
            semaphore.WaitOne();

            for (x = 1; x < 6; ++x)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}:{x}");
            }
            Console.WriteLine();

            semaphore.Release();
            Thread.Sleep(1000);
        }
    }
}
