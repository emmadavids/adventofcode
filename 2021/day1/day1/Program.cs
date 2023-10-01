
int increasedFromPrevious = 0;
int previous_number = 0;
List<int> numbers = new List<int>();


foreach (string line in File.ReadLines("test_input.txt"))
{   
    numbers.Add(int.Parse(line));
}

for (int i = 1; i < numbers.Count -1; i++)
{
    int sum = numbers[i] + numbers[i-1] + numbers[i+1];
    Console.WriteLine(sum);
    if (sum > previous_number)
    {   
        Console.WriteLine("increased!");
        increasedFromPrevious ++;
    }
    previous_number = sum;
}

Console.WriteLine(increasedFromPrevious -1);   
