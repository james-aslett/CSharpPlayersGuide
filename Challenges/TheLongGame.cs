
Console.WriteLine("Please enter your name.");
String playerName = Console.ReadLine();
int playerScore = 0;
ConsoleKey key;

do
{
    key = Console.ReadKey(true).Key;
    playerScore++;
    Console.WriteLine($"Current score is {playerScore }");

} while (key != ConsoleKey.Enter);

//when player presses Enter, save their score in a file, eg: [username].txt
File.WriteAllText($"{playerName}.txt", playerScore.ToString());

//when user enters name at start, start with previously saved score if they have one

