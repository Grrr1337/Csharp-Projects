using System;
using System.Diagnostics;

namespace SortAlgorithms
{
    class Program
    {
        static void Main()
        {
           
             
            // int size = 20000, minRange = 0, maxRange = 20001;

            int size = 20, minRange = 0, maxRange = 21;
        
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
            int[] quickSortedArray = Algorithms.QuickSortWrapper(array);
            Console.WriteLine($"Quick Sort BenchMark: {string.Format("{0,12}", Algorithms.BenchmarkTime)} ms");

            // Using Merge Sort
            int[] mergeSortedArray = Algorithms.MergeSortWrapper(array);
            Console.WriteLine($"Merge Sort BenchMark: {string.Format("{0,12}", Algorithms.BenchmarkTime)} ms");

            /*
            List<int[]> sortedArrays = new List<int[]>
            {
                insertionSortedArray,
                bubbleSortedArray,
                selectionSortedArray,
                // selectionSortedArray.Reverse().ToArray(), // <- to test if the `AreArraysSame` method work.
                quickSortedArray,
                mergeSortedArray
                // Add more sorted arrays if needed
            };
            */

            List<Tuple<string, int[]>> sortedArrays = new List<Tuple<string, int[]>>
            {
                Tuple.Create("Insertion Sort", insertionSortedArray),
                Tuple.Create("Bubble Sort", bubbleSortedArray),
                Tuple.Create("Selection Sort", selectionSortedArray),
                // Tuple.Create("Reversed Selection Sort", selectionSortedArray.Reverse().ToArray()), // <- to test if the `AreArraysSame` method work.
                Tuple.Create("Quick Sort", quickSortedArray),
                Tuple.Create("Merge Sort", mergeSortedArray),
                // Tuple.Create("Test Sort", selectionSortedArray.Reverse().ToArray()), // <- to test if the `AreArraysSame` method work.
                // Add more sorted arrays if needed
            };

            GenericFunctions.PrintArrays(sortedArrays);

            // Check if all sorted arrays are the same
            //bool areSortedArraysSame = GenericFunctions.AreArraysSame(sortedArrays);
            //Console.WriteLine($"Are all sorted arrays the same? {areSortedArraysSame}");

            // Extract only the second elements (int arrays)
            List<int[]> intArrays = sortedArrays.Select(tuple => tuple.Item2).ToList();
            // Use the extracted int arrays with the existing AreArraysSame method
            bool areSortedArraysSame = GenericFunctions.AreArraysSame(intArrays);
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

        public static void PrintArrays(List<Tuple<string, int[]>> Arrays)
        {
            foreach (var tuple in Arrays)
            {
                // Console.WriteLine($"{tuple.Item1}:");
                GenericFunctions.PrintArray($"{tuple.Item1}:", tuple.Item2);
            }
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

        public static int[] QuickSortWrapper(int[] arr)
        {
            stopwatch.Restart();
            int[] sortedArray = QuickSort(arr.ToArray());
            stopwatch.Stop();
            return sortedArray;
        }

        private static int[] QuickSort(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;

            int pivot = arr[arr.Length / 2];
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length / 2)
                    continue;

                if (arr[i] < pivot)
                    left.Add(arr[i]);
                else
                    right.Add(arr[i]);
            }

            return QuickSort(left.ToArray())
                .Concat(new int[] { pivot })
                .Concat(QuickSort(right.ToArray()))
                .ToArray();
        }



        public static int[] MergeSortWrapper(int[] arr)
        {
            stopwatch.Restart();
            int[] sortedArray = MergeSort(arr.ToArray());
            stopwatch.Stop();
            return sortedArray;
        }

        private static int[] MergeSort(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1)
                return arr;

            int mid = n / 2;
            int[] left = new int[mid];
            int[] right = new int[n - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, n - mid);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int leftLength = left.Length;
            int rightLength = right.Length;
            int[] result = new int[leftLength + rightLength];

            int i = 0, j = 0, k = 0;

            while (i < leftLength && j < rightLength)
            {
                if (left[i] < right[j])
                {
                    result[k] = left[i];
                    i++;
                }
                else
                {
                    result[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < leftLength)
            {
                result[k] = left[i];
                i++;
                k++;
            }

            while (j < rightLength)
            {
                result[k] = right[j];
                j++;
                k++;
            }

            return result;
        }
    }// class algorithms
}
