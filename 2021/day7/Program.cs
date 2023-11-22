using System;
using System.Runtime.CompilerServices;

public class Program
{
        public static List<int> ParseInput(string text)
        {
            return text.Split(",").Select(int.Parse).ToList();
        }
        // public static int findMedianLocationOfCrabs(List<int> crabLocations)
        // {
        //     var crabs = crabLocations.OrderBy(crab=>crab);
        //     if (crabs.Sum() % 2 == 0)
        //     {
        //         double medianLocation = (crabs[crabs.Sum() / 2 - 1] + crabs[crabs.Sum() / 2]) / 2;
        //     }
        //     else {
        //         return crabs[crabs.Count/2];
        //     }
        // }

        public static void calculateOptimalCrabPosition(List<int> crabLocations)
        {
            // int range = 5;
            // int medianCrabIndex = crabLocations.IndexOf(medianCrabshipLocation);

            // var crabPositionsToBeCalculated = crabLocations.Where((_, index) => index >= medianCrabIndex - range && medianCrabIndex + range)
            // .ToList();
            int smallestLocation = int.MaxValue;
            for (int i = 0; i < crabLocations.Max(); i ++)
            {
                int fuelCost = 0;
                foreach (int loc in crabLocations)
                {
                    // int fuelLocToPosition = 0;
                    int steps = Math.Abs(loc - i);  
                    fuelCost += ((steps * steps) + steps) / 2;
                }
                    if (fuelCost < smallestLocation)
                    {
                        smallestLocation = fuelCost;
                    }
            }
            Console.WriteLine(smallestLocation);
        }
        static void Main()
        {
            string text = File.ReadAllText("test_input.txt");
            // string test_input = "16,1,2,0,4,2,7,1,2,14";
            List<int> crabLocations = ParseInput(text);
            // int medianCrabshipLocation = findMedianLocationOfCrabs(crabLocations);
            calculateOptimalCrabPosition(crabLocations);
        }
}


