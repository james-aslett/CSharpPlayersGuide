//USING MULTIPLE FILES
//As your programs grow, having everthing in a single file becomes unwieldy. You can spread C# code across many files and folder to organize your code. In fact, most C# programmers prefer putting types into separate files with a name that matches the type name. However, tiny type definitions like enumerations and records often get lumped in with closely related things.

//There are many ways to get more files in your project, but sometimes the easiest way is to initially put it into an existing file and then use a Quick Action in VS to move it to another file. The Quick Action will be available on any type you have defined in a file with a mismatched name. Imagine you have this code in Program.cs:
public class One { }
public class Two { }

//You can get to the Quick Action by placing the cursor on the first line of the type definition (such as public class One), then clicking on the screwdriver/lightbulb icon. Then select 'move type to One.cs'.

//If a type is more than a few hundred lines long, it probably deserves its own file. Many C# programmers put each type in separate files; you're in good company if you do the same.

//You can make as many files as you want with one caveat: a program can only contain one file with a main method. Every other file can only contain type definitions. If you have Console.WriteLine("Hello, World!"); at the top of two files, the compiler won't know which to use as the entry point for your program.

//NAMESPACES AND USING DIRECTIVES
//In C#, we name every type we create. Every other C# programmer is doing a similar thing. As you can imagine, some names are used more than once. For example, there are probably a hundred thousand different Point classes in the world.

//To better differentiate identically named types from each other, we can place our types in a namespace. A namespace is a named container for organizing types. We can refer to a type by its fully qualified name, a combination of the namespace it lives in, and the type name itself. For example, since Console lives in the System namespace, its fully qualified name is System.Console.

//Fully qualified names allow us to differentiate between types with the same simple name. We do similar things with people's names, especially when the name could be ambiguous or unclear: "Paul Leipzig", "Paul from work", or "Tall Paul".

//Until now, we have not placed our types in a specific namespace. They end up in an unnamed namespace called the global namespace.

//But most of the types we have used, such as Console, Math and List<T>, all live in specific namespaces. So far, everything we have covered has been in one of three namespaces.

//The System namespace contains the most foundational and common types, including Console, Convert, all the built-in types (int, bool, double, string, object etc.), Math/MathF, Random, DateTime, TimeSpan, Guid, Nullable<T>, and tuples (ValueTuple). It is hard to imagine a C# program that doesn't use System.

//The System.Collections.Generic namespace contains the generic collection types we discussed in Level 32, including List<T>, IEnumerable<T>, and Dictionary<TKey, TValue>. It is also hard to imagine any program with collections not using this namespace.

//The System.Text namespace contains advanced text-related types, including the StringBuilder class we saw in Level 32. This namespace is not quite as common.

//As you program in C#, you will encounter types defined in many other namespaces. These three are just the first three we've seen.

//Any time you use a type name in your code, you have the option of using the type's fully qualified name. Since Console's fully qualified name is System.Console, we could have written Hello World like this:
System.Console.WriteLine("Hello, World!");

//In fact, by default, you're required to use a type's fully qualified name! We sawm an example of this in Level 32 when we talked about StringBuilder. The code there included this line:
System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

//So why haven't we had to write System.Console everywhere? It's complicated.

//You can include a line at the top of any file that tells the computer "I'm going to be using this namespace a lot. I want to use simple type names for things in this namespace. When you see a plain type name, look in this namespace for it." This line is called a using directive. For example:
using System.Text;

StringBuilder stringBuilder = new StringBuilder();
stringBuilder.Append("Hello, ");
stringBuilder.Append("World!");
Console.WriteLine(stringBuilder.ToString());

//With that using directive at the top of the file, we no longer need to use StringBuilder's fully qualified name when referring to that type.

//In the future, you will want to pay attention to what namespace types live in, so you can either use their fully qualified name or add a using directive for their namespace. If you attempt to use a type's simple name without the correct using directive, you will get a compiler error because the compiler won't know what the identifier refers to.

//These using directives partially explan why we don't always need to write out System.Console, but we haven't adding usingSystem; to our programs either. Why?

//When you look at older C# code, you will find that they almost invariably start with using System; and a small pile of other using directives.

//Starting with C# 10 projects, several using directives are added implicitly - you don't need to add them yourself. The automatic list includes both System and System.Collections.Generic, which we have encountered. It also includes System.IO, System.Linq, System.Net.Http, System.Threading, and System.Threading.Tasks, most of which we'll cover before the end of this book.

//Because these extremely common namespaces are added implicitly, the pile of using directives at the start of the file only lists the non-obvious namespaces used in the file.

//You can turn this feature off, but I recommend leaving it on, as it eliminates cluttered, obvious using directives across your code, which is a big win. On the other hand, if you're stick in an older codebase and can't use this feature, you'll have to add using directives for every namespace you want to use or use fully qualified names.

//For namespaces not in the list above, like System.Text, you will still need to add a using directive.

//ADDING USING DIRECTIVE FEATURES
//The basic using directive is what you will do most of the time. But there are a few advanced tricks you can do that are worth mentioning.

//GLOBAL USING DIRECTIVES
//In most files in a project use a specific namespace, you'll have using SomeNameSpace; everywhere. As an alternative, you can include the global keyword on a using directive and it will automatically be included in all files in the project:
global using SomeNameSpace;

//A global using directive can be added to any file but must come before regular using directives. I recommend putting these in a place you can find them easily. For example, you could make a GlobalUsings.cs or ProjectSettings.cs file containing only your global using directives.

//STATIC USING DIRECTIVES
//You can add a using directive with the static modifier to name a single type (not a namespace) to gain access to any static members of the type without writing out the type name. For example, the Math and Console classes have many static members. We could add static using directives for them:
using static System.Math;
using static System.Console;

//With these in place, the following code compiles:
double x = PI; // PI from Math
WriteLine(Single(x)); // WriteLine from Console, Sin from Math
ReadyKey(); //ReadKey from Console

//The leads to shorter code, but it does add a burden on you and other programmers to figure out where these methods are coming from. I recommend using these sparingly. More often than not, the burden of figuring out and remembering where the methods came from outweighs the few characters you save, but all tools have their uses.

//NAME CONFLICTS AND ALIASES
//Suppose you want to use two types that share the same name in a single file. For example, imagine you need to use a PhysicsEngine.Point and UserInterface.Point class. Adding using directives for those two namespaces results in a name conflict. The compiler won't know which one Point refers to.

//One solution is to use fully qualified names to sidestep the conflict:
PhysicsEngine.Point point = new PhysicsEngine.Point();

//Alternatively, you can also use the using keyword to give an alias to a type:
using Point = PhysicsEngine.Point;

//The above line is sufficient for the compiler to know when it sees the type Point in a file, you're referring to PhysicsEngine.Point, not UserInterface.Point, which resolves the conflict.

//An alias does not need to match the original name of the type, meaning you can do this:
using PhysicsPoint = PhysicsEngine.Point;
using UIPoint = UserInterface.Point;

PhysicsPoint p1 = new PhysicsPoint();
UIPoint p2 = new UIPoint();

//Aliaisng a type to another name can get confusing; do so with caution.

//PUTTING TYPES INTO NAMESPACES
//Virtually all types you use but don't create yourself (Console, Math, List<T>, etc.) wlil be in one namespace or another. Anything meant to be shared and reused in other projects should be in a namespace. If you are building something that isn't being reused, namespaces are somewhat less important. Everything we've done so far is in that category, so it isn't a big deal that we haven't used namespaces before.

//But putting things into namespaces isn't hard and is often worth doing, even if you don't expect the code to be used far and wide.

//The most flexible way of putting types in a namespace is shown below, using the namespace keyword, a name, and a set of curly braces that hold the types you want in the namepace:
namespace SpaceGame
{
    public enum Color { Red, Green, Blue, Yellow }

    public class Point { /* ... */ }
}

//With this code, Color's fully qualified name is SpaceGame.Color, and Point's is SpaceGame.Point.

//A slightly more complete example might look this this:4
using SpaceGame;

Color color = Color.Red;
point point = new Point();

namespace SpaceGame
{
    public enum Color { Red, Green, Blue, Yellow }
    public class Point { /* ... */ }
}

//Our main method at the top isn't in the SpaceGame namespace, so it relies on the using directive at the top to use Color and Point without fully qualified names.

//Namespaces can contain other namespaces:
namespace SpaceGame
{
    namespace Drawing
    {
    }
}

//But the more common way to nest namespaces is this:
namespace SpaceGame.Drawing
{
}

//A namespace can span many files. Each file will simply add to the namespace's members. Aside from the file containing your main method, most files lump all of its types into the same namespace. The following version is a shortcut to say, "Everything in this file is in the SpaceGame namespace," allowing it to ditch the excessive curly braces and indentation:
namespace SpaceGame;

public enum Color { Red, Green, Blue, Yellow }
public class Point { /* ... */ }

//This version comes after any using directives but before any type definitions. Unfortunately, you cannot use this version in the file containing your main method.

//NAMESPACE NAMING CONVENTION
//Most C# programmers will make their namespace names align with their project and folder structure. If you name your project SpaceGame, you would also make your namespace be SpaceGame. If you make a folder within your SpaceGame project called Graphics, you would put things in that folder in the SpaceGame.Graphics namespace.

//Since namespace names usually mirror project names, let's briefly talk about project naming conventions. Project names are typically given a short, memorable project name (for example, SpaceGame) or prefix the project name with a company name (RBTech.SpaceGame). Some large projects are made of multiple components, so you'll sometimes see a component name added to the end (SpaceGame.Client, or RBTech.SpaceGame.Graphics). The namespace used within these projects will typically match these project names in each case.

//TRADITIONAL ENTRY POINTS
//Back in Level 3, I mentioned that there are two different ways to define an entry point for your program. Placing statements in a file like Program.cs is the simplest of the two and is what we have been doing in this book. This style is called top-level statements and is the newer and easier of the two options.

//The alternative, which I'll call a traditional entry point, is still worth knowing. You will inevitably encounter code that still uses it, and if you find yourself using older code, it may be your only option.

//The traditional approach is to make a class (usually called Program) and give it a static void Main method with an (optional) string array parameter (usually calls args):
using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

//In fact, the newer top-level 