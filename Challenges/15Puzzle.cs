new FifteenPuzzleGame().Run();

public class FifteenPuzzleGame
{
    public void Run()
    {
        Board board = new Board();
        PlayerInput input = new PlayerInput();
        BoardRenderer renderer = new BoardRenderer();

        Randomize(board);

        while (!board.IsOver)
        {
            renderer.Render(board);
            Direction toMove = input.GetMove();
            board.Move(toMove);
        }
    }

    private static void Randomize(Board board)
    {
        Random random = new Random();
        for (int iteration = 0; iteration < 1000; iteration++)
        {
            Direction toMove = (Direction)random.Next(4);
            board.Move(toMove);
        }    
    }
}

public class BoardRenderer
{
    public void Render(Board board)
    {
        Console.Clear();
        for (int row = 0; row < 4; row++)
        {
            for (int column = 0; column < 4; column++)
                if (board.GetSquare(row, column) == 16)
                    Console.Write("   ");
            else
                Console.Write($"{board.GetSquare(row, column):00} ");

            Console.WriteLine();
        }
    }
}
public class Board
{
    private int[,] _squares; //numbers 1 through 15, and 16 is open slot
                             // [Row, Column]
    public Board()
    {
        _squares = new int[4, 4];

        //loop through 2D array
        for (int row = 0; row < 4; row++)
            for (int column = 0; column < 4; column++)
                _squares[row, column] = row * 4 + column + 1;

    }

    public int GetSquare(int row, int column)
    {
        return _squares[row, column];
    }

    public void Move(Direction direction)
    {
        (int row, int column) = GetOpenLocation();

        if (direction == Direction.Right && column > 0) Swap(row, column, row, column - 1);
        if (direction == Direction.Left && column < 3) Swap(row, column, row, column + 1);
        if (direction == Direction.Up && row < 3) Swap(row, column, row, column);
        if (direction == Direction.Down && row > 0) Swap(row, column, row, column);
    }

    public bool IsOver
    {
        get
        {
            for (int row = 0; row < 4; row++)
                for (int column = 0; column < 4; column++)
                    if (_squares[row, column] != row * 4 + column + 1)
                        return false;
            return true;
        }
    }

    private void Swap(int row1, int column1, int row2, int column2)
    {
        int temporary = _squares[row1, column1];
        _squares[row1, column1] = _squares[row2, column2];
        _squares[row2, column2] = temporary;

    }

    private (int, int) GetOpenLocation()
    {
        for (int row = 0; row < 4; row++)
            for (int column = 0; column < 4; column++)
                if (_squares[row, column] == 16)
                    return (row, column);
        return (0, 0);
    }
}

public class Location
{
    public int Row { get; }
    public int Column { get; }
    public Location(int row, int column) {  Row = row; Column = column; }
}

public class PlayerInput
{
    public Direction GetMove()
    {
        ConsoleKey selection = Console.ReadKey(true).Key;
        Direction choice = selection switch
        {
            ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.RightArrow => Direction.Right,
            ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.DownArrow => Direction.Down,
            _ => Direction.Down
        };
        return choice;
    }
}

public enum Direction { Up, Right, Down, Left}

