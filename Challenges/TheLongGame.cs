
Console.WriteLine("Please enter your name.");
string? playerName = Console.ReadLine();
int playerScore;

if (File.Exists($"{playerName}.txt"))
{
    playerScore = int.Parse(File.ReadAllText($"{playerName}.txt"));
    Console.WriteLine($"Your score from your previous session was {playerScore}.");
}
else { playerScore = 0; }

Console.WriteLine("Now press any key except Enter. Your score should increase on each key press. Press Enter when you've had enough.");
ConsoleKey key;

do
{
    key = Console.ReadKey(true).Key;
    playerScore++;
    Console.WriteLine($"Current score is {playerScore}");

} while (key != ConsoleKey.Enter);

File.WriteAllText($"{playerName}.txt", playerScore.ToString());