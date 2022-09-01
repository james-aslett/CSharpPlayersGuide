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

//If you reuse a key, the new value replaces the first:
dictionary["carrier"] = "a ship that carries stuff";
dictionary["carrier"] = "a ship that serves as a floating runway for aircraft";
Console.WriteLine(dictionary["carrier"]);

//This displays the second definition, the first is gone.

//What if you try to retrieve the item with a key that isn't in the dictionary?
Console.WriteLine(dictionary["gunship"]);

//This blows up. (Speicifically, it throws a KeyNotFoundException, a topic we will learn in Level 35.) We can get around this by asking if a dictionary contains a key before retrieving it:

if (dictionary.ContainsKey("gunship"))
    Console.WriteLine(dictionary["gunship"]);

//Or we could ask it to use a fallback value with the GetValueOrDefault method:
Console.WriteLine(dictionary.GetValueOrDefault("gunship", "unknown"));

//If you want to remove a key and its value from the dictionary, you can use the Remove method:
dictionary.Remove("battleship");

//This returns a bool that indicates if anything was removed.

//Once again, there is more to Dictionary<TKey, TValue> than we can cover here, though we have covered the most essential parts.

//Types Beside a String
//Dictionaries are generic types, so they can use anything you want for key and value types. String are not uncommon, but they are certainly not the only or even primary usage.

//For example, we might create a WordDefinition class that contains the definition, an example sentence , and the part of a speech, and then use that in a Dictionary:
var dictionary2 = new Dictionary<string, WordDefinition>();

//The key here is still a string, while the values are WordDefinition instances. So you still look up items with dictionary["battleship"] but get a WordDefinition instance out.

//Or perhaps we have a collection of GameObject instances (maybe this is the base class of all the objects in a game we're making), and each instance has an ID that is an int. We could store these in a dictionary as well, allowing us to look up he game objects by their ID:
Dictionary<int, GameObject> gameObjects = new Dictionary<int, GameObject>();

//If GameObject has an ID property, you could add an item to the dictionary like this:
gameObjects[ship.ID] = ship;

//This code is a good illustration of the power of generic types. We have lots of flexibility within dictionaries, which stems from our ability to pick any key or type value.

//Dictionary Keys Should Not Change
//Dictionaries use the hash code of the key to store and locate the object in memory. A hash code is a special value determined by each object, as returned by GetHashCode(), defined by object. You can override this, but for a reference type, this is based on the reference itself. For value types, it is determined by combining the hash code of the fields that compose it. Once a key has been placed in a dictionary, you should do nothing to cause its hash code to change to a different hash code. That would make it so the dictionary cannot recover the key, and the key and the object are lost for all practical purposes.

//If a key is immutable, it guarantees you won't have any problems. Types like int, char, long, and even string are all immutable, so they are safe. If a reference type, like a class, uses the default behaviour, you should also be safe. But if somebody has overridden GetHashCode, which is often done if you redefined Equals, == and !=, take care not to change the key object in ways that would alter its hash code.