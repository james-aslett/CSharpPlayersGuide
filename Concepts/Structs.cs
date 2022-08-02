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