﻿Pack pack = new Pack(10, 20, 30);

while (true)
{
    Console.WriteLine(pack);
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
        6 => new Sword()
    };

    if (!pack.Add(newItem))
        Console.WriteLine("Could not add this to the pack.");
}

public class Pack
{
    public int MaxCount { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }

    private InventoryItem[] _items;

    public int CurrentCount { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }

    public Pack(int maxCount, float maxWeight, float maxVolume)
    {
        MaxCount = maxCount;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;

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

    public override string ToString()
    {
        string contents = "Pack contains ";
        if (CurrentCount == 0) contents += "Nothing";

        for (int itemNumber = 0; itemNumber < CurrentCount; itemNumber++)
        {
            contents += _items[itemNumber].ToString() + " ";
        }
        return contents;
    }
}

public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

//Create derived classes for each of the types of items above. Each class should pass the correct weight and volume to the base class constructor but should
//be creatable themselves with a parameterless constructor (for example, 'new Rope()' or 'new Sword()'

//each class contains a single empty parameterless constructor, but because it inherits InventoryItem we pass in each item's
//weight and volume

public class Arrow : InventoryItem {
    public Arrow() : base(0.1f, 0.05f) { }
    public override string ToString() => "Arrow";
}
public class Bow : InventoryItem {
    public Bow() : base(0.1f, 0.05f) { }
    public override string ToString() => "Bow";
}
public class Rope : InventoryItem {
    public Rope() : base(0.1f, 0.05f) { }
    public override string ToString() => "Rope";
}
public class Water : InventoryItem {
    public Water() : base(0.1f, 0.05f) { }
    public override string ToString() => "Water";
}
public class Food : InventoryItem {
    public Food() : base(0.1f, 0.05f) { }
    public override string ToString() => "Food";
}
public class Sword : InventoryItem {
    public Sword() : base(0.1f, 0.05f) { }
    public override string ToString() => "Sword";
}