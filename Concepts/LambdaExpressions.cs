//LAMBDA EXPRESSIONS

//Lamba expressions let you define short, unnamed methods using simplified inline syntax: x => x < 5 is equivalent to bool LessThanFive(int x) => x < 5;
//Multiple and zero parameters are also allowed, but require parentheses: (x, y) => x*x + y*y and () => Console.WriteLine("Hello, World!");
//Types can usually be inferred, but you can explicitly state types: (int x) => x < 5
//Lambdas have a statement form if you need more than just an expression: x => { bool lessThan5 = x < 5; return lessThan5; }
//Lambda expressions can use variables that are in scope at the place where they are defined

//Lambda Expression Basics
