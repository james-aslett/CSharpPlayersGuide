int number = AskForNumberInRange("Airship pilot, enter a number between 0 and 100", 0, 100);

Console.Clear();

Console.WriteLine("Hunter, guess the number");

while (true)
{
    int hunterGuess = AskForNumber("What is your next guess?");
    if (hunterGuess > number) Console.WriteLine($"{hunterGuess} is too high.");
    else if (hunterGuess < number) Console.WriteLine($"{hunterGuess} is too low.");
    else break;
}

Console.WriteLine("That is the correct number!");

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {
        int number = AskForNumber(text);
        if (number >= min && number <= max)
            return number;
    }
}