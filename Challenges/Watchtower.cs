public static class Program
{
    public static void Main()
    {
        Console.WriteLine("The enemy is upon us. Please enter your x (horizontal) coordinate.");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter your y (vertical) coordinate.");
        int y = Convert.ToInt32(Console.ReadLine());
        string messageToDisplay = LocationMessage(x, y);
        Console.WriteLine(messageToDisplay);
    }

    public static string LocationMessage(int x, int y)
    {
        string enemyStr = "The enemy is to the ";
        string returnStr;

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

        if (x == 0 && y == 0) returnStr = "The enemy is here!";
        else returnStr = $"{enemyStr}{location}";
        return returnStr;
    }
}