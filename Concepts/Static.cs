//in C#, class members naturally belong to instances of the class
public class SomeClass
{
    private int _number;
    public int Number => _number;
}
//each instance of SomeClass has its own _number field, and calling methods or properties like the Number property is associated with the specific instance and their
//individual data. Each instance is independent of the others, other than sharing the same class definition

//But you can also mark members of a class with the static keyword to detach them from individual instances and tie it to the class itself. In VB, the keyword is
//Shared, which is a more intuitive name

//Static fields - useful for defining variables that affect every instance of the class, eg: we can add two static fields that will help determine if a score is
//worth putting on the highsocre table
public class ScoreFields
{
    private static readonly int PointThreshold = 1000;
    private static readonly int LevelThreshold = 4;
}

//fields are usually _lowerCamelCase, eg: _pointThreshold, but static fields are UpperCamelCase, eg: PointThreshold
//sometimes people refer to regular non-static fields as 'instance fields'

//If a static field is public, it can be used outside the class through the class name, eg: Score.PointThreshold

//Global State
//Static fields have their uses, but caution is advised. If a field is static, public and not readonly, it creates global state. Global state is data that can be
//changed and used anywhere in your program. This is considered dangerous because one part of your program can affect other parts even though they seem unrelated
//to each other. Unexpected changes to global state can lead to bugs that take a long time to debug, and in most situations you're better off not having it.
//It is the combination that is dangerous. Making a field private limits access to just the class, which is easier to manage. Making it readonly ensures it
//can't change over time, preventing one part of the code interfering with other parts. If it is not static, only parts of the program that have a reference
//to the object will be able to do anything with it. Just be cautious any time you make a public static field

//Static Properties
//Properties can also be made static. These can use static fields as their backing fields, or you can make them auto-properties. These have the same global state
//issue that fields have, so be careful with public static properties as well

//below is the property version of the above threshold fields
public class ScoreProperties
{
    public static int PointThreshold { get; } = 1000;
    public static int LevelThreshold { get; } = 4;
}

//we use static properties on the Console class. Console.ForegroundColor is a good example of the danger of global state. If one part of the code changes the
//color to red to display an error, everything afterward will also be written in red until somebody changes it back

//Static Methods
//Methods can also be static. A static method is not tied to a single instance, so it cannot reer to any non-static (instance) fields, properties or methods.
////Static methods are most often used for utility or helper methods that provide some sort of service related to the class they are placed in, but that isn't
////tied directly to a single instance. For example, the following method determines how many scores in an array belong to a specific player
public static int CountForPlayer(string playerName, Score[] scores)
{
    int count = 0;
    foreach (Score score in scores)
    {
        if (score.Name == playerName) count++;
    }
    return count;
}
//this method would not make sense as an instance method because it is about many scores, not a single one. But it makes sense as a static method in the Score
//class because it is closely tied to the Score concept

//another common use of static methods is a factory method, which creates new instances for the outside world as an alternative to calling a constructor. For example,
//this method could be a factory method in our Rectangle class

Rectangle rectangle = Rectangle.CreateSquare(2); //calling factory method outside of the Rectangle class
public class Rectangle
{
    private float _width;
    public float _height;

    public static Rectangle CreateSquare(float size) => new Rectangle(size, size); //factory method

    public Rectangle(float width, float height)
    {
        _width = width;
        _height = height;
    }
}

//Static Constructors
//If a class has static fields or properties, you may need to run some logic to initialize them. To address this, you could define a static constructor
public class Score
{
    public static readonly int PointThreshold;
    public static readonly int LevelThreshold;

    static Score()
    {
        PointThreshold = 1000;
        LevelThreshold = 4;
    }
}
//A static constructor cannot have parameters, nor can you call it directly. Instead, it runs automatically the first time you use the class. Because of this,
//you cannot place an accessibility modifier like public or private on it

//Static Classes
//Some classes are nothing more than a collection of related utility methods, fields or properties. Console, Convert and Math are all examples of this
var x = new Console; //this won't work, because Console class is static

//In these cases, you may want to forfit creating instances of the class, which is done by marking it with the static keyword
public static class Utilities
{
    public static int Helper1() => 4;
    public static double HelperProperty => 4.0;
    public static int AddNumbers(int a, int b) => a + b;
}

//The compiler will ensure that you don't accidentally add non-static members to a static class and prevent new instances from being created with the 'new' keyword.
//Because Console, Convert and Math are all static classes, we never needed - nor were we allowed - to make an instance with the 'new' keyword



