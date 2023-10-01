
int horizontal_position = 0;
int depth = 0;
int aim = 0;

foreach (string line in File.ReadLines("full_input.txt"))
{   
    string[] instruction = line.Split(' ');
    int distance = int.Parse(instruction[1]);
    switch (instruction[0]) 
        {
        case "forward":
            horizontal_position += distance;
            depth += aim * distance;
            break;
        case "down":
            aim += distance;
            break;
        case "up":
            aim -= distance;
            break;
        }
}

Console.WriteLine(horizontal_position * depth);