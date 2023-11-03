using System;
using Xunit;

public class ProgramTests
{
    [Fact]
    public void TestOverlap()
    {
        // Arrange
        Program p = new Program();

        // Act
        p.ProcessInput();

        // Assert
        int overlaps = Program.GetOverlaps();
        Assert.Equal(5, overlaps);
    }
}
