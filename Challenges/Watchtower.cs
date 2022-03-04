int x = AskForNumber("The enemy is upon us. Please enter your x (horizontal) coordinate.");
int y = AskForNumber("Please enter your y (vertical) coordinate.");

string messageToDisplay = LocationMessage(x, y);
Console.WriteLine(messageToDisplay);

string LocationMessage(int x, int y)
{
    string yDirection;
    if (y < 0) yDirection = "South";
    else if (y > 0) yDirection = "North";
    else yDirection = "";

    string xDirection;
    if (x < 0) xDirection = "West";
    else if (x > 0) xDirection = "East";
    else xDirection = "";

    string location;
    if (yDirection == "" | xDirection == "") location = $"{yDirection}{xDirection}";
    else if (yDirection == "" | xDirection != "") location = $"{yDirection}{xDirection.ToLower()}";
    else location = "";

    if (yDirection != "") xDirection = xDirection.ToLower();

    if (x == 0 && y == 0) return "The enemy is here!";
    return $"The enemy is to the {yDirection}{xDirection}.";
}

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}