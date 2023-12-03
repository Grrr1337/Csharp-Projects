using System;

namespace SortAlgorithms
{
    class Program
    {
        static void Main()
        {
            int[] array = { 12, 11, 13, 5, 6 };

            Console.WriteLine("Original Array:");
            Algorithms.PrintArray(array);

            // Using Insertion Sort
            Algorithms.InsertionSort(array);

            Console.WriteLine("\nSorted Array using Insertion Sort:");
            Algorithms.PrintArray(array);

            // Using Bubble Sort
            Algorithms.BubbleSort(array);

            Console.WriteLine("\nSorted Array using Bubble Sort:");
            Algorithms.PrintArray(array);
        }
    }
}

namespace SortAlgorithms
{

    public class Algorithms
    {
     
        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1] that are greater than key to one position ahead of their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = key;
            }
        }

        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap arr[j] and arr[j + 1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

}
