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
            if (line.Contains(",")) 
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

    public static int lastCalledNumber = 0;
    public static void YellNumbers(List<Board> boards, int[] bingoCalls, List<Board> bingoBoards, int numOfBoards)
    {
        foreach (int call in bingoCalls)
        {   
            if (numOfBoards == 0)
            {
                return;
            }
            lastCalledNumber = call;
            MarkNumber(boards, call);
            
            // if (winningBoard != null)
            //     continue;

            (Board wonBoard, bool won) = CheckWin(boards, bingoBoards, numOfBoards);
            if (won)
            {   
                Console.WriteLine(numOfBoards);
                boards.Remove(wonBoard);
                numOfBoards--;
            }
        }
    }

    // public static void CheckBoardsPopulatedCorrectly(List<Board> boards)
    // {
    //     foreach (Board board in boards)
    //     {   Console.WriteLine("board!");
    //         foreach (Cell cell in board.Cells)
    //         {
    //             Console.WriteLine($"{cell.Num} ({cell.X}, {cell.Y}, {cell.Flag})");
    //         }
    //     }
    // }
    public static void MarkNumber(List<Board> boards, int call)
    {
        foreach (Board board in boards)
        {
            foreach (Cell cell in board.Cells)
            {
                if (call == cell.Num)
                {
                    cell.Flag = true;
                    // Console.WriteLine($"Marked cell number {cell.Num} at ({cell.X}, {cell.Y})");
                }
            }
        }
    }

    public static (Board, bool) CheckWin(List<Board> boards, List<Board> bingoBoards, int numOfBoards)
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
                .Count() == 5 && g
                .All(c => c.Flag));

            if (horizontalGroup is not null)
            {
                Console.WriteLine("horizontal win");
                bingoBoards.Add(board);
                return (board, true);
            }

            var verticalGroup = board.Cells
                .GroupBy(c => c.X)
                .FirstOrDefault(g => g
                .Count() == 5 && g
                .All(c => c.Flag));
            
            if (verticalGroup is not null)    
            {   
                Console.WriteLine("vertical win");
                bingoBoards.Add(board);
                return (board, true);
            }
        }
            return (new Board(), false);
        }

    public static int CalculateWinningScore(Board board)
    {
        int losingNum = board.Cells.Where(c => !c.Flag).Sum(c => c.Num);
        Console.WriteLine($"losing num: {losingNum}");
        Console.WriteLine($"Losing numbers: {string.Join(", ", board.Cells.Where(c => !c.Flag).Select(c => c.Num))}");
        Console.WriteLine("Winning Numbers Count: " + board.Cells.Count(c => c.Flag));
        Console.WriteLine("Losing Numbers Count: " + board.Cells.Count(c => !c.Flag));
        Console.WriteLine($"Last called number is {lastCalledNumber}");
        Console.WriteLine($"Final result: {losingNum * lastCalledNumber}");
        return lastCalledNumber * losingNum;
    }

    public static void Main()
    {
        List<Board> boards = new();
        List<Board> bingoBoards = new();
        int[] bingoCalls;
        string[] lines = File.ReadAllLines("text_input.txt");
        string[] bingoCallsStr = lines[0].Split(',');
        bingoCalls = bingoCallsStr.Select(int.Parse).ToArray();
        ProcessBingoCallsAndBoard(boards, bingoCalls);
        int numOfBoards = boards.Count();
        Console.WriteLine($"number of boards {numOfBoards}");
        YellNumbers(boards, bingoCalls, bingoBoards, numOfBoards);
        // CheckBoardsPopulatedCorrectly(bingoBoards);
        Board lastWin = bingoBoards.Last();
        CalculateWinningScore(lastWin);
        foreach (Cell cell in lastWin.Cells)
        {
            Console.WriteLine($"last win: {cell.Num} ({cell.X}, {cell.Y}, {cell.Flag})");
        }
    }
}