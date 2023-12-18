public class Program 
{
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
    
    List<char> possibleTopPipes = new List<char>{ 'F', '|', '7'};
    List<char> possibleBottomPipes = new List<char>{ 'L', '|', 'J'};
    List<char> possibleLeftPipes = new List<char>{ 'F', '-', 'L'};
    List<char> possibleRightPipes = new List<char>{ '-', 'J', '7'};
    List<Tuple<int,int>> vistedNodes = new List<Tuple<int, int>>();
public static void Main()
{
    List<Coordinate> coordinates = new List<Coordinate>();
    // Tuple<int,int> startingCoordinate = new Tuple<int, int>();
    Dictionary<char, List<(int, int)>> exits = new Dictionary<char, List<(int, int)>>
        {
            { '|', new List<(int, int)> { (0, -1), (0, 1) } },
            { '7', new List<(int, int)> { (-1, 0), (0, 1) } },
            { '-', new List<(int, int)> { (-1, 0), (1, 0) } },
            { 'J', new List<(int, int)> { (-1, 0), (0, -1) } },
            { 'L', new List<(int, int)> { (0, -1), (1, 0) } },
            { 'F', new List<(int, int)> { (0, 1), (1, 0) } },
        };


    string[] lines = File.ReadAllLines("test_input.txt");
    int y;
    int x;
    for (int i = 0; i < lines.Count(); i++)
    {
        if (lines[i].Contains('S'))
        {
            x = i;
            y = lines[i].IndexOf('S');
            Coordinate startingCoordinate = new Coordinate(x, y);
            coordinates.Add(startingCoordinate);
            break;
        }   
    }

    char neighbouringPipe;

    List<Tuple<int, int>> startNeighbouringCoords = new List<Tuple<int, int>>{ (0,-1), (0,1), (-1,0), (1,0) };

    for (int i = 0; i < startNeighbouringCoords.Count; i++) 
    {
        x += startNeighbouringCoords[i].ItemOne;
        y += startNeighbouringCoords[i].ItemTwo;
        neighbouringPipe = lines[x][y];
        Tuple<int, int> neighbouringCoords = (x, y); 

        if (possibleTopPipes.Contains(neighbouringPipe) && startNeighbouringCoords[i] == (0, -1))
            {
                vistedNodes.Add(neighbouringCoords);
            }
        else if (possibleBottomPipes.Contains(neighbouringPipe) && startNeighbouringCoords[i] == (0, 1))
            {
                vistedNodes.Add(neighbouringCoords);
            }
        else if (possibleLeftPipes.Contains(neighbouringPipe) && startNeighbouringCoords[i] == (-1, 0))
            {
                vistedNodes.Add(neighbouringCoords);
            }
        else if (possibleRightPipes.Contains(neighbouringPipe) && startNeighbouringCoords[i] == (1, 0))
            {
                vistedNodes.Add(neighbouringCoords);
            }

    
    }
    bool keepLooping = true;
    Tuple<int, int> currentPipeDirection = new Tuple<int, int>();

    while (keepLooping)
    {
        currentPipeDirection = exits[neighbouringPipe];

        if (visitedNodes.Contains(currentPipeDirection[0]))
        {
            x += currentPipeDirection[1].ItemOne;
            y += currentPipeDirection[1].ItemTwo;
        }
        else if (visitedNodes.Contains(currentPipeDirection[1]))
        {
            x += currentPipeDirection[0].ItemOne;
            y += currentPipeDirection[0].ItemTwo;
        }
        
        neighbouringPipe = lines[x][y];
        if (lines[x][y] == 'S')
        {
            keepLooping = false;
            break;
        }
    }

}    

}