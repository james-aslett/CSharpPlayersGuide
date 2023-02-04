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
//- The accessibility level goes away because you cannot reuse a lambda expresson elsewhere
//- The compiler infers the return type and parameter types from the surrounding context. Since the countFunction parameter is a Func<int, bool>, it is easy for the compiler to infer that n must be an int, and the expression must return a bool
//- The name is gone because it is a single-use method and does not need to be used again
//- The parentheses are gone just to make the code simpler

//Using the name n instead of number also makes the code shorter. Generally, more descriptive names are better, but C# programmers tend to use concise names in a lambda expression. When a variable is only used in the following few characters, the downsides of a short name are not nearly as significant as they are in a 30-line method.

//We can do some pretty cool things with little code using a combination of lambda expressions and delegates. This counts the number of positive integers:
//int positives = Count(numbers, n => n > 0);

//This counts positive three-digit integers:
//int threeDigitCount = Count(numbers, n => n >= 100 && n < 1000);

//Lambda expressions are different enough from normal methods that it may require some time to adjust. But with a bit of practice, you will find them a simple but powerul tool.

//The Origin of the nane Lambda
//You may be wondering why this is called a lambda expression. The name comes from lambda calculus. Lambda calculus is a type of functon-oriented math - almost a mathematical programming language. The nature of lambda expressions and delegates is heavily inspired by lambda calculus. In lambda calculus, the name lambda comes from its usage of the Greek letter lambda.

//Multiple and zero parameters
//Our lambda expressions so far have all had a single parameter. Let's talk about lamdba expressions with zero or many parameters. When you have zero or multiple parameters, the parentheses come back.

//A lambda expression with two parameters looks like this:
//(a, b) => a + b

//A lambda expression with no parameters looks like this:
//() => 4

//These two cases require parentheses, but parentheses are always an option:
//(n) => n % 2 == 0

//When type inference fails
//Sometimes, the compiler cannot infer the parameter types in a lambda expression. If you encounter this, you can name the types explicitly, as you might for a normal metohd:
//(int n) => n % 2 == 0

//Or:
//(string a, string b) => a + b

//If the compiler can't correctly infer the return type of a method, you can write out the return type before the parentheses that contain the parameters like this:
//bool (n) => n % 2 == 0

//Or:
//bool (int n) => n % 2 == 0

//In all of these cases, parentheses are required.

//Discards
//Lambdas are often used in places where the code demands certain parameters but where you may not need all of them. If so, you can use discards for those parameters with either of the following two forms:
//(_, _) => 1
//(int _, int _) => 1

//Lambda Statements
//Most of the time, when you want a simple single-use method, an expression is all you need, and lambda expressions are a good fit. You can use a lambda statement in the rare cases where a statement or several statemenrs are required. Lambda expressions and lambda statements are both sometimes referred to by the shorter catch-all name lambda.

//Making a statement lambda is simple enough. Replace the expression body with a block body:
//Count(numbers, n => { return n % 2 == 0; });

//Or this:
//Count(numbers, n => { Console.WriteLine(n); return n % 2  == 0; };

//Closures
//Lambdas and local functions can do something normal methods can't do. Consider this code:
//int threshold = 3;
//Count(numbers, x => x < threshold);

//The lambda expression has one parameter: x. However, it can use the local variables of the method that contains it. Here, it uses threshold. Lambda expressions and local functions