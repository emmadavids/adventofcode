using System;

public class Program

{

    public static List<int> mirrorData = new();
    public static List<string> ParseMirrorPatterns(string lines)

    {
        return lines
        .Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries)
        .ToList();
    }

    public static void HandleValleyOfMirrors(List<string> mirrorPatterns)

    {
        Console.WriteLine(mirrorPatterns.Count);
        foreach (string mirrorPattern in mirrorPatterns)
        {
            List<string> mirrorLines = mirrorPattern.Split(Environment.NewLine).ToList();
            List<(int, string)> mirrorIndex = FindIndexOfReflection(mirrorLines);
        }
        Console.WriteLine(mirrorData.Sum());
    }
    public static int times = 0;
    
    public static List<(int, string)> FindIndexOfReflection(List<string> mirrorLines)
    {
        List<(int, string)> reflectionIndex = new();
        for (int i = 0; i < mirrorLines.Count(); i++)
        {
            if (i < mirrorLines.Count - 1)
            {
                if (mirrorLines[i] == mirrorLines[i + 1])

                {
                    reflectionIndex.Add((i, "horizontal"));
                    KeepMirroringToFindReflection(reflectionIndex, mirrorLines);
                    reflectionIndex.Clear();
                    break;
                }}
        }

        foreach (int idx in Enumerable.Range(0, mirrorLines[0].Count()))

        {   
            // Console.WriteLine($"fired {times} times");
            times ++;
            if (idx <= mirrorLines[0].Length - 2) {
                if (mirrorLines.All(x => x[idx] == x[idx + 1]))
                {
                    reflectionIndex.Add((idx, "vertical"));
                    KeepMirroringToFindReflection(reflectionIndex, mirrorLines);
                    break;
                }
            }
        }
        return reflectionIndex;
    }

    public static void KeepMirroringToFindReflection(List<(int, string)> mirrorIndex, List<string> mirrorLines)

    {
        bool keepMirroring = true;
        int mirrorIdx = mirrorIndex[0].Item1;
        int topReflection = 1;
        int bottomReflection = 2;
        int leftReflection = 1;
        int rightReflection = 2;

        while (keepMirroring)
        {
            if (mirrorIdx == 0)
            {
                break;
            }
            if (mirrorIndex[0].Item2 == "horizontal")
            {   
                if(mirrorIdx - topReflection < 0 || mirrorIdx + bottomReflection >= mirrorLines.Count) 
                {
                    mirrorData.Add((mirrorIdx + 1) * 100);
                    break;
                }
                //top reflection should never be more than mirror
                if (mirrorLines[mirrorIdx - topReflection] == mirrorLines[mirrorIdx + bottomReflection])
                {
                    topReflection += 1;
                    bottomReflection += 1;
                }
                else
                {
                    break;
                }
            }
            else
            {
                if (mirrorIndex[0].Item2 == "vertical"){
                if(mirrorIdx - leftReflection < 0 || mirrorIdx + rightReflection >=  mirrorLines[0].Length) 
                {
                    // Console.WriteLine(mirrorIdx + 1);
                    mirrorData.Add(mirrorIdx + 1);
                    break;
                }
                if (mirrorLines.All(x => x[mirrorIdx - leftReflection] == x[mirrorIdx + rightReflection]))
                {
                    leftReflection += 1;
                    rightReflection += 1;
                }
                else
                {
                    break;
                }
            }}
        }
    }

    public static void Main()
    {
        string lines = File.ReadAllText("full_input.txt");
        List<string> mirrorPatterns = ParseMirrorPatterns(lines);
        HandleValleyOfMirrors(mirrorPatterns);
    }
}

