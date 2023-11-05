using NUnit.Framework;
using System.Collections.Generic;
using static Program;

[TestFixture]
public class ProgramTests
{
    [Test]
    public void TestOverlap()
    {
        // Arrange
        List<Vent> vents = new List<Vent>(); // Create a list of Vent objects
        Program p = new Program();

        // Act 
        Program.VentUtilities.ProcessInput();

        // Assert
        int overlaps = Program.VentUtilities.GetOverlaps(vents);
        Assert.AreEqual(5, overlaps);
    }
}
