
//declare a tuple with a string and two ints
(string, int, int) score = ("R2-D2", 12420, 15);
Console.WriteLine($"Name: {score.Item1}, Level: {score.Item2}, Score: {score.Item3}");

//can also declare using var
var score2 = ("R2-D2", 12420, 15);
Console.WriteLine($"Name: {score.Item1}, Level: {score.Item2}, Score: {score.Item3}");

//you can give tuple items a name to make code more readable
(string Name, int Points, int Level) score3 = ("R2-D2", 12420, 15);
Console.WriteLine($"Name: {score3.Name}, Level: {score3.Level}, Score: {score3.Points}");

//if you use var, you must appy names when tuple is formed
var score4 = (Name: "R2-D2", Points: 12420, Level: 15);
Console.WriteLine($"Name: {score4.Name}, Level: {score4.Level}, Score: {score4.Points}");

//you can pass a tuple into a method as a parameter
void DisplayScore((string Name, int Points, int Level) score)
{
    Console.WriteLine($"Name: {score.Name} Level: {score.Level} Score: {score.Points}");
}
DisplayScore(score);

//you can return a tuple from a method by placing its constituent parts in parentheses where we list the return type
(string Name, int Points, int Level) GetScore() => ("R2-D2", 12420, 15);
GetScore();

//a tuple's types and names can be inferred from a called method's return type
var score5 = GetScore();
Console.WriteLine($"Name: {score5.Name} Level: {score5.Level} Score: {score5.Points}");

//this tuple represents a point in a two-dimensional space
(double X, double Y) point = (2.0, 4.0);

//this tuple represents a 4x4 matrix. Perhaps an array would be better in this scenario!
var matrix = (M11: 1, M12: 0, M13: 0, M14: 0, M21: 0, M22: 1, M23: 0, M24: 0, M31: 0, M32: 0, M33: 1, M34: 0, M41: 0, M42: 0, M43: 0, M44: 1);

//creates and returns an array of (string, int, int) tuples to represent a full scoreboard
(string Name, int Points, int Level)[] CreateHighScore()
{
    return new (string, int, int)[3]
    {
        ("R2-D2", 12420, 15),
        ("C-3PO", 8543, 9),
        ("GONK", -1, 1)
    };
}

//we can decontruct tuples
