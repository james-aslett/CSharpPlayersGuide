//An interface is a type that defines a contract or role that objects can fulfill or implement:
public interface ILevelBuilder { ILevelBuilder BuildLevel(int levelNumber); }

//Classes can implement interfaces:
public class LevelBuilder : ILevelBuilder { public LevelBuilder BuildLevel(int levelNumber) => new LevelBuilder(); }

//A class can have only one base class but can implement many interfaces

//Interfaces are perfect for situations where we know we may want to substitute entirely different or unrelated object to fulfill a specific role
//or responsibility in our system. The only assumption made about the object is that it complies with the defined interface. As long as the two things
//implement the same interface, we can swap one for another and the rest of the system is none the wiser.

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

