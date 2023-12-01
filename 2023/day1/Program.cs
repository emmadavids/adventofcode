

List<string> lines = File.ReadLines("full_input.txt").ToList();
List<int> numbers = new List<int>();

Dictionary<string, string> wordNums = new Dictionary<string, string>
            {
            {"one", "1"},
            {"two", "2"},
            {"three","3"}, 
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9" }};

foreach(string line in lines)
{   
    string num = "";
    for (int i = 0; i < line.Length; i++)
    {   
        foreach (var (key,value) in wordNums)
        {   
            try{  
            if (line.Substring(i, key.Length) == key)
            {

                num += value;
            }}
            catch {
                continue;
            }
        }
        if (Char.IsDigit(line[i]))
        {
            num += line[i];
        }
    }
    if (num.Length > 2)
    {   
        num = (char)num[0] + num.Substring(num.Length - 1);
    }
    else if (num.Length == 1)
    {
        num = num + num;
    }
    try{
    var intNum = Int32.Parse(num);
    numbers.Add(intNum);
    // Console.WriteLine(num);
    }
    catch { continue ;}
}

Console.WriteLine(numbers.Sum());