Console.WriteLine("Please enter a number.");
int inputNumber = Convert.ToInt32(Console.ReadLine());
if (inputNumber % 2 == 0)
    Console.WriteLine($"The number {inputNumber} is even. Tick!");
else
    Console.WriteLine($"The number {inputNumber} is odd. Tock!");