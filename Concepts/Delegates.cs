﻿//DELEGATES

//Speedrun
//A delegate is a variable that stores methods, allowing them to be passed around like an object
//Define delegates like this: public delegate float NumberDelegate(float number); This identifies the return type and parameter list of the new delegate type
//Assign values to delegate variables like this: NumberDelegate d = AddOne;
//Invoke the method stored in a delegate variabe: d(2), or d.Invoke(2)
//Action, Func, and Predicate are pre-defined generic delegate types that are flexible enough that you rarely have to build new delegate types from scratch
//Delegates can refer to multiple methods if needed, and each method will be called in turn

//DELEGATE BASICS
//A delegate is a variable that holds a reference to a method or function. This feature allows you to pass around chunks of executable code as though it were simple data. That may not seem like a big deal, but it is a game-changer. Delegates are powerful in their own right but also serve as a basis of many other powerful C# features.
//Let's look at the type of problem they help solve. Suppose you have this method, which takes an array of numbers and produces a new array where every item has been incremented. If the array [1, 2, 3, 4, 5] is passed in, the result will be [2, 3, 4, 5, 6]:

int[] AddOneToArrayElements(int[] numbers)
{
    int[] result = new int[numbers.Length];

    for (int index = 0; index < result.Length; index++)
        result[index] = numbers[index] + 1;

    return result;
}

//What if we also need a method that subtracts one instead? Not a big deal:

int[] SubtractOneFromArrayElements(int[] numbers)
{
    int[] result = new int[numbers.Length];

    for (int index = 0; index < result.Length; index++)
        result[index] = numbers[index] - 1;

    return result;
}

//These two methods are identical except for the code that computes the new array's value from the original value. You could create both methods and call it day, but that is not ideal. It is a large chunk of duplicated code. If you needed to fix a bug, you'd have to do so in two places.

//We could maybe add another parameter to indicate how much to change the number:

int[] ChangeArrayElements(int[] numbers, int amount)
{
    int[] result = new int[numbers.Length];

    for (int index = 0; index < result.Length; index++)
        result[index] = numbers[index] + amount;

    return result;
}

//To add or subtract, we could call ChangeArrayElements(numbers, +1) and ChangeArrayElements(number, -1). But there is only so much flexibility we can get. What if we wanted a similar method that doubled each item or computed each item's square root?

//To give the calling method the most flexibility, we can ask it to supply a method to use instead of adding a specific number.

//This is easier to illustrate with an example. Let's start by defining the methods AddOne, SubtractOne, and Double:

int AddOne(int number) => number + 1;
int SubtractOne(int number) => number - 1;
int Double(int number) => number * 2;

//These methods have the same parameter list (a single int parameter) and the same return type (also an int). That similarity is essential; it is what will make them interchangeable. The next step is for us to give a name to this pattern by defining a delegate type:

public delegate int NumberDelegate(int number);

//This defines a new type, like defining a new enumeration or class. Defining a new delegate type requires a return type, a name, and a parameter list. In this sense, it looks like a method declaration, aside from the delegate keyword.

//Variables that use delegate types can store methods. But the method must match the delegate's return type and parameter types to work. A variable whose type is NumberDelegate can store any method with an int return type and a single int parameter. Lucky for us, AddOne, SubstractOne and Double all meet these conditions. That means we can make a variable that can store a reference to any of them.

//There are three parts to using a delegate: making a variable of that type, assigning it a value, and then using it.

//Any variable can use a delegate for its type, just like we saw with enumerations and classes. We can make a method with a parameter whose type is NumberDelegate, which will allow callers of the method to supply a different method to invoke when the time is right:

int[] ChangeArrayElements(int[] numbers, NumberDelegate operation) { ... }

//To call ChangeArrayElements with the delegate, we name the method we want to use:

ChangeArrayElements(new int[] { 1, 2, 3, 4, 5 }, AddOne);

//Note the lack of parentheses! With parentheses, we'd be invoking the method and passing its return value. Instead, we are passing the method itself by name.

//If the method is an instance method, you can name the object with its method:

SomeClass thing = new SomeClass();
ChangeArrayElements(new int[] { 1, 2, 3, 4, 5 }, this.DoIt);

//The C# compiler is smart enough to keep track of the fact that the delegate must store a reference to this instance (thing) and know which method to call (DoIt).

//On rare occassions, the compiler may struggle to understand what you are doing. In these cases, you may need to be more formal with something like this:

ChangeArrayElements(new int[] { 1, 2, 3, 4, 5 }, new NumberDelegate(AddOne);

//That shouldn't happen very often, though.

//Let's see howw ChangeArrayElements would use this delegate-typed variable. Because a delegate holds a reference to a method, you will eventually want to invoke the method. There are two ways to do this. The first is shown here:

int[] ChangeArrayElements(int[] numbers, NumberDelegate operation)
{
    int[] result = new int[numbers.Length];

    for (int index = 0; index < result.Length; index++)
        result[index] = operation(numbers[index]);

    return result;
}

//You can invoke the method in a delegate variable by using parentheses. Invoking a method in a delegate-typed variable looks like a typical method call, except perhaps the capitalization. (Most methods in C# start with a capital letter. Most parameters do not).

//The second way is to use the delegate's Invoke method:

return[index] = operation.Invoke(numbers[Index]);

//These are the same thing for all practical purposes, though the second option allows you to check for null with a simple operation?.Invoke(numbers[index]).

//By looking at this code, you can see why delegates are called that. ChangeArrayElements know how to iterate through the array and build a new array, but it doesn't understand how to compute new values from old values. It expects somebody else to do that work, and when the time comes, it delegates that job to the delegate object.

//Delegates can significantly increase the flexibility of sections of code. It can allow you to define algorithms with replaceable elements in the middle, filled in by other methods via delegates. That makes them a valuable tool to add to your C# toolbox.

//The action, func and predicate delegates

//In that last section, we defined a new delegate type to use in our program. That has its uses - if you want a specific name given to a method pattern - but if you play your cards right, you won't have to define new delegate types often. The Base Class Library contains a flexible and extensive collection of delegate types that cover most scenarios.

//