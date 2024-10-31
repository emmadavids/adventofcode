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
            currentValue += asciiDictionary[h];
            currentValue *= 17;
            currentValue = currentValue % 256;
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
        Console.WriteLine("total value: " + totalValue); 
        return totalValue;
    }
    public static Dictionary<int, List<(string, int?)>> SortLenses(List<string> holidayStrings)
    {
        Dictionary<int, List<(string, int?)>> lenses = new Dictionary<int, List<(string, int?)>>();
        foreach (string h in holidayStrings)
        {   
            string firstTwoChars = h.Substring(0, 2);
            int boxNumber = CalculateIndividualHashValue(firstTwoChars);
            if (!lenses.ContainsKey(boxNumber))
            {
                lenses[boxNumber] = new List<(string, int?)>();
            }
            int idx = lenses[boxNumber].FindIndex(t => t.Item1 == firstTwoChars);
            if (h.Length == 2)
            {
                lenses[boxNumber].Add((firstTwoChars, null));
            }
            else if (h.Length == 3 && idx != -1)
            {
                lenses[boxNumber].RemoveAt(idx);
            }
            else 
            {
                int focalLength = int.Parse(h.Substring(3, 1));
                if (idx != -1)
                {
                    {
                        lenses[boxNumber][idx] = (firstTwoChars, focalLength);
                    }
                }
                else 
                {
                    lenses[boxNumber].Add((firstTwoChars, focalLength));
                }
            }
        }
        return lenses;
    }
    
    static int CalculateFocalLength(Dictionary<int, List<(string, int?)>> lenses)
    {

        int totalValue = 0;
        foreach (var kvp in lenses)
        {
            int slotNumber = 1;
            totalValue += kvp.Key + 1;
            foreach (var tup in kvp.Value)
            {
                if (tup.Item2.HasValue) 
                {
                    totalValue += (kvp.Key + 1) * slotNumber * tup.Item2.Value;
                }
                slotNumber ++;
            }
        }
        Console.WriteLine("total val: " + totalValue);
        return totalValue;
    }
    static void Main()
    {
        string text = File.ReadAllText("test_input.txt");
        Console.WriteLine(text);
        List<string> holidayStrings = ParseInput(text);
        CalculateTotalHashValue(holidayStrings);
        SortLenses(holidayStrings);
        
    }
}
