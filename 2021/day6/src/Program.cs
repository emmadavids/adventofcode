using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static List<int> ParseInput(string input)
    {
        // string[] numberStrings = input.Split(",");
        // List<int> numbers = new List<int>();
        // foreach (string number in numberStrings)
        // {
        //     int num = Convert.ToInt32(number);
        //     numbers.Add(num);
        // }
        // return numbers;
        return input.Split(",").Select(int.Parse).ToList();
    }
    public static void LanternFishSpawnCalculator(int days, List<int>fishput)
    {
        while (days != 0)
        {   
            for (int i = 0; i < fishput.Count; i++)
            {    
                if (fishput[i] == 0)
                {
                    fishput.Add(9);
                    fishput[i] = 7; 
                }     
                fishput[i] = fishput[i] -1;  
            }
            days --;
        }
        Console.WriteLine(fishput.Count());
    }
static void Main()
{
    // string testInput = "3,4,3,1,2";
    string text = File.ReadAllText("input.txt");
    List<int> fishies = ParseInput(text);
    LanternFishSpawnCalculator(256, fishies);
}

}