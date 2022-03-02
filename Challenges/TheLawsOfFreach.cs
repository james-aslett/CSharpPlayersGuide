int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

int currentSmallest = int.MaxValue;
int total = 0;

foreach (int value in array)
{
    if (value < currentSmallest)
        currentSmallest = value;

    total += value;
}

float average = (float)total / array.Length;

Console.WriteLine($"The smallest value in the array is {currentSmallest}");
Console.WriteLine($"The average is {average}");