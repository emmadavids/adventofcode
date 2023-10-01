using System.Linq;

List<int> gamma_bits = new List<int>();
List<int> epsilon_bits = new List<int>();
List<string> lines = File.ReadLines("test_input.txt").ToList();
// List<int> oxygenGeneratorRatings = lines.Select(l => Convert.ToInt32(l, 2)).ToList();
// List<int> co2ScrubberRatings = lines.Select(l => Convert.ToInt32(l, 2)).ToList();
List<string> oxygenGeneratorRatings = lines.ToList();
List<string> co2ScrubberRatings = lines.ToList();

int maxLength = lines.Max(l => l.Length); 

for (int i = 0; i < maxLength; i++)
{
    int columnZeroes = 0;
    int columnOnes = 0;
    
    foreach (string line in lines)
    {   
        if (i < line.Length)
        {
            int num = int.Parse(line[i].ToString());

            if (num == 0)
            {
                columnZeroes++;
            }
            else if (num == 1)
            {
                columnOnes++;
            }
        }
    }
    if (columnZeroes > columnOnes)
    {
        gamma_bits.Add(0);
        epsilon_bits.Add(1);
    }
    else
    {   
        gamma_bits.Add(1);
        epsilon_bits.Add(0);
    }

    char mostUsedBit = columnZeroes > columnOnes ? '0' : '1';
    if (oxygenGeneratorRatings.Count > 1){
        oxygenGeneratorRatings.RemoveAll(x => x.ToString()[i] !=mostUsedBit);
    }
    if (co2ScrubberRatings.Count >1){
        co2ScrubberRatings.RemoveAll(x=>x.ToString()[i]!=mostUsedBit);
    }
}

string gamma_string = string.Join("", gamma_bits);
int gamma_decimal = Convert.ToInt32(gamma_string, 2);

string epsilon_string = string.Join("", epsilon_bits);
int epsilon_decimal = Convert.ToInt32(epsilon_string, 2);

int oxygen_decimal = Convert.ToInt32(oxygenGeneratorRatings[0], 2);
int co2_decimal = Convert.ToInt32(co2ScrubberRatings[0], 2);
Console.WriteLine(oxygen_decimal*co2_decimal);
Console.WriteLine(gamma_decimal * epsilon_decimal);
