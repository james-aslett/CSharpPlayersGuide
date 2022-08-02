//An interface is a type that defines a contract or role that objects can fulfill or implement:
//public interface ILevelBuilder { ILevelBuilder BuildLevel(int levelNumber); }

//Classes can implement interfaces:
//public class LevelBuilder : ILevelBuilder { public LevelBuilder BuildLevel(int levelNumber) => new LevelBuilder(); }

//A class can have only one base class but can implement many interfaces

//Interfaces are perfect for situations where we know we may want to substitute entirely different or unrelated object to fulfill a specific role
//or responsibility in our system. The only assumption made about the object is that it complies with the defined interface. As long as the two things
//implement the same interface, we can swap one for another and the rest of the system is none the wiser.

//DEFINING INTERFACES

//Let's say we have a game where the player advances through the levels one at a time. Each level is a grid of different terrain types:
public enum TerrainType { Desert, Forests, Mountains, Pastures, Fields, Hills }

//Each level is a 2D grid of terrain types, represented by an instance of this class:
public class Level
{
    public int Width { get; }
    public int Height { get; }
    public TerrainType GetTerrainAt(int row, int column) { /* ... */ }
}

//We find a use for interfaces when deciding where level definitions come from. There are many options. We could define them directly in code,
//setting terrain types at each row and column in C# code. We could load them from files on our computer. We could load them from a database.
//There are many options, yet each one has the same responsibility - create a level. Yet, the code for each is entirely unrelated to the code for
//the other options.

//We may not know yet which of these we will end up using. Or perhaps we plan to retrieve the levels from the Internet but don't intend to get a web
//server running for a few months and need a short-term fix.

//To preserve as much flexibility as possible around this decision, we simply define what this role must do - what interface or boundary the object
//or objects fulfilling this role will have:
public interface ILevelBuilder
{
    Level BuildLevel(int levelNumber);
}

//Members of an interface are public and abstract automatically. After all, an interface defines a boundary (abstract) meant for others to use (public).
//You can place those keywords on there if you like, but few developers do.

//Because an interface defines just the boundary or job to be done, its members don't have an implementation.

//Interfaces can have as many members (methods) as they need to define the role they represent, eg: you could let the rest of the game know how many
//levels are in the set by adding an int Count { get; } property.

//IMPLEMENTING INTERFACES

//Once an interface has been created, the next step is to build a class that fulfills the job described by the interface. This is called implementing
//the interface. It looks like inheritance, so some devs also call is extending/deriving from the interface.

//The simplest implementaton of the ILevelBuilder interface is probably defining levels in code:
public class FixedLevelBuilder : ILevelBuilder
{
    public Level BuildLevel(int levelNumber)
    {
        Level level = new Level(10, 10, TerrainType.Forests);

        level.SetTerrainAt(2, 4, TerrainType.Mountains);
        level.SetTerrainAt(2, 5, TerrainType.Mountains);
        level.SetTerrainAt(6, 1, TerrainType.Desert);
    }
}

//You must define each member included in the interface, as we did with the BuildLevel method. These will be public but do not put the override keyword
//on them. This isn't an override. It is simply filling in the definition of how this class performs the job it has claimed to do by implementing
//the interface.

//A class that implements an interface can have other members unrelated to the interfaces it implements. By indicating that a class implements an
//interface, you are saying that it will have AT LEAST the capabilities defined by the interface, not that it is limited to the interface. One
//notable example is that an interface can declare a property with a get accessor, while a class that implements it can ALSO include a set or init
//accessor.

//We can create variables that use an interface as their type and place in it anything that implements that interface:
ILevelBuilder levelBuilder = LocateLevelBuilder();

int currentLevel = 1;

while (true)
{
    Level level = levelBuilder.BuildLevel(currentLevel);
    RunLevel(level);
    currentLevel++;
}
//The rest of the game doesn't care which implementation of ILevelBuilder is being used. However, with the code we have written so far, we know it will
//be FixedLevelBuilder since that is the only one that exists. However, by doing nothing more than adding a new class that implements ILevelBuilder
//and changing the implementation of LocateLevelBuilder to return that instead, we can completely change the source of levels in our game. The entire
//rest of the game does not care where they come from, as long as the object building them conforms to the ILevelBuilder interface. We have reserved
//a great degree of flexibility for the future by merely defining and using an interface.

//INTERFACES AND BASE CLASSES

//Interfaces and base classes can play nicely together. A class can simultaneously extend a base class and implement an interface. Do this by listing
//the base class followed by the interface after the colon, separated by commas:
public class MySqlDatabaseLevelBuilder : BasicDatabaseLevelBuilder, ILevelBuilder { /*...*/ }

//A class can implement several interfaces in the same way by listing each one, separated by commas:
public class SomeClass : ISomeInterface1, ISomeInterface2 { /* ... */ }

//While you can only have one base class, a class can implement as many interfaces as you want (though this may indicate that an object or class is
//trying to do too much.)

//Finally, an interface itself can list other interfaces (but not classes) that it augments or extends:
public interface IBroaderInterface : INarrowerInterface { /* ... */ }

//When a class implements IBroaderInterface, they will also be on the hook to implement INarrowerInterface.

//EXPLICIT INTERFACE IMPLEMENTATIONS

//Occasionally, a class implements two different interfaces containing members  with the same name but different meanings, eg:
public interface IBomb { void BlowUp(); }
public interface IBalloon { void BlowUp(); }

public class ExplodingBalloon : IBomb, IBalloon
{
    public void BlowUp() { /*...*/ }
}

//This single method is enough to implement both IBomb and IBalloon. If this one method definition is a good fit for both interfaces, you are done.

//On the other hand, in this situation, "blow up" means different things for bombs than it does balloons. When we define ExplodingBalloon's
//BlowUp method, which one are we referring to?

//If you have control over these interfaces, consider renaming one or the other. We could rename IBomb.BlowUp to Detonate or IBalloon.BlowUp to
//Inflate. Problem solved.

//But if you don't want to or can't, the other choice is to make a definition for each using an explicit interface implementation:
public class ExplodingBalloon : IBomb, IBalloon
{
    void IBomb.BlowUp() { Console.WriteLine("Kaboom!"); }
    void IBalloon.BlowUp() { Console.WriteLine("Whoosh!"); }
}

//By prefacing the method name with the interface name, you can define two versions of BlowUp, one for each interface. Note that the public has been
//removed. This is required with explicit interface implementations.

//The big surprise is that explicit implementations are detached from their containing class:
ExplodingBalloon explodingBalloon = new ExplodingBalloon();
// explodingBalloon.BlowUp(); // COMPILER ERROR!

IBomb bomb = explodingBalloon;
bomb.BlowUp();

IBalloon balloon = explodingBalloon;
balloon.BlowUp();

//In this situation, you cannot call BlowUp directly on ExplodingBalloon! Instead, you must store it in a variable that is either IBomb or IBalloon
//(or cast it to one or the other). Then it becomes available because it is no longer ambiguous.

//If one of the two is more natural for the class, you can choose to do an explicit implementation for only one, leaving the other as the default.
//If you do this, then the non-explicit implementation is accessible on the object without casting it to the interface type.

//DEFAULT INTERFACE METHODS

//Interfaces allow you to create a default implementation for methods with some restrictions. (If you do not like these restrictions, an abstract
//base class may be a better fit.) Default implementations are primarily for growing or expanding an existing interface to do more. Imagine having
//an interface with ten classes that implement the interface. If you want to add a new method or property to this interface, you have to revisit
//each of the ten implementations to adapt them to the new changes.

//If you can get an interface definition right the first time around, it saves you from this rework. It is worth taking time to try to get interfaces
//right, but we can never guarantee that. Sometimes, things just need to change.

//Of course, you can just go for it and add the new member to each of the many implementations. This is often a good, clean solution, even though
//it takes time.

//In other situations, providing a default implementation for a method can be a decent alternative. Imagine you have an interface that a thousand
//programmers around the world use. If you change it, they'll all need to update their code. A default implementation may save a lot of pain
//for many people.

//Let's suppose we started with this interface definition:
public interface ILevelBuilder
{
    Level BuildLevel(int levelNumber);
    int Count { get; }
}

//If we wanted to build all the levels at once, we might consider adding a Level[] BuildAllLevels() method. Adding this is easy:
public interface ILevelBuilder
{
    Level BuildLevel(int levelNumber);
    int Count { get; }
    Level[] BuildAllLevels();
}

//But the logic for this is pretty standard, and if we can just make a default implementation for BuildAllLevels(), nobody is required to make their
//own. We can grow the interface almost for free:
public interface ILevelBuilder
{
    Level BuildLevel(int levelNumber);
    int Count { get; }
    Level[] BuildAllLevels()
    {
        Level[] levels = new Level[Count];

        for (int index = 1; index <= Count; index++)
            levels[index - 1] = BuildLevel(index);

        return levels;
    }
}

//With the default implementation, nobody else will have to write a BuildAllLevels method unless they need something special. But if they do, it is
//a simple matter of adding a definition for the method in the class.

//A default implementation can use the other members of the interface. We see that above since BuildAllLevels calls both Count and BuildLevel.

//Support Default Interface Methods

//Default interface method implementations are a relatively new thing to C#. When they decided to add this feature, they provided many of the tools
//needed to do it well. For example, if a single method becomes too big, you can split some of the code into private methods. You can also create
//protected methods and static methods. Default method implementations are not all that common. You cannot add instance fields. Interfaces cannot
//contain data themselves.

//Should I Use Default Interface Methods?

//Adding default implementations in an interface was a somewhat controversial change. It is hard for those making widely used interfaces to update
//every implementing class. The benefits of default implementations are a lifesaver to them. But for many others, the benefits are small, and it
//serves little value other than to cloud the concept of an interface.

//Should you embrace them and provide one for every method you make, avoid them like the plague, or something in between?

//My recommendation stems from the fact that interfaces are meant to define just the boundary, not the implementation. I suggest skipping default
//implementations except when many classes implement the interface and when default implementation is nearly always correct for the classes that
//use the interface.

//Not every interface change can be solved with default method implementations. It only works if you are adding new stuff to an interface. If you are
//renaming or removing a method, you will just need to fix all the classes that implement the interface.