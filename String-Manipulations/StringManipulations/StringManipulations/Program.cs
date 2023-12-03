using System;
using System.Globalization;

namespace StringManipulations
{
    class Program
    {
        static void Main()
        {
            string str1 = "Hello";
            string str2 = "World";

            // Concatenation
            Console.WriteLine($"\nConcatenation result: {BasicStringUtils.ConcatenateStrings(str1, str2)}");

            string original = "Hello World";

            // Substring
            Console.WriteLine($"\nSubstring result: {BasicStringUtils.ExtractSubstring(original, 6)}");

            // Length
            Console.WriteLine($"\nLength of the string: {BasicStringUtils.GetStringLenght(original)}");

            // Replace
            string sentence = "C# is fun!";
            string newSentence = BasicStringUtils.ReplaceSubstring(sentence, "fun", "awesome");
            Console.WriteLine($"\nReplace result: {newSentence}");

            // Split
            Console.WriteLine("\nSplit string result:");
            string names = "Vlado,Gosho,Pesho";
            string[] nameArray = BasicStringUtils.SplitString(names, ',');
            foreach (var name in nameArray)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nChange case string results:");
            // ToLower, ToUpper, ToCamelCase
            string mixedCase = "MiXeD CaSe t3st";
            Console.WriteLine($"ToLower: {BasicStringUtils.ConvertToLower(mixedCase)}");
            Console.WriteLine($"ToUpper: {BasicStringUtils.ConvertToUpper(mixedCase)}");
            Console.WriteLine($"ToCamel: {BasicStringUtils.ToCamelCase(mixedCase)}" );
            Console.WriteLine($"ToPascal: {BasicStringUtils.ToPascalCase(mixedCase)}");
        }
    }
}



public class BasicStringUtils
{
    public static string ConcatenateStrings(string str1, string str2)
    {
        return str1 + " " + str2;
    }

    public static string ExtractSubstring(string original, int startIndex)
    {
        return original.Substring(startIndex);
    }

    public static int GetStringLenght(string text)
    {
        return text.Length;
    }

    public static string ReplaceSubstring(string input, string oldSubstring, string newSubstring)
    {
        return input.Replace(oldSubstring, newSubstring);
    }

    public static string[] SplitString(string input, char separator)
    {
        return input.Split(separator);
    }

    public static string ConvertToLower(string input)
    {
        return input.ToLower();
    }

    public static string ConvertToUpper(string input)
    {
        return input.ToUpper();
    }

    public static string ToCamelCase(string input)
    {
        // Ensure the input is not empty
        if (string.IsNullOrEmpty(input))
            return input;

        // Split the string into words
        string[] words = input.Split(' ');

        // Capitalize the first letter of each word except the first one
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = i == 0
                ? words[i].ToLower()  // Lowercase the first word
                : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i]);
        }

        // Concatenate the words back into a single string
        return string.Join("", words);
    }


    public static string ToPascalCase(string input)
    {
        // Ensure the input is not empty
        if (string.IsNullOrEmpty(input))
            return input;

        // Split the string into words
        string[] words = input.Split(' ');

        // Capitalize the first letter of each word
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(words[i]);
        }

        // Concatenate the words back into a single string
        return string.Join("", words);
    }
}
