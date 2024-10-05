// using System;

// public class Program

// {

//     public static List<int> mirrorData = new();
//     public static List<string> ParseMirrorPatterns(string lines)

//     {
//         return lines
//         .Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
//         .ToList();
//     }

//     public static void HandleValleyOfMirrors(List<string> mirrorPatterns)

//     {
//         Console.WriteLine(mirrorPatterns.Count);
//         foreach (string mirrorPattern in mirrorPatterns)
//         {
//             List<string> mirrorLines = mirrorPattern.Split(Environment.NewLine).ToList();
//             List<(int, string)> mirrorIndex = FindIndexOfReflection(mirrorLines);
//         }
//         Console.WriteLine(mirrorData.Sum());
//     }
//     public static int times = 0;
//     public static List<(int, string)> FindIndexOfReflection(List<string> mirrorLines)
// {
//     List<(int, string)> reflectionIndex = new();
    
//     for (int i = 0; i < mirrorLines.Count(); i++) {
//         if (i < mirrorLines.Count - 1) {
//             if (mirrorLines[i] == mirrorLines[i + 1]) {   
//                 reflectionIndex.Add((i, "horizontal"));
//                 KeepMirroringToFindReflection(reflectionIndex, mirrorLines);
//                 reflectionIndex.Clear();
//                 break;
//             }
//         }
//     }

//     for (int idx = 0; idx < mirrorLines[0].Count(); idx++) {    
//         if (idx <= mirrorLines[0].Length - 2) {
//             if (mirrorLines.All(x => x[idx] == x[idx + 1])) {
//                 reflectionIndex.Add((idx, "vertical")); 
//                 KeepMirroringToFindReflection(reflectionIndex, mirrorLines);
//                 break;
//             }
//         }
//     }
    

//         foreach (int idx in Enumerable.Range(0, mirrorLines[0].Count()))

//         {   
//             // Console.WriteLine($"fired {times} times");
//             times ++;
//             if (idx <= mirrorLines[0].Length - 2) {
//                 if (mirrorLines.All(x => x[idx] == x[idx + 1]))
//                 {
//                     reflectionIndex.Add((idx, "vertical"));
//                     KeepMirroringToFindReflection(reflectionIndex, mirrorLines);
//                     break;
//                 }
//             }
//         }
//         return reflectionIndex;
//     }

//     // public static void KeepMirroringToFindReflection(List<(int, string)> mirrorIndex, List<string> mirrorLines)

//     // {
//     //     bool keepMirroring = true;
//     //     int mirrorIdx = mirrorIndex[0].Item1;
//     //     int topReflection = 1;
//     //     int bottomReflection = 2;
//     //     int leftReflection = 1;
//     //     int rightReflection = 2;

//     //     while (keepMirroring)
//     //     {
//     //         if (mirrorIdx == 0)
//     //         {
//     //             break;
//     //         }
//     //         if (mirrorIndex[0].Item2 == "horizontal")
//     //         {   
//     //             if(mirrorIdx - topReflection < 0 || mirrorIdx + bottomReflection >= mirrorLines.Count) 
//     //             {
//     //                 mirrorData.Add((mirrorIdx + 1) * 100);
//     //                 break;
//     //             }
//     //             //top reflection should never be more than mirror
//     //             if (mirrorLines[mirrorIdx - topReflection] == mirrorLines[mirrorIdx + bottomReflection])
//     //             {
//     //                 topReflection += 1;
//     //                 bottomReflection += 1;
//     //             }
//     //             else
//     //             {
//     //                 break;
//     //             }
//     //         }
//     //         else
//     //         {
//     //             if (mirrorIndex[0].Item2 == "vertical"){
//     //             if(mirrorIdx - leftReflection < 0 || mirrorIdx + rightReflection >=  mirrorLines[0].Length) 
//     //             {
//     //                 // Console.WriteLine(mirrorIdx + 1);
//     //                 mirrorData.Add(mirrorIdx + 1);
//     //                 break;
//     //             }
//     //             if (mirrorLines.All(x => x[mirrorIdx - leftReflection] == x[mirrorIdx + rightReflection]))
//     //             {
//     //                 leftReflection += 1;
//     //                 rightReflection += 1;
//     //             }
//     //             else
//     //             {
//     //                 break;
//     //             }
//     //         }}
//     //     }
//     // }
// public static void KeepMirroringToFindReflection(List<(int, string)> mirrorIndex, List<string> mirrorLines)  

//     {
//         int score = 0;
        
//         foreach (var (mirrorIdx, direction) in mirrorIndex) {

//             if (direction == "horizontal") {

//                 int rows = 1;
//                 int offset = 1;
//                 while (mirrorIdx - offset >= 0  
//                        && mirrorIdx + offset < mirrorLines.Count
//                        && mirrorLines[mirrorIdx - offset] == mirrorLines[mirrorIdx + offset]) {
                    
//                     rows++;
//                     offset++;
//                 }
//                 score = rows * 100;

//             } else {

//                 int cols = 0;
//                 int offset = 1;
//                 while (mirrorIdx - offset >= 0  
//                        && mirrorIdx + offset < mirrorLines.Count  
//                        && mirrorLines.All(line => line[mirrorIdx - offset] == line[mirrorIdx + offset])) {

//                     cols++;
//                     offset++;
//                 }
//                 score = cols;
//             }
            
//             mirrorData.Add(score);
//         }
//     }
//     public static void Main()
//     {
//         string lines = File.ReadAllText("full_input.txt");
//         List<string> mirrorPatterns = ParseMirrorPatterns(lines);
//         HandleValleyOfMirrors(mirrorPatterns);
//     }
// }

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    public static List<int> mirrorData = new();

    // Parses the input into a list of patterns separated by double newlines
    public static List<string> ParseMirrorPatterns(string lines)
    {
        return lines.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    // Main logic to handle all mirror patterns
    public static void HandleValleyOfMirrors(List<string> mirrorPatterns)
    {
        Console.WriteLine($"Number of patterns: {mirrorPatterns.Count}");
        foreach (string mirrorPattern in mirrorPatterns)
        {
            List<string> mirrorLines = mirrorPattern.Split(Environment.NewLine).ToList();
            List<(int, string)> mirrorIndex = FindIndexOfReflection(mirrorLines);
        }
        Console.WriteLine($"Total score: {mirrorData.Sum()}");
    }

    // Finds indices of reflection (either horizontal or vertical)
    public static List<(int, string)> FindIndexOfReflection(List<string> mirrorLines)
    {
        List<(int, string)> reflectionIndex = new();

        // Check for horizontal reflections between rows
        for (int i = 0; i < mirrorLines.Count - 1; i++)
        {
            if (mirrorLines[i] == mirrorLines[i + 1])
            {
                reflectionIndex.Add((i, "horizontal"));
                KeepMirroringToFindReflection(reflectionIndex, mirrorLines);
                reflectionIndex.Clear(); // Clear after finding a reflection
                break;
            }
        }

        // Check for vertical reflections between columns
        for (int idx = 0; idx < mirrorLines[0].Length - 1; idx++)
        {
            if (mirrorLines.All(line => line[idx] == line[idx + 1]))
            {
                reflectionIndex.Add((idx, "vertical"));
                KeepMirroringToFindReflection(reflectionIndex, mirrorLines);
                break;
            }
        }

        return reflectionIndex;
    }

    // Calculates the score based on reflections
    public static void KeepMirroringToFindReflection(List<(int, string)> mirrorIndex, List<string> mirrorLines)
    {
        int score = 0;

        foreach (var (mirrorIdx, direction) in mirrorIndex)
        {
            if (direction == "horizontal")
            {
                // Calculate number of rows above the reflection line
                int rows = mirrorIdx + 1;
                score = rows * 100; // Score = 100 * number of rows above
            }
            else if (direction == "vertical")
            {
                // Calculate number of columns to the left of the reflection line
                int cols = mirrorIdx + 1;
                score = cols; // Score = number of columns to the left
            }

            mirrorData.Add(score);
        }
    }

    // Entry point to the program
    public static void Main()
    {
        // Read input from file "full_input.txt"
        string lines = File.ReadAllText("full_input.txt");
        List<string> mirrorPatterns = ParseMirrorPatterns(lines);
        HandleValleyOfMirrors(mirrorPatterns);
    }
}
