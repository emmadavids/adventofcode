using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Program 
{
    public static List<char> possibleTopPipes = new() { 'F', '|', '7'};
    public static List<char> possibleBottomPipes = new() { 'L', '|', 'J'};
    public static List<char> possibleLeftPipes = new() { 'F', '-', 'L'};
    public static List<char> possibleRightPipes = new() { '-', 'J', '7'};
    public static List<(int, int)> visitedNodes = new();
    public static int steps = 0;
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
    
    public static void FindStart(string[] lines)
    {   
        for (int i = 0; i < lines.Count(); i++)
        {
            if (lines[i].Contains('S'))
            {
                x = i;
                y = lines[i].IndexOf('S');
                visitedNodes.Add((x, y));
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
            Tuple<int, int> neighbouringCoords = (xCopy, yCopy).ToTuple(); 
            if (possibleTopPipes.Contains(neighbouringPipe) && startNeighbouringCoords[i] == (-1, 0))
                {
                    visitedNodes.Add((neighbouringCoords.Item1, neighbouringCoords.Item2));
                    neighbouringPipe = lines[xCopy][yCopy];
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

    public static void BuildPipeMap(string[] lines)
    {   
        bool keepLooping = true;
        
        while (keepLooping)
        {
            List<(int, int)> currentPipeDirection = exits[neighbouringPipe];
            int x3 = x + currentPipeDirection[1].Item1;
            int y3 = y + currentPipeDirection[1].Item2;
    
            currentPipeDirection = exits[neighbouringPipe];
            if (visitedNodes.Contains((x3,y3)))
            {
                x += currentPipeDirection[0].Item1;
                y += currentPipeDirection[0].Item2;
            }
            else {
                x += currentPipeDirection[1].Item1;
                y += currentPipeDirection[1].Item2;
            }
            
            visitedNodes.Add((x, y));

            neighbouringPipe = lines[x][y];
            
            if (y -1 >= 0 && lines[x][y-1] == 'S')
            {   
                visitedNodes.Add((x, y-1));
                break;
            }
    }}

    public static int CountSteps()
    {   
        // foreach (var (coordX, coordY) in visitedNodes)
        //     {
        //         Console.WriteLine($"({coordX}, {coordY})");
        //     }
 
        if (visitedNodes.Count % 2 == 0)
        {
            return visitedNodes.Count / 2;
        }
        else
        {
            return (visitedNodes.Count - 1) / 2;
        }
}

public static bool IsBetween(int x, int y, List<(int, int)> pipeEdges)
{
    int overlaps = 0;

    for (int i = 0, j = pipeEdges.Count - 1; i < pipeEdges.Count; j = i++)
    {
        if (((pipeEdges[i].Item2 <= y && y < pipeEdges[j].Item2) ||
            (pipeEdges[j].Item2 <= y && y < pipeEdges[i].Item2)) &&
            (x < (pipeEdges[j].Item1 - pipeEdges[i].Item1) *
                    (y - pipeEdges[i].Item2) /
                    (pipeEdges[j].Item2 - pipeEdges[i].Item2) +
                pipeEdges[i].Item1))
        {
            overlaps++;
        }
    }
    return overlaps % 2 != 0;
}

public static void CheckHowManyTilesAreInsideLoop(string[] lines)
{
    int tiles = 0;
    for (int i = 0; i < lines.Count(); i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {   
            if (!visitedNodes.Contains((i,j))){
            if (IsBetween(i, j, visitedNodes))
            {
                tiles += 1;
            }}
        }
    }
    Console.WriteLine(tiles);
}
public static void Main()
{   
    string[] lines = File.ReadAllLines("full_input.txt");
    FindStart(lines);
    TraverseFromStart(lines);
    BuildPipeMap(lines);
    Console.WriteLine(CountSteps());
    CheckHowManyTilesAreInsideLoop(lines);
}
}    
