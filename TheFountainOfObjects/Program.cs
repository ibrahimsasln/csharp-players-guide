using System;

namespace TheFountainOfObjects;

class Program
{
    static void Main(string[] args)
    {
        Map map = new Map(4, 4);
        Player player = new Player(0, 0);
        FountainOfObjectGame fountainOfObjectGame = new(map, player);

        fountainOfObjectGame.Run();
    }
}

public class Map
{
    private Room[,] room;
    public int Rows { get; }
    public int Columns { get; }

    public Map(int rowCount, int columnCount)
    {
        Rows = rowCount;
        Columns = columnCount;

        room = new Room[rowCount, columnCount];

        for (int r = 0; r < rowCount; r++)
            for (int c = 0; c < columnCount; c++)
                room[r, c] = new EmptyRoom(); //fill with empty room

        room[0, 0] = new CaveEntrance();
        room[0, 2] = new FountainRoom();
    }

    public Room GetRoomAt(int row, int column)
    {
        return room[row, column];
    }

    public bool IsOnMap(int row, int column)
    {
        return row >= 0 && row < Rows && column >= 0 && column < Columns;
    }
}

public class Player
{
    public int Row { get; private set; }
    public int Column { get; private set; }

    public Player(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public void MoveTo(int row, int column)
    {
        Row = row;
        Column = column;
    }
}

public class PlayerInput
{
    public string? GetCommand()
    {
        Console.Write("What do you want to do? ");
        return Console.ReadLine();
    }
}

public class FountainOfObjectGame
{
    private readonly Map map;
    private readonly Player player;
    private readonly PlayerInput input;


    public FountainOfObjectGame(Map map, Player player)
    {
        this.map = map;
        this.player = player;
        input = new PlayerInput();
    }

    public void Display()
    {
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine($"You are in the room at (Row = {player.Row}, Column = {player.Column})");
        Console.WriteLine(map.GetRoomAt(player.Row, player.Column).Describe());
    }

    public void Run()
    {
        bool isGameOver = false;

        while (!isGameOver)
        {
            Display();

            if (player.Row == 0 && player.Column == 0)
            {
                Room fountainRoom = map.GetRoomAt(0, 2);
                if (fountainRoom is FountainRoom fr && fr.IsFountainOpen)
                {
                    Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
                    Console.WriteLine("You win!");
                    isGameOver = true;
                    continue;
                }
            }

            string? userInput = input.GetCommand();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Invalid move");
                continue;
            }

            string command = userInput.Trim().ToLower();

            Direction? moveDirection = command switch
            {
                "move north" => Direction.North,
                "move south" => Direction.South,
                "move east" => Direction.East,
                "move west" => Direction.West,
                _ => null
            };

            if (moveDirection.HasValue)
            {
                var (rowOffset, columnOffset) = moveDirection.Value switch
                {
                    Direction.North => (-1, 0),
                    Direction.South => (1, 0),
                    Direction.East => (0, 1),
                    Direction.West => (0, -1),
                    _ => (0, 0)
                };

                int targetRow = player.Row + rowOffset;
                int targetColumn = player.Column + columnOffset;

                if (map.IsOnMap(targetRow, targetColumn))
                {
                    player.MoveTo(targetRow, targetColumn);
                }
                else
                {
                    Console.WriteLine("There is wall here. You can't go there.");
                }
            }
            else if (command == "enable fountain")
            {
                Room currentRoom = map.GetRoomAt(player.Row, player.Column);

                if (currentRoom is FountainRoom fountainRoom)
                {
                    fountainRoom.EnableFountain();
                }
                else
                {
                    Console.WriteLine("There is no fountain here");
                }
            }
            else
            {
                Console.WriteLine("Invalid move");
            }
        }
    }
}


public abstract class Room
{
    public abstract string Describe();
}

public class FountainRoom : Room
{
    public bool IsFountainOpen { get; private set; }

    public void EnableFountain()
    {
        IsFountainOpen = true;
    }

    public override string Describe()
    {
        if (IsFountainOpen)
        {
            return "You hear the rushing waters from the Fountain of Objects. It has been reactivated!";
        }
        else
        {
            return "You hear water dripping in this room. The Fountain of Objects is here!";
        }
    }
}

public class CaveEntrance : Room
{
    public override string Describe()
    {
        return "You see light coming from the cavern entrance.";
    }
}

public class EmptyRoom : Room
{
    public override string Describe()
    {
        return "You sense nothing";
    }
}

public enum Direction { North, South, East, West }