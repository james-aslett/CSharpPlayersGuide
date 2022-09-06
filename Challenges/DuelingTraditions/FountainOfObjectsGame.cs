﻿namespace DuelingTraditions;

public class FountainOfObjectsGame
{
    public Map Map { get; }

    public Player Player { get; }

    public Monster[] Monsters { get; }

    public Maelstrom[] Maelstroms { get; }

    public Amarok[] Amaroks { get; }

    public bool IsFountainOn { get; set; }

    private readonly ISense[] _senses;

    public FountainOfObjectsGame(Map map, Player player, Monster[] monsters)
    {
        Map = map;
        Player = player;
        Monsters = monsters;
.
        _senses = new ISense[]
        {
            new LightInEntranceSense(),
            new FountainSense(),
            new PitDraftSense(),
            new MaelstromSense(),
            new AmarokSense()
        };
    }

    public void Run()
    {
        while (!HasWon && Player.IsAlive)
        {
            DisplayStatus();
            ICommand command = GetCommand();
            command.Execute(this);

            foreach (Monster monster in Monsters)
                if (monster.Location == Player.Location && monster.IsAlive) monster.Activate(this);

            if (CurrentRoom == RoomType.Pit)
                Player.Kill("You fell into the pit and died.");
        }

        if (HasWon)
        {
            ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!", ConsoleColor.DarkGreen);
            ConsoleHelper.WriteLine("You win!", ConsoleColor.DarkGreen);
        }
        else
        {
            ConsoleHelper.WriteLine(Player.CauseOfDeath, ConsoleColor.Red);
            ConsoleHelper.WriteLine("You lost.", ConsoleColor.Red);
        }
    }

    private void DisplayStatus()
    {
        ConsoleHelper.WriteLine("--------------------------------------------------------------------------------", ConsoleColor.Gray);
        ConsoleHelper.WriteLine($"You are in the room at (Row={Player.Location.Row}, Column={Player.Location.Column}). You have {Player.ArrowsRemaining} arrows remaining.", ConsoleColor.Gray);
        foreach (ISense sense in _senses)
            if (sense.CanSense(this))
                sense.DisplaySense(this);
    }

    private ICommand GetCommand()
    {
        while (true)
        {
            ConsoleHelper.Write("What do you want to do? ", ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();

            if (input == "move north") return new MoveCommand(Direction.North);
            if (input == "move south") return new MoveCommand(Direction.South);
            if (input == "move east") return new MoveCommand(Direction.East);
            if (input == "move west") return new MoveCommand(Direction.West);
            if (input == "enable fountain") return new EnableFountainCommand();
            if (input == "shoot north") return new ShootCommand(Direction.North);
            if (input == "shoot south") return new ShootCommand(Direction.South);
            if (input == "shoot east") return new ShootCommand(Direction.East);
            if (input == "shoot west") return new ShootCommand(Direction.West);
            if (input == "help") return new HelpCommand();

            ConsoleHelper.WriteLine($"I did not understand '{input}'.", ConsoleColor.Red);
        }
    }

    public bool HasWon => CurrentRoom == RoomType.Entrance && IsFountainOn;

    public RoomType CurrentRoom => Map.GetRoomTypeAtLocation(Player.Location);
}