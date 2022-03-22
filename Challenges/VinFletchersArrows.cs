
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

class Arrow
{
    //fields
    public Arrowhead _arrowhead;
    public Fletching _fletching;
    public float _length;

    //constructor
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