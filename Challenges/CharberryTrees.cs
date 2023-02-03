
CharberryTree tree = new CharberryTree();
Notifier announcer = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();

//Make a Harvester class that knows about the tree (Hint: like the notifier, this could be passed as a constructor parameter) and subscribes to its Ripened event. Attach a handler that sets the tree's Ripe property back to false
public class Harvester
{
    private int _harvestCount;
    private CharberryTree _tree;

    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        _tree.Ripened += OnTreeRipened;
    }

    private void OnTreeRipened()
    {
        _harvestCount++;
        _tree.Ripe = false;
        Console.WriteLine($"The tree has been harvested {_harvestCount} times.");
    }
}

//Make a Notifier class that knows about the tree (Hint: perhaps pass it in as a constructor parameter) and subscribes to its Ripened event. Attach a handler that displays something like "A charberry fruit has ripened!" to the console window

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnTreeRipened;
    }

    private void OnTreeRipened() => Console.WriteLine("A charberry fruit has ripened!");
}

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }
    //Add a Ripened event to the CharberryTree class that is raised when the tree ripens
    public event Action? Ripened;

    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}