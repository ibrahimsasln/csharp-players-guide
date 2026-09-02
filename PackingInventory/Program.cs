using System;

namespace PackingInventory;

class Program
{
    static void Main(string[] args)
    {
        Pack pack = new Pack(10, 20, 30);

        while (true)
        {
            Console.WriteLine($"Pack is currently at {pack.CurrentCount}/{pack.MaxCount} items, {pack.CurrentWeight}/{pack.MaxWeight} weight, and {pack.CurrentVolume}/{pack.MaxVolume} volume.");

            Console.WriteLine("What do you want to add?");
            Console.WriteLine("1 - Arrow");
            Console.WriteLine("2 - Bow");
            Console.WriteLine("3 - Rope");
            Console.WriteLine("4 - Water");
            Console.WriteLine("5 - Food");
            Console.WriteLine("6 - Sword");
            int choice = Convert.ToInt32(Console.ReadLine());

            InventoryItem newItem = choice switch
            {
                1 => new Arrow(),
                2 => new Bow(),
                3 => new Rope(),
                4 => new Water(),
                5 => new Food(),
                6 => new Sword(),
                _ => throw new ArgumentOutOfRangeException(),
            };

            if (!pack.Add(newItem))
                Console.WriteLine("Could not add this to the pack.");
        }
    }
}

class Pack
{
    public int MaxCount { get; }
    public float MaxVolume { get; }
    public float MaxWeight { get; }

    private InventoryItem[] _items;

    public int CurrentCount { get; private set; }
    public float CurrentVolume { get; private set; }
    public float CurrentWeight { get; private set; }

    public Pack(int maxCount, float maxVolume, float maxWeight)
    {
        MaxCount = maxCount;
        MaxVolume = maxVolume;
        MaxWeight = maxWeight;

        _items = new InventoryItem[maxCount];
    }

    public bool Add(InventoryItem item)
    {
        if (CurrentCount >= MaxCount) return false;
        if (CurrentVolume + item.Volume > MaxVolume) return false;
        if (CurrentWeight + item.Weight > MaxWeight) return false;

        _items[CurrentCount] = item;
        CurrentCount++;
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
        return true;
    }
}

class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }
}

class Arrow : InventoryItem
{
    public Arrow()
    {
        Weight = 0.1f;
        Volume = 0.05f;
    }
}

class Bow : InventoryItem
{
    public Bow()
    {
        Weight = 1;
        Volume = 4;
    }
}

class Rope : InventoryItem
{
    public Rope()
    {
        Weight = 1;
        Volume = 1.5f;
    }
}

class Water : InventoryItem
{
    public Water()
    {
        Weight = 2;
        Volume = 3;
    }
}

class Food : InventoryItem
{
    public Food()
    {
        Weight = 1;
        Volume = 0.5f;
    }
}

class Sword : InventoryItem
{
    public Sword()
    {
        Weight = 5;
        Volume = 3;
    }
}

