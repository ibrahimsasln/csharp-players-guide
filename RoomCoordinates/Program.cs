using System;

namespace RoomCoordinates;

class Program
{
    static void Main(string[] args)
    {
        Coordinate a = new(3, 3); //simplified new Coordinate(3, 3);
        Coordinate b = new(2, 3);
        Coordinate c = new(2, 2);

        Console.WriteLine(Coordinate.AreAdjacent(a, b));
        Console.WriteLine(Coordinate.AreAdjacent(b, c));
        Console.WriteLine(Coordinate.AreAdjacent(a, c));
    }
}
public readonly struct Coordinate(int row, int column) //primary constructor
{
    public int Row { get; } = row;
    public int Column { get; } = column;

    public static bool AreAdjacent(Coordinate a, Coordinate b)
    {
        int rowChange = a.Row - b.Row;
        int columnChange = a.Column - b.Column;

        if (Math.Abs(rowChange) <= 1 && columnChange == 0) return true;
        if (Math.Abs(columnChange) <= 1 && rowChange == 0) return true;

        return false;
    }
}