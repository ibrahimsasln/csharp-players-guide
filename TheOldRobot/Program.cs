using System;

namespace TheOldRobot;

class Program
{
    static void Main(string[] args)
    {
        Robot robot = new Robot();
        Console.WriteLine("Robot command list: on/off, north, south, west, east");
        Console.WriteLine("Enter 3 command.");
        string[] userCommands = new string[3];
        for (int i = 0; i < 3; i++)
        {
            userCommands[i] = Console.ReadLine()?.ToLower() ?? "";

            robot.Commands[i] = userCommands[i] switch
            {
                "on" => new OnCommand(),
                "off" => new OffCommand(),
                "north" => new NorthCommand(),
                "south" => new SouthCommand(),
                "west" => new WestCommand(),
                "east" => new EastCommand(),
                _ => null
            };
        }

        robot.Run();
    }
}

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
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);

}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y++;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}