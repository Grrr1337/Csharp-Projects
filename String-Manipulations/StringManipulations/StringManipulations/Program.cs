using System;
using System.Globalization;
using System.Collections.Generic;

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

            string original = "Hello Vlado";

            // Substring
            Console.WriteLine($"\nSubstring result: {BasicStringUtils.ExtractSubstring(original, 6)}");

            // Contains
            Console.WriteLine($"\nContains result: {BasicStringUtils.IsStringContained("Vladimir writes code almost every day", "every")}");

            // Length
            Console.WriteLine($"\nLength of the string: {BasicStringUtils.GetStringLenght(original)}");

            // Replace
            string sentence = "Vlado likes to party!";
            string newSentence = BasicStringUtils.ReplaceSubstring(sentence, "party", "code");
            Console.WriteLine($"\nReplace result: {newSentence}");

            Console.WriteLine("\nChange case string results:");
            // ToLower, ToUpper, ToCamelCase
            string mixedCase = "MiXeD CaSe t3st";
            Console.WriteLine($"ToLower: {BasicStringUtils.ConvertToLower(mixedCase)}");
            Console.WriteLine($"ToUpper: {BasicStringUtils.ConvertToUpper(mixedCase)}");
            Console.WriteLine($"ToCamel: {BasicStringUtils.ToCamelCase(mixedCase)}" );
            Console.WriteLine($"ToPascal: {BasicStringUtils.ToPascalCase(mixedCase)}");


            // Split
            Console.WriteLine("\nSplit string result:");
            string names = "Vlado,Gosho,Pesho";
            string[] nameArray = BasicStringUtils.SplitString(names, ',');
            foreach (var name in nameArray)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nSplit string to chars result:");
            foreach (char character in BasicStringUtils.SplitStringToChars("Hello World"))
            {
                Console.WriteLine(character);
            }

            Console.WriteLine("\nSplit string to words result:");
            foreach (string word in BasicStringUtils.SplitStringSentenceToWords("The Quick Brown Fox"))
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("\nSplit string by delimeter: ");
            foreach (string part in BasicStringUtils.SplitStringByDelimeter(new string("apple,orange,banana,apple,grape"), new String("apple,")))
            {
                Console.WriteLine(part);
            }

            // Join array or List into a string
            Console.WriteLine($"{BasicStringUtils.JoinString(new string[] { "This", "is", "a", "join", "Array", "Test" }, "_")}");
            Console.WriteLine($"{BasicStringUtils.JoinString(new List<string> { "This", "is", "a", "join", "List", "Test" }, "-")}");



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

    public static bool IsStringContained(string mainString, string searchString)
    {
        bool containsString = mainString.Contains(searchString);
        return containsString;
    }

    public static int GetStringLenght(string text)
    {
        return text.Length;
    }

    public static string ReplaceSubstring(string input, string oldSubstring, string newSubstring)
    {
        return input.Replace(oldSubstring, newSubstring);
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

    public static string[] SplitString(string input, char separator)
    {
        return input.Split(separator);
    }

    public static char[] SplitStringToChars(string inputString)
    {
        // Split the string into characters
        char[] characters = inputString.ToCharArray();
        return characters;
    }

    public static string[] SplitStringSentenceToWords(string inputString)
    {
        string[] words = inputString.Split();
        return words;
    }

    public static string[] SplitStringByDelimeter(string inputString, string delimeter)
    {
        string[] result = inputString.Split(new string[] { delimeter }, StringSplitOptions.RemoveEmptyEntries);
        return result;
    }

    public static string JoinString(string[] stringArray, string delimeter)
    {
       return string.Join(delimeter, stringArray);
    }

    public static string JoinString(List<string> stringList, string delimeter)
    {
        return string.Join(delimeter, stringList);
    }

}
