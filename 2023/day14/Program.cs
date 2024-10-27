using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    public static List<string> ParseInput(string input)
    {   
        string[] stringyInput = input.Split(",");
        foreach (string s in stringyInput)
        {
            Console.WriteLine(s);
        }
        return stringyInput.ToList();
    }

    public static Dictionary<char, int> BuildDictionary()
    {
        Dictionary<char, int> asciiDict = new Dictionary<char, int>();

        for (int i = 0; i < 128; i++)
        {
            char c = (char)i;
            asciiDict[c] = i;
        }
        return asciiDict;
    }

    public static int CalculateIndividualHashValue(string input)
    {
        Dictionary<char, int> asciiDictionary = BuildDictionary();
        Console.WriteLine("input: " + input); 
        int currentValue = 0;
        List<char> holidayChars = input.ToCharArray().ToList();  
        foreach (char h in holidayChars)
        {
            if (h !=  '\'') {

            
            currentValue += asciiDictionary[h];
            currentValue *= 17;
            currentValue = currentValue % 256;
            }
        }
        return currentValue;
    }

    public static int CalculateTotalHashValue(List<string> holidayStrings)
    {
        int totalValue = 0;
        foreach (string h in holidayStrings)
        {   
            totalValue += CalculateIndividualHashValue(h);
        }
        Console.WriteLine("total value: " + totalValue);  // Fixed the print statement for total value
        return totalValue;
    }

    static void Main()
    {
        string text = File.ReadAllText("test_input.txt");
        Console.WriteLine(text);
        List<string> holidayStrings = ParseInput(text);
        CalculateTotalHashValue(holidayStrings);
    }
}
