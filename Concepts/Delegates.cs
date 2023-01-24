//DELEGATES

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

//using System.Reflection.Metadata.Ecma335;

//int[] AddOneToArrayElements(int[] numbers)
//{
//    int[] result = new int[numbers.Length];
/
//    for (int index = 0; index < result.Length; index++)
//        result[index] = numbers[index] + 1;
//
//    return result;
//}

//What if we also need a method that subtracts one instead? Not a big deal:

//int[] SubtractOneFromArrayElements(int[] numbers)
//{
//    int[] result = new int[numbers.Length];
//
//    for (int index = 0; index < result.Length; index++)
//        result[index] = numbers[index] - 1;
//
//    return result;
//}

//These two methods are identical except for the code that computes the new array's value from the original value. You could create both methods and call it day, but that is not ideal. It is a large chunk of duplicated code. If you needed to fix a bug, you'd have to do so in two places.

//We could maybe add another parameter to indicate how much to change the number:

//int[] ChangeArrayElements(int[] numbers, int amount)
//{
 //   int[] result = new int[numbers.Length];
//
//    for (int index = 0; index < result.Length; index++)
//        result[index] = numbers[index] + amount;
//
//    return result;
//}

//To add or subtract, we could call ChangeArrayElements(numbers, +1) and ChangeArrayElements(number, -1). But there is only so much flexibility we can get. What if we wanted a similar method that doubled each item or computed each item's square root?

//To give the calling method the most flexibility, we can ask it to supply a method to use instead of adding a specific number.

//This is easier to illustrate with an example. Let's start by defining the methods AddOne, SubtractOne, and Double:

//int AddOne(int number) => number + 1;
//int SubtractOne(int number) => number - 1;
//int Double(int number) => number * 2;

//These methods have the same parameter list (a single int parameter) and the same return type (also an int). That similarity is essential; it is what will make them interchangeable. The next step is for us to give a name to this pattern by defining a delegate type:

//public delegate int NumberDelegate(int number);

//This defines a new type, like defining a new enumeration or class. Defining a new delegate type requires a return type, a name, and a parameter list. In this sense, it looks like a method declaration, aside from the delegate keyword.

//Variables that use delegate types can store methods. But the method must match the delegate's return type and parameter types to work. A variable whose type is NumberDelegate can store any method with an int return type and a single int parameter. Lucky for us, AddOne, SubstractOne and Double all meet these conditions. That means we can make a variable that can store a reference to any of them.

//There are three parts to using a delegate: making a variable of that type, assigning it a value, and then using it.

//Any variable can use a delegate for its type, just like we saw with enumerations and classes. We can make a method with a parameter whose type is NumberDelegate, which will allow callers of the method to supply a different method to invoke when the time is right:

//int[] ChangeArrayElements(int[] numbers, NumberDelegate operation) { ... }

//To call ChangeArrayElements with the delegate, we name the method we want to use:

//ChangeArrayElements(new int[] { 1, 2, 3, 4, 5 }, AddOne);

//Note the lack of parentheses! With parentheses, we'd be invoking the method and passing its return value. Instead, we are passing the method itself by name.

//If the method is an instance method, you can name the object with its method:

//SomeClass thing = new SomeClass();
//ChangeArrayElements(new int[] { 1, 2, 3, 4, 5 }, this.DoIt);

//The C# compiler is smart enough to keep track of the fact that the delegate must store a reference to this instance (thing) and know which method to call (DoIt).

//On rare occassions, the compiler may struggle to understand what you are doing. In these cases, you may need to be more formal with something like this:

//ChangeArrayElements(new int[] { 1, 2, 3, 4, 5 }, new NumberDelegate(AddOne);

//That shouldn't happen very often, though.

//Let's see howw ChangeArrayElements would use this delegate-typed variable. Because a delegate holds a reference to a method, you will eventually want to invoke the method. There are two ways to do this. The first is shown here:

//int[] ChangeArrayElements(int[] numbers, NumberDelegate operation)
//{
//    int[] result = new int[numbers.Length];

//    for (int index = 0; index < result.Length; index++)
//        result[index] = operation(numbers[index]);

//    return result;
//}

//You can invoke the method in a delegate variable by using parentheses. Invoking a method in a delegate-typed variable looks like a typical method call, except perhaps the capitalization. (Most methods in C# start with a capital letter. Most parameters do not).

//The second way is to use the delegate's Invoke method:

//return[index] = operation.Invoke(numbers[Index]);

//These are the same thing for all practical purposes, though the second option allows you to check for null with a simple operation?.Invoke(numbers[index]).

//By looking at this code, you can see why delegates are called that. ChangeArrayElements know how to iterate through the array and build a new array, but it doesn't understand how to compute new values from old values. It expects somebody else to do that work, and when the time comes, it delegates that job to the delegate object.

//Delegates can significantly increase the flexibility of sections of code. It can allow you to define algorithms with replaceable elements in the middle, filled in by other methods via delegates. That makes them a valuable tool to add to your C# toolbox.

//The action, func and predicate delegates

//In the last section, we defined a new delegate type to use in our program. That has its uses - if you want a specific name given to a method pattern - but if you play your cards right, you won't have to define new delegate types often. The Base Class Library contains a flexible and extensive collection of delegate types that cover most scenarios.

//Two sets of generic delegate types cover virtually all situations: Action and Func. Each is a set of generic delegates rather than a single delegate type.

//The Action delegates have a void return type. They capture scenarios where a method performs a job without producing a result. The simplest one, known simply as Action, is a delegate for any function with no parameters and a void return type, such as void DoSomething().

//If you need one parameter, Action<T> is what you want. It is generic, so the right flavour will allow you to account for any parameter type - for example, Action<string> for a method like void DoSomething(string value). There are versions of Action with up to 16 parameters, though if you have a method with more than 16 parameters, change your design. You could use Action<string, int, bool> for void DoSomething(string message, int number, bool isFancy).

//The Func delegates (short for 'function') are for when you need a return value. Func<TResult> is the simplest version, and it has a generic return type (TResult). Use this for a method with no parameters. Func<int> could be used for the method int GetNumber(). If you need parameters, there's a Func for that too. Func<T, TResult> is for a single parameter. You could use Func<int, double> for double DoSomething(int number). Like Action, there is a version with up to 16 parameters plus a return type, and all are generic. For example, Func<string, int, bool, double> works for double DoSomething(string message, int, number, bool, isFancy).

//You can use one of the above delegate types for any situation where delegates could come in handy. Our NumberDelegate could have been done with Func<int, int>. Some programmers almost exclusively use these delegate types. Others tend to make their own so they can give them more descriptive names.

//One other delegate type worth noting here: Predicate<T>. The mathematical definition of predicate is a condition used to determine whether something belongs to a set. Predicate<T> represents a method that takes an object of the generic type T and returns a bool (that makes it equivalent to Func<T, bool>). Its definition looks something like this:
//public delegate bool Predicate<T>(T value);

//(This also illustrates how to define generic delegates). For example, we could define IsEven and IsOdd methods that tell you if a number belongs to the set of even numbers or odd numbers. The name Predicate<T> reveals its intended use better than Func<T, bool> and spares you from filling in two generic type parameters.

//MulticastDelegate and Delegate Chaining

//Behind the scenes, declaring a new types creates new classes dervied from the special class MulticastDelegate. That name hints at doing things in multiples, and indeed you can. Each delegate object can store many methods, not just a single one. This collection is called a delegate chain. When a delegate is invoked, each method in the delegate chain will be called in turn.

//In practice, this is rate. (Though see Level 37 where we put this ability to use). Doing so brings up at least one notable concern: what return value does a delegate with mutiple methods return? It cannot account for all of the return values. The return value will be that of the last method attached, ignoring the rest. If you are going to attach multiple methods to a multicase delegate, you should only do so with the void return type.

//Attaching additional methods to a delegate can be done with the += or + operators and subsequently detached with the -+ or - operators. For example, suppose you have the following delegate:
//Log logMethods = LogToConsole;
//logMethods += LogToDatabase;
//logMethods += LogToTextFile;

//When you invoke logMethods(LogLevel.Warning, "A problem happened."); it will call all three of those methods. You could also write it like this:

//Log logMethods = new Log(LogToConsole) + LogToDatabase + LogToTextFile;

//If any of the methods  throw an exception while running, the other delegate methods will not get a chance to run. When used this way, attached methods should not let exceptions escape.
