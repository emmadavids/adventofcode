List<int> winningGameIds = new List<int>();
List<int> allPowers = new List<int>();
int redCubes = 12;
int greenCubes = 13;
int blueCubes = 14;

Dictionary<string, int> cubeColours = new Dictionary<string, int>
{
    {"red", 0},
    {"blue", 0},
    {"green", 0}
};

List<string> lines = File.ReadLines("full_input.txt").ToList();

foreach(string line in lines)
{
    List<string> game = line.Split(" ").ToList();
    for (int i = 0; i < game.Count; i++)
    {   
        string colourKey; 
        if (game[i].EndsWith(",") || game[i].EndsWith(";"))
        {
            colourKey = game[i].Remove(game[i].Length-1, 1);
        }
        else 
        {
            colourKey = game[i];
        }
        if (cubeColours.ContainsKey(colourKey))
        {   
            var num = Int32.Parse(game[i-1]);
            if (cubeColours[colourKey] < num)
            {
                cubeColours[colourKey] = num; 
            };
        }
    }
    if (cubeColours["red"] <= redCubes &&
        cubeColours["blue"] <= blueCubes &&
        cubeColours["green"] <= greenCubes)
    {
        int winningId = Int32.Parse(game[1].Remove(game[1].Length-1, 1));
        winningGameIds.Add(winningId);
    }
    int sum = 0; 
    foreach (var key in cubeColours.Keys.ToList())
    {
        if (sum == 0)
        { 
            sum =+ cubeColours[key];
        }
        else
        {
            sum = sum * cubeColours[key];
        }
        cubeColours[key] = 0;
    }
    allPowers.Add(sum);
}

Console.WriteLine(winningGameIds.Sum());
Console.WriteLine(allPowers.Sum());
