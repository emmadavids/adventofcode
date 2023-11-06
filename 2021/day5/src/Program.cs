﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static List<Vent> vents = new List<Vent>();

    public class Vent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int hasBeenTouched = 0;
        public Vent(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public static class VentUtilities {
    public static void ProcessInput(List<string> lines)
    {
        Console.WriteLine("beep");
        foreach (string line in lines)
        {
            int hello = 0;
            int x_axis1 = Convert.ToInt32(line[0]);
            int y_axis1 = Convert.ToInt32(line[2]);
            int x_axis2 = Convert.ToInt32(line[7]);
            int y_axis2 = Convert.ToInt32(line[9]);
            if (y_axis1 == y_axis2)
            {
                int start = Math.Min(x_axis1, x_axis2);
                int end = Math.Max(x_axis1, x_axis2);
                for (int x = start; x <= end; x++)
                {   
                    Console.WriteLine($"fired {hello} times");
                    Vent existingVent = vents.Find(v => v.X == x && v.Y == y_axis1);
                    if (existingVent != null)
                    {
                        existingVent.hasBeenTouched++;
                    }
                    else
                    {
                        Vent vent = new Vent(x, y_axis1);
                        vents.Add(vent);
                    }
                    hello++;
                }
            }
            else if (x_axis1 == x_axis2)
            {
                int start = Math.Min(y_axis1, y_axis2);
                int end = Math.Max(y_axis1, y_axis2);
                for (int y = start; y <= end; y++)
                {
                    Vent existingVent = vents.Find(v => v.X == x_axis1 && v.Y == y);
                    if (existingVent != null)
                    {
                        Console.WriteLine("uiskhsd");
                        existingVent.hasBeenTouched++;
                    }
                    else
                    {
                        Vent vent = new Vent(x_axis1, y);
                        vents.Add(vent);
                    }
                }
            }
        }
    }
    
    public static int GetOverlaps(List<Vent> vents)
    {
        return vents.Where(c => c.hasBeenTouched > 1).Count();
    }
    }
    static void Main()
    {
        // Program program = new Program();
        List<string> lines = File.ReadLines("test_input.txt").ToList();
        Console.WriteLine("ifdjfdidf");
        VentUtilities.ProcessInput(lines);
        Console.WriteLine(VentUtilities.GetOverlaps(vents));
    }
}