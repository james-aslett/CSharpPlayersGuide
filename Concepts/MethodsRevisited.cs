//METHODS REVISITED

//Speedrun

//A parameter can be given a default value, which then makes it optional when called: void DoStuff(int x = 4) can be called as DoStuff(2) or DoStuf (), which uses the default of 4

//You can name parameters when calling a method: DoStuff(x: 2). This allows parameters to be supplied out of order

//params lets you call a method with a variable number of arguments: DoStuff(params string[] words) can be called like DoStuff("a") or DoStuff("a", "b", "c")

//use ref or out to pass by reference, allowing a method to share a variable's memory with another and to prevent copying data: void PassByReference(ref int x) { ... } and then PassByReference(ref a);. Use out when the called method initializes the variable

//By defining a Deconstruct method (for example, void Deconstrct(out float x, out float y) { ... }), you can unpack an object into multiple variables: (float x, float y) = point;

//Extensions methods let you define static methods that appears as methods for another type: static string Extension(this string text) { ... }

//OPTIONAL ARGUMENTS
//Optional arguments let you define a default value for a parameter. If you are happy with the default, you don't need to supply an argument when you call the method. Let's say you wrote this method to simulate rolling date:
using System.Transactions;

private Random _random = new Random();
public interface RollDie(int sides) => _random.Next(sides) + 1;

//This code lets you roll the dice with any number of sides: traditional 6-sided dice, 20-sided dice, or 107-sided dice. The flexibility is nice, but what if 99% of the time, you want 6-sided dice? Your code would be peppered with RollDice(6) calls. That's not necessarily bad, but it does make you wonder if there is a better way.

//You could define an overload with no parameters and then just call the one above with a 6:
public int RollDie() => RollDie(6);

//With optional arguments, you can identify a default value where the method is defined:
public int RollDie(int sides = 6) => _random.Next(sides) + 1;

//Only one RollDie method has been defined, but it can be called in either of these ways:
RollDie();   //Uses the default value of 6
RollDie(20); //Uses 20 instead of the default

//You can have multiple parameters with an optional value, and you can mix them with normal non-optional parameters, but the optional ones must come last.

//Optional parameters should only be used when there is some obvious choice for the value or usually called with the same value. If no standard or obvious value exists, it is generally better to skip the default value.

//Default values must be compile-time constants. You can use any literal value or an expression made of literal values, but other expressions are not allowed. For example, you cannot use new List<int>() as a default value. If you need that, use an overload.

//NAMED ARGUMENTS
//When a method has many parameters or several of the same type, it can sometimes be hard to remember which order they appear in. Math's Clamp method is a good example because it has three parameters of the same type:
Math.Clamp(20, 50, 100);

//Does this clamp the value to 20 to the range of 50 to 100 or the value 100 to the range of 20 to 50? When in doubt, C# lets you write out parameter names for each argument you are passing in:
Math.Clamp(min: 50, max: 100, value: 20);

//This provides instant clarity about which argument is which, but it also allows you to supply them out of order. Math.Clamp expects value to come first, but it is last here.

//You do not have to name every argument when using this feature; you can do it selectively. But, once you start putting things out of order, you can't go back to unnamed arguments.

//VARIABLE NUMBERS OF PARAMETERS
//Look at this method that averages two numbers:
public static double Average(int a, int b) => (a + b) / 2.0;

//What if you wanted to average three numbers? We could do this:
public static double Average(int a, int b, int c) => (a + b + c) / 3.0;

//What if you wanted 5? Or 10? You could add as many overloads as you want, but it grows unwiedly fast.

//You could also make Avergae have an int[] parameter instead. But that results in uglier code when you are calling it: Average(new int[] { 2, 3}) vs. Average(2, 3).

//The params keyword gives you the best of both worlds:
public static double Average(params int[] numbers)
{
    double total = 0;

    foreach (int number in numbers)
        total += number;

    return total / numbers.Length;
}

//With that params keyword, you can now call it like this:
Average(2, 3);
Average(2, 5, 8);
Average(41, 49, 29, 2, -7, 18);

//The compiler does the hard work of transforming these methods with seemingly different parameter counts into an array.

//You can also call this version of Average with an array if that is more natural for the situation.

//You can only have one params parameter in a given method, and it must come after all normal paraters.

//COMBINATIONS
//You can combine default arguments, named arguments, and variable arguments, though I recommend getting used to each on their own before combining them.

//Default arguments and named arguments are frequently combined. Imagine a method with four parameters, where each has a reasonable default value:
public Ship MakeShip(int health = 50, int speed = 26, int rateOfFire = 2, int siize = 4) => ...

//You get a 'standard' ship by calling MakeShip() with no arguments, taking advantage of all the default values. Or you can specify a non-default value for a single, specific parameter with something like MakeShip(rateOfFire: 3). You get the custom value for the parameter you name and default values for every other parameter.

//PASSING BY REFERENCE
//As we saw in Levels 13 and 14, when calling a method, the values passed to the method are duplicated into the called method's parameters. When a value type is passed, the value is copied into the parameter. When a reference type is passed, the reference is copied into the parameter. This copying of variable contents is called passing by value. In contrast, passing by reference allows two methods to share a variable and its memory location directly. The memory address itself is handed over rather than passing copied data to a method. Passing by reference allows a method to directly affect the calling method's variables, which is powerful but risky.

//The terminology here is unfortunate. The concept of value types vs. reference type and the concept of passing by value vs. passing by reference are separate. You can pass either type using either mode. But as we'll see, passing by reference has more benefits to value types than it does to reference types.

//Passing by reference means you do not have to duplicate data when methods are called. If you are passing large structs around, or even small struct with great frequency, this can make your program run much faster.

//To make a parameter pass by reference, put the ref keyword before it:
void DisplayNumber(ref int x) => Console.WriteLine(x);

//You must also use the ref keyword when calling the method:
int y = 3;
DisplayNumber(ref y);

//Here, DisplayNumber's x parameter does not have its own storage. It is an alias for another variable. When DisplayNumber(ref y) is called, that other variable will be y.

//The primary goal is to avoid the costs of copying large value types whenever we call a method. While it achieves that goal, it comes with a steep price: the called method has total access to the caller's variables and can change them.
void DisplayNextNumber(ref int x)
{
    x++;
    Console.WriteLine(x);
}

//If the above code used a regular (non-ref) parameter, x would be a local variable with its own memory. x++ would affect only the new memory location. With ref, the memory is supplied by the calling method, and x++ will impact the calling method.

//This is typically undesirable - a cost that must be paid to get the advertised speed boosts. This risk is why you must put ref where the method is declared and where the method is called. Both sides must agree to share the variables. But sometimes, it is precisely what you want. For example, this method swaps the contents of two variables:
void Swap(ref int a, ref int b)
{
    int temporary = a;
    a = b;
    b = temporary;
}

//Due to their nature, passing by reference can only be done with a variable - something that has a memory location. You cannot just supply an expression. You cannot do this:
DisplayNumber(ref 3); //compiler error!

//Passing by reference is primarily for value types. Reference types already get most of the would-be benefits by their very nature. But reference types can also be passed by reference.

//Methods assume parameters are initialized when the method is called. You must initialize any variable that you pass by reference before calling it. The code beloe is a compiler error because y is not initialized:
int y;
DisplayNumber(ref y); // compiler error!

//OUTPUT PARAMETERS
//Output parameters are a special flavor of ref parameters. They are also passed by reference, but they are not required to be initialized in advance, and the method must initialize an output parameter before returning. Output parameters are made with the out keyword:
void SetupNumber(bool useBigNumber, out double value)
{
    value = useBigNumber ? 1000000 : 1;
}

//Which is called like this:
double x;
SetupNumber(true, out x);
double y;
SetupNumber(false, out y);

//Mechanically, output parameters work the same as reference parameters. But as you can see, neither x nor y was initialized beforehand. This code expects SetupNumber to initialize those variables instead.

//Output parameters are sometimes used to return more than one value from a method. You will find plenty of code that does this, but also consider returning a tuple or record since these sometimes create simpler code.

//When invoking a method with an output parameter, you can also declare a variable right there, instead of needing to declare it on a previous line:
SetupNumber(true, out double x);
SetupNumber(false, out double y);

//You will also encounter scenarios where the method you're calling has an output parameter that you don't care to use. Instead of a throwaway variable like junk1 or unused2, you can use a discard to ignore it:
SetupNumber(true, out _);

//One notable usage of output parameters appears when parsing text. As we saw in Level 6, most built-in types have a Parse method: int x = int.Parse("3");. If these methods are called with bad data, they crash the program. These types also have a TryParse method, whose return value tells you if it was able to parse the data and supplies the parsed number as an output parameter:
string? input = Console.ReadLine();
if (int.TryParse(input, out int value))
    Console.WriteLine($"You entered {value}");
else
    Console.WriteLine("That is not a number");

//THERE'S MORE!
//Passing  by reference is a powerful concept. You will find the occasional use for it. But what we have covered here is only scratching at the surface. The details are beyond this book, getting into the darkest corners of C#. But just so you have an idea of what else is out there in these deep, dark caverns, here are a few hints about how else passing by reference can be used.

//Most of the time, the memory location shared when passing by reference is owned by the calling method. The called method can originate a shared memory location, but how it ensures this is not straightforward. The compiler can easily enforce that you never assign a completely new value to the supplied variable. The rest is trickier. The compiler does not magically know which properties and methods will modify the object and which won't. To ensure the called method doesn't accidentially change the in parameter, it will duplicate the value into another variable and call methods and properties on the copy instead. But bypassing those duplications was a key reason for passing by reference in the first place, which somewhat defeats the purpose. To counter that, you can mark some structs and some struct methods as readonly, which tells the compiler it is safe to call the method without making a defensive copy first.

//This sharing of memory locations is also the basis for a special type called Span<T>, representing a collection that reuses some or all of another's memory.

//DECONSTRUCTORS
//With tuples, we can unpack the elements into multiple variables simultaneously:
var tuple = (2, 3);
(int a, int b) = tuple;

//You can give your types this ability by defining a Deconstruct method with a void return type and a collection of output parameters. The following could be added to any of the various Point types we have defined:
public void Deconstruct(out float x, out float y)
{
    x = X;
    y = Y;
}

//While you can invoke the Deconstruct method directly (as though it were any other method), you can also call it with code like this:
(float x, float y) = p;

//By adding Deconstruct methods, you give any type this deconstruction ability. This is especially useful for data-centric types. (Records have this automatically).

//You can define multiple Deconstruct overloads with different parameter lists.

//EXTENSION METHODS
//An extension method is a static method that can give the apperance of being attached to another type (class, enumeration, interface, etc.) as an instance method. Extension methods are useful when you want to add to a class that you do not own. They also let you add methods for things that can't or typically don't have them, such as interfaces or enumerations.

//For example, the string class has the ToUpper and ToLower methods that produce uppercase and lowercase versions of the string. If we wanted a ToAlternating method that alternates between upper/lower case with each letter, we would normally be out of luck. We don't own the string class, so we can't add this method to it. But an extension method allows us to define ToAlternating as a static method elsewhere and then use it as though it were a natural part of the string class:
public static class StringExtensions
{
    public static string ToAlternating(this string text)
    {
        string result = "";

        bool isCapital = true;
        foreach (char letter in text)
        {
            result += isCapital ? char.ToUpper(letter) : char.ToLower(letter);
            isCapital = !isCapital;
        }

        return result;
    }
}

//As shown above, an extension method must be static and in a static class. But the magic that turns it into an extension method is the this keyword before the method's first parameter. You can only do this on the first parameter.

//When you define an extention method like this, you can call it as though it were an instance method of the first parameter's type:
string message = "Hello, World!";
Console.WriteLine(message.ToAlternating());

//It is typical (but not required) to place extension methods for any given type in a class with the name [Type]Extensions. We defined an extension method for the string class, so the class was StringExtensions.

//Extension methods can have other parameters after the this parameter. They are treated as normal parameters when calling the method. So ToAlternating(this string text, bool startCapitalized) could be called with text.ToAlternating(false);

//Extension methods can only define new instance methods. You cannot use them to make extension properties or extension static methods.