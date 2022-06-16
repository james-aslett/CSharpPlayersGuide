new TicTacToeGame().Run();

public class WinChecker
{
    public bool HasXWon(Board board)
    {      
        return HasWon(board, CellType.X);
    }

    public bool HasOWon(Board board)
    {
        return HasWon(board, CellType.O);
    }

    private static bool HasWon(Board board, CellType type)
    {
        bool[,] match = new bool[3, 3]; //bool array - all defaulted to false
        for (int row = 0; row < 3; row++)
            for (int column = 0; column < 3; column++)
                //for each item in array, check if == CellType.X. If yes, item set to true
                match[row, column] = board.Get(row, column) == type;

        //columns
        if (match[0, 0] && match[0, 1] && match[0, 2]) return true;
        if (match[1, 0] && match[1, 1] && match[1, 2]) return true;
        if (match[2, 0] && match[2, 1] && match[2, 2]) return true;
        //rows
        if (match[0, 0] && match[1, 0] && match[2, 0]) return true;
        if (match[0, 1] && match[1, 1] && match[2, 1]) return true;
        if (match[0, 2] && match[1, 2] && match[2, 2]) return true;
        //diagonals
        if (match[0, 0] && match[1, 1] && match[2, 2]) return true;
        if (match[2, 0] && match[1, 1] && match[0, 2]) return true;

        return false;
    }

    public bool IsBoardFull(Board board)
    {
        for (int row = 0; row < 3; row++)
            for (int column = 0; column < 3; column++)
                if (board.Get(new Location(row, column)) == CellType.Empty)
                    return false;
        return true;
    }
}

public class TicTacToeGame
{
    public void Run()
    {
        Board board = new Board();
        BoardRenderer renderer = new BoardRenderer();
        Player player1 = new Player(CellType.X);
        Player player2 = new Player(CellType.O);
        Player currentPlayer = player1;
        WinChecker winchecker = new WinChecker();

        while (!winchecker.HasXWon(board) && !winchecker.HasOWon(board) && !winchecker.IsBoardFull(board))
        {
            Console.WriteLine($"It is {currentPlayer.Token}'s turn.");
            Console.WriteLine();
            renderer.Render(board);
            Console.WriteLine();
            Location target = currentPlayer.GetChoice(board);
            board.Set(target, currentPlayer.Token);

            if (currentPlayer == player1) currentPlayer = player2;
            else currentPlayer = player1;

            Console.Clear();
        }

        renderer.Render(board);
        Console.WriteLine();
        if (winchecker.HasXWon(board))
            Console.WriteLine("X wins!");
        else if (winchecker.HasOWon(board))
            Console.WriteLine("O wins!");
        else Console.WriteLine("It's a draw!");
    }
}

public class Player
{
    public CellType Token { get; }
    public Player(CellType token) { Token = token; }
    public Location GetChoice(Board board)
    {
        while (true)
        {
            Console.Write("What square do you want to play in? ");
            string? choiceAsString = Console.ReadLine();

            //will refactor this with proper error handling later
            if (!int.TryParse(choiceAsString, out int choice))
            {
                Console.WriteLine("That was not a valid choice. Try again.");
                continue;
            }

            Location? location = ToLocation(choice);

            if (location == null)
            {
                Console.WriteLine("That was not a valid choice. Try again.");
                continue;
            }
            if (board.Get(location) == CellType.Empty)
                return location;
            Console.WriteLine("That space is not open! Try again.");
        }
    }

    private static Location ToLocation(int choice)
    {
        return choice switch
        {
            1 => new Location(2, 0),
            2 => new Location(2, 1),
            3 => new Location(2, 2),
            4 => new Location(1, 0),
            5 => new Location(1, 1),
            6 => new Location(1, 2),
            7 => new Location(0, 0),
            8 => new Location(0, 1),
            9 => new Location(0, 2),
        };
    }
}

public class BoardRenderer
{
    public void Render(Board board)
    {
        char[,] characters = new char[3, 3];
        for (int row = 0; row < 3; row++)
            for (int column = 0; column < 3; column++)
                characters[row, column] = ToCharacter(board.Get(new Location(row, column)));

        Console.WriteLine($" {characters[0, 0]} | {characters[0, 1]} | {characters[0, 2]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {characters[1, 0]} | {characters[1, 1]} | {characters[1, 2]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {characters[2, 0]} | {characters[2, 1]} | {characters[2, 2]} ");
    }

    private static char ToCharacter(CellType cellType)
    {
        return cellType switch
        {
            CellType.X => 'X',
            CellType.O => 'O',
            _ => ' '
        };
    }
}

public class Board
{
    private readonly CellType[,] _cells = new CellType[3, 3];

    public void Set(Location location, CellType newType)
    {
        if (newType == CellType.Empty)
            return;
        if (_cells[location.Row, location.Column] != CellType.Empty)
            return;

        _cells[location.Row, location.Column] = newType;
    }

    public CellType Get(Location location)
    {
        return _cells[location.Row, location.Column];
    }

    public CellType Get(int row, int column)
    {
        return _cells[row, column];
    }
}

public enum CellType { Empty, X, O }

public class Location
{
    public int Row { get; }
    public int Column { get; }

    public Location(int row, int column) { Row = row; Column = column; }
}