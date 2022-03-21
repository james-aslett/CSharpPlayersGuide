//define an Arrow class with fields for arrowhead type (enum), fletching type (enum), and length
class Arrow
{
    public Arrowhead _arrowhead;
    public Fletching _fletching;
    public int _length;

    public Arrow(Arrowhead arrowhead, Fletching fletching, int length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    string GetArrowhead()
    {
        Console.WriteLine($"Choose an arrowhead. {Arrowhead.Steel}, {Arrowhead.Wool}, {Arrowhead.Obsidian}");
        return Console.ReadLine().ToLower();
    }

    string GetFletchingType()
    {
        Console.WriteLine($"Choose a fletching type. {Fletching.Plastic}, {Fletching.TurkeyFeathers}, {Fletching.GooseFeathers}");
        return Console.ReadLine().ToLower();
    }

    int GetShaftLength()
    {
        Console.WriteLine("Choose a shaft length between 60 - 100cm.");
        return Convert.ToInt32(Console.ReadLine().ToLower());
    }

    string CreateArrow(string arrowhead, string fletching, int shaft)
    {
        Arrowhead head;

        head = arrowhead switch
        {
            "steel" => Arrowhead.Steel,
            "wool" => Arrowhead.Wool,
            "obsidian" => Arrowhead.Obsidian,
        };
    }

    //allow user to choose an arrowhead, fletching type and length, then create a new Arrow instance
    Array GetUserInput()
    {
        Console.WriteLine("Choose an arrowhead (steel / wool / obsidian");
        string arrow = Console.ReadLine();
        Console.WriteLine("Choose a fletching type (plastic / turkey feathers / goose feathers)");
        string fletching = Console.ReadLine();
        Console.WriteLine("Choose a shaft length (between 60 - 100cm");
        int shaft = Convert.ToInt32(Console.ReadLine());

        return new (string, string, int)[1]
        {
            (arrow, fletching, shaft)
        };

    }

    //add a GetCost method that returns its cost as a float based on the following numbers, and display the arrow's cost:

    //arrowhead (steel 10, wool 3, obsidian 5)
    //shaft (between 60cm - 100cm) 0.05 per cm
    //fletching (plastic 10, turkey feathers 5, goose feathers 3)
    public string GetCost(Array userInput)
    {

    }
}

enum Arrowhead { Steel, Wool, Obsidian }
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }




