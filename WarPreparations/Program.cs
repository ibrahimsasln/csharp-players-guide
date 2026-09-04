using System;

namespace WarPreparations;

class Program
{
    static void Main(string[] args)
    {
        Sword sword1 = new(Material.Iron, Gemstone.None, 5, 1.5f);
        Sword sword2 = sword1 with { Material = Material.Binarium, Length = 6 };
        Sword sword3 = sword1 with { Gemstone = Gemstone.Emerald };

        Console.WriteLine(sword1);
        Console.WriteLine(sword2);
        Console.WriteLine(sword3);
    }
}
public record Sword(Material Material, Gemstone Gemstone, float Length, float CrossguardWidth);


public enum Material
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

public enum Gemstone
{
    None,
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone
}