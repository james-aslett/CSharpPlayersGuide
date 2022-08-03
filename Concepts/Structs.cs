//While classes are a great way to create new reference types, C# also lets you make custom value types. New types of this nature are called structs,
//which is short for structure or data structure. Making a struct is nearly the same as making a class. We have seen many variations on a Point class
//before, but here is a Point struct:
public struct Point
{
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }
}
//The only code difference is using the struct keyword instead of class. Most aspects of making a struct are the same as making a class. You can add
//fields, properties, methods, and constructors, along with some other member types we have not discussed yet.

//Using a struct is also nearly the same as using a class:
Point p1 = new Point(2, 4);
Console.WriteLine($"({p1.X}. {p1.Y}");

//The critical difference is that structs are value types instead of reference types. This means variables whose type is a struct contain the data
//where the variable lives, instead of holding a reference that points to the data, as is the case with classes.

//Recall that the variable's contents are copied when passing something between methods (an argument or return value). For a reference type like
//classes, that means the reference is copied. The calling method and the called method both have their own reference, but both references point
//to the same object. For a value type like structs, the entire block of data is copied, and each ends up with a full copy of the data. The same is
//true when assigning a value from one local variable to another or working with expressions.

//Structs are primarily useful for representing small data-related concepts that don't have a lot of behaviour. Representing a 2D point, as we did
//above, is a good candidate for a struct. A circle, a line, or a matrix could also be good candidates.  In situations where the concept is not a
//small data-related concept, a class is usually better. Even still, some small data-related concepts are still better than a class. We'll analyze
//the class vs. struct decision in more depth in a moment.

//MEMORY AND CONSTRUCTORS

//Because structs are value types, memory usage and constructors are two critical ways structs differ from the classes we have been making in the
//past. Reference types, such as a class, can be null. In these cases, the memory for an object doesn't exist until it is explicitly created by
//calling a constructor with the new keyword. For value types like structs, we don't have that option. The variable's mere existence means its
//memory must also exist, even before it has been initialized by a constructor. This model has a lot of implications that may be surprising.

//First, while a constructor can be used to initialize data, invoking a constructor is not always necessary. Consider this struct:
public struct PairOfInts
{
    public int A; // These are public fields, which are usually best to avoid
    public int B;
}

//Now, look at this code with a PairOfInts local variable:
PairOfInts pair;
pair.A = 2;
Console.WriteLine(pair.A);

//It calls no constructor but still assign a value to its A field. The pair variable acts like two separate local variables, each of which can be
//initialized and used like any other local variable but through a shared name.

//Now imagine we add this class into the mix:
public class PairOfInts
{
    public PairOfInts _one;
    public PairOfInts _two;

    public void Display()
    {
        Console.WriteLine($"{_one.A} {_one.B} and {_two.A} {_two.B}");
    }
}

//Once again, we can use these structs without calling a constructor. In this case, the structs are initialized to default values by zeroing out
//their memory, meaning A and B of both _one and _two will be 0 until somebody changed it.

//No matter what constructors you give a struct, they may simply not be called!

//Second, structs will always have a public parameterless constructor. If a class doesn't define any constructors, the compiler automatically generates
//a parameterless constructor for any class you make. The compiler does the same thing for a struct. For a class, if you define a different
//constructor, the compiler no longer makes a parameterless constructor. For a struct, the compiler will define a public paramterless constructor
//anyway. You cannot get rid of the public parameterless constructor yourself if you need it to do something specific.

//Third, field initializers are a bit weird in a struct. Consider this version of PairOfInts:
public struct PairOfInts
{
    public int A = 10;
    public int B = -2;
}

//These initializers do not always run when you use a PairOfInts. More specifically:
// - field and property initializers don't even run if no contructor is called
// - the compiler-generated constructor runs these initializers only if the struct has no constructors
// - if you add your own constructors, these initializers will only run as part of constructors YOU have defined, not as part of the compiler-generated
//   one.

//To ensure the third rule doesn't catch you off guard, you will likely want to define your own parameterless constructor when adding initializers to
//your fields or properties.

//You don't need to memorize all these rules. Just remember that it can be a tricky area. Don't just assume your code works, but check to ensure it
//does.

//CLASSES VS. STRUCTS

//Classes and structs have a lot in common, but let's compare the two and describe when you might want to use them.

//The main difference is that classes are reference types and structs are value types. We touched on this in the previous section, but it means
//struct-typed variables store their data directly, while class-typed variables store a referece, and the actual data lives elsewhere (see level 14).

//This one difference has a lot of rammificatinons, not the least of which is the differences in constructors described in the previous section.

//Another key difference is that structs cannot take on a null value, though we will see a way to pretend in level 32.

//Because structs are value types, reading and writing values to variables involves copying the whole pile of data around, not just a reference.
//Like with a double, when we copy a value from one variable to another results in a copy:
PaitOfInts first = new PairOfInts(2, 10);
PairOfInts second = first;

 //Here, the second will get a copy of both the 2 and the 10 assigned to its fields. The same thing would happen if we passed a PairOfInts to a
 //method as an argument.

//Additionally, inheritance does not work well when copying value types around (do a web search for 'object slicing'), so structs do not support it.
//A struct cannot pick a base class (they all derive from ValueType, which derives from object). Structs, however, are allowed to implement interfaces.

//Equality is also different for structs. As we saw in level 14, value types have value semantics - two things are equal if all of their data
//members are equal. Any struct you create will automatically have value semantics. The Equals method and the == and != operators are automatically
//defined to compare the struct's fields for equality.

//Choosing to make a class or a struct

//Given how similar structs and classes are, you're probably wondering how to decide between the two. Ultimately, the deciding factor should be if you
//need a reference type or a value type. That's the main difference, and it should drive your selection.

//Structs are usually the better choice for small, data-focused types. A struct may be better if a concept is primarily about representing data and not
//doing work. If the concept's behaviour is important, then things like inheritance and polymorphism often are as well. You can't get that from a struct.
//That doesn't mean that a struct can't have methods, but a struct's methods are usually focused on answering questions about the data instead of getting
//the work done.

//However, just because something focuses on data doesn't mean a struct is always better. You can't get references to a struct like you can with a class.
//With a class, you can build a web of interconnected objects that know about each other through references. You can't do the same thing with structs.

//The way structs and classes are managed in memory is also a driving force. Reference types like classes always get allocated individually on the heap.
//Structs get allocated directly in whatever contains them. That is sometimes the stack and sometimes a larger object on the heap (such as an array or
//class with value-types fields). Therefore, instances of classes make the garbage collector work harder, while structs don't.

//Let's illustrate that point with an example. Let's say we have the following two types that differ only by whether they are a struct (a value type)
//or a class (a reference type):
public struct CircleStruct
{
    public double X { get; }
    public double Y { get; }
    public double Radius { get; }

    public CircleStruct(double x, double y, double radius)
    {
        X = x; Y = y; Radius = radius;
    }
}

public class CircleClass
{
    public double X { get; }
    public double Y { get; }
    public double Radius { get; }

    public CircleClass(double x, double y, double radius)
    {
        X = x; Y = y; Radius = radius;
    }
}

//Consider this code:
for (int number = 0; number < 10000; number++)
{
    CircleStruct circle = new CircleStruct(0, 0, 10);
    Console.WriteLine($"X={circle.X} Y= {circle.Y} Radius={circle.Radius}");
}

for (int number = 0; number < 10000; number++)
{
    CircleClass circle = new CircleClass(0, 0, 10);
    Console.WriteLine($"X={circle.X} Y= {circle.Y} Radius={circle.Radius}");
}

//In the first loop, with structs, there is one variable designed to hold a single CircleStruct and because it is a local variable, it lives on the stack.
//That variable is big enough to contain an entire CircleStruct, with 8 bytes for X, Y, and Radius for a total of 24 bytes. Every time we get to that
//new CircleStruct(...) part, we re-initialize that memory location with new data. But we reuse the memory location.

//In the second loop, with classes, we still have a single variable on the stack, but that variable is a reference type and will only hold references.
//This variable will be only 8 bytes (on a 64-bit computer). However, each time we run new CircleClass (...), a new CircleClass object is allocated on
//the heap. By the time we finish, we will have done that 10,000 times (and used 240,000 bytes), and the garbage collector will need to clean them
//all up.

//Structs don't always have the upper hand with memory usage. Consider this scenario, where we pass a circle as an argument to a method 10,000 times:
CircleStruct circleStruct = new CircleStruct(0, 0, 10);
for (int number = 0; number < 10000; number++)
    DisplayStruct(circleStruct);

CircleClass circleClass = new CircleClass(0, 0, 10);
for (int number = 0; number < 10000; number++)
    DisplayClass(circleClass);

void DisplayStruct(CircleStruct circle) =>
    Console.WriteLine($"X={circle.X} Y={circle.Y} Radius={circle.Radius}");

void DisplayClass(CircleClass circle) =>
    Console.WriteLine($"X={circle.X} Y={circle.Y} Radius={circle.Radius}");

//We only create one struct and class instance here, but we repeatedly call the DisplayStruct and DisplayClass methods. In doing so, the contents of
//circleStruct are copied to DisplayStruct's circle parameter, and the contents of circleClass are copied to DisplayClass's circle parameter repeatedly.
//For the struct, that means copying all 24 bytes of the data structure, for a total of 240,000 bytes copied. For the class, we're only copying the
//8 byte reference and a total of 80,000 bytes, which is far less.

//The bottom line is that you'll get different memory usage patterns depending on which one you pick. Those differences play a key role in deciding
//whether to use a class or a struct.

//In short, you should consider a struct when you have a type that a: is focused on data instead of behaviour, b: is small in size, c: where you don't
//need shared references, and d: when being a value type works to your advantage instead of against you. If any of those are not true, you should
//prefer a class.

//To give a few more examples, a point, a rectangle, circle and score could each potentially fit into those criteria, depending on how you're using
//them.

//I'll let you in on a secret: many C# programmer, including some veterans, don't fully grasp the differences between a class and a struct and will
//always make a class. I don't think this is ideal, but it may not be so bad as a short-term strategy as you get more comfortable in C#.

//Just don't let that be your permanent strategy. I probably make 50 times as many classes as structs, but a few strategically placed structs
//make a big difference.

//Rules to follow when making structs

//There are three guidelines that you should follow when you make a struct.

//First, keep them small. That is subjective, but an 8 byte struct is fine, while a 200 byte struct should generally be avoided. The costs of copying
//large structs add up.

//Second, make structs immutable. Structs should represent a single compound value, and as such, you should make its fields readonly and not have setters
//(not even private) for its properties. (an init accessor is fine). Doing this helps prevent situations where somebody thought they had modified a
//struct value but modified a copy instead:
public void ShiftLeft(Point p) => p.X -= 10;

//Assuming Point is a struct, the data is copied into p when you call this method. The variable p's X property is shifted, but it is ShiftLeft's copy.
//The original copy is unaffected.

//Making structs immutable sidesteps all sorts of bugs like this. If you want to shift a point to the left, you make a new Point value instead, with its
//X property adjusted for the desired shift. Making a new value is essentially the same thing you would do if it were just an int:
public Point ShiftLeft(Point p) => new Point(p.X - 10, p.Y);

//With this change, the calling method would do this:
Point somePoint = new Point(5, 5);
somePoint = ShiftLeft(somePoint);

//Third, because struct values can exist without calling a constructor, a default, zeroed-out struct should represent a valid value. Consider the
//LineSegment class below:
public class LineSegment
{
    private readonly Point _start;
    private readonly Point _end;

    public LineSegment() { }

    // ...
}

//When a new LineSegment is created, _start and _end are initialized to all zeroes. Regardless of what constructors Point defines, they don't get called
//here. Fortunately, a Point whose X and Y values are 0 represents a point at the origin, which is a valid point.

