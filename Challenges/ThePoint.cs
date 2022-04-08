//in Main, create a point at (2,3) and another at (-4,0) and display them in the console with the format (x, y)
Point point1 = new(2,3);
Point point2 = new(-4, 0);
Point point3 = new();

Console.WriteLine($"The first point is ({point1.X},{point1.Y})");
Console.WriteLine($"The second point is ({point2.X},{point2.Y})");
Console.WriteLine($"The third point is ({point3.X},{point3.Y})");

//define Point class
public class Point
{
    //define X/Y properties
    public float X { get; }
    public float Y { get; }

    //constructor to create a point from a specific X/Y coordinate
    public Point(float x, float y) 
    {
        X = x;
        Y = y;
    }

    //parameterless constructor to create a point at (0,0). Has an empty body
    public Point() : this(0, 0) { }
}

//Answer this question: are your X and Y properties immutable? Why did you choose what you did?

//They are immutable because they have no ability to set a new value for either one (they have no setters) - usually best to prefer immutable unless
//there's a reason to make them mutable