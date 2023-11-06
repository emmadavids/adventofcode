using NUnit.Framework;
using System.Collections.Generic;
using static Program;

[TestFixture]
public class ProgramTests
{
    // [Test]
    // public void TestOverlap()
    // {
    //     // Arrange
    //     List<Vent> vents = new List<Vent>(); // Create a list of Vent objects
    //     Program p = new Program();

    //     // Act 
    //     Program.VentUtilities.ProcessInput();

    //     // Assert
    //     int overlaps = Program.VentUtilities.GetOverlaps(vents);
    //     Assert.AreEqual(5, overlaps);
    // }
[Test]
public void VentConstructor_SetsCoordinates() {
    Vent vent = new Vent(10, 20);
    
    Assert.AreEqual(10, vent.X);
    Assert.AreEqual(20, vent.Y);
}

[Test]
    public void TestProcessInput_HorizontalLine()
    {
        // Arrange
        List<string> lines = new List<string>
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4"
        };

        Program.VentUtilities.ProcessInput(lines);

        foreach (Program.Vent vent in Program.vents)
        {
            if (vent.X >= 0 && vent.X <= 5 && vent.Y == 9)
            {
                Assert.AreEqual(1, vent.hasBeenTouched);
            }
        }
    }

[Test]
    public void TestProcessInput_VerticalLine()
    {
        List<string> lines = new List<string>
        {
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0"
        };

        Program.VentUtilities.ProcessInput(lines);

        foreach (Program.Vent vent in Program.vents)
        {
            if (vent.X == 2 && vent.Y >= 0 && vent.Y <= 4)
            {
                Assert.AreEqual(1, vent.hasBeenTouched);
            }
        }
    }

[Test]
    public void ProcessInput_SetsCorrectAmountOfVents() 
    {
        List<string> lines = new List<string>
        {
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0"
        }; 
        Program.VentUtilities.ProcessInput(lines);
        Assert.AreEqual(7, Program.vents.Count);
    
    }
    }
