//SOME USEFUL TYPES

//RANDOM
//Generates random numbers. These start with an initial value called a seed. If you reuse the same seed you will get the same random-looking sequence again. Minecraft generates a world based on a seed. Sometimes you want a specific random world, and by telling Minecraft to use a specific seed, you can get the same world again. But most of the time, you want a random seed to get a unique world.

//The System.Random class is the starting point for anything involving randomness. It is a simple class that is easy to learn how to use:
Random random = new Random();
Console.WriteLine(random.Next());

//The Random() constructor is initialized with an arbiturary seed value, which means you will not see the same sequence come up ever again with another Random object or by rerunning the program.

//Random's most basic method is the Next() method. Next picks a random non-negative int with equal chances of each. You are just as likely to get 7 as 1,844,349,103. Such a large range is rarely useful, so a couple of overloads of Next give you more control. Next(int) lets you pick the ceiling:
Console.WriteLine(random.Next(6));

//random.Next(6) will give you 0, 1, 2, 3, 4, or 5 (but not 6) as possible choices, with equal chances of each. It is common to add 1 to this result so that the range is 1 through 6 instead of 0 through 5. For example:
Console.WriteLine($"Rolling a six-sided die: {random.Next(6) + 1}");

//The third overload of Next allows you to name the minimum value as well:
Console.WriteLine(random.Next(18, 22));

//This will randomly pick from the values 18, 19, 20, and 21 (but not 22). If you want floating-point values instead of integers, you can use NextDouble():
Console.WriteLine(random.NextDouble());

//This will give you a double in the range of 0.0 to 1.0 (strictly speaking, 1.0 won't ever come up, but 0.9999999 can). You can stretch this out over a larger range with some simple arithmetic. The following will produce random numbers in the range 0 to 10:
Console.WriteLine(random.NextDouble() * 10);

//And this will produce random numbers in the range -10 to +10:
Console.WriteLine(random.NextDouble() * 20 - 10);

//The Random class also has a constructor that lets you pass in a specific seed:
Random random2 = new Random(3445);
Console.WriteLine(random2.Next());

//This code will always display the same output because the seed is always 3445, which lets you recreate a random sequence of numbers.

//THE DATETIME STRUCT
//Stores moments in time and allows you to get the current time. One way to create a DateTime value is with its constructors:
DateTime time1 = new DateTime(2022, 12, 31);
DateTime time2 = new DateTime(2022, 12, 31, 23, 59, 55);

//This creates a time at the start of 31 Dec 2022 and at 11:59:55 on 31 Dec 2022. There are a total of 12 constructors for Datetime.

//Perhaps even more useful are the static DateTime.Now and DateTime.UtcNow properties:
DateTime nowLocal = DateTime.Now;
DateTime nowUtc = DateTime.UtcNow;

//DateTime.Now is in your local time zone, as determined by your computer. DateTime.UtcNow gives you the current time in Coordinated Universal Time or UTC, which is essentially a wordwide time, not specific to time zones, daylight saving time, etc.

//A DateTime value has various properties to see the year, month, day, hour, minute, second and millisecond, among other things. The following illustrates some simple uses:
DateTime time = DateTime.Now;
if (time.Month == 10) Console.WriteLine("Happy Halloween!");
else if (time.Month == 4 && time.Day == 1) Console.WriteLine("April Fools!");

//There are also methods for getting new DateTime values relative to another. For example:
DateTime tomoroww = DateTime.Now.AddDays(1);

//The DateTime struct is very smart, handling many easy-to-forget edge cases, such as leap years and day-of-the-week calculations. When dealing with dates and times, this is your go-to struct to represent and get the current date and time.

//THE TIMESPAN STRUCT
//Represents a span of time. You can create values of the TimeSpan in one of two wats. Several constructors let you dictate the length of time:
TimeSpan timeSpan1 = new TimeSpan(1, 30, 0); //1 hour, 30 minutes, 0 seconds
TimeSpan timeSpan2 = new TimeSpan(2, 12, 0, 0); //2 days, 12 hours
TimeSpan timeSpan3 = new TimeSpan(0, 0, 0, 0, 500); //500 milliseconds
TimeSpan timeSpan4 = new TimeSpan(10); //10 'ticks' == 1 microsecond

//After reading the comments, most of these are straightforward, but the last one is notable. Internally, a TimeSpan keeps track of time in a unit called a tick, which is 0.1 microseconds or 100 nanoseconds. This is as fine-grained as a TimeSpan can get, but you rarely need more.

//The other way to create TimeSpans is with one of the various FromX methods:
TimeSpan aLittleWhile = TimeSpan.FromSeconds(3.5);
TimeSpan quiteAWhile = TimeSpan.FromHours(1.21);

//The whole collection includes FromTicks, FromMilliseconds, FromSeconds, FromHours, and FromDays.

//TimeSpan has two sets of properties worth mentioning. First is this set: Days, Hours, Minutes, Seconds, Milliseconds. These represent the various components of the TimeSpan, for example:
TimeSpan timeLeft = new TimeSpan(1, 30, 0);
Console.WriteLine($"{timeLeft.Days}d {timeLeft.Hours}h {timeLeft.Minutes}m");

//timeLeft.Minutes does not return 90, since 60 of those come from a full hour, represented by the Hours property.

//Another set of properties capture the entire timespan in the unit requested: TotalDays, TotalHours, TotalMinutes, TotalSeconds, TotalMilliseconds.
TimeSpan timeRemaining = new TimeSpan(1, 30, 0);
Console.WriteLine(timeRemaining.TotalHours);
Console.WriteLine(timeRemaining.TotalMilliseconds);

//This will display 1.5 | 90

//Both DateTime and TimeSpan have defined several operators (Level 41) for things like comparison (>, <, >=, <=), addition, and subtraction. Plus, the two structs play nice together:
DateTime eventTime = new DateTime(2022, 12, 4, 5, 29, 0); // 4 Dec 2022 at 5:29am
TimeSpan timeLeft2 = eventTime - DateTime.Now;
// 'TimeSpan.Zero' is no time at all
if (timeLeft2 > TimeSpan.Zero) Console.WriteLine($"{timeLeft2.Days}d {timeLeft2.Hours}h {timeLeft2.Minutes}m");
else Console.WriteLine("This event has passed");

//The second line shows that substracting one DateTime from another results in a TimeSpan that is the amount of time between the two. The if statement shows a comparison against the special TimeSpan.Zero value.

//THE GUID STRUCT
//Represents a globally unique identifier or GUID. You may find value in giving objects or items a unique identifier to track them independently from other similar objects in certain programs. This is especially true if you send information across a network, where you can't just use a simple reference. While you could use an int or long as unique numbers for these objects, it can be tough to ensure that each item has a truly unique number. This is especially true if different computers have to create the unique number. This is where the Guid struct comes in handy.

//The idea is that if you have enough possible choices, two people picking at random won't pick the same thing. If all of humanity had a beach party and each of us went and picked a grain of sand on the beach, the chance that any of us would pick the same gran is vanishingly small. The generation of new identifiers with the Guid struct is similar.

//To generate a new arbitrary identifier, you use the static Guid.NewGuid() method:
Guid id = Guid.NewGuid();

//Each Guid value is 16 bytes (4 times as many as an int), ensuring plenty of available choices. But NewGuid() is smarter than just picking a random number. It has smarts built in that ensure that other computers won't pick the same value and that multiple calls to NewGuid() won't even give you the same number again, maximising the chance of uniqueness.

//A Guid is just a collection of 16 bytes, but is is usually written in hexadecimal with dashes breaking it into smaller chunks like this: 10A24E2-3008-4678-AD86-FCCCDA8CE868. Once you know about GUIDs, you will see them pop up all over the place.

//If you already have a GUID and do not want to generate a new one, there are other constructors that you can use to build a new Guid value that represents it. For example:
Guid id2 = new Guid("10A24E2-3008-4678-AD86-FCCCDA8CE868");

//Just be careful about inadvertently reusing a GUID in situations that could cause conflicts. Copying and pasting GUIDs can lead to accidental reuse. Visual Studio has a tool to generate a random GUID under Tools > Create GUID, and you can find similar things online.

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

//THE IENUMERABLE<T> INTERFACE
//While List<T> might be the most versatile generic type, IEnumerable<T> might be the most foundational. This simple interface essentially defines what counts as a collection in .NET.

//IEnumerable<T> defines a mechanism that allows you to inspect items one at a time. This mechanism is the basis for a foreach loop. If a type implements IEnumberable<T>, you can use it in a foreach loop.

//IEnumberable<T> is anything that can provide an 'enumerator', and the definition looks something like this:
public interface IEnumberable<T>
{
    IEnumerator<T> GetEnumerator();
}

//But what's an enumerator? It is a thing that lets you look at items in a set, one at a time, with the ability to start over. It is defined roughly like this:
public interface IEnumerator<T>
{
    T Current { get; }
    bool MoveNext();
    void Reset();
}

//The Current property lets you see the current item. The MoveNext method advances to the next item and returns whether there even is another item. Reset starts over from the beginning. Almost nobody uses an IEnumerator<T> directly. They let the foreach loop deal with it. Consider this code:
List<string> fruits = new List<string> { "apple", "banana", "corn", "durian" };

foreach (string fruit in fruits)
    Console.WriteLine(fruit);

//That is equivalent to:
List<string> fruits2 = new List<string> { "apple", "banana", "corn", "durian" };
IEnumerator<string> iterator = fruits2.GetEnumerator();

while (iterator.MoveNext())
{
    string fruit = iterator.Current;
    Console.WriteLine(fruit);
}

//List<T> and arrays both implement IEnumberable<T>, but dozens of other collection types also implement this interface. It is the basis for all collection types. You will see IEnumberable<T> everywhere.

//THE DICTIONARY<TKEY, TVALUE> CLASS
//Sometimes, you want to look up one object or piece of information using another. A dictionary (also called an associative array or a map in other programming languages) is a data type that makes this possible. A dictionary provides this functionality. You add new items to the dictionary by supplying a key to store the item under, and when you want to retrieve it, you provide the key again to get the item back out. The value stored and retrieved via the key is called the value.

//The origin of the name - and an illustrative example - is a standard English dictionary. Dictionaries store words and their definitions. For any word, you can look up its definition in the dictionary. If we wanted to make an English dictionary in C# code, we could use the generic Dictionary<TKey, TValue> class:
Dictionary<string, string> dictionary = new Dictionary<string, string>();

//This type has two generic type parameters, one for the key type and one for the value type. Here, we used string for both.

//We can add items to the dictionary using the indexing operator with the key instead of an int:
dictionary["battleship"] = "a large warship with big guns";
dictionary["cruiser"] = "a fast but large warship.";
dictionary["submarine"] = "a ship capable of moving under the water's surface";

//To retrieve a value, you can also use the indexing operator:
Console.WriteLine(dictionary["battleship"]);

//This will display the string "a large warship with big guns".