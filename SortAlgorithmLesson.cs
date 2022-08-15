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
            ISort sort = new MergeSort(arr);
            sort.SortMax();
            sort.SortMin();
        }
    }
}

namespace SortAlg
{
    public interface ISort
    {
        public void SortMax();
        public void SortMin();
    }

    public abstract class SortAbstract
    {
        public bool IsSortable(int[] arr, bool increase)
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
                    if ((increase && arr[i] > arr[i + 1])
                        || (!increase && arr[i] < arr[i + 1]))
                        return true;
                }
                Console.WriteLine("Array is already sorted.");
                return false;
            }
        }
    }

    public class BubbleSort : SortAbstract, ISort
    {
        private int[] arr;

        public BubbleSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMax()
        {
            if (!IsSortable(arr, true)) return;
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
            if (!IsSortable(arr, false)) return;
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

    public class ShakerSort : SortAbstract, ISort
    {
        private int[] arr;

        public ShakerSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMax()
        {
            if (!IsSortable(arr, true)) return;
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
            if (!IsSortable(arr, false)) return;
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

    public class CombSort : SortAbstract, ISort
    {
        private int[] arr;

        public CombSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMax()
        {
            if (!IsSortable(arr, true)) return;

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
            if (!IsSortable(arr, false)) return;

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

    public class InsertionSort : SortAbstract, ISort
    {
        private int[] arr;

        public InsertionSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMax()
        {
            if (!IsSortable(arr, true)) return;
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
            if (!IsSortable(arr, false)) return;
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

    public class SelectionSort : SortAbstract, ISort
    {
        private int[] arr;

        public SelectionSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMax()
        {
            if (!IsSortable(arr, true)) return;
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
            if (!IsSortable(arr, false)) return;
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

    public class QuickSort : SortAbstract, ISort
    {
        private int[] arr;

        public QuickSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMax()
        {
            if (!IsSortable(arr, true)) return;
            Sort(true, 0, arr.Length - 1);
            Console.Write($"Array after max SELECTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin()
        {
            if (!IsSortable(arr, false)) return;
            Sort(false, 0, arr.Length - 1);
            Console.Write($"Array after min SELECTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        private int GetIndexOfPivot(bool increase, int start, int end)
        {
            int indexOfPivot = start;

            for (int i = start; i <= end; ++i)
            {
                if (increase && arr[i] <= arr[end])
                {
                    (arr[i], arr[indexOfPivot]) = (arr[indexOfPivot], arr[i]);
                    ++indexOfPivot;
                }
                else if (!increase && arr[i] > arr[end])
                {
                    (arr[i], arr[indexOfPivot]) = (arr[indexOfPivot], arr[i]);
                    ++indexOfPivot;
                }
            }
            return --indexOfPivot;
        }

        private void Sort(bool increase, int start, int end)
        {
            if (start > end) return;

            int indexOfPivot = GetIndexOfPivot(increase, start, end);
            Sort(increase, start, indexOfPivot - 1);
            Sort(increase, indexOfPivot + 1, end);
        }
    }

    public class MergeSort : SortAbstract, ISort
    {
        private int[] arr;

        public MergeSort(int[] arr)
        {
            this.arr = arr;

            Console.Write($"Array before:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMax()
        {
            if (!IsSortable(arr, true)) return;
            Sort(true, 0, arr.Length - 1, new int[arr.Length]);
            Console.Write($"Array after max SELECTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        public void SortMin()
        {
            if (!IsSortable(arr, false)) return;
            Sort(false, 0, arr.Length - 1, new int[arr.Length]);
            Console.Write($"Array after min SELECTION sort:");
            Array.ForEach(arr, x => Console.Write(" " + x.ToString() + " "));
            Console.WriteLine();
        }

        private void Sort(bool increase, int start, int end, int[] buf)
        {
            if (start < end)
            {
                int middle = (end - start) / 2 + start;
                Sort(increase, start, middle, buf);
                Sort(increase, middle + 1, end, buf);

                int k = start;
                for (int i = start, j = middle + 1; i <= middle || j <= end;)
                {
                    if (j > end
                        || (increase && i <= middle && arr[i] < arr[j])
                        || (!increase && i <= middle && arr[i] > arr[j]))
                    {
                        buf[k] = arr[i];
                        ++i;
                    }
                    else
                    {
                        buf[k] = arr[j];
                        ++j;
                    }
                    ++k;
                }
                for (int i = start; i <= end; ++i)
                {
                    arr[i] = buf[i];
                }
            }
        }
    }
}
