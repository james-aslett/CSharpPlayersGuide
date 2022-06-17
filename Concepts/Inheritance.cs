//INHERITANCE AND THE OBJECT CLASS

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

//suppose we have a Point class. Even though this class done not define ToString/Equals methods, in has them:
Point p1 = new Point(2, 4);
Point p2 = p1;
Console.WriteLine(p1.ToString());
Console.Write(p1.Equals(p2));

//..this is because Point inherits these methods from its base class, object. Because a derived class has all the base classes' capabilities,
//you can use the derived class anywhere the bass class is expected:
object thing = new Point(2, 4);

//The variable holds a reference to something with a type of object. We give it a reference to a Point instance. Point is a different class
//than object, but Point is derived from object and can thus be treated as one.

//This makes things interesting. The thing variable knows it holds objects. You can use its ToString/Equals methods, but the variable makes no
//promises that it has a reference to anything more specific than object:

Console.WriteLine(thing.ToString()); // Safe
Console.WriteLine(thing.X); //Compiler error

//even though we put an instance of Point into our thing variable, the variable itself can only guarantee that it has a reference to an object.
//It could be a Point, but the variable and the compiler cannot guarantee that, even though a human can see it from inspecting the code.
//Once we place a reference to a derived class like Point into a base class variable like object, that information is not lost forever. Later,
//we'll see how we can explore an object's type and cast to the derived type if needed, to regain access to the object as the derived type.

public class Point
{
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y)
    {
        X = x; Y = y; 
    }
}

//CHOOSING BASE CLASSES

//By default, all classes inherit from object, but it is not hard to claim a different class as the base class.

//Going back to drifting through space logic from Asteroids, the ship and bullets would both need the same behaviour. We could make a GameObject
//class that serves as a base class for all of these:
public class GameObject
{
    public float PositionX { get; set; }
    public float PositionY { get; set; }
    public float VelocityX { get; set; }
    public float VelocityY { get; set; }

    public void Update()
    {
        PositionX += VelocityX;
        PositionY += VelocityY;
    }
}
//We can now create an Asteroid class that includes things specific to just the asteroid and indicate that this class is derived from GameObject
//instead of plain object:
public class Asteroid: GameObject
{
    public float Size { get; }
    public float RoatationAngle { get; }
}
//As shown above, a class identifies its base class by placing its name after a colon. Asteroid will inherit PositionX, PositionY, VelocityX,
//VelocityY and Update from its base class, GameObject. It also adds new Size and RotationAngle properties, which are unique to Asteroid.

//Let's suppose we also make Bullet and Ship classes that also derive from GameObject. We could set up a new game of Asteroids with a collection
//of game objects of mixed types like this:
GameObject[] gameObjects = new GameObject[]
{
    new Asteroid(), new Asteroid(), new Asteroid(),
    new Bullet(), new Ship()
}
//Okay, you probably won't start a new game with a bullet flying around, but you get the idea. The array stores references to GameObject instances.
//But that array contains instances of the Asteroid, Bullet and Ship classes. The array is fine with this because all 3 of those types derive
//from GameObject.

//Here's where things get interesting:
foreach (GameObject item in gameObjects)
    item.Update();

//Even though we are dealing with 4 classes (1 base and 3 derived), we can call the Update method on any of them since it is defined by GameObject.
//All of the derived classes are guaranteed to have that method.

//Inheritance only goes one way. While you can use an Asteroid when a GameObject is needed, you cannot use a GameObject where an Asteroid is needed.
//Nor can you use an Asteroid when a Ship/Bullet is needed:
Asteroid asteroid = new GameObject(); //Compiler error
Ship ship - new Asteroid(); //Compiler error

//A collection of classes related through inheritance, such as there 4, is called an inheritance hierarchy. These can be as deep as you need them
//to be. For example:
public class Scout : Ship { /* ... */ }
public class Bomber : Ship { /* ... */ }

//The Bomber and Scout classes derive from Ship, which derives from GameObject, which derives from object. You can use a Bomber anywhere a Ship, 
//GameObject or object is needed.

//However, classes may only choose one base class. You cannot directly derive from more than one. There are situations where this is somewhat
//limiting, but complications arise from this, so C# forbids it.

//CONSTRUCTORS

//A derived class inherits most members from a base class, but not constructors. Constructors put a new object into a valid starting state.
//A constructor in the base class can make no guarantees about the validity of an object of a derived class. So constructors are not inherited,
//and derived classes must supply their own. However, we can - and must - leverage the constructors defined in the base class when making
//new constructors in the derived class.



