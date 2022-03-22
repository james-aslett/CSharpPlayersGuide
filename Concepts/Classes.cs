// <-- Your Main method goes here

//create new instance of class (which expects parameters as we included them in our constructor)
Score best = new Score("James", 100, 5);

//define new class
class Score
{
    //fields
    private string _name;
    private int _points;
    private int _level;

    //constructor sets fields to their initial values
    public Score(string name, int points, int level)
    {
        _name = name;
        _points = points;
        _level = level;
    }

    //you can have multiple constructors with same name, using different number/type of parameters
    public Score(string name, int points)
    {
        _name = name;
        _points = points;
    }

    //you define methods in a class
    public bool EarnedStar() => (_points / _level) > 1000;
}



// <-- other classes and enumerations can go here
