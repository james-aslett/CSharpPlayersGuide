//Checking for null

//if a variable indicates that null is an option, you will want to do a null check before using its members
string? name = Console.ReadLine();
if (name != null)
{
    Console.WriteLine("The name is not null.");
}

//if a variable indicates that null is not an option, you will want to do a null check on any value you're about to assign to it

//Null-Condtitional Operators: ?. and ?[]

//one problem with null checking is that there may be implications down the line. For example:
//private string? GetTopPlayerName()
{
    return _scoreManager.GetScores()[0].Name;
}
//_scoreManager could be null, GetScoreS() could return null, or the array could contain a null reference at index 0. If any of those are null, it will crash.
//we need to check at each step:
private string? GetTopPlayerName()
{
    if (_scoreManager == null) return null;

    Score[]? scores = _scoreManager.GetScores();
    if (scores == null) return null;

    Score? topScore = scores[0];
    if (topScore == null) return null;

    return topScore.Name;
}

//the null checks make the code hard to read. They obscure the interesting parts. There is another way: null-conditional operators. The ?. and ?[] operators
//can be used in place of . and [] to simultaneously check for null and access the member
private string? GetTopPlayerName()
{
    return _scoreManager?.GetScores()?[0]?.Name;
}

//both ?. and ?[] evaluate the part before it to see if it is null. If it is then no further evaluation happens, and the whole expression evaluates to null.
//if it is not null, evaluation will continue as though it has been a normal . or [] operator. So if _scoreManager is null, then the above code returns a null 
//value without calling GetScores. If GetScores() returns null, then index 0 is never accessed.
//these operators do not cover every null-related scenario - you will sometimes need a good old-fashioned if (x == null) - but they can be a simple solution
//in many scenarios.

//The Null Coalesing Operator: ??
//Takes an expression that might be null and provides a value or expression to use as a fallback if it is
private string GetTopPlayerName() // no longer need to allow nulls
{
    return _scoreManager?.GetScores()?[0]?.Name ?? "(not found)";
}
//if the code before the ?? evaluates to null, then the fallback value will be used instead.

//there is also a compound assignment operator for this
private string GetTopPlayerName)()
{
    string? name = _scoreManager?.GetScore()?[0]?.Name;
    name ??= "(not found)";
    return name; //no compiler warning. '??=' ensures we have a real value
}

//The Null-Forgiving Operator: !
//the compiler is pretty thorough in analyzing what can and can't be null and giving you appropriate warnings. On infrequent occasions, you know something
//about the code that the compiler simply can't infer from its analysis, for example
string message = MightReturnNullIfNegative(+10);
//assuming the return type of MightReturnNullIfNegative is string?, the compiler will flag this as a situation where you are assinging a potentially null value
//to a variable that indicated that null isn't allowed. But assuming the method name isn't a lie, we know the returned value can't be null.
//to get rid of the compiler warning, we can use the null-forgiving operator: !. (C# uses this same symbol for the boolean not operator). This operator tells the
//compiler 'I know this looks like a potential null problem, but it won't be. Trust me.'

//Using it looks like this
sring message = MightReturnNullIfNegative(+10)!;
//you place it at the end of an expression that might be null to tell the compiler that it won't actually evaluate to null. Use this operator with caution - you
//have to be sure that you are correct
