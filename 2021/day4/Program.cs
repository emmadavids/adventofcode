using System;

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
        List<Cell> Temporary_holding_board = new List<Cell>();
        List<string> lines = File.ReadLines("text_input.txt").ToList();
        int row = 0; 
        int col = 0;
        foreach (string line in lines)
        {
            if (line.Contains(",")) //ignore bingo calls these have been processsed
            {
                continue;
            }

            else if (string.IsNullOrWhiteSpace(line))
            {   Console.WriteLine("fired");
                boards.Add(new Board { Cells = Temporary_holding_board });
                Temporary_holding_board = new List<Cell>();
                //push board to boards, reset temporary_holding_board 
            }
        
            else
            {
                string[] numbers = line.Split(" ");
                foreach (string numberStr in numbers)
                {   if(!string.IsNullOrEmpty(numberStr))
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
        }
    }

    public static void YellNumbers(List<Board> boards, int[] bingoCalls)
    {
        foreach (int call in bingoCalls)
        {
            Console.WriteLine($"Announcing Bingo Call: {call}");
            MarkNumber(boards, call);
            (Board winningBoard, bool won) = CheckWin(boards);

            if (won)
            {
                CalculateWinningScore(winningBoard);
                break; // Exit the loop if a winning board is found
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
                    Console.WriteLine($"Marked cell ({cell.X}, {cell.Y}) with number {cell.Num} as flagged.");
                }
            }
        }
    }

    public static (Board, bool) CheckWin(List<Board> boards)
    {
        foreach (Board board in boards)
        {   //board.cells is a list of classes
            //groups by y axis, gets any of those groups where all are flagged 
            if (board.Cells.GroupBy(c => c.Y)
                .Any(g => g.All(c => c.Flag)))
            {
                Console.WriteLine("returning board prematurely");
                return (board, true);
            }
            //same but for x axis
            if (board.Cells.GroupBy(c => c.X)
                .Any(g => g.All(cell => cell.Flag)))
            {
                Console.WriteLine("returning board prematurely 2");
                return (board, true);
            }
            // if (board.Cells.Where(c => c.X == c.Y)
            //     .All(c => c.Flag))
            // {   
            //     Console.WriteLine("returning board prematurely 3");
            //     return (board, true);
            // }
            // if (board.Cells.Where(c => c.X + c.Y == 5 - 1)
            //     .All(c => c.Flag))
            // {
            //     Console.WriteLine("returning board prematurely 4");
            //     return (board, true);
            // }
            return (new Board(), false);
        }
        return (new Board(), false);
    }

    public static int CalculateWinningScore(Board board)
    {
        int winningNum = board.Cells.Where(c => c.Flag).Sum(c => c.Num);
        int losingNum = board.Cells.Where(c => !c.Flag).Sum(c => c.Num);
        Console.WriteLine($"Winning numbers: {string.Join(", ", board.Cells.Where(c => c.Flag).Select(c => c.Num))}");
        Console.WriteLine($"Losing numbers: {string.Join(", ", board.Cells.Where(c => !c.Flag).Select(c => c.Num))}");
        Console.WriteLine("Winning Numbers Count: " + board.Cells.Count(c => c.Flag));
        Console.WriteLine("Losing Numbers Count: " + board.Cells.Count(c => !c.Flag));
        Console.WriteLine($"Final result: {winningNum * losingNum}");

        return winningNum * losingNum;
    }

    public static void Main()
    {
        List<Board> boards = new List<Board>();
        int[] bingoCalls;
        string[] lines = File.ReadAllLines("text_input.txt");
        string[] bingoCallsStr = lines[0].Split(',');
        bingoCalls = bingoCallsStr.Select(int.Parse).ToArray();

        ProcessBingoCallsAndBoard(boards, bingoCalls);
        // MarkNumber(boards, bingoCalls);
        // (Board winningBoard, bool won) = CheckWin(boards);
        YellNumbers(boards, bingoCalls);
        Console.WriteLine("Number of Boards: " + boards.Count);
    }
}

