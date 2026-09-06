using System;

namespace ColoredItems;

class Program
{
    static void Main(string[] args)
    {
        ColoredItem<Sword> sword = new(new Sword(), ConsoleColor.Blue);
        ColoredItem<Bow> bow = new(new Bow(), ConsoleColor.Red);
        ColoredItem<Axe> axe = new(new Axe(), ConsoleColor.Green);

        sword.Display();
        bow.Display();
        axe.Display();

    }
}
public class Sword { public override string ToString() => "Sword"; }
public class Bow { public override string ToString() => "Bow"; }
public class Axe { public override string ToString() => "Axe"; }

public class ColoredItem<T>(T item, ConsoleColor color)
{
    public T Item { get; } = item;
    public ConsoleColor Color { get; } = color;

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item);

        Console.ResetColor();
    }
}