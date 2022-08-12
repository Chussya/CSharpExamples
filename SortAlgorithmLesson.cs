using System;
using System.Collections.Generic;
using System.Text;
using SortAlg;

namespace CSharpHints
{
    class SortAlgorithmLesson : ILesson
    {
        private int[] arr = { 9, 0, 8, 1, 7, 2, 6, 3, 5, 4 };
        private int[] arr1 = { 0, 1 };
        private int[] arr2 = { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 };
        private int[] arr3 = { 1, 1, 1, 1, 1, 1, 1 };

        public void StartLesson()
        {
            ISort sort = new QuickSort(arr);
            sort.SortMax();
            sort = new QuickSort(arr1);
            sort.SortMax();
            sort = new QuickSort(arr2);
            sort.SortMax();
            sort = new QuickSort(arr3);
            sort.SortMax();
        }
    }
}

namespace SortAlg
{
    public interface ISort
    {
        public bool IsSortable();
        public void SortMax();
        public void SortMin();
    }

    public class BubbleSort : ISort
    {
        private int[] arr;

        public BubbleSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public bool IsSortable()
        {
            if (arr.Length <= 1)
            {
                Console.WriteLine("Array's length = 1, nothing to sort.");
                return false;
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                        return true;
                }
                Console.WriteLine("Array is already sorted.");
                return false;
            }
        }

        public void SortMax()
        {
            if (!IsSortable()) return;
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
            Console.Write($"Array after max BUBLE sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin()
        {
            if (!IsSortable()) return;
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
            Console.Write($"Array after min BUBLE sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }
    }

    public class ShakerSort : ISort
    {
        private int[] arr;

        public ShakerSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public bool IsSortable()
        {
            if (arr.Length <= 1)
            {
                Console.WriteLine("Array's length = 1, nothing to sort.");
                return false;
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                        return true;
                }
                Console.WriteLine("Array is already sorted.");
                return false;
            }
        }

        public void SortMax()
        {
            if (!IsSortable()) return;
            for (int i = 0; i < arr.Length / 2; ++i)
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
            Console.Write($"Array after max SHAKER sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin()
        {
            if (!IsSortable()) return;
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
            Console.Write($"Array after min SHAKER sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }
    }

    public class CombSort : ISort
    {
        private int[] arr;

        public CombSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public bool IsSortable()
        {
            if (arr.Length <= 1)
            {
                Console.WriteLine("Array's length = 1, nothing to sort.");
                return false;
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                        return true;
                }
                Console.WriteLine("Array is already sorted.");
                return false;
            }
        }

        public void SortMax()
        {
            if (!IsSortable()) return;

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
            Console.Write($"Array after max COMB sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin()
        {
            if (!IsSortable()) return;

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
            Console.Write($"Array after min COMB sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }
    }

    public class InsertionSort : ISort
    {
        private int[] arr;

        public InsertionSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public bool IsSortable()
        {
            if (arr.Length <= 1)
            {
                Console.WriteLine("Array's length = 1, nothing to sort.");
                return false;
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                        return true;
                }
                Console.WriteLine("Array is already sorted.");
                return false;
            }
        }

        public void SortMax()
        {
            if (!IsSortable()) return;
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                if (arr[i] > arr[i + 1])
                {
                    for (int j = i + 1; j > 0 && arr[j - 1] > arr[j]; --j)
                    {
                        (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                    }
                }
            }
            Console.Write($"Array after max INSERTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin()
        {
            if (!IsSortable()) return;
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                if (arr[i] < arr[i + 1])
                {
                    for (int j = i + 1; j > 0 && arr[j - 1] < arr[j]; --j)
                    {
                        (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                    }
                }
            }
            Console.Write($"Array after min INSERTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }
    }

    public class SelectionSort : ISort
    {
        private int[] arr;

        public SelectionSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public bool IsSortable()
        {
            if (arr.Length <= 1)
            {
                Console.WriteLine("Array's length = 1, nothing to sort.");
                return false;
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                        return true;
                }
                Console.WriteLine("Array is already sorted.");
                return false;
            }
        }

        public void SortMax()
        {
            if (!IsSortable()) return;
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                int memIndex = i;
                for (int j = i + 1; j <= arr.Length - 1; ++j)
                {
                    if (arr[j] < arr[memIndex])
                    {
                        memIndex = j;
                    }
                }
                (arr[i], arr[memIndex]) = (arr[memIndex], arr[i]);
            }
            Console.Write($"Array after max SELECTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin()
        {
            if (!IsSortable()) return;
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                int memIndex = i;
                for (int j = i + 1; j <= arr.Length - 1; ++j)
                {
                    if (arr[j] > arr[memIndex])
                    {
                        memIndex = j;
                    }
                }
                (arr[i], arr[memIndex]) = (arr[memIndex], arr[i]);
            }
            Console.Write($"Array after min SELECTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }
    }

    public class QuickSort : ISort
    {
        private int[] arr;
        private int indexOfMaxGlobal;
        private int indexOfMinGlobal;

        public QuickSort(int[] arr)
        {
            this.arr = arr;
            indexOfMinGlobal = Array.IndexOf(arr, arr.Min());
            indexOfMaxGlobal = Array.IndexOf(arr, arr.Max());

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        private int GetIndexOfPivot()
        {
            int average = (arr[indexOfMinGlobal] + arr[indexOfMaxGlobal]) / 2;

            if (arr.Contains(average)) return Array.IndexOf(arr, average);

            // Find closer pivot element:
            // Firstly, try find closer min and max elements to average:
            int indexOfMin = indexOfMinGlobal;
            int indexOfMax = indexOfMaxGlobal;
            int distFromMin = average - arr[indexOfMin];
            int distFromMax = arr[indexOfMax] - average;

            for (int i = 1; i < arr.Length - 1; ++i)
            {
                if (arr[i] > arr[indexOfMin] && arr[i] - arr[indexOfMin] < distFromMin)
                {
                    distFromMin = arr[i] - arr[indexOfMin];
                    indexOfMin = i;
                }
                if (arr[i] < arr[indexOfMax] && arr[indexOfMax] - arr[i] < distFromMax)
                {
                    distFromMax = arr[indexOfMax] - arr[i];
                    indexOfMax = i;
                }
            }

            // Finally, just check the result and choose the most efficient one:
            return indexOfMaxGlobal - indexOfMax >= indexOfMinGlobal - indexOfMin
                ? indexOfMax
                : indexOfMin;
        }

        private void Sort(bool increase, int indexMax, int indexMin)
        {
            int indexOfPivot = GetIndexOfPivot();

            if (indexOfPivot != arr.Length / 2)
                (arr[indexOfPivot], arr[arr.Length / 2]) = (arr[arr.Length / 2], arr[indexOfPivot]);

            if (increase)
            {
                for (int i = indexMin; i < indexMax - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                        (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                }
            }
            else
            {
                for (int i = indexMin; i < indexMax - 1; ++i)
                {
                    if (arr[i] < arr[i + 1])
                        (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                }
            }
        }

        public bool IsSortable()
        {
            if (arr.Length <= 1)
            {
                Console.WriteLine("Array's length = 1, nothing to sort.");
                return false;
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                        return true;
                }
                Console.WriteLine("Array is already sorted.");
                return false;
            }
        }

        public void SortMax()
        {
            if (!IsSortable()) return;
            Sort(true, indexOfMaxGlobal, indexOfMinGlobal);
            Console.Write($"Array after max SELECTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin()
        {
            if (!IsSortable()) return;
            Console.Write($"Array after min SELECTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

    }
}
