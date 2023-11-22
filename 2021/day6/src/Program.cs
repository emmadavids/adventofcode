using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static List<int> ParseInput(string input)
    {
        return input.Split(",").Select(int.Parse).ToList();
    }
    public static void LanternFishSpawnCalculator(int days, List<int>fishput)
    {   
        Dictionary<int, long> fishTimers = new Dictionary<int, long>();
        for (int i = 0; i <= 8; i++)
        {
            fishTimers[i] = 0;
        }
        foreach (int fish in fishput)
        {
            fishTimers[fish] ++;
        }
        for (int day = 1; day <= days; day++)
        {
            long newlySpawnedFish = fishTimers[0];
            // Console.WriteLine(newlySpawnedFish);
            fishTimers[0] = 0;
            fishTimers[6] += newlySpawnedFish;
            fishTimers[8] += newlySpawnedFish;
        for (int i = 1; i<=8; i++)
        {   
            Console.WriteLine(i);
            fishTimers[i] = fishTimers[i-1];
        }
        fishTimers[8] = 0;
        }
        long totalFish = 0;
        foreach (long count in fishTimers.Values) {
            // Console.WriteLine(count);
            totalFish += count;
        }

  Console.WriteLine(totalFish);
    }   
static void Main()
{
    // string testInput = "3,4,3,1,2";
    string text = File.ReadAllText("input.txt");
    List<int> fishies = ParseInput(text);
    LanternFishSpawnCalculator(256, fishies);
}

}