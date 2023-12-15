    

List<string> lines = File.ReadLines("full_input.txt").ToList();
List<int> histories = new List<int>();
List<int> moreHistories = new List<int>();  

foreach (string line in lines)
{
    List<string> oasisValues = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
    List<List<int>> sequences = new List<List<int>>();
    List<int> currentList = oasisValues.Select(int.Parse).ToList();
    sequences.Add(currentList);

    int difference;
    bool notZero = true;

    while (notZero)  
    {  
        List<int> sequence = new List<int>();
        for (int i = 0; i < currentList.Count; i++)
        {
            try {
                int num = currentList[i];
                int adjNum = currentList[i+1];
                difference = adjNum - num;
                sequence.Add(difference);
            }
            catch {
                break;
            }
        }
        if (currentList.All(num => num == 0))
        {
            notZero = false;
        }
        currentList = sequence;
        sequences.Add(sequence);
       
    }
    int sum = 0;
   
    foreach (List<int> seque in sequences)
    {
        sum += seque.Last();
    }

    histories.Add(sum);
    }

Console.WriteLine(histories.Sum());