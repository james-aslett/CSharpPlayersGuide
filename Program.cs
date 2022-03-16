

//2: make a tuple variable to represent a meal composed of the three enumeration types
var meal = (Dish.Soup, Ingredient.Mushroom, Seasoning.Spicy);

//3: let the user pick a meal, main ingredient and seasoning from the allowed choices and fill the tuple with the results. HINT: You could give user a menu to pick from
//or simply compare the user's input against specific strings to determine which enum value represents their choice

//4: when done, display contents of the meal tuple variable in a format like "Sweet Chicken Gumbo". HINT: You don't need to convert the enum value back to a string. Simply
//displaying an enumeration value with Write or WriteLine will display the name of the enum value
Console.WriteLine($"You have chosen the {meal}");







//1: define enumerations for 3 variations on food: type (soup, stew, gumbo), main ingredient (mushrooms, chicken, carrots, potatoes) and seasoning (spicy, salty, sweet)
enum Dish { Soup, Stew, Gumbo };
enum Ingredient { Mushroom, Chicken, Carrot, Potato };
enum Seasoning { Spicy, Salty, Sweet };
