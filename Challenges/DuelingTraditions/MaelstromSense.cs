namespace DuelingTraditions;

public class MaelstromSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        foreach (Monster monster in game.Monsters)
        {
            if (monster is Maelstrom && monster.IsAlive)
            {
                int rowDifference = Math.Abs(monster.Location.Row - game.Player.Location.Row);
                int columnDifference = Math.Abs(monster.Location.Column - game.Player.Location.Column);

                if (rowDifference <= 1 && columnDifference <= 1) return true;
            }
        }
        return false;
    }

    public void DisplaySense(FountainOfObjectsGame game) => ConsoleHelper.WriteLine("You hear the growling and groaning of a maelstrom nearby.", ConsoleColor.Red);
}