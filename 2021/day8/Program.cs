using System.Linq;

public class Program
{   
    static Dictionary<string, string> signalDecoderUnsorted = new Dictionary<string, string>(){
        {"acedgfb", "8"},
        {"cdfbe", "5"}, 
        {"gcdfa", "2"},
        {"fbcad", "3"},
        {"dab", "7"},
        {"cefabd", "9"},
        {"cdfgeb", "6"},
        {"eafb", "4"},  
        {"cagedb", "0"},
        {"ab", "1"}
    };
    public static string SortChars(string s)
    {
        char[] chars = s.ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }

    static Dictionary<string, string> signalDecoder = new Dictionary<string, string>();

    public static void SortDictionary()
    {
    foreach (KeyValuePair<string, string> pair in signalDecoderUnsorted)
        {
            string sortedKey = SortChars(pair.Key);
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
            string lineNum = "";
            var decodedNums = line.Split(" ") 
                            .Where(s => !String.IsNullOrEmpty(s));

            foreach(string splitNum in decodedNums)
            {
                string sortedKey = SortChars(splitNum);
                if (signalDecoder.ContainsKey(sortedKey))
                { 
                    lineNum += signalDecoder[sortedKey];
                }    
                else if (splitNum.Length == 2) 
                {
                    lineNum += 1;
                }
                else if (splitNum.Length ==3)
                {
                    lineNum +=7;
                }
                else if (splitNum.Length ==4)
                {
                    lineNum +=4;
                }
            }
        try
        {
            int decodedInts = Int32.Parse(lineNum);
            allDecodedNums.Add(decodedInts);
        }
        catch 
        {
            continue;
        }
        }

        foreach (int num in allDecodedNums) 
        {
            Console.WriteLine(num);  
        }
    }    
    static void Main()
    {   
        string filepath = "test_input.txt";
        List<string> parsedInput = ParseInput(filepath);
        SortDictionary();
        DetectChars(parsedInput);
    }
}