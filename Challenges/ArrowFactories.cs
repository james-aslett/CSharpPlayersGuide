Arrow arrow;
int input = GetUserInput();

arrow = input switch
{
    1 => Arrow.CreateBeginnerArrow(),
    2 => Arrow.CreateMarksmanArrow(),
    3 => Arrow.CreateEliteArrow(),
    4 => GetCustomArrow(),
};

Console.WriteLine($"That arrow costs {arrow.Cost} gold");

int GetUserInput()
{
    int number;
    do
    {
        Console.WriteLine("Please choose from the following arrows, or create your own!");
        Console.WriteLine("1: Beginner");
        Console.WriteLine("2: Marksman");
        Console.WriteLine("3: Elite");
        Console.WriteLine("4: Custom");
        number = Convert.ToInt32(Console.ReadLine());
    }
    while (number < 1 | number > 4);
    return number;
}

Arrow GetCustomArrow()
{
    Arrowhead arrowhead = GetArrowhead();
    Fletching fletching = GetFletchingType();
    float length = GetShaftLength();

    return new Arrow(arrowhead, fletching, length);
}

Arrowhead GetArrowhead()
{
    Console.WriteLine($"Choose an arrowhead (steel | wool | obsidian)");
    string input = Console.ReadLine().ToLower();
    return input switch
    {
        "steel" => Arrowhead.Steel,
        "wool" => Arrowhead.Wool,
        "obsidian" => Arrowhead.Obsidian
    };
}

Fletching GetFletchingType()
{
    Console.WriteLine($"Choose a fletching type (plastic | turkey feathers | goose feathers)");
    string input = Console.ReadLine().ToLower();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "turkey feathers" => Fletching.TurkeyFeathers,
        "goose feathers" => Fletching.GooseFeathers
    };
}

float GetShaftLength()
{
    float length = 0;

    while (length < 60 || length > 100)
    {
        Console.WriteLine("Arrow length (between 60 and 100): ");
        length = Convert.ToSingle(Console.ReadLine());
    }
    return length;
}
class Arrow
{
    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get; }
    public float Length { get; }

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;
    }

    public float Cost
    {
        get
        {
            float arrowheadCost = Arrowhead switch
            {
                Arrowhead.Steel => 10,
                Arrowhead.Wool => 3,
                Arrowhead.Obsidian => 5
            };

            float fletchingCost = Fletching switch
            {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };

            float shaftCost = 0.05f * Length;

            return arrowheadCost + fletchingCost + shaftCost;
        }
    }
     
    public static Arrow CreateEliteArrow() => new(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new(Arrowhead.Wool, Fletching.GooseFeathers, 75);
    public static Arrow CreateMarksmanArrow() => new(Arrowhead.Steel, Fletching.GooseFeathers, 65);
}

enum Arrowhead { Steel, Wool, Obsidian }
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }