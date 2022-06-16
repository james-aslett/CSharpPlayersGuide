//The object class is the base class of everything, and everything is a specialization of the object class.

//create instance of the object class and use object as a type for a variable:
object thing = new object();

//the object class doesn't have many responsibilities, so creating instances of it is rare.
//it has several methods, including ToString and Equals:
Console.WriteLine(thing.ToString()); //by default, ToString will display the full name of the object's type, eg: System.Object, since the Object class
//lives in the System namespace.

//the Equals method is a bool that will return true/false. The following will display True and then False:
object a = new object();
object b = a;
object c = new object();
Console.WriteLine(a.Equals(b)); //true
Console.WriteLine(a.Equals(c)); //false

//by default, equals will return whether two things are reference to the same object on the heap. But equality is a complex subject. Should two things be equal
//only if they represent the same memory location? Should they be equal if they are of the same type and their fields are equal? 

//suppose we have a Point class:
public class Point
{
    public float X { get; }
    public float Y { get; }

    //even though this class done not define ToString/Equals methods, in has them:

    public Point(float x, float y)
    {
        X = x; Y = y; 
    }


}
