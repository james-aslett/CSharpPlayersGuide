for (int num = 1; num <= 100; num++)

    if (num % 5 == 0 && num % 3 == 0) WriteBlastTypeAndSetColor(num, "Combined", ConsoleColor.Blue);
    else if (num % 3 == 0) WriteBlastTypeAndSetColor(num, "Fire", ConsoleColor.Red);
    else if (num % 5 == 0) WriteBlastTypeAndSetColor(num, "Electric", ConsoleColor.Yellow);
    else WriteBlastTypeAndSetColor(num, "Normal", ConsoleColor.White);

static void WriteBlastTypeAndSetColor(int num, string blastType, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine($"{num}: {blastType} blast");
    Console.ResetColor();
}
