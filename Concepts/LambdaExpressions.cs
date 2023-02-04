//LAMBDA EXPRESSIONS

//Lamba expressions let you define short, unnamed methods using simplified inline syntax: x => x < 5 is equivalent to bool LessThanFive(int x) => x < 5;
//Multiple and zero parameters are also allowed, but require parentheses: (x, y) => x*x + y*y and () => Console.WriteLine("Hello, World!");
//Types can usually be inferred, but you can explicitly state types: (int x) => x < 5
//Lambdas have a statement form if you need more than just an expression: x => { bool lessThan5 = x < 5; return lessThan5; }
//Lambda expressions can use variables that are in scope at the place where they are defined

//Lambda Expression Basics
//C# provides a way to define small unnamed methods using a short syntax called a lambda expression. To illustrate where this could be useful, consider this method to count the number of items in an array that meet some condition. The condition is configurable, determined by a delegate:
//public static int Count(int[] input, Func<int, bool> countFunction)
//{
//    int count = 0;

//    foreach (int number in input)
//        if (countFunction(number))
//            count++;

//    return count;   
//}

//(In Level 42 we will see all IEnumerable<T>'s have a Count method like this, so you do not usually have to write your own.)

//We saw methods when we first learned about delegates in Level 36. We know we can call a method like this by passing in a named method:
//int count = Count(numbers, IsEven);

//But let's look at that IsEven method:
//private static bool IsEVen(int number) => number % 2 == 0;

//That method is not long, but it has a lot of pomp and formality for a method that may only be used once. We can alternatively define a lambda expression right in the spot where it is used:
//int count = Count(numbers, n => n % 2 == 0);

//This lambda expression replaces the definition of IsEvemn entirely. You can see some similarities to methods with an expression body. They both use the => operator. This operator is sometimes called the arrow operator or the fat arrow operator but is also frequently called the lambda operater. (In fact, lambda expressions came before expression-bodied methods).

//Yet, many of the other elements of this definition are gone. No prive. No static. No stated return type. No name. No parentheses around the parameters. No type listed for the paramter. Plus, we used the variable name n instead of number.

//A lambda expression defines a single-use method inline, right where it is needed. To prevent the code from getting ugly, everything in a lambda expression uses a minimalistic form:
//- The accessibility level goes away because you cannot 