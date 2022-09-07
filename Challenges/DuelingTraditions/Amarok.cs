using DuelingTraditions;

public class Amarok : Monster
{
    // Creates a new amarok at a specific starting location.
    public Amarok(Location start) : base(start) { }

    public override void Activate(FountainOfObjectsGame game)
    {
        game.Player.Kill("You stumbled across an amarok and have been eaten alive!");
    }
}