//create tuple consisting of each enum and assign to GetMeal()
(Meal type, MainIngredient ingredient, Seasoning seasoning) meal = GetMeal();

Console.WriteLine($"You have chosen the {meal.seasoning} {meal.ingredient} {meal.type}");

//method takes no args, but its type is a 3-tuple of 3 enums, hence the assignment on line 2 works
(Meal, MainIngredient, Seasoning) GetMeal()
{
    Meal meal = GetMealType();
    MainIngredient ingredient = GetMainIngredient();
    Seasoning seasoning = GetSeasoning();
    return (meal, ingredient, seasoning);
}

Meal GetMealType()
{
    Console.Write("Meal type (soup, stew, gumbo): ");
    string input = Console.ReadLine();
    return input switch
    {
        "soup" => Meal.Soup,
        "stew" => Meal.Stew,
        "gumbo" => Meal.Gumbo
    };
}

MainIngredient GetMainIngredient()
{
    Console.Write("Main ingredient (mushroom, chicken, carrot, potato): ");
    string input = Console.ReadLine();
    return input switch
    {
        "mushroom" => MainIngredient.Mushroom,
        "chicken" => MainIngredient.Chicken,
        "carrot" => MainIngredient.Carrot,
        "potato" => MainIngredient.Potato
    };
}

Seasoning GetSeasoning()
{
    Console.Write("Seasoning (spicy, salty, sweet): ");
    string input = Console.ReadLine();
    return input switch
    {
        "spicy" => Seasoning.Spicy,
        "salty" => Seasoning.Salty,
        "sweet" => Seasoning.Sweet
    };
}

enum Meal { Soup, Stew, Gumbo };
enum MainIngredient { Mushroom, Chicken, Carrot, Potato };
enum Seasoning { Spicy, Salty, Sweet };
