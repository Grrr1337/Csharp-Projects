using System;
using System.Diagnostics;

namespace SortAlgorithms
{
    class Program
    {
        static void Main()
        {
           
            int size, minRange, maxRange;
            size = 20000;
            minRange = 0;
            maxRange = 20001;
            int[] array = GenericFunctions.GenerateIntArray(size, minRange, maxRange);
            
            // GenericFunctions.PrintArray("Original Array:", array);
 
            // Using Insertion Sort
            int[] insertionSortedArray = Algorithms.InsertionSort(array);
            Console.WriteLine($"Insertion Sort BenchMark: {string.Format("{0,12}", Algorithms.BenchmarkTime)} ms");
            // GenericFunctions.PrintArray("Sorted Array using Insertion Sort:", insertionSortedArray);

            // Using Bubble Sort
            int[] bubbleSortedArray = Algorithms.BubbleSort(array);
            Console.WriteLine($"Bubble Sort BenchMark: {string.Format("{0,12}", Algorithms.BenchmarkTime)} ms");
            // GenericFunctions.PrintArray("Sorted Array using Bubble Sort:", bubbleSortedArray);

            // Using Selection Sort
            int[] selectionSortedArray = Algorithms.SelectionSort(array);
            Console.WriteLine($"Selection Sort BenchMark: {string.Format("{0,12}", Algorithms.BenchmarkTime)} ms");

            // Using Quick Sort
            // int[] quickSortedArray = Algorithms.QuickSort(array);
            // Console.WriteLine($"Quick Sort BenchMark: {string.Format("{0,12}", Algorithms.BenchmarkTime)} ms");


            // Check if all sorted arrays are the same
            bool areSortedArraysSame = GenericFunctions.AreArraysSame(new List<int[]>
            {
                insertionSortedArray,
                bubbleSortedArray,
                selectionSortedArray,
                // selectionSortedArray.Reverse().ToArray(), // <- to test if the `AreArraysSame` method work.
                // Add more sorted arrays if needed
            });

            Console.WriteLine($"Are all sorted arrays the same? {areSortedArraysSame}");

        }
    }
}


namespace SortAlgorithms
{
    public class GenericFunctions
    {
        public static int[] GenerateIntArray(int size, int minRange, int maxRange)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minRange, maxRange); // Generate a random integer between 0 and 100
            }

            return array;
        }

        public static void PrintArray(String header, int[] arr)
        {
            Console.WriteLine(header);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
        }


        public static bool AreArraysSame(List<int[]> arrays)
        {
            if (arrays == null || arrays.Count < 2)
            {
                // If the list is null or has less than 2 arrays, they are considered the same.
                return true;
            }

            // Compare each element of the arrays
            for (int i = 1; i < arrays.Count; i++)
            {
                if (!Enumerable.SequenceEqual(arrays[0], arrays[i]))
                {
                    // If any array is not equal to the first one, return false
                    return false;
                }
            }

            // All arrays are the same
            return true;
        }
    }
}

namespace SortAlgorithms
{

    public class Algorithms
    {
        // private static long benchmarkTime; // Internal parameter to hold elapsed milliseconds

        //public static long BenchmarkTime
        //{
        //    get { return benchmarkTime; }
        //}

        private static Stopwatch stopwatch = new Stopwatch();

        public static TimeSpan BenchmarkTime
        {
            get { return stopwatch.Elapsed; }
        }

        public static int[] SelectionSort(int[] arr)
        {
            int n = arr.Length;
            int[] sortedArray = arr.ToArray();

            stopwatch.Restart();

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (sortedArray[j] < sortedArray[minIndex])
                        minIndex = j;
                }

                // Swap sortedArray[i] and sortedArray[minIndex]
                int temp = sortedArray[i];
                sortedArray[i] = sortedArray[minIndex];
                sortedArray[minIndex] = temp;
            }

            stopwatch.Stop();
            return sortedArray;
        }


        public static int[] InsertionSort(int[] arr)
        {
            int n = arr.Length;
            int[] sortedArray = arr.ToArray(); // Create a copy of the array

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            stopwatch.Restart();

            for (int i = 1; i < n; ++i)
            {
                int key = sortedArray[i];
                int j = i - 1;

                while (j >= 0 && sortedArray[j] > key)
                {
                    sortedArray[j + 1] = sortedArray[j];
                    j = j - 1;
                }

                sortedArray[j + 1] = key;
            }

            //stopwatch.Stop();
            //benchmarkTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Stop();

            return sortedArray;
        }

        public static int[] BubbleSort(int[] arr)
        {
            int n = arr.Length;
            int[] sortedArray = arr.ToArray(); // Create a copy of the array

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            stopwatch.Restart();

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sortedArray[j] > sortedArray[j + 1])
                    {
                        // Swap sortedArray[j] and sortedArray[j + 1]
                        int temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }

            //stopwatch.Stop();
            //benchmarkTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Stop();
            return sortedArray;
        }

    }

}
