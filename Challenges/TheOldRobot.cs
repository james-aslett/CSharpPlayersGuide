Robot robot = new Robot();

Console.WriteLine($"The robot is currently {robot.PowerStatus(robot.IsPowered)}. Please:");
Console.WriteLine("1: Set power status (on/off)");
Console.WriteLine("2: Specify a direction (north/south/east/west)");
Console.WriteLine("3: Specify another direction");

for (int index = 0; index < robot.Commands.Length; index++)
{
    string? input = Console.ReadLine();
    RobotCommand newCommand = input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
    };
    robot.Commands[index] = newCommand;
}

Console.WriteLine();

robot.Run();

if (robot.IsPowered == false)
    Console.WriteLine("You didn't turn the robot on, so it couldn't move!");

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[Horizontal:{X} | Vertical:{Y} | Power status: {PowerStatus(IsPowered)}]");
        }
    }
    public string PowerStatus(bool IsPowered) { if (IsPowered == true) return "on"; return "off"; }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand { public override void Run(Robot robot) => robot.IsPowered = true; }

public class OffCommand : RobotCommand { public override void Run(Robot robot) => robot.IsPowered = false; }

public class NorthCommand : RobotCommand { public override void Run(Robot robot) { if (robot.IsPowered == true) robot.Y++; }}

public class SouthCommand : RobotCommand { public override void Run(Robot robot) { if (robot.IsPowered == true) robot.Y--; } }

public class WestCommand : RobotCommand { public override void Run(Robot robot) { if (robot.IsPowered == true) robot.X--; } }

public class EastCommand : RobotCommand { public override void Run(Robot robot) { if (robot.IsPowered == true) robot.X++; } }