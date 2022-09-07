namespace DuelingTraditions;

public class AmarokSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        foreach (Monster monster in game.Monsters)
        {
            if (monster is Amarok && monster.IsAlive)
            {
                int rowDifference = Math.Abs(monster.Location.Row - game.Player.Location.Row);
                int columnDifference = Math.Abs(monster.Location.Column - game.Player.Location.Column);

                if (rowDifference <= 1 && columnDifference <= 1) return true;
            }
        }

        return false;
    }

    public void DisplaySense(FountainOfObjectsGame game) => ConsoleHelper.WriteLine("You can smell the rotton stench of an amarok in a nearby room.", ConsoleColor.Red);
}