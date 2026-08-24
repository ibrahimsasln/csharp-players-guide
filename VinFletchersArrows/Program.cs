Console.WriteLine("Which type of arrowhead do you want? (Steel/Wood/Obsidian)");
string? arrowheadInput = Console.ReadLine();

ArrowheadType arrowhead = arrowheadInput switch
{
    "Steel" => ArrowheadType.Steel,
    "Wood" => ArrowheadType.Wood,
    "Obsidian" => ArrowheadType.Obsidian,
    _ => throw new ArgumentException($"Unexpected arrowhead type: {arrowheadInput}")
};

Console.WriteLine("Which type of fletching do you want? (Plastic/TurkeyFeathers/GooseFeathers)");
string? fletchingInput = Console.ReadLine();

FletchingType fletching = fletchingInput switch
{
    "Plastic" => FletchingType.Plastic,
    "TurkeyFeathers" => FletchingType.TurkeyFeathers,
    "GooseFeathers" => FletchingType.GooseFeathers,
    _ => throw new ArgumentException($"Unexpected fletching type: {fletchingInput}")
};

Console.WriteLine("Length? (60-100)");
string? lengthInput = Console.ReadLine();
if (!int.TryParse(lengthInput, out int length))
{
    Console.WriteLine("Unexpected value");
    return;
}

    Arrow arrow = new Arrow(arrowhead, fletching, length);
    Console.WriteLine($"Cost: {arrow.GetCost()}");

class Arrow
{
    const int MinLength = 60;
    const int MaxLength = 100;

    ArrowheadType arrowhead;
    FletchingType fletching;
    int length;

    public Arrow(ArrowheadType arrowhead, FletchingType fletching, int length)
    {
        if (length < MinLength || length > MaxLength)
        {
            throw new ArgumentException($"Length must be between {MinLength} and {MaxLength}, got {length}");
        }

        this.arrowhead = arrowhead;
        this.fletching = fletching;
        this.length = length;
    }

    public float GetCost()
    {
        float headCost = arrowhead switch
        {
            ArrowheadType.Steel => 10.0f,
            ArrowheadType.Wood => 3.0f,
            ArrowheadType.Obsidian => 5.0f,
            _ => throw new ArgumentException($"Unexpected arrowhead type: {arrowhead}")
        };

        float fletchingCost = fletching switch
        {
            FletchingType.Plastic => 10.0f,
            FletchingType.TurkeyFeathers => 5.0f,
            FletchingType.GooseFeathers => 3.0f,
            _ => throw new ArgumentException($"Unexpected fletching type: {fletching}")
        };

        float lengthCost = length * 0.05f;

        return headCost + fletchingCost + lengthCost;
    }
}

enum ArrowheadType
{
    Steel,
    Wood,
    Obsidian
}

enum FletchingType
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}