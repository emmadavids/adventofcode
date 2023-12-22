using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;

public class Program 
{
    public static List<char> possibleTopPipes = new() { 'F', '|', '7'};
    public static List<char> possibleBottomPipes = new() { 'L', '|', 'J'};
    public static List<char> possibleLeftPipes = new() { 'F', '-', 'L'};
    public static List<char> possibleRightPipes = new() { '-', 'J', '7'};
    public static List<(int, int)> visitedNodes = new();
    public static int steps = 0;
    public static List<Coordinate> coordinates = new();
    
    public static int y = 0;
    public static int x = 0;
    public static char neighbouringPipe = 'S';

    public static Dictionary<char, List<(int, int)>> exits = new()
    {
            { '|', new List<(int, int)> { (-1, 0), (1, 0) } },
            { '7', new List<(int, int)> { (0, -1), (1, 0) } },
            { '-', new List<(int, int)> { (0, -1), (0, 1) } },
            { 'J', new List<(int, int)> { (-1, 0), (0, -1) } },
            { 'L', new List<(int, int)> { (-1, 0), (0, 1) } },
            { 'F', new List<(int, int)> { (1, 0), (0, 1) } },
        };

    public static List<(int, int)> startNeighbouringCoords = new() { (0, -1), (0, 1), (-1, 0), (1, 0) };
    
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        } 
    }
    
    public static void FindStart(string[] lines)
    {
        for (int i = 0; i < lines.Count(); i++)
        {
            if (lines[i].Contains('S'))
            {
                x = i;
                y = lines[i].IndexOf('S');
                Console.WriteLine($"x:{x},y:{y}");
                Coordinate startingCoordinate = new Coordinate(x, y);
                coordinates.Add(startingCoordinate);
                visitedNodes.Add((x, y));
                break;
            }   
        }
    }

    public static void TraverseFromStart(string[] lines)
    {
        for (int i = 0; i < startNeighbouringCoords.Count; i++) 
        {
            try{
            int xCopy = x + startNeighbouringCoords[i].Item1;
            int yCopy = y + startNeighbouringCoords[i].Item2;
            neighbouringPipe = lines[xCopy][yCopy];
            Console.WriteLine($"neighbouring pipe{neighbouringPipe}, neighbouring coordinates{startNeighbouringCoords[i]}");
            Tuple<int, int> neighbouringCoords = (xCopy, yCopy).ToTuple(); 
            Console.WriteLine($"x: {xCopy} y: {yCopy}");
            if (possibleTopPipes.Contains(neighbouringPipe) && startNeighbouringCoords[i] == (-1, 0))
                {
                    visitedNodes.Add((neighbouringCoords.Item1, neighbouringCoords.Item2));
                    neighbouringPipe = lines[xCopy][yCopy];
                    Console.WriteLine($"returning neighbouring pipe:{neighbouringPipe}");
                    break;
                }
            else if (possibleBottomPipes.Contains(neighbouringPipe) && startNeighbouringCoords[i] == (1, 0))
                {
                    visitedNodes.Add((xCopy,yCopy));
                    neighbouringPipe = lines[xCopy][yCopy];

                    x = xCopy;
                    y = yCopy;
                    break;
                }
            else if (possibleLeftPipes.Contains(neighbouringPipe) && startNeighbouringCoords[i] == (0, -1))
                {
                    visitedNodes.Add((xCopy,yCopy));
                    neighbouringPipe = lines[xCopy][yCopy];
                    x = xCopy;
                    y = yCopy;
                    break;
                }
            else if (possibleRightPipes.Contains(neighbouringPipe) && startNeighbouringCoords[i] == (0, 1))
                {
                    visitedNodes.Add((xCopy,yCopy));
                    neighbouringPipe = lines[xCopy][yCopy];
                    x = xCopy;
                    y = yCopy;
                    break;
                }
        } catch{
            Console.WriteLine("fail");
        }
        }}
        
    

    // public static void BuildPipeMap(string[] lines)
    // {
    //     bool keepLooping = true;
        
    //     while (keepLooping)
    //     {
    //     List<(int, int)> currentPipeDirection = exits[neighbouringPipe];
    //     int x3 = x + currentPipeDirection[1].Item1;
    //     int y3 = y + currentPipeDirection[1].Item2;
    //         currentPipeDirection = exits[neighbouringPipe];
    //         if (visitedNodes.Contains((x3,y3)))
    //         {
    //             x += currentPipeDirection[0].Item1;
    //             y += currentPipeDirection[0].Item2;
    //         }
    //         else {
    //             x += currentPipeDirection[1].Item1;
    //             y += currentPipeDirection[1].Item2;
    //         }
            
    //         visitedNodes.Add((x, y));
    //         // foreach (var (coordX, coordY) in visitedNodes)
    //         //     {
    //         //         Console.WriteLine($"char {neighbouringPipe} X: {coordX}, Y: {coordY}");
    //         //     }

    //         neighbouringPipe = lines[x][y];

    //         if (lines[x][y] == 'S')
    //         {
    //             keepLooping = false;
    //             break;
    //         }
        
    // }}
public static void BuildPipeMap(string[] lines)
{
    bool keepLooping = true;

    while (keepLooping)
    {
        if (x >= 0 && x < lines.Length && y >= 0 && y < lines[x].Length)
        {
            List<(int, int)> currentPipeDirection = exits[neighbouringPipe];
            int x3 = x + currentPipeDirection[1].Item1;
            int y3 = y + currentPipeDirection[1].Item2;

            if (x3 >= 0 && x3 < lines.Length && y3 >= 0 && y3 < lines[x].Length)
            {
                currentPipeDirection = exits[neighbouringPipe];
                
                if (visitedNodes.Contains((x3, y3)))
                {
                    x += currentPipeDirection[0].Item1;
                    y += currentPipeDirection[0].Item2;
                }
                else
                {
                    x += currentPipeDirection[1].Item1;
                    y += currentPipeDirection[1].Item2;
                }

                visitedNodes.Add((x, y));

                neighbouringPipe = lines[x][y];

                if (lines[x][y] == 'S')
                {
                    keepLooping = false;
                    break;
                }
            }
            else
            {
                Console.WriteLine("Error: Out of bounds at x:{0}, y:{1}", x3, y3);
                // Handle the out-of-bounds scenario
                keepLooping = false;
            }
        }
        else
        {
            Console.WriteLine("Error: Out of bounds at x:{0}, y:{1}", x, y);
            // Handle the out-of-bounds scenario
            keepLooping = false;
        }
    }
}


    public static int CountSteps()
    {
        if (visitedNodes.Count % 2 == 0)
        {
            return visitedNodes.Count / 2;
        }
        else
        {
            return (visitedNodes.Count - 1) / 2;
        }
    }

public static void Main()
{   
    string[] lines = File.ReadAllLines("full_input.txt");
    FindStart(lines);
    TraverseFromStart(lines);
    BuildPipeMap(lines);
    Console.WriteLine(CountSteps());
}
}    



