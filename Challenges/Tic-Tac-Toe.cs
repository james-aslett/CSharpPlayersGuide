Board board = new Board();
board.Set(new Location(0, 1), CellType.O);
board.Set(new Location(0, 2), CellType.X);
board.Set(new Location(2, 2), CellType.X);
board.Set(new Location(2, 1), CellType.O);
new BoardRenderer().Render(board);

public class Player
{
    public Location GetChoice(Board board)
    {
        while (true)
        {
            Console.Write("What square do you want to play in?");
            int choice = Convert.ToInt32(Console.ReadLine());

            Location location = choice switch
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

            if (board.Get(location) == CellType.Empty)
                return location;
        }
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

    private char ToCharacter(CellType cellType)
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
}

public enum CellType { Empty, X, O }

public class Location
{
    public int Row { get; }
    public int Column { get; }

    public Location(int row, int column) { Row = row; Column = column; }
}