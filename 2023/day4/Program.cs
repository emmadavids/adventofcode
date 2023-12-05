
// List<string> lines = File.ReadLines("test_input.txt").ToList();
// List<Tuple<List<string>, List<string>>> games = new List<Tuple<List<string>, List<string>>>(); 
// Dictionary<int,int> scratchCardCopies = new Dictionary<int, int>{};


// foreach (string line in lines)
// {
//     List<string> splitLine = line.Split("|").ToList();
//     List<string> scratchcard = splitLine[0].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
//     List<string> elfNumbers = splitLine[1].Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
//     Tuple<List<string>, List<string>> elfGame = Tuple.Create(scratchcard, elfNumbers);
//     games.Add(elfGame);
// }


// for (int i = 0; i < games.Count; i++)
// {
//     scratchCardCopies.Add(i + 1, 1);
// }

// for (int i = 0; i < games.Count; i++)
// {
//     int matchingNums = 0;
//     foreach(var num in games[i].Item2)
//     {   
//         if (games[i].Item1.Contains(num))
//         {   
//             matchingNums ++; 
//         }
//     }

//     Console.WriteLine($"matching nums: {matchingNums}");
//     // int cardNumber = i + 2;
//     while (matchingNums != 0)
//     {   

//         foreach(var pair in scratchCardCopies)
//         {
//             Console.WriteLine($"key {pair.Key} value {pair.Value}");
//         }

//         Console.WriteLine($"card number {i + matchingNums +1 }");
//         if (scratchCardCopies.ContainsKey(i + matchingNums +1 ))
//         {
//             scratchCardCopies[i + matchingNums +1 ] = 2 * scratchCardCopies[i + matchingNums +1 ];
//         }
//         // cardNumber += 1;
//         matchingNums -= 1;
//     }
// } 

// int sum = 0;
// foreach(var pair in scratchCardCopies)
// {
//     Console.WriteLine($"key {pair.Key} value {pair.Value}");
//     sum += pair.Value;
// }

// Console.WriteLine(sum);
//2 cards for every overlapping, 1 card for non overlapping
List<string> lines = File.ReadLines("test_input.txt").ToList();
List<Tuple<List<string>, List<string>>> games = new List<Tuple<List<string>, List<string>>>();
Dictionary<int, int> scratchCardCopies = new Dictionary<int, int> { };

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
    int matchingNums = 0;
    foreach (var num in games[i].Item2)
    {
        if (games[i].Item1.Contains(num))
        {
            matchingNums++;
        }
    }

    Console.WriteLine($"matching nums: {matchingNums}");

    // Count of overlapping numbers
    int overlappingNums = 0;

    // Check for overlapping numbers with the next cards in the sequence
    for (int j = i + 1; j < games.Count; j++)
    {
        foreach (var num in games[j].Item2)
        {
            if (games[i].Item1.Contains(num))
            {
                overlappingNums++;
            }
        }
    }

    while (matchingNums != 0)
    {
        Console.WriteLine($"card number {i + matchingNums + 1}");

        // Modify the condition based on your logic
        if (overlappingNums == matchingNums)
        {
            // Double the value if all matching numbers are still overlapping
            if (scratchCardCopies.ContainsKey(i + matchingNums + 1))
            {
                scratchCardCopies[i + matchingNums + 1] = 2 * scratchCardCopies[i + matchingNums + 1];
            }
            else
            {
                scratchCardCopies.Add(i + matchingNums + 1, 1);
            }
        }
        else
        {
            // Subtract the number of non-overlapping numbers
            int nonOverlappingNums = matchingNums - overlappingNums;
            if (scratchCardCopies.ContainsKey(i + matchingNums + 1))
            {
                scratchCardCopies[i + matchingNums + 1] += scratchCardCopies[i + matchingNums + 1] - nonOverlappingNums;
            }
            else
            {
                scratchCardCopies.Add(i + matchingNums + 1, matchingNums - nonOverlappingNums);
            }
        }

        matchingNums -= 1;
    }
}

int sum = 0;
foreach (var pair in scratchCardCopies)
{
    Console.WriteLine($"key {pair.Key} value {pair.Value}");
    sum += pair.Value;
}

Console.WriteLine(sum);
