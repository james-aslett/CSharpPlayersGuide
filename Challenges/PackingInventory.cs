//Story:
//You decide to make a 'Pack' class to help hold items. Each pack has 3 limits - total items/total weight/total volume. Each item has a weight and volume, and you
//must not overload a pack by adding too many items, too much weight or too much volume.
//Story END

//Create a program that creates a new pack and then allow the user to add (or attempt to add) items chosen from a menu
Pack pack = new Pack(10, 20, 30);

while (true)
{

}

//Build a 'Pack' class that can store an array of items. The total number of items, the maximum weight, and the maximum volume are provived at creation time and
//cannot change afterwards
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
}

//Make a 'public bool Add(InventoryItem item)' method to 'Pack' that allows you to add items of any type to the pack's contents. This method should fail (return
//false and not modify the pack's fields) if adding an item would cause it to exceed the pack's item, weight or volume limit

//Add properties to Pack that allow it to report the current item count, weight, and volume, and the limits of each



//Create an inventory item class that represents any of the different item types. This class must represent the item's weight and volume, which it needs
//at creation time (constructor)
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
public class Arrow : InventoryItem { public Arrow() : base(0.1f, 0.05f) { } }
public class Bow : InventoryItem { public Bow() : base(1f, 4f) { } }
public class Rope : InventoryItem { public Rope() : base(1f, 1.5f) { } }
public class Water : InventoryItem { public Water() : base(2f, 3f) { } }
public class FoodRations : InventoryItem { public FoodRations() : base(1f, 0.5f) { } }
public class Sword : InventoryItem { public Sword() : base(5f, 3f) { } }


