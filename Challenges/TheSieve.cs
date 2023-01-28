
Console.WriteLine("Please choose from the following:");
Console.WriteLine("1: Even numbers");
Console.WriteLine("2: Positive numbers");
Console.WriteLine("3: Multiples of ten");
int choice = Convert.ToInt32(Console.Read());

Sieve sieve = choice switch
{
    1 => new Sieve(IsEven),
    2 => new Sieve(IsPositive),
    3 => new Sieve(IsMultipleOfTen),
    _ => throw new NotImplementedException()
};

while (true)
{
    Console.Write("Enter a number: ");
    int number = Convert.ToInt32(Console.ReadLine());
    string goodOrBad = sieve.IsGood(number) ? "good" : "bad";
    Console.WriteLine($"That number is {goodOrBad}.");
}

bool IsEven(int number) => number % 2 == 0;
bool IsPositive(int number) => number > 0;
bool IsMultipleOfTen(int number) => number % 10 == 0;

public class Sieve
{
    private readonly Func<int, bool> _decisionFunction;

    public Sieve(Func<int, bool> decisionFunction) => _decisionFunction = decisionFunction;

    public bool IsGood(int number)
    {
        return _decisionFunction(number);
    }
}
