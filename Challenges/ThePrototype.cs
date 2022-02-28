int pilotInput;

do
{
    Console.WriteLine("Airship pilot, enter a number between 0 and 100");
    pilotInput = Convert.ToInt32(Console.ReadLine());
}
while (pilotInput < 0 || pilotInput > 100);

Console.Clear();

Console.WriteLine("Hunter, guess the number");

while (true)
{
    Console.WriteLine("What is your next guess?");
    int hunterGuess = Convert.ToInt32(Console.ReadLine());

    if (hunterGuess > pilotInput) Console.WriteLine($"{hunterGuess} is too high.");
    else if (hunterGuess < pilotInput) Console.WriteLine($"{hunterGuess} is too low.");
    else break;
}

Console.WriteLine("That is the correct number!");