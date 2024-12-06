// // using System;
// // using System.Collections.Generic;
// // using System.IO;
// // using System.Linq;

// // class Program
// // {
// //     public static List<string> ParseInput(string input)
// //     {   
// //         string[] stringyInput = input.Split(",");
// //         return stringyInput.ToList();
// //     }

// //     public static Dictionary<char, int> BuildDictionary()
// //     {
// //         Dictionary<char, int> asciiDict = new Dictionary<char, int>();

// //         for (int i = 0; i < 128; i++)
// //         {
// //             char c = (char)i;
// //             asciiDict[c] = i;
// //         }
// //         return asciiDict;
// //     }

// //     public static int CalculateIndividualHashValue(string input)
// //     {
// //         Dictionary<char, int> asciiDictionary = BuildDictionary();
// //         Console.WriteLine("input: " + input); 
// //         int currentValue = 0;
// //         List<char> holidayChars = input.ToCharArray().ToList();  
// //         foreach (char h in holidayChars)
// //         {
// //             currentValue += asciiDictionary[h];
// //             currentValue *= 17;
// //             currentValue = currentValue % 256;
// //         }
// //         return currentValue;
// //     }

// //     public static int CalculateTotalHashValue(List<string> holidayStrings)
// //     {
// //         int totalValue = 0;
// //         foreach (string h in holidayStrings)
// //         {   
// //             totalValue += CalculateIndividualHashValue(h);
// //         }
// //         Console.WriteLine("total value: " + totalValue); 
// //         return totalValue;
// //     }
// //     public static Dictionary<int, List<(string, int?)>> SortLenses(List<string> holidayStrings)
// //     {
// //         Dictionary<int, List<(string, int?)>> lenses = new Dictionary<int, List<(string, int?)>>();
// //         foreach (string h in holidayStrings)
// //         {   
// //             string firstTwoChars = h.Substring(0, 2);
// //             int boxNumber = CalculateIndividualHashValue(firstTwoChars);
// //             if (!lenses.ContainsKey(boxNumber))
// //             {
// //                 lenses[boxNumber] = new List<(string, int?)>();
// //             }
// //             int idx = lenses[boxNumber].FindIndex(t => t.Item1 == firstTwoChars);
// //             if (h.Length == 2)
// //             {
// //                 lenses[boxNumber].Add((firstTwoChars, null));
// //             }
// //             else if (h.Length == 3 && idx != -1)
// //             {
// //                 lenses[boxNumber].RemoveAt(idx);
// //             }
// //             else if (h.Length == 4)
// //             {
// //                 int focalLength = int.Parse(h.Substring(3, 1));
// //                 if (idx != -1)
// //                 {
// //                     {
// //                         lenses[boxNumber][idx] = (firstTwoChars, focalLength);
// //                     }
// //                 }
// //                 else 
// //                 {
// //                     lenses[boxNumber].Add((firstTwoChars, focalLength));
// //                 }
// //             }
// //         // Console.WriteLine($"boxNumber: {boxNumber}, lenses: [{string.Join(", ", lenses[boxNumber].Select(t => $"({t.Item1}, {t.Item2?.ToString() ?? "null"})"))}]");
// //         }
// //         return lenses;
// //     }
    
// //     static int CalculateFocalLength(Dictionary<int, List<(string, int?)>> lenses)
// //     {
// //         int totalValue = 0;
// //         foreach (var kvp in lenses)
// //         {
// //             int slotNumber = 1;
// //             // totalValue += kvp.Key + 1;
// //             foreach (var tup in kvp.Value)
// //             {
// //                 if (tup.Item2.HasValue) 
// //                 {
// //                     totalValue += (kvp.Key + 1) * slotNumber * tup.Item2.Value;
// //                 }
// //                 slotNumber ++;
// //             }
// //         }
// //         Console.WriteLine("total val: " + totalValue);
// //         return totalValue;
// //     }
// //     static void Main()
// //     {
// //         string text = File.ReadAllText("test_input.txt");
// //         Console.WriteLine(text);
// //         List<string> holidayStrings = ParseInput(text);
// //         CalculateTotalHashValue(holidayStrings);
// //         var sortedLenses = SortLenses(holidayStrings);
// //         CalculateFocalLength(sortedLenses);
// //     }
// // }

// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Text.RegularExpressions;

// class Program
// {
//     public static List<string> ParseInput(string input)
//     {   
//         string[] stringyInput = input.Split(",");
//         return stringyInput.ToList();
//     }

//     public static Dictionary<char, int> BuildDictionary()
//     {
//         Dictionary<char, int> asciiDict = new Dictionary<char, int>();

//         for (int i = 0; i < 128; i++)
//         {
//             char c = (char)i;
//             asciiDict[c] = i;
//         }
//         return asciiDict;
//     }

//     public static int CalculateIndividualHashValue(string input)
//     {
//         Dictionary<char, int> asciiDictionary = BuildDictionary();
//         int currentValue = 0;
//         List<char> holidayChars = input.ToCharArray().ToList();  
//         foreach (char h in holidayChars)
//         {
//             currentValue += asciiDictionary[h];
//             currentValue *= 17;
//             currentValue = currentValue % 256;
//         }
//         return currentValue;
//     }

//     public static int CalculateTotalHashValue(List<string> holidayStrings)
//     {
//         int totalValue = 0;
//         foreach (string h in holidayStrings)
//         {   
//             totalValue += CalculateIndividualHashValue(h);
//         }
//         return totalValue;
//     }

//     public static Dictionary<int, List<(string, int?)>> SortLenses(List<string> holidayStrings)
//     {
//         Dictionary<int, List<(string, int?)>> lenses = new Dictionary<int, List<(string, int?)>>();
//         Regex regex = new Regex(@"[=-]");

//         foreach (string h in holidayStrings)
//         {
//             Match match = regex.Match(h);
//             string firstTwoChars = h.Length >= 2 ? h.Substring(0, 2) : h;
//             int boxNumber = CalculateIndividualHashValue(firstTwoChars);
//             Console.WriteLine("" + boxNumber);
//             if (!lenses.ContainsKey(boxNumber))
//             {
//                 lenses[boxNumber] = new List<(string, int?)>();
//             }

//             int idx = lenses[boxNumber].FindIndex(t => t.Item1 == firstTwoChars);

//             if (match.Success)
//             {
//                 char foundChar = match.Value[0];
//                 int matchIndex = match.Index;

//                 if (h.Length == 2)
//                 {
//                     lenses[boxNumber].Add((firstTwoChars, null));
//                 }
//                 else if (h.Length == 3 && idx != -1)
//                 {
//                     if (foundChar == '-')
//                     {
//                         lenses[boxNumber].RemoveAt(idx);
//                     }
//                 }
//                 else if (h.Length >= 4)
//                 {
//                     int focalLength = 0;
//                     if (matchIndex + 1 < h.Length && char.IsDigit(h[matchIndex + 1]))
//                     {
//                         focalLength = int.Parse(h[matchIndex + 1].ToString());
//                     }

//                     if (foundChar == '-')
//                     {
//                         if (idx != -1)
//                         {
//                             lenses[boxNumber].RemoveAt(idx);
//                         }
//                     }
//                     else if (foundChar == '=')
//                     {
//                         if (idx != -1)
//                         {
//                             lenses[boxNumber][idx] = (firstTwoChars, focalLength);
//                         }
//                         else 
//                         {
//                             lenses[boxNumber].Add((firstTwoChars, focalLength));
//                         }
//                     }
//                 }
//             }
//         }
//         return lenses;
//     }
    
//     static int CalculateFocalLength(Dictionary<int, List<(string, int?)>> lenses)
//     {
//         int totalValue = 0;
//         foreach (var kvp in lenses)
//         {
//             int slotNumber = 1;
//             // totalValue += kvp.Key + 1;
//             foreach (var tup in kvp.Value)
//             {
//                 if (tup.Item2.HasValue) 
//                 {
//                     totalValue += (kvp.Key + 1) * slotNumber * tup.Item2.Value;
//                 }
//                 slotNumber++;
//             }
//         }
//         Console.WriteLine("Total focal length value: " + totalValue);
//         return totalValue;
//     }

//     static void Main()
//     {
//         string text = File.ReadAllText("full_input.txt");
//         List<string> holidayStrings = ParseInput(text);
//         CalculateTotalHashValue(holidayStrings);
//         var sortedLenses = SortLenses(holidayStrings);
//         CalculateFocalLength(sortedLenses);
//     }
// }
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    // Parses the comma-separated initialization sequence input into a list of individual steps
    public static List<string> ParseInput(string input)
    {   
        return input.Split(",").ToList();
    }

    // Builds an ASCII dictionary for quick ASCII code lookup
    public static Dictionary<char, int> BuildAsciiDictionary()
    {
        Dictionary<char, int> asciiDict = new Dictionary<char, int>();
        for (int i = 0; i < 128; i++)
        {
            asciiDict[(char)i] = i;
        }
        return asciiDict;
    }

    // HASH algorithm for each string: calculates a hash value in the range of 0-255
    public static int CalculateHash(string input)
    {
        var asciiDictionary = BuildAsciiDictionary();
        int currentValue = 0;

        foreach (char character in input)
        {
            currentValue += asciiDictionary[character];
            currentValue *= 17;
            currentValue %= 256;  // Keep within 0-255 range
        }
        return currentValue;
    }

    // Sums up HASH values for a list of strings
    public static int CalculateTotalHashValue(List<string> items)
    {
        int totalHash = items.Sum(item => CalculateHash(item));
        Console.WriteLine("Total HASH Value: " + totalHash);
        return totalHash;
    }

    // Sorts lenses into appropriate boxes and applies operations based on HASH values
    public static Dictionary<int, List<(string Label, int? FocalLength)>> SortLenses(List<string> items)
    {
        Dictionary<int, List<(string Label, int? FocalLength)>> boxes = new Dictionary<int, List<(string Label, int? FocalLength)>>();
        Regex regex = new Regex(@"[=-]");

        foreach (string item in items)
        {
            Match match = regex.Match(item);
            string label = item.Length >= 2 ? item.Substring(0, 2) : item;
            int boxIndex = CalculateHash(label);

            if (!boxes.ContainsKey(boxIndex))
            {
                boxes[boxIndex] = new List<(string Label, int? FocalLength)>();
            }

            int lensIndex = boxes[boxIndex].FindIndex(lens => lens.Label == label);

            if (match.Success)
            {
                char operation = match.Value[0];
                int operationPosition = match.Index;

                if (item.Length == 3 && operation == '-' && lensIndex != -1)
                {
                    boxes[boxIndex].RemoveAt(lensIndex); // Remove lens if '-' is specified
                }
                else if (item.Length >= 4 && operation == '=')
                {
                    int focalLength = int.Parse(item.Substring(operationPosition + 1, 1));
                    if (lensIndex != -1)
                    {
                        boxes[boxIndex][lensIndex] = (label, focalLength); // Replace if lens exists
                    }
                    else
                    {
                        boxes[boxIndex].Add((label, focalLength)); // Add new lens if it doesn't exist
                    }
                }
            }
        }
        return boxes;
    }

    // Calculates total focusing power for all lenses in all boxes
    static int CalculateFocusingPower(Dictionary<int, List<(string Label, int? FocalLength)>> boxes)
    {
        int totalPower = 0;

        foreach (var kvp in boxes)
        {
            int boxNumber = kvp.Key;
            int slotNumber = 1;

            foreach (var (Label, FocalLength) in kvp.Value)
            {
                if (FocalLength.HasValue)
                {
                    totalPower += (boxNumber + 1) * slotNumber * FocalLength.Value;
                }
                slotNumber++;
            }
        }
        Console.WriteLine("Total Focusing Power: " + totalPower);
        return totalPower;
    }

    static void Main()
    {
        // Load and parse the input
        string text = File.ReadAllText("full_input.txt");
        List<string> steps = ParseInput(text);

        // Step 1: Verify HASH algorithm on each step
        CalculateTotalHashValue(steps);

        // Step 2: Sort lenses according to the rules and calculate final focusing power
        var sortedLenses = SortLenses(steps);
        CalculateFocusingPower(sortedLenses);
    }
}
