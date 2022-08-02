using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHints
{
    internal class TaskLesson : ILesson
    {
        public void StartLesson()
        {
            Console.WriteLine("Start Main");
            WaysToStart();
            InnerTask();
            GetResultFromTask();
            ContinueTask();
            CancelTask();
            Console.WriteLine("End Main");
        }

        private void WaysToStart()
        {
            Console.WriteLine("Ways to start:");
            Task task1;
            Task task2;
            Task task3;
            Task task4;

            task1 = new Task(() => Console.WriteLine("variant 1: taskObj.Start()"));
            task1.Start();

            task2 = Task.Factory.StartNew(() => Console.WriteLine("variant 2: Task.Factory.StartNew()"));

            task3 = Task.Run(() => Console.WriteLine("variant 3: Task.Run()"));

            task4 = new Task(() => Console.WriteLine("variant 1, but Run Synchronously: taskObj.RunSynchronously()"));
            task4.RunSynchronously();

            // Wait end of tasks:
            task1.Wait();
            task2.Wait();
            task3.Wait();
            Console.WriteLine();    // wait task4, because it started synchrounosly
        }

        private void InnerTask()
        {
            Console.WriteLine("Inner task:");
            Task outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Start outer task...");
                Task inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Start inner task...");
                    Console.WriteLine("Start 2 sec timeout...");
                    Thread.Sleep(2000);
                    Console.WriteLine("End inner task.");
                }, TaskCreationOptions.AttachedToParent);
            });
            outer.Wait();
            Console.WriteLine("End outer task.");
            Console.WriteLine();
        }

        private void GetResultFromTask()
        {
            Console.WriteLine("Get result from task:");
            Task<int> task = new Task<int>(() => 1);
            task.Start();

            Console.WriteLine("Start 2 sec timeout...");
            Thread.Sleep(2000);

            int result = task.Result;
            Console.WriteLine($"Result is {result}. Thread stopes when we try to get Result from task.");
            Console.WriteLine();
        }

        private void ContinueTask()
        {
            Console.WriteLine("Continue task:");
            Task startTask = new Task(() => Console.WriteLine("Start first task"));
            Task endTask = startTask.ContinueWith(task => Console.WriteLine($"Start second task with id = {Task.CurrentId} after task with id {task.Id}"));
            startTask.Start();
            endTask.Wait();
            Console.WriteLine();
        }

        private void CancelTask()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            // Light way:
            Console.WriteLine("Light way:");
            Task showNumTask = new Task(() =>
            {
                Console.WriteLine("Show num starting...");
                for (int i = 0; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Cancellation requested");
                        return;
                    }
                    Console.WriteLine(i);
                    Thread.Sleep(200);
                }
            }, token);
            showNumTask.Start();
            Thread.Sleep(1000); // time for some actions in task
            cancelTokenSource.Cancel();
            Thread.Sleep(1000); // time for logging cancellation requested
            cancelTokenSource.Dispose();
            showNumTask = null;
            Console.WriteLine();
            Thread.Sleep(1000);

            // Exception way:
            Console.WriteLine("Exception way:");
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            showNumTask = new Task(() =>
            {
                Console.WriteLine("Show num starting...");
                for (int i = 0; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    Console.WriteLine(i);
                    Thread.Sleep(200);
                }
            }, token);

            try
            {
                showNumTask.Start();
                Thread.Sleep(1000); // time for some actions in task
                cancelTokenSource.Cancel();
                showNumTask.Wait(); // Necessary Wait for catch exception
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Cancellation requested");
            }
            finally
            {
                cancelTokenSource.Dispose();
                showNumTask.Dispose();
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }
    }
}
