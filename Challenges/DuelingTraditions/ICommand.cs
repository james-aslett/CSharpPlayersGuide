using DuelingTraditions;

public interface ICommand
{
    void Execute(FountainOfObjectsGame game);
}

public class HelpCommand : ICommand
{
    public void Execute(FountainOfObjectsGame game)
    {
        ConsoleHelper.WriteLine("Available commands: ", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("move - move in direction of your choice (north/south/east west), eg: 'move north' if there are no walls.", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine($"shoot - shoot in direction of your choice (north/south/east west), eg: 'shoot north'. You currently have {game.Player.ArrowsRemaining} arrows remaining.", ConsoleColor.DarkYellow);
        ConsoleHelper.WriteLine("enable fountain - turns on the Fountain of Objects if you are in the fountain room, or does nothing if you are not.", ConsoleColor.DarkYellow);
    }
}

public class MoveCommand : ICommand
{
    public Direction Direction { get; }

    public MoveCommand(Direction direction)
    {
        Direction = direction;
    }

    public void Execute(FountainOfObjectsGame game)
    {
        Location currentLocation = game.Player.Location;
        Location newLocation = Direction switch
        {
            Direction.North => new Location(currentLocation.Row - 1, currentLocation.Column),
            Direction.South => new Location(currentLocation.Row + 1, currentLocation.Column),
            Direction.West => new Location(currentLocation.Row, currentLocation.Column - 1),
            Direction.East => new Location(currentLocation.Row, currentLocation.Column + 1)
        };

        if (game.Map.IsOnMap(newLocation))
            game.Player.Location = newLocation;
        else
            ConsoleHelper.WriteLine("There is a wall there.", ConsoleColor.Red);
    }
}

public class EnableFountainCommand : ICommand
{
    public void Execute(FountainOfObjectsGame game)
    {
        if (game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Fountain) game.IsFountainOn = true;
        else ConsoleHelper.WriteLine("The fountain is not in this room. There was no effect.", ConsoleColor.Red);
    }
}