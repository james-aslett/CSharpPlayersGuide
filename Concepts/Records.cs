//Records are a compact alternative notation for defining a data-centrc class or struct: public record Point(float X, float Y);

//The compiler automatically generates a constructor, properties, ToString, equality with value semantics, and deconstruction

//You can add additional members or provide a definition for most compiler-synthesized members

//Records are turned into classes by default or into a struct (public record struct Point (...))

//Records can be used in a with expression: Point modified = p with { X = -2 };

//RECORDS

//C# has an ultra-compact way to define certain kinds of classes or structs. This compact notation is called a record. The typical situation where a record makes
//makes sense is when your type is little more than a set of properties - a data-focused entity.

//The following shows a simple Point record, defined with an X and Y property:
public record Point(float X, float Y); //That's all

///The compiler will expand the code into something like this:
public class Point
{
    public float X { get; init; }
    public float Y { get; init; }

    public Point(float x, float y)
    {
        X = x; Y = y;
    }
}

//When you define a record, you get several features for free. It starts with properties that match the names you provided in the record definition and a
//matching constructor. Note that these properties are init properties, so the class is, by defauly, immutable. But that's only the beginning. We get several
//other things for free: a nice string representation, value semantics, deconstructionm and creating copies with tweaks.

//STRING REPRESENTATION
//Records automatically override the ToString method with a convenient, readable representation of its data. For example, new Point(2, 3).ToString(), will
//produce this:
Point { X = 2, Y = 3 }

//When a type's data is the focus, a string representation like this is a nice bonus. You could do this manually by overriding ToString, but we get it free with
//records.

//VALUE SEMANTICS
//Recall that semantics are when the thing's value or data counts, not it's reference. While struct have value semantics automtically, classes have reference
//semantic by default. However, records automatically have value semantics. In a record, the Equal's method, the == operator and the != operator are redefined
//to give it value semantics. For example:
Point a = new Point(2, 3);
Point b = new Point(2, 3);
Console.WriteLine(a == b);

//Though a and b refer to different instances and use separate memory locations, this code displays True because the data are a perfect match, and the two
//are considered equal. Level 41 describes making operators for your own types, but we get it for free with a record.

//DECONSTRUCTION
//In Level 17, we saw how to deconstruct a tuple, unpacking the data into separate variables:
(string first, string last) = ("Jack", "Sparrow");

//You can do the same thing with records:
Point p = new Point(-2, 5);
(float x, float y) = p;

//In Level 34, we will see how you can add deconstruction to any type, but records get it for free.

//with STATEMENTS
//Given the records are immutable by default, it is not uncommon to want a second copy with most of the same data, just with one or two of the properties
//tweaked. While you could always just call the constructor, passing in the right values, records give you extra powers in the form of a with statementL
Point p1 = new Point(-2, 5);
Point p2 = p1 with { X = 0 };

//You can replace many properties at once by separating them with commas:
Point p3 = p1 with { X = 0, Y = 0 };

//In this case, since we've replaced all the properties with new values, it might have been better to just write new Point(0, 0), but that code shows the
//mechanics.

//The plumbing that the compiler generates to facilitate the with statement is not something you can add to your own types. This is a record-only feature
//(at least for now)

//ADVANCED SCENARIOS
//Most records you define will be a single line, similar to the Point record defined earlier. But when you have the need, they can be much more. You can add
//additional members and make your own definition to supplant most compiler-generated members

//ADDITIONAL MEMBERS
//In any record, you can add any members you need to flesh out your record type, just like a class. The following shows a Rectangle record with Width and Height
//properties and then adds in an Area property, calculated from the rectangle's width and height:
public record Rectangle(float Width, float Height)
{
    public float Area => Width * Height;
}

//There are no limits to what members you can add to a record.

//REPLACING SYNTHESIZED MEMBERS
//The compiler generates quite a few members to provide the features that make records attractive. While you can't remove any of those features, you can customize
//most of them to meet your needs. For example, as we saw, the Point record defines ToString to display text like Point { X = 2, Y = 3 }. If you wanted your Point
//record to show it like {2, 3} instead, you could simply add in your own definition for ToString:
public record Point (float X, float Y)
{
    public override string ToString() => $"{X}, {Y}";
}

//In most situations where the compiler would normally synthesize a member for you, if it sees that you've provided a definition, it will use your version instead.

//One use for this is defining the properties as mutable properties or fields instead of the default init-only property. The compiler will not automatically assign
//initial values to your version if you do this. You'll want to initialize them yourself:
public record Point(float X, float Y)
{
    public float X { get; set; } = X;
}

//You cannot supply a definition for the constructor (though this limitation is removed if you make a non-positional record, as described later).

//You cannot define many of the equality related members, including Equals(object), the == operator, and the != operator. However, you can still define Equals(Point),
//or whatever the record's type is. Equals(object), == and != each call Equals(Point), so you can usually achieve what you want, despite this limitation.

//NON-POSITIONAL RECORDS
//Most records will include a set of properties in parentheses after the record name. These are positional records because the properties have a known, fixed
//ordering (which also matters for deconstruction). These parameters are not strictly required. You could also write a simple record like this:
public record Point
{
    public float X { get; init; }
    public float Y { get; init; }
}

//In this case, you wouldn't get the constructor or the ability to do deconstruction (unless you add them in yourself), but otherwise, this is the same as any other
//record.

//STRUCT AND-CLASS-BASED RECORDS
//The compiler turns records into classes by default because this is the more common scenario. However, you can also make a record struct instead:
public record struct Point(float X, float Y);

//This code will now generate a struct instead of a class, bringing along all the other things we know about structs vs. classes (in particularm this is a value
//type instead of a reference type).

//A record struct creates properties slightly different from class-based structs. They are defined as get/set properties instead of get/init. The record struct above
//becomes something more like this:
public struct Point
{
    public float X { get; set; }

}
