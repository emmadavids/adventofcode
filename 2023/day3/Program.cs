List<string> lines = File.ReadLines("full_input.txt").ToList();

List<char> symbols = new List<char>()
    {
        '*', '#', '+', '$', '&', '%', '@', '=', '/', '-'
    };

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
    // Console.WriteLine(lines[currentLine]);
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
            // Console.WriteLine(lines[currentLine][i]);
            int count = i; 
            bool keepChecking = true; 
            bool canBeIncluded = false;

            while (keepChecking)
            {   
                numString += lines[currentLine][count];
                foreach ((int, int) coordinate in neighbouringCoordinates)
                {
                    try 
                    {
                        if (symbols.Contains(lines[currentLine + coordinate.Item1][count + coordinate.Item2]))
                        {
                            canBeIncluded = true;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                try{
                if (!char.IsDigit(lines[currentLine][count +1]))
                {
                    keepChecking = false;
                    if (canBeIncluded == false)
                    {
                        numString = "";
                    }
                }}
            
            catch
            {
                keepChecking = false;
                if (canBeIncluded == false)
                    {
                        numString = "";
                    }
            }
                count ++;
            }
        }
        if (numString != "")
        {   
            int partNumber = Int32.Parse(numString);
            partNumbers.Add(partNumber);
        }
        }
    }

    Console.WriteLine(partNumbers.Sum());

