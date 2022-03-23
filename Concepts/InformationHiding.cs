//fields in classes should almost always be private - in this example, we can still use the fields inside the class as the constructor does to initialize them, but
//the outside world cannot change the area and create an inconsistent rectangle


//these lines will fail, because we've made _area private. Since the outside world needs to know the rectangle's area, must be make this field public?
////Generally, no. Instead, we provide controlled access through methods
Rectangle rectangle = new Rectangle(2, 3);
Console.WriteLine(rectangle._area);

//if we want to create a rectangle and change its size, we use the new methods instead of directly accessing its fields
Rectangle rectangle2 = new Rectangle(2, 3);
rectangle2.SetWidth(3);
Console.WriteLine(rectangle2.GetArea());

class Rectangle
{
    private float _width;
    private float _height;
    private float _area;

    public Rectangle(float width, float height)
    {
        _width = width;
        _height = height;
        _area = UpdateArea(_width, _width);
    }

    //these public methods allow the outside world to access the data behind the private fields without having direct access to them
    public float GetWidth() => _width;
    public float GetHeight() => _height;
    public float GetArea() => _area;

    //if the outside world needs to change the rectangle's dimensions we can also solve that with methods
    public void SetWidth(float value)
    {
        _width = value;
        _area = UpdateArea(_width, _width);
    }

    public void SetHeight(float value)
    {
        _height = value;
        _area = UpdateArea(_width, _width);
    }

    //updating the area is not something the outside world should have to request specifically. It is details of how we have created the Rectangle class, so
    //is best off as a private method
    private float UpdateArea(float width, float height)
    {
        return width * height;
    }

    //we've decided that it is reasonable to ask a rectangle to update its width and height and so have added methods for these. But we've decided not to let people
    //directly change the area, so we've left that one out

    //methods that retriee a field's current value are called getters
    //methods that assign a new value to a field are called setters

    //information hiding allows an object to protect its data. Each object is its own gatekeeper. If another object wants to see what state the object is in
    //or change its state, it must request that information by calling a getter or a setter method, rather than just grabbing it directly. This way, objects
    //can enforce rules about their data

    //information hiding comes at a cost of added complexity, but it's worth it, and we'll see a better better example in Level 20
}
