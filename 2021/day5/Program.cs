
public class Program 
{
List<string> lines = File.ReadLines("test_input.txt");
public List<Vent> Vents = new();
public class Vent 
{
    public int X { get; set; }
    public int Y {get; set; }
    public int hasBeenTouched {get; set;}  
    public Vent(int x, int y)
    {
        X = x;
        Y = y;
    }
}
public static void ProcessInput()
{
foreach (string line in lines)
{
    int x_axis1 = Convert.ToInt32(line[0]);
    int y_axis1 = Convert.ToInt32(line[2]);
    int x_axis2 = Convert.ToInt32(line[7]);
    int y_axis2 = Convert.ToInt32(line[9]);
    if (y_axis1 == y_axis2) 
    {
        int start = Math.Min(x_axis1, x_axis2);
        int end = Math.Max(x_axis1, x_axis2);
        
        for (int x = start; x <= end; x++)
        {
            Vent vent = Vents.Find(v => v.X == x && v.Y == y_axis1);
            if (vent != null)
            {
                vent.hasBeenTouched ++;
            }
            else
            {
                Vent vent = new Vent(x, y_axis1);
                Vents.Add(vent);
            }
        }
    }
    else if (x_axis1 == x_axis2)
    {
        int start = Math.Min(y_axis1, y_axis2);
        int end = Math.Max(y_axis1, y_axis2);

        for (int y = start; y <= end; y++)
        {
            Vent vent = vents.Find(v => v.X == x_axis1 && v.Y == y);
            if (vent != null)
            {
                vent.hasBeenTouched ++;
            }
            else 
            {
                Vent vent = new Vent(x_axis1, y);
                Vents.Add(vent);                
            }
        }
    }
}

}
public static void Main() 
{
    ProcessInput();
}
}