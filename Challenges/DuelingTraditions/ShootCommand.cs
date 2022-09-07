namespace DuelingTraditions;

public class ShootCommand : ICommand
{
    public Direction Direction { get; }

    public ShootCommand(Direction direction)
    {
        Direction = direction;
    }

    public void Execute(FountainOfObjectsGame game)
    {
        if (game.Player.ArrowsRemaining == 0)
        {
            ConsoleHelper.WriteLine("You don't have any arrows left!", ConsoleColor.Red);
            return;
        }

        Location currentLocation = game.Player.Location;
        Location targetLocation = Direction switch
        {
            Direction.North => new Location(currentLocation.Row - 1, currentLocation.Column),
            Direction.South => new Location(currentLocation.Row + 1, currentLocation.Column),
            Direction.West => new Location(currentLocation.Row, currentLocation.Column - 1),
            Direction.East => new Location(currentLocation.Row, currentLocation.Column + 1)
        };

        bool foundSomething = false;
        foreach (Monster monster in game.Monsters)
        {
            if (monster.Location == targetLocation && monster.IsAlive)
            {
                monster.IsAlive = false;
                foundSomething = true;
            }
        }

        if (foundSomething) ConsoleHelper.WriteLine("You fire an arrow and hit something!", ConsoleColor.Green);
        else ConsoleHelper.WriteLine("You fire an arrow and missed.", ConsoleColor.Magenta);

        game.Player.ArrowsRemaining--;
    }
}