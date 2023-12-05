List<string> lines = File.ReadLines("full_input.txt").ToList();

// List<char> symbols = new List<char>()
//     {
//         '*', '#', '+', '$', '&', '%', '@', '=', '/', '-'
//     };

Dictionary<Tuple<int?,int?>, List<int>> gears = new Dictionary<Tuple<int?,int?>, List<int>>();

var neighbouringCoordinates = new List<(int, int)>
{
    (-1,-1),
    (-1,0),
    (-1,1),
    (0,0),
    (0,-1),
    (0,1),
    (1,-1),
    (1,0), 
    (1,1)
};

List<int> partNumbers = new List<int>();
int counter = lines.Count;

for (int currentLine = 0; currentLine < lines.Count; currentLine++)
{   
    for (int i = 0; i < counter; i++)
    {   
        string numString = "";
        bool isEdge = i == 0;
        bool hasNoLeftNum = true; 
        if (!isEdge)
        {
            hasNoLeftNum = !Char.IsDigit(lines[currentLine][i-1]);
        }
        if (Char.IsDigit(lines[currentLine][i]) && hasNoLeftNum)
        {   
            int count = i; 
            bool keepChecking = true; 
            bool canBeIncluded = false;
            int? xCoord = null;
            int? yCoord = null;
            while (keepChecking)
            {   
                numString += lines[currentLine][count];
                foreach ((int, int) coordinate in neighbouringCoordinates)
                {
                    try 
                    {
                        if (lines[currentLine + coordinate.Item1][count + coordinate.Item2] == '*')
                        {   
                            xCoord = currentLine + coordinate.Item1;
                            yCoord = count + coordinate.Item2;
                            canBeIncluded = true;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                try 
                {
                    if (!char.IsDigit(lines[currentLine][count +1]))
                    {
                        keepChecking = false;
                        if (canBeIncluded == false)
                        {
                            numString = "";
                        }
                    }
                }
                catch
                {
                    keepChecking = false;
                    if (canBeIncluded == false)
                    {
                        numString = "";
                    }
                }

                if (!keepChecking && canBeIncluded) 
                {
                {   
                    int partNumber = Int32.Parse(numString);
                    if (gears.ContainsKey((xCoord!,yCoord!).ToTuple()))
                        {
                            gears[(xCoord!,yCoord!).ToTuple()].Add(partNumber);
                        } 
                    else
                        {
                            gears.Add((xCoord!,yCoord!).ToTuple(),  new List<int> { partNumber });
                        }
                }
                }
                count ++;
            }
        }
    }
}

int sum = 0; 
foreach(var pair in gears)
{
    if (pair.Value.Count == 2)
    {
        sum += pair.Value[0] * pair.Value[1];
    }
}


Console.WriteLine(sum);