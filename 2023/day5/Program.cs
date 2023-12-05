using System.Linq;

List<string> lines = File.ReadLines("test_input.txt").ToList();
List<long> locationNums = new List<long>();

List<long> seeds = new List<long>();
Dictionary<string, long> seedDictionary = new Dictionary<string, long>();

foreach (string line in lines)
{
    List<string> splitLine = line.Split(" ").ToList();
    if (splitLine[0] == "seeds:")
    {
        for (int i = 1; i < splitLine.Count; i++)
        {
            long seed = long.Parse(splitLine[i]);
            seeds.Add(seed);   
        }
    }
    break;
}
string currentResource = "";
foreach (long seed in seeds)
{
    long currentSeed;
    long seedNumber = seed; 
    for (int i = 0; i < lines.Count; i++)
    {   
        currentSeed = seedNumber;
        List<string> sgmnt = lines[i].Trim().Split(" ").ToList();
    
        if (sgmnt[0] == "seeds:")
        {
            continue;
        }

        if (!String.IsNullOrWhiteSpace(sgmnt[0]))
        {   
            if (Char.IsLetter(sgmnt[0][0])) 
            {
                List<string> header = sgmnt[0].Split("-").ToList();
                currentResource = header[0];
                seedDictionary.Add(currentResource, long.MaxValue);
            }
        
        if (!Char.IsLetter(sgmnt[0][0])) 
        {
            long source = long.Parse(sgmnt[1]);
            long soilRange = long.Parse(sgmnt[2]) ;

        if (currentSeed >= source - soilRange && currentSeed <= source + soilRange) 
        {
            long diff = Math.Abs(currentSeed-source);
            long destination = long.Parse(sgmnt[0]);
            seedNumber = destination + diff;
            if (seedDictionary.ContainsKey(currentResource) && seedDictionary[currentResource] > seedNumber)
            {
                seedDictionary[currentResource] = seedNumber;
                // Console.WriteLine("seed number" + seedNumber);
            }
        else seedDictionary[currentResource] = currentSeed;}
        }}
    }
    foreach (var pair in seedDictionary)
        {   
            Console.WriteLine($"Resource: {pair.Key}, SeedNumber: {pair.Value}");
            locationNums.Add(pair.Value);
        }
    seedDictionary.Clear();
}

Console.WriteLine(locationNums.Min());

