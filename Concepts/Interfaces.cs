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

//Each level is a 2D grid of these terrain types, represented by an instance of this class:
public class Level
{
    public int Width { get; }
    public int Height { get; }
    public TerrainType GetTerrainAt(int row, int column) { /* ... */ }
}

//We find a user for interfaces when deciding where level definitions come from. There are many options. We could define them directly in code,
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

//The simplest implementaton of the ILevelBuilder interfae is probably defining levels in code:
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

//You must define each member included in the interface, as we did with the BuildLevel method. These will be public but do not put the ovveride keyword
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
//rest of the game does not care where they come from, as long as the object building them confirms to the ILevelBuilder interface. We have reserved
//a great degree of flexibility for the future by merely defining and using an interface.

//INTERFACES AND BASE CLASSES

//Interfaces and base classes can play nicely together. A class can simultaneously extend a base class and implement an interface. Do this by listing
//the base class followed by the interface after the colon, separated by commas:
public class MySqlDatabaseLevelBuilder : BasicDatabaseLevelBuilder : ILevelBuilder { /*...*/ }

//A class can implement several interfaces in the same way by listing each one, separated by commas:
public class SomeClass : ISomeInterface1, SomeInterface2 { /* ... */ }

//While you can only have one base class, a class can implement as many interfaces as you want (though this may indicate that an object or class is
//trying to do too much).

//Finally, an interface itself can list other interfaces (but not classes) that it augments or extends:
public interface IBroaderInterface : INarrowerInterface { /* ... */ }

//When a class implements IBrowserInterface, they will also be on the hook to implement INarrowerInterface.

//EXPLICIT INTERFACE IMPLEMENTATIONS




