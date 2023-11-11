using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static List<int> ParseInput(string input)
    {
        string[] numberStrings = input.Split(",");
        int[] numbers = new List<int>;
        foreach (string number in numberStrings)
        {
            int num = Convert.ToInt32(number);
            numbers.Add(num);
        }
        return numbers;
    }
    public static 
}