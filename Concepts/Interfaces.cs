//An interface is a type that defines a contract or role that objects cab fulfill or implement:
public interface ILevelBuilder { ILevelBuilder BuildLevel(int levelNumber); }

//Classes can implement interfaces:
public class LevelBuilder : ILevelBuilder { public LevelBuilder BuildLevel(int levelNumber) => new LevelBuilder(); }

//A class can have only one base class but can implement many interfaces