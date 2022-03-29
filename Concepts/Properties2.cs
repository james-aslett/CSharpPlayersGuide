//while constructors should get the object into a good starting state, some initialization is best done immediately after the object is constructed, changing the
//values to a handful of properties right after construction. It is like making some final adjustments are the concrete is still drying.

//with the below Circle class, we could make a new circle and set its properties like this:
Circle circle = new Circle();
circle.Radius = 3;
circle.X = -4;

//C# provides a simple syntax for setting properties right as the object is created, called 'object initializer syntax':
Circle circle2 = new Circle() { Radius = 3, X = 4 };

//if the constructor is parameterless you can leave out the parentheses
Circle circle3 = new Circle { Radius = 3, X = 4 };

//you cannot use object initializer syntax with properties that are get-only. You can instead use an 'init' accessor. This is a settor that can be used in limited
//circumstances, including with an inline initializer (the 0's below) and in the constructor, but also in object initializer syntax
public class Circle
{
    public float X { get; init; } = 0;
    public float Y { get; init; } = 0;
    public float Radius { get; init; } = 0;
}
