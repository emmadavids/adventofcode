public class Program 
{

    public static List<(int, int)> FindCoordinatesOfGalaxies(List<string> lines)
    {
        List<(int, int)> galaxyCoordinates = new();
        for (int i = 0; i < lines.Count(); i++)
        {
            for (int j = 0; j < lines.Count(); j++)
            {
                if (lines[i][j] == '#')
                {
                    galaxyCoordinates.Add((i,j));
                } 
            }
        }
        return galaxyCoordinates;
    }

    public static List<int> FindHorizontalLinesForExpansion(List<string> lines)
    {
        List<int> horizontalLinesToBeAdded = new();

        for (int i = 0; i < lines.Count(); i ++)
        {
            var galaxyRow = lines[i].ToCharArray().ToList();
            if (!galaxyRow.Contains('#'))
            {   
                horizontalLinesToBeAdded.Add(i);
            }
        }
        return horizontalLinesToBeAdded;
    }

    public static List<int> FindVerticalLinesForExpansion(List<string> lines)
    {   
        List<int> verticalLinesToBeAdded = new();

        foreach (int indx in Enumerable.Range(0, lines[0].Count()))
        {
            if (lines.All(x => x[indx] != '#'))
            {
                verticalLinesToBeAdded.Add(indx);
            }
    }
        return verticalLinesToBeAdded;
    }

    public static long CalculateExtraSteps(List<int> extraLines, 
                                        int coordinateOne,
                                        int coordinateTwo)
    {
        long extraSteps = 0;
        for (int i = 0; i < extraLines.Count(); i++)
        {
            if (extraLines[i] > coordinateOne && extraLines[i] < coordinateTwo
                || extraLines[i] < coordinateOne && extraLines[i] > coordinateTwo)
            {
                extraSteps += 999999;
            }
        }
        return extraSteps;
    }

public static void CalculateOverallSteps(List<int> verticalLinesToBeAdded,
                                        List<int> horizontalLinesToBeAdded,
                                        List<(int, int)> galaxyCoordinates)
{
    var galaxyStepMappings = new List<long>();
    
    for (int i = 0; i < galaxyCoordinates.Count; i++)
    {
        for (int j = i + 1; j < galaxyCoordinates.Count; j++)
        {
            long extraVerticals = CalculateExtraSteps(verticalLinesToBeAdded, galaxyCoordinates[i].Item2, galaxyCoordinates[j].Item2);
            long extraHorizontals = CalculateExtraSteps(horizontalLinesToBeAdded, galaxyCoordinates[i].Item1, galaxyCoordinates[j].Item1);
            long xSteps = Math.Abs(galaxyCoordinates[i].Item1 - galaxyCoordinates[j].Item1) + extraVerticals;
            long ySteps = Math.Abs(galaxyCoordinates[i].Item2 - galaxyCoordinates[j].Item2) + extraHorizontals;
            long totalSteps = xSteps + ySteps;
            galaxyStepMappings.Add(totalSteps);
        }
    }
    long sum = galaxyStepMappings.Sum();
    Console.WriteLine(sum);
}

public static void Main()
{
    List<string> lines = File.ReadLines("full_input.txt").ToList();
    List<(int, int)> galaxyCoordinates = FindCoordinatesOfGalaxies(lines);
    List<int> verticalLines = FindVerticalLinesForExpansion(lines);
    List<int> horizontalLines = FindHorizontalLinesForExpansion(lines);
    CalculateOverallSteps(verticalLines,horizontalLines, galaxyCoordinates);
}
}