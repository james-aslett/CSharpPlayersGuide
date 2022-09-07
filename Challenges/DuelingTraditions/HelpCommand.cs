namespace DuelingTraditions;

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