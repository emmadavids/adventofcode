using System;
using System.Runtime.CompilerServices;

public class Program
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Num { get; set; }
        public bool Flag { get; set; }
        public Cell(int num, int x, int y)
        {
            Num = num;
            X = x;
            Y = y;
            Flag = false;
        }
    }
    public class Board
    {
        public List<Cell> Cells { get; set; }
        public Board()
        {
            Cells = new List<Cell>();
        }
    }

    public static void ProcessBingoCallsAndBoard(List<Board> boards, int[] bingoCalls)
    {
        List<Cell> Temporary_holding_board = new();
        List<string> lines = File.ReadLines("text_input.txt").ToList();
        int row = 0;
        int col = 0;
        bool firstIteration = true;
        int linesProcessed = 1;
        foreach (string line in lines)
        {   
            if (line.Contains(",")) //ignore bingo calls these have been processsed
            {
                continue;
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {   
                string[] numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string numberStr in numbers)
                {
                    if (!string.IsNullOrEmpty(numberStr))
                    {
                        int number = int.Parse(numberStr);
                        // Console.WriteLine($"adding cell number {number} at: {col}, {row}");
                        Cell cell = new Cell(number, col, row);
                        Temporary_holding_board.Add(cell);
                        col++;
                    }
                }
                row++;
                col = 0;
            }
            else if (string.IsNullOrWhiteSpace(line) || linesProcessed == lines.Count)
            {   
                if (!firstIteration)
                {
                row = 0;
                boards.Add(new Board { Cells = Temporary_holding_board });
                Temporary_holding_board = new List<Cell>();
                //push board to boards, reset temporary_holding_board 
                }
                else 
                {
                    firstIteration = false;
                }
            }
            linesProcessed++;
        }
    }

    public static Board winningBoard;
    public static int lastCalledNumber = 0;
    public static void YellNumbers(List<Board> boards, int[] bingoCalls)
    {
        foreach (int call in bingoCalls)
        {
            lastCalledNumber = call;
            MarkNumber(boards, call);
            if (winningBoard != null)
                continue;

            (Board wonBoard, bool won, IGrouping<int, Cell> winningRow) = CheckWin(boards);

            if (won)
            {
                winningBoard = wonBoard;
                CalculateWinningScore(winningBoard, winningRow);
                break;
            }
        }
    }

    public static void CheckBoardsPopulatedCorrectly(List<Board> boards)
    {
        foreach (Board board in boards)
        {   Console.WriteLine("board!");
            foreach (Cell cell in board.Cells)
            {
                Console.WriteLine($"{cell.Num} ({cell.X}, {cell.Y}, {cell.Flag})");
            }
        }
    }
    public static void MarkNumber(List<Board> boards, int call)
    {
        foreach (Board board in boards)
        {
            foreach (Cell cell in board.Cells)
            {
                if (call == cell.Num)
                {
                    cell.Flag = true;
                    Console.WriteLine($"Marked cell number {cell.Num} at ({cell.X}, {cell.Y})");
                }
            }
        }
    }

    public static (Board, bool, IGrouping<int,Cell>?) CheckWin(List<Board> boards)
    {
        foreach (Board board in boards)
        {
            if (board.Cells.Count == 0)
            {
                continue;
            }
            
            var horizontalGroup = board.Cells
                .GroupBy(c => c.Y)
                .FirstOrDefault(g => g
                .Count()==5 && g
                .All(c => c.Flag));

            if (horizontalGroup is not null)
            {
                Console.WriteLine("We have a horizontal bingo!");
                Console.WriteLine(horizontalGroup.Count());
                return (board, true, horizontalGroup);
            }

            var verticalGroup = board.Cells
                .GroupBy(c => c.X)
                .FirstOrDefault(g => g
                .Count()==5 && g
                .All(c => c.Flag));
            
            if (verticalGroup is not null)    
            {
                Console.WriteLine("returning a row bingo");
                return (board, true, verticalGroup);
            }

            var forwardDiagonal = board.Cells.Where(c => c.X == c.Y);

            if (forwardDiagonal.Count() == 5 && forwardDiagonal.All(c => c.Flag)) 
            {   
                IGrouping<int, Cell> forwardGroup = forwardDiagonal.GroupBy(_ => 1).First(); 
                return (board, true, forwardGroup);
            }

            var backwardDiagonal = board.Cells.Where(c => c.X + c.Y == 4);

            if (backwardDiagonal.Count() == 5 && backwardDiagonal.All(c => c.Flag))
            {
                IGrouping<int, Cell> backwardGroup = backwardDiagonal.GroupBy(_ => 1).First();
                return (board, true, backwardGroup);
            }
            }
            return (new Board(), false, null);
        }

    public static int CalculateWinningScore(Board board, IGrouping<int,Cell> winningRow)
    {
        int winningNum = winningRow.Sum(c => c.Num);
        int losingNum = board.Cells.Where(c => !c.Flag).Sum(c => c.Num);
        Console.WriteLine($"winning row: {string.Join(", ", winningRow.Select(c => c.Num))}");
        Console.WriteLine($"Losing numbers: {string.Join(", ", board.Cells.Where(c => !c.Flag).Select(c => c.Num))}");
        Console.WriteLine("Winning Numbers Count: " + board.Cells.Count(c => c.Flag));
        Console.WriteLine("Losing Numbers Count: " + board.Cells.Count(c => !c.Flag));
        Console.WriteLine($"Final result: {winningNum * losingNum}");
        return lastCalledNumber * losingNum;
    }

    public static void Main()
    {
        List<Board> boards = new();
        int[] bingoCalls;
        string[] lines = File.ReadAllLines("text_input.txt");
        string[] bingoCallsStr = lines[0].Split(',');
        bingoCalls = bingoCallsStr.Select(int.Parse).ToArray();
        ProcessBingoCallsAndBoard(boards, bingoCalls);
        CheckBoardsPopulatedCorrectly(boards);
        YellNumbers(boards, bingoCalls);
        Console.WriteLine("Number of Boards: " + boards.Count);
    }
}