namespace DuelingTraditions;

public class Maelstrom : Monster
{
    // Creates a new maelstrom at a specific starting location.
    public Maelstrom(Location start) : base(start) { }

    // When activated, this moves the player two spaces east (+2 columns) and one space north (-1 row)
    // and the maelstrom moves two spaces west (-2 columns) and one space south (+1 row). However,
    // it ensures both player and maelstrom stay within the boundaries of the map.
    public override void Activate(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("You have encountered a maelstrom and have been swept away to another room!", ConsoleColor.Magenta);
        game.Player.Location = Clamp(new Location(game.Player.Location.Row - 1, game.Player.Location.Column + 2), game.Map.Rows, game.Map.Columns);
        Location = Clamp(new Location(Location.Row + 1, Location.Column - 2), game.Map.Rows, game.Map.Columns);
    }

    // Takes a location and a map size, and produces a new location that is as much the same
    // as possible, but guarantees it is on the map.
    private Location Clamp(Location location, int totalRows, int totalColumns)
    {
        int row = location.Row;
        if (row < 0) row = 0;
        if (row >= totalRows) row = totalRows - 1;

        int column = location.Column;
        if (column < 0) column = 0;
        if (column >= totalColumns) column = totalColumns - 1;

        return new Location(row, column);
    }
}