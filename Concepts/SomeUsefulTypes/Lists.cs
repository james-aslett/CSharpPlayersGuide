//THE LIST<T> CLASS
//Perhaps the most versatile generic class in .NET. List<T> is a collection class where order matters, you can access items by their index, and where items can be added and removed easily. They are like an array, but their ability to grow and shrink makes them superior in virtually all circumstances. In fact, after this section, you should only rarely use arrays.

//The List<T> class is a complex class with many capabilities. We won't look at all of them, but let's look at the most important ones.

//Creating List Instances
//There are many ways to create a new list, but the most common is to make an empty list:
List<int> numbers = new List<int>();

//This makes a new List<int> instance with nothing in it. You will do this most of the time. If a list has a known set of initial values, you can also use collection initializer syntax as we did with arrays:
List<int> numbersInit = new List<int> { 1, 2, 3 };

//This calls the same empty constructor before adding the items in the collection one at a time but is an elegant way to initialize a new list with specific items. Like we saw with object initializer syntax, where we set properties on a new object, if the constructor needs no parameters, you can also leave the parentheses off:
List<int> numbers2 = new List<int> { 1, 2, 3 };

//Some people like the concisesness of that version; others find it strange. They both work.

//Indexing
//Lists support indexing, just like arrays:
List<string> words = new List<string>() { "apple", "banana", "corn", "durian" };
Console.WriteLine(words[2]);

//Lists also use 0-based indexing. Accessing index 2 gives you "corn".

//You can replace an item in a list by assigning a new value to that index, just like an array:
words[0] = "avocado";

//When we made our own List<T> class in Level 30, we didn't get this simple indexing syntax, though that was because we just didn't know the right tools yet (Level 41).

//Adding and Removing Items from List
//A key benefit of lists over arrays is the easy ability to add and remove items. For example:
List<string> words2 = new List<string>();
words2.Add("apple");

//Add puts items at the back of the list. To put something in the middle, you use Insert, which requires an index and then the item:
List<string> words3 = new List<string>() { "apple", "banana", "durian" };
words3.Insert(2, "corn");

//If you need to add or insert many items, there is AddRange and InsertRange:
List<string> words4 = new List<string>();
words4.AddRange(new string[] { "apple", "durian" });
words4.InsertRange(1, new string[] { "banana", "corn" });

//These allow you to supply a collection of items to add to the back of the list (AddRange) or insert in the middle (InsertRange). I used array to hold those collections above, though the specific type involved is the IEnumberable<T> interface, which we will discuss next. Virtually any collection type implements that interface, so you have a lot of flexibility.

//To remove items from the list, you can name the item to remove with the Remove method:
List<string> words5 = new List<string>() { "apple", "banana", "corn", "durian" };
words5.Remove("banana");

//If an item is in the collection more than once, only the first occurence is removed. Remove returns a bool that tells you whether anything was removed. If you need to remove all occurrences, you could loop until that starts returning false.

//If you want to remove the item at a specific index, use RemoveAt:
words5.RemoveAt(0);

//The Clear method removes everything in the list:
words5.Clear();

//Since we're talking about adding and removing items from a list, you might be wondering how to determine how many things are in the list. Unlike an array, which has a Length property, a list has a Count property:
Console.WriteLine(words5.Count);

//foreach Loops
//You can use a foreach loop with a List<T> as you might with an array:
foreach (Ship ship in ships)
    words5.Update();

//But there's a crucial catch: you cannot add or remove items in a List<T> while a foreach is in progress. This doesn't cause problems very often, but every so often, it is painful. For example, you have a List<Ship> for a game, and you use foreach to iterate through each and let them update. While updating, some ships may be destroyed and removed. By removing something from the list, the iteration mechanism used with foreach cannot keep track of what it has seen, and it will crash. (Specifically, it throws an InvalidOperationException; exceptions are covered in Level 35.)

//There are two workarounds for this. One is to use a plain for loop. Using a for loop and retrieving the item at the current index lets you sidestep the iteration mechanism that a foreach loop uses:
for (int index = 0; index < ships.Count; index++)
{
    Ship ship = ships[index];
    ship.Update();
}

//If you add or remove items further down the list (at an index beyond the current one), there are not generally complications to adding and removing items as you go. But if you add or remove an item before the spot you are currently at, you will have to account for it. If you are looking at the item at index 3 and insert at index 0, then what was once index 3 is now index 4. If you remove the item at index 0, then index 3 becomes index 2. You can use ++ and -- to account for this, but it is a tricky situation to avoid if possible:
for (int index = 0; index < ships.Count; index++)
{
    Ship ship = ships[index];
    ship.Update();
    if (ship.IsDead)
    {
        ships.Remove(ship);
        index--;
    }    
}

//Another workaround is to hold off on the actual addition or removal during the foreach loop. Instead, remember which things should be added or removed by placing them in helper lists like toBeAdded and toBeRemoved. After the foreach loop, go through the items in those two helper lists and use List<T>'s Add and Remove methods to do the actual adding and removing.

//Other useful things
//The Contains method tells you if the list contains a specific item, returning true if it is there and false if not:
bool hasApples = words.Contains("apple");
if (hasApples)
    Console.Write("Apples are already on the shopping list!");

//The IndexOf method tells you where in a list an item can be found, or -1 if it is not there:
int index = words.IndexOf("apple");

//The List<T> class has quite a bit more than we have discussed here, though we have covered the highlights. At some point, you will want to use Visual Studio's AutoComplete feature or look it up on docs.microsoft.com and see what else it is capable of.
