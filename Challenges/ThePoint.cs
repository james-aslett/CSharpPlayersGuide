//in Main, create a point at (2,3) and another at (-4,0) and display them in the console with the format (x, y)
DisplayPoint(new Point(2, 3));
DisplayPoint(new Point(-4, 0));
DisplayPoint(new Point());

void DisplayPoint(Point p)
{
    Console.WriteLine($"({p.X},{p.Y})");
}

//define Point class
public class Point
{
    //define X/Y properties
    public float X { get; }
    public float Y { get; }

    //constructor to create a point from a specific X/Y coordinate
    public Point(float x, float y) 
    {
        //assign the parameters to the X/Y properties
        X = x;
        Y = y;
    }

    //parameterless constructor to create a point at (0,0). Has an empty body
    public Point() : this(0, 0) { }
}

//Answer this question: are your X and Y properties immutable? Why did you choose what you did?

//They are immutable because they have no ability to set a new value for either one (they have no setters) - usually best to prefer immutable unless
//there's a reason to make them mutable