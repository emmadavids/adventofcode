using System.Linq;

public class Program
{  
    static Dictionary<string, int> signalDecoderUnsorted = new Dictionary<string, int>(){
        {"acedgfb", 8},
        {"cdfbe", 5}, 
        {"gcdfa", 2},
        {"fbcad", 3},
        {"dab", 7},
        {"cefabd", 9},
        {"cdfgeb", 6},
        {"eafb", 4},  
        {"cagedb", 0},
        {"ab", 1}
    }; //sort these 
    
    public static string SortChars(string s)
    {
        char[] chars = s.ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }

    static Dictionary<string, int> signalDecoder = new Dictionary<string, int>();

    public static void SortDictionary()
    {
    foreach (KeyValuePair<string, int> pair in signalDecoderUnsorted)
    {
        string sortedKey = SortChars(pair.Key);
        Console.WriteLine($"{sortedKey}, {pair.Value}");
        signalDecoder.Add(sortedKey, pair.Value);
    }
    }

    public static List<string> ParseInput(string text)
    {
        string[] lines = File.ReadAllLines(text);
        List<string> afterDelimiterSegments = new List<string>();
        foreach (string line in lines)
        {   
            string bisectedBit = line.Substring(line.IndexOf("|") + 1);
            afterDelimiterSegments.Add(bisectedBit);
        };
        return afterDelimiterSegments;
    }

    public static void DetectChars(List<string> parsedInput)
    {
        List<int> allDecodedNums = new List<int>();
        foreach (string line in parsedInput)
        {   
            string sortedKey;
            // Console.WriteLine(line);
            var decodedNums = line.Split(" ") 
                                .Where(s => !String.IsNullOrEmpty(s))
                                .Select(s => {
                sortedKey = SortChars(s);
                // Console.WriteLine(sortedKey);
                int value;
                if (signalDecoder.TryGetValue(sortedKey, out value))
                { 
                    Console.WriteLine($"value; {value}");
                    return value;
                }
                else 
                { 
                    Console.WriteLine("fired");
                    return 0;  
                }       
                });
            allDecodedNums.AddRange(decodedNums);
        }
        List<int> decodedList = allDecodedNums.ToList();
        foreach (int num in decodedList) {
        Console.WriteLine(num);  
        
}
    }
        // var summy = allDecodedNums.SelectMany(x => Convert.ToInt32(x)).Sum();
        // Console.WriteLine(summy);
    
    static void Main()
    {
        string filepath = "test_input.txt";
        List<string> parsedInput = ParseInput(filepath);
        SortDictionary();
        DetectChars(parsedInput);
    }
}