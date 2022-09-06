using DuelingTraditions;

public class PitDraftSense : ISense
{
    public bool CanSense(FountainOfObjectsGame game) => game.Map.HasNeighborWithType(game.Player.Location, RoomType.Pit);

    public void DisplaySense(FountainOfObjectsGame game) => ConsoleHelper.WriteLine("You feel a draft. There is a pit in a nearby room.", ConsoleColor.Red);
}