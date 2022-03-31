//2: Modify the program to allow users to choose one of these predefined types or a custom arrow. If they select a predefined one, produce an Arrow instance using one of
//the new static methods. If they choose custom, use your earlier code to get their custom data about the desired arrow


Arrow Elite = Arrow.CreateEliteArrow();

Arrow arrow = GetArrow();
Console.WriteLine($"That arrows costs {arrow.GetCost()} gold.");

Arrow GetArrow()
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

//1: Modify your arrow class to include static methods of each of the following arrow types, like this: public static Arrow CreateEliteArrow() { ... }
//EliteArrow = steel/plastic/95cm
//BeginnerArrow = wood/goose/75cm
//MarksmanArrow = steel/goose/65cm
class Arrow
{
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private float _length;

    public Arrowhead GetArrowhead() => _arrowhead;
    public Fletching GetFletching() => _fletching;
    public float GetLength() => _length;

    public static Arrow CreateEliteArrow() => new(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new(Arrowhead.w, Fletching.Plastic, 95);
    public static Arrow CreateMarksmanArrow() => new(Arrowhead.Steel, Fletching.Plastic, 95);


    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public float GetCost()
    {
        float arrowheadCost = _arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wool => 3,
            Arrowhead.Obsidian => 5
        };

        float fletchingCost = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3
        };

        float shaftCost = 0.05f * _length;

        return arrowheadCost + fletchingCost + shaftCost;
    }
}

enum Arrowhead { Steel, Wool, Obsidian }
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }