int inputNumber = AskForNumber("Please enter a number");

if (inputNumber % 2 == 0)
    Console.WriteLine($"The number {inputNumber} is even. Tick!");
else
    Console.WriteLine($"The number {inputNumber} is odd. Tock!");

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}