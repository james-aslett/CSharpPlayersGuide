Console.WriteLine("Please enter a number.");
int number = Convert.ToInt32(Console.ReadLine());
if (number % 2 == 0)
{
    Console.WriteLine($"The number {number} is even. Tick!");
}
else
{
    Console.WriteLine($"The number {number} is odd. Tock!");
}