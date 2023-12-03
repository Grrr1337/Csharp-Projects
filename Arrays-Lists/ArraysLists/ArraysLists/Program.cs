
using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
       
        int[] myArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        Console.WriteLine($"Original Array:\n{string.Join(", ", myArray)}");
        Console.WriteLine($"Array length: {myArray.Length}");
        Console.WriteLine($"First element: {myArray.First()} | {myArray[0]}");
        Console.WriteLine($"Last element: {myArray.Last()} | {myArray[^1]}"); // myArray[myArray.Length - 1]
        Console.WriteLine($"\nReversed Array:\n{string.Join(", ", myArray.Reverse())}");

        // Adding an item to the array (must be re-casted to List datatype):
        List<int> tmpList1 = new List<int>(myArray);
        tmpList1.Add(69);
        // If I need it back as an array
        int[] addedToArray = tmpList1.ToArray();
        Console.WriteLine($"\nAdded '69' to the Array:\n{string.Join(", ", addedToArray)}");

        // Removing an Item from the array (must be re-casted to List datatype):
        List<int> tmpList2 = new List<int>(myArray);
        tmpList2.Remove(1);
        // If you need it back as an array
        int[] removedFromArray = tmpList2.ToArray();
        Console.WriteLine($"\nRemoved '1' from the Array:\n{string.Join(", ", removedFromArray)}");

        // Copying an array:
        int[] originalArray = { 1, 2, 3, 4, 5 };
        int[] copiedArray = new int[originalArray.Length];
        Array.Copy(originalArray, copiedArray, originalArray.Length);
        Console.WriteLine($"\nCopied Array:\n{string.Join(", ", copiedArray)}");

        // Obtaining a value by providing index (nth)
        Console.WriteLine($"\nIndex of 3: {Array.IndexOf(myArray, 3)}");

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




        Console.WriteLine("\nDistinct values: ");
        int[] myArrayDistinctTest = { 1, 1, 1, 2, 2, 3, 4, 4, 5, 8, 8, 8 };
        // Getting distinct values using LINQ
        int[] distinctValues = myArrayDistinctTest.Distinct().ToArray();

        Console.WriteLine($"Original array: {string.Join(", ", myArrayDistinctTest)}");
        Console.WriteLine($"distinctValues: {string.Join(", ", distinctValues)}");


        Console.WriteLine("\nGrouped values: ");
        string[] words = { "apple", "banana", "cherry", "date", "blueberries", "pineapple", "strawberry", "ananas", "pear", "coconut" };

        // Grouping words by their first letter
        var groupedByFirstLetter = words.GroupBy(word => word[0]);

        Console.WriteLine($"Original array:\n {string.Join(", ", words)}");
        // Console.WriteLine($"Grouped by first letter: {string.Join(", ", groupedByFirstLetter)}");

        // Iterating over groups and printing each group and its elements
        foreach (var group in groupedByFirstLetter)
        {
            Console.WriteLine($"Group for letter {group.Key}: {string.Join(", ", group)}");
        }

        // Converting to Dictionary:
        int[] keys = { 1, 2, 3, 4 };
        string[] values = { "one", "two", "three", "four" };

        // Converting two arrays to a dictionary
        var dictionary = keys.Zip(values, (k, v) => new { Key = k, Value = v })
                            .ToDictionary(pair => pair.Key, pair => pair.Value);

        Console.WriteLine("\nDictionary contents:");
        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }


        Console.WriteLine("\nFlatting an array:");
        int[][] nestedArray = { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };

        // Flattening a nested array
        int[] flatArray = nestedArray.SelectMany(subArray => subArray).ToArray();
        Console.WriteLine($"Flat array: {string.Join(", ", flatArray)}");


        Console.WriteLine("\nCheck if All/Any Elements Satisfy a Condition: (vl-every/vl-some):");

        // Checking if all elements are even
        bool allEven = myArray.All(n => n % 2 == 0);
        Console.WriteLine($"Are all even?: {allEven}");

        // Define a custom test function
        bool IsGreaterThanThree(int x) => x > 3;

        // Check if any element satisfies the custom condition
        bool anyGreaterThanThree = myArray.Any(IsGreaterThanThree);
        Console.WriteLine($"anyGreaterThanThree?: {anyGreaterThanThree}");

        // Checking if any element is greater than 4
        bool anyGreaterThan4 = myArray.Any(n => n > 4);
        Console.WriteLine($"anyGreaterThan4?: {anyGreaterThan4}");

        Console.WriteLine("\nShifting an array:");
        Console.WriteLine($"Right shift: {string.Join(", ", Helpers.ShiftRight(myArray))}");
        Console.WriteLine($"Left shift: {string.Join(", ", Helpers.ShiftLeft(myArray))}");
    }// main
}// class Program


class Helpers
{

    public static int[] ShiftLeft(int[] array)
    {
        if (array.Length < 2)
        {
            // No need to shift if the array has 0 or 1 element
            return array;
        }

        int[] shiftedArray = new int[array.Length];

        // Copy elements starting from index 1 to the end
        Array.Copy(array, 1, shiftedArray, 0, array.Length - 1);

        // Place the first element at the end
        shiftedArray[array.Length - 1] = array[0];

        return shiftedArray;
    }
    public static int[] ShiftRight(int[] array)
    {
        if (array.Length < 2)
        {
            // No need to shift if the array has 0 or 1 element
            return array;
        }

        int[] shiftedArray = new int[array.Length];

        // Place the last element at the beginning
        shiftedArray[0] = array[array.Length - 1];

        // Copy elements from the original array to the new array, excluding the last element
        Array.Copy(array, 0, shiftedArray, 1, array.Length - 1);

        return shiftedArray;
    }
}