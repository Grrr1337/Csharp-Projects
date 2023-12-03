
using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
       
        int[] myArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        Console.WriteLine($"Original Array:\n{string.Join(", ", myArray)}");

        Console.WriteLine("\nMapping (x2) each element:");
        // Mapping: Doubling each element
        var doubledArray = myArray.Select(x => x * 2).ToArray();
        Console.WriteLine($"{string.Join(", ", doubledArray)}");

        Console.WriteLine("\nFiltering - keep only even numbers:");
        // Filtering: Keeping only even numbers
        var evenNumbers = myArray.Where(x => x % 2 == 0).ToArray();
        Console.WriteLine($"{string.Join(", ", evenNumbers)}");

        Console.WriteLine("\nSlicing: ");
        // Slice an Array:
        // Taking a subarray (slicing)
        int[] subArray = myArray.Skip(2).Take(3).ToArray();
        Console.WriteLine($"{string.Join(", ", subArray)}");

        Console.WriteLine("\nReducing: ");
        Console.WriteLine($"Sum: {myArray.Sum()}");
        Console.WriteLine($"Max: {myArray.Max()}");
        Console.WriteLine($"Min: {myArray.Min()}");

        Console.WriteLine("\nLINQ transformation: ");
        // Using LINQ to transform the array
        var transformedArray = myArray.Select(x => $"suffix_{x * 0.5}_prefix").ToArray();
        transformedArray.ToList().ForEach(item => Console.WriteLine(item));

        Console.WriteLine("\nCombining: ");
        int[] array1 = { 1, 2, 3 };
        int[] array2 = { 4, 5, 6 };

        // Concatenating two arrays
        int[] combinedArray = array1.Concat(array2).ToArray();
        combinedArray.ToList().ForEach(item => Console.WriteLine(item));

        Console.WriteLine("\nPartitioning (groupByN): ");
        // Partitioning the array into chunks
        var partitions = myArray.Select((value, index) => new { value, index })
                                .GroupBy(x => x.index / 2)
                                .Select(g => g.Select(x => x.value).ToArray())
                                .ToArray();

        partitions.ToList().ForEach(subArr => { 
            Console.WriteLine("---");
            subArr.ToList().ForEach(item => Console.WriteLine(item));
            });

       

        // Shuffling the array
        var shuffledArray = myArray.OrderBy(x => Guid.NewGuid()).ToArray();
        Console.WriteLine($"\nShuffled Array:\n{string.Join(", ", shuffledArray)}");

        Console.WriteLine("\nIndexing (accessing the index and the value at the same time): ");
        string[] strArray = new string[] { "Vlado", "Gosho", "Pesho", "Kiro", "Ivan" };
        // Printing each element with index using LINQ and Select
        strArray.Select((item, index) => $"index: {index} | value: {item}")
               .ToList()
               .ForEach(result => Console.WriteLine(result));


        Console.WriteLine("\nCommon values (array intersection): ");
        int[] arr1 = { 1, 2, 3, 4, 5, 8, 9 };
        int[] arr2 = { 3, 4, 5, 6, 7, 8, 9 };

        // Finding common values using LINQ and Intersect
        int[] commonValues = arr1.Intersect(arr2).ToArray();

        Console.WriteLine($"commonValues :\n{string.Join(", ", commonValues)}");

        Console.WriteLine("\nUnique values (array difference): ");
        // Finding values unique to each array using LINQ and Except
        int[] uniqueToArr1 = arr1.Except(arr2).ToArray();
        int[] uniqueToArr2 = arr2.Except(arr1).ToArray();

        Console.WriteLine($"Unique to arr1: {string.Join(", ", uniqueToArr1)}");
        Console.WriteLine($"Unique to arr2: {string.Join(", ", uniqueToArr2)}");


    }// main
}// class Program