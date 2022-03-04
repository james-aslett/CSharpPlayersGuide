int[] original = new int[5];

for (int i = 0; i < 5; i++)
{
    int number = AskForNumber("Enter a number: ");
    original[i] = number;
}

int[] copy = new int[5];

for (int i = 0; i < 5; i++) copy[i] = original[i];

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Original = {original[i]} and Copy = {copy[i]}");
}

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}