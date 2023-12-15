using System.Linq;

public class Program
{
    public static List<char> ParseDirections(List<string> lines)
    {
        List<char> directions = new List<char>();
        foreach (string line in lines)
        {
            if (String.IsNullOrWhiteSpace(line))
                {
                    return directions;
                    break;
                }
            foreach (char direction in line)
            {   
                if (!Char.IsLetter(direction))
                {
                    return directions;
                    break;
                }
                directions.Add(direction);
            }
        }
        return directions;
    }
        
    public static Dictionary <string, Tuple<string, string>> ParseLocations(List<string> lines)
    {
        Dictionary <string, Tuple<string, string>> locations = new Dictionary<string, Tuple<string, string>>();
        for (int i = 2; i < lines.Count; i++ )
        {
            locations.Add(lines[i].Substring(0,3), (lines[i].Substring(7,3), lines[i].Substring(12,3)).ToTuple());
        }
        return locations;
    } 
    // public static int NightmarishTraversal(List<char> directions,
    //                                 Dictionary <string, Tuple<string, string>> locations)
    // {
    //     int steps = 0;
    //     string lastSeenSpace = "AAA";
    //     while (lastSeenSpace != "ZZZ")
    //     {
    //         foreach (char direction in directions)
    //         {
    //             string currentStep;
    //             if (direction == 'L')
    //             {  
    //                 currentStep = locations[lastSeenSpace].Item1;
    //             }
    //             else
    //             {
    //                 currentStep = locations[lastSeenSpace].Item2;
    //             }
    //             //set new value
    //             lastSeenSpace = currentStep;
    //             steps += 1;
    //         }
    //     }
    //     Console.WriteLine(steps);
    //     return steps;
    // }

     public static int NightmarishTraversal(List<char> directions,
                                    Dictionary <string, Tuple<string, string>> locations)
    {
        int steps = 0;
        string lastSeenSpace = "AAA";
        while (!lastSeenSpace.Contains("Z"))
        {
            foreach (char direction in directions)
            {
                var filteredKeys = locations.Keys
                    .Where(k => k[2] == 'A')
                    .ToList();
                foreach (var key in filteredKeys)
                {
                string currentStep;
                if (direction == 'L')
                {  
                    currentStep = locations[key].Item1;
                }
                else
                {
                    currentStep = locations[key].Item2;
                }
                //set new value
                lastSeenSpace = currentStep;
                steps += 1;}
            }
        }
        Console.WriteLine(steps);
        return steps;
    }
    static void Main()
    {
        List<string> lines = File.ReadLines("full_input.txt").ToList();
        Dictionary <string, Tuple<string, string>> locations = ParseLocations(lines);
        List<char> directions = ParseDirections(lines);
        NightmarishTraversal(directions, locations);
    }
}