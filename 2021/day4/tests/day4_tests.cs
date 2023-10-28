// [Test]
// public void Validate_Board_Structure() {

//   // Arrange
//   var board = new Board();
  
//   board.Cells.Add(new Cell(1, 0, 0));
//   board.Cells.Add(new Cell(2, 1, 0));
  
//   var boards = new List<Board>();
//   boards.Add(board);

//   // Act
//   ValidateBoardStructure(boards);

//   // Assert
//   // Passes as long as no exceptions thrown

//   // Could also check expected output:

//   var output = GetConsoleOutput();
  
//   StringAssert.Contains("1 (0, 0, False)", output);
//   StringAssert.Contains("2 (1, 0, False)", output);
// }

// public void ValidateBoardStructure(List<Board> boards) {

//   foreach (Board board in boards) {

//     Console.WriteLine("board!");

//     foreach (Cell cell in board.Cells) {
//       Console.WriteLine($"{cell.Num} ({cell.X}, {cell.Y}, {cell.Flag})");
//     }
//   }
// } 

// public string GetConsoleOutput() {
//   // Redirect console output to string
// }