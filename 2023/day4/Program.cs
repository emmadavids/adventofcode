
List<string> lines = File.ReadLines("full_input.txt").ToList();
List<Tuple<List<string>, List<string>>> games = new List<Tuple<List<string>, List<string>>>(); 
Dictionary<int,int> scratchCardCopies = new Dictionary<int, int>{};

foreach (string line in lines)
{
    List<string> splitLine = line.Split("|").ToList();
    List<string> scratchcard = splitLine[0].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
    List<string> elfNumbers = splitLine[1].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
    Tuple<List<string>, List<string>> elfGame = Tuple.Create(scratchcard, elfNumbers);
    games.Add(elfGame);
}

for (int i = 0; i < games.Count; i++)
{
    scratchCardCopies.Add(i + 1, 1);
}

for (int i = 0; i < games.Count; i++)
{
    int toRepeat = 0;
    string gameKey = games[i].Item1[1].Trim(':');
    toRepeat = scratchCardCopies[Int32.Parse(gameKey)];
    while (toRepeat > 0)
    {
    int matchingNums = 0;
    foreach(var num in games[i].Item2)
    {   
        if (games[i].Item1.Contains(num))
        {   
            matchingNums ++; //checks if the scratchcard has the numbers and increments  
        }
    }

    Console.WriteLine($"matching nums: {matchingNums}");

    //adds an extra card for each subsequent card
    while (matchingNums != 0)
    {   
        Console.WriteLine($"card number {i + matchingNums +1 }");
        if (scratchCardCopies.ContainsKey(i + matchingNums +1 ))
        {
            scratchCardCopies[i + matchingNums +1 ] += 1;
        }
        matchingNums -= 1;
    }
    toRepeat --;
    }
} 

int sum = 0;
foreach(var pair in scratchCardCopies)
{
    Console.WriteLine($"key {pair.Key} value {pair.Value}");
    sum += pair.Value;
}

Console.WriteLine(sum);

