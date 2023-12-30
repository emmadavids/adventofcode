public static void CalculateOverallSteps(List<int> verticalLinesToBeAdded,
                                         List<int> horizontalLinesToBeAdded,
                                         List<(int, int)> galaxyCoordinates)
{
    var galaxyStepMappings = new List<int>();
    
    for (int i = 0; i < galaxyCoordinates.Count; i++)
    {
        for (int j = i + 1; j < galaxyCoordinates.Count; j++)
        {
            int extraVerticals = CalculateExtraSteps(verticalLinesToBeAdded, galaxyCoordinates[i].Item1, galaxyCoordinates[j].Item1);
            int extraHorizontals = CalculateExtraSteps(horizontalLinesToBeAdded, galaxyCoordinates[i].Item2, galaxyCoordinates[j].Item2);
            int xSteps = Math.Abs(galaxyCoordinates[i].Item1 - galaxyCoordinates[j].Item1) + extraVerticals;
            int ySteps = Math.Abs(galaxyCoordinates[i].Item2 - galaxyCoordinates[j].Item2) + extraHorizontals;
            int totalSteps = xSteps + ySteps;
            galaxyStepMappings.Add(totalSteps);
        }
    }
    int sum = galaxyStepMappings.Sum();
    Console.WriteLine(sum);
}

