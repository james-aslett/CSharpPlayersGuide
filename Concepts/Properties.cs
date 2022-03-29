
//the most significant benefit of the below class/property structure is to the outside world, which now has field-like access to the properties instead of
//method-like access
Rectangle r = new Rectangle(2, 3);
r.Width = 5; //calls the Width's property setter, and the special 'value' variable will be 5 when the setter code runs
Console.WriteLine($"A {r.Width} x {r.Height} rectangle has an area of {r.Area}"); //calls the Width/Height/Area getters


public class Rectangle
{
    private float _width;
    public float _height;

    public string _name { get; set; } = "Player"; //example of auto-implemented property with a starting value

    //constructor
    public Rectangle(float width, float height)
    {
        _width = width;
        _height = height;
    }

    //properties for getting and setting Width/Height. Properties include a special 'value' keyword so don't need to define one

    //example with expression body
    public float Width
    {
        get => _width;
        set => _width = value;
    }

    //example with block body
    public float Height
    {
        get
        {
            return _height;
        }
        set
        {
            _height = value;
        }
    }

    //get-only properties make sense for something that can't be changed from the outside
    public float Area
    {
        get => _width * _height;
    }

    //if the property is get-only with an expression body like above, we can simplify it further
    public float AreaSimple => _width * _height;
}
//with an immutable (or read only) property, you have complete control over when the object is created, but it cannot be changed again once created
public class Player
{
    private readonly string _name; //immutable field
    public string Name { get; } = "Player 1";

    public Player(string name)
    {
        Name = name;
    }
}

//the getter is public, so we can always get the current value of Name and even without a setter, we can still assign a value to Name in an initializer or
//constructor. But after creation, we cannot change Name from inside or outside the class. While this sounds restrictive, there are many benefits to immutability.
//For example, with immutable properties there is no possible way for the data to become inconsistent afterward.

//the getter is public, so we can always get the current value of Name and even without a setter, we can still assign a value to Name in an initializer or
//constructor. But after creation, we cannot change Name from inside or outside the class. While this sounds restrictive, there are many benefits to immutability.
//For example, with immutable properties there is no possible way for the data to become inconsistent afterward.

//when all of a classe's fields and properties are immutable (get only properties and readonly fields) the entire object is immutable. Not every object should be made
//immutable. But when they can be, they are much easier to work with because you know the object cannot change.
