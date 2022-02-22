//page 67
Console.WriteLine($"{Math.PI}"); //displays "3.141592653589793"
Console.WriteLine($"{Math.PI:0.000}"); //displays "3.142"
Console.WriteLine($"{42:#.##}"); //displays 42
Console.WriteLine($"{42.1234:#.##}"); //displays 42.12

float currentHealth = 4;
float maxHealth = 9;
Console.WriteLine($"{currentHealth / maxHealth:0.0%}"); //displays "44.4%"