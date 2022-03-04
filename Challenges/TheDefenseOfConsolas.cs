Console.Title = "Defense of Consolas";

int row = AskForNumber("Enter target row");
int col = AskForNumber("Enter target column");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Deploy to :");

Console.WriteLine($"Row {row} column {col - 1}");
Console.WriteLine($"Row {row - 1} column {col}");
Console.WriteLine($"Row {row} column {col + 1}");
Console.WriteLine($"Row {row + 1} column {col}");

Console.Beep(440, 500);
Console.Beep(440, 150);
Console.Beep(660, 1000);

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}