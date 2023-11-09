using System;
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
        foreach (string line in lines)
        {
            string[] points = line.Split(" -> ");

            // Split start coordinates
            string[] start = points[0].Split(",");

            int x_axis1 = Convert.ToInt32(start[0]);
            int y_axis1 = Convert.ToInt32(start[1]);

            // Split end coordinates
            string[] end = points[1].Split(",");

            int x_axis2 = Convert.ToInt32(end[0]); 
            int y_axis2 = Convert.ToInt32(end[1]);
            
            // Console.WriteLine($"Start: {x_axis1},{y_axis1}");
            // Console.WriteLine($"End: {x_axis2},{y_axis2}");

            if (y_axis1 == y_axis2)
            {  
                int pointA = Math.Min(x_axis1, x_axis2);
                int pointB = Math.Max(x_axis1, x_axis2);
                for (int x = pointA; x <= pointB; x++)
                {   
                    // Console.WriteLine($"Start: {x_axis1},{y_axis1}, End: {x_axis2},{y_axis2}");
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
                }
            }
            else if (x_axis1 == x_axis2)
            {   
                // Console.WriteLine("fired");
                int pointA = Math.Min(y_axis1, y_axis2);
                int pointB = Math.Max(y_axis1, y_axis2);
                // Console.WriteLine($"horizontal Start: ({start}, end, {end})"); 
                for (int y = pointA; y <= pointB; y++)
                {   
                    // Console.WriteLine($"Start: {x_axis1},{y}, End: {x_axis2},{pointB}");
                    Vent existingVent = vents.Find(v => v.X == x_axis1 && v.Y == y);
                    if (existingVent != null)
                    {
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
        Console.WriteLine("fired");
        return vents.Where(c => c.hasBeenTouched > 0).Count();
    }
    }
    static void Main()
    {
        // Program program = new Program();
        List<string> lines = File.ReadLines("full_input.txt").ToList();
        VentUtilities.ProcessInput(lines);
        Console.WriteLine(VentUtilities.GetOverlaps(vents));
    }
}
