//change the Robot class to use a List<IRobotCommand> instead of an array for its Commands property
//instead of looping three times, go until the user types stop. Then run all of the commands created

Robot robot = new Robot();

Console.WriteLine($"The robot is currently {robot.PowerStatus(robot.IsPowered)}. Please:");
Console.WriteLine("1: Set power status (on/off)");
Console.WriteLine("2: Specify a direction (north/south/east/west)");
Console.WriteLine("3: Specify another direction");

while (true)
{
    string? input = Console.ReadLine();
    if (input == "stop") break;

    robot.Commands.Add(input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
    });
}

//execute all commands
Console.WriteLine();
robot.Run();

if (robot.IsPowered == false)
    Console.WriteLine("You didn't turn the robot on, so it couldn't move!");

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }

    public List<IRobotCommand?> Commands { get; } = new List<IRobotCommand?>();
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[Horizontal:{X} | Vertical:{Y} | Power status: {PowerStatus(IsPowered)}]");
        }
    }
    public string PowerStatus(bool IsPowered) { if (IsPowered == true) return "on"; return "off"; }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand { public void Run(Robot robot) => robot.IsPowered = true; }

public class OffCommand : IRobotCommand { public void Run(Robot robot) => robot.IsPowered = false; }

public class NorthCommand : IRobotCommand { public void Run(Robot robot) { if (robot.IsPowered == true) robot.Y++; } }

public class SouthCommand : IRobotCommand { public void Run(Robot robot) { if (robot.IsPowered == true) robot.Y--; } }

public class WestCommand : IRobotCommand { public void Run(Robot robot) { if (robot.IsPowered == true) robot.X--; } }

public class EastCommand : IRobotCommand { public void Run(Robot robot) { if (robot.IsPowered == true) robot.X++; } }