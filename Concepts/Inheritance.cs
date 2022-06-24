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

//If a parameterless constructor exists in the base class, a constructor in a derived class will automatically call it before running its own code.
//And remember: if a class does not define any constructor, the compiler will generate a simple, parameterless constructor. The compiler-made one will work
//fine for our own purposes here. This is what has happened in our simple inheritance hierarchy. Neither GameObject not Asteroid specifically defined any
//constructors. The compiler generated a parameterless constructor in both classes, and the one in Asteroid automatically called the one in GameObject.

//The same thing happens if you have manually made parameterless constructors:

public class GameObject
{
    public GameObject()
    {
        PositionX = 2; PositionY = 4;
    }

    //Properties and other things here
}

public class Asteroid : GameObject
{
    public Asteroid()
    {
        RoatationAngle = 1;
    }

    //Properties and other things here
}

//Here, Asteroid's parameterless constructor will automatically call GameObject's parameterless constructor. Calling 'new Asteroid()' will enter Asteroid's constructor
//and immediately jump to GameObject's parameterless constructor to set PositionX and PositionY and then return to Asteroid's constructor to set RotationAngle.

//Suppose a base class has more than one constructor or does not include a parameterless constructor (both common scenarios). In that case, you will need to expressly
//state which base class constructor to build upon for any new constructors in the derived class.

//Let's suppose GameObject has only this constructor:
public GameObject(float positionX, float positionY, float velocityX, float velocityY)
{
    PositionX = positionX; PositionY = positionY;
    VelocityX = velocityX; VelocityY = velocityY;
}
//Since there is no parameterless constructor to call, any constructors defined in Asteroid will need to specifically indicate that it is using this other
//constructor and supply arguments for its parameters:
public Asteroid() : base(0, 0, 0, 0)
{

}
//It is relatively common to pass along parameters from the current constructor down to the base class's constructor, so the following might be more common:
public Asteroid(float positionX, float positionY,float velocityX, float velocityY) : base(positionX, positionY, velocityX, velocityY)
{

}

//We saw something similar in Level 18, with just the keyword this instead of base. It works in the same way, just reaching down to the base class's constructors
//instead of this class's constructors. You cannot use both this and base together on a constructor, but a constructor can call out another constructor in the
//same class with this instead of using base. Since constructor calls with this cannot create a loop, eventually, something will need to pick a constructor
//from the base class.

//Those rules are a bit complicated, so let's recap. Constructors are not inherited like other members are. Constructors in the derived class must call out
//a constructor from the base class (with 'base') to build upon. Alternatively, they can call out a different one in the same class (with 'this').
//If a parameterless constructor exists, including one the compiler generates, you do not need to state it explicitly with 'base'. But don't worry;
//the compiler will help you spot any problems.

//CASTING AND CHECKING FOR TYPES

//If you ever have a base type but need to get a derived type out of it, you have some options. Consider this situation:
GameObject gameObject = new Asteroid();
Asteroid asteroid = gameObject; //ERROR!#
//the gameObject variable can only guarantee that it has a GameObject. It might reference something more specific, like an Asteroid. In the above code
//we know that's true.

//By casting, we can get the compiler to treat the object as the more specialised type:
GameObject gameObject = new Asteroid();
Asteroid asteroid = (Asteroid)gameObject; //Use with caution

//Casting tells the compiler 'I know more about this than you do, and it will be safe to treat this as an asteroid.' The compiler will allow this code
//to compile, but the program will crash when running if you are wrong. The above code is guaranteed to be safe, but this one is not:
Asteroid probablyAnAsteroid = (Asteroid)CreateAGameObject();
GameObject CreateAGameObject() {  }
//This cast is risky. Is assumes it will get an Asteroid back, but that's not a guaranteed thing. If CreateAGameObject returns anything else,
//this program will crash.

//Casting from a base class to a derived class is called a downcast. Incidentally, that is how you should feel when doing it. You should not
//generally do it, and usually only if you check for the correct type first. There are three ways to do this check:

//The first way is with object's GetType() method and the typeof keyword:
if (gameObject.GetType() == typeof(Asteroid)) {  }
//For each type that your program uses, the C# runtime will create an object representing information about that type. These objects are instances
//of the Type class, which is a type that has metadata about other types in your program. Calling GetType() returns the type object associated
//with the instance class. If gameObject is an Asteroid, it will return the Type object representing the Asteroid class. If it is a Ship, GetType will
//return the Type object representing the Ship class. The typeof keyword lets you access these special objects by name instead. Using code like this,
//you can see if an object's type matches some specific class.

//Using typeof and .GetType() only work if there is an extact match. If you have an Asteroid instance and do asteroid.GetType() == typeof(GameObject),
//this evaluates to false. The Type instances that represent the Asteroid and GameObject classes are different. That can work for or against you,
//but it is important to keep in mind.

//Another way is through the 'as' keyword:
GameObject gameObject = CreateAGameObject();
Asteroid? asteroid = gameObject as Asteroid;
//The 'as' keyword simultaneously does a check AND the conversion. If gameObject is an Asteroid (or something derived from Asteroid), then the
//variable asteroid will contain the reference to the object, now known to be an Asteroid. If gameObject is a Ship or a Bullet, then Asteroid
//will be null. That means you will want to do a null check before using the variable.

//The third way is with the 'is' keyword. The 'is' keyword is powerful and is one way to use patterns, which is the topic of level 40, But it is
//freqently used to simply check the type and assign it to a new variable. The most common way to use it is like this:
if (gameObject is Asteroid asteroid)
{
    //You can use the 'asteroid' variable here
}

//If you don't need the variable that this create, you can skip the nameL
if (gameObject is Asteroid)

//THE PROTECTED ACCESS MODIFIER

    //We have already encountered three access modifiers in the past: private, public and internal. The fourth accessibility modifier is the protected
    //keyword. If something is protected, it is accessible within the class and also any derived class. For example:

public class GameObject {
    public float PositionX { get; protected set; }
    public float PositionY { get; protected set; }
    public float VelocityX { get; protected set; }
    public float VelocityY { get; protected set; }
}
//If we make these setters protected instead of public, only GameObject and its derived classes (like Asteroid and Ship) can change those properties;
//the outside world cannot.

//SEALED CLASSES

//If you want to forbid others from deriving from a specific class, you can prevent it by adding the sealed modifier to the class defenition:
public sealed class Asteroid : GameObject
{
    
}
//In this case, nobody will be able to derive a new class based on Asteroid. It is rare to want an outright ban on deriving from a class, but it has
//occasional uses. Sealing a class can also sometimes result in a performance boost.


