//Give your program a traditional Program and Main method instead of top-level statements
//Place every type in a namespace
//Place each type in its own file (small types like enums or records can be an exception)
//Having used both top-level statements and a traditional entry point, which do you prefer and why?

//Complete FountainOfObjects game

namespace DuelingTraditions;

public class Program
{
    static void Main(string[] args)
    {
        ConsoleHelper.Write("Would you like to play a small, medium or large game?", ConsoleColor.White);
        Console.ForegroundColor = ConsoleColor.Cyan;

        FountainOfObjectsGame game = Console.ReadLine() switch
        {
            "small" => CreateSmallGame(),
            "medium" => CreateMediumGame(),
            "large" => CreateLargeGame()
        };

        DisplayIntro();

        game.Run();

        void DisplayIntro()
        {
            ConsoleHelper.Write("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the ", ConsoleColor.DarkCyan);
            ConsoleHelper.Write("Fountain of Objects. ", ConsoleColor.Green);
            ConsoleHelper.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns. You must navigate the caverns with your other senses. Find the Fountain of Objects, activate it, and return to the entrance.", ConsoleColor.DarkCyan);
            Console.WriteLine();
            ConsoleHelper.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.", ConsoleColor.DarkCyan);
            ConsoleHelper.Write("Maelstroms ", ConsoleColor.Red);
            ConsoleHelper.WriteLine("are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. You will be able to hear their growling and groaning in nearby rooms.", ConsoleColor.DarkCyan);
            Console.WriteLine();
            ConsoleHelper.Write("Amaroks ", ConsoleColor.Red);
            ConsoleHelper.WriteLine("roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms. You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.", ConsoleColor.DarkCyan);
            Console.WriteLine();
            ConsoleHelper.WriteLine("Type 'help' at any time for a list of commands.", ConsoleColor.DarkCyan);
        }

        FountainOfObjectsGame CreateSmallGame()
        {
            Map map = new Map(4, 4);
            Location start = new Location(0, 0);
            map.SetRoomTypeAtLocation(start, RoomType.Entrance);
            map.SetRoomTypeAtLocation(new Location(0, 2), RoomType.Fountain);
            map.SetRoomTypeAtLocation(new Location(3, 3), RoomType.Pit);

            Monster[] monsters = new Monster[]
            {
        new Maelstrom(new Location(2, 0)),
        new Amarok(new Location(1, 3))
            };

            return new FountainOfObjectsGame(map, new Player(start), monsters);
        }

        FountainOfObjectsGame CreateMediumGame()
        {
            Map map = new Map(6, 6);
            Location start = new Location(1, 0);
            map.SetRoomTypeAtLocation(start, RoomType.Entrance);
            map.SetRoomTypeAtLocation(new Location(5, 2), RoomType.Fountain);
            map.SetRoomTypeAtLocation(new Location(4, 3), RoomType.Pit);

            Monster[] monsters = new Monster[]
            {
        new Maelstrom(new Location(2, 0)),
        new Maelstrom(new Location(2, 0)),
        new Amarok(new Location(5, 4)),
        new Amarok(new Location(1, 4))
            };

            return new FountainOfObjectsGame(map, new Player(start), monsters);
        }

        FountainOfObjectsGame CreateLargeGame()
        {
            Map map = new Map(8, 8);
            Location start = new Location(2, 0);
            map.SetRoomTypeAtLocation(start, RoomType.Entrance);
            map.SetRoomTypeAtLocation(new Location(7, 2), RoomType.Fountain);
            map.SetRoomTypeAtLocation(new Location(7, 6), RoomType.Pit);

            Monster[] monsters = new Monster[]
            {
        new Maelstrom(new Location(2, 0)),
        new Maelstrom(new Location(2, 0)),
        new Amarok(new Location(6, 1)),
        new Amarok(new Location(3, 7))
            };

            return new FountainOfObjectsGame(map, new Player(start), monsters);
        }
    }
}