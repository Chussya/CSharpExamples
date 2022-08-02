using SortAlg;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpHints
{
    class SortAlgorithmLesson : ILesson
    {
        private int[] arr = { 9, 0, 8, 1, 7, 2, 6, 3, 5, 4 };

        public void StartLesson()
        {
            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();

            ISort sort = new CombSort();
            sort.SortMax(arr);
            sort.SortMin(arr);
        }
    }
}

namespace SortAlg
{
    public interface ISort
    {
        public void SortMax(int[] arr);
        public void SortMin(int[] arr);
    }

    public class BubbleSort : ISort
    {
        public void SortMax(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr.Length - (i + 1); ++j)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            Console.Write($"Array after max sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr.Length - (i + 1); ++j)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            Console.Write($"Array after min sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }
    }

    public class ShakerSort : ISort
    {
        public void SortMax(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr.Length - (i + 1); ++j)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                for (int j = arr.Length - (i + 2); j > i + 1; --j)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
            Console.Write($"Array after max sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr.Length - (i + 1); ++j)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                for (int j = arr.Length - (i + 2); j > i + 1; --j)
                {
                    if (arr[j] > arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
            Console.Write($"Array after min sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }
    }

    public class CombSort : ISort
    {
        public void SortMax(int[] arr)
        {
            int gap = arr.Length - 1;

            while (gap > 0)
            {
                int i = 0;
                while (i + gap <= arr.Length - 1)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        int temp = arr[i + gap];
                        arr[i + gap] = arr[i];
                        arr[i] = temp;
                    }
                    ++i;
                }
                --gap;
            }
            Console.Write($"Array after max sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin(int[] arr)
        {
            int gap = arr.Length - 1;

            while (gap > 0)
            {
                int i = 0;
                while (i + gap <= arr.Length - 1)
                {
                    if (arr[i] < arr[i + gap])
                    {
                        int temp = arr[i + gap];
                        arr[i + gap] = arr[i];
                        arr[i] = temp;
                    }
                    ++i;
                }
                --gap;
            }
            Console.Write($"Array after min sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }
    }
}
