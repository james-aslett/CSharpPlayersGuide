int manticoreHP = 10;
int cityHP = 15;
int roundNumber = 1;

int manticoreLocation;
int canonRange;

do manticoreLocation = AskForNumberInRange("Player 1, how far away from the city to you want to station the Manticore? Enter a number between 1-100", 1, 100);
while (manticoreLocation < 1 | manticoreLocation > 100);

Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Player 2, it is your turn.");
Console.WriteLine();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"STATUS: Round {roundNumber} | City's health {cityHP} | Manticore's health {manticoreHP}");
    Console.WriteLine($"The canon is expected to deal {CalculateCanonDamage(roundNumber)} damage this round");
    Console.WriteLine();
    roundNumber++;

    do
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        canonRange = AskForNumberInRange("Enter the desired canon range, between 1-100", 1, 100);
    }
    while (canonRange < 1 | canonRange > 100);

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(TargetResponseText(canonRange, manticoreLocation));
    Console.WriteLine();

    if (canonRange == manticoreLocation) manticoreHP -= 1;
    else cityHP -= 1;

    if (manticoreHP == 0 | cityHP == 0) break;
}

FinalOutcome(manticoreHP, cityHP);

int AskForNumber(string text)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(text);
    int number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    return number;
}

int AskForNumberInRange(string text, int min, int max)
{
    while (true)
    {
        int num = AskForNumber(text);
        if (num >= min && num < max) return num;
    }
}

int CalculateCanonDamage(int roundNumber)
{
    if (roundNumber % 3 == 0 && roundNumber % 5 == 0) return 10;
    else if (roundNumber % 3 == 0 ^ roundNumber % 5 == 0) return 3;
    else return 1;
}

string TargetResponseText(int canonRange, int manticoreLocation)
{
    if (canonRange > manticoreLocation) return "That round OVERSHOT the target";
    else if (canonRange < manticoreLocation) return "That round FELL SHORT of the target";
    else return "That round was a DIRECT HIT!";
}

void FinalOutcome(int manticoreHP, int cityHP)
{
    if (manticoreHP < cityHP)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Manticore was destoyed! The city is saved!");
        PlayTune("Victory");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The city was destoyed. The Manticore lives on.");
        PlayTune("Defeat");
    }
}

void PlayTune(string tune)
{
    if (tune == "Victory")
    {
        Console.Beep(440, 500);
        Console.Beep(440, 150);
        Console.Beep(660, 1000);
    }
    else
    {
        Console.Beep(440, 500);
        Console.Beep(420, 500);
        Console.Beep(400, 1000);
    }
}