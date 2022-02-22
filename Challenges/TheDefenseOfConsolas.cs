Console.Title = "Defense of Consolas";
Console.WriteLine("Enter target row");
int row = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter target column");
int col = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Deploy to :");

Console.WriteLine($"Row {row} column {col - 1}");
Console.WriteLine($"Row {row - 1} column {col}");
Console.WriteLine($"Row {row} column {col + 1}");
Console.WriteLine($"Row {row + 1} column {col}");

Console.Beep(440, 500);
Console.Beep(440, 150);
Console.Beep(660, 1000);