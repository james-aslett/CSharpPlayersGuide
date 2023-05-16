//SPEEDRUN
//Pattern matching categorizes data into one or more categories based on its type, properties, etc.
//Switch expressions, switch statements, and the is keyword all use pattern matching
//Constant pattern: matches if the value equals some constant: 1 or null
//Discard pattern: matches anything: _
//Declaration pattern: matches based on type: Snake s or Monster m
//Property pattern: checks an object's properties: Dragon { LifePhase: LifePhase.Ancient }
//Relational patterns: >= 3, < 100
//and, or, and not patterns: LifePhase.Ancient or LifePhase.Adult, not LifePhase.Wyrmling
//var pattern: matches anything but also puts the result into a variable: var x
//Positional pattern: used for multiple elements, tuples, or things with a Deconstruct method to provide sub-patterns for each of the elements: (Choice.Rock, Choice.Scissors)
//Switches also have case guards, using the when keyword: Snake s when s.Length > 2

//Programming is full of categorization problems, where you must decide which of the several categories an object fits in based on its type, properties, etc.
//-Is today a weekend or weekday?
//-In a game where you fight monsters, how many experience points should the player receive after defeating it?
//-In the game of Rock-Paper-Scissors, given the player's choices, which player won?

//You can solve these problems with the venerable if statement, but C# provides another tool designed specifically for these situations: pattern matching. Pattern matching lets you define categorization rules to determine which category an object fits in. You can use pattern matching in switch expressions, switch statements, and the is keyword.

//THE CONSTANT PATTERN AND THE DISCARD PATTERN
//We got our first glimpse in Level 10 when we made our pirate-themed menu:
//string response = choice switch
//{
//  1 => "Ye rest and recover your health.",
//  2 => "Raiding the port town get ye 50 gold doubloons.",
//  3 => "The wind is at your back; the open horizon ahead.",
//  4 => "Tis but a baby Kraken, but still eats toy boats.",
//  _ => "Apologies. I do not know that one."
//};

//This level was our introduction to patterns, though we didn't know it at the time.

//In a switch expression, each arm is defined by a pattern on the left, followed by the => operator, followed by the expression to evaluate if the pattern is a match (pattern expression => evaluation expression). Each pattern is a rule that determines if the object under consideration fits into the category or not. The switch expression above uses the two most basic patterns: the constant pattern and the discard pattern.

//The first four lines show the constant pattern, which decides if there is a match based on whether the item exactly equals some constant value, like the literals 1, 2, 3 or 4.

//The last switch arm uses the discard pattern: _. This pattern is a catch-all pattern, matching anything and everything. In C#, a single underscore usually represents a discard, signifying that what goes in that spot does not matter. Here, it indicates that there is nothing to check - that there are no constraints or rules for matching the pattern. Because it matches anything, when it shows up, it should always be the very last pattern.

//But these two patterns are only the beginning.

//THE MONSTER SCORING PROBLEM
//Having a realistic and complex problem can help illustrate the different patterns we will be learning. In this level, we will use the following problem: in a game where the player fights monsters, given some Monster instance, determine how many points to award the player for defeating it. In code, we might write this problem like so:
//int ScoreFor(Monster monster)
//{
//  // ...
//}

//Let's also define what a Monster is:
//public abstract record Monster;

//Monsters in a real game would likely have more than that, but it's all we need right now. Other monster types are derived from Monster:
//public record Skeleton() : Monster;

//A more complex subtype might add additional properties:
//public record Snake(double Length) : Monster;

//Anacondas are more challenging to defeat than mere garter snakes; the player deserves a larger reward for defeating them:

//Here is a Dragon type that builds on two enumerations:
//public record Dragon(DragonType Type, LifePhase LifePhase) : Monster;
//public enum DragonType { Black, Green, Red, Blue, Gold }
//public enum LifePhase { Wyrmling, Young, Adult, Ancient }

//Each dragon has a type and a life phase. Different types of dragons and different life phases make for more formidable challenges worth more points.

//And here is an orc with a sword that has properties of its own:
//public record Orc(Sword Sword) : Monster;
//public record Sword(SwordType Type);
//public enum SwordType { WoodenStick, ArmingSword, Longsword }

//The sword has a type: a longsword, an arming sword, or a wooden stick. It may be a stretch to call a WoodenStick a sword, but it is always worth compromising the design for stupid humor! (Please don't quote me on that.)

//We could make more, but this is enough to make meaningful patterns.

//THE TYPE ARE DECLARATION PATTERNS
//The type pattern matches anything of a specific type. For example, the following code uses the type pattern to look for the Snake and Dragon types:
//int ScoreFor(Monster monster)
//{
//      return monster switch
//      {
//          Snake s => (int)(s.Length * 2),
//          Dragon d => 50,
//          _ => 5
//      };
//}

//Snake => 7 and Dragon => 50 are both type patterns. (The last is another discard pattern.) If the monster is the named type, it will be match. So this code will return 7 for snakes, 50 for dragon, and 5 otherwise. This pattern is a match even for derived types. A pattern like Monster => 2 would match every kind of monster, regardless of its specific subtype.

//The declaration pattern is similar but additionally gives you a variable that you can use in the body afterward. So we could change this so that longer snakes are worth more points:
//int ScoreFor(Monster monster)
//{
//  return monster switch
//  {
//      Snake s => (int)(s.Length * 2),
//      Dragon => 50,
//      _ => 5
//  };
//}

//I also changed the whitespace to make all of the => elements line up. This spacing is a common practice to increase the readability of the code. It puts it into a table-like format.

//CASE GUARDS
//Switches have a feature called a guard expression or a case guard. These allow you to supply a second expression that must be evaluated before deciding if a specific arm matches. We can use this to have our snake rule apply only to long snakes:
//int ScoreFor(Monster monster)
//{
//  return monster switch
//  {
//      Snake s when s.Length => 3 => 7,
//      Dragon                => 50,
//      _                     => 5
//  };
//}

//Order matters. If you reverse the top two lines, the length-based pattern would never get a chance to match. If the compiler detects this, it will create a compiler error to flag it.

//You can use case guards with any pattern.
