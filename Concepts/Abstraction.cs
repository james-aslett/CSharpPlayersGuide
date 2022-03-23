//Earlier versions of our Rectangle class (see Information Hiding.cs) had a field for the rectangle's area, which got updated every time the width or height changed.
//But we can change this to compute the area as needed and ditch the field without affecting the rest of our program

class Rectangle
{
    private float _width;
    private float _height;
    //private float _area //we've removed this

    public Rectangle(float width, float height)
    {
        _width = width;
        _height = height;
    }

    public float GetWidth() => _width;
    public float GetHeight() => _height;

    //area now calculated on demand. The outside world is oblivious to this change. They used to retrieve the area through GetArea() and they still do
    public float GetArea() => _width * _height;

    public void SetWidth(float value) => _width = value;
    public void SetHeight(float value) => _height = value;
}

//difference between public and internal

//public can be accessed anywhere, including in other projects
public class Rectangle2
{

}

//internal can only be used in the project in which it is defined
internal class Rectangle3
{

}

//if you make a class and feel that its role is a supporting role - details that help other classes accomplish their job - but not something you want the
//outside world to know about, then internal could be a suitable choice