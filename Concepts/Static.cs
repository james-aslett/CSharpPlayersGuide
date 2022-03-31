//in C#, class members naturally belong to instances of the class
public class SomeClass
{
    private int _number;
    public int Number => _number;
}
//each instance of SomeClass has its own _number field, and calling methods or properties like the Number property is associated with specific instance and their
//individual data. Each instance is independent of the others, other than sharing the same class definition

//But you can also mark members of a class with the static keyword to detach them from individual instances and tie it to the class itself. In VB, the keyword is
//Shared, which is a more intuitive name

//Static fields - useful for defining variables that affect every instance of the class, eg: we can add two static fields that will help determine if a score is
//worth putting on the highsocre table
public class Score
{
    private static readonly int PointThreshold = 1000;
    private static readonly int LevelThreshold = 4;
}

//