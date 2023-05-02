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
