//SPEEDRUN
//Generics solve the problem of making classes or methods that would differ only by the types they use. Generics leave placeholders for types that can be filled in when used
//Defining a generic class: public class List<T> { public T GetItemAt(int index) { ... } ... }
//You can also make generic methods and generic types with multiple type parameters
//Constraints allow you to limit what can be used for a generic type argument while enabling you to know more about the types being used: class List<T> where T : IsSomeInterface { }

//We'll look at a powerful feature in C# called generics (generic types and generic methods) in this level. We'll start with the problem this feature solves and then see how generics solve it. In Level 32, we'll see a few existing generic types that will make your life a lot easier.

//THE MOTIVATION FOR GENERICS
//By now, you've probably noticed that arrays have a bit limitation: you can't easily change their size by adding and removing items. The best you can do is copy the contents of the array to a new array, making any necessary changes in the process, and then update your array variable:
int[] numbers = new int[] { 1, 2, 3 };
numbers = AddToArray(numbers, 4);

int[] AddToArray(int[] input, int newNumber)
{
    int[] output = new int[input.Length + 1];

    for (int index = 0; index < input.Length; index++)
        output[index] = input[index];

    output[^1] = newNumber;

    return output;
}

//With your understanding of objects and classes, you might say to yourself, "I could make a class that handles this for me. Then whenever I need it, I can just use the class instead of an array, and growing and shrinking the collection will happen automatically." Indeed, this would make a great reusable class. What an excellent idea! You start with this:
public class ListOfNumbers
{
    private int[] _numbers = new int[0];

    public int GetItemAt(int index) => _numbers[index];
    public void SetItemAt(int index, int value) => _numbers[index] = value;

    public void Add(int newValue)
    {
        int[] updated = new int[_numbers.Length + 1];

        for (int index = 0; index < _numbers.Length; index++)
            updated[index] = _numbers[index];

        updated[^1] = newValue;

        _numbers = updated;
    }
}

//This ListOfNumbers class has a field that  is an int array. It includes methods for getting and setting items at a specific index in the list. Also, it includes an Add method, which tacks a new int to the end of the collection, copying everything over to a new, slightly longer array, and placing the new value at the end. The code in Add is essentially the same as our AddToArray method earlier. I won't add code for removing an item, but you could do something similar.

//Now we can use the class like this:
ListOfNumbers numbers = new ListOfNumbers();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
Console.WriteLine(numbers.GetItemAt(2));

//This is a better solution because it is object-oriented. Instead of having a loose array and a loose method to work with it, the two are combined. The class handles growing the collection as needed, and the outside world is free to assume it does the job assigned to it. And it is reusable! With this class defined, any time we want a growable collection of ints, we make a new instance of ListOfNumbers, and off we go.

//I do have one complaint. With arrrays, you can use the indexing operator. numbers[0] is cleaner than numbers.GetItemAt(0). We can solve that problem with the tools we'll learn in Level 41. For now, we'll just live with it.

//However, there's a second, more substantial problem. We can make instances of ListOfNumbers whenever we want, but what if we need it to be strings instead? ListOfNumbers is built around ints. It is useless if we need the string type.

//Using only tools we already know, we have two options. We could just create a ListOfStrings class:
public class ListOfStrings
{
    private string[] _strings = new string[0];

    public string GetItemAt(int index) => _strings[index];
    public void SetItemAt(int index, string value) => _strings[index] = value;

    public void Add(string newValue) { /* Details skipped */ }
}

//This has potential, although it isn't great. What if we need a list of bools? A list of doubles? A list of points? A list of int[]? How many of these do we make? We would have to copy and paste this code repeatedly, making tiny tweaks to change the type each time. In Level 23, we said that designs with duplicate code are worse than ones that do not. This approach results in a lot of duplicate code. Imagine making 20 of these, only to discover a bug in them!

//The second approach would be just to use object. With object, we can use it for anything:
public class List
{
    private object[] _items = new object[0];

    public object GetItemAt(int index) => _items[index];
    public void SetItemAt(int index, object value) => _items[index] = value;

    public void Add(object newValue) {  /* Details skipped */ }
}

//Which could get used like this:
List numbers = new List();
numbers.Add(1);
numbers.Add(2);

List words = new List();
numbers.Add(1);
numbers.Add("Hello");

//Unfortunately, this also has a couple of big drawbacks. The first is that the GetItemAt method (and others) return an object, not an int or a string. We must cast it:
int first = (int)numbers.GetItemAt(0);

//The second drawback is that we have thrown out all type checking that the compiler would normally help us with. Consider this code, which compiles but isn't good:
List numbers = new List();
numbers.Add(1);
numbers.Add("Hello");

//Do you see the problem? From it's name, numbers should contain only numbers. But we just dropped a string into it. The compiler cannot detect this because we are using object, and string is an object. This code won't fail until you cast it to an int, expecting it to be one, only to discoveer it was a string.

//Neither of these solutions is perfect. But this is where generics save the day.

//DEFINING A GENERIC TYPE
//A generic type is a type definition (class, struct, or interface) that leaves a placeholder for some of the types it uses. This is conceptually similar to making methods with parameters, allowing the outside world to supply a value. The easiest way to show a generic type is with an example of a generic List class:
public class List<T>
{
    private T[] _items = new T[0];

    public T GetItemAt(int index) => _items[index];
    public void SetItemAt(int index, T value) => _items[index] = value;

    public void Add(T newValue)
    {
        T[] updated = new T[_items.Length + 1];

        for (int index = 0; index < updated.Length; index++)
            updated[index] = _items[index];

        updated[^1] = newValue;

        _items = updated;
    }
}

//Before going further, I am going to interrupt with an important note. The code above defines our own custom generic List class. You might be thinking, "I can use something like this!" But there is already an existing generic List class that does all of this and more, is well tested, and is optimized. This code illustrates generic types, but once we learn about the official List<T> class (Level 32), we should be using that instead. Now back to our discussion.

//When defining the class, we can identify a placeholder for a type in angle brackets (that <T> thing). This placeholder type is called a generic type parameter. Is it like a method parameter, except it works at a higher level and stands in for a specific type that will be chosen later. It can be used throughout the class, as is done in several places in the above code. When this List<T> class is used, that code will supply the specific type it needs insread of T. For example:
List<int> numbers = new List<int>();
numbers.Add(1);
numbers.Add(2);

//In this case, int is used as the generic type argument (like passing an argument to a method when you call it). Here, int will be used in all the places that T was listed. That means that Add method will have an int parameter, and GetItemAt will return an int.

//Without defining additional types, we can use a different type argument such as string:
List<string> words = new List<string>();
words.Add("Hello");
words.Add("World");

//Importantly, this potential problem is now caught by the compiler:
words.Add(1); //ERROR!

//The variable words is a List<string> , not a List<int>. The compiler can recognize the type-related issue and flag it. We have created the best of both worlds: we only need to create a single type but can still retain type safety.

//By the way, many C# programmers will read orr pronounce List<T> as "list of T" and List<int> and "list of int".

//There was nothing magical about the name T. We could have called it M, Type, or  _wakawaka. However, there are two conventions for type names: single, capital letters (T, K, V, etc.) or a captial T followed by some more descriptive word or phrase, like TItem. If you only have a single generic type parameter, T is virtually universal.

//MULTIPLE GENERIC TYPE PARAMETERS
//You can also have multiple generic type parameters by listing them in the angle brackets, separated by commas:
public class Pair<TFirst, TSecond>
{
    public TFirst First { get; }
    public TSecond Second { get; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }
}

//Which could be used like this:
Pair<string, double> namedNumber = new Pair<string, double>("pi", 3.1415926535);
Console.WriteLine($"{namedNumber.First} is {namedNumber.Second}");

//Generic types can end up with rather complicated names. Pair<string, double> is a long name, and it could be worse. Instead of string, it could be a List<string> or even another Pair<int, int>. This results in nested generic types with extremely long names: Pair<Pair<int, int>, double>.  While I have been avoiding var for clarity in this book, long, complex names like this are why some people prefer var or new() (without listing the type); without it, this complicated name shows up twice, making the code hard to understand.

//INHERITANCE AND GENERIC TYPES
//Generic classes and inheritance can be combined. A generic class can derive from normal non-generic classes or other generic classes, and normal classes can be derived from generic classes. When doing this, you have some options for handling generic types in the base class. The simplest thing is just to keep the generic type parameter open:
public class FancyList<T> : List<T>
{
    //... 
}

//The base class's generic type parameter stays as a generic type parameter in the derived class. Or a derived class can close the generic type parameter, resulting in a derived class that is no longer generic:
public class Polygon: List<Point>
{
    //...
}

//With this definition, Polygon is a subtype of List<Point>, but you cannot make polygons using anything besides Point. The genreric-ness is gone.

//Of course, you can close some generic types, leave others open, and simultaneously introduce additional generic type parameters. Tricky situations like these are rare, though.

//GENERIC METHODS
//Sometimes it isn't a type that needs to be generic but a single method. You can define generic methods by putting generic type parameters after a method's name but before its parentheses:
public static List<T> Repeat<T>(T value, int times)
{
    List<T> collection = new List<T>();

    for (int index = 0; index < times; index++)
        collection.Add(value);

    return collection;
}

//You can use generic type parameters for method parameters and return types, as shown above. You can then use this like so:
List<string> words = Repeat<string>("Alright", 3);
List<int> zeroes = Repeat<int>(0, 100);

//Generic methods do not have to live in a generic type. They can, and often are, defined in regular non-generic types.

//When using a generic method, the compiler can often infer the types you use based on the parameters you pass into the method itself. For example, because Repeat<string>("Alright", 3) passes in a string as the first parameter, the compiler can tell that you want to use string as your generic type argument, and you can leave it out:
List<string> words = Repeat("Alright", 3);

//You usually only need to list the generic type argument when the compiler either can't infer the type or is inferring the wrong type.

//GENERIC TYPE CONSTRAINTS
//By default, any type can be used as an argument for a generic type parameter. The tradeoff is that within the generic type, little is known about what type will be used, and therefore, the generic type can do little with it. For our List<T> class, this was not a problem. It was just a container to hold several items of the same type. On the other hand, if we constrain or limit the possible choices, we can know more about the type being used and do things with it.

//To show an example, let's go back to our Asteroids type hierarchy. We had several different classes that all derived from a GameObject class. Let's say GameObject had an ID property used to identify each thing in the game uniquely:
public abstract class GameObject
{
    public int ID { get; }
    //...
}

//If we give a generic type a constraint that it must be derived from GameObject, then we will know that it is safe to use any of the members GameObject defines:
public class IDList<T> where T : GameObject
{
    private T[] items = new T[0];

    public T? GetItemByID(int idToFind)
    {
        foreach (T item in items)
            if (item.ID == idToFind)
                return item;

        return null;
    }

    public void Add(T newValue) { /* ... */ }
}

//That 'where T : GameObject' is called a generic type contraint. It allows you to limit what type arguments can be used for the given type parameter. IDList is still a generic type. We can create an IDList<Asteroid> that ensures only asteroids are added or an IDList<Ship> that can only use ships. But we can't make an IDList<int> since int isn't derived from GameObject. We reduce how generic the IDlist class is but increase what we have know about things going into it, allowing us to do more with it.

//If you have several type parameters, you can contrain each of them with their own where:
public class GenericType<T, U> where T : GameObject
                               where U : Asteroid

{
    //...
}

//There are many different contraints you can place on a generic type parameter. The above, where you list another type that the argument must derive from, is perhaps the simplest.

//You can also use the class and struct constraints to demand that the argument be either a class (or a reference type) or a struct (or a value type): where T : class. The class constraint will assume usages of the generic type parameter do not allow null as an option. By comparison, the class? constraint will assume usages of the generic type parameter allow null as an option.

//There is also a new() contraint (where T : new()), which limits you to using only types that have a parameterless constructor. This allows you to create new instances of the generic type parameter (new T()). Interestingly, there is no option for other constructor constraints. The parameterless constructor is the only one.

//You can also define constraints in relation to other generic type parameters if you have more than one: public class Generic<T, U> where T : U { //... }, or even where T : IGenericInterface<U>. This is rare but useful in situations that need it.

//Three other constraints deal with future topics. The unmanaged constraint demands that the thing be an unmanaged type (Level 46). The struct? allows for nullable structs (Level 32). The nonnull contraint is like a combination of class and struct constraints (without the question marks), allowing for anything that is not null.

//You don't need to memorize all of these different constraints. You'll spend far more time working with generic types than making them (Level 32). When you make a generic type, most of the time, you either won't have any constraints or use a simple where T : SomeSpecificType. Just remember that there are many kinds of constraints, giving you control of virtually any important aspect of the types being used as a generic type argument.

//MULTIPLE CONSTRAINTS
//You can define multiple constraints for each generic type parameter by separating them with commas. For example, the following requires T to have a parameterless constructor and to be a GameObject:
public class Factory<T> where T : GameObject, new() { /*...*/ }

//Within this Factory<T> class, you would be able to create new instances of T because of the new() constraint and use any properties or methods on GameObject, such as ID, because of the GameObject constraint. Each constraint limits what types can be used for T and gives you more power within the class to do useful stuff with T because you know more about it.

//Not every constraint can be combined with every other constraint. This limitation is either because two constraints conflict or one is made redundant by another. For example, you can't use both the class and struct constraints simultaneously. Also, you can't combine the struct and new() constraints because the struct constraint already guarantees you have a public, parameterless constructor.

//The ordering of generic type constraints also matters. For example, calling out a specific type (like GameObject above) is expected to come first, while new() must be last. The rules are hard to describe and remember; it is usually easiest to just write them out and let the compiler point out any problems. In truth, you will only rarely run into issues like this; multiple generic type constraints are rare.

//CONSTRAINTS ON METHODS
//Generic type constraints can also be applied to methods by listing them after the method's parameter list but before its body:
public static List<T> Repeat<T>(T value, int times) where T : class { /*...*/ }

//THE DEFAULT OPERATOR
//When using generic types, you may find some uses for the default operator, which allows you to get the default value for any type. (This isn't just limited to generic types and methods, but it is perhaps the most useful place.)

//The basic form of this operator is to place the name of the type in parentheses after it. The result will be the default value for that type. For example, default(int) will evaluate to 0, default(bool) will evaluate to false, and default(string) will evaluate to null.

//However, in most cases, a simple 0, false, or null is simpler code that doesn't leave people scratching their heads to remember if the default for bool was true or false. If the type can be inferred, you can leave out the type and parentheses and just use a plain default.

//Where default shows its power is with generics. default(T) will produce the default regardless of what type T is. If we go back to our Pair<TFirst, TSecond>, we could make a constructor that uses default values:
public Pair()
{
    First = default; // Or default(TFirst), if the compiler cannot infer it
    Second = default; // Or default(TSecond), if the compiler cannot infer it
}

//This seems more useful than it is. You still know nothing about the value you just created, so you can do little with it afterward. But it does have its occassional time and place.