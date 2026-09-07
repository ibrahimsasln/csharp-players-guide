using System;

namespace TheFountainOfObjects;

class Program
{
    static void Main(string[] args)
    {
        Map map = new Map(4, 4);
        Player player = new Player(0, 0);
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

        room[0, 0] = new CaveEnterance();
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
    private PlayerInput input;


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
        while (true)
        {
            Display();
            string userInput = input.GetCommand();
            
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

public class CaveEnterance : Room
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