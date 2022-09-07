﻿//METHODS REVISITED

//Speedrun

//A parameter can be given a default value, which then makes it optional when called: void DoStuff(int x = 4) can be called as DoStuff(2) or DoStuf (), which uses the default of 4

//You can name parameters when calling a method: DoStuff(x: 2). This allows parameters to be supplied out of order

//params lets you call a method with a variable number of arguments: DoStuff(params string[] words) can be called like DoStuff("a") or DoStuff("a", "b", "c")

//use ref or out to pass by reference, allowing a method to share a variable's memory with another and to prevent copying data: void PassByReference(ref int x) { ... } and then PassByReference(ref a);. Use out when the called method initializes the variable

//By defining a Deconstruct method (for example, void Deconstrct(out float x, out float y) { ... }), you can unpack an object into multiple variables: (float x, float y) = point;

//Extensions methods let you define static methods that appears as methods for another type: static string Extension(this string text) { ... }

//OPTIONAL ARGUMENTS
//Optional arguments let you define a default value for a parameter. If you are happy with the default, you don't need to supply an argument when you call the method. Let's say you wrote this method to simulate rolling date:
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